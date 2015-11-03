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

            /// <summary>The buffer supplied to a function was too small.</summary>
            NTE_BUFFER_TOO_SMALL = 0x80090028,

            /// <summary>The requested operation is not supported.</summary>
            NTE_NOT_SUPPORTED = 0x80090029,

            /// <summary>No more data is available.</summary>
            NTE_NO_MORE_ITEMS = 0x8009002a,
        }

        /// <summary>
        /// A legacy identifier that specifies the type of key.
        /// </summary>
        public enum LegacyKeySpec
        {
            /// <summary>
            /// None of the other types.
            /// </summary>
            None = 0x0,

            /// <summary>
            /// The key is a key exchange key.
            /// </summary>
            AT_KEYEXCHANGE,

            /// <summary>
            /// The key is a signature key.
            /// </summary>
            AT_SIGNATURE,
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
        /// Flags that may be passed to the <see cref="NCryptCreatePersistedKey(SafeProviderHandle, out SafeKeyHandle, string, string, LegacyKeySpec, NCryptCreatePersistedKeyFlags)"/> method.
        /// </summary>
        [Flags]
        public enum NCryptCreatePersistedKeyFlags
        {
            /// <summary>
            /// No flags.
            /// </summary>
            None = 0x0,

            /// <summary>
            /// The key applies to the local computer. If this flag is not present, the key applies to the current user.
            /// </summary>
            NCRYPT_MACHINE_KEY_FLAG,

            /// <summary>
            /// If a key already exists in the container with the specified name, the existing key will be overwritten. If this flag is not specified and a key with the specified name already exists, this function will return <see cref="SECURITY_STATUS.NTE_EXISTS"/>.
            /// </summary>
            NCRYPT_OVERWRITE_KEY_FLAG,
        }

        /// <summary>
        /// Flags that may be passed to the <see cref="NCryptFinalizeKey"/> function.
        /// </summary>
        [Flags]
        public enum NCryptFinalizeKeyFlags
        {
            /// <summary>
            /// No flags.
            /// </summary>
            None = 0x0,

            /// <summary>
            /// Do not validate the public portion of the key pair. This flag only applies to public/private key pairs.
            /// </summary>
            NCRYPT_NO_KEY_VALIDATION = 0x00000008,

            /// <summary>
            /// Also save the key in legacy storage. This allows the key to be used with CryptoAPI. This flag only applies to RSA keys.
            /// </summary>
            NCRYPT_WRITE_KEY_TO_LEGACY_STORE_FLAG = 0x00000200,

            /// <summary>
            /// Requests that the key service provider (KSP) not display any user interface. If the provider must display the UI to operate, the call fails and the KSP should set the NTE_SILENT_CONTEXT error code as the last error.
            /// </summary>
            NCRYPT_SILENT_FLAG = 0x00000040,
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
        /// Creates a new key and stores it in the specified key storage provider. After you create a key by using this function, you can use the NCryptSetProperty function to set its properties; however, the key cannot be used until the NCryptFinalizeKey function is called.
        /// </summary>
        /// <param name="hProvider">
        /// The handle of the key storage provider to create the key in. This handle is obtained by using the <see cref="NCryptOpenStorageProvider(string, NCryptOpenStorageProviderFlags)"/> function.
        /// </param>
        /// <param name="phKey">
        /// The address of an <see cref="SafeKeyHandle"/> variable that receives the handle of the key. When you have finished using this handle, release it by disposing it.
        /// </param>
        /// <param name="pszAlgId">
        /// A null-terminated Unicode string that contains the identifier of the cryptographic algorithm to create the key. This can be one of the standard CNG Algorithm Identifiers defined in <see cref="AlgorithmIdentifiers"/> or the identifier for another registered algorithm.
        /// </param>
        /// <param name="pszKeyName">
        /// A pointer to a null-terminated Unicode string that contains the name of the key. If this parameter is NULL, this function will create an ephemeral key that is not persisted.
        /// </param>
        /// <param name="dwLegacyKeySpec">
        /// A legacy identifier that specifies the type of key.
        /// </param>
        /// <param name="dwFlags">A set of flags that modify the behavior of this function.</param>
        /// <returns>Returns a status code that indicates the success or failure of the function.</returns>
        [DllImport(nameof(NCrypt))]
        public static extern SECURITY_STATUS NCryptCreatePersistedKey(
            SafeProviderHandle hProvider,
            out SafeKeyHandle phKey,
            string pszAlgId,
            string pszKeyName = null,
            LegacyKeySpec dwLegacyKeySpec = LegacyKeySpec.None,
            NCryptCreatePersistedKeyFlags dwFlags = NCryptCreatePersistedKeyFlags.None);

        /// <summary>
        /// Completes a CNG key storage key. The key cannot be used until this function has been called.
        /// </summary>
        /// <param name="hKey">
        /// The handle of the key to complete. This handle is obtained by calling the <see cref="NCryptCreatePersistedKey(SafeProviderHandle, string, string, LegacyKeySpec, NCryptCreatePersistedKeyFlags)"/> function.
        /// </param>
        /// <param name="dwFlags">
        /// Flags that modify function behavior.
        /// </param>
        /// <returns>Returns a status code that indicates the success or failure of the function.</returns>
        [DllImport(nameof(NCrypt))]
        public static extern SECURITY_STATUS NCryptFinalizeKey(
            SafeKeyHandle hKey,
            NCryptFinalizeKeyFlags dwFlags = NCryptFinalizeKeyFlags.None);

        /// <summary>
        /// Retrieves the value of a named property for a key storage object.
        /// </summary>
        /// <param name="hObject">
        /// The handle of the object to get the property for. This can be a provider handle (<see cref="SafeProviderHandle"/>) or a key handle (<see cref="SafeKeyHandle"/>).
        /// </param>
        /// <param name="pszProperty">
        /// A pointer to a null-terminated Unicode string that contains the name of the property to retrieve. This can be one of the predefined <see cref="KeyStoragePropertyIdentifiers"/> or a custom property identifier.
        /// </param>
        /// <param name="pbOutput">
        /// The address of a buffer that receives the property value. The <paramref name="cbOutput"/> parameter contains the size of this buffer.
        /// To calculate the size required for the buffer, set this parameter to NULL. The size, in bytes, required is returned in the location pointed to by the <paramref name="pcbResult"/> parameter.
        /// </param>
        /// <param name="cbOutput">
        /// The size, in bytes, of the <paramref name="pbOutput"/> buffer.
        /// </param>
        /// <param name="pcbResult">
        /// A pointer to a DWORD variable that receives the number of bytes that were copied to the <paramref name="pbOutput"/> buffer.
        /// If the <paramref name="pbOutput"/> parameter is NULL, the size, in bytes, required for the buffer is placed in the location pointed to by this parameter.
        /// </param>
        /// <param name="dwFlags">Flags that modify function behavior.</param>
        /// <returns>Returns a status code that indicates the success or failure of the function.</returns>
        [DllImport(nameof(NCrypt), CharSet = CharSet.Unicode)]
        public static extern SECURITY_STATUS NCryptGetProperty(
            SafeHandle hObject,
            string pszProperty,
            [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] byte[] pbOutput,
            int cbOutput,
            out int pcbResult,
            NCryptGetPropertyFlags dwFlags);

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
