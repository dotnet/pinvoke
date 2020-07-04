// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using PInvoke;
using Xunit;
using static PInvoke.Kernel32;

public partial class Kernel32Facts
{
    private static unsafe Kernel32.THREAD_START_ROUTINE threadProc = new THREAD_START_ROUTINE(CreateThread_Test_ThreadMain);
    private readonly Random random = new Random();

    [Fact]
    public void Beep_Nostalgia()
    {
        // Beep usually returns true -- but not on servers (like AppVeyor CI).
        Beep(750, 10);
    }

    [Fact]
    public void CreateProcess_CmdListDirectories()
    {
        STARTUPINFO startupInfo = STARTUPINFO.Create();
        PROCESS_INFORMATION processInformation;
        bool result = CreateProcess(
            Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.SystemX86), "cmd.exe"),
            "/c dir",
            IntPtr.Zero,
            IntPtr.Zero,
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
                    (SECURITY_ATTRIBUTES?)null,
                    null,
                    false,
                    CreateProcessFlags.CREATE_NO_WINDOW | CreateProcessFlags.CREATE_UNICODE_ENVIRONMENT,
                    environmentBlock,
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
            ACCESS_MASK.GenericRight.GENERIC_WRITE,
            Kernel32.FileShare.FILE_SHARE_READ,
            IntPtr.Zero,
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
    [UseCulture("en-US")]
    public void FormatMessage_NTStatus()
    {
        using (var ntdll = LoadLibrary("ntdll.dll"))
        {
            string actual = FormatMessage(
                FormatMessageFlags.FORMAT_MESSAGE_FROM_HMODULE,
                ntdll.DangerousGetHandle(),
                (int)NTSTATUS.Code.DBG_REPLY_LATER,
#if NETFRAMEWORK || NETSTANDARD2_0_ORLATER
                CultureInfo.CurrentCulture.LCID,
#else
                0,
#endif
                null,
                500);
            Assert.Equal("Debugger will reply later", actual);
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
            var win32Process = processes.Single(p => p.th32ProcessID == currentProcess);
            var netProcess = Process.GetCurrentProcess();
            Assert.Equal(netProcess.MainModule.ModuleName, win32Process.ExeFile, true);
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
    public void GetProcessTimes_CanGetCurrentProcessTimes()
    {
        var currentProcessId = GetCurrentProcessId();
        var currentProcess = OpenProcess(ProcessAccess.PROCESS_QUERY_LIMITED_INFORMATION, false, currentProcessId);
        using (currentProcess)
        {
            Kernel32.FILETIME create, exit, kernel, user;
            var totalProcessTime = Process.GetCurrentProcess().TotalProcessorTime;
            Assert.True(GetProcessTimes(currentProcess, out create, out exit, out kernel, out user));
            var expected = Math.Truncate(totalProcessTime.TotalSeconds / 10);
            var actual = Math.Truncate(new TimeSpan(kernel + user).TotalSeconds / 10);
            Assert.Equal(expected, actual);
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
                ACCESS_MASK.GenericRight.GENERIC_READ,
                Kernel32.FileShare.None,
                IntPtr.Zero,
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
                ACCESS_MASK.GenericRight.GENERIC_READ,
                Kernel32.FileShare.None,
                (SECURITY_ATTRIBUTES?)null,
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
                ACCESS_MASK.GenericRight.GENERIC_READ,
                Kernel32.FileShare.None,
                (SECURITY_ATTRIBUTES?)null,
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
                ACCESS_MASK.GenericRight.GENERIC_WRITE,
                Kernel32.FileShare.None,
                IntPtr.Zero,
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
                ACCESS_MASK.GenericRight.GENERIC_WRITE,
                Kernel32.FileShare.None,
                (SECURITY_ATTRIBUTES?)null,
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
                ACCESS_MASK.GenericRight.GENERIC_WRITE,
                Kernel32.FileShare.None,
                (SECURITY_ATTRIBUTES?)null,
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
                ACCESS_MASK.GenericRight.GENERIC_WRITE,
                Kernel32.FileShare.None,
                (SECURITY_ATTRIBUTES?)null,
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
                ACCESS_MASK.GenericRight.GENERIC_WRITE,
                Kernel32.FileShare.None,
                (SECURITY_ATTRIBUTES?)null,
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
                ACCESS_MASK.GenericRight.GENERIC_WRITE,
                Kernel32.FileShare.None,
                (SECURITY_ATTRIBUTES?)null,
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
        Assert.True(CreatePipe(out readPipe, out writePipe, IntPtr.Zero, 0));
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
            (SECURITY_ATTRIBUTES?)null);

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
                    (uint)ACCESS_MASK.GenericRight.GENERIC_READ | (uint)Kernel32.FileAccess.FILE_GENERIC_WRITE,
                    Kernel32.FileShare.None,
                    (SECURITY_ATTRIBUTES?)null,
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

    [Fact]
    public unsafe void LocalAlloc_LocalFree()
    {
        IntPtr hlocal = LocalAlloc_IntPtr(LocalAllocFlags.LMEM_FIXED, 5);
        Assert.Equal(IntPtr.Zero, LocalFree(hlocal));
    }

    [Fact]
    public unsafe void Find_And_Load_Bmp_Icon_Resource()
    {
        // shell32.dll contains at position #1 the icon for unknown files
        using (var imageRes = LoadLibrary("shell32.dll"))
        {
            Assert.False(imageRes.IsInvalid);

            // Locate where the resource is (Can be in some language dll)
            var resInfo = FindResource(imageRes, MAKEINTRESOURCE(1), RT_GROUP_ICON);
            Assert.NotEqual(IntPtr.Zero, resInfo);

            // Get a handle to the resource
            var resHGlobal = LoadResource(imageRes, resInfo);
            Assert.NotEqual(IntPtr.Zero, resHGlobal);

            // Get a pointer to the data
            var ptr = LockResource(resHGlobal);
            Assert.True(ptr != null);
        }
    }

    [Fact]
    public unsafe void Get_Size_Of_Bmp_Icon_Resource()
    {
        using (var imageRes = LoadLibrary("shell32.dll"))
        {
            Assert.False(imageRes.IsInvalid);

            // Load the icon for unknown files
            var resInfo = FindResource(imageRes, MAKEINTRESOURCE(1), RT_GROUP_ICON);
            Assert.NotEqual(IntPtr.Zero, resInfo);

            // Should be able to get it's size
            var size = SizeofResource(imageRes, resInfo);
            Assert.NotEqual(0, size);
        }
    }

    [Fact]
    public unsafe void Enumerate_Imageres_Resources()
    {
        // Let's load the icon for unknown files
        using (var imageRes = LoadLibrary("shell32.dll"))
        {
            Assert.False(imageRes.IsInvalid);

            List<int> intResources = new List<int>();

            EnumResNameProc onResourceFound = (module, type, name, lparam) =>
            {
                if (IS_INTRESOURCE(name))
                {
                    intResources.Add((int)name);
                }

                return true;
            };

            Assert.True(EnumResourceNames(imageRes, RT_GROUP_ICON, onResourceFound, IntPtr.Zero));

            // The icon for .bmp files
            Assert.Contains(1, intResources);
        }
    }

    [Fact]
    public unsafe void Enumerate_Resource_Languages()
    {
        using (var imageRes = LoadLibrary("shell32.dll"))
        {
            Assert.False(imageRes.IsInvalid);

            // Get bitmap resource IDs.
            List<int> intResources = new List<int>();
            EnumResNameProc onResourceFound = (module, type, name, lparam) =>
            {
                if (IS_INTRESOURCE(name))
                {
                    intResources.Add((int)name);
                }

                return true;
            };

            Assert.True(EnumResourceNames(imageRes, RT_BITMAP, onResourceFound, IntPtr.Zero));
            Assert.NotEmpty(intResources);

            // Get resource languages for bitmap resources.
            List<LANGID> resourceLanguages = new List<LANGID>();
            EnumResLangProc onResourceLanguageFound = (module, type, name, language, lParam) =>
            {
                if (IS_INTRESOURCE(name))
                {
                    resourceLanguages.Add(language);
                }

                return true;
            };

            Assert.True(EnumResourceLanguages(imageRes, RT_BITMAP, MAKEINTRESOURCE(intResources.First()), onResourceLanguageFound, (void*)IntPtr.Zero), GetLastError().ToString());
            Assert.NotEmpty(resourceLanguages);
        }
    }

    [Fact]
    public void SetThreadExectionState_Simple()
    {
        Assert.NotEqual(EXECUTION_STATE.None, SetThreadExecutionState(EXECUTION_STATE.ES_SYSTEM_REQUIRED));
    }

    [Fact]
    public void MAKELANGID_Simple()
    {
        Assert.Equal(0x0409, MAKELANGID(LANGID.PrimaryLanguage.LANG_ENGLISH, LANGID.SubLanguage.SUBLANG_ENGLISH_US).Data);
    }

    [Fact]
    public void GetHandleInformation_DoesNotThrow()
    {
        var manualResetEvent = new ManualResetEvent(false);
        Assert.True(GetHandleInformation(manualResetEvent.SafeWaitHandle, out var lpdwFlags));
    }

    [Fact]
    public void SetHandleInformation_DoesNotThrow()
    {
        var manualResetEvent = new ManualResetEvent(false);
        Assert.True(SetHandleInformation(
            manualResetEvent.SafeWaitHandle,
            HandleFlags.HANDLE_FLAG_INHERIT | HandleFlags.HANDLE_FLAG_PROTECT_FROM_CLOSE,
            HandleFlags.HANDLE_FLAG_NONE));
    }

    /// <summary>
    /// Basic validation for <see cref="Kernel32.CreateThread(SECURITY_ATTRIBUTES*, UIntPtr, THREAD_START_ROUTINE, void*, CreateThreadFlags, uint*)"/>
    ///
    /// Creates a thread by supplying <see cref="CreateThread_Test_ThreadMain(void*)"/> as its ThreadProc/<see cref="Kernel32.THREAD_START_ROUTINE"/>.
    /// The ThreadProc updates a bool value (supplied by the thread that created it) from false -> true. This change
    /// is observed by the calling thread as proof of successful thread-creation.
    ///
    /// Also validates that the (native) Thread-ID for the newly created Thread is different than the (native) Thread-ID
    /// of that of the calling thread.
    /// </summary>
    [Fact]
    public unsafe void CreateThread_Test()
    {
        var result = false;
        var dwNewThreadId = 0u;

        using var hThread =
                Kernel32.CreateThread(
                    null,
                    UIntPtr.Zero,
                    Kernel32Facts.threadProc,
                    &result,
                    Kernel32.CreateThreadFlags.None,
                    &dwNewThreadId);
        Kernel32.WaitForSingleObject(hThread, -1);

        Assert.True(result);
        Assert.NotEqual((uint)Kernel32.GetCurrentThreadId(), dwNewThreadId);
    }

    /// <summary>
    /// Basic validation for <see cref="CreateRemoteThread(IntPtr, SECURITY_ATTRIBUTES*, UIntPtr, THREAD_START_ROUTINE, void*, CreateThreadFlags, uint*)"/>
    /// Note that this test DOES NOT create a true REMOTE thread in a foreign process; it just leverages this function to create a thread in the current (i.e, the test) procrss.
    /// Nevertheless, this approach provides modest confidence that the P/Invoke definition is well-formed.
    ///
    /// Creates a thread by supplying <see cref="CreateThread_Test_ThreadMain(void*)"/> as its ThreadProc/<see cref="Kernel32.THREAD_START_ROUTINE"/>.
    /// The ThreadProc updates a bool value (supplied by the thread that created it) from false -> true. This change
    /// is observed by the calling thread as proof of successful thread-creation.
    ///
    /// Also validates that the (native) Thread-ID for the newly created Thread is different than the (native) Thread-ID
    /// of that of the calling thread.
    /// </summary>
    [Fact]
    public unsafe void CreateRemoteThread_PseudoTest()
    {
        var result = false;
        var dwNewThreadId = 0u;

        using var hProcess = Kernel32.GetCurrentProcess();
        using var hThread =
                Kernel32.CreateRemoteThread(
                    hProcess.DangerousGetHandle(),
                    null,
                    UIntPtr.Zero,
                    Kernel32Facts.threadProc,
                    &result,
                    Kernel32.CreateThreadFlags.None,
                    &dwNewThreadId);
        Kernel32.WaitForSingleObject(hThread, -1);

        Assert.True(result);
        Assert.NotEqual((uint)Kernel32.GetCurrentThreadId(), dwNewThreadId);
    }

    /// <summary>
    /// Basic validation for <see cref="CreateRemoteThreadEx(IntPtr, SECURITY_ATTRIBUTES*, UIntPtr, THREAD_START_ROUTINE, void*, CreateThreadFlags, PROC_THREAD_ATTRIBUTE_LIST*, uint*)"/>
    /// Note that this test DOES NOT create a true REMOTE thread in a foreign process; it just leverages this function to create a thread in the current (i.e, the test) procrss.
    /// Nevertheless, this approach provides modest confidence that the P/Invoke definition is well-formed.
    ///
    /// Creates a thread by supplying <see cref="CreateThread_Test_ThreadMain(void*)"/> as its ThreadProc/<see cref="Kernel32.THREAD_START_ROUTINE"/>.
    /// The ThreadProc updates a bool value (supplied by the thread that created it) from false -> true. This change
    /// is observed by the calling thread as proof of successful thread-creation.
    ///
    /// Also validates that the (native) Thread-ID for the newly created Thread is different than the (native) Thread-ID
    /// of that of the calling thread.
    /// </summary>
    [Fact]
    public unsafe void CreateRemoteThreadEx_PseudoTest()
    {
        var result = false;
        var dwNewThreadId = 0u;

        using var hProcess = Kernel32.GetCurrentProcess();
        using var hThread =
                Kernel32.CreateRemoteThreadEx(
                    hProcess.DangerousGetHandle(),
                    null,
                    UIntPtr.Zero,
                    Kernel32Facts.threadProc,
                    &result,
                    Kernel32.CreateThreadFlags.None,
                    null,
                    &dwNewThreadId);
        Kernel32.WaitForSingleObject(hThread, -1);

        Assert.True(result);
        Assert.NotEqual((uint)Kernel32.GetCurrentThreadId(), dwNewThreadId);
    }

    [Fact]
    public unsafe void GetCurrentThreadStackLimitsTest()
    {
        // Returns the low and high stack-limits of the running thread
        //
        // The parameter 'data' is assumed to be allocated by the caller and capable of
        // carrying two ulong values.
        unsafe uint ThreadStackLimitsThreadProc(void* data)
        {
            ulong lowLimit = 0u;
            ulong highLimit = 0u;
            Kernel32.GetCurrentThreadStackLimits(&lowLimit, &highLimit);

            ulong* limits = (ulong*)data;
            limits[0] = lowLimit;
            limits[1] = highLimit;

            return 1;
        }

        const uint ThreadStackSize = 512 * 1024u;

        var threadStartRoutine = new THREAD_START_ROUTINE(ThreadStackLimitsThreadProc);

        var gcHandle = GCHandle.Alloc(threadStartRoutine); // Prevent premature GC of the delegate
        try
        {
            ulong* limits = stackalloc ulong[2] { 0, 0 };
            using var hThread =
                Kernel32.CreateThread(
                    null,
                    new UIntPtr(ThreadStackSize),
                    threadStartRoutine,
                    limits,
                    CreateThreadFlags.STACK_SIZE_PARAM_IS_A_RESERVATION,
                    null);
            Kernel32.WaitForSingleObject(hThread, -1);

            Assert.Equal(ThreadStackSize, limits[1] - limits[0]);
        }
        finally
        {
            gcHandle.Free();
        }
    }

    [Fact]
    public unsafe void GetProcessHandleCountTest()
    {
        using var hProcess = Kernel32.GetCurrentProcess();

        uint handleCount = 0;
        Assert.True(Kernel32.GetProcessHandleCount(hProcess, &handleCount));
        Assert.NotEqual(0u, handleCount);
    }

    [Fact]
    public unsafe void GetProcessIdOfThreadTest()
    {
        // Calls into GetProcessIdOfThread and returns the process-id
        // Assumes that data contains enough allocated memory to
        // return the process-id (i.e., a uint value)
        unsafe uint GetProcessIdThreadProc(void* data)
        {
            using var hThread = Kernel32.GetCurrentThread();
            var processId = Kernel32.GetProcessIdOfThread(hThread);

            *(uint*)data = processId;

            return 1;
        }

        var threadStartRoutine = new Kernel32.THREAD_START_ROUTINE(GetProcessIdThreadProc);

        uint processId = 0;
        using var hThread = Kernel32.CreateThread(
            null,
            UIntPtr.Zero,
            threadStartRoutine,
            &processId,
            CreateThreadFlags.None,
            null);
        Kernel32.WaitForSingleObject(hThread, -1);

        Assert.Equal((uint)Process.GetCurrentProcess().Id, processId);

        GC.KeepAlive(threadStartRoutine); // Make sure that the delegate stays alive until the test
    }

    /// <summary>
    /// Helper for <see cref="CreateThread_Test"/>, <see cref="CreateRemoteThread_PseudoTest"/>  and
    /// <see cref="CreateRemoteThreadEx_PseudoTest"/> tests.
    ///
    /// Updates the boolean data pasesed in to true.
    /// </summary>
    /// <param name="data">
    /// Data passed by the test. Contains a pointer to a boolean value.
    /// </param>
    /// <returns>
    /// Returns 1.
    /// </returns>
    /// <remarks>See <see cref=" Kernel32.THREAD_START_ROUTINE"/> for general documentation</remarks>
    private static unsafe uint CreateThread_Test_ThreadMain(void* data)
    {
        *(bool*)data = true;
        return 1;
    }

    private ArraySegment<byte> GetRandomSegment(int size)
    {
        var result = new ArraySegment<byte>(new byte[size]);
        this.random.NextBytes(result.Array);
        return result;
    }
}
