// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.InteropServices;
using PInvoke;
using Xunit;
using static PInvoke.SetupApi;

public unsafe class SetupApiFacts
{
    [Fact]
    public void SetupDiCreateDeviceInfoListWithoutGuidTest()
    {
        using (var handle = SetupApi.SetupDiCreateDeviceInfoList((Guid*)null, IntPtr.Zero))
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
        using (var deviceInfoSet = SetupApi.SetupDiCreateDeviceInfoList((Guid*)null, IntPtr.Zero))
        {
            SP_DEVINFO_DATA deviceInfoData = SP_DEVINFO_DATA.Create();

            // If DeviceInstanceId is NULL or references a zero-length string, SetupDiOpenDeviceInfo adds a device information element
            // to the supplied device information set, if one does not already exist, for the root device in the device tree.
            string deviceId = null;
            Assert.True(SetupApi.SetupDiOpenDeviceInfo(deviceInfoSet, deviceId, IntPtr.Zero, SetupDiOpenDeviceInfoFlags.None, ref deviceInfoData));
        }
    }

    [Fact]
    public void SetupDiSetSelectedDeviceTest()
    {
        using (var deviceInfoSet = SetupApi.SetupDiCreateDeviceInfoList((Guid*)null, IntPtr.Zero))
        {
            SP_DEVINFO_DATA deviceInfoData = SP_DEVINFO_DATA.Create();

            // If DeviceInstanceId is NULL or references a zero-length string, SetupDiOpenDeviceInfo adds a device information element
            // to the supplied device information set, if one does not already exist, for the root device in the device tree.
            string deviceId = null;
            Assert.True(SetupApi.SetupDiOpenDeviceInfo(deviceInfoSet, deviceId, IntPtr.Zero, SetupDiOpenDeviceInfoFlags.None, ref deviceInfoData));

            Assert.True(SetupApi.SetupDiSetSelectedDevice(deviceInfoSet, deviceInfoData));

            deviceInfoData = SP_DEVINFO_DATA.Create();
            Assert.False(SetupApi.SetupDiSetSelectedDevice(deviceInfoSet, deviceInfoData));
        }
    }

    [Fact]
    public void SetupDiGetDeviceInstallParamsTest()
    {
        using (var deviceInfoSet = SetupApi.SetupDiCreateDeviceInfoList((Guid*)null, IntPtr.Zero))
        {
            SP_DEVINFO_DATA deviceInfoData = SP_DEVINFO_DATA.Create();

            // If DeviceInstanceId is NULL or references a zero-length string, SetupDiOpenDeviceInfo adds a device information element
            // to the supplied device information set, if one does not already exist, for the root device in the device tree.
            string deviceId = null;
            if (!SetupApi.SetupDiOpenDeviceInfo(deviceInfoSet, deviceId, IntPtr.Zero, SetupDiOpenDeviceInfoFlags.None, ref deviceInfoData))
            {
                throw new Win32Exception();
            }

            SP_DEVINSTALL_PARAMS deviceInstallParams = SP_DEVINSTALL_PARAMS.Create();

            if (!SetupApi.SetupDiGetDeviceInstallParams(deviceInfoSet, deviceInfoData, ref deviceInstallParams))
            {
                throw new Win32Exception();
            }

            deviceInfoData = SP_DEVINFO_DATA.Create();
            Assert.False(SetupApi.SetupDiGetDeviceInstallParams(deviceInfoSet, deviceInfoData, ref deviceInstallParams));
        }
    }

    [Fact]
    public void SetupDiGetSetDeviceInstallParamsTest()
    {
        using (var deviceInfoSet = SetupApi.SetupDiCreateDeviceInfoList((Guid*)null, IntPtr.Zero))
        {
            SP_DEVINFO_DATA deviceInfoData = SP_DEVINFO_DATA.Create();

            // If DeviceInstanceId is NULL or references a zero-length string, SetupDiOpenDeviceInfo adds a device information element
            // to the supplied device information set, if one does not already exist, for the root device in the device tree.
            string deviceId = null;
            Assert.True(SetupApi.SetupDiOpenDeviceInfo(deviceInfoSet, deviceId, IntPtr.Zero, SetupDiOpenDeviceInfoFlags.None, ref deviceInfoData));

            SP_DEVINSTALL_PARAMS deviceInstallParams = SP_DEVINSTALL_PARAMS.Create();

            Assert.True(SetupApi.SetupDiSetDeviceInstallParams(deviceInfoSet, deviceInfoData, deviceInstallParams));

            deviceInfoData = SP_DEVINFO_DATA.Create();
            Assert.False(SetupApi.SetupDiSetDeviceInstallParams(deviceInfoSet, deviceInfoData, deviceInstallParams));
        }
    }

    [Fact]
    public void SetupDiBuildDriverInfoListTest()
    {
        Guid usbDeviceId = SetupApi.DeviceSetupClass.UsbDevice;

        using (var deviceInfoSet = SetupApi.SetupDiCreateDeviceInfoList(&usbDeviceId, IntPtr.Zero))
        {
            Assert.True(SetupApi.SetupDiBuildDriverInfoList(deviceInfoSet, (SP_DEVINFO_DATA*)null, DriverType.SPDIT_CLASSDRIVER));
        }
    }

    [Fact]
    public void SetupDiEnumDriverInfoListTest()
    {
        Guid usbDeviceId = SetupApi.DeviceSetupClass.Net;

        using (var deviceInfoSet = SetupApi.SetupDiCreateDeviceInfoList(&usbDeviceId, IntPtr.Zero))
        {
            Assert.True(SetupApi.SetupDiBuildDriverInfoList(deviceInfoSet, (SP_DEVINFO_DATA*)null, DriverType.SPDIT_CLASSDRIVER));

            uint i = 0;

            SP_DRVINFO_DATA driverInfoData = SP_DRVINFO_DATA.Create();

            Collection<SP_DRVINFO_DATA> driverInfos = new Collection<SP_DRVINFO_DATA>();

            while (SetupApi.SetupDiEnumDriverInfo(deviceInfoSet, null, DriverType.SPDIT_CLASSDRIVER, i, ref driverInfoData))
            {
                driverInfos.Add(driverInfoData);
                i += 1;
            }

            // We should have enumerated at least one driver
            Assert.NotEmpty(driverInfos);

            var loopbackDrivers =
                driverInfos
                .Where(d => d.DescriptionString.IndexOf("loopback", StringComparison.OrdinalIgnoreCase) >= 0).ToArray();

            var loopbackDriver = Assert.Single(loopbackDrivers);

            Assert.Equal("Microsoft KM-TEST Loopback Adapter", loopbackDriver.DescriptionString);
            Assert.Equal(DriverType.SPDIT_CLASSDRIVER, loopbackDriver.DriverType);
            Assert.NotEqual(0u, loopbackDriver.DriverVersion);
            Assert.Equal("Microsoft", loopbackDriver.MfgNameString);
            Assert.Equal("Microsoft", loopbackDriver.ProviderNameString);
        }
    }
}
