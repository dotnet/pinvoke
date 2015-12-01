// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using PInvoke;
using Xunit;
using static PInvoke.Constants;
using static PInvoke.Kernel32;

public partial class Kernel32
{
    private readonly Random random = new Random();

    [Fact]
    public void CreateProcess_CmdListDirectories()
    {
        STARTUPINFO startupInfo = STARTUPINFO.Create();
        PROCESS_INFORMATION processInformation;
        bool result = CreateProcess(
            Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.SystemX86), "cmd.exe"),
            "/c dir",
            null,
            null,
            false,
            CreateProcessFlags.CREATE_NO_WINDOW,
            IntPtr.Zero,
            null,
            ref startupInfo,
            out processInformation);
        if (!result)
        {
            throw new Win32Exception();
        }

        CloseHandle(processInformation.hProcess);
        CloseHandle(processInformation.hThread);
    }

    [Fact]
    public unsafe void CreateProcess_SetUnicodeEnvironment()
    {
        string commandOutputFileName = Path.GetTempFileName();
        try
        {
            string environment = "abc=123\0def=456\0\0";
            fixed (void* environmentBlock = environment)
            {
                STARTUPINFO startupInfo = STARTUPINFO.Create();
                PROCESS_INFORMATION processInformation;
                bool result = CreateProcess(
                    Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.SystemX86), "cmd.exe"),
                    $"/c set > \"{commandOutputFileName}\"",
                    null,
                    null,
                    false,
                    CreateProcessFlags.CREATE_NO_WINDOW | CreateProcessFlags.CREATE_UNICODE_ENVIRONMENT,
                    new IntPtr(environmentBlock),
                    null,
                    ref startupInfo,
                    out processInformation);
                if (!result)
                {
                    throw new Win32Exception();
                }

                try
                {
                    // Wait for the process to exit.
                    Assert.Equal(
                        WaitForSingleObjectResult.WAIT_OBJECT_0,
                        WaitForSingleObject(new SafeObjectHandle(processInformation.hProcess, false), 5000));
                }
                finally
                {
                    CloseHandle(processInformation.hProcess);
                    CloseHandle(processInformation.hThread);
                }
            }

            string[] envVars = File.ReadAllLines(commandOutputFileName);
            Assert.Contains("abc=123", envVars);
            Assert.Contains("def=456", envVars);
        }
        finally
        {
            File.Delete(commandOutputFileName);
        }
    }

    [Fact]
    public void CreateFile_DeleteOnClose()
    {
        string testPath = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
        using (var tempFileHandle = CreateFile(
            testPath,
            PInvoke.Kernel32.FileAccess.GENERIC_WRITE,
            PInvoke.Kernel32.FileShare.FILE_SHARE_READ,
            null,
            CreationDisposition.CREATE_ALWAYS,
            CreateFileFlags.FILE_FLAG_DELETE_ON_CLOSE,
            new SafeObjectHandle()))
        {
            Assert.True(File.Exists(testPath));
        }

        Assert.False(File.Exists(testPath));
    }

    [Fact]
    public void FindFirstFile_NoMatches()
    {
        WIN32_FIND_DATA data;
        using (var handle = FindFirstFile("foodoesnotexist", out data))
        {
            Assert.True(handle.IsInvalid);
        }
    }

    [Fact]
    public void FindFirstFile_FindNextFile()
    {
        string testPath = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
        try
        {
            Directory.CreateDirectory(testPath);
            string aTxt = Path.Combine(testPath, "a.txt");
            File.WriteAllText(aTxt, string.Empty);
            File.SetAttributes(aTxt, FileAttributes.Archive);

            var bTxt = Path.Combine(testPath, "b.txt");
            File.WriteAllText(bTxt, string.Empty);
            File.SetAttributes(bTxt, FileAttributes.Normal);

            WIN32_FIND_DATA data;
            using (var handle = FindFirstFile(Path.Combine(testPath, "*.txt"), out data))
            {
                Assert.False(handle.IsInvalid);
                Assert.Equal("a.txt", data.cFileName);
                Assert.Equal(FileAttribute.FILE_ATTRIBUTE_ARCHIVE, data.dwFileAttributes);

                Assert.True(FindNextFile(handle, out data));
                Assert.Equal("b.txt", data.cFileName);
                Assert.Equal(FileAttribute.FILE_ATTRIBUTE_NORMAL, data.dwFileAttributes);

                Assert.False(FindNextFile(handle, out data));
            }
        }
        finally
        {
            Directory.Delete(testPath, true);
        }
    }

    [Fact]
    public void Win32Exception_DerivesFromBCLType()
    {
        Assert.IsAssignableFrom<System.ComponentModel.Win32Exception>(new PInvoke.Win32Exception(1));
    }

    [Fact]
    public void GetCurrentThreadId_SameAsAppDomainOne()
    {
#pragma warning disable CS0618 // Type or member is obsolete
        int frameworkValue = AppDomain.GetCurrentThreadId();
#pragma warning restore CS0618 // Type or member is obsolete
        int pinvokeValue = GetCurrentThreadId();

        Assert.Equal(frameworkValue, pinvokeValue);
    }

    [Fact]
    public void GetCurrentProcessId_SameAsProcessOne()
    {
        int frameworkValue = Process.GetCurrentProcess().Id;
        int pinvokeValue = GetCurrentProcessId();

        Assert.Equal(frameworkValue, pinvokeValue);
    }

    [Fact]
    public void CreateToolhelp32Snapshot_CanGetCurrentProcess()
    {
        var currentProcess = GetCurrentProcessId();
        var snapshot = CreateToolhelp32Snapshot(CreateToolhelp32SnapshotFlags.TH32CS_SNAPPROCESS, 0);
        using (snapshot)
        {
            var processes = Process32Enumerate(snapshot).ToList();
            Assert.Contains(processes, p => p.th32ProcessID == currentProcess);
        }
    }

    [Fact]
    public void OpenProcess_CannotOpenSystem()
    {
        using (var system = OpenProcess(ProcessAccess.PROCESS_TERMINATE, false, 0x00000000))
        {
            var error = (Win32ErrorCode)Marshal.GetLastWin32Error();
            Assert.True(system.IsInvalid);
            Assert.Equal(Win32ErrorCode.ERROR_INVALID_PARAMETER, error);
        }
    }

    [Fact]
    public void OpenProcess_CanOpenSelf()
    {
        var currentProcessId = GetCurrentProcessId();
        var currentProcess = OpenProcess(ProcessAccess.PROCESS_QUERY_LIMITED_INFORMATION, false, currentProcessId);
        using (currentProcess)
        {
            Assert.False(currentProcess.IsInvalid);
        }
    }

    [Fact]
    public void QueryFullProcessImageName_CanGetForCurrentProcess()
    {
        var currentProcessId = GetCurrentProcessId();
        var currentProcess = OpenProcess(ProcessAccess.PROCESS_QUERY_LIMITED_INFORMATION, false, currentProcessId);
        using (currentProcess)
        {
            var actual = QueryFullProcessImageName(currentProcess);
            var expected = Process.GetCurrentProcess().MainModule.FileName;

            Assert.Equal(expected, actual, ignoreCase: true);
        }
    }

    [Fact]
    public void ReadFile_CanReadSynchronously()
    {
        var testPath = Path.GetTempFileName();
        try
        {
            const int testDataSize = 256;
            var expected = new byte[testDataSize];
            this.random.NextBytes(expected);

            File.WriteAllBytes(testPath, expected);

            using (var file = CreateFile(
                testPath,
                PInvoke.Kernel32.FileAccess.GENERIC_READ,
                PInvoke.Kernel32.FileShare.None,
                null,
                CreationDisposition.OPEN_EXISTING,
                CreateFileFlags.FILE_ATTRIBUTE_NORMAL,
                new SafeObjectHandle()))
            {
                var actual = ReadFile(file, testDataSize);
                var actualData = actual.Skip(actual.Offset).Take(actual.Count);
                Assert.Equal(expected, actualData);
            }
        }
        finally
        {
            File.Delete(testPath);
        }
    }

    [Fact]
    public unsafe void ReadFile_CanReadOverlappedWithWait()
    {
        var testPath = Path.GetTempFileName();
        try
        {
            const int testDataSize = 256;
            var expected = new byte[testDataSize];
            this.random.NextBytes(expected);

            File.WriteAllBytes(testPath, expected);

            using (var file = CreateFile(
                testPath,
                PInvoke.Kernel32.FileAccess.GENERIC_READ,
                PInvoke.Kernel32.FileShare.None,
                null,
                CreationDisposition.OPEN_EXISTING,
                CreateFileFlags.FILE_FLAG_OVERLAPPED,
                new SafeObjectHandle()))
            {
                var overlapped = default(OVERLAPPED);
                var actual = new byte[testDataSize];
                fixed (byte* pActual = actual)
                {
                    var result = ReadFile(file, pActual, testDataSize, null, &overlapped);
                    if (result)
                    {
                        // We can't really test anything not covered by another test here :(
                        return;
                    }

                    var lastError = GetLastError();
                    Assert.Equal(Win32ErrorCode.ERROR_IO_PENDING, lastError);
                    int bytesTransfered;
                    var overlappedResult = GetOverlappedResult(file, &overlapped, out bytesTransfered, true);
                    Assert.Equal(testDataSize, bytesTransfered);
                    Assert.True(overlappedResult);
                }

                Assert.Equal(expected, actual);
            }
        }
        finally
        {
            File.Delete(testPath);
        }
    }

    [Fact]
    public unsafe void ReadFile_CanReadOverlappedWithWaitHandle()
    {
        var testPath = Path.GetTempFileName();
        try
        {
            const int testDataSize = 256;
            var expected = new byte[testDataSize];
            this.random.NextBytes(expected);

            File.WriteAllBytes(testPath, expected);

            using (var file = CreateFile(
                testPath,
                PInvoke.Kernel32.FileAccess.GENERIC_READ,
                PInvoke.Kernel32.FileShare.None,
                null,
                CreationDisposition.OPEN_EXISTING,
                CreateFileFlags.FILE_FLAG_OVERLAPPED,
                new SafeObjectHandle()))
            {
                var overlapped = default(OVERLAPPED);
                var actual = new byte[testDataSize];
                var evt = new ManualResetEvent(false);
                overlapped.hEvent = evt.SafeWaitHandle.DangerousGetHandle();
                fixed (byte* pActual = actual)
                {
                    var result = ReadFile(file, pActual, testDataSize, null, &overlapped);
                    if (result)
                    {
                        // We can't really test anything not covered by another test here :(
                        return;
                    }

                    var lastError = GetLastError();
                    Assert.Equal(Win32ErrorCode.ERROR_IO_PENDING, lastError);
                    Assert.True(evt.WaitOne(TimeSpan.FromSeconds(30)));
                    int bytesTransfered;
                    var overlappedResult = GetOverlappedResult(file, &overlapped, out bytesTransfered, false);
                    Assert.Equal(testDataSize, bytesTransfered);
                    Assert.True(overlappedResult);
                }

                Assert.Equal(expected, actual);
            }
        }
        finally
        {
            File.Delete(testPath);
        }
    }

    [Fact]
    public void WriteFile_CanWriteSynchronously()
    {
        var testPath = Path.GetTempFileName();
        try
        {
            const int testDataSize = 256;
            var expected = new byte[testDataSize];
            this.random.NextBytes(expected);

            using (var file = CreateFile(
                testPath,
                PInvoke.Kernel32.FileAccess.GENERIC_WRITE,
                PInvoke.Kernel32.FileShare.None,
                null,
                CreationDisposition.OPEN_EXISTING,
                CreateFileFlags.FILE_ATTRIBUTE_NORMAL,
                new SafeObjectHandle()))
            {
                var bytesWritten = WriteFile(file, new ArraySegment<byte>(expected));
                Assert.Equal(testDataSize, bytesWritten);
            }

            var actual = File.ReadAllBytes(testPath);

            Assert.Equal(expected, actual);
        }
        finally
        {
            File.Delete(testPath);
        }
    }

    [Fact]
    public unsafe void WriteFile_CanWriteOverlappedWithWait()
    {
        var testPath = Path.GetTempFileName();
        try
        {
            const int testDataSize = 256;
            var expected = new byte[testDataSize];
            this.random.NextBytes(expected);

            using (var file = CreateFile(
                testPath,
                PInvoke.Kernel32.FileAccess.GENERIC_WRITE,
                PInvoke.Kernel32.FileShare.None,
                null,
                CreationDisposition.OPEN_EXISTING,
                CreateFileFlags.FILE_FLAG_OVERLAPPED,
                new SafeObjectHandle()))
            {
                var overlapped = default(OVERLAPPED);
                fixed (byte* pExpected = expected)
                {
                    var result = WriteFile(file, pExpected, testDataSize, null, &overlapped);
                    if (result)
                    {
                        // We can't really test anything not covered by another test here :(
                        return;
                    }

                    var lastError = GetLastError();
                    Assert.Equal(Win32ErrorCode.ERROR_IO_PENDING, lastError);
                    int bytesTransfered;
                    var overlappedResult = GetOverlappedResult(file, &overlapped, out bytesTransfered, true);
                    Assert.Equal(testDataSize, bytesTransfered);
                    Assert.True(overlappedResult);
                }
            }

            var actual = File.ReadAllBytes(testPath);

            Assert.Equal(expected, actual);
        }
        finally
        {
            File.Delete(testPath);
        }
    }

    [Fact]
    public unsafe void WriteFile_CanWriteOverlappedWithWaitHandle()
    {
        var testPath = Path.GetTempFileName();
        try
        {
            const int testDataSize = 256;
            var expected = new byte[testDataSize];
            this.random.NextBytes(expected);

            using (var file = CreateFile(
                testPath,
                PInvoke.Kernel32.FileAccess.GENERIC_WRITE,
                PInvoke.Kernel32.FileShare.None,
                null,
                CreationDisposition.OPEN_EXISTING,
                CreateFileFlags.FILE_FLAG_OVERLAPPED,
                new SafeObjectHandle()))
            {
                var overlapped = default(OVERLAPPED);
                var evt = new ManualResetEvent(false);
                overlapped.hEvent = evt.SafeWaitHandle.DangerousGetHandle();
                fixed (byte* pExpected = expected)
                {
                    var result = WriteFile(file, pExpected, testDataSize, null, &overlapped);
                    if (result)
                    {
                        // We can't really test anything not covered by another test here :(
                        return;
                    }

                    var lastError = GetLastError();
                    Assert.Equal(Win32ErrorCode.ERROR_IO_PENDING, lastError);
                    Assert.True(evt.WaitOne(TimeSpan.FromSeconds(30)));
                    int bytesTransfered;
                    var overlappedResult = GetOverlappedResult(file, &overlapped, out bytesTransfered, false);
                    Assert.Equal(testDataSize, bytesTransfered);
                    Assert.True(overlappedResult);
                }
            }

            var actual = File.ReadAllBytes(testPath);

            Assert.Equal(expected, actual);
        }
        finally
        {
            File.Delete(testPath);
        }
    }

    [Fact]
    public unsafe void CancelIo_CancelWrite()
    {
        var testPath = Path.GetTempFileName();
        try
        {
            const int testDataSize = 256;
            var buffer = new byte[testDataSize];

            using (var file = CreateFile(
                testPath,
                PInvoke.Kernel32.FileAccess.GENERIC_WRITE,
                PInvoke.Kernel32.FileShare.None,
                null,
                CreationDisposition.OPEN_EXISTING,
                CreateFileFlags.FILE_FLAG_OVERLAPPED,
                new SafeObjectHandle()))
            {
                var overlapped = default(OVERLAPPED);
                fixed (byte* pExpected = buffer)
                {
                    var result = WriteFile(file, pExpected, testDataSize, null, &overlapped);
                    if (result)
                    {
                        // We can't really test anything not covered by another test here :(
                        return;
                    }

                    var lastError = GetLastError();
                    Assert.Equal(Win32ErrorCode.ERROR_IO_PENDING, lastError);
                    try
                    {
                        Assert.True(CancelIo(file));
                    }
                    finally
                    {
                        int bytesTransfered;
                        GetOverlappedResult(file, &overlapped, out bytesTransfered, true);
                    }
                }
            }
        }
        finally
        {
            File.Delete(testPath);
        }
    }

    [Fact]
    public unsafe void CancelIoEx_CancelWriteAll()
    {
        var testPath = Path.GetTempFileName();
        try
        {
            const int testDataSize = 256;
            var buffer = new byte[testDataSize];

            using (var file = CreateFile(
                testPath,
                PInvoke.Kernel32.FileAccess.GENERIC_WRITE,
                PInvoke.Kernel32.FileShare.None,
                null,
                CreationDisposition.OPEN_EXISTING,
                CreateFileFlags.FILE_FLAG_OVERLAPPED,
                new SafeObjectHandle()))
            {
                var overlapped = default(OVERLAPPED);
                fixed (byte* pExpected = buffer)
                {
                    var result = WriteFile(file, pExpected, testDataSize, null, &overlapped);
                    if (result)
                    {
                        // We can't really test anything not covered by another test here :(
                        return;
                    }

                    var lastError = GetLastError();
                    Assert.Equal(Win32ErrorCode.ERROR_IO_PENDING, lastError);
                    try
                    {
                        var cancelled = CancelIoEx(file, null);

                        // We can't assert that it's true as if the IO finished already it'll fail with ERROR_NOT_FOUND
                        if (!cancelled)
                        {
                            Assert.Equal(Win32ErrorCode.ERROR_NOT_FOUND, GetLastError());
                        }
                    }
                    finally
                    {
                        int bytesTransfered;
                        GetOverlappedResult(file, &overlapped, out bytesTransfered, true);
                    }
                }
            }
        }
        finally
        {
            File.Delete(testPath);
        }
    }

    [Fact]
    public unsafe void CancelIoEx_CancelWriteSpecific()
    {
        var testPath = Path.GetTempFileName();
        try
        {
            const int testDataSize = 256;
            var buffer = new byte[testDataSize];

            using (var file = CreateFile(
                testPath,
                PInvoke.Kernel32.FileAccess.GENERIC_WRITE,
                PInvoke.Kernel32.FileShare.None,
                null,
                CreationDisposition.OPEN_EXISTING,
                CreateFileFlags.FILE_FLAG_OVERLAPPED,
                new SafeObjectHandle()))
            {
                var overlapped = default(OVERLAPPED);
                fixed (byte* pExpected = buffer)
                {
                    var result = WriteFile(file, pExpected, testDataSize, null, &overlapped);
                    if (result)
                    {
                        // We can't really test anything not covered by another test here :(
                        return;
                    }

                    var lastError = GetLastError();
                    Assert.Equal(Win32ErrorCode.ERROR_IO_PENDING, lastError);
                    try
                    {
                        var cancelled = CancelIoEx(file, &overlapped);

                        // We can't assert that it's true as if the IO finished already it'll fail with ERROR_NOT_FOUND
                        if (!cancelled)
                        {
                            Assert.Equal(Win32ErrorCode.ERROR_NOT_FOUND, GetLastError());
                        }
                    }
                    finally
                    {
                        int bytesTransfered;
                        GetOverlappedResult(file, &overlapped, out bytesTransfered, true);
                    }
                }
            }
        }
        finally
        {
            File.Delete(testPath);
        }
    }

    [Fact]
    public void IsWow64Process_ReturnExpectedValue()
    {
        var expected = Environment.Is64BitOperatingSystem && !Environment.Is64BitProcess;
        var actual = IsWow64Process(GetCurrentProcess());
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void CreatePipe_ReadWrite()
    {
        SafeObjectHandle readPipe, writePipe;
        Assert.True(CreatePipe(out readPipe, out writePipe, null, 0));
        using (readPipe)
        using (writePipe)
        {
            var data = new byte[] { 1, 2, 3 };
            Assert.Equal(data.Length, WriteFile(writePipe, new ArraySegment<byte>(data)));
            Assert.Equal(data, ReadFile(readPipe, data.Length));
        }
    }

    [IgnoreOnOsVersionUnderFact("6.1")]
    public void K32EmptyWorkingSet_Run()
    {
        using (var pid = GetCurrentProcess())
        {
            Assert.True(K32EmptyWorkingSet(pid));
        }
    }

    [Fact]
    public void LoadLibrary_And_FreeLibrary()
    {
        using (var library = LoadLibrary("kernel32.dll"))
        {
            Assert.False(library.IsInvalid);
        }
    }

    [Fact]
    public void GetConsoleWindow_DoesNotThrow()
    {
        // No assert possible as the answer depends on the test runner, we only want to know that the method can be called successfully.
        GetConsoleWindow();
    }

    [Fact]
    public unsafe void CreateNamedPipe_ReadWrite()
    {
        var pipeName = @"\\.\pipe\pinvoke_tests_" + Guid.NewGuid();

        var server = CreateNamedPipe(
            pipeName,
            PipeAccessMode.PIPE_ACCESS_DUPLEX | PipeAccessMode.FILE_FLAG_FIRST_PIPE_INSTANCE | PipeAccessMode.FILE_FLAG_OVERLAPPED,
            PipeMode.PIPE_TYPE_MESSAGE | PipeMode.PIPE_READMODE_MESSAGE | PipeMode.PIPE_REJECT_REMOTE_CLIENTS,
            PIPE_UNLIMITED_INSTANCES,
            255,
            255,
            0,
            null);

        Assert.False(server.IsInvalid);
        using (server)
        {
            var connectEvent = new ManualResetEvent(false);
            var connectOverlapped = default(OVERLAPPED);
            connectOverlapped.hEvent = connectEvent.SafeWaitHandle.DangerousGetHandle();

            Assert.False(ConnectNamedPipe(server, &connectOverlapped));
            Assert.Equal(Win32ErrorCode.ERROR_IO_PENDING, GetLastError());
            try
            {
                Assert.True(WaitNamedPipe(pipeName, NMPWAIT_NOWAIT));

                var client = CreateFile(
                    pipeName,
                    PInvoke.Kernel32.FileAccess.GENERIC_READ | PInvoke.Kernel32.FileAccess.FILE_GENERIC_WRITE,
                    PInvoke.Kernel32.FileShare.None,
                    null,
                    CreationDisposition.OPEN_EXISTING,
                    0,
                    SafeObjectHandle.Null);

                Assert.False(client.IsInvalid);
                using (client)
                {
                    Assert.True(connectEvent.WaitOne(TimeSpan.FromMilliseconds(100)));
                    Assert.True(SetNamedPipeHandleState(client, PipeMode.PIPE_READMODE_MESSAGE, null, null));

                    var writeBuffer = this.GetRandomSegment(42);
                    WriteFile(client, writeBuffer);
                    Assert.Equal(writeBuffer, ReadFile(server, writeBuffer.Count));

                    Assert.True(FlushFileBuffers(client));
                    Assert.True(FlushFileBuffers(server));
                }
            }
            finally
            {
                Assert.True(DisconnectNamedPipe(server));
            }
        }
    }

    private ArraySegment<byte> GetRandomSegment(int size)
    {
        var result = new ArraySegment<byte>(new byte[size]);
        this.random.NextBytes(result.Array);
        return result;
    }
}
