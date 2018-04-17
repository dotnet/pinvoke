// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Linq;
using System.Security.Cryptography;
using PInvoke;
using Xunit;
using Xunit.Abstractions;
using static PInvoke.NCrypt;

public class NCryptFacts
{
    private readonly ITestOutputHelper logger;

    public NCryptFacts(ITestOutputHelper logger)
    {
        this.logger = logger;
    }

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
    public void NCryptDeleteKey_Test()
    {
        using (var provider = NCryptOpenStorageProvider(KeyStorageProviders.MS_KEY_STORAGE_PROVIDER))
        {
            string keyName = $"PInvokeTest_{Guid.NewGuid():N}";
            using (var key = NCryptCreatePersistedKey(provider, BCrypt.AlgorithmIdentifiers.BCRYPT_ECDSA_P256_ALGORITHM, keyName))
            {
                NCryptFinalizeKey(key).ThrowOnError();

                // TODO: add test to enumerate named keys before and after deleting this one.
                NCryptDeleteKey(key).ThrowOnError();
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
    public void ExportKey_ECDHPublic()
    {
        using (var provider = NCryptOpenStorageProvider(KeyStorageProviders.MS_KEY_STORAGE_PROVIDER))
        {
            using (var key = NCryptCreatePersistedKey(
                provider,
                BCrypt.AlgorithmIdentifiers.BCRYPT_ECDH_P256_ALGORITHM))
            {
                NCryptFinalizeKey(key).ThrowOnError();
                var exported = NCryptExportKey(key, SafeKeyHandle.Null, AsymmetricKeyBlobTypes.BCRYPT_ECCPUBLIC_BLOB, IntPtr.Zero);
                Assert.NotNull(exported.Array);
            }
        }
    }

    [Fact]
    public void ImportKey_ECDHPublic()
    {
        const string ecdhPublicBase64 = "RUNLMSAAAAC4EtbkVuPCJQIzxjfb+NbYkxxN2FoMZnPxBdTp3GI4NiPQz3fdBaLtLBa95UuBWjnBnvF1q4vfKwdkSTe1ieIx";
        using (var provider = NCryptOpenStorageProvider(KeyStorageProviders.MS_KEY_STORAGE_PROVIDER))
        {
            using (var key = NCryptImportKey(
                provider,
                SafeKeyHandle.Null,
                AsymmetricKeyBlobTypes.BCRYPT_ECCPUBLIC_BLOB,
                IntPtr.Zero,
                Convert.FromBase64String(ecdhPublicBase64)))
            {
                Assert.NotNull(key);
                Assert.False(key.IsInvalid);
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
            var actual = (KeyStoragePropertyValues.NCRYPT_IMPL_TYPE_PROPERTY)NCryptGetProperty<int>(provider, KeyStoragePropertyIdentifiers.NCRYPT_IMPL_TYPE_PROPERTY);
            Assert.Equal(KeyStoragePropertyValues.NCRYPT_IMPL_TYPE_PROPERTY.NCRYPT_IMPL_SOFTWARE_FLAG, actual);
        }
    }

    [Fact]
    public unsafe void NCryptEnumAlgorithms_Test()
    {
        using (var provider = NCryptOpenStorageProvider(KeyStorageProviders.MS_KEY_STORAGE_PROVIDER))
        {
            int algCount;
            NCryptAlgorithmName* algList;
            NCryptEnumAlgorithms(
                provider,
                AlgorithmOperations.NCRYPT_ASYMMETRIC_ENCRYPTION_OPERATION | AlgorithmOperations.NCRYPT_KEY_DERIVATION_OPERATION,
                out algCount,
                out algList).ThrowOnError();
            Assert.NotEqual(0, algCount);
            for (int i = 0; i < algCount; i++)
            {
                this.logger.WriteLine(algList[i].Name);
            }

            NCryptFreeBuffer(algList).ThrowOnError();
        }
    }

    [Fact]
    public unsafe void NCryptEnumStorageProviders_Test()
    {
        int providerCount;
        NCryptProviderName* providerList;
        NCryptEnumStorageProviders(
            out providerCount,
            out providerList).ThrowOnError();
        Assert.NotEqual(0, providerCount);
        for (int i = 0; i < providerCount; i++)
        {
            this.logger.WriteLine("{0}: {1}", providerList[i].Name, providerList[i].Comment);
        }

        NCryptFreeBuffer(providerList).ThrowOnError();
    }

    [Fact]
    public void NCryptIsAlgSupported_Test()
    {
        using (var provider = NCryptOpenStorageProvider(KeyStorageProviders.MS_KEY_STORAGE_PROVIDER))
        {
            Assert.Equal(SECURITY_STATUS.NTE_NOT_SUPPORTED, NCryptIsAlgSupported(provider, "Foo"));
            Assert.Equal(SECURITY_STATUS.ERROR_SUCCESS, NCryptIsAlgSupported(provider, BCrypt.AlgorithmIdentifiers.BCRYPT_RSA_ALGORITHM));
        }
    }

    [Fact]
    public unsafe void NCryptEnumKeys_Test()
    {
        using (var provider = NCryptOpenStorageProvider(KeyStorageProviders.MS_KEY_STORAGE_PROVIDER))
        {
            const string scope = null;
            NCryptKeyName* keyName;
            void* enumState = null;
            SECURITY_STATUS status = NCryptEnumKeys(provider, scope, out keyName, ref enumState);
            while (status == SECURITY_STATUS.ERROR_SUCCESS)
            {
                this.logger.WriteLine($"{keyName->Name} ({keyName->Algid})");

                if (keyName->Name.StartsWith("PclCrypto_"))
                {
                    using (var key = NCryptOpenKey(provider, *keyName))
                    {
                        NCryptDeleteKey(key).ThrowOnError();
                        key.SetHandleAsInvalid();
                    }
                }

                NCryptFreeBuffer(keyName).ThrowOnError();
                status = NCryptEnumKeys(provider, scope, out keyName, ref enumState);
            }

            if (enumState != null)
            {
                NCryptFreeBuffer(enumState).ThrowOnError();
            }

            if (status != SECURITY_STATUS.NTE_NO_MORE_ITEMS)
            {
                status.ThrowOnError();
            }
        }
    }

    private static int GetMinimumKeySize(SafeKeyHandle key)
    {
        var keyLengths = NCryptGetProperty<NCRYPT_SUPPORTED_LENGTHS>(key, KeyStoragePropertyIdentifiers.NCRYPT_LENGTHS_PROPERTY);
        return keyLengths.dwMinLength;
    }
}
