// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Runtime.InteropServices;

    /// <content>
    /// Methods and nested types that are not strictly P/Invokes but provide
    /// a slightly higher level of functionality to ease calling into native code.
    /// </content>
    public static partial class BCrypt
    {
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

        /// <summary>
        /// Loads and initializes a CNG provider.
        /// </summary>
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
        /// A pointer to a BCRYPT_ALG_HANDLE variable that receives the CNG provider handle.
        /// When you have finished using this handle, release it by passing it to the
        /// BCryptCloseAlgorithmProvider function.
        /// </returns>
        public static SafeAlgorithmHandle BCryptOpenAlgorithmProvider(
            string pszAlgId,
            string pszImplementation = null,
            BCryptOpenAlgorithmProviderFlags dwFlags = BCryptOpenAlgorithmProviderFlags.None)
        {
            SafeAlgorithmHandle handle;
            BCryptOpenAlgorithmProvider(
                out handle,
                pszAlgId,
                pszImplementation,
                dwFlags).ThrowOnError();
            return handle;
        }

        public static byte[] BCryptExportKey(SafeKeyHandle key, SafeKeyHandle exportKey, string blobType)
        {
            int lengthRequired;
            exportKey = exportKey ?? SafeKeyHandle.NullHandle;
            BCryptExportKey(
                key,
                exportKey,
                blobType,
                null,
                0,
                out lengthRequired,
                0).ThrowOnError();
            byte[] keyBuffer = new byte[lengthRequired];
            BCryptExportKey(
                key,
                exportKey,
                AsymmetricKeyBlobTypes.EccPublic,
                keyBuffer,
                keyBuffer.Length,
                out lengthRequired,
                0).ThrowOnError();

            return keyBuffer;
        }

        /// <summary>
        /// Completes a public/private key pair.
        /// </summary>
        /// <param name="keyHandle">The handle of the key to complete. This handle is obtained by calling the BCryptGenerateKeyPair function.</param>
        /// <remarks>
        /// The key cannot be used until this function has been called.
        /// After this function has been called, the BCryptSetProperty function
        /// can no longer be used for this key.
        /// </remarks>
        public static void BCryptFinalizeKeyPair(SafeKeyHandle keyHandle)
        {
            var error = BCryptFinalizeKeyPair(keyHandle, 0);
            error.ThrowOnError();
        }

        /// <summary>
        /// Creates an empty public/private key pair.
        /// </summary>
        /// <param name="algorithm">The handle to the algorithm previously opened by <see cref="BCryptOpenAlgorithmProvider(string, string, BCryptOpenAlgorithmProviderFlags)"/></param>
        /// <param name="keyLength">The length of the key, in bits.</param>
        /// <returns>A handle to the generated key pair.</returns>
        /// <remarks>
        /// After you create a key by using this function, you can use the BCryptSetProperty
        /// function to set its properties; however, the key cannot be used until the
        /// BCryptFinalizeKeyPair function is called.
        /// </remarks>
        public static SafeKeyHandle BCryptGenerateKeyPair(
            SafeAlgorithmHandle algorithm,
            int keyLength)
        {
            SafeKeyHandle result;
            var error = BCryptGenerateKeyPair(algorithm, out result, keyLength, 0);
            error.ThrowOnError();
            return result;
        }

        /// <summary>
        /// Creates a key object for use with a symmetrical key encryption algorithm from a supplied key.
        /// </summary>
        /// <param name="algorithm">
        /// The handle of an algorithm provider created with the <see cref="BCryptOpenAlgorithmProvider(string, string, BCryptOpenAlgorithmProviderFlags)"/> function. The algorithm specified when the provider was created must support symmetric key encryption.
        /// </param>
        /// <param name="secret">
        /// A buffer that contains the key from which to create the key object. This is normally a hash of a password or some other reproducible data. If the data passed in exceeds the target key size, the data will be truncated and the excess will be ignored.
        /// Note: We strongly recommended that applications pass in the exact number of bytes required by the target key.
        /// </param>
        /// <param name="keyObject">
        /// A pointer to a buffer that receives the key object. The required size of this buffer can be obtained by calling the <see cref="BCryptGetProperty(SafeHandle, string, BCryptGetPropertyFlags)"/> function to get the BCRYPT_OBJECT_LENGTH property. This will provide the size of the key object for the specified algorithm.
        /// This memory can only be freed after the returned key handle is destroyed.
        /// If the value of this parameter is NULL, the memory for the key object is allocated and freed by this function.
        /// </param>
        /// <param name="flags">A set of flags that modify the behavior of this function. No flags are currently defined, so this parameter should be zero.</param>
        /// <returns>A handle to the generated key.</returns>
        public static SafeKeyHandle BCryptGenerateSymmetricKey(
            SafeAlgorithmHandle algorithm,
            byte[] secret,
            byte[] keyObject = null,
            BCryptGenerateSymmetricKeyFlags flags = BCryptGenerateSymmetricKeyFlags.None)
        {
            SafeKeyHandle hKey;
            BCryptGenerateSymmetricKey(
                algorithm,
                out hKey,
                keyObject,
                keyObject?.Length ?? 0,
                secret,
                secret.Length,
                flags).ThrowOnError();
            return hKey;
        }

        public static SafeKeyHandle BCryptImportKeyPair(
            SafeAlgorithmHandle algorithm,
            string blobType,
            byte[] input,
            BCryptImportKeyPairFlags flags)
        {
            SafeKeyHandle result;
            var error = BCryptImportKeyPair(
                algorithm,
                SafeKeyHandle.NullHandle,
                blobType,
                out result,
                input,
                input.Length,
                flags);
            error.ThrowOnError();
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
        /// <returns>
        /// A handle to the shared secret.
        /// </returns>
        public static SafeSecretHandle BCryptSecretAgreement(
            SafeKeyHandle privateKey,
            SafeKeyHandle publicKey)
        {
            SafeSecretHandle result;
            BCryptSecretAgreement(
                  privateKey,
                  publicKey,
                  out result).ThrowOnError();
            return result;
        }

        /// <summary>
        /// Sets the value of a named property for a CNG object.
        /// </summary>
        /// <param name="hObject">A handle that represents the CNG object to set the property value for.</param>
        /// <param name="propertyName">
        /// The name of the property to set. This can be one of the predefined <see cref="PropertyNames"/> or a custom property identifier.
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
            error.ThrowOnError();
        }

        /// <summary>
        /// Retrieves the value of a named property for a CNG object.
        /// </summary>
        /// <param name="hObject">A handle that represents the CNG object to obtain the property value for.</param>
        /// <param name="propertyName">A pointer to a null-terminated Unicode string that contains the name of the property to retrieve. This can be one of the predefined <see cref="PropertyNames"/> or a custom property identifier.</param>
        /// <param name="flags">A set of flags that modify the behavior of this function. No flags are defined for this function.</param>
        /// <returns>The property value.</returns>
        public static byte[] BCryptGetProperty(SafeHandle hObject, string propertyName, BCryptGetPropertyFlags flags = BCryptGetPropertyFlags.None)
        {
            int requiredSize;
            BCryptGetProperty(hObject, propertyName, null, 0, out requiredSize, flags).ThrowOnError();
            byte[] result = new byte[requiredSize];
            BCryptGetProperty(hObject, propertyName, result, result.Length, out requiredSize, flags).ThrowOnError();
            return result;
        }

        /// <summary>
        /// Retrieves the value of a named property for a CNG object.
        /// </summary>
        /// <typeparam name="T">The type of struct to return the property value as.</typeparam>
        /// <param name="hObject">A handle that represents the CNG object to obtain the property value for.</param>
        /// <param name="propertyName">A pointer to a null-terminated Unicode string that contains the name of the property to retrieve. This can be one of the predefined <see cref="PropertyNames"/> or a custom property identifier.</param>
        /// <param name="flags">A set of flags that modify the behavior of this function. No flags are defined for this function.</param>
        /// <returns>The property value.</returns>
        public static T BCryptGetProperty<T>(SafeHandle hObject, string propertyName, BCryptGetPropertyFlags flags = BCryptGetPropertyFlags.None)
            where T : struct
        {
            byte[] value = BCryptGetProperty(hObject, propertyName, flags);
            T result = default(T);

            // Use a finally block so that we don't leak a GCHandle if
            // our thread is interrupted after the alloc and before we assign the variable.
            try
            {
            }
            finally
            {
                GCHandle bufferHandle = GCHandle.Alloc(value, GCHandleType.Pinned);
                try
                {
                    result = (T)Marshal.PtrToStructure(bufferHandle.AddrOfPinnedObject(), typeof(T));
                }
                finally
                {
                    bufferHandle.Free();
                }
            }

            return result;
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

        /// <summary>
        /// The identifiers for the algorithms defined within BCrypt itself.
        /// </summary>
        public static class AlgorithmIdentifiers
        {
            /// <summary>
            /// The triple data encryption standard symmetric encryption algorithm.
            /// </summary>
            public const string BCRYPT_3DES_ALGORITHM = "3DES";

            /// <summary>
            /// The 112-bit triple data encryption standard symmetric encryption algorithm.
            /// </summary>
            public const string BCRYPT_3DES_112_ALGORITHM = "3DES_112";

            /// <summary>
            /// The advanced encryption standard symmetric encryption algorithm.
            /// </summary>
            public const string BCRYPT_AES_ALGORITHM = "AES";

            /// <summary>
            /// The random-number generator algorithm.
            /// </summary>
            public const string BCRYPT_RNG_ALGORITHM = "RNG";

            /// <summary>
            /// The dual elliptic curve random-number generator algorithm.
            /// </summary>
            public const string BCRYPT_RNG_DUAL_EC_ALGORITHM = "DUALECRNG";

            /// <summary>
            /// The random-number generator algorithm suitable for DSA (Digital Signature Algorithm).
            /// </summary>
            public const string BCRYPT_RNG_FIPS186_DSA_ALGORITHM = "FIPS186DSARNG";

            // TODO: Define constants for the rest in https://msdn.microsoft.com/en-us/library/windows/desktop/aa375534(v=vs.85).aspx
        }

        /// <summary>
        /// Common property names to supply to <see cref="BCryptGetProperty(SafeHandle, string, BCryptGetPropertyFlags)"/>.
        /// </summary>
        /// <devremarks>
        /// Fill in summaries for each property as defined here: https://msdn.microsoft.com/en-us/library/windows/desktop/aa376211(v=vs.85).aspx
        /// </devremarks>
        public static class PropertyNames
        {
            public const string ObjectLength = "ObjectLength";
            public const string AlgorithmName = "AlgorithmName";
            public const string ProviderHandle = "ProviderHandle";
            public const string ChainingMode = "ChainingMode";

            /// <summary>
            /// The size, in bytes, of a cipher block for the algorithm. This property only applies to block cipher algorithms. This data type is a DWORD.
            /// </summary>
            public const string BlockLength = "BlockLength";
            public const string KeyLength = "KeyLength";
            public const string KeyObjectLength = "KeyObjectLength";
            public const string KeyStrength = "KeyStrength";
            public const string KeyLengths = "KeyLengths";
            public const string BlockSizeList = "BlockSizeList";
            public const string EffectiveKeyLength = "EffectiveKeyLength";
            public const string HashDigestLength = "HashDigestLength";
            public const string HashOIDList = "HashOIDList";
            public const string PaddingSchemes = "PaddingSchemes";
            public const string SignatureLength = "SignatureLength";
            public const string HashBlockLength = "HashBlockLength";
            public const string AuthTagLength = "AuthTagLength";
            public const string PrimitiveType = "PrimitiveType";
            public const string IsKeyedHash = "IsKeyedHash";
            public const string IsReusableHash = "IsReusableHash";
            public const string MessageBlockLength = "MessageBlockLength";
        }

        public static class SymmetricKeyBlobTypes
        {
            /// <summary>
            /// Import a symmetric key from an AES key–wrapped key BLOB. The hImportKey parameter must reference a valid BCRYPT_KEY_HANDLE pointer to the key encryption key.
            /// </summary>
            public const string BCRYPT_AES_WRAP_KEY_BLOB = "Rfc3565KeyWrapBlob";

            /// <summary>
            /// Import a symmetric key from a data BLOB. The pbInput parameter is a pointer to a BCRYPT_KEY_DATA_BLOB_HEADER structure immediately followed by the key BLOB.
            /// </summary>
            public const string BCRYPT_KEY_DATA_BLOB = "KeyDataBlob";

            /// <summary>
            /// Import a symmetric key BLOB in a format that is specific to a single CSP. Opaque BLOBs are not transferable and must be imported by using the same CSP that generated the BLOB. Opaque BLOBs are only intended to be used for interprocess transfer of keys and are not suitable to be persisted and read in across versions of a provider.
            /// </summary>
            public const string BCRYPT_OPAQUE_KEY_BLOB = "OpaqueKeyBlob";
        }

        public static class AsymmetricKeyBlobTypes
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
    }
}
