// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PInvoke
{
    using System;

    /// <content>
    /// Contains the <see cref="InstallDeviceFlags"/> nested type.
    /// </content>
    public partial class NewDev
    {
        /// <summary>
        /// Specifies how a driver is installed.
        /// </summary>
        public enum InstallDeviceFlags : uint
        {
            /// <summary>
            /// The flag is not set.
            /// </summary>
            None = 0,

            /// <summary>
            /// If the caller does not specify a driver (<c>DriverInfoData</c> is set to <see langword="NULL"/>) and <see cref="NewDev.DiInstallDevice(IntPtr, SetupApi.SafeDeviceInfoSetHandle, SetupApi.SP_DEVINFO_DATA*, SetupApi.SP_DRVINFO_DATA*, InstallDeviceFlags, out bool)"/>
            /// does not locate a preinstalled driver that matches the specified device. Instead, <see cref="NewDev.DiInstallDevice(IntPtr, SetupApi.SafeDeviceInfoSetHandle, SetupApi.SP_DEVINFO_DATA*, SetupApi.SP_DRVINFO_DATA*, InstallDeviceFlags, out bool)"/> displays the
            /// Found New Hardware wizard for the device.
            /// </summary>
            DIIDFLAG_SHOWSEARCHUI = 0x00000001,

            /// <summary>
            /// <see cref="NewDev.DiInstallDevice(IntPtr, SetupApi.SafeDeviceInfoSetHandle, SetupApi.SP_DEVINFO_DATA*, SetupApi.SP_DRVINFO_DATA*, InstallDeviceFlags, out bool)"/> does not start finish-install wizard pages or finish-install actions. The caller of <see cref="NewDev.DiInstallDevice(IntPtr, SetupApi.SafeDeviceInfoSetHandle, SetupApi.SP_DEVINFO_DATA*, SetupApi.SP_DRVINFO_DATA*, InstallDeviceFlags, out bool)"/>
            /// must start these operations. The caller should only specify this flag if the caller requires that finish-install wizard pages be invoked in the
            /// context of a caller-supplied user interface component.
            /// </summary>
            DIIDFLAG_NOFINISHINSTALLUI = 0x00000002,

            /// <summary>
            /// <see cref="NewDev.DiInstallDevice(IntPtr, SetupApi.SafeDeviceInfoSetHandle, SetupApi.SP_DEVINFO_DATA*, SetupApi.SP_DRVINFO_DATA*, InstallDeviceFlags, out bool)"/> attempts to install a null driver on the specified device. If this flag is set, <see cref="NewDev.DiInstallDevice(IntPtr, SetupApi.SafeDeviceInfoSetHandle, SetupApi.SP_DEVINFO_DATA*, SetupApi.SP_DRVINFO_DATA*, InstallDeviceFlags, out bool)"/> does
            /// not use the <c>DriverInfoData</c> parameter. <see cref="NewDev.DiInstallDevice(IntPtr, SetupApi.SafeDeviceInfoSetHandle, SetupApi.SP_DEVINFO_DATA*, SetupApi.SP_DRVINFO_DATA*, InstallDeviceFlags, out bool)"/> removes all device settings and, if the device cannot run in raw mode,
            /// the function sets the status of the device to <c>CM_PROB_FAILED_INSTALL</c>. If <see cref="NewDev.DiInstallDevice(IntPtr, SetupApi.SafeDeviceInfoSetHandle, SetupApi.SP_DEVINFO_DATA*, SetupApi.SP_DRVINFO_DATA*, InstallDeviceFlags, out bool)"/> cannot install a <see langword="null"/>
            /// driver, the resulting state of the device is the same as if the device was connected for the first time to the computer and Windows did not locate
            /// a driver for the device.
            /// </summary>
            DIIDFLAG_INSTALLNULLDRIVER = 0x00000004,
        }
    }
}
