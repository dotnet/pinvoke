// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using PInvoke;
using Xunit;
using Xunit.Abstractions;
using static PInvoke.BCrypt;

public class BCryptFacts
{
    private readonly ITestOutputHelper logger;

    public BCryptFacts(ITestOutputHelper logger)
    {
        this.logger = logger;
    }

    [Fact]
    public void BCryptGetPropertyOfT()
    {
        using (var provider = BCryptOpenAlgorithmProvider(AlgorithmIdentifiers.BCRYPT_AES_ALGORITHM))
        {
            var keyLengths = BCryptGetProperty<BCRYPT_KEY_LENGTHS_STRUCT>(provider, PropertyNames.BCRYPT_KEY_LENGTHS);
            Assert.Equal(128, keyLengths.MinLength);
            Assert.Equal(256, keyLengths.MaxLength);
            Assert.Equal(64, keyLengths.Increment);
        }
    }

    [Fact]
    public void KeySizes()
    {
        var keySizes = new BCRYPT_KEY_LENGTHS_STRUCT
        {
            MinLength = 8,
            MaxLength = 12,
            Increment = 2,
        };
        Assert.Equal(new[] { 8, 10, 12 }, keySizes);

        keySizes = new BCRYPT_KEY_LENGTHS_STRUCT
        {
            MinLength = 16,
            MaxLength = 16,
            Increment = 0,
        };
        Assert.Equal(new[] { 16 }, keySizes);
    }

    [Fact]
    public void TagLengths()
    {
        var tagSizes = new BCRYPT_AUTH_TAG_LENGTHS_STRUCT
        {
            dwMinLength = 8,
            dwMaxLength = 12,
            dwIncrement = 2,
        };
        Assert.Equal(new[] { 8, 10, 12 }, tagSizes);

        tagSizes = new BCRYPT_AUTH_TAG_LENGTHS_STRUCT
        {
            dwMinLength = 16,
            dwMaxLength = 16,
            dwIncrement = 0,
        };
        Assert.Equal(new[] { 16 }, tagSizes);
    }

    [Fact]
    public void GenRandom()
    {
        using (var provider = BCryptOpenAlgorithmProvider(AlgorithmIdentifiers.BCRYPT_RNG_ALGORITHM))
        {
            byte[] buffer = new byte[20];
            BCryptGenRandom(provider, buffer, 15).ThrowOnError();
            Assert.NotEqual(new byte[15], buffer.Take(15));
            Assert.Equal(new byte[5], buffer.Skip(15));
        }
    }

    [Fact]
    public void GenerateSymmetricKey()
    {
        using (var provider = BCryptOpenAlgorithmProvider(AlgorithmIdentifiers.BCRYPT_AES_ALGORITHM))
        {
            byte[] keyMaterial = new byte[128 / 8];
            using (var key = BCryptGenerateSymmetricKey(provider, keyMaterial))
            {
                Assert.NotNull(key);
            }
        }
    }

    [Fact]
    public unsafe void EncryptDecrypt_DefaultPadding()
    {
        using (var provider = BCryptOpenAlgorithmProvider(AlgorithmIdentifiers.BCRYPT_AES_ALGORITHM))
        {
            byte[] plainText = new byte[] { 0x3, 0x5, 0x8 };
            byte[] keyMaterial = new byte[128 / 8];
            byte[] cipherText;

            using (var key = BCryptGenerateSymmetricKey(provider, keyMaterial))
            {
                cipherText = BCryptEncrypt(key, plainText, null, null, BCryptEncryptFlags.BCRYPT_BLOCK_PADDING).ToArray();
                Assert.NotEqual<byte>(plainText, cipherText);
            }

            using (var key = BCryptGenerateSymmetricKey(provider, keyMaterial))
            {
                byte[] decryptedText = BCryptDecrypt(key, cipherText, null, null, BCryptEncryptFlags.BCRYPT_BLOCK_PADDING).ToArray();
                Assert.Equal<byte>(plainText, decryptedText);
            }
        }
    }

    [Fact]
    public unsafe void EncryptDecrypt_NoPadding()
    {
        using (var provider = BCryptOpenAlgorithmProvider(AlgorithmIdentifiers.BCRYPT_AES_ALGORITHM))
        {
            byte[] plainText = new byte[] { 0x3, 0x5, 0x8 };
            byte[] plainTextPadded;
            byte[] cipherText;
            int blockSize;
            int cipherTextLength;

            byte[] keyMaterial = new byte[128 / 8];
            using (var key = BCryptGenerateSymmetricKey(provider, keyMaterial))
            {
                // Verify that without padding, an error is returned.
                Assert.Equal<NTSTATUS>(NTSTATUS.Code.STATUS_INVALID_BUFFER_SIZE, BCryptEncrypt(key, plainText, plainText.Length, null, null, 0, null, 0, out cipherTextLength, BCryptEncryptFlags.None));

                // Now do our own padding (zeros).
                blockSize = BCryptGetProperty<int>(provider, PropertyNames.BCRYPT_BLOCK_LENGTH);
                plainTextPadded = new byte[blockSize];
                Array.Copy(plainText, plainTextPadded, plainText.Length);
                BCryptEncrypt(key, plainTextPadded, plainTextPadded.Length, null, null, 0, null, 0, out cipherTextLength, BCryptEncryptFlags.None).ThrowOnError();
                cipherText = new byte[cipherTextLength];
                BCryptEncrypt(key, plainTextPadded, plainTextPadded.Length, null, null, 0, cipherText, cipherText.Length, out cipherTextLength, BCryptEncryptFlags.None).ThrowOnError();
                Assert.NotEqual<byte>(plainTextPadded, cipherText);
            }

            // We must renew the key because there are residual effects on it from encryption
            // that will prevent decryption from working.
            using (var key = BCryptGenerateSymmetricKey(provider, keyMaterial))
            {
                byte[] decryptedText = new byte[plainTextPadded.Length];
                int cbDecrypted;
                BCryptDecrypt(key, cipherText, cipherTextLength, null, null, 0, decryptedText, decryptedText.Length, out cbDecrypted, BCryptEncryptFlags.None).ThrowOnError();
                Assert.Equal(plainTextPadded.Length, cbDecrypted);
                Assert.Equal<byte>(plainTextPadded, decryptedText);
            }
        }
    }

    [Fact]
    public unsafe void EncryptDecrypt_Pointers()
    {
        using (var provider = BCryptOpenAlgorithmProvider(AlgorithmIdentifiers.BCRYPT_AES_ALGORITHM))
        {
            byte[] plainText = new byte[] { 0x3, 0x5, 0x8 };
            byte[] plainTextPadded;
            byte[] cipherText;
            int blockSize;
            int cipherTextLength;

            byte[] keyMaterial = new byte[128 / 8];
            using (var key = BCryptGenerateSymmetricKey(provider, keyMaterial))
            {
                // Verify that without padding, an error is returned.
                Assert.Equal<NTSTATUS>(NTSTATUS.Code.STATUS_INVALID_BUFFER_SIZE, BCryptEncrypt(key, plainText, plainText.Length, null, null, 0, null, 0, out cipherTextLength, BCryptEncryptFlags.None));

                // Now do our own padding (zeros).
                blockSize = BCryptGetProperty<int>(provider, PropertyNames.BCRYPT_BLOCK_LENGTH);
                plainTextPadded = new byte[blockSize];
                Array.Copy(plainText, plainTextPadded, plainText.Length);
                BCryptEncrypt(
                    key,
                    new ArraySegment<byte>(plainTextPadded),
                    null,
                    null,
                    null,
                    out cipherTextLength,
                    BCryptEncryptFlags.None).ThrowOnError();

                cipherText = new byte[cipherTextLength];
                BCryptEncrypt(
                    key,
                    new ArraySegment<byte>(plainTextPadded),
                    null,
                    null,
                    new ArraySegment<byte>(cipherText),
                    out cipherTextLength,
                    BCryptEncryptFlags.None).ThrowOnError();

                Assert.NotEqual<byte>(plainTextPadded, cipherText);
            }

            // We must renew the key because there are residual effects on it from encryption
            // that will prevent decryption from working.
            using (var key = BCryptGenerateSymmetricKey(provider, keyMaterial))
            {
                byte[] decryptedText = new byte[plainTextPadded.Length];
                int cbDecrypted;
                BCryptDecrypt(
                    key,
                    new ArraySegment<byte>(cipherText),
                    null,
                    null,
                    new ArraySegment<byte>(decryptedText),
                    out cbDecrypted,
                    BCryptEncryptFlags.None).ThrowOnError();

                Assert.Equal(plainTextPadded.Length, cbDecrypted);
                Assert.Equal<byte>(plainTextPadded, decryptedText);
            }
        }
    }

    [Fact]
    public unsafe void EncryptDecrypt_PointerCornerCases()
    {
        using (var provider = BCryptOpenAlgorithmProvider(AlgorithmIdentifiers.BCRYPT_AES_ALGORITHM))
        {
            byte[] keyMaterial = new byte[128 / 8];
            using (var key = BCryptGenerateSymmetricKey(provider, keyMaterial))
            {
                int length;
                BCryptEncrypt(
                    key,
                    new ArraySegment<byte>(new byte[0]),
                    null,
                    default(ArraySegment<byte>),
                    new ArraySegment<byte>(new byte[1]),
                    out length,
                    BCryptEncryptFlags.None);
            }

            using (var key = BCryptGenerateSymmetricKey(provider, keyMaterial))
            {
                int length;
                BCryptEncrypt(
                    key,
                    new ArraySegment<byte>(new byte[0]),
                    null,
                    null,
                    new ArraySegment<byte>(new byte[1]),
                    out length,
                    BCryptEncryptFlags.None);
            }
        }
    }

    [Fact]
    public unsafe void EncryptDecrypt_EmptyBuffer()
    {
        using (var provider = BCryptOpenAlgorithmProvider(AlgorithmIdentifiers.BCRYPT_AES_ALGORITHM))
        {
            byte[] keyMaterial = new byte[128 / 8];
            using (var key = BCryptGenerateSymmetricKey(provider, keyMaterial))
            {
                var cipherText = BCryptEncrypt(
                     key,
                     new byte[0],
                     null,
                     new byte[keyMaterial.Length],
                     BCryptEncryptFlags.BCRYPT_BLOCK_PADDING);
                Assert.Equal(BCryptGetProperty<int>(key, PropertyNames.BCRYPT_BLOCK_LENGTH), cipherText.Count);

                var plainText = BCryptDecrypt(
                    key,
                    cipherText.ToArray(),
                    null,
                    new byte[keyMaterial.Length],
                    BCryptEncryptFlags.BCRYPT_BLOCK_PADDING);

                Assert.Equal(0, plainText.Count);
            }
        }
    }

    /// <summary>
    /// Demonstrates use of an authenticated block chaining mode
    /// that requires use of several more struct types than
    /// the default CBC mode for AES.
    /// </summary>
    [Fact]
    public unsafe void EncryptDecrypt_AesCcm()
    {
        var random = new Random();

        using (var provider = BCryptOpenAlgorithmProvider(AlgorithmIdentifiers.BCRYPT_AES_ALGORITHM))
        {
            BCryptSetProperty(provider, PropertyNames.BCRYPT_CHAINING_MODE, ChainingModes.Ccm);

            byte[] plainText;
            byte[] cipherText;

            var nonceBuffer = new byte[12];
            random.NextBytes(nonceBuffer);

            var tagLengths = BCryptGetProperty<BCRYPT_AUTH_TAG_LENGTHS_STRUCT>(provider, PropertyNames.BCRYPT_AUTH_TAG_LENGTH);
            var tagBuffer = new byte[tagLengths.dwMaxLength];

            int blockSize = BCryptGetProperty<int>(provider, PropertyNames.BCRYPT_BLOCK_LENGTH);
            plainText = new byte[blockSize];
            random.NextBytes(plainText);

            byte[] keyMaterial = new byte[blockSize];
            RandomNumberGenerator.Create().GetBytes(keyMaterial);

            using (var key = BCryptGenerateSymmetricKey(provider, keyMaterial))
            {
                var authInfo = BCRYPT_AUTHENTICATED_CIPHER_MODE_INFO.Create();
                fixed (byte* pTagBuffer = tagBuffer)
                fixed (byte* pNonce = nonceBuffer)
                {
                    authInfo.pbNonce = pNonce;
                    authInfo.cbNonce = nonceBuffer.Length;
                    authInfo.pbTag = pTagBuffer;
                    authInfo.cbTag = tagBuffer.Length;

                    // Mix up calling the IntPtr and native pointer overloads so we test both.
                    int cipherTextLength;
                    BCryptEncrypt(key, plainText, plainText.Length, &authInfo, null, 0, null, 0, out cipherTextLength, BCryptEncryptFlags.None).ThrowOnError();
                    cipherText = new byte[cipherTextLength];
                    BCryptEncrypt(key, plainText, plainText.Length, &authInfo, null, 0, cipherText, cipherText.Length, out cipherTextLength, BCryptEncryptFlags.None).ThrowOnError();
                }

                Assert.NotEqual<byte>(plainText, cipherText);
            }

            // Renew the key to prove we can decrypt it with a fresh key.
            using (var key = BCryptGenerateSymmetricKey(provider, keyMaterial))
            {
                byte[] decryptedText;

                var authInfo = BCRYPT_AUTHENTICATED_CIPHER_MODE_INFO.Create();
                fixed (byte* pTagBuffer = tagBuffer)
                fixed (byte* pNonce = nonceBuffer)
                {
                    authInfo.pbNonce = pNonce;
                    authInfo.cbNonce = nonceBuffer.Length;
                    authInfo.pbTag = pTagBuffer;
                    authInfo.cbTag = tagBuffer.Length;

                    int plainTextLength;
                    BCryptDecrypt(key, cipherText, cipherText.Length, &authInfo, null, 0, null, 0, out plainTextLength, BCryptEncryptFlags.None).ThrowOnError();
                    decryptedText = new byte[plainTextLength];
                    BCryptEncrypt(key, cipherText, cipherText.Length, &authInfo, null, 0, decryptedText, decryptedText.Length, out plainTextLength, BCryptEncryptFlags.None).ThrowOnError();
                    Array.Resize(ref decryptedText, plainTextLength);
                }

                Assert.Equal<byte>(plainText, decryptedText);
            }
        }
    }

    [Fact]
    public void Hash()
    {
        byte[] data = new byte[] { 0x3, 0x5, 0x8 };
        byte[] actualHash;
        using (var algorithm = BCryptOpenAlgorithmProvider(AlgorithmIdentifiers.BCRYPT_SHA1_ALGORITHM))
        {
            using (var hash = BCryptCreateHash(algorithm))
            {
                BCryptHashData(hash, data, 2).ThrowOnError();
                byte[] data2 = new byte[] { data[2] };
                BCryptHashData(hash, data2, data2.Length).ThrowOnError();
                actualHash = BCryptFinishHash(hash);
            }
        }

        byte[] expectedHash = SHA1.Create().ComputeHash(data);
        Assert.Equal(expectedHash, actualHash);
    }

    [Fact]
    public unsafe void SignHash()
    {
        using (var algorithm = BCryptOpenAlgorithmProvider(AlgorithmIdentifiers.BCRYPT_ECDSA_P256_ALGORITHM))
        {
            int keySize = GetMinimumKeySize(algorithm);
            using (var keyPair = BCryptGenerateKeyPair(algorithm, keySize))
            {
                BCryptFinalizeKeyPair(keyPair).ThrowOnError();
                byte[] hashData = SHA1.Create().ComputeHash(new byte[] { 0x1 });
                byte[] signature = BCryptSignHash(keyPair, hashData).ToArray();
                NTSTATUS status = BCryptVerifySignature(keyPair, null, hashData, hashData.Length, signature, signature.Length);
                Assert.Equal<NTSTATUS>(NTSTATUS.Code.STATUS_SUCCESS, status);
                signature[0] = unchecked((byte)(signature[0] + 1));
                status = BCryptVerifySignature(keyPair, null, hashData, hashData.Length, signature, signature.Length);
                Assert.Equal<NTSTATUS>(NTSTATUS.Code.STATUS_INVALID_SIGNATURE, status);
            }
        }
    }

    [Fact]
    public void ExportKey_ECDHPublic()
    {
        using (var algorithm = BCryptOpenAlgorithmProvider(AlgorithmIdentifiers.BCRYPT_ECDH_P256_ALGORITHM))
        {
            using (var key = BCryptGenerateKeyPair(algorithm, 256))
            {
                BCryptFinalizeKeyPair(key).ThrowOnError();
                var exported = BCryptExportKey(key, SafeKeyHandle.Null, AsymmetricKeyBlobTypes.BCRYPT_ECCPUBLIC_BLOB);
                Assert.NotNull(exported.Array);
            }
        }
    }

    [Fact]
    public void ImportKey_ECDHPublic()
    {
        const string ecdhPublicBase64 = "RUNLMSAAAAC4EtbkVuPCJQIzxjfb+NbYkxxN2FoMZnPxBdTp3GI4NiPQz3fdBaLtLBa95UuBWjnBnvF1q4vfKwdkSTe1ieIx";
        using (var algorithm = BCryptOpenAlgorithmProvider(AlgorithmIdentifiers.BCRYPT_ECDH_P256_ALGORITHM))
        {
            // This throws, as using NCrypt is required to import ECDH keys.
            Assert.Throws<NTStatusException>(() =>
                BCryptImportKey(
                    algorithm,
                    AsymmetricKeyBlobTypes.BCRYPT_ECCPUBLIC_BLOB,
                    Convert.FromBase64String(ecdhPublicBase64)));
        }
    }

    [Fact]
    public void ImportKey_AES()
    {
        using (var algorithm = BCryptOpenAlgorithmProvider(AlgorithmIdentifiers.BCRYPT_AES_ALGORITHM))
        {
            byte[] keyMaterial = new byte[GetMinimumKeySize(algorithm) / 8];
            var keyWithHeader = BCRYPT_KEY_DATA_BLOB_HEADER.InsertBeforeKey(keyMaterial);
            using (SafeKeyHandle key = BCryptImportKey(algorithm, SymmetricKeyBlobTypes.BCRYPT_KEY_DATA_BLOB, keyWithHeader))
            {
                Assert.NotNull(key);
                Assert.False(key.IsInvalid);
            }
        }
    }

    [Fact]
    public void IntPtrStructPropertyAccessor()
    {
        BCRYPT_AUTHENTICATED_CIPHER_MODE_INFO s = default(BCRYPT_AUTHENTICATED_CIPHER_MODE_INFO);
        s.pbAuthData_IntPtr = IntPtr.Zero;
        BCRYPT_OAEP_PADDING_INFO oaep = default(BCRYPT_OAEP_PADDING_INFO);
        oaep.pbLabel_IntPtr = IntPtr.Zero;
    }

    [Fact]
    public unsafe void PaddingInfo_Pinnable()
    {
        // These padding structures must be allowed to get their address
        // as they are always passed by pointer not by value.
        // This test ensures that they are pinnable, thus preventing anyone
        // from changing the char* field types to string for usability reasons
        // and unknowingly breaking pinnability.
        var oaepPaddingInfo = default(BCRYPT_OAEP_PADDING_INFO);
        void* pPaddingInfo = &oaepPaddingInfo;

        var pkcs1PaddingInfo = default(BCRYPT_PKCS1_PADDING_INFO);
        pPaddingInfo = &pkcs1PaddingInfo;

        var pssPaddingInfo = default(BCRYPT_PSS_PADDING_INFO);
        pPaddingInfo = &pssPaddingInfo;
    }

    [Fact]
    public unsafe void BCryptEnumAlgorithms_Test()
    {
        int algCount;
        BCRYPT_ALGORITHM_IDENTIFIER* algList;
        BCryptEnumAlgorithms(
            AlgorithmOperations.BCRYPT_HASH_OPERATION | AlgorithmOperations.BCRYPT_RNG_OPERATION,
            out algCount,
            out algList).ThrowOnError();
        Assert.NotEqual(0, algCount);
        for (int i = 0; i < algCount; i++)
        {
            this.logger.WriteLine(algList[i].Name);
        }

        BCryptFreeBuffer(algList);
    }

    [Fact]
    public void AddContextFunction()
    {
        NTSTATUS status = BCryptAddContextFunction(
            ConfigurationTable.CRYPT_LOCAL,
            null,
            InterfaceIdentifiers.BCRYPT_CIPHER_INTERFACE,
            null,
            0);
        Assert.Equal<NTSTATUS>(NTSTATUS.Code.STATUS_INVALID_PARAMETER, status);
    }

    /// <summary>
    /// Gets the minimum length of a key (in bits).
    /// </summary>
    /// <param name="algorithm">The algorithm.</param>
    /// <returns>The length of the smallest key, in bits.</returns>
    private static int GetMinimumKeySize(SafeAlgorithmHandle algorithm)
    {
        var keyLengths = BCryptGetProperty<BCRYPT_KEY_LENGTHS_STRUCT>(algorithm, PropertyNames.BCRYPT_KEY_LENGTHS);
        return keyLengths.MinLength;
    }
}
