// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Collections.ObjectModel;
using System.Linq;
using PInvoke;
using Xunit;
using static PInvoke.SetupApi;

public unsafe class SetupApiFacts
{
    [Fact]
    public void SetupDiCreateDeviceInfoListWithoutGuidTest()
    {
        using var handle = SetupDiCreateDeviceInfoList((Guid*)null, IntPtr.Zero);
        Assert.False(handle.IsInvalid);
    }

    [Fact]
    public void SetupDiCreateDeviceInfoWithGuidListTest()
    {
        Guid processorId = DeviceSetupClass.Processor;
        using var handle = SetupDiCreateDeviceInfoList(&processorId, IntPtr.Zero);
        Assert.False(handle.IsInvalid);
    }

    [Fact]
    public void SetupDiOpenDeviceInfoTest()
    {
        using var deviceInfoSet = SetupDiCreateDeviceInfoList((Guid*)null, IntPtr.Zero);

        SP_DEVINFO_DATA deviceInfoData = SP_DEVINFO_DATA.Create();

        // If DeviceInstanceId is NULL or references a zero-length string, SetupDiOpenDeviceInfo adds a device information element
        // to the supplied device information set, if one does not already exist, for the root device in the device tree.
        string deviceId = null;
        Assert.True(SetupDiOpenDeviceInfo(deviceInfoSet, deviceId, IntPtr.Zero, SetupDiOpenDeviceInfoFlags.None, ref deviceInfoData));
    }

    [Fact]
    public void SetupDiSetSelectedDeviceTest()
    {
        using var deviceInfoSet = SetupDiCreateDeviceInfoList((Guid*)null, IntPtr.Zero);

        SP_DEVINFO_DATA deviceInfoData = SP_DEVINFO_DATA.Create();

        // If DeviceInstanceId is NULL or references a zero-length string, SetupDiOpenDeviceInfo adds a device information element
        // to the supplied device information set, if one does not already exist, for the root device in the device tree.
        string deviceId = null;
        Assert.True(SetupDiOpenDeviceInfo(deviceInfoSet, deviceId, IntPtr.Zero, SetupDiOpenDeviceInfoFlags.None, ref deviceInfoData));

        Assert.True(SetupDiSetSelectedDevice(deviceInfoSet, deviceInfoData));

        deviceInfoData = SP_DEVINFO_DATA.Create();
        Assert.False(SetupDiSetSelectedDevice(deviceInfoSet, deviceInfoData));
    }

    [Fact]
    public void SetupDiGetDeviceInstallParamsTest()
    {
        using var deviceInfoSet = SetupDiCreateDeviceInfoList((Guid*)null, IntPtr.Zero);

        SP_DEVINFO_DATA deviceInfoData = SP_DEVINFO_DATA.Create();

        // If DeviceInstanceId is NULL or references a zero-length string, SetupDiOpenDeviceInfo adds a device information element
        // to the supplied device information set, if one does not already exist, for the root device in the device tree.
        string deviceId = null;
        if (!SetupDiOpenDeviceInfo(deviceInfoSet, deviceId, IntPtr.Zero, SetupDiOpenDeviceInfoFlags.None, ref deviceInfoData))
        {
            throw new Win32Exception();
        }

        SP_DEVINSTALL_PARAMS deviceInstallParams = SP_DEVINSTALL_PARAMS.Create();

        if (!SetupDiGetDeviceInstallParams(deviceInfoSet, deviceInfoData, ref deviceInstallParams))
        {
            throw new Win32Exception();
        }

        deviceInfoData = SP_DEVINFO_DATA.Create();
        Assert.False(SetupDiGetDeviceInstallParams(deviceInfoSet, deviceInfoData, ref deviceInstallParams));
    }

    [Fact]
    public void SetupDiGetSetDeviceInstallParamsTest()
    {
        using var deviceInfoSet = SetupDiCreateDeviceInfoList((Guid*)null, IntPtr.Zero);

        SP_DEVINFO_DATA deviceInfoData = SP_DEVINFO_DATA.Create();

        // If DeviceInstanceId is NULL or references a zero-length string, SetupDiOpenDeviceInfo adds a device information element
        // to the supplied device information set, if one does not already exist, for the root device in the device tree.
        string deviceId = null;
        Assert.True(SetupDiOpenDeviceInfo(deviceInfoSet, deviceId, IntPtr.Zero, SetupDiOpenDeviceInfoFlags.None, ref deviceInfoData));

        SP_DEVINSTALL_PARAMS deviceInstallParams = SP_DEVINSTALL_PARAMS.Create();

        Assert.True(SetupDiSetDeviceInstallParams(deviceInfoSet, deviceInfoData, deviceInstallParams));

        deviceInfoData = SP_DEVINFO_DATA.Create();
        Assert.False(SetupDiSetDeviceInstallParams(deviceInfoSet, deviceInfoData, deviceInstallParams));
    }

    [Fact]
    public void SetupDiBuildDriverInfoListTest()
    {
        Guid usbDeviceId = DeviceSetupClass.UsbDevice;

        using var deviceInfoSet = SetupDiCreateDeviceInfoList(&usbDeviceId, IntPtr.Zero);
        Assert.True(SetupDiBuildDriverInfoList(deviceInfoSet, (SP_DEVINFO_DATA*)null, DriverType.SPDIT_CLASSDRIVER));
    }

    [Fact]
    public void SetupDiEnumDriverInfoListTest()
    {
        Guid usbDeviceId = DeviceSetupClass.Net;

        using var deviceInfoSet = SetupDiCreateDeviceInfoList(&usbDeviceId, IntPtr.Zero);

        Assert.True(SetupDiBuildDriverInfoList(deviceInfoSet, (SP_DEVINFO_DATA*)null, DriverType.SPDIT_CLASSDRIVER));

        uint i = 0;
        SP_DRVINFO_DATA driverInfoData = SP_DRVINFO_DATA.Create();
        Collection<SP_DRVINFO_DATA> driverInfos = new Collection<SP_DRVINFO_DATA>();
        while (SetupDiEnumDriverInfo(deviceInfoSet, null, DriverType.SPDIT_CLASSDRIVER, i++, ref driverInfoData))
        {
            driverInfos.Add(driverInfoData);
        }

        // We should have enumerated at least one driver
        Assert.NotEmpty(driverInfos);

        var loopbackDrivers =
            driverInfos
            .Where(d => new string(d.Description).IndexOf("loopback", StringComparison.OrdinalIgnoreCase) >= 0).ToArray();

        var loopbackDriver = Assert.Single(loopbackDrivers);

        Assert.Equal("Microsoft KM-TEST Loopback Adapter", new string(loopbackDriver.Description));
        Assert.Equal(DriverType.SPDIT_CLASSDRIVER, loopbackDriver.DriverType);
        Assert.NotEqual(0u, loopbackDriver.DriverVersion);
        Assert.Equal("Microsoft", new string(loopbackDriver.MfgName));
        Assert.Equal("Microsoft", new string(loopbackDriver.ProviderName));
    }

    [Fact]
    public unsafe void SetupDiGetDriverInfoDetailTest()
    {
        Guid usbDeviceId = DeviceSetupClass.Net;

        using var deviceInfoSet = SetupDiCreateDeviceInfoList(&usbDeviceId, IntPtr.Zero);

        Assert.True(SetupDiBuildDriverInfoList(deviceInfoSet, (SP_DEVINFO_DATA*)null, DriverType.SPDIT_CLASSDRIVER));

        uint i = 0;
        SP_DRVINFO_DATA driverInfoData = SP_DRVINFO_DATA.Create();
        Collection<SP_DRVINFO_DATA> driverInfos = new Collection<SP_DRVINFO_DATA>();
        while (SetupDiEnumDriverInfo(deviceInfoSet, null, DriverType.SPDIT_CLASSDRIVER, i++, ref driverInfoData))
        {
            driverInfos.Add(driverInfoData);
        }

        // We should have enumerated at least one driver
        Assert.NotEmpty(driverInfos);

        var loopbackDrivers =
            driverInfos
            .Where(d => new string(d.Description).IndexOf("loopback", StringComparison.OrdinalIgnoreCase) >= 0).ToArray();

        var loopbackDriver = Assert.Single(loopbackDrivers);

        byte[] buffer = new byte[0x1000];
        fixed (byte* ptr = buffer)
        {
            var drvInfoDetailData = (SP_DRVINFO_DETAIL_DATA*)ptr;
            *drvInfoDetailData = SP_DRVINFO_DETAIL_DATA.Create();

            if (!SetupDiGetDriverInfoDetail(
                deviceInfoSet,
                null,
                &loopbackDriver,
                ptr,
                buffer.Length,
                out int requiredSize))
            {
                throw new Win32Exception();
            }

            Assert.Equal(0, (int)drvInfoDetailData->CompatIDsLength);
            Assert.Equal(0x8, drvInfoDetailData->CompatIDsOffset);
            Assert.Equal("Microsoft KM-TEST Loopback Adapter", new string(drvInfoDetailData->DrvDescription));
            Assert.NotEqual(0, drvInfoDetailData->InfDate.dwHighDateTime);
            Assert.NotEqual(0, drvInfoDetailData->InfDate.dwLowDateTime);
            Assert.Equal(@"C:\WINDOWS\INF\netloop.inf", new string(drvInfoDetailData->InfFileName), ignoreCase: true);
            Assert.Equal("kmloop.ndi", new string(drvInfoDetailData->SectionName), ignoreCase: true);
            Assert.Equal("*msloop", new string(drvInfoDetailData->HardwareID));
        }
    }
}
