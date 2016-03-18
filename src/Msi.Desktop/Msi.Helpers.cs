// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Runtime.InteropServices;

    /// <content>
    /// Methods and nested types that are not strictly P/Invokes but provide
    /// a slightly higher level of functionality to ease calling into native code.
    /// </content>
    public static partial class Msi
    {
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
        public static Win32ErrorCode MsiIsProductElevated(
            Guid szProductCode,
            out bool pfElevated)
        {
            return MsiIsProductElevated(szProductCode.ToString("B"), out pfElevated);
        }

        /// <summary>
        /// The MsiEnumProductsEx function enumerates through one or all the instances of products that are currently advertised or installed in the specified contexts.
        /// This function supersedes MsiEnumProducts.
        /// </summary>
        /// <param name="szProductCode">
        /// ProductCode GUID of the product to be enumerated. Only instances of products within the scope of the context specified by the szUserSid and dwContext parameters are enumerated. This parameter can be set to NULL to enumerate all products in the specified context.
        /// </param>
        /// <param name="szUserSid">
        /// Null-terminated string that specifies a security identifier (SID) that restricts the context of enumeration. The special SID string s-1-1-0 (Everyone) specifies enumeration across all users in the system. A SID value other than s-1-1-0 is considered a user-SID and restricts enumeration to the current user or any user in the system. This parameter can be set to NULL to restrict the enumeration scope to the current user.
        /// See MSDN documentation for more information.
        /// </param>
        /// <param name="dwContext">Restricts the enumeration to a context. </param>
        /// <param name="dwIndex">Specifies the index of the product to retrieve. This parameter must be zero for the first call to the MsiEnumProductsEx function and then incremented for subsequent calls. The index should be incremented, only if the previous call has returned ERROR_SUCCESS. Because products are not ordered, any new product has an arbitrary index. This means that the function can return products in any order.</param>
        /// <param name="szInstalledProductCode">Gives the ProductCode GUID of the product instance being enumerated. This parameter can be NULL.</param>
        /// <param name="pdwInstalledContext">Returns the context of the product instance being enumerated. The output value can be <see cref="MSIINSTALLCONTEXT.MSIINSTALLCONTEXT_USERMANAGED"/>, <see cref="MSIINSTALLCONTEXT.MSIINSTALLCONTEXT_USERUNMANAGED"/>, or <see cref="MSIINSTALLCONTEXT.MSIINSTALLCONTEXT_MACHINE"/>. This parameter can be NULL.</param>
        /// <param name="szSid">
        /// An output buffer that receives the string SID of the account under which this product instance exists. This buffer returns an empty string for an instance installed in a per-machine context.
        /// </param>
        /// <returns>An error code.</returns>
        public static unsafe Win32ErrorCode MsiEnumProductsEx(
            string szProductCode,
            string szUserSid,
            MSIINSTALLCONTEXT dwContext,
            int dwIndex,
            out Guid szInstalledProductCode,
            out MSIINSTALLCONTEXT pdwInstalledContext,
            out string szSid)
        {
            szInstalledProductCode = Guid.Empty;
            pdwInstalledContext = MSIINSTALLCONTEXT.MSIINSTALLCONTEXT_NONE;
            szSid = null;

            var installedProductCode = new char[39];
            MSIINSTALLCONTEXT? pdwInstalledContextLocal = MSIINSTALLCONTEXT.MSIINSTALLCONTEXT_NONE;
            int? pcchSid = 0;
            Win32ErrorCode error = MsiEnumProductsEx(
                szProductCode,
                szUserSid,
                dwContext,
                dwIndex,
                installedProductCode,
                ref pdwInstalledContextLocal,
                null,
                ref pcchSid);
            if (error != Win32ErrorCode.ERROR_SUCCESS)
            {
                return error;
            }

            char[] pszSid = new char[pcchSid.Value];
            error = MsiEnumProductsEx(
                szProductCode,
                szUserSid,
                dwContext,
                dwIndex,
                installedProductCode,
                ref pdwInstalledContextLocal,
                pszSid,
                ref pcchSid);
            if (error != Win32ErrorCode.ERROR_SUCCESS)
            {
                return error;
            }

            szInstalledProductCode = new Guid(new string(installedProductCode, 0, 38));
            pdwInstalledContext = pdwInstalledContextLocal.Value;
            szSid = new string(pszSid, 0, pcchSid.Value);
            return error;
        }
    }
}
