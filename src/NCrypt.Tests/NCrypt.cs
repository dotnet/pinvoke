// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

using System;
using System.Linq;
using System.Security.Cryptography;
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
    public unsafe void ExportImport_RSAPublicKey()
    {
        using (var provider = NCryptOpenStorageProvider(KeyStorageProviders.MS_KEY_STORAGE_PROVIDER))
        {
            using (var key = NCryptCreatePersistedKey(provider, BCrypt.AlgorithmIdentifiers.BCRYPT_RSA_ALGORITHM))
            {
                NCryptFinalizeKey(key).ThrowOnError();
                const string blobType = AsymmetricKeyBlobTypes.BCRYPT_RSAPUBLIC_BLOB;
                var exportedPublicKey = NCryptExportKey(key, null, blobType);
                Assert.NotNull(exportedPublicKey.Array);

                using (var importedPublicKey = NCryptImportKey(provider, null, blobType, null, exportedPublicKey.ToArray()))
                {
                }
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
    public unsafe void SignHash()
    {
        using (var provider = NCryptOpenStorageProvider(KeyStorageProviders.MS_KEY_STORAGE_PROVIDER))
        {
            using (var keyPair = NCryptCreatePersistedKey(provider, BCrypt.AlgorithmIdentifiers.BCRYPT_RSA_ALGORITHM))
            {
                int keySize = GetMinimumKeySize(keyPair);
                NCryptSetProperty(keyPair, KeyStoragePropertyIdentifiers.NCRYPT_LENGTH_PROPERTY, keySize);
                NCryptFinalizeKey(keyPair).ThrowOnError();
                byte[] hashData = SHA1.Create().ComputeHash(new byte[] { 0x1 });
                var flags = NCryptSignHashFlags.BCRYPT_PAD_PKCS1;
                fixed (char* pAlgorithm = BCrypt.AlgorithmIdentifiers.BCRYPT_SHA1_ALGORITHM.ToCharArrayWithNullTerminator())
                {
                    var paddingInfo = new BCrypt.BCRYPT_PKCS1_PADDING_INFO()
                    {
                        pszAlgId = pAlgorithm,
                    };
                    byte[] signature = NCryptSignHash(keyPair, &paddingInfo, hashData, flags).ToArray();
                    bool valid = NCryptVerifySignature(keyPair, &paddingInfo, hashData, signature, flags);
                    Assert.True(valid);
                    signature[0] = unchecked((byte)(signature[0] + 1));
                    valid = NCryptVerifySignature(keyPair, &paddingInfo, hashData, signature, flags);
                    Assert.False(valid);
                }
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

    private static int GetMinimumKeySize(SafeKeyHandle algorithm)
    {
        var keyLengths = NCryptGetProperty<NCRYPT_SUPPORTED_LENGTHS>(algorithm, KeyStoragePropertyIdentifiers.NCRYPT_LENGTHS_PROPERTY);
        return keyLengths.dwMinLength;
    }
}
