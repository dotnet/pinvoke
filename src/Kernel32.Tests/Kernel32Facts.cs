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
        StringBuilder volumeNameBuffer = new StringBuilder(261);
        StringBuilder fileSystemNameBuffer = new StringBuilder(261);
        uint serialNumber, maxlen;
        FileSystemFeature flags;

        var systemDrive = Path.GetPathRoot(Environment.SystemDirectory);

        if (!Kernel32.GetVolumeInformation(systemDrive, volumeNameBuffer, volumeNameBuffer.Capacity, out serialNumber, out maxlen, out flags, fileSystemNameBuffer, fileSystemNameBuffer.Capacity))
        {
            Marshal.ThrowExceptionForHR(Marshal.GetHRForLastWin32Error());
        }

        Assert.NotEmpty(volumeNameBuffer.ToString());
        Assert.NotEqual(0u, serialNumber);
        Assert.NotEqual(0u, maxlen);
        Assert.NotEqual((FileSystemFeature)0, flags);
        Assert.NotEmpty(fileSystemNameBuffer.ToString());
    }
}
