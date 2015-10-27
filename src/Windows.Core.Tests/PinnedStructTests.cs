// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

using System;
using PInvoke;
using Xunit;

public class PinnedStructTests
{
    [Fact]
    public void NullStruct()
    {
        int? number = null;
        var pinnedNumber = number.Pin();
        Assert.False(pinnedNumber.HasValue);
        Assert.Throws<InvalidOperationException>(() => pinnedNumber.Value);
        Assert.Equal(IntPtr.Zero, pinnedNumber.ValuePointer);
        pinnedNumber.Dispose();
        Assert.Throws<ObjectDisposedException>(() => pinnedNumber.HasValue);
        Assert.Throws<ObjectDisposedException>(() => pinnedNumber.Value);
    }

    [Fact]
    public void HasValue()
    {
        int? number = 5;
        var pinnedNumber = number.Pin();
        Assert.True(pinnedNumber.HasValue);
        Assert.Equal(5, pinnedNumber.Value);
        Assert.NotEqual(IntPtr.Zero, pinnedNumber.ValuePointer);
        pinnedNumber.Dispose();
        Assert.Throws<ObjectDisposedException>(() => pinnedNumber.HasValue);
        Assert.Throws<ObjectDisposedException>(() => pinnedNumber.Value);
    }

    [Fact]
    public void DisposeTwice()
    {
        var pinnedValue = 5.Pin();
        pinnedValue.Dispose();
        pinnedValue.Dispose();
    }
}
