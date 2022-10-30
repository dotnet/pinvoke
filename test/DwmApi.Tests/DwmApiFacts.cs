// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using PInvoke;
using Xunit;
using static PInvoke.DwmApi;

public class DwmApiFacts
{
    [Fact]
    public void DefWindowProc()
    {
        bool result = DwmDefWindowProc(IntPtr.Zero, 0, IntPtr.Zero, IntPtr.Zero, out IntPtr lResult);
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
        DwmGetColorizationColor(out uint colorization, out bool opaqueBlend).ThrowOnFailure();
    }
}
