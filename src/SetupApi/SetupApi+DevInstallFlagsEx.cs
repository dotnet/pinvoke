// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    /// <content>
    /// Contains the <see cref="DevInstallFlagsEx"/> nested type.
    /// </content>
    public partial class SetupApi
    {
        /// <summary>
        /// Flags that control installation and user interface operations.
        /// </summary>
        [Flags]
        public enum DevInstallFlagsEx : uint
        {
            /// <summary>
            /// <para>
            /// If set, include drivers that were marked "Exclude From Select."
            /// </para>
            /// <para>
            /// For example, if this flag is set, <c>SetupDiSelectDevice</c>  displays drivers that have the Exclude From Select state
            /// and <see cref="SetupApi.SetupDiBuildDriverInfoList(SafeDeviceInfoSetHandle, SP_DEVINFO_DATA*, DriverType)"/> includes Exclude From Select drivers in the requested driver list.
            /// </para>
            /// <para>
            /// A driver is "Exclude From Select" if either it is marked <c>ExcludeFromSelect</c> in the INF file or it is a driver for a device whose whole
            /// setup class is marked <c>NoInstallClass</c> or <c>NoUseClass</c> in the class installer INF. Drivers for PnP devices are typically "Exclude From Select";
            /// PnP devices should not be manually installed. To build a list of driver files for a PnP device a caller of <see cref="SetupApi.SetupDiBuildDriverInfoList(SafeDeviceInfoSetHandle, SP_DEVINFO_DATA*, DriverType)"/>
            /// must set this flag.
            /// </para>
            /// </summary>
            DI_FLAGSEX_ALLOWEXCLUDEDDRVS = 0x00000800,

            /// <summary>
            /// If set and the <see cref="DevInstallFlags.DI_NOWRITE_IDS"/> flag is clear, always write hardware and compatible IDs to the device properties for the devnode.
            /// This flag should only be set for root-enumerated devices.
            /// </summary>
            DI_FLAGSEX_ALWAYSWRITEIDS = 0x00000200,

            /// <summary>
            /// If set, <see cref="SetupApi.SetupDiBuildDriverInfoList(SafeDeviceInfoSetHandle, SP_DEVINFO_DATA*, DriverType)"/> appends a new driver list to an existing list. This flag is relevant when searching multiple locations.
            /// </summary>
            DI_FLAGSEX_APPENDDRIVERLIST = 0x00040000,

            /// <summary>
            /// <para>
            /// If set, build the driver list from INF(s) retrieved from the URL that is specified in <see cref="SP_DEVINSTALL_PARAMS.DriverPath"/>. If the <see cref="SP_DEVINSTALL_PARAMS.DriverPath"/>
            /// is an empty string, use the Windows Update website.
            /// </para>
            /// <para>
            /// Currently, the operating system does not support URLs. Use this flag to direct <see cref="SetupApi.SetupDiBuildDriverInfoList(SafeDeviceInfoSetHandle, SP_DEVINFO_DATA*, DriverType)"/> to search the Windows Update website.
            /// </para>
            /// <para>
            /// Do not set this flag if <see cref="DevInstallFlags.DI_QUIETINSTALL"/> is set.
            /// </para>
            /// </summary>
            DI_FLAGSEX_DRIVERLIST_FROM_URL,

            /// <summary>
            /// If set, do not include old Internet drivers when building a driver list. This flag should be set any time that you are building a list of potential drivers for a device.
            /// You can clear this flag if you are just getting a list of drivers currently installed for a device.
            /// </summary>
            DI_FLAGSEX_EXCLUDE_OLD_INET_DRIVERS,

            /// <summary>
            /// If set, <c>SetupDiBuildClassInfoList</c> will check for class inclusion filters. This means that a device will not be included in the
            /// class list if its class is marked as <c>NoInstallClass</c>.
            /// </summary>
            DI_FLAGSEX_FILTERCLASSES = 0x00000040,

            /// <summary>
            /// If set, <see cref="SetupApi.SetupDiBuildDriverInfoList(SafeDeviceInfoSetHandle, SP_DEVINFO_DATA*, DriverType)"/> includes "similar" drivers when building a class driver list. A "similar" driver is one for which
            /// one of the hardware IDs or compatible IDs in the INF file partially (or completely) matches one of the hardware IDs or compatible IDs of the hardware.
            /// </summary>
            DI_FLAGSEX_FILTERSIMILARDRIVERS = 0x02000000,

            /// <summary>
            /// If set, the driver was obtained from the Internet. Windows will not use the device's INF to install future devices because Windows cannot guarantee that it
            /// can retrieve the driver files again from the Internet.
            /// </summary>
            DI_FLAGSEX_INET_DRIVER = 0x00020000,

            /// <summary>
            /// If set, <see cref="SetupApi.SetupDiBuildDriverInfoList(SafeDeviceInfoSetHandle, SP_DEVINFO_DATA*, DriverType)"/> includes only the currently installed driver when creating a list of class drivers or device-compatible drivers.
            /// </summary>
            DI_FLAGSEX_INSTALLEDDRIVER = 0x04000000,

            /// <summary>
            /// Do not process the <c>AddReg</c> and <c>DelReg</c> entries for the device's hardware and software (driver) keys. That is, the <c>AddReg</c> and <c>DelReg</c> entries in the INF file
            /// <c>DDInstall</c> and <c>DDInstall.HW</c> sections.
            /// </summary>
            DI_FLAGSEX_NO_DRVREG_MODIFY = 0x00008000,

            /// <summary>
            /// If set, an installer added their own page for the power properties dialog. The operating system will not display the system-supplied power properties page.
            /// This flag is only relevant if the device supports power management.
            /// </summary>
            DI_FLAGSEX_POWERPAGE_ADDED = 0x01000000,

            /// <summary>
            /// <para>
            /// If set, the user made changes to one or more device property sheets. The property-page provider typically sets this flag.
            /// </para>
            /// <para>
            /// When the user closes the device property sheet, Device Manager checks the <see cref="DI_FLAGSEX_PROPCHANGE_PENDING"/> flag.
            /// If it is set, Device Manager clears this flag, sets the <see cref="DevInstallFlags.DI_PROPERTIES_CHANGE"/> flag, and sends a <c>DIF_PROPERTYCHANGE</c>
            /// request to the installers to notify them that something has changed.
            /// </para>
            /// </summary>
            DI_FLAGSEX_PROPCHANGE_PENDING = 0x00000400,

            /// <summary>
            /// Set if the installation failed. If this flag is set, the <c>SetupDiInstallDevice</c> function just sets the <c>FAILEDINSTALL</c> flag
            /// in the device's ConfigFlags registry value. If <see cref="DI_FLAGSEX_SETFAILEDINSTALL"/> is set, co-installers must return <c>NO_ERROR</c> in response to <c>DIF_INSTALLDEVICE</c>,
            /// while class installers must return <c>NO_ERROR</c> or <c>ERROR_DI_DO_DEFAULT</c>.
            /// </summary>
            DI_FLAGSEX_SETFAILEDINSTALL = 0x00000080,

            /// <summary>
            /// Filter INF files on the device's setup class when building a list of compatible drivers. If a device's setup class is known, setting this flag reduces the
            /// time that is required to build a list of compatible drivers when searching INF files that are not precompiled. This flag is ignored if <see cref="DevInstallFlags.DI_COMPAT_FROM_CLASS"/> is set.
            /// </summary>
            DI_FLAGSEX_USECLASSFORCOMPAT = 0x00002000,

            /// <summary>
            /// Set by the operating system if a class installer failed to load or start. This flag is read-only.
            /// </summary>
            DI_FLAGSEX_CI_FAILED = 0x00000004,

            /// <summary>
            /// Windows has built a list of driver nodes that are compatible with the device. This flag is read-only.
            /// </summary>
            DI_FLAGSEX_DIDCOMPATINFO = 0x00000020,

            /// <summary>
            /// Windows has built a list of driver nodes that includes all the drivers that are listed in the INF files of the specified setup class.
            /// If the specified setup class is <see langword="null"/> because the HDEVINFO set or device has no associated class,
            /// the list includes all driver nodes from all available INF files. This flag is read-only.
            /// </summary>
            DI_FLAGSEX_DIDINFOLIST = 0x00000010,

            /// <summary>
            /// If set, installation is occurring during initial system setup. This flag is read-only.
            /// </summary>
            DI_FLAGSEX_IN_SYSTEM_SETUP = 0x00010000,
        }
    }
}
