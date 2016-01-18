// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

using System;
using PInvoke;
using Xunit;

public class NullableUInt32Facts
{
    [Fact]
    public void ConstructorSetValue()
    {
        Assert.Equal(new NullableUInt32(42).Value, (uint)42);
        Assert.Equal(new NullableUInt32().Value, default(uint));
    }

    [Fact]
    public void CanCastToNullableUInt32()
    {
        Assert.Equal(((NullableUInt32)42).Value, (uint)42);
        Assert.Equal((NullableUInt32)((uint?)null), null);
        Assert.Equal(((NullableUInt32)((uint?)42)).Value, (uint)42);
    }

    [Fact]
    public void CanCastFromNullableUInt32()
    {
        Assert.Equal((uint)((NullableUInt32)42), (uint)42);
        Assert.Equal((uint?)((NullableUInt32)42), (uint?)42);
        Assert.Equal((uint?)((NullableUInt32)null), null);
    }

    [Fact]
    public void CastFromNullableUInt32ToInt32ThrowOnNull()
    {
        Assert.Throws<ArgumentNullException>(() =>
            (uint)((NullableUInt32)null));
    }
}