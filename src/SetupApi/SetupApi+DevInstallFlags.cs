// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    /// <content>
    /// Contains the <see cref="DevInstallFlags"/> nested type.
    /// </content>
    public partial class SetupApi
    {
        /// <summary>
        /// Flags that control installation and user interface operations.
        /// </summary>
        [Flags]
        public enum DevInstallFlags : uint
        {
            /// <summary>
            /// Set to use the Class Install parameters. <see cref="SetupApi.SetupDiSetDeviceInstallParams(SafeDeviceInfoSetHandle, SP_DEVINFO_DATA*, SP_DEVINSTALL_PARAMS*)"/> sets this flag when the caller
            /// specifies parameters and clears the flag when the caller specifies a <see cref="IntPtr.Zero"/> parameters pointer.
            /// </summary>
            DI_CLASSINSTALLPARAMS = 0x00100000,

            /// <summary>
            /// Set to force <see cref="SetupApi.SetupDiBuildDriverInfoList(SafeDeviceInfoSetHandle, SP_DEVINFO_DATA*, DriverType)"/> to build a device's list of compatible drivers from its class driver list instead of the INF file.
            /// </summary>
            DI_COMPAT_FROM_CLASS = 0x00080000,

            /// <summary>
            /// Set by a class installer or co-installer if the installer supplies a page that replaces the system-supplied driver properties page. If this flag is set,
            /// the operating system does not display the system-supplied driver page.
            /// </summary>
            DI_DRIVERPAGE_ADDED = 0x04000000,

            /// <summary>
            /// Set if the configuration manager should not be called to remove or reenumerate devices during the execution of certain device installation functions
            /// (for example, <c>SetupApi.DiInstallDevice</c>).
            /// </summary>
            DI_DONOTCALLCONFIGMG = 0x00020000,

            /// <summary>
            /// Set if installers and other device installation components should only search the INF file specified by <see cref="SP_DEVINSTALL_PARAMS.DriverPath"/>.
            /// If this flag is set, <see cref="SP_DEVINSTALL_PARAMS.DriverPath"/> contains the path of a single INF file instead of a path of a directory.
            /// </summary>
            DI_ENUMSINGLEINF = 0x00010000,

            /// <summary>
            /// Set to indicate that the Select Device page should list drivers in the order in which they appear in the INF file, instead of sorting them alphabetically.
            /// </summary>
            DI_INF_IS_SORTED = 0x00008000,

            /// <summary>
            /// Set if the device should be installed in a disabled state by default. To be recognized, this flag must be set before Windows calls the default handler for the
            /// <c>DIF_INSTALLDEVICE</c> request.
            /// </summary>
            DI_INSTALLDISABLED = 0x00040000,

            /// <summary>
            /// For NT-based operating systems, this flag is set if the device requires that the computer be restarted after device installation or a device state change.
            /// A class installer or co-installer can set this flag at any time during device installation, if the installer determines that a restart is necessary.
            /// </summary>
            DI_NEEDREBOOT = 0x00000100,

            /// <summary>
            /// The same as <see cref="DI_NEEDREBOOT"/>.
            /// </summary>
            DI_NEEDRESTART = 0x00000080,

            /// <summary>
            /// Set to disable browsing when the user is selecting an OEM disk path. A device installation application sets this flag to constrain a user to only
            /// installing from the installation media location.
            /// </summary>
            DI_NOBROWSE = 0x00000200,

            /// <summary>
            /// Set if <c>SetupDiCallClassInstaller</c> should not perform any default action if the class installer returns <c>ERR_DI_DO_DEFAULT</c>
            /// or there is not a class installer.
            /// </summary>
            DI_NODI_DEFAULTACTION = 0x00200000,

            /// <summary>
            /// Set if device installation applications and components, such as <c>SetupApi.DiInstallDevice</c>, should skip file copying.
            /// </summary>
            DI_NOFILECOPY = 0x01000000,

            /// <summary>
            /// Set to disable creation of a new copy queue. Use the caller-supplied copy queue in <see cref="SP_DEVINSTALL_PARAMS.FileQueue"/>.
            /// </summary>
            DI_NOVCP = 0x00000008,

            /// <summary>
            /// Set to prevent <c>SetupApi.DiInstallDevice</c> from writing the INF-specified hardware IDs and compatible IDs to the device properties for
            /// the device node (devnode). This flag should only be set for root-enumerated devices.
            /// </summary>
            DI_NOWRITE_IDS = 0x80000000,

            /// <summary>
            /// Set by Device Manager if a device's properties were changed, which requires an update of the installer's user interface.
            /// </summary>
            DI_PROPERTIES_CHANGE = 0x00004000,

            /// <summary>
            /// Set if the device installer functions must be silent and use default choices wherever possible. Class installers and co-installers must
            /// not display any UI if this flag is set.
            /// </summary>
            DI_QUIETINSTALL = 0x00800000,

            /// <summary>
            /// Set by a class installer or co-installer if the installer supplies a page that replaces the system-supplied resource properties page.
            /// If this flag is set, the operating system does not display the system-supplied resource page.
            /// </summary>
            DI_RESOURCEPAGE_ADDED = 0x00002000,

            /// <summary>
            /// Set to allow support for OEM disks. If this flag is set, the operating system presents a "Have Disk" button on the Select Device page.
            /// This flag is set, by default, in system-supplied wizards.
            /// </summary>
            DI_SHOWOEM = 0x00000001,

            /// <summary>
            /// Set if a class installer or co-installer supplied strings that should be used during <c>DiSelectDevice</c>.
            /// </summary>
            DI_USECI_SELECTSTRINGS = 0x08000000,

            /// <summary>
            /// <para>
            /// Set if <see cref="SetupApi.SetupDiDestroyDeviceInfoList(IntPtr)"/> has already built a list of the drivers for this class of device.
            /// If this list has already been built, it contains all the driver information and this flag is always set.
            /// <see cref="SetupApi.SetupDiDestroyDeviceInfoList(IntPtr)"/> clears this flag when it deletes a list of drivers for a class.
            /// </para>
            /// <para>
            /// This flag is read-only. Only the operating system sets this flag.
            /// </para>
            /// </summary>
            DI_DIDCLASS = 0x00000020,

            /// <summary>
            /// <para>
            /// Set if <see cref="SetupApi.SetupDiDestroyDeviceInfoList(IntPtr)"/> has already built a list of compatible drivers for this device.
            /// If this list has already been built, it contains all the driver information and this flag is always set.
            /// <see cref="SetupApi.SetupDiDestroyDeviceInfoList(IntPtr)"/> clears this flag when it deletes a compatible driver list.
            /// </para>
            /// <para>
            /// This flag is only set in device installation parameters that are associated with a particular device information element,
            /// not in parameters for a device information set as a whole.
            /// </para>
            /// <para>
            /// This flag is read-only. Only the operating system sets this flag.
            /// </para>
            /// </summary>
            DI_DIDCOMPAT = 0x00000010,

            /// <summary>
            /// <para>
            /// Set by <see cref="SetupApi.SetupDiBuildDriverInfoList(SafeDeviceInfoSetHandle, SP_DEVINFO_DATA*, DriverType)"/> if a list of drivers for a device setup class contains drivers that are provided by multiple manufacturers.
            /// </para>
            /// <para>
            /// This flag is read-only. Only the operating system sets this flag.
            /// </para>
            /// </summary>
            DI_MULTMFGS = 0x00000400,
        }
    }
}
