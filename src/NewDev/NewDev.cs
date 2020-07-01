// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PInvoke
{
    using System;
#if NETFRAMEWORK || NETSTANDARD2_0_ORLATER
    using System.Runtime.ConstrainedExecution;
#endif
    using System.Runtime.InteropServices;
    using System.Security;

    /// <content>
    /// Exported functions from the SetupApi.dll Windows library
    /// that are available to Desktop apps only.
    /// </content>
    [OfferFriendlyOverloads]
    public static partial class NewDev
    {
        /// <summary>
        /// The <see cref="DiInstallDevice(IntPtr, SetupApi.SafeDeviceInfoSetHandle, SetupApi.SP_DEVINFO_DATA*, SetupApi.SP_DRVINFO_DATA*, InstallDeviceFlags, out bool)"/> function installs a specified driver on a specified device that is present in the system.
        /// </summary>
        /// <param name="hwndParent">
        /// A handle to the top-level window that <see cref="DiInstallDevice(IntPtr, SetupApi.SafeDeviceInfoSetHandle, SetupApi.SP_DEVINFO_DATA*, SetupApi.SP_DRVINFO_DATA*, InstallDeviceFlags, out bool)"/> uses to display any user interface component that is associated
        /// with installing the device. This parameter is optional and can be set to <see cref="IntPtr.Zero"/>.
        /// </param>
        /// <param name="deviceInfoSet">
        /// A handle to a device information set that contains a device information element that represents the specified device.
        /// </param>
        /// <param name="deviceInfoData">
        /// A <see cref="SetupApi.SP_DEVINFO_DATA"/> structure that represents the specified device in the specified device information set.
        /// </param>
        /// <param name="driverInfoData">
        /// An pointer to an <see cref="SetupApi.SP_DRVINFO_DATA"/> structure that specifies the driver to install on the specified device.
        /// This parameter is optional and can be set to <see langword="null"/>. If this parameter is <see langword="null"/>, <see cref="DiInstallDevice(IntPtr, SetupApi.SafeDeviceInfoSetHandle, SetupApi.SP_DEVINFO_DATA*, SetupApi.SP_DRVINFO_DATA*, InstallDeviceFlags, out bool)"/>
        /// searches the drivers preinstalled in the driver store for the driver that is the best match to the specified device, and, if one is found,
        /// installs the driver on the specified device.
        /// </param>
        /// <param name="flags">
        /// Flags that specify how to install the driver.
        /// </param>
        /// <param name="needReboot">
        /// A reference to a value of type <see cref="bool"/> that <see cref="DiInstallDevice(IntPtr, SetupApi.SafeDeviceInfoSetHandle, SetupApi.SP_DEVINFO_DATA*, SetupApi.SP_DRVINFO_DATA*, InstallDeviceFlags, out bool)"/> sets to indicate whether a system restart is required
        /// to complete the installation. This parameter is optional and can be set to <see cref="IntPtr.Zero"/>. If this parameter is supplied and a
        /// system restart is required to complete the installation, <see cref="DiInstallDevice(IntPtr, SetupApi.SafeDeviceInfoSetHandle, SetupApi.SP_DEVINFO_DATA*, SetupApi.SP_DRVINFO_DATA*, InstallDeviceFlags, out bool)"/> sets the value to <see langword="true"/>.
        /// In this case, the caller is responsible for restarting the system. If this parameter is supplied and a system restart is not required,
        /// <see cref="DiInstallDevice(IntPtr, SetupApi.SafeDeviceInfoSetHandle, SetupApi.SP_DEVINFO_DATA*, SetupApi.SP_DRVINFO_DATA*, InstallDeviceFlags, out bool)"/> sets this parameter to <see langword="false"/>. If this parameter is <see cref="IntPtr.Zero"/> and a system
        /// restart is required to complete the installation, <see cref="DiInstallDevice(IntPtr, SetupApi.SafeDeviceInfoSetHandle, SetupApi.SP_DEVINFO_DATA*, SetupApi.SP_DRVINFO_DATA*, InstallDeviceFlags, out bool)"/> displays a system restart dialog box.
        /// </param>
        /// <returns>
        /// The function returns <see langword="true"/> if it is successful.
        /// Otherwise, it returns <see langword="false"/> and the logged error can be retrieved with a call to <see cref="Marshal.GetLastWin32Error"/>.
        /// </returns>
        /// <seealso href="https://msdn.microsoft.com/en-us/library/windows/hardware/ff544710(v=vs.85).aspx"/>
        [DllImport(nameof(NewDev), SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern unsafe bool DiInstallDevice(
            IntPtr hwndParent,
            SetupApi.SafeDeviceInfoSetHandle deviceInfoSet,
            [Friendly(FriendlyFlags.In)] SetupApi.SP_DEVINFO_DATA* deviceInfoData,
            [Friendly(FriendlyFlags.In)] SetupApi.SP_DRVINFO_DATA* driverInfoData,
            InstallDeviceFlags flags,
            out bool needReboot);

        /// <summary>
        /// Given an INF file and a hardware ID, the <see cref="UpdateDriverForPlugAndPlayDevices"/> function installs
        /// updated drivers for devices that match the hardware ID.
        /// </summary>
        /// <param name="hwndParent">
        /// A handle to the top-level window to use for any UI related to installing devices.
        /// </param>
        /// <param name="hardwareId">
        /// A <see cref="string"/> that supplies the hardware identifier to match
        /// existing devices on the computer. The maximum length of hardware identifier is
        /// <c>MAX_DEVICE_ID_LEN</c>.
        /// </param>
        /// <param name="fullInfPath">
        /// A <see cref="string"/> that supplies the full path file name of an INF file.
        /// The files should be on the distribution media or in a vendor-created directory,
        /// not in a system location such as <c>%SystemRoot%\inf</c>. <see cref="UpdateDriverForPlugAndPlayDevices"/>
        /// copies driver files to the appropriate system locations if the installation is successful.
        /// </param>
        /// <param name="installFlags">
        /// A caller-supplied value created by using OR to combine zero or more of the <see cref="InstallFlags"/> values.
        /// </param>
        /// <param name="bRebootRequired">
        /// A pointer to a BOOL-typed variable that indicates whether a restart is required and who
        /// should prompt for it. This pointer is optional and can be <see cref="IntPtr.Zero"/>.
        /// </param>
        /// <returns>
        /// <para>
        /// The function returns <see langword="true"/> if a device was upgraded to the specified driver.
        /// </para>
        /// <para>
        /// Otherwise, it returns FALSE and the logged error can be retrieved with a call to <see cref="Marshal.GetLastWin32Error"/>.
        /// </para>
        /// </returns>
        [DllImport(nameof(NewDev), SetLastError = true, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool UpdateDriverForPlugAndPlayDevices(
            IntPtr hwndParent,
            [MarshalAs(UnmanagedType.LPWStr)] string hardwareId,
            [MarshalAs(UnmanagedType.LPWStr)] string fullInfPath,
            InstallFlags installFlags,
            out bool bRebootRequired);

        /// <summary>
        /// The DiUninstallDevice function uninstalls a device and removes its device node (devnode) from the system.
        /// </summary>
        /// <param name="hwndParent">
        /// A handle to the top-level window that is used to display any user interface component that is associated with the
        /// uninstallation request for the device. This parameter is optional and can be set to NULL.
        /// </param>
        /// <param name="deviceInfoSet">
        /// A handle to the device information set that contains a device information element. This element represents the
        /// device to be uninstalled through this call.
        /// </param>
        /// <param name="deviceInfoData">
        /// A pointer to an SP_DEVINFO_DATA structure that represents the specified device in the specified device information
        /// set for which the uninstallation request is performed.
        /// </param>
        /// <param name="flags">
        /// A value of type DWORD that specifies device uninstallation flags. Starting with Windows 7, this parameter must be
        /// set to zero.
        /// </param>
        /// <param name="needReboot">
        /// A pointer to a value of type BOOL that DiUninstallDevice sets to indicate whether a system restart is required to
        /// complete the device uninstallation request. This parameter is optional and can be set to NULL.
        /// If the parameter is given and a system restart is required, DiUninstallDevice sets the value to TRUE.In this case,
        /// the application must prompt the user to restart the system. If this parameter is supplied and a system restart is
        /// not required, DiUninstallDevice sets the value to FALSE.
        /// If this parameter is NULL and a system restart is required to complete the device uninstallation, DiUninstallDevice
        /// displays a system restart dialog box.
        /// </param>
        /// <returns>
        /// DiUninstallDevice returns TRUE if the function successfully uninstalled the top-level device node that represents the device.
        /// Otherwise, DiUninstallDevice returns FALSE, and the logged error can be retrieved by making a call to GetLastError.
        /// </returns>
        [DllImport(nameof(NewDev), SetLastError = true, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool DiUninstallDevice(
            IntPtr hwndParent,
            SetupApi.SafeDeviceInfoSetHandle deviceInfoSet,
            ref SetupApi.SP_DEVINFO_DATA deviceInfoData,
            int flags,
            out bool needReboot);
    }
}
