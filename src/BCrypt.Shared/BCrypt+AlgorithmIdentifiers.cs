// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    /// <content>
    /// Contains the <see cref="AlgorithmIdentifiers"/> nested type.
    /// </content>
    public static partial class BCrypt
    {
        /// <summary>
        /// The identifiers for the algorithms defined within BCrypt itself.
        /// </summary>
        public static class AlgorithmIdentifiers
        {
            /// <summary>
            /// The triple data encryption standard symmetric encryption algorithm.
            /// Standard: SP800-67, SP800-38A
            /// </summary>
            public const string BCRYPT_3DES_ALGORITHM = "3DES";

            /// <summary>
            /// The 112-bit triple data encryption standard symmetric encryption algorithm.
            /// Standard: SP800-67, SP800-38A
            /// </summary>
            public const string BCRYPT_3DES_112_ALGORITHM = "3DES_112";

            /// <summary>
            /// The advanced encryption standard symmetric encryption algorithm.
            /// Standard: FIPS 197
            /// </summary>
            public const string BCRYPT_AES_ALGORITHM = "AES";

            /// <summary>
            /// The advanced encryption standard (AES) cipher based message authentication code (CMAC) symmetric encryption algorithm.
            /// Standard: SP 800-38B
            /// Windows 8:  Support for this algorithm begins.
            /// </summary>
            public const string BCRYPT_AES_CMAC_ALGORITHM = "AES-CMAC";

            /// <summary>
            /// The advanced encryption standard (AES) Galois message authentication code (GMAC) symmetric encryption algorithm.
            /// Standard: SP800-38D
            /// Windows Vista:  This algorithm is supported beginning with Windows Vista with SP1.
            /// </summary>
            public const string BCRYPT_AES_GMAC_ALGORITHM = "AES-GMAC";

            /// <summary>
            /// Crypto API (CAPI) key derivation function algorithm. Used by the BCryptKeyDerivation and NCryptKeyDerivation functions.
            /// </summary>
            public const string BCRYPT_CAPI_KDF_ALGORITHM = "CAPI_KDF";

            /// <summary>
            /// The data encryption standard symmetric encryption algorithm.
            /// Standard: FIPS 46-3, FIPS 81
            /// </summary>
            public const string BCRYPT_DES_ALGORITHM = "DES";

            /// <summary>
            /// The extended data encryption standard symmetric encryption algorithm.
            /// Standard: None
            /// </summary>
            public const string BCRYPT_DESX_ALGORITHM = "DESX";

            /// <summary>
            /// The Diffie-Hellman key exchange algorithm.
            /// Standard: PKCS #3
            /// </summary>
            public const string BCRYPT_DH_ALGORITHM = "DH";

            /// <summary>
            /// The digital signature algorithm.
            /// Standard: FIPS 186-2
            /// Windows 8:  Beginning with Windows 8, this algorithm supports FIPS 186-3. Keys less than or equal to 1024 bits adhere to FIPS 186-2 and keys greater than 1024 to FIPS 186-3.
            /// </summary>
            public const string BCRYPT_DSA_ALGORITHM = "DSA";

            /// <summary>
            /// The 256-bit prime elliptic curve Diffie-Hellman key exchange algorithm.
            /// Standard: SP800-56A
            /// </summary>
            public const string BCRYPT_ECDH_P256_ALGORITHM = "ECDH_P256";

            /// <summary>
            /// The 384-bit prime elliptic curve Diffie-Hellman key exchange algorithm.
            /// Standard: SP800-56A
            /// </summary>
            public const string BCRYPT_ECDH_P384_ALGORITHM = "ECDH_P384";

            /// <summary>
            /// The 521-bit prime elliptic curve Diffie-Hellman key exchange algorithm.
            /// Standard: SP800-56A
            /// </summary>
            public const string BCRYPT_ECDH_P521_ALGORITHM = "ECDH_P521";

            /// <summary>
            /// The 256-bit prime elliptic curve digital signature algorithm (FIPS 186-2).
            /// Standard: FIPS 186-2, X9.62
            /// </summary>
            public const string BCRYPT_ECDSA_P256_ALGORITHM = "ECDSA_P256";

            /// <summary>
            /// The 384-bit prime elliptic curve digital signature algorithm (FIPS 186-2).
            /// Standard: FIPS 186-2, X9.62
            /// </summary>
            public const string BCRYPT_ECDSA_P384_ALGORITHM = "ECDSA_P384";

            /// <summary>
            /// The 521-bit prime elliptic curve digital signature algorithm (FIPS 186-2).
            /// Standard: FIPS 186-2, X9.62
            /// </summary>
            public const string BCRYPT_ECDSA_P521_ALGORITHM = "ECDSA_P521";

            /// <summary>
            /// The MD2 hash algorithm.
            /// Standard: RFC 1319
            /// </summary>
            public const string BCRYPT_MD2_ALGORITHM = "MD2";

            /// <summary>
            /// The MD4 hash algorithm.
            /// Standard: RFC 1320
            /// </summary>
            public const string BCRYPT_MD4_ALGORITHM = "MD4";

            /// <summary>
            /// The MD5 hash algorithm.
            /// Standard: RFC 1321
            /// </summary>
            public const string BCRYPT_MD5_ALGORITHM = "MD5";

            /// <summary>
            /// The RC2 block symmetric encryption algorithm.
            /// Standard: RFC 2268
            /// </summary>
            public const string BCRYPT_RC2_ALGORITHM = "RC2";

            /// <summary>
            /// The RC4 symmetric encryption algorithm.
            /// Standard: Various
            /// </summary>
            public const string BCRYPT_RC4_ALGORITHM = "RC4";

            /// <summary>
            /// The random-number generator algorithm.
            /// Standard: FIPS 186-2, FIPS 140-2, NIST SP 800-90
            /// Note  Beginning with Windows Vista with SP1 and Windows Server 2008, the random number generator is based on the AES counter mode specified in the NIST SP 800-90 standard.
            /// Windows Vista:  The random number generator is based on the hash-based random number generator specified in the FIPS 186-2 standard.
            /// Windows 8:  Beginning with Windows 8, the RNG algorithm supports FIPS 186-3. Keys less than or equal to 1024 bits adhere to FIPS 186-2 and keys greater than 1024 to FIPS 186-3.
            /// </summary>
            public const string BCRYPT_RNG_ALGORITHM = "RNG";

            /// <summary>
            /// The dual elliptic curve random-number generator algorithm.
            /// Standard: SP800-90
            /// Windows 8:  Beginning with Windows 8, the EC RNG algorithm supports FIPS 186-3. Keys less than or equal to 1024 bits adhere to FIPS 186-2 and keys greater than 1024 to FIPS 186-3.
            /// Windows 10:  Beginning with Windows 10, the dual elliptic curve random number generator algorithm has been removed. Existing uses of this algorithm will continue to work; however, the random number generator is based on the AES counter mode specified in the NIST SP 800-90 standard. New code should use BCRYPT_RNG_ALGORITHM, and it is recommended that existing code be changed to use BCRYPT_RNG_ALGORITHM.
            /// </summary>
            public const string BCRYPT_RNG_DUAL_EC_ALGORITHM = "DUALECRNG";

            /// <summary>
            /// The random-number generator algorithm suitable for DSA (Digital Signature Algorithm).
            /// Standard: FIPS 186-2
            /// Windows 8:  Support for FIPS 186-3 begins.
            /// </summary>
            public const string BCRYPT_RNG_FIPS186_DSA_ALGORITHM = "FIPS186DSARNG";

            /// <summary>
            /// The RSA public key algorithm.
            /// Standard: PKCS #1 v1.5 and v2.0.
            /// </summary>
            public const string BCRYPT_RSA_ALGORITHM = "RSA";

            /// <summary>
            /// The RSA signature algorithm. This algorithm is not currently supported. You can use the BCRYPT_RSA_ALGORITHM algorithm to perform RSA signing operations.
            /// Standard: PKCS #1 v1.5 and v2.0.
            /// </summary>
            public const string BCRYPT_RSA_SIGN_ALGORITHM = "RSA_SIGN";

            /// <summary>
            /// The 160-bit secure hash algorithm.
            /// Standard: FIPS 180-2, FIPS 198
            /// </summary>
            public const string BCRYPT_SHA1_ALGORITHM = "SHA1";

            /// <summary>
            /// The 256-bit secure hash algorithm.
            /// Standard: FIPS 180-2, FIPS 198
            /// </summary>
            public const string BCRYPT_SHA256_ALGORITHM = "SHA256";

            /// <summary>
            /// The 384-bit secure hash algorithm.
            /// Standard: FIPS 180-2, FIPS 198
            /// </summary>
            public const string BCRYPT_SHA384_ALGORITHM = "SHA384";

            /// <summary>
            /// The 512-bit secure hash algorithm.
            /// Standard: FIPS 180-2, FIPS 198
            /// </summary>
            public const string BCRYPT_SHA512_ALGORITHM = "SHA512";

            /// <summary>
            /// Counter mode, hash-based message authentication code (HMAC) key derivation function algorithm. Used by the BCryptKeyDerivation and NCryptKeyDerivation functions.
            /// </summary>
            public const string BCRYPT_SP800108_CTR_HMAC_ALGORITHM = "SP800_108_CTR_HMAC";

            /// <summary>
            /// SP800-56A key derivation function algorithm. Used by the BCryptKeyDerivation and NCryptKeyDerivation functions.
            /// </summary>
            public const string BCRYPT_SP80056A_CONCAT_ALGORITHM = "SP800_56A_CONCAT";

            /// <summary>
            /// Password-based key derivation function 2 (PBKDF2) algorithm. Used by the BCryptKeyDerivation and NCryptKeyDerivation functions.
            /// </summary>
            public const string BCRYPT_PBKDF2_ALGORITHM = "PBKDF2";
        }
    }
}
