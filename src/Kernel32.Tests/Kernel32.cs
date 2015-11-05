// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using PInvoke;
using Xunit;
using static PInvoke.Kernel32;

public partial class Kernel32
{
    private Random random = new Random();

    [Fact]
    public void CreateFile_DeleteOnClose()
    {
        string testPath = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
        using (var tempFileHandle = CreateFile(
            testPath,
            PInvoke.Kernel32.FileAccess.GenericWrite,
            PInvoke.Kernel32.FileShare.Read,
            IntPtr.Zero,
            CreationDisposition.CreateAlways,
            CreateFileFlags.DeleteOnCloseFlag,
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
                Assert.Equal(FileAttribute.Archive, data.dwFileAttributes);

                Assert.True(FindNextFile(handle, out data));
                Assert.Equal("b.txt", data.cFileName);
                Assert.Equal(FileAttribute.Normal, data.dwFileAttributes);

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
        var frameworkValue = AppDomain.GetCurrentThreadId();
#pragma warning restore CS0618 // Type or member is obsolete
        var pinvokeValue = GetCurrentThreadId();

        Assert.Equal((uint)frameworkValue, pinvokeValue);
    }

    [Fact]
    public void GetCurrentProcessId_SameAsProcessOne()
    {
        var frameworkValue = Process.GetCurrentProcess().Id;
        var pinvokeValue = GetCurrentProcessId();

        Assert.Equal((uint)frameworkValue, pinvokeValue);
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
            Assert.Equal(true, system.IsInvalid);
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
            Assert.Equal(false, currentProcess.IsInvalid);
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
                PInvoke.Kernel32.FileAccess.GenericRead,
                PInvoke.Kernel32.FileShare.None,
                IntPtr.Zero,
                CreationDisposition.OpenExisting,
                CreateFileFlags.NormalAttribute,
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
                PInvoke.Kernel32.FileAccess.GenericWrite,
                PInvoke.Kernel32.FileShare.None,
                IntPtr.Zero,
                CreationDisposition.OpenExisting,
                CreateFileFlags.NormalAttribute,
                new SafeObjectHandle()))
            {
                var bytesWritten = WriteFile(file, new ArraySegment<byte>(expected));
                Assert.Equal((uint)testDataSize, bytesWritten);
            }

            var actual = File.ReadAllBytes(testPath);

            Assert.Equal(expected, actual);
        }
        finally
        {
            File.Delete(testPath);
        }
    }
}
