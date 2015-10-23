// Copyright (c) Andrew Arnott. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Exported functions from the BCrypt.dll Windows library.
    /// </summary>
    public static class BCrypt
    {
        public static readonly IReadOnlyDictionary<int, string> ECDH_KeySizesAndAlgorithmNames = new Dictionary<int, string>
        {
            { 256, "ECDH_P256" },
            { 384, "ECDH_P384" },
            { 521, "ECDH_P521" },
        };

        /// <summary>
        /// Types of NCryptBuffers
        /// </summary>
        public enum BufferType
        {
            KdfHashAlgorithm = 0x00000000,              // KDF_HASH_ALGORITHM
            KdfSecretPrepend = 0x00000001,              // KDF_SECRET_PREPEND
            KdfSecretAppend = 0x00000002,               // KDF_SECRET_APPEND
            KdfHmacKey = 0x00000003,                    // KDF_HMAC_KEY
            KdfTlsLabel = 0x00000004,                   // KDF_TLS_PRF_LABEL
            KdfTlsSeed = 0x00000005,                    // KDF_TLS_PRF_SEED
        }

        /// <summary>
        /// Flags that can be passed to <see cref="BCryptOpenAlgorithmProvider"/>
        /// </summary>
        [Flags]
        public enum OpenAlgorithmProviderOptions
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

        public enum EccKeyBlobMagicNumbers : uint
        {
            BCRYPT_ECDH_PUBLIC_P256_MAGIC = 0x314B4345,  // ECK1
            BCRYPT_ECDH_PRIVATE_P256_MAGIC = 0x324B4345,  // ECK2
            BCRYPT_ECDH_PUBLIC_P384_MAGIC = 0x334B4345,  // ECK3
            BCRYPT_ECDH_PRIVATE_P384_MAGIC = 0x344B4345,  // ECK4
            BCRYPT_ECDH_PUBLIC_P521_MAGIC = 0x354B4345,  // ECK5
            BCRYPT_ECDH_PRIVATE_P521_MAGIC = 0x364B4345,  // ECK6
            BCRYPT_ECDSA_PUBLIC_P256_MAGIC = 0x31534345,  // ECS1
            BCRYPT_ECDSA_PRIVATE_P256_MAGIC = 0x32534345,  // ECS2
            BCRYPT_ECDSA_PUBLIC_P384_MAGIC = 0x33534345,  // ECS3
            BCRYPT_ECDSA_PRIVATE_P384_MAGIC = 0x34534345,  // ECS4
            BCRYPT_ECDSA_PUBLIC_P521_MAGIC = 0x35534345,  // ECS5
            BCRYPT_ECDSA_PRIVATE_P521_MAGIC = 0x36534345,  // ECS6
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
        /// Opens a BCrypt algorithm.
        /// </summary>
        /// <param name="keySize">The length of the key, in bits.</param>
        /// <returns>The BCrypt algorithm.</returns>
        public static BCryptAlgorithmSafeHandle OpenAlgorithm(int keySize)
        {
            BCryptAlgorithmSafeHandle algorithm;
            var error = BCryptOpenAlgorithmProvider(
                out algorithm,
                ECDH_KeySizesAndAlgorithmNames[keySize],
                null,
                OpenAlgorithmProviderOptions.None);
            ThrowOnWin32Error(error);
            return algorithm;
        }

        public static EccKeyBlob GetEccKeyBlob(byte[] keyBlob)
        {
            return new EccKeyBlob(keyBlob);
        }

        /// <summary>
        /// Loads and initializes a CNG provider.
        /// </summary>
        /// <param name="algorithm">
        /// A pointer to a BCRYPT_ALG_HANDLE variable that receives the CNG provider handle.
        /// When you have finished using this handle, release it by passing it to the
        /// BCryptCloseAlgorithmProvider function.
        /// </param>
        /// <param name="algorithmId">
        /// A pointer to a null-terminated Unicode string that identifies the requested
        /// cryptographic algorithm. This can be one of the standard
        /// CNG Algorithm Identifiers or the identifier for another registered algorithm.
        /// </param>
        /// <param name="implementation">
        /// <para>
        /// A pointer to a null-terminated Unicode string that identifies the specific provider
        /// to load. This is the registered alias of the cryptographic primitive provider.
        /// This parameter is optional and can be NULL if it is not needed. If this parameter
        /// is NULL, the default provider for the specified algorithm will be loaded.
        /// </para>
        /// <para>
        /// Note If the pszImplementation parameter value is NULL, CNG attempts to open each
        /// registered provider, in order of priority, for the algorithm specified by the
        /// pszAlgId parameter and returns the handle of the first provider that is successfully
        /// opened.For the lifetime of the handle, any BCrypt*** cryptographic APIs will use the
        /// provider that was successfully opened.
        /// </para>
        /// </param>
        /// <param name="flags">Options for the function.</param>
        /// <returns>
        /// Returns a status code that indicates the success or failure of the function.
        /// </returns>
        [DllImport("Bcrypt", SetLastError = true, CharSet = CharSet.Unicode, ExactSpelling = true)]
        public static extern NTStatus BCryptOpenAlgorithmProvider(
            out BCryptAlgorithmSafeHandle algorithm,
            string algorithmId,
            string implementation,
            OpenAlgorithmProviderOptions flags);

        /// <summary>
        /// Creates an empty public/private key pair.
        /// </summary>
        /// <param name="algorithm">The handle to the algorithm previously opened by <see cref="BCryptOpenAlgorithmProvider"/></param>
        /// <param name="keyLength">The length of the key, in bits.</param>
        /// <returns>A handle to the generated key pair.</returns>
        /// <remarks>
        /// After you create a key by using this function, you can use the BCryptSetProperty
        /// function to set its properties; however, the key cannot be used until the
        /// BCryptFinalizeKeyPair function is called.
        /// </remarks>
        public static BCryptKeySafeHandle BCryptGenerateKeyPair(
            BCryptAlgorithmSafeHandle algorithm,
            int keyLength)
        {
            BCryptKeySafeHandle result;
            var error = BCryptGenerateKeyPair(algorithm, out result, keyLength, 0);
            ThrowOnWin32Error(error);
            return result;
        }

        /// <summary>
        /// Creates an empty public/private key pair.
        /// </summary>
        /// <param name="algorithm">The handle to the algorithm previously opened by <see cref="BCryptOpenAlgorithmProvider"/></param>
        /// <param name="key">Receives a handle to the generated key pair.</param>
        /// <param name="keyLength">The length of the key, in bits.</param>
        /// <param name="flags">A set of flags that modify the behavior of this function. No flags are currently defined, so this parameter should be zero.</param>
        /// <returns>Returns a status code that indicates the success or failure of the function.</returns>
        /// <remarks>
        /// After you create a key by using this function, you can use the BCryptSetProperty
        /// function to set its properties; however, the key cannot be used until the
        /// BCryptFinalizeKeyPair function is called.
        /// </remarks>
        [DllImport("Bcrypt", SetLastError = true, ExactSpelling = true)]
        public static extern NTStatus BCryptGenerateKeyPair(
            BCryptAlgorithmSafeHandle algorithm,
            out BCryptKeySafeHandle key,
            int keyLength,
            uint flags);

        /// <summary>
        /// Completes a public/private key pair.
        /// </summary>
        /// <param name="keyHandle">The handle of the key to complete. This handle is obtained by calling the BCryptGenerateKeyPair function.</param>
        /// <remarks>
        /// The key cannot be used until this function has been called.
        /// After this function has been called, the BCryptSetProperty function
        /// can no longer be used for this key.
        /// </remarks>
        public static void BCryptFinalizeKeyPair(BCryptKeySafeHandle keyHandle)
        {
            var error = BCryptFinalizeKeyPair(keyHandle, 0);
            ThrowOnWin32Error(error);
        }

        /// <summary>
        /// Completes a public/private key pair.
        /// </summary>
        /// <param name="keyHandle">The handle of the key to complete. This handle is obtained by calling the BCryptGenerateKeyPair function.</param>
        /// <param name="flags">A set of flags that modify the behavior of this function. No flags are currently defined, so this parameter should be zero.</param>
        /// <returns>Returns a status code that indicates the success or failure of the function.</returns>
        /// <remarks>
        /// The key cannot be used until this function has been called.
        /// After this function has been called, the BCryptSetProperty function
        /// can no longer be used for this key.
        /// </remarks>
        [DllImport("Bcrypt", SetLastError = true, ExactSpelling = true)]
        public static extern NTStatus BCryptFinalizeKeyPair(
            BCryptKeySafeHandle keyHandle,
            uint flags);

        /// <summary>
        /// Destroys a key.
        /// </summary>
        /// <param name="keyHandle">The handle of the key to destroy.</param>
        /// <returns>Returns a status code that indicates the success or failure of the function.</returns>
        [DllImport("Bcrypt", SetLastError = true, ExactSpelling = true)]
        public static extern NTStatus BCryptDestroyKey(
            IntPtr keyHandle);

        /// <summary>
        /// Destroys a secret agreement handle that was created by using the BCryptSecretAgreement function.
        /// </summary>
        /// <param name="secretHandle">The handle of the secret to destroy.</param>
        /// <returns>Returns a status code that indicates the success or failure of the function.</returns>
        [DllImport("Bcrypt", SetLastError = true, ExactSpelling = true)]
        public static extern NTStatus BCryptDestroySecret(
            IntPtr secretHandle);

        [DllImport("Bcrypt", SetLastError = true, ExactSpelling = true, CharSet = CharSet.Unicode)]
        public static extern NTStatus BCryptImportKey(
            BCryptAlgorithmSafeHandle algorithm,
            BCryptKeySafeHandle importKey,
            [MarshalAs(UnmanagedType.LPWStr)] string blobType,
            out BCryptKeySafeHandle key,
            byte[] keyObject,
            [MarshalAs(UnmanagedType.U4)] uint keyObjectSize,
            byte[] input,
            [MarshalAs(UnmanagedType.U4)] uint inputSize,
            uint flags);

        public static BCryptKeySafeHandle BCryptImportKeyPair(
            BCryptAlgorithmSafeHandle algorithm,
            [MarshalAs(UnmanagedType.LPWStr)] string blobType,
            byte[] input,
            uint flags = 0)
        {
            BCryptKeySafeHandle result;
            var error = BCryptImportKeyPair(
                algorithm,
                new BCryptKeySafeHandle(),
                blobType,
                out result,
                input,
                input.Length,
                flags);
            ThrowOnWin32Error(error);
            return result;
        }

        /// <summary>
        /// Imports a public/private key pair from a key BLOB.
        /// </summary>
        /// <param name="algorithm">The handle of the algorithm provider to import the key. This handle is obtained by calling the BCryptOpenAlgorithmProvider function.</param>
        /// <param name="importKey">This parameter is not currently used and should be NULL.</param>
        /// <param name="blobType">an identifier that specifies the type of BLOB that is contained in the <paramref name="input"/> buffer.</param>
        /// <param name="key">A pointer to a BCRYPT_KEY_HANDLE that receives the handle of the imported key. This handle is used in subsequent functions that require a key, such as BCryptSignHash. This handle must be released when it is no longer needed by passing it to the BCryptDestroyKey function.</param>
        /// <param name="input">The address of a buffer that contains the key BLOB to import. The cbInput parameter contains the size of this buffer. The pszBlobType parameter specifies the type of key BLOB this buffer contains.</param>
        /// <param name="inputSize">The size, in bytes, of the <paramref name="input"/> buffer.</param>
        /// <param name="flags">A set of flags that modify the behavior of this function. This can be zero or the following value: BCRYPT_NO_KEY_VALIDATION</param>
        /// <returns>Returns a status code that indicates the success or failure of the function.</returns>
        [DllImport("Bcrypt", SetLastError = true, ExactSpelling = true, CharSet = CharSet.Unicode)]
        public static extern NTStatus BCryptImportKeyPair(
            BCryptAlgorithmSafeHandle algorithm,
            BCryptKeySafeHandle importKey,
            [MarshalAs(UnmanagedType.LPWStr)] string blobType,
            out BCryptKeySafeHandle key,
            byte[] input,
            int inputSize,
            uint flags);

        public static byte[] BCryptExportKey(BCryptKeySafeHandle key, BCryptKeySafeHandle exportKey, string blobType)
        {
            int lengthRequired;
            exportKey = exportKey ?? new BCryptKeySafeHandle();
            var error = BCryptExportKey(
                key,
                exportKey,
                blobType,
                null,
                0,
                out lengthRequired,
                0);
            ThrowOnWin32Error(error);
            byte[] keyBuffer = new byte[lengthRequired];
            error = BCryptExportKey(
                key,
                exportKey,
                BlobTypes.EccPublic,
                keyBuffer,
                keyBuffer.Length,
                out lengthRequired,
                0);
            ThrowOnWin32Error(error);

            return keyBuffer;
        }

        [DllImport("Bcrypt", SetLastError = true, ExactSpelling = true, CharSet = CharSet.Unicode)]
        public static extern NTStatus BCryptExportKey(
            BCryptKeySafeHandle key,
            BCryptKeySafeHandle exportKey,
            [MarshalAs(UnmanagedType.LPWStr)] string blobType,
            [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 5)] byte[] output,
            int outputSize,
            out int resultSize,
            uint flags);

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
        /// <returns>
        /// A handle to the shared secret.
        /// </returns>
        public static BCryptSecretSafeHandle BCryptSecretAgreement(
            BCryptKeySafeHandle privateKey,
            BCryptKeySafeHandle publicKey)
        {
            BCryptSecretSafeHandle result;
            var error = BCryptSecretAgreement(
                  privateKey,
                  publicKey,
                  out result,
                  0);
            ThrowOnWin32Error(error);
            return result;
        }

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
            BCryptKeySafeHandle privateKey,
            BCryptKeySafeHandle publicKey,
            out BCryptSecretSafeHandle secret,
            uint flags);

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
            BCryptSecretSafeHandle sharedSecret,
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
            int flags);

        /// <summary>
        /// Sets the value of a named property for a CNG object.
        /// </summary>
        /// <param name="hObject">A handle that represents the CNG object to set the property value for.</param>
        /// <param name="propertyName">
        /// The name of the property to set. This can be one of the predefined Cryptography Primitive Property Identifiers or a custom property identifier.
        /// </param>
        /// <param name="propertyValue">The new property value.</param>
        public static void BCryptSetProperty(SafeHandle hObject, string propertyName, string propertyValue)
        {
            var error = BCryptSetProperty(
                hObject,
                propertyName,
                propertyValue,
                propertyValue != null ? (propertyValue.Length + 1) * sizeof(char) : 0,
                0);
            ThrowOnWin32Error(error);
        }

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
            int flags);

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
            int flags);

        /// <summary>
        /// Throws an exception if a P/Invoke failed.
        /// </summary>
        /// <param name="status">The result of the P/Invoke call.</param>
        public static void ThrowOnWin32Error(NTStatus status)
        {
            switch (status)
            {
                case NTStatus.Success:
                    break;
                case NTStatus.InvalidHandle:
                    throw new ArgumentException("Invalid handle");
                case NTStatus.InvalidParameter:
                    throw new ArgumentException();
                case NTStatus.NotFound:
                    throw new ArgumentException("Not found");
                case NTStatus.NoMemory:
                    throw new OutOfMemoryException();
                case NTStatus.NotSupported:
                    throw new NotSupportedException();
                default:
                    if ((int)status < 0)
                    {
                        Marshal.ThrowExceptionForHR(Marshal.GetHRForLastWin32Error());
                    }

                    break;
            }
        }

        /// <summary>
        /// Closes an algorithm provider.
        /// </summary>
        /// <param name="algorithmHandle">A handle that represents the algorithm provider to close. This handle is obtained by calling the BCryptOpenAlgorithmProvider function.</param>
        /// <param name="flags">A set of flags that modify the behavior of this function. No flags are defined for this function.</param>
        /// <returns>Returns a status code that indicates the success or failure of the function.</returns>
        [DllImport("Bcrypt", SetLastError = true, ExactSpelling = true)]
        private static extern NTStatus BCryptCloseAlgorithmProvider(
            IntPtr algorithmHandle,
            [MarshalAs(UnmanagedType.U4)] uint flags);

        [StructLayout(LayoutKind.Sequential)]
        public struct BCryptBufferDesc
        {
            public uint ulVersion;
            public int cBuffers;
            public IntPtr pBuffers; // NCryptBuffer[cBuffers]
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct BCryptBuffer
        {
            public int cbBuffer;
            public BufferType BufferType;
            public IntPtr pvBuffer;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct EccKeyBlob
        {
            /// <summary>
            /// Specifies the type of key this BLOB represents.
            /// The possible values for this member depend on the type of BLOB this structure represents.
            /// </summary>
            public EccKeyBlobMagicNumbers Magic;

            /// <summary>
            /// The length, in bytes, of the key.
            /// </summary>
            public uint KeyLength;

            /// <summary>
            /// Initializes a new instance of the <see cref="EccKeyBlob"/> struct.
            /// </summary>
            /// <param name="keyBlob">The key blob that starts with an BCRYPT_ECCKEY_BLOB structure.</param>
            public EccKeyBlob(byte[] keyBlob)
            {
                this.Magic = (EccKeyBlobMagicNumbers)BitConverter.ToUInt32(keyBlob, 0);
                this.KeyLength = BitConverter.ToUInt32(keyBlob, 4);
            }
        }

        public static class BlobTypes
        {
            public const string EccPublic = "ECCPUBLICBLOB";
            public const string EccPrivate = "ECCPRIVATEBLOB";
        }

        public static class KeyDerivationFunctions
        {
            public const string HASH = "HASH";
            public const string HMAC = "HMAC";
            public const string TLS_PRF = "TLS_PRF";
        }

        /// <summary>
        /// A BCrypt algorithm handle.
        /// </summary>
        public class BCryptAlgorithmSafeHandle : SafeHandle
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="BCryptAlgorithmSafeHandle"/> class.
            /// </summary>
            private BCryptAlgorithmSafeHandle()
                : base(IntPtr.Zero, true)
            {
            }

            /// <inheritdoc />
            public override bool IsInvalid => this.handle == IntPtr.Zero;

            /// <inheritdoc />
            protected override bool ReleaseHandle()
            {
                return BCryptCloseAlgorithmProvider(this.handle, 0) == NTStatus.Success;
            }
        }

        /// <summary>
        /// A BCrypt cryptographic key handle.
        /// </summary>
        public class BCryptKeySafeHandle : SafeHandle
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="BCryptKeySafeHandle"/> class.
            /// </summary>
            public BCryptKeySafeHandle()
                : base(IntPtr.Zero, true)
            {
            }

            /// <inheritdoc />
            public override bool IsInvalid => this.handle == IntPtr.Zero;

            /// <inheritdoc />
            protected override bool ReleaseHandle()
            {
                return BCryptDestroyKey(this.handle) == NTStatus.Success;
            }
        }

        /// <summary>
        /// A safe handle for BCrypt secrets.
        /// </summary>
        public class BCryptSecretSafeHandle : SafeHandle
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="BCryptSecretSafeHandle"/> class.
            /// </summary>
            private BCryptSecretSafeHandle()
                : base(IntPtr.Zero, true)
            {
            }

            /// <inheritdoc />
            public override bool IsInvalid => this.handle == IntPtr.Zero;

            /// <inheritdoc />
            protected override bool ReleaseHandle()
            {
                return BCryptDestroySecret(this.handle) == NTStatus.Success;
            }
        }
    }
}
