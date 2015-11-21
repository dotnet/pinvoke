// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using PInvoke;
using Xunit;
using static PInvoke.BCrypt;

public class BCrypt
{
    [Fact]
    public void BCryptGetPropertyOfT()
    {
        using (var provider = BCryptOpenAlgorithmProvider(AlgorithmIdentifiers.BCRYPT_AES_ALGORITHM))
        {
            var keyLengths = BCryptGetProperty<BCRYPT_KEY_LENGTHS_STRUCT>(provider, PropertyNames.KeyLengths);
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
        Assert.Equal(new[] { 8, 10, 12 }, keySizes.KeySizes);
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
    public void EncryptDecrypt_DefaultPadding()
    {
        using (var provider = BCryptOpenAlgorithmProvider(AlgorithmIdentifiers.BCRYPT_AES_ALGORITHM))
        {
            byte[] plainText = new byte[] { 0x3, 0x5, 0x8 };
            byte[] keyMaterial = new byte[128 / 8];
            byte[] cipherText;

            using (var key = BCryptGenerateSymmetricKey(provider, keyMaterial))
            {
                cipherText = BCryptEncrypt(key, plainText, IntPtr.Zero, null, BCryptEncryptFlags.BCRYPT_BLOCK_PADDING);
                Assert.NotEqual<byte>(plainText, cipherText);
            }

            using (var key = BCryptGenerateSymmetricKey(provider, keyMaterial))
            {
                byte[] decryptedText = BCryptDecrypt(key, cipherText, IntPtr.Zero, null, BCryptEncryptFlags.BCRYPT_BLOCK_PADDING);
                Assert.Equal<byte>(plainText, decryptedText);
            }
        }
    }

    [Fact]
    public void EncryptDecrypt_NoPadding()
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
                Assert.Equal(NTStatus.STATUS_INVALID_BUFFER_SIZE, BCryptEncrypt(key, plainText, plainText.Length, IntPtr.Zero, null, 0, null, 0, out cipherTextLength, BCryptEncryptFlags.None));

                // Now do our own padding (zeros).
                blockSize = BCryptGetProperty<int>(provider, PropertyNames.BlockLength);
                plainTextPadded = new byte[blockSize];
                Array.Copy(plainText, plainTextPadded, plainText.Length);
                BCryptEncrypt(key, plainTextPadded, plainTextPadded.Length, IntPtr.Zero, null, 0, null, 0, out cipherTextLength, BCryptEncryptFlags.None).ThrowOnError();
                cipherText = new byte[cipherTextLength];
                BCryptEncrypt(key, plainTextPadded, plainTextPadded.Length, IntPtr.Zero, null, 0, cipherText, cipherText.Length, out cipherTextLength, BCryptEncryptFlags.None).ThrowOnError();
                Assert.NotEqual<byte>(plainTextPadded, cipherText);
            }

            // We must renew the key because there are residual effects on it from encryption
            // that will prevent decryption from working.
            using (var key = BCryptGenerateSymmetricKey(provider, keyMaterial))
            {
                byte[] decryptedText = new byte[plainTextPadded.Length];
                int cbDecrypted;
                BCryptDecrypt(key, cipherText, cipherTextLength, IntPtr.Zero, null, 0, decryptedText, decryptedText.Length, out cbDecrypted, BCryptEncryptFlags.None).ThrowOnError();
                Assert.Equal(plainTextPadded.Length, cbDecrypted);
                Assert.Equal<byte>(plainTextPadded, decryptedText);
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
    public void SignHash()
    {
        using (var algorithm = BCryptOpenAlgorithmProvider(AlgorithmIdentifiers.BCRYPT_ECDSA_P256_ALGORITHM))
        {
            int keySize = GetMinimumKeySize(algorithm);
            using (var keyPair = BCryptGenerateKeyPair(algorithm, keySize))
            {
                BCryptFinalizeKeyPair(keyPair).ThrowOnError();
                byte[] hashData = SHA1.Create().ComputeHash(new byte[] { 0x1 });
                byte[] signature = BCryptSignHash(keyPair, hashData);
                NTStatus status = BCryptVerifySignature(keyPair, IntPtr.Zero, hashData, hashData.Length, signature, signature.Length);
                Assert.Equal(NTStatus.STATUS_SUCCESS, status);
                signature[0] = unchecked((byte)(signature[0] + 1));
                status = BCryptVerifySignature(keyPair, IntPtr.Zero, hashData, hashData.Length, signature, signature.Length);
                Assert.Equal(NTStatus.STATUS_INVALID_SIGNATURE, status);
            }
        }
    }

    [Fact]
    public void ImportKey()
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

    /// <summary>
    /// Gets the minimum length of a key (in bits).
    /// </summary>
    /// <param name="algorithm">The algorithm.</param>
    /// <returns>The length of the smallest key, in bits.</returns>
    private static int GetMinimumKeySize(SafeAlgorithmHandle algorithm)
    {
        var keyLengths = BCryptGetProperty<BCRYPT_KEY_LENGTHS_STRUCT>(algorithm, PropertyNames.KeyLengths);
        return keyLengths.MinLength;
    }
}
