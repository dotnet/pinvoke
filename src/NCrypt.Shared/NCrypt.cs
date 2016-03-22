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
    [OfferFriendlyOverloads]
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
        /// Opens a key that exists in the specified CNG key storage provider.
        /// </summary>
        /// <param name="hProvider">The handle of the key storage provider to open the key from.</param>
        /// <param name="phKey">A pointer to a NCRYPT_KEY_HANDLE variable that receives the key handle. When you have finished using this handle, release it by calling its <see cref="SafeHandle.Dispose()"/> method.</param>
        /// <param name="pszKeyName">A pointer to a null-terminated Unicode string that contains the name of the key to retrieve.</param>
        /// <param name="dwLegacyKeySpec">A legacy identifier that specifies the type of key.</param>
        /// <param name="dwFlags">Flags that modify function behavior.</param>
        /// <returns>Returns a status code that indicates the success or failure of the function.</returns>
        [DllImport(nameof(NCrypt), CharSet = CharSet.Unicode)]
        public static extern SECURITY_STATUS NCryptOpenKey(
            SafeProviderHandle hProvider,
            out SafeKeyHandle phKey,
            string pszKeyName,
            LegacyKeySpec dwLegacyKeySpec,
            NCryptOpenKeyFlags dwFlags = NCryptOpenKeyFlags.None);

        /// <summary>
        /// Deletes a CNG key.
        /// </summary>
        /// <param name="hKey">
        /// The handle of the key to delete. This handle is obtained by using the <see cref="NCryptOpenKey(SafeProviderHandle, out SafeKeyHandle, string, LegacyKeySpec, NCryptOpenKeyFlags)"/> function.
        /// The NCryptDeleteKey function frees the handle. Applications must call <see cref="SafeHandle.SetHandleAsInvalid"/> function on it after calling the <see cref="NCryptDeleteKey(SafeKeyHandle, NCryptDeleteKeyFlags)"/> function.
        /// </param>
        /// <param name="dwFlags">Flags that modify function behavior. This can be zero or a combination of values that is specific to each key storage provider.</param>
        /// <returns>Returns a status code that indicates the success or failure of the function.</returns>
        [DllImport(nameof(NCrypt))]
        public static extern SECURITY_STATUS NCryptDeleteKey(
            SafeKeyHandle hKey,
            NCryptDeleteKeyFlags dwFlags = NCryptDeleteKeyFlags.None);

        /// <summary>
        /// Creates a secret agreement value from a private and a public key.
        /// </summary>
        /// <param name="hPrivKey">The handle of the private key to use to create the secret agreement value. This key and the <paramref name="hPubKey"/> key must come from the same key storage provider.</param>
        /// <param name="hPubKey">The handle of the public key to use to create the secret agreement value. This key and the <paramref name="hPrivKey"/> key must come from the same key storage provider.</param>
        /// <param name="phSecret">A pointer to an NCRYPT_SECRET_HANDLE variable that receives a handle that represents the secret agreement value. When this handle is no longer needed, release it by calling its <see cref="SafeHandle.Dispose()"/> method.</param>
        /// <param name="dwFlags">Flags that modify function behavior. The set of valid flags is specific to each key storage provider.</param>
        /// <returns>Returns a status code that indicates the success or failure of the function.</returns>
        [DllImport(nameof(NCrypt))]
        public static extern SECURITY_STATUS NCryptSecretAgreement(
            SafeKeyHandle hPrivKey,
            SafeKeyHandle hPubKey,
            out SafeSecretHandle phSecret,
            NCryptSecretAgreementFlags dwFlags = NCryptSecretAgreementFlags.None);

        /// <summary>
        /// Creates a key from another key by using the specified key derivation function. The function returns the key in a byte array.
        /// </summary>
        /// <param name="hKey">Handle of the key derivation function (KDF) key.</param>
        /// <param name="pParameterList">The address of a <see cref="NCryptBufferDesc"/> structure that contains the KDF parameters. The parameters can be specific to a KDF or generic. See https://msdn.microsoft.com/en-us/library/windows/desktop/hh448516(v=vs.85).aspx for more information.</param>
        /// <param name="pbDerivedKey">Address of a buffer that receives the key. The <paramref name="cbDerivedKey"/> parameter contains the size, in bytes, of the key buffer.</param>
        /// <param name="cbDerivedKey">Size, in bytes, of the buffer pointed to by the <paramref name="pbDerivedKey"/> parameter.</param>
        /// <param name="pcbResult">Pointer to a DWORD that receives the number of bytes copied to the buffer pointed to by the <paramref name="pbDerivedKey"/> parameter.</param>
        /// <param name="dwFlags">Flags that modify function behavior.</param>
        /// <returns>Returns a status code that indicates the success or failure of the function.</returns>
        [DllImport(nameof(NCrypt))]
        public static extern unsafe SECURITY_STATUS NCryptKeyDerivation(
            SafeKeyHandle hKey,
            NCryptBufferDesc* pParameterList,
            byte* pbDerivedKey,
            int cbDerivedKey,
            out int pcbResult,
            NCryptKeyDerivationFlags dwFlags = NCryptKeyDerivationFlags.None);

        /// <summary>
        /// Derives a key from a secret agreement value. This function is intended to be used as part of a secret agreement procedure using persisted secret agreement keys. To derive key material by using a persisted secret instead, use the <see cref="NCryptKeyDerivation(SafeKeyHandle, NCryptBufferDesc*, byte*, int, out int, NCryptKeyDerivationFlags)"/> function.
        /// </summary>
        /// <param name="hSharedSecret">The secret agreement handle to create the key from. This handle is obtained from the <see cref="NCryptSecretAgreement(SafeKeyHandle, SafeKeyHandle, out SafeSecretHandle, NCryptSecretAgreementFlags)"/> function.</param>
        /// <param name="pwszKDF">A pointer to a null-terminated Unicode string that identifies the key derivation function (KDF) to use to derive the key. It can be one of the strings defined in <see cref="BCrypt.KeyDerivationFunctions"/>.</param>
        /// <param name="pParameterList">The address of a <see cref="NCryptBufferDesc"/> structure that contains the KDF parameters. This parameter is optional and can be NULL if it is not needed.</param>
        /// <param name="pbDerivedKey">The address of a buffer that receives the key. The <paramref name="cbDerivedKey"/> parameter contains the size of this buffer. If this parameter is NULL, this function will place the required size, in bytes, in the DWORD pointed to by the <paramref name="pcbResult"/> parameter.</param>
        /// <param name="cbDerivedKey">The size, in bytes, of the <paramref name="pbDerivedKey"/> buffer.</param>
        /// <param name="pcbResult">A pointer to a DWORD that receives the number of bytes that were copied to the <paramref name="pbDerivedKey"/> buffer. If the <paramref name="pbDerivedKey"/> parameter is NULL, this function will place the required size, in bytes, in the DWORD pointed to by this parameter.</param>
        /// <param name="dwFlags">A set of flags that modify the behavior of this function.</param>
        /// <returns>Returns a status code that indicates the success or failure of the function.</returns>
        [DllImport(nameof(NCrypt), CharSet = CharSet.Unicode)]
        public static extern unsafe SECURITY_STATUS NCryptDeriveKey(
            SafeSecretHandle hSharedSecret,
            string pwszKDF,
            NCryptBufferDesc* pParameterList,
            byte* pbDerivedKey,
            int cbDerivedKey,
            out int pcbResult,
            NCryptDeriveKeyFlags dwFlags = NCryptDeriveKeyFlags.None);

        /// <summary>
        /// Obtains the names of the algorithms that are supported by the specified key storage provider.
        /// </summary>
        /// <param name="hProvider">The handle of the key storage provider to enumerate the algorithms for. This handle is obtained with the <see cref="NCryptOpenStorageProvider(out SafeProviderHandle, string, NCryptOpenStorageProviderFlags)"/> function.</param>
        /// <param name="dwAlgOperations">
        /// A set of values that determine which algorithm classes to enumerate. This can be zero or a combination of one or more of the values in <see cref="AlgorithmOperations"/>. If dwAlgOperations is zero, all algorithms are enumerated.
        /// </param>
        /// <param name="pdwAlgCount">The address of a DWORD that receives the number of elements in the <paramref name="ppAlgList"/> array.</param>
        /// <param name="ppAlgList">
        /// The address of an <see cref="NCryptAlgorithmName"/> structure pointer that receives an array of the registered algorithm names. The variable pointed to by the <paramref name="pdwAlgCount"/> parameter receives the number of elements in this array.
        /// When this memory is no longer needed, it must be freed by passing this pointer to the <see cref="NCryptFreeBuffer(void*)"/> function.
        /// </param>
        /// <param name="dwFlags">Flags that modify function behavior.</param>
        /// <returns>Returns a status code that indicates the success or failure of the function.</returns>
        [DllImport(nameof(NCrypt))]
        public static extern unsafe SECURITY_STATUS NCryptEnumAlgorithms(
            SafeProviderHandle hProvider,
            AlgorithmOperations dwAlgOperations,
            out int pdwAlgCount,
            out NCryptAlgorithmName* ppAlgList,
            NCryptEnumAlgorithmsFlags dwFlags = NCryptEnumAlgorithmsFlags.None);

        /// <summary>
        /// Obtains the names of the keys that are stored by the provider.
        /// </summary>
        /// <param name="hProvider">The handle of the key storage provider to enumerate the keys for. This handle is obtained with the <see cref="NCryptOpenStorageProvider(out SafeProviderHandle, string, NCryptOpenStorageProviderFlags)"/> function.</param>
        /// <param name="pszScope">This parameter is not currently used and must be NULL.</param>
        /// <param name="ppKeyName">The address of a pointer to an <see cref="NCryptKeyName"/> structure that receives the name of the retrieved key. When the application has finished using this memory, free it by calling the <see cref="NCryptFreeBuffer(void*)"/> function.</param>
        /// <param name="ppEnumState">
        /// The address of a VOID pointer that receives enumeration state information that is used in subsequent calls to this function. This information only has meaning to the key storage provider and is opaque to the caller. The key storage provider uses this information to determine which item is next in the enumeration. If the variable pointed to by this parameter contains NULL, the enumeration is started from the beginning.
        /// When this memory is no longer needed, it must be freed by passing this pointer to the <see cref="NCryptFreeBuffer(void*)"/> function.
        /// </param>
        /// <param name="dwFlags">Flags that modify function behavior.</param>
        /// <returns>
        /// Returns a status code that indicates the success or failure of the function.
        /// In particular, <see cref="SECURITY_STATUS.NTE_NO_MORE_ITEMS"/> is returned when
        /// the end of the enumeration has been reached.
        /// </returns>
        /// <remarks>
        /// This function retrieves only one item each time it is called.
        /// The state of the enumeration is stored in the variable pointed to by the <paramref name="ppEnumState"/> parameter,
        /// so this must be preserved between calls to this function.
        /// When the last key stored by the provider has been retrieved, this function will return
        /// <see cref="SECURITY_STATUS.NTE_NO_MORE_ITEMS"/> the next time it is called.
        /// To start the enumeration over, set the variable pointed to by the <paramref name="ppEnumState"/> parameter to NULL,
        /// free the memory pointed to by the <paramref name="ppKeyName"/> parameter, if it is not NULL,
        /// and call this function again.
        /// </remarks>
        [DllImport(nameof(NCrypt), CharSet = CharSet.Unicode)]
        public static extern unsafe SECURITY_STATUS NCryptEnumKeys(
            SafeProviderHandle hProvider,
            string pszScope,
            out NCryptKeyName* ppKeyName,
            ref void* ppEnumState,
            NCryptEnumKeysFlags dwFlags = NCryptEnumKeysFlags.None);

        /// <summary>
        /// Determines if a CNG key storage provider supports a specific cryptographic algorithm.
        /// </summary>
        /// <param name="hProvider">The handle of the key storage provider. This handle is obtained with the <see cref="NCryptOpenStorageProvider(out SafeProviderHandle, string, NCryptOpenStorageProviderFlags)"/> function.</param>
        /// <param name="pszAlgId">
        /// A pointer to a null-terminated Unicode string that identifies the cryptographic algorithm in question.
        /// Typical values for this argument are defined in <see cref="BCrypt.AlgorithmIdentifiers"/>.
        /// </param>
        /// <param name="dwFlags">Flags that modify function behavior.</param>
        /// <returns>Returns a status code that indicates the success or failure of the function.</returns>
        [DllImport(nameof(NCrypt), CharSet = CharSet.Unicode)]
        public static extern SECURITY_STATUS NCryptIsAlgSupported(
            SafeProviderHandle hProvider,
            string pszAlgId,
            NCryptIsAlgSupportedFlags dwFlags = NCryptIsAlgSupportedFlags.None);

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
        /// Imports a Cryptography API: Next Generation (CNG) key from a memory BLOB.
        /// </summary>
        /// <param name="hProvider">The handle of the key storage provider.</param>
        /// <param name="hImportKey">
        /// The handle of the cryptographic key with which the key data within the imported key BLOB was encrypted. This must be a handle to the same key that was passed in the hExportKey parameter of the NCryptExportKey function. If this parameter is NULL, the key BLOB is assumed to not be encrypted.
        /// </param>
        /// <param name="pszBlobType">
        /// A null-terminated Unicode string that contains an identifier that specifies the format of the key BLOB. These formats are specific to a particular key storage provider. Commonly a value from <see cref="AsymmetricKeyBlobTypes"/> or <see cref="SymmetricKeyBlobTypes"/>.
        /// </param>
        /// <param name="pParameterList">
        /// The address of an <see cref="NCryptBufferDesc"/> structure that points to an array of buffers that contain parameter information for the key.
        /// </param>
        /// <param name="phKey">
        /// The address of an NCRYPT_KEY_HANDLE variable that receives the handle of the key. When you have finished using this handle, release it by calling <see cref="SafeHandle.Dispose()"/> on the value.
        /// </param>
        /// <param name="pbData">The address of a buffer that contains the key BLOB to be imported. The <paramref name="cbData"/> parameter contains the size of this buffer.</param>
        /// <param name="cbData">The size, in bytes, of the <paramref name="pbData"/> buffer.</param>
        /// <param name="dwFlags">Flags that modify function behavior.</param>
        /// <returns>Returns a status code that indicates the success or failure of the function.</returns>
        /// <remarks>
        /// If a key name is not supplied, the Microsoft Software KSP treats the key as ephemeral and does not store it persistently. For the NCRYPT_OPAQUETRANSPORT_BLOB type, the key name is stored within the BLOB when it is exported. For other BLOB formats, the name can be supplied in an NCRYPTBUFFER_PKCS_KEY_NAME buffer parameter within the pParameterList parameter.
        /// On Windows Server 2008 and Windows Vista, only keys imported as PKCS #7 envelope BLOBs (NCRYPT_PKCS7_ENVELOPE_BLOB) or PKCS #8 private key BLOBs (NCRYPT_PKCS8_PRIVATE_KEY_BLOB) can be persisted by using the above method. To persist keys imported through other BLOB types on these platforms, use the method documented in Key Import and Export.
        /// </remarks>
        [DllImport(nameof(NCrypt), CharSet = CharSet.Unicode)]
        public static extern unsafe SECURITY_STATUS NCryptImportKey(
            SafeProviderHandle hProvider,
            SafeKeyHandle hImportKey,
            string pszBlobType,
            NCryptBufferDesc* pParameterList,
            out SafeKeyHandle phKey,
            byte* pbData,
            int cbData,
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
        /// Creates a signature of a hash value.
        /// </summary>
        /// <param name="hKey">The handle of the key to use to sign the hash.</param>
        /// <param name="pPaddingInfo">
        /// A pointer to a structure that contains padding information. The actual type of structure this parameter points to depends on the value of the <paramref name="dwFlags"/> parameter. This parameter is only used with asymmetric keys and must be NULL otherwise.
        /// </param>
        /// <param name="pbHashValue">
        /// A pointer to a buffer that contains the hash value to sign. The <paramref name="cbHashValue"/> parameter contains the size of this buffer.
        /// </param>
        /// <param name="cbHashValue">
        /// The number of bytes in the <paramref name="pbHashValue"/> buffer to sign.
        /// </param>
        /// <param name="pbSignature">
        /// The address of a buffer to receive the signature produced by this function. The <paramref name="cbSignature"/> parameter contains the size of this buffer.
        /// If this parameter is NULL, this function will calculate the size required for the signature and return the size in the location pointed to by the <paramref name="pcbResult"/> parameter.
        /// </param>
        /// <param name="cbSignature">
        /// The size, in bytes, of the <paramref name="pbSignature"/> buffer. This parameter is ignored if the <paramref name="pbSignature"/> parameter is NULL.
        /// </param>
        /// <param name="pcbResult">
        /// A pointer to a ULONG variable that receives the number of bytes copied to the <paramref name="pbSignature"/> buffer.
        /// If <paramref name="pbSignature"/> is NULL, this receives the size, in bytes, required for the signature.
        /// </param>
        /// <param name="dwFlags">
        /// A set of flags that modify the behavior of this function. The allowed set of flags depends on the type of key specified by the <paramref name="hKey"/> parameter.
        /// </param>
        /// <returns>Returns a status code that indicates the success or failure of the function.</returns>
        /// <remarks>
        /// To later verify that the signature is valid, call the <see cref="NCryptVerifySignature(SafeKeyHandle, void*, byte*, int, byte*, int, NCryptSignHashFlags)"/> function with an identical key and an identical hash of the original data.
        /// </remarks>
        [DllImport(nameof(NCrypt))]
        public static unsafe extern SECURITY_STATUS NCryptSignHash(
            SafeKeyHandle hKey,
            void* pPaddingInfo,
            byte* pbHashValue,
            int cbHashValue,
            byte* pbSignature,
            int cbSignature,
            out int pcbResult,
            NCryptSignHashFlags dwFlags);

        /// <summary>
        /// Verifies that the specified signature matches the specified hash.
        /// </summary>
        /// <param name="hKey">
        /// The handle of the key to use to decrypt the signature. This must be an identical key or the public key portion of the key pair used to sign the data with the <see cref="NCryptSignHash(SafeKeyHandle, void*, byte*, int, byte*, int, out int, NCryptSignHashFlags)"/> function.
        /// </param>
        /// <param name="pPaddingInfo">
        /// A pointer to a structure that contains padding information. The actual type of structure this parameter points to depends on the value of the <paramref name="dwFlags"/> parameter. This parameter is only used with asymmetric keys and must be NULL otherwise.
        /// </param>
        /// <param name="pbHashValue">
        /// The address of a buffer that contains the hash of the data. The <paramref name="cbHashValue"/> parameter contains the size of this buffer.
        /// </param>
        /// <param name="cbHashValue">
        /// The size, in bytes, of the <paramref name="pbHashValue"/> buffer.
        /// </param>
        /// <param name="pbSignature">
        /// The address of a buffer that contains the signed hash of the data. The <see cref="NCryptSignHash(SafeKeyHandle, void*, byte*, int, byte*, int, out int, NCryptSignHashFlags)"/> function is used to create the signature. The <paramref name="cbSignature"/> parameter contains the size of this buffer.
        /// </param>
        /// <param name="cbSignature">
        /// The size, in bytes, of the <paramref name="pbSignature"/> buffer. The <see cref="NCryptSignHash(SafeKeyHandle, void*, byte*, int, byte*, int, out int, NCryptSignHashFlags)"/> function is used to create the signature.
        /// </param>
        /// <param name="dwFlags">
        /// A set of flags that modify the behavior of this function. The allowed set of flags depends on the type of key specified by the hKey parameter.
        /// If the key is a symmetric key, this parameter is not used and should be zero.
        /// If the key is an asymmetric key, this can be one of the following values.
        /// </param>
        /// <returns>
        /// Returns a status code that indicates the success or failure of the function.
        /// In particular, an invalid signature will produce a <see cref="SECURITY_STATUS.NTE_BAD_SIGNATURE"/> result.
        /// </returns>
        [DllImport(nameof(NCrypt))]
        public static unsafe extern SECURITY_STATUS NCryptVerifySignature(
            SafeKeyHandle hKey,
            void* pPaddingInfo,
            byte* pbHashValue,
            int cbHashValue,
            byte* pbSignature,
            int cbSignature,
            NCryptSignHashFlags dwFlags = NCryptSignHashFlags.None);

        /// <summary>
        /// Releases a block of memory allocated by a CNG key storage provider.
        /// </summary>
        /// <param name="pvInput">The address of the memory to be released.</param>
        /// <returns>Returns a status code that indicates the success or failure of the function.</returns>
        [DllImport(nameof(NCrypt))]
        public static extern unsafe SECURITY_STATUS NCryptFreeBuffer(void* pvInput);

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
