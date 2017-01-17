// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Runtime.InteropServices;

    /// <content>
    /// Exported functions from the NCrypt.dll Windows library
    /// that are available to Desktop apps only.
    /// </content>
    public static partial class NCrypt
    {
        /// <summary>
        /// Obtains the names of the registered key storage providers.
        /// </summary>
        /// <param name="pdwProviderCount">The address of a DWORD to receive the number of elements in the <paramref name="ppProviderList"/> array.</param>
        /// <param name="ppProviderList">
        /// The address of an <see cref="NCryptProviderName"/> structure pointer to receive an array of the registered key storage provider names. The variable pointed to by the <paramref name="pdwProviderCount"/> parameter receives the number of elements in this array.
        /// When this memory is no longer needed, free it by passing this pointer to the <see cref="NCryptFreeBuffer(void*)"/> function.
        /// </param>
        /// <param name="dwFlags">Flags that modify function behavior.</param>
        /// <returns>Returns a status code that indicates the success or failure of the function.</returns>
        [DllImport(nameof(NCrypt))]
        public static extern unsafe SECURITY_STATUS NCryptEnumStorageProviders(
            out int pdwProviderCount,
            out NCryptProviderName* ppProviderList,
            NCryptEnumStorageProvidersFlags dwFlags = NCryptEnumStorageProvidersFlags.None);

        /// <summary>
        /// Determines if the specified handle is a CNG key handle.
        /// </summary>
        /// <param name="hKey">The handle of the key to test.</param>
        /// <returns>Returns a nonzero value if the handle is a key handle or zero otherwise.</returns>
        [DllImport(nameof(NCrypt))]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool NCryptIsKeyHandle(IntPtr hKey);
    }
}
