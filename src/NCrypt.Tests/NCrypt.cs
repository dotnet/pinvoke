// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

using System;
using System.Linq;
using PInvoke;
using Xunit;
using static PInvoke.NCrypt;

public class NCrypt
{
    [Fact]
    public void OpenStorageProvider()
    {
        using (var provider = NCryptOpenStorageProvider(KeyStorageProviders.MS_KEY_STORAGE_PROVIDER))
        {
        }
    }

    [Fact]
    public void CreatePersistedKey()
    {
        using (var provider = NCryptOpenStorageProvider(KeyStorageProviders.MS_KEY_STORAGE_PROVIDER))
        {
            using (var key = NCryptCreatePersistedKey(provider, BCrypt.AlgorithmIdentifiers.BCRYPT_ECDSA_P256_ALGORITHM))
            {
                NCryptFinalizeKey(key).ThrowOnError();
            }
        }
    }

    [Fact]
    public unsafe void ExportRSAPublicKey()
    {
        using (var provider = NCryptOpenStorageProvider(KeyStorageProviders.MS_KEY_STORAGE_PROVIDER))
        {
            using (var key = NCryptCreatePersistedKey(provider, BCrypt.AlgorithmIdentifiers.BCRYPT_RSA_ALGORITHM))
            {
                NCryptFinalizeKey(key).ThrowOnError();
                var exported = NCryptExportKey(key, SafeKeyHandle.Null, BCrypt.AsymmetricKeyBlobTypes.BCRYPT_RSAPUBLIC_BLOB, null);
                Assert.NotNull(exported.Array);
            }
        }
    }

    [Fact]
    public unsafe void EncryptDecryptRSA()
    {
        using (var provider = NCryptOpenStorageProvider(KeyStorageProviders.MS_KEY_STORAGE_PROVIDER))
        {
            using (var key = NCryptCreatePersistedKey(provider, BCrypt.AlgorithmIdentifiers.BCRYPT_RSA_ALGORITHM))
            {
                NCryptSetProperty(key, KeyStoragePropertyIdentifiers.NCRYPT_LENGTH_PROPERTY, 512);
                NCryptFinalizeKey(key).ThrowOnError();

                const NCryptEncryptFlags flags = NCryptEncryptFlags.NCRYPT_PAD_PKCS1_FLAG;
                byte[] plaintext = new byte[] { 0x1, 0x2, 0x3 };
                ArraySegment<byte> cipherText = NCryptEncrypt(key, plaintext, flags: flags);
                Assert.NotEqual(plaintext, cipherText.Array.Take(cipherText.Count));

                ArraySegment<byte> decryptedPlaintext = NCryptDecrypt(key, cipherText.ToArray(), flags: flags);
                Assert.Equal(plaintext, decryptedPlaintext.Take(decryptedPlaintext.Count));
            }
        }
    }

    [Fact]
    public void GetPropertyOfT()
    {
        using (var provider = NCryptOpenStorageProvider(KeyStorageProviders.MS_KEY_STORAGE_PROVIDER))
        {
            var actual = (KeyStorageImplementationType)NCryptGetProperty<int>(provider, KeyStoragePropertyIdentifiers.NCRYPT_IMPL_TYPE_PROPERTY);
            Assert.Equal(KeyStorageImplementationType.NCRYPT_IMPL_SOFTWARE_FLAG, actual);
        }
    }
}
