// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

using System;
using PInvoke;
using Xunit;

public class NullableGuidTests
{
    private readonly Guid testGuid = Guid.NewGuid();

    [Fact]
    public void ConstructorSetValue()
    {
        Assert.Equal(new NullableGuid(this.testGuid).Value, (Guid)this.testGuid);
        Assert.Equal(new NullableGuid().Value, default(Guid));
    }

    [Fact]
    public void CanCastToNullableGuid()
    {
        Assert.Equal(((NullableGuid)this.testGuid).Value, (Guid)this.testGuid);
        Assert.Equal((NullableGuid)((Guid?)null), null);
        Assert.Equal(((NullableGuid)((Guid?)this.testGuid)).Value, (Guid)this.testGuid);
    }

    [Fact]
    public void CanCastFromNullableGuid()
    {
        Assert.Equal((Guid)((NullableGuid)this.testGuid), (Guid)this.testGuid);
        Assert.Equal((Guid?)((NullableGuid)this.testGuid), (Guid?)this.testGuid);
        Assert.Equal((Guid?)((NullableGuid)null), null);
    }

    [Fact]
    public void CastFromNullableGuidToInt32ThrowOnNull()
    {
        Assert.Throws<ArgumentNullException>(() =>
            (Guid)((NullableGuid)null));
    }
}