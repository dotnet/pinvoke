// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using PInvoke;
using Xunit;
using static PInvoke.Kernel32;

public partial class Kernel32Facts
{
    [Fact]
    public void GetTickCount_Nonzero()
    {
        uint result = GetTickCount();
        Assert.NotEqual(0u, result);
    }

    [Fact]
    public void GetTickCount64_Nonzero()
    {
        ulong result = GetTickCount64();
        Assert.NotEqual(0ul, result);
    }

    [Fact]
    public void SetLastError_ImpactsMarshalGetLastWin32Error()
    {
        SetLastError(2);
        Assert.Equal(2, Marshal.GetLastWin32Error());
    }

    [Fact]
    public void SetErrorMode_Works()
    {
        ErrorModes oldMode = SetErrorMode(ErrorModes.SEM_DEFAULT);
    }

    [Fact]
    public unsafe void GetStartupInfo_Title()
    {
        var startupInfo = STARTUPINFO.Create();
        GetStartupInfo(ref startupInfo);
        Assert.NotNull(startupInfo.Title);
        Assert.NotEqual(0, startupInfo.Title.Length);
    }

    [Fact]
    public void GetVolumeInformationTest()
    {
        char[] volumeNameBuffer = new char[261];
        char[] fileSystemNameBuffer = new char[261];

        string systemDrive = Path.GetPathRoot(Environment.SystemDirectory);

        if (!Kernel32.GetVolumeInformation(systemDrive, volumeNameBuffer, volumeNameBuffer.Length, out uint serialNumber, out int maxlen, out FileSystemFlags flags, fileSystemNameBuffer, fileSystemNameBuffer.Length))
        {
            Marshal.ThrowExceptionForHR(Marshal.GetHRForLastWin32Error());
        }

        Assert.NotEmpty(new string(volumeNameBuffer));
        Assert.NotEqual(0u, serialNumber);
        Assert.NotEqual(0, maxlen);
        Assert.NotEqual((FileSystemFlags)0, flags);
        Assert.NotEmpty(new string(fileSystemNameBuffer));
    }

    [Fact]
    public unsafe void GetNativeSystemInfo_Works()
    {
        GetNativeSystemInfo(out SYSTEM_INFO systemInfo);

        Assert.True(Enum.IsDefined(typeof(Kernel32.ProcessorArchitecture), systemInfo.wProcessorArchitecture));
        Assert.NotEqual(0, systemInfo.dwPageSize);
        Assert.NotEqual(IntPtr.Zero, systemInfo.dwActiveProcessorMask);
        Assert.Equal(Environment.ProcessorCount, systemInfo.dwNumberOfProcessors);
        Assert.True(Enum.IsDefined(typeof(Kernel32.ProcessorType), systemInfo.dwProcessorType));
        Assert.NotEqual(0, systemInfo.dwAllocationGranularity);
    }

    [Fact]
    public unsafe void GetSetProcessInformationMemoryPriorityTest()
    {
        using SafeObjectHandle hProcess = Kernel32.GetCurrentProcess();

        // Save current memory-priority info
        MEMORY_PRIORITY_INFORMATION savedInfo;
        Assert.True(Kernel32.GetProcessInformation(
            hProcess,
            PROCESS_INFORMATION_CLASS.ProcessMemoryPriority,
            &savedInfo,
            (uint)sizeof(MEMORY_PRIORITY_INFORMATION)));

        // Set low memory priority on the process
        var memoryPriority = new MEMORY_PRIORITY_INFORMATION
        {
            MemoryPriority = MemoryPriority.MEMORY_PRIORITY_LOW,
        };

        Assert.True(Kernel32.SetProcessInformation(
            hProcess,
            PROCESS_INFORMATION_CLASS.ProcessMemoryPriority,
            &memoryPriority,
            (uint)sizeof(MEMORY_PRIORITY_INFORMATION)));

        // Now read it back and verify that we get back MEMORY_PRIORITY_LOW
        memoryPriority.MemoryPriority = MemoryPriority.MEMORY_PRIORITY_NORMAL;
        Assert.True(Kernel32.GetProcessInformation(
            hProcess,
            PROCESS_INFORMATION_CLASS.ProcessMemoryPriority,
            &memoryPriority,
            (uint)sizeof(MEMORY_PRIORITY_INFORMATION)));

        Assert.Equal(
            MemoryPriority.MEMORY_PRIORITY_LOW,
            memoryPriority.MemoryPriority);

        // Restore the saved memory-priority info
        if (savedInfo.MemoryPriority != MemoryPriority.MEMORY_PRIORITY_LOW)
        {
            Assert.True(Kernel32.SetProcessInformation(
                hProcess,
                PROCESS_INFORMATION_CLASS.ProcessMemoryPriority,
                &savedInfo,
                (uint)sizeof(MEMORY_PRIORITY_INFORMATION)));

            // Verify that the memory-priority was restore successfully
            memoryPriority.MemoryPriority = MemoryPriority.MEMORY_PRIORITY_LOW;
            Assert.True(Kernel32.GetProcessInformation(
                hProcess,
                PROCESS_INFORMATION_CLASS.ProcessMemoryPriority,
                &memoryPriority,
                (uint)sizeof(MEMORY_PRIORITY_INFORMATION)));
            Assert.Equal(savedInfo.MemoryPriority, memoryPriority.MemoryPriority);
        }
    }
}
