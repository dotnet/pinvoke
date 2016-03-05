// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Runtime.InteropServices;

    /// <summary>
    /// Exported functions from the BCrypt.dll Windows library
    /// that are available to Desktop and Store apps.
    /// </summary>
    [OfferFriendlyOverloads]
    public static partial class BCrypt
    {
        /// <summary>
        /// The BCryptEnumAlgorithms function gets a list of the registered algorithm identifiers.
        /// </summary>
        /// <param name="dwAlgOperations">A value that specifies the algorithm operation types to include in the enumeration.</param>
        /// <param name="pAlgCount">A pointer to a ULONG variable to receive the number of elements in the <paramref name="ppAlgList"/> array.</param>
        /// <param name="ppAlgList">
        /// The address of a <see cref="BCRYPT_ALGORITHM_IDENTIFIER"/> structure pointer to receive the array of registered algorithm identifiers. This pointer must be passed to the <see cref="BCryptFreeBuffer(void*)"/> function when it is no longer needed.
        /// </param>
        /// <param name="dwFlags">A set of flags that modify the behavior of this function.</param>
        /// <returns>Returns a status code that indicates the success or failure of the function.</returns>
        [DllImport(nameof(BCrypt), SetLastError = true)]
        public static extern unsafe NTSTATUS BCryptEnumAlgorithms(
            AlgorithmOperations dwAlgOperations,
            out int pAlgCount,
            out BCRYPT_ALGORITHM_IDENTIFIER* ppAlgList,
            BCryptEnumAlgorithmsFlags dwFlags = BCryptEnumAlgorithmsFlags.None);

        /// <summary>
        /// Loads and initializes a CNG provider.
        /// </summary>
        /// <param name="phAlgorithm">
        /// A pointer to a BCRYPT_ALG_HANDLE variable that receives the CNG provider handle.
        /// When you have finished using this handle, release it by passing it to the
        /// BCryptCloseAlgorithmProvider function.
        /// </param>
        /// <param name="pszAlgId">
        /// A pointer to a null-terminated Unicode string that identifies the requested
        /// cryptographic algorithm. This can be one of the standard
        /// CNG Algorithm Identifiers defined in <see cref="AlgorithmIdentifiers"/>
        /// or the identifier for another registered algorithm.
        /// </param>
        /// <param name="pszImplementation">
        /// <para>
        /// A pointer to a null-terminated Unicode string that identifies the specific provider
        /// to load. This is the registered alias of the cryptographic primitive provider.
        /// This parameter is optional and can be NULL if it is not needed. If this parameter
        /// is NULL, the default provider for the specified algorithm will be loaded.
        /// </para>
        /// <para>
        /// Note If the <paramref name="pszImplementation"/> parameter value is NULL, CNG attempts to open each
        /// registered provider, in order of priority, for the algorithm specified by the
        /// <paramref name="pszAlgId"/> parameter and returns the handle of the first provider that is successfully
        /// opened.For the lifetime of the handle, any BCrypt*** cryptographic APIs will use the
        /// provider that was successfully opened.
        /// </para>
        /// </param>
        /// <param name="dwFlags">Options for the function.</param>
        /// <returns>
        /// Returns a status code that indicates the success or failure of the function.
        /// </returns>
        [DllImport(nameof(BCrypt), SetLastError = true, CharSet = CharSet.Unicode, ExactSpelling = true)]
        public static extern NTSTATUS BCryptOpenAlgorithmProvider(
            out SafeAlgorithmHandle phAlgorithm,
            string pszAlgId,
            string pszImplementation,
            BCryptOpenAlgorithmProviderFlags dwFlags);

        /// <summary>
        /// Create a hash or Message Authentication Code (MAC) object.
        /// </summary>
        /// <param name="hAlgorithm">
        /// The handle of an algorithm provider created by using the <see cref="BCryptOpenAlgorithmProvider(string, string, BCryptOpenAlgorithmProviderFlags)"/> function. The algorithm that was specified when the provider was created must support the hash interface.
        /// </param>
        /// <param name="phHash">
        /// A pointer to a <see cref="SafeHashHandle"/> value that receives a handle that represents the hash or MAC object. This handle is used in subsequent hashing or MAC functions, such as the <see cref="BCryptHashData"/> function. When you have finished using this handle, release it by passing it to the <see cref="BCryptDestroyHash"/> function.
        /// </param>
        /// <param name="pbHashObject">
        /// A pointer to a buffer that receives the hash or MAC object. The <paramref name="cbHashObject"/> parameter contains the size of this buffer. The required size of this buffer can be obtained by calling the <see cref="BCryptGetProperty(SafeHandle, string, BCryptGetPropertyFlags)"/> function to get the <see cref="PropertyNames.BCRYPT_OBJECT_LENGTH"/> property. This will provide the size of the hash or MAC object for the specified algorithm.
        /// This memory can only be freed after the handle pointed to by the <paramref name="phHash"/> parameter is destroyed.
        /// If the value of this parameter is NULL and the value of the <paramref name="cbHashObject"/> parameter is zero, the memory for the hash object is allocated and freed by this function.
        /// Windows 7:  This memory management functionality is available beginning with Windows 7.
        /// </param>
        /// <param name="cbHashObject">
        /// The size, in bytes, of the <paramref name="pbHashObject"/> buffer.
        /// If the value of this parameter is zero and the value of the <paramref name="pbHashObject"/> parameter is NULL, the memory for the key object is allocated and freed by this function.
        /// Windows 7:  This memory management functionality is available beginning with Windows 7.
        /// </param>
        /// <param name="pbSecret">
        /// A pointer to a buffer that contains the key to use for the hash or MAC. The <paramref name="cbSecret"/> parameter contains the size of this buffer. This key only applies to hash algorithms opened by the BCryptOpenAlgorithmProvider function by using the <see cref="BCryptOpenAlgorithmProviderFlags.AlgorithmHandleHmac"/> flag. Otherwise, set this parameter to NULL.
        /// </param>
        /// <param name="cbSecret">
        /// The size, in bytes, of the <paramref name="pbSecret"/> buffer. If no key is used, set this parameter to zero.
        /// </param>
        /// <param name="dwFlags">Flags that modify the behavior of the function.</param>
        /// <returns>Returns a status code that indicates the success or failure of the function.</returns>
        [DllImport(nameof(BCrypt), SetLastError = true)]
        public static extern NTSTATUS BCryptCreateHash(
            SafeAlgorithmHandle hAlgorithm,
            out SafeHashHandle phHash,
            byte[] pbHashObject,
            int cbHashObject,
            byte[] pbSecret,
            int cbSecret,
            BCryptCreateHashFlags dwFlags);

        /// <summary>
        /// Encrypts a block of data.
        /// </summary>
        /// <param name="hKey">
        /// The handle of the key to use to encrypt the data. This handle is obtained from one of the key creation functions, such as <see cref="BCryptGenerateSymmetricKey(SafeAlgorithmHandle, byte[], byte[], BCryptGenerateSymmetricKeyFlags)"/>, <see cref="BCryptGenerateKeyPair(SafeAlgorithmHandle, int)"/>, or <see cref="BCryptImportKey(SafeAlgorithmHandle, string, byte[], SafeKeyHandle, byte[], BCryptImportKeyFlags)"/>.
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
        /// <param name="pbIV">
        /// The address of a buffer that contains the initialization vector (IV) to use during encryption. The cbIV parameter contains the size of this buffer. This function will modify the contents of this buffer. If you need to reuse the IV later, make sure you make a copy of this buffer before calling this function.
        /// This parameter is optional and can be NULL if no IV is used.
        /// The required size of the IV can be obtained by calling the <see cref="BCryptGetProperty(SafeHandle, string, BCryptGetPropertyFlags)"/> function to get the BCRYPT_BLOCK_LENGTH property.This will provide the size of a block for the algorithm, which is also the size of the IV.
        /// </param>
        /// <param name="cbIV">The size, in bytes, of the pbIV buffer.</param>
        /// <param name="pbOutput">
        /// The address of the buffer that receives the ciphertext produced by this function. The <paramref name="cbOutput"/> parameter contains the size of this buffer. For more information, see Remarks.
        /// If this parameter is NULL, the <see cref="BCryptEncrypt(SafeKeyHandle, byte[], void*, byte[], BCryptEncryptFlags)"/> function calculates the size needed for the ciphertext of the data passed in the <paramref name="pbInput"/> parameter. In this case, the location pointed to by the <paramref name="pcbResult"/> parameter contains this size, and the function returns <see cref="NTSTATUS.Code.STATUS_SUCCESS"/>.The <paramref name="pPaddingInfo"/> parameter is not modified.
        /// If the values of both the <paramref name="pbOutput"/> and <paramref name="pbInput"/> parameters are NULL, an error is returned unless an authenticated encryption algorithm is in use.In the latter case, the call is treated as an authenticated encryption call with zero length data, and the authentication tag is returned in the <paramref name="pPaddingInfo"/> parameter.
        /// </param>
        /// <param name="cbOutput">
        /// The size, in bytes, of the <paramref name="pbOutput"/> buffer. This parameter is ignored if the <paramref name="pbOutput"/> parameter is NULL.
        /// </param>
        /// <param name="pcbResult">
        /// A pointer to a ULONG variable that receives the number of bytes copied to the <paramref name="pbOutput"/> buffer. If <paramref name="pbOutput"/> is NULL, this receives the size, in bytes, required for the ciphertext.
        /// </param>
        /// <param name="dwFlags">
        /// A set of flags that modify the behavior of this function. The allowed set of flags depends on the type of key specified by the hKey parameter.
        /// </param>
        /// <returns>Returns a status code that indicates the success or failure of the function.</returns>
        /// <remarks>
        /// The <paramref name="pbInput"/> and <paramref name="pbOutput"/> parameters can point to the same buffer. In this case, this function will perform the encryption in place. It is possible that the encrypted data size will be larger than the unencrypted data size, so the buffer must be large enough to hold the encrypted data.
        /// </remarks>
        [DllImport(nameof(BCrypt), SetLastError = true)]
        public static unsafe extern NTSTATUS BCryptEncrypt(
            SafeKeyHandle hKey,
            byte* pbInput,
            int cbInput,
            void* pPaddingInfo,
            byte* pbIV,
            int cbIV,
            byte* pbOutput,
            int cbOutput,
            out int pcbResult,
            BCryptEncryptFlags dwFlags);

        /// <summary>
        /// Decrypts a block of data.
        /// </summary>
        /// <param name="hKey">
        /// The handle of the key to use to decrypt the data. This handle is obtained from one of the key creation functions, such as <see cref="BCryptGenerateSymmetricKey(SafeAlgorithmHandle, byte[], byte[], BCryptGenerateSymmetricKeyFlags)"/>, <see cref="BCryptGenerateKeyPair(SafeAlgorithmHandle, int)"/>, or <see cref="BCryptImportKey(SafeAlgorithmHandle, string, byte[], SafeKeyHandle, byte[], BCryptImportKeyFlags)"/>.
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
        /// <param name="pbIV">
        /// The address of a buffer that contains the initialization vector (IV) to use during decryption. The <paramref name="cbIV"/> parameter contains the size of this buffer. This function will modify the contents of this buffer. If you need to reuse the IV later, make sure you make a copy of this buffer before calling this function.
        /// This parameter is optional and can be NULL if no IV is used.
        /// The required size of the IV can be obtained by calling the <see cref="BCryptGetProperty(SafeHandle, string, BCryptGetPropertyFlags)"/> function to get the <see cref="PropertyNames.BCRYPT_BLOCK_LENGTH"/> property. This will provide the size of a block for the algorithm, which is also the size of the IV.
        /// </param>
        /// <param name="cbIV">
        /// The size, in bytes, of the <paramref name="pbIV"/> buffer.
        /// </param>
        /// <param name="pbOutput">
        /// The address of a buffer to receive the plaintext produced by this function. The cbOutput parameter contains the size of this buffer. For more information, see Remarks.
        /// If this parameter is NULL, the <see cref="BCryptDecrypt(SafeKeyHandle, byte[], void*, byte[], BCryptEncryptFlags)"/> function calculates the size required for the plaintext of the encrypted data passed in the <paramref name="pbInput"/> parameter.In this case, the location pointed to by the <paramref name="pcbResult"/> parameter contains this size, and the function returns <see cref="NTSTATUS.Code.STATUS_SUCCESS"/>.
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
        [DllImport(nameof(BCrypt), SetLastError = true)]
        public static unsafe extern NTSTATUS BCryptDecrypt(
            SafeKeyHandle hKey,
            byte* pbInput,
            int cbInput,
            void* pPaddingInfo,
            byte* pbIV,
            int cbIV,
            byte* pbOutput,
            int cbOutput,
            out int pcbResult,
            BCryptEncryptFlags dwFlags);

        /// <summary>
        /// Performs a one way hash or Message Authentication Code (MAC) on a data buffer.
        /// </summary>
        /// <param name="hHash">
        /// The handle of the hash or MAC object to use to perform the operation. This handle is obtained by calling the <see cref="BCryptCreateHash(SafeAlgorithmHandle, out SafeHashHandle, byte[], int, byte[], int, BCryptCreateHashFlags)"/> function.
        /// </param>
        /// <param name="pbInput">
        /// A pointer to a buffer that contains the data to process. The <paramref name="cbInput"/> parameter contains the number of bytes in this buffer. This function does not modify the contents of this buffer.
        /// </param>
        /// <param name="cbInput">The number of bytes in the <paramref name="pbInput"/> buffer.</param>
        /// <param name="dwFlags">A set of flags that modify the behavior of this function.</param>
        /// <returns>Returns a status code that indicates the success or failure of the function.</returns>
        /// <remarks>
        /// To combine more than one buffer into the hash or MAC, you can call this function multiple times, passing a different buffer each time. To obtain the hash or MAC value, call the <see cref="BCryptFinishHash(SafeHashHandle, byte[], int, BCryptFinishHashFlags)"/> function.
        /// After the <see cref="BCryptFinishHash(SafeHashHandle, byte[], int, BCryptFinishHashFlags)"/> function has been called for a specified handle, that handle cannot be reused.
        /// </remarks>
        [DllImport(nameof(BCrypt), SetLastError = true)]
        public static extern NTSTATUS BCryptHashData(
            SafeHashHandle hHash,
            byte[] pbInput,
            int cbInput,
            BCryptHashDataFlags dwFlags = BCryptHashDataFlags.None);

        /// <summary>
        /// Retrieves the hash or Message Authentication Code (MAC) value for the data accumulated from prior calls to <see cref="BCryptHashData(SafeHashHandle, byte[], int, BCryptHashDataFlags)"/>.
        /// </summary>
        /// <param name="hHash">
        /// The handle of the hash or MAC object to use to compute the hash or MAC. This handle is obtained by calling the <see cref="BCryptCreateHash(SafeAlgorithmHandle, byte[], byte[], BCryptCreateHashFlags)"/> function. After this function has been called, the hash handle passed to this function cannot be used again except in a call to <see cref="BCryptDestroyHash"/>.
        /// </param>
        /// <param name="pbOutput">
        /// A pointer to a buffer that receives the hash or MAC value. The <paramref name="cbOutput"/> parameter contains the size of this buffer.
        /// </param>
        /// <param name="cbOutput">
        /// The size, in bytes, of the <paramref name="pbOutput"/> buffer. This size must exactly match the size of the hash or MAC value.
        /// The size can be obtained by calling the <see cref="BCryptGetProperty(SafeHandle, string, BCryptGetPropertyFlags)"/> function to get the <see cref="PropertyNames.BCRYPT_HASH_LENGTH"/> property. This will provide the size of the hash or MAC value for the specified algorithm.
        /// </param>
        /// <param name="dwFlags">A set of flags that modify the behavior of this function.</param>
        /// <returns>Returns a status code that indicates the success or failure of the function.</returns>
        [DllImport(nameof(BCrypt), SetLastError = true)]
        public static extern NTSTATUS BCryptFinishHash(
            SafeHashHandle hHash,
            [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] byte[] pbOutput,
            int cbOutput,
            BCryptFinishHashFlags dwFlags = BCryptFinishHashFlags.None);

        /// <summary>
        /// Creates a signature of a hash value.
        /// </summary>
        /// <param name="hKey">The handle of the key to use to sign the hash.</param>
        /// <param name="pPaddingInfo">
        /// A pointer to a structure that contains padding information. The actual type of structure this parameter points to depends on the value of the <paramref name="dwFlags"/> parameter. This parameter is only used with asymmetric keys and must be NULL otherwise.
        /// </param>
        /// <param name="pbInput">
        /// A pointer to a buffer that contains the hash value to sign. The <paramref name="cbInput"/> parameter contains the size of this buffer.
        /// </param>
        /// <param name="cbInput">
        /// The number of bytes in the <paramref name="pbInput"/> buffer to sign.
        /// </param>
        /// <param name="pbOutput">
        /// The address of a buffer to receive the signature produced by this function. The <paramref name="cbOutput"/> parameter contains the size of this buffer.
        /// If this parameter is NULL, this function will calculate the size required for the signature and return the size in the location pointed to by the <paramref name="pcbResult"/> parameter.
        /// </param>
        /// <param name="cbOutput">
        /// The size, in bytes, of the <paramref name="pbOutput"/> buffer. This parameter is ignored if the <paramref name="pbOutput"/> parameter is NULL.
        /// </param>
        /// <param name="pcbResult">
        /// A pointer to a ULONG variable that receives the number of bytes copied to the <paramref name="pbOutput"/> buffer.
        /// If <paramref name="pbOutput"/> is NULL, this receives the size, in bytes, required for the signature.
        /// </param>
        /// <param name="dwFlags">
        /// A set of flags that modify the behavior of this function. The allowed set of flags depends on the type of key specified by the <paramref name="hKey"/> parameter.
        /// </param>
        /// <returns>Returns a status code that indicates the success or failure of the function.</returns>
        /// <remarks>
        /// To later verify that the signature is valid, call the <see cref="BCryptVerifySignature(SafeKeyHandle, void*, byte[], int, byte[], int, BCryptSignHashFlags)"/> function with an identical key and an identical hash of the original data.
        /// </remarks>
        [DllImport(nameof(BCrypt), SetLastError = true)]
        public static unsafe extern NTSTATUS BCryptSignHash(
            SafeKeyHandle hKey,
            void* pPaddingInfo,
            byte[] pbInput,
            int cbInput,
            [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 6)] byte[] pbOutput,
            int cbOutput,
            out int pcbResult,
            BCryptSignHashFlags dwFlags);

        /// <summary>
        /// Verifies that the specified signature matches the specified hash.
        /// </summary>
        /// <param name="hKey">
        /// The handle of the key to use to decrypt the signature. This must be an identical key or the public key portion of the key pair used to sign the data with the <see cref="BCryptSignHash(SafeKeyHandle, byte[], void*, BCryptSignHashFlags)"/> function.
        /// </param>
        /// <param name="pPaddingInfo">
        /// A pointer to a structure that contains padding information. The actual type of structure this parameter points to depends on the value of the <paramref name="dwFlags"/> parameter. This parameter is only used with asymmetric keys and must be NULL otherwise.
        /// </param>
        /// <param name="pbHash">
        /// The address of a buffer that contains the hash of the data. The <paramref name="cbHash"/> parameter contains the size of this buffer.
        /// </param>
        /// <param name="cbHash">
        /// The size, in bytes, of the <paramref name="pbHash"/> buffer.
        /// </param>
        /// <param name="pbSignature">
        /// The address of a buffer that contains the signed hash of the data. The <see cref="BCryptSignHash(SafeKeyHandle, byte[], void*, BCryptSignHashFlags)"/> function is used to create the signature. The <paramref name="cbSignature"/> parameter contains the size of this buffer.
        /// </param>
        /// <param name="cbSignature">
        /// The size, in bytes, of the <paramref name="pbSignature"/> buffer. The <see cref="BCryptSignHash(SafeKeyHandle, byte[], void*, BCryptSignHashFlags)"/> function is used to create the signature.
        /// </param>
        /// <param name="dwFlags">
        /// A set of flags that modify the behavior of this function. The allowed set of flags depends on the type of key specified by the hKey parameter.
        /// If the key is a symmetric key, this parameter is not used and should be zero.
        /// If the key is an asymmetric key, this can be one of the following values.
        /// </param>
        /// <returns>
        /// Returns a status code that indicates the success or failure of the function.
        /// In particular, an invalid signature will produce a <see cref="NTSTATUS.Code.STATUS_INVALID_SIGNATURE"/> result.
        /// </returns>
        [DllImport(nameof(BCrypt), SetLastError = true)]
        public static unsafe extern NTSTATUS BCryptVerifySignature(
            SafeKeyHandle hKey,
            void* pPaddingInfo,
            byte[] pbHash,
            int cbHash,
            byte[] pbSignature,
            int cbSignature,
            BCryptSignHashFlags dwFlags = BCryptSignHashFlags.None);

        /// <summary>
        /// Creates an empty public/private key pair.
        /// </summary>
        /// <param name="hAlgorithm">The handle to the algorithm previously opened by <see cref="BCryptOpenAlgorithmProvider(string, string, BCryptOpenAlgorithmProviderFlags)"/></param>
        /// <param name="phKey">Receives a handle to the generated key pair.</param>
        /// <param name="dwLength">The length of the key, in bits.</param>
        /// <param name="dwFlags">A set of flags that modify the behavior of this function. No flags are currently defined, so this parameter should be zero.</param>
        /// <returns>Returns a status code that indicates the success or failure of the function.</returns>
        /// <remarks>
        /// After you create a key by using this function, you can use the BCryptSetProperty
        /// function to set its properties; however, the key cannot be used until the
        /// BCryptFinalizeKeyPair function is called.
        /// </remarks>
        [DllImport(nameof(BCrypt), SetLastError = true, ExactSpelling = true)]
        public static extern NTSTATUS BCryptGenerateKeyPair(
            SafeAlgorithmHandle hAlgorithm,
            out SafeKeyHandle phKey,
            int dwLength,
            BCryptGenerateKeyPairFlags dwFlags = BCryptGenerateKeyPairFlags.None);

        /// <summary>
        /// Creates a key object for use with a symmetrical key encryption algorithm from a supplied key.
        /// </summary>
        /// <param name="hAlgorithm">
        /// The handle of an algorithm provider created with the <see cref="BCryptOpenAlgorithmProvider(string, string, BCryptOpenAlgorithmProviderFlags)"/> function. The algorithm specified when the provider was created must support symmetric key encryption.
        /// </param>
        /// <param name="phKey">
        /// Receives the <see cref="SafeKeyHandle"/> of the generated key.
        /// </param>
        /// <param name="pbKeyObject">
        /// A pointer to a buffer that receives the key object. The <paramref name="cbKeyObject"/> parameter contains the size of this buffer. The required size of this buffer can be obtained by calling the <see cref="BCryptGetProperty(SafeHandle, string, BCryptGetPropertyFlags)"/> function to get the BCRYPT_OBJECT_LENGTH property. This will provide the size of the key object for the specified algorithm.
        /// This memory can only be freed after the <paramref name="phKey"/> key handle is destroyed.
        /// If the value of this parameter is NULL and the value of the <paramref name="cbKeyObject"/> parameter is zero, the memory for the key object is allocated and freed by this function.
        /// </param>
        /// <param name="cbKeyObject">
        /// The size, in bytes, of the <paramref name="pbKeyObject"/> buffer.
        /// If the value of this parameter is zero and the value of the <paramref name="pbKeyObject"/> parameter is NULL, the memory for the key object is allocated and freed by this function.
        /// </param>
        /// <param name="pbSecret">
        /// Pointer to a buffer that contains the key from which to create the key object. The <paramref name="cbSecret"/> parameter contains the size of this buffer. This is normally a hash of a password or some other reproducible data. If the data passed in exceeds the target key size, the data will be truncated and the excess will be ignored.
        /// Note: We strongly recommended that applications pass in the exact number of bytes required by the target key.
        /// </param>
        /// <param name="cbSecret">
        /// The size, in bytes, of the <paramref name="pbSecret"/> buffer.
        /// </param>
        /// <param name="flags">A set of flags that modify the behavior of this function. No flags are currently defined, so this parameter should be zero.</param>
        /// <returns>Returns a status code that indicates the success or failure of the function.</returns>
        [DllImport(nameof(BCrypt), SetLastError = true)]
        public static extern NTSTATUS BCryptGenerateSymmetricKey(
            SafeAlgorithmHandle hAlgorithm,
            out SafeKeyHandle phKey,
            byte[] pbKeyObject,
            int cbKeyObject,
            byte[] pbSecret,
            int cbSecret,
            BCryptGenerateSymmetricKeyFlags flags = BCryptGenerateSymmetricKeyFlags.None);

        /// <summary>
        /// Completes a public/private key pair.
        /// </summary>
        /// <param name="hKey">The handle of the key to complete. This handle is obtained by calling the BCryptGenerateKeyPair function.</param>
        /// <param name="dwFlags">A set of flags that modify the behavior of this function. No flags are currently defined, so this parameter should be zero.</param>
        /// <returns>Returns a status code that indicates the success or failure of the function.</returns>
        /// <remarks>
        /// The key cannot be used until this function has been called.
        /// After this function has been called, the BCryptSetProperty function
        /// can no longer be used for this key.
        /// </remarks>
        [DllImport(nameof(BCrypt), SetLastError = true, ExactSpelling = true)]
        public static extern NTSTATUS BCryptFinalizeKeyPair(
            SafeKeyHandle hKey,
            BCryptFinalizeKeyPairFlags dwFlags = BCryptFinalizeKeyPairFlags.None);

        /// <summary>
        /// Imports a symmetric key from a key BLOB. The BCryptImportKeyPair function is used to import a public/private key pair.
        /// </summary>
        /// <param name="hAlgorithm">
        /// The handle of the algorithm provider to import the key. This handle is obtained by calling the <see cref="BCryptOpenAlgorithmProvider(string, string, BCryptOpenAlgorithmProviderFlags)"/> function.
        /// </param>
        /// <param name="hImportKey">
        /// The handle of the key encryption key needed to unwrap the key BLOB in the pbInput parameter.
        /// Note The handle must be supplied by the same provider that supplied the key that is being imported.
        /// </param>
        /// <param name="pszBlobType">
        /// An identifier that specifies the type of BLOB that is contained in the pbInput buffer.
        /// This can be one of the values defined in <see cref="SymmetricKeyBlobTypes"/>.
        /// </param>
        /// <param name="phKey">
        /// A pointer to a BCRYPT_KEY_HANDLE that receives the handle of the imported key. This handle is used in subsequent functions that require a key, such as BCryptEncrypt. This handle must be released when it is no longer needed by passing it to the <see cref="BCryptDestroyKey"/> function.
        /// </param>
        /// <param name="pbKeyObject">
        /// A pointer to a buffer that receives the imported key object.
        /// The <paramref name="cbKeyObject"/> parameter contains the size of this buffer.
        /// The required size of this buffer can be obtained by calling the <see cref="BCryptGetProperty(SafeHandle, string, BCryptGetPropertyFlags)"/>
        /// function to get the <see cref="PropertyNames.BCRYPT_OBJECT_LENGTH"/> property. This will provide the size of the
        /// key object for the specified algorithm.
        /// This memory can only be freed after the phKey key handle is destroyed.
        /// </param>
        /// <param name="cbKeyObject">The size, in bytes, of the <paramref name="pbKeyObject"/> buffer.</param>
        /// <param name="pbInput">
        /// The address of a buffer that contains the key BLOB to import.
        /// The <paramref name="cbInput"/> parameter contains the size of this buffer.
        /// The <paramref name="pszBlobType"/> parameter specifies the type of key BLOB this buffer contains.
        /// </param>
        /// <param name="cbInput">
        /// The size, in bytes, of the <paramref name="pbInput" /> buffer.
        /// </param>
        /// <param name="dwFlags">A set of flags that modify the behavior of this function.</param>
        /// <returns>Returns a status code that indicates the success or failure of the function.</returns>
        [DllImport(nameof(BCrypt), SetLastError = true, ExactSpelling = true, CharSet = CharSet.Unicode)]
        public static extern NTSTATUS BCryptImportKey(
            SafeAlgorithmHandle hAlgorithm,
            SafeKeyHandle hImportKey,
            [MarshalAs(UnmanagedType.LPWStr)] string pszBlobType,
            out SafeKeyHandle phKey,
            byte[] pbKeyObject,
            int cbKeyObject,
            byte[] pbInput,
            int cbInput,
            BCryptImportKeyFlags dwFlags = BCryptImportKeyFlags.None);

        /// <summary>
        /// Imports a public/private key pair from a key BLOB.
        /// </summary>
        /// <param name="hAlgorithm">The handle of the algorithm provider to import the key. This handle is obtained by calling the BCryptOpenAlgorithmProvider function.</param>
        /// <param name="hImportKey">This parameter is not currently used and should be NULL.</param>
        /// <param name="pszBlobType">An identifier that specifies the type of BLOB that is contained in the <paramref name="pbInput"/> buffer. Supported formats are defined in <see cref="AsymmetricKeyBlobTypes"/>.</param>
        /// <param name="phKey">A pointer to a BCRYPT_KEY_HANDLE that receives the handle of the imported key. This handle is used in subsequent functions that require a key, such as BCryptSignHash. This handle must be released when it is no longer needed by passing it to the <see cref="BCryptDestroyKey"/> function.</param>
        /// <param name="pbInput">The address of a buffer that contains the key BLOB to import. The <paramref name="cbInput"/> parameter contains the size of this buffer. The <paramref name="pszBlobType"/> parameter specifies the type of key BLOB this buffer contains.</param>
        /// <param name="cbInput">The size, in bytes, of the <paramref name="pbInput"/> buffer.</param>
        /// <param name="dwFlags">A set of flags that modify the behavior of this function. This can be zero or the following value: BCRYPT_NO_KEY_VALIDATION</param>
        /// <returns>Returns a status code that indicates the success or failure of the function.</returns>
        [DllImport(nameof(BCrypt), SetLastError = true, ExactSpelling = true, CharSet = CharSet.Unicode)]
        public static extern NTSTATUS BCryptImportKeyPair(
            SafeAlgorithmHandle hAlgorithm,
            SafeKeyHandle hImportKey,
            [MarshalAs(UnmanagedType.LPWStr)] string pszBlobType,
            out SafeKeyHandle phKey,
            byte[] pbInput,
            int cbInput,
            BCryptImportKeyPairFlags dwFlags);

        /// <summary>
        /// Exports a key to a memory BLOB that can be persisted for later use.
        /// </summary>
        /// <param name="hKey">The handle of the key to export.</param>
        /// <param name="hExportKey">
        /// The handle of the key with which to wrap the exported key. Use this parameter when exporting BLOBs of type BCRYPT_AES_WRAP_KEY_BLOB; otherwise, set it to NULL.
        /// Note: The <paramref name="hExportKey"/> handle must be supplied by the same provider that supplied the hKey handle, and hExportKey must be a handle to a symmetric key that can be used in the Advanced Encryption Standard(AES) key wrap algorithm.When the hKey handle is from the Microsoft provider, hExportKey must be an AES key handle.
        /// </param>
        /// <param name="pszBlobType">
        /// An identifier that specifies the type of BLOB to export. This can be one of the values
        /// defined in the <see cref="AsymmetricKeyBlobTypes"/> or <see cref="SymmetricKeyBlobTypes"/> classes.
        /// </param>
        /// <param name="pbOutput">
        /// The address of a buffer that receives the key BLOB.
        /// The <paramref name="cbOutput"/> parameter contains the size of this buffer.
        /// If this parameter is NULL, this function will place the required size, in bytes, in the ULONG pointed to by the <paramref name="pcbResult"/> parameter.
        /// </param>
        /// <param name="cbOutput">
        /// Contains the size, in bytes, of the <paramref name="pbOutput"/> buffer.
        /// </param>
        /// <param name="pcbResult">
        /// A pointer to a ULONG that receives the number of bytes that were copied to the <paramref name="pbOutput"/> buffer.
        /// If the pbOutput parameter is NULL, this function will place the required size, in bytes,
        /// in the ULONG pointed to by this parameter.
        /// </param>
        /// <param name="dwFlags">A set of flags that modify the behavior of this function. </param>
        /// <returns>Returns a status code that indicates the success or failure of the function.</returns>
        [DllImport(nameof(BCrypt), SetLastError = true, ExactSpelling = true, CharSet = CharSet.Unicode)]
        public static extern NTSTATUS BCryptExportKey(
            SafeKeyHandle hKey,
            SafeKeyHandle hExportKey,
            [MarshalAs(UnmanagedType.LPWStr)] string pszBlobType,
            [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 5)] byte[] pbOutput,
            int cbOutput,
            out int pcbResult,
            BCryptExportKeyFlags dwFlags = BCryptExportKeyFlags.None);

        /// <summary>
        /// Creates a secret agreement value from a private and a public key.
        /// </summary>
        /// <param name="privateKey">
        /// The handle of the private key to use to create the secret agreement value.
        /// This key and the hPubKey key must come from the same CNG cryptographic algorithm provider.
        /// </param>
        /// <param name="publicKey">
        /// The handle of the public key to use to create the secret agreement value.
        /// This key and the hPrivKey key must come from the same CNG cryptographic algorithm provider.
        /// </param>
        /// <param name="secret">
        /// A pointer to a BCRYPT_SECRET_HANDLE that receives a handle that represents the
        /// secret agreement value. This handle must be released by passing it to the
        /// BCryptDestroySecret function when it is no longer needed.
        /// </param>
        /// <param name="flags">A set of flags that modify the behavior of this function. No flags are defined for this function.</param>
        /// <returns>Returns a status code that indicates the success or failure of the function.</returns>
        [DllImport(nameof(BCrypt), SetLastError = true, ExactSpelling = true)]
        public static extern NTSTATUS BCryptSecretAgreement(
            SafeKeyHandle privateKey,
            SafeKeyHandle publicKey,
            out SafeSecretHandle secret,
            BCryptSecretAgreementFlags flags = BCryptSecretAgreementFlags.None);

        /// <summary>
        /// Derives a key from a secret agreement value.
        /// </summary>
        /// <param name="sharedSecret">
        /// The secret agreement handle to create the key from.
        /// This handle is obtained from the BCryptSecretAgreement function.
        /// </param>
        /// <param name="keyDerivationFunction">
        /// The key derivation function.
        /// May come from the constants defined on the <see cref="KeyDerivationFunctions"/> class.
        /// </param>
        /// <param name="kdfParameters">
        /// The address of a BCryptBufferDesc structure that contains the KDF parameters.
        /// This parameter is optional and can be NULL if it is not needed.
        /// </param>
        /// <param name="derivedKey">
        /// The address of a buffer that receives the key. The cbDerivedKey parameter contains
        /// the size of this buffer. If this parameter is NULL, this function will place the
        /// required size, in bytes, in the ULONG pointed to by the pcbResult parameter.
        /// </param>
        /// <param name="derivedKeySize">
        /// The size, in bytes, of the pbDerivedKey buffer.
        /// </param>
        /// <param name="resultSize">
        /// A pointer to a ULONG that receives the number of bytes that were copied to the
        /// pbDerivedKey buffer. If the pbDerivedKey parameter is NULL, this function will
        /// place the required size, in bytes, in the ULONG pointed to by this parameter.
        /// </param>
        /// <param name="flags">
        /// A set of flags that modify the behavior of this function.
        /// This can be zero or the following value.
        /// </param>
        /// <returns>
        /// Returns a status code that indicates the success or failure of the function.
        /// </returns>
        [DllImport(nameof(BCrypt), SetLastError = true, ExactSpelling = true, CharSet = CharSet.Unicode)]
        public static extern NTSTATUS BCryptDeriveKey(
            SafeSecretHandle sharedSecret,
            string keyDerivationFunction,
            [In] ref BCryptBufferDesc kdfParameters,
            [Out, MarshalAs(UnmanagedType.LPArray)] byte[] derivedKey,
            int derivedKeySize,
            [Out] out int resultSize,
            BCryptDeriveKeyFlags flags);

        /// <summary>
        /// Sets the value of a named property for a CNG object.
        /// </summary>
        /// <param name="hObject">A handle that represents the CNG object to set the property value for.</param>
        /// <param name="pszProperty">
        /// A pointer to a null-terminated Unicode string that contains the name of the property to set. This can be one of the predefined <see cref="PropertyNames"/> or a custom property identifier.
        /// </param>
        /// <param name="pbInput">The address of a buffer that contains the new property value. The <paramref name="cbInput"/> parameter contains the size of this buffer.</param>
        /// <param name="cbInput">The size, in bytes, of the <paramref name="pbInput"/> buffer.</param>
        /// <param name="dwFlags">A set of flags that modify the behavior of this function. No flags are defined for this function.</param>
        /// <returns>Returns a status code that indicates the success or failure of the function.</returns>
        [DllImport(nameof(BCrypt), SetLastError = true, ExactSpelling = true, CharSet = CharSet.Unicode)]
        public static extern unsafe NTSTATUS BCryptSetProperty(
            SafeHandle hObject,
            string pszProperty,
            byte* pbInput,
            int cbInput,
            BCryptSetPropertyFlags dwFlags = BCryptSetPropertyFlags.None);

        /// <summary>
        /// Sets the value of a named property for a CNG object.
        /// </summary>
        /// <param name="hObject">A handle that represents the CNG object to set the property value for.</param>
        /// <param name="pszProperty">
        /// The name of the property to set. This can be one of the predefined <see cref="PropertyNames"/> or a custom property identifier.
        /// </param>
        /// <param name="pbInput">The new property value. The <paramref name="cbInput"/> parameter contains the size of this buffer.</param>
        /// <param name="cbInput">The size, in bytes, of the <paramref name="pbInput"/> buffer.</param>
        /// <param name="dwFlags">A set of flags that modify the behavior of this function. No flags are defined for this function.</param>
        /// <returns>Returns a status code that indicates the success or failure of the function.</returns>
        [DllImport(nameof(BCrypt), SetLastError = true, ExactSpelling = true, CharSet = CharSet.Unicode)]
        public static extern NTSTATUS BCryptSetProperty(
            SafeHandle hObject,
            string pszProperty,
            string pbInput,
            int cbInput,
            BCryptSetPropertyFlags dwFlags = BCryptSetPropertyFlags.None);

        /// <summary>
        /// Retrieves the value of a named property for a CNG object.
        /// </summary>
        /// <param name="hObject">A handle that represents the CNG object to obtain the property value for.</param>
        /// <param name="property">A pointer to a null-terminated Unicode string that contains the name of the property to retrieve. This can be one of the predefined <see cref="PropertyNames"/> or a custom property identifier.</param>
        /// <param name="output">The address of a buffer that receives the property value. The <paramref name="outputSize"/> parameter contains the size of this buffer.</param>
        /// <param name="outputSize">The size, in bytes, of the <paramref name="output"/> buffer.</param>
        /// <param name="resultSize">A pointer to a ULONG variable that receives the number of bytes that were copied to the pbOutput buffer. If the <paramref name="output"/> parameter is NULL, this function will place the required size, in bytes, in the location pointed to by this parameter.</param>
        /// <param name="flags">A set of flags that modify the behavior of this function. No flags are defined for this function.</param>
        /// <returns>Returns a status code that indicates the success or failure of the function.</returns>
        [DllImport(nameof(BCrypt), SetLastError = true, ExactSpelling = true, CharSet = CharSet.Unicode)]
        public static extern NTSTATUS BCryptGetProperty(
            SafeHandle hObject,
            string property,
            [Out, MarshalAs(UnmanagedType.LPArray)] byte[] output,
            int outputSize,
            out int resultSize,
            BCryptGetPropertyFlags flags = BCryptGetPropertyFlags.None);

        /// <summary>
        /// Generates a random number.
        /// </summary>
        /// <param name="hAlgorithm">
        /// The handle of an algorithm provider created by using the <see cref="BCryptOpenAlgorithmProvider(string, string, BCryptOpenAlgorithmProviderFlags)"/> function. The algorithm that was specified when the provider was created must support the random number generator interface.
        /// </param>
        /// <param name="pbBuffer">
        /// The address of a buffer that receives the random number. The size of this buffer is specified by the <paramref name="cbBuffer"/> parameter.
        /// </param>
        /// <param name="cbBuffer">
        /// The size, in bytes, of the <paramref name="pbBuffer" /> buffer.
        /// </param>
        /// <param name="flags">A set of flags that modify the behavior of this function. </param>
        /// <returns>Returns a status code that indicates the success or failure of the function.</returns>
        [DllImport(nameof(BCrypt), SetLastError = true)]
        public static extern NTSTATUS BCryptGenRandom(
            SafeAlgorithmHandle hAlgorithm,
            byte[] pbBuffer,
            int cbBuffer,
            BCryptGenRandomFlags flags = BCryptGenRandomFlags.None);

        /// <summary>
        /// The BCryptFreeBuffer function is used to free memory that was allocated by one of the CNG functions.
        /// </summary>
        /// <param name="pvBuffer">A pointer to the memory buffer to be freed.</param>
        [DllImport(nameof(BCrypt), SetLastError = true)]
        public static extern unsafe void BCryptFreeBuffer(void* pvBuffer);

        /// <summary>
        /// Closes an algorithm provider.
        /// </summary>
        /// <param name="algorithmHandle">A handle that represents the algorithm provider to close. This handle is obtained by calling the BCryptOpenAlgorithmProvider function.</param>
        /// <param name="flags">A set of flags that modify the behavior of this function. No flags are defined for this function.</param>
        /// <returns>Returns a status code that indicates the success or failure of the function.</returns>
        [DllImport(nameof(BCrypt), SetLastError = true, ExactSpelling = true)]
        private static extern NTSTATUS BCryptCloseAlgorithmProvider(
            IntPtr algorithmHandle,
            BCryptCloseAlgorithmProviderFlags flags = BCryptCloseAlgorithmProviderFlags.None);

        /// <summary>
        /// Destroys a hash or Message Authentication Code (MAC) object.
        /// </summary>
        /// <param name="hHash">The handle of the hash or MAC object to destroy. This handle is obtained by using the <see cref="BCryptCreateHash(SafeAlgorithmHandle, out SafeHashHandle, byte[], int, byte[], int, BCryptCreateHashFlags)"/> function.</param>
        /// <returns>Returns a status code that indicates the success or failure of the function.</returns>
        [DllImport(nameof(BCrypt), SetLastError = true)]
        private static extern NTSTATUS BCryptDestroyHash(IntPtr hHash);

        /// <summary>
        /// Destroys a key.
        /// </summary>
        /// <param name="hKey">The handle of the key to destroy.</param>
        /// <returns>Returns a status code that indicates the success or failure of the function.</returns>
        [DllImport(nameof(BCrypt), SetLastError = true, ExactSpelling = true)]
        private static extern NTSTATUS BCryptDestroyKey(
            IntPtr hKey);

        /// <summary>
        /// Destroys a secret agreement handle that was created by using the BCryptSecretAgreement function.
        /// </summary>
        /// <param name="hSecret">The handle of the secret to destroy.</param>
        /// <returns>Returns a status code that indicates the success or failure of the function.</returns>
        [DllImport(nameof(BCrypt), SetLastError = true, ExactSpelling = true)]
        private static extern NTSTATUS BCryptDestroySecret(
            IntPtr hSecret);
    }
}
