// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

using System;
using System.Runtime.InteropServices;
using PInvoke;
using Xunit;

public class HResultFacts
{
    [Fact]
    public void MarshaledSize()
    {
        // It's imperative that the struct be exactly the size of an Int32
        // since we use it in interop.
        Assert.Equal(sizeof(int), Marshal.SizeOf(typeof(HResult)));
    }

    [Fact]
    public void Ctor_Int32()
    {
        Assert.Equal(3, new HResult(3).AsInt32);
    }

    [Fact]
    public void Ctor_UInt32()
    {
        Assert.Equal(3, new HResult((uint)3).AsInt32);
    }

    [Fact]
    public void DefaultIs0()
    {
        Assert.Equal(0, default(HResult).AsInt32);
    }

    [Fact]
    public void PopularValuesPredefined()
    {
        Assert.Equal(0u, (uint)HResult.Code.S_OK);
        Assert.Equal(0x80004005u, (uint)HResult.Code.E_FAIL);
        Assert.Equal(1u, (uint)HResult.Code.S_FALSE);
    }

    [Fact]
    public void AsUInt32()
    {
        uint expectedValue = 5;
        HResult hr = expectedValue;
        uint actualValue = hr.AsUInt32;
        Assert.Equal(expectedValue, actualValue);
    }

    [Fact]
    public void ImplicitCast_Int32()
    {
        int originalValue = 0x5;
        HResult hr = originalValue;
        int backToInt = hr;
        Assert.Equal(originalValue, backToInt);
    }

    [Fact]
    public void ImplicitCast_UInt32()
    {
        uint originalValue = 0x5;
        HResult hr = originalValue;
        Assert.Equal(originalValue, hr.AsUInt32);
    }

    [Fact]
    public void ExplicitCast_Int32()
    {
        int originalValue = 0x5;
        HResult hr = (HResult)originalValue;
        Assert.Equal(originalValue, (int)hr);
    }

    [Fact]
    public void ExplicitCast_UInt32()
    {
        uint originalValue = 0x5;
        HResult hr = (HResult)originalValue;
        Assert.Equal(originalValue, (uint)hr);
    }

    [Fact]
    public void ToString_FormatsNumberAsDecimalOrName()
    {
        HResult hr = 0x80000000;
        Assert.Equal("2147483648", hr.ToString());
        hr = HResult.Code.E_INVALIDARG;
        Assert.Equal("E_INVALIDARG", hr.ToString());
    }

    [Fact]
    public void ToString_IsFormattable()
    {
        HResult hr = 0x10;
        Assert.Equal("0010", $"{hr:x4}");
        Assert.Equal("00000010", $"{hr:x8}");
    }

    [Fact]
    public void GetHashCodeReturnsValue()
    {
        Assert.Equal(3, new HResult(3).GetHashCode());
        Assert.Equal(4, new HResult(4).GetHashCode());
    }

    [Fact]
    public void EqualityChecks()
    {
        HResult hr3 = 3;
        HResult hr5 = 5;
        IEquatable<HResult> hr3Equatable = hr3;

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
        HResult hr3 = 3;
        HResult hr3b = 3;
        HResult hr5 = 5;

        Assert.True(hr3 != hr5);
        Assert.True(hr3 == hr3b);
        Assert.False(hr3 == hr5);
        Assert.False(hr3 != hr3b);
    }

    [Fact]
    public void Succeeded()
    {
        Assert.True(((HResult)HResult.Code.S_OK).Succeeded);
        Assert.True(((HResult)HResult.Code.S_FALSE).Succeeded);
        Assert.False(new HResult(-1).Succeeded);
    }

    [Fact]
    public void Failed()
    {
        Assert.False(((HResult)HResult.Code.S_OK).Failed);
        Assert.False(((HResult)HResult.Code.S_FALSE).Failed);
        Assert.True(new HResult(-1).Failed);
    }

    [Fact]
    public void Severity()
    {
        Assert.Equal((HResult.SeverityCode)0x80000000u, new HResult(0xffffffff).Severity);
    }

    [Fact]
    public void Facility()
    {
        Assert.Equal((HResult.FacilityCode)0x7ff0000, new HResult(0xffffffff).Facility);

        // Verify that a real HRESULT produces a valid Facility enum value.
        HResult hr = 0x80090001; // SECURITY_STATUS.NTE_BAD_UID
        Assert.Equal(HResult.FacilityCode.FACILITY_SECURITY, hr.Facility);
    }

    [Fact]
    public void Code()
    {
        Assert.Equal(0xffffu, new HResult(0xffffffff).FacilityStatus);
    }

    [Fact]
    public void ThrowOnFailure()
    {
        Assert.Throws<COMException>(() => ((HResult)HResult.Code.E_FAIL).ThrowOnFailure());
        ((HResult)HResult.Code.S_OK).ThrowOnFailure();
        ((HResult)HResult.Code.S_FALSE).ThrowOnFailure();
    }

    [Theory]
    [InlineData(HResult.Code.S_OK)]
    [InlineData(HResult.Code.S_FALSE)]
    [InlineData(HResult.Code.E_FAIL)]
    public void GetException(HResult.Code hrCode)
    {
        HResult hr = hrCode;
        Exception expected = Marshal.GetExceptionForHR(hr);
        Exception actual = hr.GetException();
        if (expected == null)
        {
            Assert.Null(actual);
        }
        else
        {
            Assert.IsType(expected.GetType(), actual);
            Assert.Equal(expected.Message, actual.Message);
        }
    }

    [Theory]
    [InlineData(HResult.Code.S_OK)]
    [InlineData(HResult.Code.S_FALSE)]
    [InlineData(HResult.Code.E_FAIL)]
    public void GetExceptionWithErrorInfo(HResult.Code hrCode)
    {
        HResult hr = hrCode;
        Exception expected = Marshal.GetExceptionForHR(hr);
        Exception actual = hr.GetException(IntPtr.Zero); // Consider actually initializing this.
        if (expected == null)
        {
            Assert.Null(actual);
        }
        else
        {
            Assert.IsType(expected.GetType(), actual);
            Assert.Equal(expected.Message, actual.Message);
        }
    }
}
