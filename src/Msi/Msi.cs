// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Runtime.InteropServices;

    /// <content>
    /// Exported functions from the Msi.dll Windows library
    /// that are available to Desktop apps only.
    /// </content>
    [OfferFriendlyOverloads]
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
        /// <param name="dwContext">Restricts the enumeration to a context.</param>
        /// <param name="dwIndex">Specifies the index of the product to retrieve. This parameter must be zero for the first call to the MsiEnumProductsEx function and then incremented for subsequent calls. The index should be incremented, only if the previous call has returned ERROR_SUCCESS. Because products are not ordered, any new product has an arbitrary index. This means that the function can return products in any order.</param>
        /// <param name="szInstalledProductCode">39 character length array for a null-terminated string of TCHAR that gives the ProductCode GUID of the product instance being enumerated. This parameter can be NULL.</param>
        /// <param name="pdwInstalledContext">Returns the context of the product instance being enumerated. The output value can be <see cref="MSIINSTALLCONTEXT.MSIINSTALLCONTEXT_USERMANAGED"/>, <see cref="MSIINSTALLCONTEXT.MSIINSTALLCONTEXT_USERUNMANAGED"/>, or <see cref="MSIINSTALLCONTEXT.MSIINSTALLCONTEXT_MACHINE"/>. This parameter can be NULL.</param>
        /// <param name="szSid">
        /// An output buffer that receives the string SID of the account under which this product instance exists. This buffer returns an empty string for an instance installed in a per-machine context.
        /// This buffer should be large enough to contain the SID. If the buffer is too small, the function returns <see cref="Win32ErrorCode.ERROR_MORE_DATA"/> and sets *<paramref name="pcchSid"/> to the number of TCHAR in the SID, not including the terminating NULL character.
        /// If <paramref name="szSid"/> is set to NULL and pcchSid is set to a valid pointer, the function returns <see cref="Win32ErrorCode.ERROR_SUCCESS"/> and sets *<paramref name="pcchSid"/> to the number of TCHAR in the value, not including the terminating NULL. The function can then be called again to retrieve the value, with the <paramref name="szSid"/> buffer large enough to contain *<paramref name="pcchSid"/> + 1 characters.
        /// If <paramref name="szSid"/> and <paramref name="pcchSid"/> are both set to NULL, the function returns <see cref="Win32ErrorCode.ERROR_SUCCESS"/> if the value exists, without retrieving the value.
        /// </param>
        /// <param name="pcchSid">
        /// When calling the function, this parameter should be a pointer to a variable that specifies the number of TCHAR in the <paramref name="szSid"/> buffer. When the function returns, this parameter is set to the size of the requested value whether or not the function copies the value into the specified buffer. The size is returned as the number of TCHAR in the requested value, not including the terminating null character.
        /// This parameter can be set to NULL only if <paramref name="szSid"/> is also NULL, otherwise the function returns ERROR_INVALID_PARAMETER.
        /// </param>
        /// <returns>An error code.</returns>
        [DllImport(nameof(Msi), CharSet = CharSet.Unicode)]
        public static extern unsafe Win32ErrorCode MsiEnumProductsEx(
            string szProductCode,
            string szUserSid,
            MSIINSTALLCONTEXT dwContext,
            int dwIndex,
            [Friendly(FriendlyFlags.Out | FriendlyFlags.Optional | FriendlyFlags.Array)] char* szInstalledProductCode,
            [Friendly(FriendlyFlags.Out | FriendlyFlags.Optional)] MSIINSTALLCONTEXT* pdwInstalledContext,
            [Friendly(FriendlyFlags.Out | FriendlyFlags.Optional | FriendlyFlags.Array, ArrayLengthParameter = 7)] char* szSid,
            [Friendly(FriendlyFlags.In | FriendlyFlags.Out | FriendlyFlags.Optional)] int* pcchSid);
    }
}
