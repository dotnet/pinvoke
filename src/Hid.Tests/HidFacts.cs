// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using PInvoke;
using Xunit;
using static PInvoke.Hid;
using static PInvoke.Kernel32;

public class HidFacts
{
    [Fact]
    public void HidD_GetHidGuid_ReturnExpectedValue()
    {
        // The GUID is a well know value
        Assert.Equal(HidD_GetHidGuid(), Guid.Parse("4d1e55b2-f16f-11cf-88cb-001111000030"));
    }

    [Fact]
    public void HidP_GetCaps_ThrowForInvalidHandle()
    {
        Assert.Throws<ArgumentException>(() =>
            HidP_GetCaps(new SafePreparsedDataHandle(new IntPtr(0), false)));
    }

    [Fact]
    public void HidD_GetManufacturerString_ThrowForInvalidHandle()
    {
        Assert.Throws<Win32Exception>(() =>
            HidD_GetManufacturerString(new SafeObjectHandle(new IntPtr(0), false)));
    }

    [Fact]
    public void HidD_GetProductString_ThrowForInvalidHandle()
    {
        Assert.Throws<Win32Exception>(() =>
            HidD_GetProductString(new SafeObjectHandle(new IntPtr(0), false)));
    }

    [Fact]
    public void HidD_GetSerialNumberString_ThrowForInvalidHandle()
    {
        Assert.Throws<Win32Exception>(() =>
            HidD_GetSerialNumberString(new SafeObjectHandle(new IntPtr(0), false)));
    }

    [Fact]
    public void HidD_GetAttributes_ThrowForInvalidHandle()
    {
        Assert.Throws<Win32Exception>(() =>
            HidD_GetAttributes(new SafeObjectHandle(new IntPtr(0), false)));
    }

    [Fact]
    public void HidD_GetPreparsedData_ThrowForInvalidHandle()
    {
        Assert.Throws<Win32Exception>(() =>
            HidD_GetPreparsedData(new SafeObjectHandle(new IntPtr(0), false)));
    }
}
