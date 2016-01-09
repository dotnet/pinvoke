// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

using System;
using System.Runtime.InteropServices;
using PInvoke;
using Xunit;

public class NTStatusTests
{
    [Fact]
    public void Ctor_Int32()
    {
        Assert.Equal(3, ((NTStatus)3).AsInt32);
    }

    [Fact]
    public void Ctor_UInt32()
    {
        Assert.Equal(3, new NTStatus((uint)3).AsInt32);
    }

    [Fact]
    public void DefaultIs0()
    {
        Assert.Equal(0, default(NTStatus).AsInt32);
    }

    [Fact]
    public void PopularValuesPredefined()
    {
        Assert.Equal(0u, NTStatus.STATUS_SUCCESS);
    }

    [Fact]
    public void AsUInt32()
    {
        uint expectedValue = 5;
        NTStatus status = expectedValue;
        uint actualValue = status.AsUInt32;
        Assert.Equal(expectedValue, actualValue);
    }

    [Fact]
    public void ImplicitCast_Int32()
    {
        int originalValue = 0x5;
        NTStatus status = originalValue;
        Assert.Equal(originalValue, status.AsInt32);
    }

    [Fact]
    public void ImplicitCast_UInt32()
    {
        uint originalValue = 0x5;
        NTStatus status = originalValue;
        uint backToUInt = status;
        Assert.Equal(originalValue, backToUInt);
    }

    [Fact]
    public void ExplicitCast_Int32()
    {
        int originalValue = 0x5;
        NTStatus status = (NTStatus)originalValue;
        Assert.Equal(originalValue, (int)status);
    }

    [Fact]
    public void ExplicitCast_UInt32()
    {
        uint originalValue = 0x5;
        NTStatus status = (NTStatus)originalValue;
        Assert.Equal(originalValue, (uint)status);
    }

    [Fact]
    public void ToString_FormatsNumberAsHex()
    {
        NTStatus status = 0x80000000;
        Assert.Equal("0x80000000", status.ToString());
    }

    [Fact]
    public void ToString_IsFormattable()
    {
        NTStatus status = 0x10;
        Assert.Equal("0010", $"{status:x4}");
        Assert.Equal("00000010", $"{status:x8}");
    }

    [Fact]
    public void GetHashCodeReturnsValue()
    {
        Assert.Equal(3, ((NTStatus)3).GetHashCode());
        Assert.Equal(4, ((NTStatus)4).GetHashCode());
    }

    [Fact]
    public void EqualityChecks()
    {
        NTStatus hr3 = 3;
        NTStatus hr5 = 5;
        IEquatable<NTStatus> hr3Equatable = hr3;

        Assert.Equal(hr3, hr3);
        Assert.True(hr3.Equals(hr3));
        Assert.True(hr3Equatable.Equals(hr3));

        Assert.NotEqual(hr3, hr5);
        Assert.False(hr3.Equals(hr5));
        Assert.False(hr3Equatable.Equals(hr5));
    }

    [Fact]
    public void EqualOperators()
    {
        NTStatus hr3 = 3;
        NTStatus hr3b = 3;
        NTStatus hr5 = 5;

        Assert.True(hr3 != hr5);
        Assert.True(hr3 == hr3b);
        Assert.False(hr3 == hr5);
        Assert.False(hr3 != hr3b);
    }

    [Fact]
    public void DebuggerDisplay()
    {
        NTStatus status = 0x10;
        var privateProperty = typeof(NTStatus).GetProperty("DebuggerDisplay", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
        object value = privateProperty.GetMethod.Invoke(status, null);
        Assert.Equal("0x00000010", value);
    }

    [Fact]
    public void Severity()
    {
        Assert.Equal((NTStatus.SeverityCodes)0x3, new NTStatus(0xc0000000).Severity);
        Assert.Equal((NTStatus.SeverityCodes)0x0, new NTStatus(0x3fffffff).Severity);
    }

    [Fact]
    public void CustomerCode()
    {
        Assert.Equal(1u, new NTStatus(0x20000000).CustomerCode);
        Assert.Equal(0u, new NTStatus(0xdfffffff).CustomerCode);
    }

    [Fact]
    public void Facility()
    {
        // The hex values used here are deliberately selected.
        // 9 is encoded in binary as 1001, which places 1's at the edges and 0's everywhere else.
        // So if the bit mask or bit shift is wrong, it will have to be detected.
        Assert.Equal((NTStatus.FacilityCodes)0x999, new NTStatus(0xf999ffff).Facility);
    }

    [Fact]
    public void Code()
    {
        Assert.Equal<uint>(0x9999, new NTStatus(0xffff9999).FacilityCode);
    }
}
