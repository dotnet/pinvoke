// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Runtime.InteropServices;

    /// <summary>
    /// Exported functions from the BCrypt.dll Windows library.
    /// </summary>
    public static partial class BCrypt
    {
        /// <summary>
        /// Types of data stored in <see cref="BCryptBuffer"/>.
        /// </summary>
        public enum BufferType
        {
            KDF_HASH_ALGORITHM = 0,
            KDF_SECRET_PREPEND = 1,
            KDF_SECRET_APPEND = 2,
            KDF_HMAC_KEY = 3,
            KDF_TLS_PRF_LABEL = 4,
            KDF_TLS_PRF_SEED = 5,
            KDF_SECRET_HANDLE = 6,
            KDF_TLS_PRF_PROTOCOL = 7,
            KDF_ALGORITHMID = 8,
            KDF_PARTYUINFO = 9,
            KDF_PARTYVINFO = 10,
            KDF_SUPPPUBINFO = 11,
            KDF_SUPPPRIVINFO = 12,
            KDF_LABEL = 13,
            KDF_CONTEXT = 14,
            KDF_SALT = 15,
            KDF_ITERATION_COUNT = 16,
        }

        [Flags]
        public enum BCryptSetPropertyFlags
        {
            None = 0x0,
        }

        [Flags]
        public enum BCryptGetPropertyFlags
        {
            None = 0x0,
        }

        [Flags]
        public enum BCryptCloseAlgorithmProviderFlags
        {
            None = 0x0,
        }

        [Flags]
        public enum BCryptSecretAgreementFlags
        {
            None = 0x0,
        }

        [Flags]
        public enum BCryptGenerateKeyPairFlags
        {
            None = 0x0,
        }

        [Flags]
        public enum BCryptFinalizeKeyPairFlags
        {
            None = 0x0,
        }

        [Flags]
        public enum BCryptImportKeyPairFlags
        {
            None = 0x0,

            /// <summary>
            /// Do not validate the public portion of the key pair.
            /// </summary>
            BCRYPT_NO_KEY_VALIDATION = 0x00000008,
        }

        [Flags]
        public enum BCryptImportKeyFlags
        {
            None = 0x0,
        }

        [Flags]
        public enum BCryptExportKeyFlags
        {
            None = 0x0,
        }

        /// <summary>
        /// Flags that can be passed to <see cref="BCryptOpenAlgorithmProvider"/>
        /// </summary>
        [Flags]
        public enum BCryptOpenAlgorithmProviderFlags
        {
            /// <summary>
            /// No flags.
            /// </summary>
            None = 0x0,

            /// <summary>
            /// The provider will perform the Hash-Based Message Authentication Code (HMAC)
            /// algorithm with the specified hash algorithm. This flag is only used by hash
            /// algorithm providers.
            /// </summary>
            AlgorithmHandleHmac,

            /// <summary>
            /// Creates a reusable hashing object. The object can be used for a new hashing
            /// operation immediately after calling BCryptFinishHash. For more information,
            /// see Creating a Hash with CNG.
            /// </summary>
            HashReusable,
        }

        [Flags]
        public enum BCryptDeriveKeyFlags
        {
            /// <summary>
            /// No flags.
            /// </summary>
            None = 0x0,

            /// <summary>
            /// Causes the secret agreement to serve also
            /// as the HMAC key.  If this flag is used, the KDF_HMAC_KEY parameter should
            /// NOT be specified.
            /// </summary>
            KDF_USE_SECRET_AS_HMAC_KEY_FLAG = 0x1,
        }

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
        /// CNG Algorithm Identifiers or the identifier for another registered algorithm.
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
        [DllImport("Bcrypt", SetLastError = true, CharSet = CharSet.Unicode, ExactSpelling = true)]
        public static extern NTStatus BCryptOpenAlgorithmProvider(
            out SafeAlgorithmHandle phAlgorithm,
            string pszAlgId,
            string pszImplementation,
            BCryptOpenAlgorithmProviderFlags dwFlags);

        /// <summary>
        /// Creates an empty public/private key pair.
        /// </summary>
        /// <param name="hAlgorithm">The handle to the algorithm previously opened by <see cref="BCryptOpenAlgorithmProvider"/></param>
        /// <param name="phKey">Receives a handle to the generated key pair.</param>
        /// <param name="dwLength">The length of the key, in bits.</param>
        /// <param name="dwFlags">A set of flags that modify the behavior of this function. No flags are currently defined, so this parameter should be zero.</param>
        /// <returns>Returns a status code that indicates the success or failure of the function.</returns>
        /// <remarks>
        /// After you create a key by using this function, you can use the BCryptSetProperty
        /// function to set its properties; however, the key cannot be used until the
        /// BCryptFinalizeKeyPair function is called.
        /// </remarks>
        [DllImport("Bcrypt", SetLastError = true, ExactSpelling = true)]
        public static extern NTStatus BCryptGenerateKeyPair(
            SafeAlgorithmHandle hAlgorithm,
            out SafeKeyHandle phKey,
            int dwLength,
            BCryptGenerateKeyPairFlags dwFlags = BCryptGenerateKeyPairFlags.None);

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
        [DllImport("Bcrypt", SetLastError = true, ExactSpelling = true)]
        public static extern NTStatus BCryptFinalizeKeyPair(
            SafeKeyHandle hKey,
            BCryptFinalizeKeyPairFlags dwFlags = BCryptFinalizeKeyPairFlags.None);

        /// <summary>
        /// Destroys a key.
        /// </summary>
        /// <param name="hKey">The handle of the key to destroy.</param>
        /// <returns>Returns a status code that indicates the success or failure of the function.</returns>
        [DllImport("Bcrypt", SetLastError = true, ExactSpelling = true)]
        public static extern NTStatus BCryptDestroyKey(
            IntPtr hKey);

        /// <summary>
        /// Destroys a secret agreement handle that was created by using the BCryptSecretAgreement function.
        /// </summary>
        /// <param name="hSecret">The handle of the secret to destroy.</param>
        /// <returns>Returns a status code that indicates the success or failure of the function.</returns>
        [DllImport("Bcrypt", SetLastError = true, ExactSpelling = true)]
        public static extern NTStatus BCryptDestroySecret(
            IntPtr hSecret);

        /// <summary>
        /// Imports a symmetric key from a key BLOB. The BCryptImportKeyPair function is used to import a public/private key pair.
        /// </summary>
        /// <param name="hAlgorithm">
        /// The handle of the algorithm provider to import the key. This handle is obtained by calling the <see cref="BCryptOpenAlgorithmProvider"/> function.
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
        /// The required size of this buffer can be obtained by calling the <see cref="BCryptGetProperty"/>
        /// function to get the BCRYPT_OBJECT_LENGTH property. This will provide the size of the
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
        [DllImport("Bcrypt", SetLastError = true, ExactSpelling = true, CharSet = CharSet.Unicode)]
        public static extern NTStatus BCryptImportKey(
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
        /// <param name="pszBlobType">an identifier that specifies the type of BLOB that is contained in the <paramref name="pbInput"/> buffer.</param>
        /// <param name="phKey">A pointer to a BCRYPT_KEY_HANDLE that receives the handle of the imported key. This handle is used in subsequent functions that require a key, such as BCryptSignHash. This handle must be released when it is no longer needed by passing it to the <see cref="BCryptDestroyKey"/> function.</param>
        /// <param name="pbInput">The address of a buffer that contains the key BLOB to import. The cbInput parameter contains the size of this buffer. The <paramref name="pszBlobType"/> parameter specifies the type of key BLOB this buffer contains.</param>
        /// <param name="cbInput">The size, in bytes, of the <paramref name="pbInput"/> buffer.</param>
        /// <param name="dwFlags">A set of flags that modify the behavior of this function. This can be zero or the following value: BCRYPT_NO_KEY_VALIDATION</param>
        /// <returns>Returns a status code that indicates the success or failure of the function.</returns>
        [DllImport("Bcrypt", SetLastError = true, ExactSpelling = true, CharSet = CharSet.Unicode)]
        public static extern NTStatus BCryptImportKeyPair(
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
        [DllImport("Bcrypt", SetLastError = true, ExactSpelling = true, CharSet = CharSet.Unicode)]
        public static extern NTStatus BCryptExportKey(
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
        [DllImport("Bcrypt", SetLastError = true, ExactSpelling = true)]
        public static extern NTStatus BCryptSecretAgreement(
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
        [DllImport("Bcrypt", SetLastError = true, ExactSpelling = true, CharSet = CharSet.Unicode)]
        public static extern NTStatus BCryptDeriveKey(
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
        /// <param name="property">
        /// A pointer to a null-terminated Unicode string that contains the name of the property to set. This can be one of the predefined Cryptography Primitive Property Identifiers or a custom property identifier.
        /// </param>
        /// <param name="input">The address of a buffer that contains the new property value. The <paramref name="inputSize"/> parameter contains the size of this buffer.</param>
        /// <param name="inputSize">The size, in bytes, of the <paramref name="input"/> buffer.</param>
        /// <param name="flags">A set of flags that modify the behavior of this function. No flags are defined for this function.</param>
        /// <returns>Returns a status code that indicates the success or failure of the function.</returns>
        [DllImport("Bcrypt", SetLastError = true, ExactSpelling = true, CharSet = CharSet.Unicode)]
        public static extern NTStatus BCryptSetProperty(
            SafeHandle hObject,
            string property,
            [In, MarshalAs(UnmanagedType.LPArray)] byte[] input,
            int inputSize,
            BCryptSetPropertyFlags flags = BCryptSetPropertyFlags.None);

        /// <summary>
        /// Sets the value of a named property for a CNG object.
        /// </summary>
        /// <param name="hObject">A handle that represents the CNG object to set the property value for.</param>
        /// <param name="property">
        /// The name of the property to set. This can be one of the predefined Cryptography Primitive Property Identifiers or a custom property identifier.
        /// </param>
        /// <param name="input">The new property value. The <paramref name="inputSize"/> parameter contains the size of this buffer.</param>
        /// <param name="inputSize">The size, in bytes, of the <paramref name="input"/> buffer.</param>
        /// <param name="flags">A set of flags that modify the behavior of this function. No flags are defined for this function.</param>
        /// <returns>Returns a status code that indicates the success or failure of the function.</returns>
        [DllImport("Bcrypt", SetLastError = true, ExactSpelling = true, CharSet = CharSet.Unicode)]
        public static extern NTStatus BCryptSetProperty(
            SafeHandle hObject,
            string property,
            string input,
            int inputSize,
            BCryptSetPropertyFlags flags = BCryptSetPropertyFlags.None);

        /// <summary>
        /// Retrieves the value of a named property for a CNG object.
        /// </summary>
        /// <param name="hObject">A handle that represents the CNG object to obtain the property value for.</param>
        /// <param name="property">A pointer to a null-terminated Unicode string that contains the name of the property to retrieve. This can be one of the predefined Cryptography Primitive Property Identifiers or a custom property identifier.</param>
        /// <param name="output">The address of a buffer that receives the property value. The <paramref name="outputSize"/> parameter contains the size of this buffer.</param>
        /// <param name="outputSize">The size, in bytes, of the <paramref name="output"/> buffer.</param>
        /// <param name="resultSize">A pointer to a ULONG variable that receives the number of bytes that were copied to the pbOutput buffer. If the <paramref name="output"/> parameter is NULL, this function will place the required size, in bytes, in the location pointed to by this parameter.</param>
        /// <param name="flags">A set of flags that modify the behavior of this function. No flags are defined for this function.</param>
        /// <returns>Returns a status code that indicates the success or failure of the function.</returns>
        [DllImport("Bcrypt", SetLastError = true, ExactSpelling = true, CharSet = CharSet.Unicode)]
        public static extern NTStatus BCryptGetProperty(
            SafeHandle hObject,
            string property,
            [Out, MarshalAs(UnmanagedType.LPArray)] byte[] output,
            int outputSize,
            out int resultSize,
            BCryptGetPropertyFlags flags = BCryptGetPropertyFlags.None);

        /// <summary>
        /// Closes an algorithm provider.
        /// </summary>
        /// <param name="algorithmHandle">A handle that represents the algorithm provider to close. This handle is obtained by calling the BCryptOpenAlgorithmProvider function.</param>
        /// <param name="flags">A set of flags that modify the behavior of this function. No flags are defined for this function.</param>
        /// <returns>Returns a status code that indicates the success or failure of the function.</returns>
        [DllImport("Bcrypt", SetLastError = true, ExactSpelling = true)]
        private static extern NTStatus BCryptCloseAlgorithmProvider(
            IntPtr algorithmHandle,
            BCryptCloseAlgorithmProviderFlags flags = BCryptCloseAlgorithmProviderFlags.None);
    }
}
