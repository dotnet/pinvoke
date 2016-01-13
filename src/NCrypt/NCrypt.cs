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
    [OfferIntPtrOverloads]
    public static partial class NCrypt
    {
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
        /// A null-terminated Unicode string that contains the identifier of the cryptographic algorithm to create the key. This can be one of the standard CNG Algorithm Identifiers defined in <see cref="BCrypt.AlgorithmIdentifiers"/> or the identifier for another registered algorithm.
        /// </param>
        /// <param name="pszKeyName">
        /// A pointer to a null-terminated Unicode string that contains the name of the key. If this parameter is NULL, this function will create an ephemeral key that is not persisted.
        /// </param>
        /// <param name="dwLegacyKeySpec">
        /// A legacy identifier that specifies the type of key.
        /// </param>
        /// <param name="dwFlags">A set of flags that modify the behavior of this function.</param>
        /// <returns>Returns a status code that indicates the success or failure of the function.</returns>
        [DllImport(nameof(NCrypt), CharSet = CharSet.Unicode)]
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
        /// The NCryptExportKey function exports a CNG key to a memory BLOB.
        /// </summary>
        /// <param name="hKey">A handle of the key to export.</param>
        /// <param name="hExportKey">A handle to a cryptographic key of the destination user. The key data within the exported key BLOB is encrypted by using this key. This ensures that only the destination user is able to make use of the key BLOB.</param>
        /// <param name="pszBlobType">A null-terminated Unicode string that contains an identifier that specifies the type of BLOB to export. This can be one of the values defined by the <see cref="BCrypt.AsymmetricKeyBlobTypes"/> or <see cref="BCrypt.SymmetricKeyBlobTypes"/> classes.</param>
        /// <param name="pParameterList">The address of an NCryptBufferDesc structure that receives parameter information for the key. This parameter can be NULL if this information is not needed.</param>
        /// <param name="pbOutput">The address of a buffer that receives the key BLOB. The <paramref name="cbOutput"/> parameter contains the size of this buffer. If this parameter is NULL, this function will place the required size, in bytes, in the DWORD pointed to by the <paramref name="pcbResult"/> parameter.</param>
        /// <param name="cbOutput">The size, in bytes, of the <paramref name="pbOutput" /> buffer.</param>
        /// <param name="pcbResult">The address of a DWORD variable that receives the number of bytes copied to the <paramref name="pbOutput"/> buffer. If the <paramref name="pbOutput"/> parameter is NULL, this function will place the required size, in bytes, in the DWORD pointed to by this parameter.</param>
        /// <param name="dwFlags">Flags that modify function behavior. This can be zero or a combination of one or more of the following values. The set of valid flags is specific to each key storage provider.</param>
        /// <returns>Returns a status code that indicates the success or failure of the function.</returns>
        /// <remarks>
        /// A service must not call this function from its StartService Function. If a service calls this function from its StartService function, a deadlock can occur, and the service may stop responding.
        /// </remarks>
        [DllImport(nameof(NCrypt), CharSet = CharSet.Unicode)]
        public static extern unsafe SECURITY_STATUS NCryptExportKey(
            SafeKeyHandle hKey,
            SafeKeyHandle hExportKey,
            string pszBlobType,
            NCryptBufferDesc* pParameterList,
            byte[] pbOutput,
            int cbOutput,
            out int pcbResult,
            NCryptExportKeyFlags dwFlags = NCryptExportKeyFlags.None);

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
        /// Sets the value for a named property for a CNG key storage object.
        /// </summary>
        /// <param name="hObject">The handle of the key storage object to set the property for.</param>
        /// <param name="pszProperty">
        /// A pointer to a null-terminated Unicode string that contains the name of the property to set. This can be one of the predefined <see cref="KeyStoragePropertyIdentifiers"/> or a custom property identifier.
        /// </param>
        /// <param name="pbInput">
        /// The address of a buffer that contains the new property value. The <paramref name="cbInput"/> parameter contains the size of this buffer.
        /// </param>
        /// <param name="cbInput">
        /// The size, in bytes, of the <paramref name="pbInput"/> buffer.
        /// </param>
        /// <param name="dwFlags">Flags that modify function behavior.</param>
        /// <returns>Returns a status code that indicates the success or failure of the function.</returns>
        [DllImport(nameof(NCrypt), CharSet = CharSet.Unicode)]
        public static extern unsafe SECURITY_STATUS NCryptSetProperty(
            SafeHandle hObject,
            string pszProperty,
            byte* pbInput,
            int cbInput,
            NCryptSetPropertyFlags dwFlags);

        /// <summary>
        /// Sets the value for a named property for a CNG key storage object.
        /// </summary>
        /// <param name="hObject">The handle of the key storage object to set the property for.</param>
        /// <param name="pszProperty">
        /// A pointer to a null-terminated Unicode string that contains the name of the property to set. This can be one of the predefined <see cref="KeyStoragePropertyIdentifiers"/> or a custom property identifier.
        /// </param>
        /// <param name="pbInput">
        /// The address of a buffer that contains the new property value. The <paramref name="cbInput"/> parameter contains the size of this buffer.
        /// </param>
        /// <param name="cbInput">
        /// The size, in bytes, of the <paramref name="pbInput"/> buffer.
        /// </param>
        /// <param name="dwFlags">Flags that modify function behavior.</param>
        /// <returns>Returns a status code that indicates the success or failure of the function.</returns>
        [DllImport(nameof(NCrypt), CharSet = CharSet.Unicode)]
        public static extern SECURITY_STATUS NCryptSetProperty(
            SafeHandle hObject,
            string pszProperty,
            string pbInput,
            int cbInput,
            NCryptSetPropertyFlags dwFlags);

        /// <summary>
        /// Encrypts a block of data.
        /// </summary>
        /// <param name="hKey">
        /// The handle of the key to use to encrypt the data.
        /// </param>
        /// <param name="pbInput">
        /// The address of a buffer that contains the plaintext to be encrypted. The cbInput parameter contains the size of the plaintext to encrypt.
        /// </param>
        /// <param name="cbInput">
        /// The number of bytes in the pbInput buffer to encrypt.
        /// </param>
        /// <param name="pPaddingInfo">
        /// A pointer to a structure that contains padding information. This parameter is only used with asymmetric keys and authenticated encryption modes. If an authenticated encryption mode is used, this parameter must point to a BCRYPT_AUTHENTICATED_CIPHER_MODE_INFO structure. If asymmetric keys are used, the type of structure this parameter points to is determined by the value of the dwFlags parameter. Otherwise, the parameter must be set to NULL.
        /// </param>
        /// <param name="pbOutput">
        /// The address of the buffer that receives the ciphertext produced by this function. The <paramref name="cbOutput"/> parameter contains the size of this buffer. For more information, see Remarks.
        /// If this parameter is NULL, this function calculates the size needed for the ciphertext of the data passed in the <paramref name="pbInput"/> parameter. In this case, the location pointed to by the <paramref name="pcbResult"/> parameter contains this size, and the function returns <see cref="NTSTATUS.Code.STATUS_SUCCESS"/>.The <paramref name="pPaddingInfo"/> parameter is not modified.
        /// If the values of both the <paramref name="pbOutput"/> and <paramref name="pbInput"/> parameters are NULL, an error is returned unless an authenticated encryption algorithm is in use.In the latter case, the call is treated as an authenticated encryption call with zero length data, and the authentication tag is returned in the <paramref name="pPaddingInfo"/> parameter.
        /// </param>
        /// <param name="cbOutput">
        /// The size, in bytes, of the <paramref name="pbOutput"/> buffer. This parameter is ignored if the <paramref name="pbOutput"/> parameter is NULL.
        /// </param>
        /// <param name="pcbResult">
        /// A pointer to a DWORD variable that receives the number of bytes copied to the <paramref name="pbOutput"/> buffer. If <paramref name="pbOutput"/> is NULL, this receives the size, in bytes, required for the ciphertext.
        /// </param>
        /// <param name="dwFlags">
        /// A set of flags that modify the behavior of this function. The allowed set of flags depends on the type of key specified by the hKey parameter.
        /// </param>
        /// <returns>Returns a status code that indicates the success or failure of the function.</returns>
        /// <remarks>
        /// The <paramref name="pbInput"/> and <paramref name="pbOutput"/> parameters can point to the same buffer. In this case, this function will perform the encryption in place. It is possible that the encrypted data size will be larger than the unencrypted data size, so the buffer must be large enough to hold the encrypted data.
        /// </remarks>
        [DllImport(nameof(NCrypt))]
        public static unsafe extern SECURITY_STATUS NCryptEncrypt(
            SafeKeyHandle hKey,
            byte* pbInput,
            int cbInput,
            void* pPaddingInfo,
            byte* pbOutput,
            int cbOutput,
            out int pcbResult,
            NCryptEncryptFlags dwFlags = NCryptEncryptFlags.None);

        /// <summary>
        /// Decrypts a block of data.
        /// </summary>
        /// <param name="hKey">
        /// The handle of the key to use to decrypt the data.
        /// </param>
        /// <param name="pbInput">
        /// The address of a buffer that contains the ciphertext to be decrypted. The <paramref name="cbInput"/> parameter contains the size of the ciphertext to decrypt. For more information, see Remarks.
        /// </param>
        /// <param name="cbInput">
        /// The number of bytes in the <paramref name="pbInput"/> buffer to decrypt.
        /// </param>
        /// <param name="pPaddingInfo">
        /// A pointer to a structure that contains padding information. This parameter is only used with asymmetric keys and authenticated encryption modes. If an authenticated encryption mode is used, this parameter must point to a BCRYPT_AUTHENTICATED_CIPHER_MODE_INFO structure. If asymmetric keys are used, the type of structure this parameter points to is determined by the value of the <paramref name="dwFlags"/> parameter. Otherwise, the parameter must be set to NULL.
        /// </param>
        /// <param name="pbOutput">
        /// The address of a buffer to receive the plaintext produced by this function. The cbOutput parameter contains the size of this buffer. For more information, see Remarks.
        /// If this parameter is NULL, this function calculates the size required for the plaintext of the encrypted data passed in the <paramref name="pbInput"/> parameter.In this case, the location pointed to by the <paramref name="pcbResult"/> parameter contains this size, and the function returns <see cref="NTSTATUS.Code.STATUS_SUCCESS"/>.
        /// If the values of both the <paramref name="pbOutput"/> and <paramref name="pbInput" /> parameters are NULL, an error is returned unless an authenticated encryption algorithm is in use.In the latter case, the call is treated as an authenticated encryption call with zero length data, and the authentication tag, passed in the <paramref name="pPaddingInfo"/> parameter, is verified.
        /// </param>
        /// <param name="cbOutput">
        /// The size, in bytes, of the <paramref name="pbOutput"/> buffer. This parameter is ignored if the <paramref name="pbOutput"/> parameter is NULL.
        /// </param>
        /// <param name="pcbResult">
        /// A pointer to a ULONG variable to receive the number of bytes copied to the <paramref name="pbOutput"/> buffer. If <paramref name="pbOutput"/> is NULL, this receives the size, in bytes, required for the plaintext.
        /// </param>
        /// <param name="dwFlags">
        /// A set of flags that modify the behavior of this function. The allowed set of flags depends on the type of key specified by the <paramref name="hKey"/> parameter.
        /// </param>
        /// <returns>Returns a status code that indicates the success or failure of the function.</returns>
        [DllImport(nameof(NCrypt))]
        public static unsafe extern SECURITY_STATUS NCryptDecrypt(
            SafeKeyHandle hKey,
            byte* pbInput,
            int cbInput,
            void* pPaddingInfo,
            byte* pbOutput,
            int cbOutput,
            out int pcbResult,
            NCryptEncryptFlags dwFlags);

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
