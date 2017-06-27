// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

using System;
using System.Runtime.InteropServices;
using PInvoke;
using Xunit;
using static PInvoke.Magnification;

public class MagnificationFacts
{
    [Fact]
    public void InitializeThenDeinitialize()
    {
        Assert.True(MagInitialize());
        Assert.True(MagUninitialize());
    }

    [Fact]
    public void MAGCOLOREFFECT_IsRightSize()
    {
        Assert.Equal(sizeof(float) * 5 * 5, Marshal.SizeOf<MAGCOLOREFFECT>());
    }

    [Fact]
    public void MAGTRANSFORM_IsRightSize()
    {
        Assert.Equal(sizeof(float) * 3 * 3, Marshal.SizeOf<MAGTRANSFORM>());
    }
}
