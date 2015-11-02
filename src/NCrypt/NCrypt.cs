// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Runtime.InteropServices;

    /// <summary>
    /// Exported functions from the NCrypt.dll Windows library
    /// that are available to Desktop and Store apps.
    /// </summary>
    public static partial class NCrypt
    {
        /// <summary>
        /// Describes the error codes that may be returned from NCrypt functions.
        /// </summary>
        public enum SECURITY_STATUS : uint
        {
            /// <summary>
            /// The operation completed successfully.
            /// </summary>
            ERROR_SUCCESS = 0,

            /// <summary>Bad UID.</summary>
            NTE_BAD_UID = 0x80090001,

            /// <summary>Bad hash.</summary>
            NTE_BAD_HASH = 0x80090002,

            /// <summary>Bad key.</summary>
            NTE_BAD_KEY = 0x80090003,

            /// <summary>Bad length.</summary>
            NTE_BAD_LEN = 0x80090004,

            /// <summary>Bad data.</summary>
            NTE_BAD_DATA = 0x80090005,

            /// <summary>Invalid signature.</summary>
            NTE_BAD_SIGNATURE = 0x80090006,

            /// <summary>Bad version of provider.</summary>
            NTE_BAD_VER = 0x80090007,

            /// <summary>Invalid algorithm specified.</summary>
            NTE_BAD_ALGID = 0x80090008,

            /// <summary>Invalid flags specified.</summary>
            NTE_BAD_FLAGS = 0x80090009,

            /// <summary>Invalid type specified.</summary>
            NTE_BAD_TYPE = 0x8009000A,

            /// <summary>Key not valid for use in specified state.</summary>
            NTE_BAD_KEY_STATE = 0x8009000B,

            /// <summary>Hash not valid for use in specified state.</summary>
            NTE_BAD_HASH_STATE = 0x8009000C,

            /// <summary>Key does not exist.</summary>
            NTE_NO_KEY = 0x8009000D,

            /// <summary>Insufficient memory available for the operation.</summary>
            NTE_NO_MEMORY = 0x8009000E,

            /// <summary>Object already exists.</summary>
            NTE_EXISTS = 0x8009000F,

            /// <summary>Access denied.</summary>
            NTE_PERM = 0x80090010,

            /// <summary>Object was not found.</summary>
            NTE_NOT_FOUND = 0x80090011,

            /// <summary>Data already encrypted.</summary>
            NTE_DOUBLE_ENCRYPT = 0x80090012,

            /// <summary>Invalid provider specified.</summary>
            NTE_BAD_PROVIDER = 0x80090013,

            /// <summary>Invalid provider type specified.</summary>
            NTE_BAD_PROV_TYPE = 0x80090014,

            /// <summary>Invalid provider public key.</summary>
            NTE_BAD_PUBLIC_KEY = 0x80090015,

            /// <summary>Keyset does not exist</summary>
            NTE_BAD_KEYSET = 0x80090016,

            /// <summary>Provider type not defined.</summary>
            NTE_PROV_TYPE_NOT_DEF = 0x80090017,

            /// <summary>Invalid registration for provider type.</summary>
            NTE_PROV_TYPE_ENTRY_BAD = 0x80090018,

            /// <summary>The keyset not defined.</summary>
            NTE_KEYSET_NOT_DEF = 0x80090019,

            /// <summary>Invalid keyset registration.</summary>
            NTE_KEYSET_ENTRY_BAD = 0x8009001A,

            /// <summary>Provider type does not match registered value.</summary>
            NTE_PROV_TYPE_NO_MATCH = 0x8009001B,

            /// <summary>Corrupt digital signature file.</summary>
            NTE_SIGNATURE_FILE_BAD = 0x8009001C,

            /// <summary>Provider DLL failed to initialize correctly.</summary>
            NTE_PROVIDER_DLL_FAIL = 0x8009001D,

            /// <summary>Provider DLL not found.</summary>
            NTE_PROV_DLL_NOT_FOUND = 0x8009001E,

            /// <summary>Invalid keyset parameter.</summary>
            NTE_BAD_KEYSET_PARAM = 0x8009001F,

            /// <summary>Internal error occurred.</summary>
            NTE_FAIL = 0x80090020,

            /// <summary>Base error occurred.</summary>
            NTE_SYS_ERR = 0x80090021,

            /// <summary>Undocumented.</summary>
            NTE_BUFFER_TOO_SMALL = 0x80090028,

            /// <summary>Undocumented.</summary>
            NTE_NO_MORE_ITEMS = 0x8009002a,
        }

        /// <summary>
        /// Flags that may be passed to the <see cref="NCryptOpenStorageProvider(out SafeProviderHandle, string, NCryptOpenStorageProviderFlags)"/> function.
        /// </summary>
        [Flags]
        public enum NCryptOpenStorageProviderFlags
        {
            /// <summary>
            /// No flags.
            /// </summary>
            None = 0x0,
        }

        /// <summary>
        /// Loads and initializes a CNG key storage provider.
        /// </summary>
        /// <param name="phProvider">
        /// A pointer to a <see cref="SafeProviderHandle"/> variable that receives the provider handle. When you have finished using this handle, release it by passing it to the <see cref="NCryptFreeObject"/> function.
        /// </param>
        /// <param name="pszProviderName">
        /// A pointer to a null-terminated Unicode string that identifies the key storage provider to load. This is the registered alias of the key storage provider. This parameter is optional and can be NULL. If this parameter is NULL, the default key storage provider is loaded. The <see cref="KeyStorageProviders"/> class identifies the built-in key storage providers.
        /// </param>
        /// <param name="dwFlags">Flags that modify the behavior of the function.</param>
        /// <returns>Returns a status code that indicates the success or failure of the function.</returns>
        [DllImport(nameof(NCrypt), CharSet = CharSet.Unicode)]
        public static extern SECURITY_STATUS NCryptOpenStorageProvider(
            out SafeProviderHandle phProvider,
            string pszProviderName,
            NCryptOpenStorageProviderFlags dwFlags = NCryptOpenStorageProviderFlags.None);

        /// <summary>
        /// Frees a CNG key storage object.
        /// </summary>
        /// <param name="hObject">
        /// The handle of the object to free. This can be either a provider handle (<see cref="SafeProviderHandle"/>) or a key handle (<see cref="SafeKeyHandle"/>).
        /// </param>
        /// <returns>Returns a status code that indicates the success or failure of the function.</returns>
        [DllImport(nameof(NCrypt))]
        private static extern SECURITY_STATUS NCryptFreeObject(IntPtr hObject);
    }
}
