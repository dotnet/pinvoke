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
using System.Threading.Tasks;
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
            out PROCESS_INFORMATION processInformation);
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
                    out PROCESS_INFORMATION processInformation);
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
        using (SafeObjectHandle tempFileHandle = CreateFile(
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
        using (SafeFindFilesHandle handle = FindFirstFile("foodoesnotexist", out WIN32_FIND_DATA data))
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

            string bTxt = Path.Combine(testPath, "b.txt");
            File.WriteAllText(bTxt, string.Empty);
            File.SetAttributes(bTxt, FileAttributes.Normal);

            using (SafeFindFilesHandle handle = FindFirstFile(Path.Combine(testPath, "*.txt"), out WIN32_FIND_DATA data))
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
        using (SafeLibraryHandle ntdll = LoadLibrary("ntdll.dll"))
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
        int currentProcess = GetCurrentProcessId();
        SafeObjectHandle snapshot = CreateToolhelp32Snapshot(CreateToolhelp32SnapshotFlags.TH32CS_SNAPPROCESS, 0);
        using (snapshot)
        {
            var processes = Process32Enumerate(snapshot).ToList();
            PROCESSENTRY32 win32Process = processes.Single(p => p.th32ProcessID == currentProcess);
            var netProcess = Process.GetCurrentProcess();
            Assert.Equal(netProcess.MainModule.ModuleName, win32Process.ExeFile, true);
        }
    }

    [Fact]
    public void OpenProcess_CannotOpenSystem()
    {
        using (SafeObjectHandle system = OpenProcess(ProcessAccess.PROCESS_TERMINATE, false, 0x00000000))
        {
            var error = (Win32ErrorCode)Marshal.GetLastWin32Error();
            Assert.True(system.IsInvalid);
            Assert.Equal(Win32ErrorCode.ERROR_INVALID_PARAMETER, error);
        }
    }

    [Fact]
    public void OpenProcess_CanOpenSelf()
    {
        int currentProcessId = GetCurrentProcessId();
        SafeObjectHandle currentProcess = OpenProcess(ProcessAccess.PROCESS_QUERY_LIMITED_INFORMATION, false, currentProcessId);
        using (currentProcess)
        {
            Assert.False(currentProcess.IsInvalid);
        }
    }

    [Fact]
    public void GetProcessTimes_CanGetCurrentProcessTimes()
    {
        int currentProcessId = GetCurrentProcessId();
        SafeObjectHandle currentProcess = OpenProcess(ProcessAccess.PROCESS_QUERY_LIMITED_INFORMATION, false, currentProcessId);
        using (currentProcess)
        {
            TimeSpan totalProcessTime = Process.GetCurrentProcess().TotalProcessorTime;

/* Unmerged change from project 'Kernel32.Tests (netcoreapp3.1)'
Before:
            Assert.True(GetProcessTimes(currentProcess, out create, out exit, out kernel, out user));
After:
            Assert.True(GetProcessTimes(currentProcess, out FILETIME create, out FILETIME exit, out FILETIME kernel, out FILETIME user));
*/
            Assert.True(GetProcessTimes(currentProcess, out Kernel32.FILETIME create, out Kernel32.FILETIME exit, out Kernel32.FILETIME kernel, out Kernel32.FILETIME user));
            double expected = Math.Truncate(totalProcessTime.TotalSeconds / 10);
            double actual = Math.Truncate(new TimeSpan(kernel + user).TotalSeconds / 10);
            Assert.Equal(expected, actual);
        }
    }

    [Fact]
    public void QueryFullProcessImageName_CanGetForCurrentProcess()
    {
        int currentProcessId = GetCurrentProcessId();
        SafeObjectHandle currentProcess = OpenProcess(ProcessAccess.PROCESS_QUERY_LIMITED_INFORMATION, false, currentProcessId);
        using (currentProcess)
        {
            string actual = QueryFullProcessImageName(currentProcess);
            string expected = Process.GetCurrentProcess().MainModule.FileName;

            Assert.Equal(expected, actual, ignoreCase: true);
        }
    }

    [Fact]
    public void ReadFile_CanReadSynchronously()
    {
        string testPath = Path.GetTempFileName();
        try
        {
            const int testDataSize = 256;
            byte[] expected = new byte[testDataSize];
            this.random.NextBytes(expected);

            File.WriteAllBytes(testPath, expected);

            using (SafeObjectHandle file = CreateFile(
                testPath,
                ACCESS_MASK.GenericRight.GENERIC_READ,
                Kernel32.FileShare.None,
                IntPtr.Zero,
                CreationDisposition.OPEN_EXISTING,
                CreateFileFlags.FILE_ATTRIBUTE_NORMAL,
                new SafeObjectHandle()))
            {
                ArraySegment<byte> actual = ReadFile(file, testDataSize);
                IEnumerable<byte> actualData = actual.Skip(actual.Offset).Take(actual.Count);
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
        string testPath = Path.GetTempFileName();
        try
        {
            const int testDataSize = 256;
            byte[] expected = new byte[testDataSize];
            this.random.NextBytes(expected);

            File.WriteAllBytes(testPath, expected);

            using (SafeObjectHandle file = CreateFile(
                testPath,
                ACCESS_MASK.GenericRight.GENERIC_READ,
                Kernel32.FileShare.None,
                (SECURITY_ATTRIBUTES?)null,
                CreationDisposition.OPEN_EXISTING,
                CreateFileFlags.FILE_FLAG_OVERLAPPED,
                new SafeObjectHandle()))
            {
                var overlapped = default(OVERLAPPED);
                byte[] actual = new byte[testDataSize];
                fixed (byte* pActual = actual)
                {
                    bool result = ReadFile(file, pActual, testDataSize, null, &overlapped);
                    if (result)
                    {
                        // We can't really test anything not covered by another test here :(
                        return;
                    }

                    Win32ErrorCode lastError = GetLastError();
                    Assert.Equal(Win32ErrorCode.ERROR_IO_PENDING, lastError);
                    bool overlappedResult = GetOverlappedResult(file, &overlapped, out int bytesTransfered, true);
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
        string testPath = Path.GetTempFileName();
        try
        {
            const int testDataSize = 256;
            byte[] expected = new byte[testDataSize];
            this.random.NextBytes(expected);

            File.WriteAllBytes(testPath, expected);

            using (SafeObjectHandle file = CreateFile(
                testPath,
                ACCESS_MASK.GenericRight.GENERIC_READ,
                Kernel32.FileShare.None,
                (SECURITY_ATTRIBUTES?)null,
                CreationDisposition.OPEN_EXISTING,
                CreateFileFlags.FILE_FLAG_OVERLAPPED,
                new SafeObjectHandle()))
            {
                var overlapped = default(OVERLAPPED);
                byte[] actual = new byte[testDataSize];
                var evt = new ManualResetEvent(false);
                overlapped.hEvent = evt.SafeWaitHandle.DangerousGetHandle();
                fixed (byte* pActual = actual)
                {
                    bool result = ReadFile(file, pActual, testDataSize, null, &overlapped);
                    if (result)
                    {
                        // We can't really test anything not covered by another test here :(
                        return;
                    }

                    Win32ErrorCode lastError = GetLastError();
                    Assert.Equal(Win32ErrorCode.ERROR_IO_PENDING, lastError);
                    Assert.True(evt.WaitOne(TimeSpan.FromSeconds(30)));
                    bool overlappedResult = GetOverlappedResult(file, &overlapped, out int bytesTransfered, false);
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
        string testPath = Path.GetTempFileName();
        try
        {
            const int testDataSize = 256;
            byte[] expected = new byte[testDataSize];
            this.random.NextBytes(expected);

            using (SafeObjectHandle file = CreateFile(
                testPath,
                ACCESS_MASK.GenericRight.GENERIC_WRITE,
                Kernel32.FileShare.None,
                IntPtr.Zero,
                CreationDisposition.OPEN_EXISTING,
                CreateFileFlags.FILE_ATTRIBUTE_NORMAL,
                new SafeObjectHandle()))
            {
                int bytesWritten = WriteFile(file, new ArraySegment<byte>(expected));
                Assert.Equal(testDataSize, bytesWritten);
            }

            byte[] actual = File.ReadAllBytes(testPath);

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
        string testPath = Path.GetTempFileName();
        try
        {
            const int testDataSize = 256;
            byte[] expected = new byte[testDataSize];
            this.random.NextBytes(expected);

            using (SafeObjectHandle file = CreateFile(
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
                    bool result = WriteFile(file, pExpected, testDataSize, null, &overlapped);
                    if (result)
                    {
                        // We can't really test anything not covered by another test here :(
                        return;
                    }

                    Win32ErrorCode lastError = GetLastError();
                    Assert.Equal(Win32ErrorCode.ERROR_IO_PENDING, lastError);
                    bool overlappedResult = GetOverlappedResult(file, &overlapped, out int bytesTransfered, true);
                    Assert.Equal(testDataSize, bytesTransfered);
                    Assert.True(overlappedResult);
                }
            }

            byte[] actual = File.ReadAllBytes(testPath);

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
        string testPath = Path.GetTempFileName();
        try
        {
            const int testDataSize = 256;
            byte[] expected = new byte[testDataSize];
            this.random.NextBytes(expected);

            using (SafeObjectHandle file = CreateFile(
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
                    bool result = WriteFile(file, pExpected, testDataSize, null, &overlapped);
                    if (result)
                    {
                        // We can't really test anything not covered by another test here :(
                        return;
                    }

                    Win32ErrorCode lastError = GetLastError();
                    Assert.Equal(Win32ErrorCode.ERROR_IO_PENDING, lastError);
                    Assert.True(evt.WaitOne(TimeSpan.FromSeconds(30)));
                    bool overlappedResult = GetOverlappedResult(file, &overlapped, out int bytesTransfered, false);
                    Assert.Equal(testDataSize, bytesTransfered);
                    Assert.True(overlappedResult);
                }
            }

            byte[] actual = File.ReadAllBytes(testPath);

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
        string testPath = Path.GetTempFileName();
        try
        {
            const int testDataSize = 256;
            byte[] buffer = new byte[testDataSize];

            using (SafeObjectHandle file = CreateFile(
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
                    bool result = WriteFile(file, pExpected, testDataSize, null, &overlapped);
                    if (result)
                    {
                        // We can't really test anything not covered by another test here :(
                        return;
                    }

                    Win32ErrorCode lastError = GetLastError();
                    Assert.Equal(Win32ErrorCode.ERROR_IO_PENDING, lastError);
                    try
                    {
                        Assert.True(CancelIo(file));
                    }
                    finally
                    {
                        GetOverlappedResult(file, &overlapped, out int bytesTransfered, true);
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
        string testPath = Path.GetTempFileName();
        try
        {
            const int testDataSize = 256;
            byte[] buffer = new byte[testDataSize];

            using (SafeObjectHandle file = CreateFile(
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
                    bool result = WriteFile(file, pExpected, testDataSize, null, &overlapped);
                    if (result)
                    {
                        // We can't really test anything not covered by another test here :(
                        return;
                    }

                    Win32ErrorCode lastError = GetLastError();
                    Assert.Equal(Win32ErrorCode.ERROR_IO_PENDING, lastError);
                    try
                    {
                        bool cancelled = CancelIoEx(file, (NativeOverlapped*)null);

                        // We can't assert that it's true as if the IO finished already it'll fail with ERROR_NOT_FOUND
                        if (!cancelled)
                        {
                            Assert.Equal(Win32ErrorCode.ERROR_NOT_FOUND, GetLastError());
                        }
                    }
                    finally
                    {
                        GetOverlappedResult(file, &overlapped, out int bytesTransfered, true);
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
        string testPath = Path.GetTempFileName();
        try
        {
            const int testDataSize = 256;
            byte[] buffer = new byte[testDataSize];

            using (SafeObjectHandle file = CreateFile(
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
                    bool result = WriteFile(file, pExpected, testDataSize, null, &overlapped);
                    if (result)
                    {
                        // We can't really test anything not covered by another test here :(
                        return;
                    }

                    Win32ErrorCode lastError = GetLastError();
                    Assert.Equal(Win32ErrorCode.ERROR_IO_PENDING, lastError);
                    try
                    {
                        bool cancelled = CancelIoEx(file, &overlapped);

                        // We can't assert that it's true as if the IO finished already it'll fail with ERROR_NOT_FOUND
                        if (!cancelled)
                        {
                            Assert.Equal(Win32ErrorCode.ERROR_NOT_FOUND, GetLastError());
                        }
                    }
                    finally
                    {
                        GetOverlappedResult(file, &overlapped, out int bytesTransfered, true);
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
        bool expected = Environment.Is64BitOperatingSystem && !Environment.Is64BitProcess;
        bool actual = IsWow64Process(GetCurrentProcess());
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void CreatePipe_ReadWrite()
    {
        Assert.True(CreatePipe(out SafeObjectHandle readPipe, out SafeObjectHandle writePipe, IntPtr.Zero, 0));
        using (readPipe)
        using (writePipe)
        {
            byte[] data = new byte[] { 1, 2, 3 };
            Assert.Equal(data.Length, WriteFile(writePipe, new ArraySegment<byte>(data)));
            Assert.Equal(data, ReadFile(readPipe, data.Length));
        }
    }

    [IgnoreOnOsVersionUnderFact("6.1")]
    public void K32EmptyWorkingSet_Run()
    {
        using (SafeObjectHandle pid = GetCurrentProcess())
        {
            Assert.True(K32EmptyWorkingSet(pid));
        }
    }

    [Fact]
    public void LoadLibrary_And_FreeLibrary()
    {
        using (SafeLibraryHandle library = LoadLibrary("kernel32.dll"))
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
        string pipeName = @"\\.\pipe\pinvoke_tests_" + Guid.NewGuid();

        SafeObjectHandle server = CreateNamedPipe(
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

                SafeObjectHandle client = CreateFile(
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

                    ArraySegment<byte> writeBuffer = this.GetRandomSegment(42);
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
        using (SafeLibraryHandle imageRes = LoadLibrary("shell32.dll"))
        {
            Assert.False(imageRes.IsInvalid);

            // Locate where the resource is (Can be in some language dll)
            IntPtr resInfo = FindResource(imageRes, MAKEINTRESOURCE(1), RT_GROUP_ICON);
            Assert.NotEqual(IntPtr.Zero, resInfo);

            // Get a handle to the resource
            IntPtr resHGlobal = LoadResource(imageRes, resInfo);
            Assert.NotEqual(IntPtr.Zero, resHGlobal);

            // Get a pointer to the data
            void* ptr = LockResource(resHGlobal);
            Assert.True(ptr != null);
        }
    }

    [Fact]
    public unsafe void Get_Size_Of_Bmp_Icon_Resource()
    {
        using (SafeLibraryHandle imageRes = LoadLibrary("shell32.dll"))
        {
            Assert.False(imageRes.IsInvalid);

            // Load the icon for unknown files
            IntPtr resInfo = FindResource(imageRes, MAKEINTRESOURCE(1), RT_GROUP_ICON);
            Assert.NotEqual(IntPtr.Zero, resInfo);

            // Should be able to get it's size
            int size = SizeofResource(imageRes, resInfo);
            Assert.NotEqual(0, size);
        }
    }

    [Fact]
    public unsafe void Enumerate_Imageres_Resources()
    {
        // Let's load the icon for unknown files
        using (SafeLibraryHandle imageRes = LoadLibrary("shell32.dll"))
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
        using (SafeLibraryHandle imageRes = LoadLibrary("shell32.dll"))
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
        Assert.True(GetHandleInformation(manualResetEvent.SafeWaitHandle, out HandleFlags lpdwFlags));
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
        bool result = false;
        uint dwNewThreadId = 0u;

        using SafeObjectHandle hThread =
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
        bool result = false;
        uint dwNewThreadId = 0u;

        using SafeObjectHandle hProcess = Kernel32.GetCurrentProcess();
        using SafeObjectHandle hThread =
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
        bool result = false;
        uint dwNewThreadId = 0u;

        using SafeObjectHandle hProcess = Kernel32.GetCurrentProcess();
        using SafeObjectHandle hThread =
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
            Kernel32.GetCurrentThreadStackLimits(out UIntPtr lowLimit, out UIntPtr highLimit);

            ulong* limits = (ulong*)data;
            limits[0] = (ulong)lowLimit;
            limits[1] = (ulong)highLimit;

            return 1;
        }

        const uint ThreadStackSize = 512 * 1024u;

        var threadStartRoutine = new THREAD_START_ROUTINE(ThreadStackLimitsThreadProc);

        var gcHandle = GCHandle.Alloc(threadStartRoutine); // Prevent premature GC of the delegate
        try
        {
            ulong* limits = stackalloc ulong[2] { 0, 0 };
            using SafeObjectHandle hThread =
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
        using SafeObjectHandle hProcess = Kernel32.GetCurrentProcess();

        Assert.True(Kernel32.GetProcessHandleCount(hProcess, out uint handleCount));
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
            using SafeObjectHandle hThread = Kernel32.GetCurrentThread();
            uint processId = Kernel32.GetProcessIdOfThread(hThread);

            *(uint*)data = processId;

            return 1;
        }

        var threadStartRoutine = new Kernel32.THREAD_START_ROUTINE(GetProcessIdThreadProc);

        uint processId = 0;
        using SafeObjectHandle hThread = Kernel32.CreateThread(
            null,
            UIntPtr.Zero,
            threadStartRoutine,
            &processId,
            CreateThreadFlags.None,
            null);
        Kernel32.WaitForSingleObject(hThread, -1);

        Assert.Equal((uint)Process.GetCurrentProcess().Id, processId);

        GC.KeepAlive(threadStartRoutine); // Make sure that the delegate stays alive until the test is done
    }

    [Fact]
    public unsafe void DeviceIOControl_Works()
    {
        const uint IOCTL_DISK_GET_DRIVE_GEOMETRY = 0x070000;
        const string drive = @"\\.\PhysicalDrive0";

        using (SafeObjectHandle device = CreateFile(
            filename: drive,
            access: 0,
            share: Kernel32.FileShare.FILE_SHARE_READ | Kernel32.FileShare.FILE_SHARE_WRITE,
            securityAttributes: (SECURITY_ATTRIBUTES*)null,
            creationDisposition: CreationDisposition.OPEN_EXISTING,
            flagsAndAttributes: 0,
            SafeObjectHandle.Null))
        {
            Assert.False(device.IsInvalid);

            DISK_GEOMETRY pdg = default;

            Assert.True(DeviceIoControl(
                device,
                (int)IOCTL_DISK_GET_DRIVE_GEOMETRY,
                null,
                0,
                &pdg,
                sizeof(DISK_GEOMETRY),
                out int pBytesReturned,
                (OVERLAPPED*)null));

            Assert.NotEqual(0u, pdg.BytesPerSector);
            Assert.NotEqual(0, pdg.Cylinders);
            Assert.Equal(MEDIA_TYPE.FixedMedia, pdg.MediaType);
            Assert.NotEqual(0u, pdg.SectorsPerTrack);
            Assert.NotEqual(0u, pdg.TracksPerCylinder);
        }
    }

    [Fact]
    public async Task DeviceIOControlAsync_NotOverlapped_Works()
    {
        const uint IOCTL_DISK_GET_DRIVE_GEOMETRY = 0x070000;
        const string drive = @"\\.\PhysicalDrive0";

        var data = new DISK_GEOMETRY[1];

        using (SafeObjectHandle device = CreateFile(
            filename: drive,
            access: 0,
            share: Kernel32.FileShare.FILE_SHARE_READ | Kernel32.FileShare.FILE_SHARE_WRITE,
            securityAttributes: IntPtr.Zero,
            creationDisposition: CreationDisposition.OPEN_EXISTING,
            flagsAndAttributes: 0,
            SafeObjectHandle.Null))
        {
            Assert.False(device.IsInvalid);

            int ret = (int)await DeviceIoControlAsync<byte, DISK_GEOMETRY>(
                device,
                (int)IOCTL_DISK_GET_DRIVE_GEOMETRY,
                Array.Empty<byte>(),
                data,
                CancellationToken.None);

            Assert.Equal(Marshal.SizeOf<DISK_GEOMETRY>(), ret);

            DISK_GEOMETRY pdg = data[0];
            Assert.NotEqual(0u, pdg.BytesPerSector);
            Assert.NotEqual(0, pdg.Cylinders);
            Assert.Equal(MEDIA_TYPE.FixedMedia, pdg.MediaType);
            Assert.NotEqual(0u, pdg.SectorsPerTrack);
            Assert.NotEqual(0u, pdg.TracksPerCylinder);
        }
    }

    [Fact]
    public async Task DeviceIOControlAsync_Overlapped_Works()
    {
        const uint FSCTL_SET_ZERO_DATA = 0x000980c8;
        string fileName = Path.GetTempFileName();

        try
        {
            using (SafeObjectHandle file = CreateFile(
                filename: fileName,
                access: Kernel32.ACCESS_MASK.GenericRight.GENERIC_READ | ACCESS_MASK.GenericRight.GENERIC_WRITE,
                share: Kernel32.FileShare.FILE_SHARE_READ | Kernel32.FileShare.FILE_SHARE_WRITE,
                securityAttributes: IntPtr.Zero,
                creationDisposition: CreationDisposition.CREATE_ALWAYS,
                flagsAndAttributes: CreateFileFlags.FILE_FLAG_OVERLAPPED,
                SafeObjectHandle.Null))
            {
                Assert.False(file.IsInvalid);

                Assert.True(ThreadPool.BindHandle(file));

                var data = new FILE_ZERO_DATA_INFORMATION[]
                {
                new FILE_ZERO_DATA_INFORMATION { BeyondFinalZero = int.MaxValue },
                };

                uint ret = await Kernel32.DeviceIoControlAsync<FILE_ZERO_DATA_INFORMATION, byte>(
                    file,
                    (int)FSCTL_SET_ZERO_DATA,
                    data,
                    null,
                    CancellationToken.None);

                Assert.Equal(0u, ret);
            }
        }
        finally
        {
            File.Delete(fileName);
        }
    }

    [Fact]
    public async Task DeviceIOControlAsync_Exception_Works()
    {
        const uint IOCTL_DISK_GET_DRIVE_GEOMETRY = 0x070000;

        await Assert.ThrowsAsync<Win32Exception>(() =>
            DeviceIoControlAsync<byte, byte>(
            SafeObjectHandle.Invalid,
            (int)IOCTL_DISK_GET_DRIVE_GEOMETRY,
            Array.Empty<byte>(),
            Array.Empty<byte>(),
            CancellationToken.None).AsTask()).ConfigureAwait(false);
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
    /// <remarks>See <see cref=" Kernel32.THREAD_START_ROUTINE"/> for general documentation.</remarks>
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
