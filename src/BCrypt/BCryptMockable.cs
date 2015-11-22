// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
	public partial class BCrypt : IBCryptMockable {        /// <summary>
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
        public NTStatus InvokeBCryptOpenAlgorithmProvider(
            out SafeAlgorithmHandle phAlgorithm,
            string pszAlgId,
            string pszImplementation,
            BCryptOpenAlgorithmProviderFlags dwFlags)
			=> BCryptOpenAlgorithmProvider(phAlgorithm, pszAlgId, pszImplementation, dwFlags);
	
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
        /// A pointer to a buffer that receives the hash or MAC object. The <paramref name="cbHashObject"/> parameter contains the size of this buffer. The required size of this buffer can be obtained by calling the <see cref="BCryptGetProperty(SafeHandle, string, BCryptGetPropertyFlags)"/> function to get the <see cref="PropertyNames.ObjectLength"/> property. This will provide the size of the hash or MAC object for the specified algorithm.
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
        public NTStatus InvokeBCryptCreateHash(
            SafeAlgorithmHandle hAlgorithm,
            out SafeHashHandle phHash,
            byte[] pbHashObject,
            int cbHashObject,
            byte[] pbSecret,
            int cbSecret,
            BCryptCreateHashFlags dwFlags)
			=> BCryptCreateHash(hAlgorithm, phHash, pbHashObject, cbHashObject, pbSecret, cbSecret, dwFlags);
	
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
        /// If this parameter is NULL, the <see cref="BCryptEncrypt(SafeKeyHandle, byte[], IntPtr, byte[], BCryptEncryptFlags)"/> function calculates the size needed for the ciphertext of the data passed in the <paramref name="pbInput"/> parameter. In this case, the location pointed to by the <paramref name="pcbResult"/> parameter contains this size, and the function returns <see cref="NTStatus.STATUS_SUCCESS"/>.The <paramref name="pPaddingInfo"/> parameter is not modified.
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
        public NTStatus InvokeBCryptEncrypt(
            SafeKeyHandle hKey,
            byte[] pbInput,
            int cbInput,
            IntPtr pPaddingInfo,
            [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 5)] byte[] pbIV,
            int cbIV,
            [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 8)] byte[] pbOutput,
            int cbOutput,
            out int pcbResult,
            BCryptEncryptFlags dwFlags)
			=> BCryptEncrypt(hKey, pbInput, cbInput, pPaddingInfo, pbIV, cbIV, pbOutput, cbOutput, pcbResult, dwFlags);
	
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
        /// The required size of the IV can be obtained by calling the <see cref="BCryptGetProperty(SafeHandle, string, BCryptGetPropertyFlags)"/> function to get the <see cref="PropertyNames.BlockLength"/> property. This will provide the size of a block for the algorithm, which is also the size of the IV.
        /// </param>
        /// <param name="cbIV">
        /// The size, in bytes, of the <paramref name="pbIV"/> buffer.
        /// </param>
        /// <param name="pbOutput">
        /// The address of a buffer to receive the plaintext produced by this function. The cbOutput parameter contains the size of this buffer. For more information, see Remarks.
        /// If this parameter is NULL, the <see cref="BCryptDecrypt(SafeKeyHandle, byte[], IntPtr, byte[], BCryptEncryptFlags)"/> function calculates the size required for the plaintext of the encrypted data passed in the <paramref name="pbInput"/> parameter.In this case, the location pointed to by the <paramref name="pcbResult"/> parameter contains this size, and the function returns <see cref="NTStatus.STATUS_SUCCESS"/>.
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
        public NTStatus InvokeBCryptDecrypt(
            SafeKeyHandle hKey,
            byte[] pbInput,
            int cbInput,
            IntPtr pPaddingInfo,
            [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 5)] byte[] pbIV,
            int cbIV,
            [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 8)] byte[] pbOutput,
            int cbOutput,
            out int pcbResult,
            BCryptEncryptFlags dwFlags)
			=> BCryptDecrypt(hKey, pbInput, cbInput, pPaddingInfo, pbIV, cbIV, pbOutput, cbOutput, pcbResult, dwFlags);
	
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
        public NTStatus InvokeBCryptHashData(
            SafeHashHandle hHash,
            byte[] pbInput,
            int cbInput,
            BCryptHashDataFlags dwFlags = BCryptHashDataFlags.None)
			=> BCryptHashData(hHash, pbInput, cbInput, dwFlags );
	
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
        /// The size can be obtained by calling the <see cref="BCryptGetProperty(SafeHandle, string, BCryptGetPropertyFlags)"/> function to get the <see cref="PropertyNames.HashLength"/> property. This will provide the size of the hash or MAC value for the specified algorithm.
        /// </param>
        /// <param name="dwFlags">A set of flags that modify the behavior of this function.</param>
        /// <returns>Returns a status code that indicates the success or failure of the function.</returns>
        public NTStatus InvokeBCryptFinishHash(
            SafeHashHandle hHash,
            [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] byte[] pbOutput,
            int cbOutput,
            BCryptFinishHashFlags dwFlags = BCryptFinishHashFlags.None)
			=> BCryptFinishHash(hHash, pbOutput, cbOutput, dwFlags );
	}
}
