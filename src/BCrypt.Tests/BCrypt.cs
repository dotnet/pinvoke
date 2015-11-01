// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

using System;
using System.Linq;
using System.Runtime.InteropServices;
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
            int cipherTextLength;

            using (var key = BCryptGenerateSymmetricKey(provider, keyMaterial))
            {
                BCryptEncrypt(key, plainText, plainText.Length, IntPtr.Zero, null, 0, null, 0, out cipherTextLength, BCryptEncryptFlags.BCRYPT_BLOCK_PADDING).ThrowOnError();
                cipherText = new byte[cipherTextLength];
                BCryptEncrypt(key, plainText, plainText.Length, IntPtr.Zero, null, 0, cipherText, cipherText.Length, out cipherTextLength, BCryptEncryptFlags.BCRYPT_BLOCK_PADDING).ThrowOnError();
                Assert.NotEqual<byte>(plainText, cipherText);
            }

            using (var key = BCryptGenerateSymmetricKey(provider, keyMaterial))
            {
                byte[] decryptedText = new byte[plainText.Length];
                int cbDecrypted;
                BCryptDecrypt(key, cipherText, cipherTextLength, IntPtr.Zero, null, 0, decryptedText, decryptedText.Length, out cbDecrypted, BCryptEncryptFlags.BCRYPT_BLOCK_PADDING).ThrowOnError();

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

    private static int GetMinimumKeySize(SafeAlgorithmHandle algorithm)
    {
        var keyLengths = BCryptGetProperty<BCRYPT_KEY_LENGTHS_STRUCT>(algorithm, PropertyNames.KeyLengths);
        return keyLengths.MinLength;
    }
}
