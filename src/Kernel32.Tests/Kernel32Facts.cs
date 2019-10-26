// Copyright (c) All contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.IO;
using System.Runtime.InteropServices;
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
    public unsafe void GetStartupInfo_Title()
    {
        var startupInfo = STARTUPINFO.Create();
        GetStartupInfo(ref startupInfo);
        Assert.NotNull(startupInfo.Title);
        Assert.NotEqual(0, startupInfo.Title.Length);
    }

    [Fact]
    public void GetHandleInformation_DoesNotThrow()
    {
        var manualResetEvent = new ManualResetEvent(false);
        GetHandleInformation(manualResetEvent.SafeWaitHandle, out var lpdwFlags);
    }

    [Fact]
    public void SetHandleInformation_DoesNotThrow()
    {
        var manualResetEvent = new ManualResetEvent(false);
        SetHandleInformation(
            manualResetEvent.SafeWaitHandle,
            HandleFlags.HANDLE_FLAG_INHERIT | HandleFlags.HANDLE_FLAG_PROTECT_FROM_CLOSE,
            HandleFlags.HANDLE_FLAG_NONE);
    }
}
