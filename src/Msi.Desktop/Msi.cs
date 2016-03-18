// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Runtime.InteropServices;

    /// <content>
    /// Exported functions from the Msi.dll Windows library
    /// that are available to Desktop apps only.
    /// </content>
    public static partial class Msi
    {
        /// <summary>
        /// The MsiInstallProduct function installs or uninstalls a product.
        /// </summary>
        /// <param name="szPackagePath">
        /// A null-terminated string that specifies the path to the location of the Windows Installer package. The string value can contain a URL (e.g. http://packageLocation/package/package.msi), a network path (e.g. \\packageLocation\package.msi), a file path (e.g. file://packageLocation/package.msi), or a local path (e.g. D:\packageLocation\package.msi).
        /// </param>
        /// <param name="szCommandLine">
        /// A null-terminated string that specifies the command line property settings. This should be a list of the format Property=Setting Property=Setting. For more information, see About Properties.
        /// To perform an administrative installation, include ACTION=ADMIN in szCommandLine. For more information, see the ACTION property.
        /// </param>
        /// <returns><see cref="Win32ErrorCode.ERROR_SUCCESS"/> when the function completes successfully. Otherwise an error code.</returns>
        [DllImport(nameof(Msi), CharSet = CharSet.Unicode)]
        public static extern Win32ErrorCode MsiInstallProduct(string szPackagePath, string szCommandLine);

        /// <summary>
        /// The MsiIsProductElevated function returns whether or not the product is managed. Only applications that require elevated privileges for installation and being installed through advertisement are considered managed, which means that an application installed per-machine is always considered managed.
        /// An application that is installed per-user is only considered managed if it is advertised by a local system process that is impersonating the user. For more information, see Advertising a Per-User Application to be Installed with Elevated Privileges.
        /// MsiIsProductElevated verifies that the local system owns the product registry data. The function does not refer to account policies such as AlwaysInstallElevated.
        /// </summary>
        /// <param name="szProductCode">
        /// The full product code GUID of the product.
        /// This parameter is required and cannot be NULL or empty.
        /// </param>
        /// <param name="pfElevated">
        /// A pointer to a BOOL for the result.
        /// This parameter cannot be NULL.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is ERROR_SUCCESS, and pfElevated is set to TRUE if the product is a managed application.
        /// </returns>
        [DllImport(nameof(Msi), CharSet = CharSet.Unicode)]
        public static extern Win32ErrorCode MsiIsProductElevated(
            string szProductCode,
            [MarshalAs(UnmanagedType.Bool)] out bool pfElevated);
    }
}
