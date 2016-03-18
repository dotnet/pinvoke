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
    }
}
