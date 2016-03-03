// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

using System;
using PInvoke;
using Xunit;
using static PInvoke.DwmApi;

public class DwmApiFacts
{
    [Fact]
    public void DefWindowProc()
    {
        IntPtr lResult;
        bool result = DwmDefWindowProc(IntPtr.Zero, 0, IntPtr.Zero, IntPtr.Zero, out lResult);
        Assert.False(result);
    }

    [Fact]
    public void EnableBlurBehindWindow()
    {
        HResult hr = DwmEnableBlurBehindWindow(IntPtr.Zero, default(DWM_BLURBEHIND));
        Assert.True(hr.Failed);
    }

    [Fact]
    public void Flush()
    {
        HResult hr = DwmFlush();

        // Accept success, or "Desktop composition is disabled".
        if (hr != 0x80263001)
        {
            hr.ThrowOnFailure();
        }
    }

    [Fact]
    public void GetColorizationColor()
    {
        uint colorization;
        bool opaqueBlend;
        DwmGetColorizationColor(out colorization, out opaqueBlend).ThrowOnFailure();
    }
}
