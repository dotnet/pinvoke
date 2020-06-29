// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Runtime.InteropServices;
using PInvoke;
using Xunit;
using static PInvoke.SetupApi;

public unsafe class SetupApiFacts
{
    [Fact]
    public void SetupDiCreateDeviceInfoListWithoutGuidTest()
    {
        using (var handle = SetupApi.SetupDiCreateDeviceInfoList(null, IntPtr.Zero))
        {
            Assert.False(handle.IsInvalid);
        }
    }

    [Fact]
    public void SetupDiCreateDeviceInfoWithGuidListTest()
    {
        Guid processorId = SetupApi.DeviceSetupClass.Processor;
        using (var handle = SetupApi.SetupDiCreateDeviceInfoList(&processorId, IntPtr.Zero))
        {
            Assert.False(handle.IsInvalid);
        }
    }

    [Fact]
    public void SetupDiOpenDeviceInfoTest()
    {
        using (var deviceInfoSet = SetupApi.SetupDiCreateDeviceInfoList(null, IntPtr.Zero))
        {
            SP_DEVINFO_DATA deviceInfoData = SP_DEVINFO_DATA.Create();

            // If DeviceInstanceId is NULL or references a zero-length string, SetupDiOpenDeviceInfo adds a device information element
            // to the supplied device information set, if one does not already exist, for the root device in the device tree.
            string deviceId = null;
            Assert.True(SetupApi.SetupDiOpenDeviceInfo(deviceInfoSet, deviceId, IntPtr.Zero, OpenFlags.None, ref deviceInfoData));
        }
    }

    [Fact]
    public void SetupDiSetSelectedDeviceTest()
    {
        using (var deviceInfoSet = SetupApi.SetupDiCreateDeviceInfoList(null, IntPtr.Zero))
        {
            SP_DEVINFO_DATA deviceInfoData = SP_DEVINFO_DATA.Create();

            // If DeviceInstanceId is NULL or references a zero-length string, SetupDiOpenDeviceInfo adds a device information element
            // to the supplied device information set, if one does not already exist, for the root device in the device tree.
            string deviceId = null;
            Assert.True(SetupApi.SetupDiOpenDeviceInfo(deviceInfoSet, deviceId, IntPtr.Zero, OpenFlags.None, ref deviceInfoData));

            Assert.True(SetupApi.SetupDiSetSelectedDevice(deviceInfoSet, ref deviceInfoData));

            deviceInfoData = SP_DEVINFO_DATA.Create();
            Assert.False(SetupApi.SetupDiSetSelectedDevice(deviceInfoSet, ref deviceInfoData));
        }
    }

    [Fact]
    public void SetupDiGetDeviceInstallParamsTest()
    {
        using (var deviceInfoSet = SetupApi.SetupDiCreateDeviceInfoList(null, IntPtr.Zero))
        {
            SP_DEVINFO_DATA deviceInfoData = SP_DEVINFO_DATA.Create();

            // If DeviceInstanceId is NULL or references a zero-length string, SetupDiOpenDeviceInfo adds a device information element
            // to the supplied device information set, if one does not already exist, for the root device in the device tree.
            string deviceId = null;
            Assert.True(SetupApi.SetupDiOpenDeviceInfo(deviceInfoSet, deviceId, IntPtr.Zero, OpenFlags.None, ref deviceInfoData));

            SP_DEVINSTALL_PARAMS deviceInstallParams = SP_DEVINSTALL_PARAMS.Create();

            Assert.True(SetupApi.SetupDiGetDeviceInstallParams(deviceInfoSet, ref deviceInfoData, ref deviceInstallParams));

            deviceInfoData = SP_DEVINFO_DATA.Create();
            Assert.False(SetupApi.SetupDiGetDeviceInstallParams(deviceInfoSet, ref deviceInfoData, ref deviceInstallParams));
        }
    }

    [Fact]
    public void SetupDiGetSetDeviceInstallParamsTest()
    {
        using (var deviceInfoSet = SetupApi.SetupDiCreateDeviceInfoList(null, IntPtr.Zero))
        {
            SP_DEVINFO_DATA deviceInfoData = SP_DEVINFO_DATA.Create();

            // If DeviceInstanceId is NULL or references a zero-length string, SetupDiOpenDeviceInfo adds a device information element
            // to the supplied device information set, if one does not already exist, for the root device in the device tree.
            string deviceId = null;
            Assert.True(SetupApi.SetupDiOpenDeviceInfo(deviceInfoSet, deviceId, IntPtr.Zero, OpenFlags.None, ref deviceInfoData));

            SP_DEVINSTALL_PARAMS deviceInstallParams = SP_DEVINSTALL_PARAMS.Create();

            Assert.True(SetupApi.SetupDiSetDeviceInstallParams(deviceInfoSet, ref deviceInfoData, ref deviceInstallParams));

            deviceInfoData = SP_DEVINFO_DATA.Create();
            Assert.False(SetupApi.SetupDiSetDeviceInstallParams(deviceInfoSet, ref deviceInfoData, ref deviceInstallParams));
        }
    }

    [Fact]
    public void SetupDiBuildDriverInfoListTest()
    {
        Guid usbDeviceId = SetupApi.DeviceSetupClass.UsbDevice;

        using (var deviceInfoSet = SetupApi.SetupDiCreateDeviceInfoList(&usbDeviceId, IntPtr.Zero))
        {
            Assert.True(SetupApi.SetupDiBuildDriverInfoList(deviceInfoSet, null, DriverType.SPDIT_CLASSDRIVER));
        }
    }

    [Fact]
    public void SetupDiEnumDriverInfoListTest()
    {
        Guid usbDeviceId = SetupApi.DeviceSetupClass.Net;

        using (var deviceInfoSet = SetupApi.SetupDiCreateDeviceInfoList(&usbDeviceId, IntPtr.Zero))
        {
            Assert.True(SetupApi.SetupDiBuildDriverInfoList(deviceInfoSet, null, DriverType.SPDIT_CLASSDRIVER));

            uint i = 0;

            SP_DRVINFO_DATA deviceInfoData = SP_DRVINFO_DATA.Create();

            while (SetupApi.SetupDiEnumDriverInfo(deviceInfoSet, null, DriverType.SPDIT_CLASSDRIVER, i, ref deviceInfoData))
            {
                i += 1;
            }

            // We should have enumerated at least one driver
            Assert.NotEqual(0u, i);
        }
    }
}
