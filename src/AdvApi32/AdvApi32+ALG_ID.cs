// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PInvoke
{
    using System;

    /// <content>
    /// Contains the <see cref="ALG_ID"/> nested type.
    /// </content>
    public static partial class AdvApi32
    {
        /// <summary>
        ///     Hashing Algorithms.
        /// </summary>
        public enum ALG_ID
        {
            CALG_MD2 = AlgorithmClasses.ALG_CLASS_HASH | AlgorithmTypes.ALG_TYPE_ANY | AlgorithmSubIds.ALG_SID_MD2,
            CALG_MD4 = AlgorithmClasses.ALG_CLASS_HASH | AlgorithmTypes.ALG_TYPE_ANY | AlgorithmSubIds.ALG_SID_MD4,
            CALG_MD5 = AlgorithmClasses.ALG_CLASS_HASH | AlgorithmTypes.ALG_TYPE_ANY | AlgorithmSubIds.ALG_SID_MD5,
            CALG_SHA = AlgorithmClasses.ALG_CLASS_HASH | AlgorithmTypes.ALG_TYPE_ANY | AlgorithmSubIds.ALG_SID_SHA,
            CALG_SHA1 = AlgorithmClasses.ALG_CLASS_HASH | AlgorithmTypes.ALG_TYPE_ANY | AlgorithmSubIds.ALG_SID_SHA1,
            [Obsolete("Deprecated. Do not use.")]
            CALG_MAC = AlgorithmClasses.ALG_CLASS_HASH | AlgorithmTypes.ALG_TYPE_ANY | AlgorithmSubIds.ALG_SID_MAC,
            CALG_RSA_SIGN = AlgorithmClasses.ALG_CLASS_SIGNATURE | AlgorithmTypes.ALG_TYPE_RSA | AlgorithmSubIds.ALG_SID_RSA_ANY,
            CALG_DSS_SIGN = AlgorithmClasses.ALG_CLASS_SIGNATURE | AlgorithmTypes.ALG_TYPE_DSS | AlgorithmSubIds.ALG_SID_DSS_ANY,
            CALG_NO_SIGN = AlgorithmClasses.ALG_CLASS_SIGNATURE | AlgorithmTypes.ALG_TYPE_ANY | AlgorithmSubIds.ALG_SID_ANY,
            CALG_RSA_KEYX = AlgorithmClasses.ALG_CLASS_KEY_EXCHANGE | AlgorithmTypes.ALG_TYPE_RSA | AlgorithmSubIds.ALG_SID_RSA_ANY,
            CALG_DES = AlgorithmClasses.ALG_CLASS_DATA_ENCRYPT | AlgorithmTypes.ALG_TYPE_BLOCK | AlgorithmSubIds.ALG_SID_DES,
            CALG_3DES_112 = AlgorithmClasses.ALG_CLASS_DATA_ENCRYPT | AlgorithmTypes.ALG_TYPE_BLOCK | AlgorithmSubIds.ALG_SID_3DES_112,
            CALG_3DES = AlgorithmClasses.ALG_CLASS_DATA_ENCRYPT | AlgorithmTypes.ALG_TYPE_BLOCK | AlgorithmSubIds.ALG_SID_3DES,
            CALG_DESX = AlgorithmClasses.ALG_CLASS_DATA_ENCRYPT | AlgorithmTypes.ALG_TYPE_BLOCK | AlgorithmSubIds.ALG_SID_DESX,
            CALG_RC2 = AlgorithmClasses.ALG_CLASS_DATA_ENCRYPT | AlgorithmTypes.ALG_TYPE_BLOCK | AlgorithmSubIds.ALG_SID_RC2,
            CALG_RC4 = AlgorithmClasses.ALG_CLASS_DATA_ENCRYPT | AlgorithmTypes.ALG_TYPE_STREAM | AlgorithmSubIds.ALG_SID_RC4,
            CALG_SEAL = AlgorithmClasses.ALG_CLASS_DATA_ENCRYPT | AlgorithmTypes.ALG_TYPE_STREAM | AlgorithmSubIds.ALG_SID_SEAL,
            CALG_DH_SF = AlgorithmClasses.ALG_CLASS_KEY_EXCHANGE | AlgorithmTypes.ALG_TYPE_DH | AlgorithmSubIds.ALG_SID_DH_SANDF,
            CALG_DH_EPHEM = AlgorithmClasses.ALG_CLASS_KEY_EXCHANGE | AlgorithmTypes.ALG_TYPE_DH | AlgorithmSubIds.ALG_SID_DH_EPHEM,
            CALG_AGREEDKEY_ANY = AlgorithmClasses.ALG_CLASS_KEY_EXCHANGE | AlgorithmTypes.ALG_TYPE_DH | AlgorithmSubIds.ALG_SID_AGREED_KEY_ANY,
            CALG_KEA_KEYX = AlgorithmClasses.ALG_CLASS_KEY_EXCHANGE | AlgorithmTypes.ALG_TYPE_DH | AlgorithmSubIds.ALG_SID_KEA,
            CALG_HUGHES_MD5 = AlgorithmClasses.ALG_CLASS_KEY_EXCHANGE | AlgorithmTypes.ALG_TYPE_ANY | AlgorithmSubIds.ALG_SID_MD5,
            CALG_SKIPJACK = AlgorithmClasses.ALG_CLASS_DATA_ENCRYPT | AlgorithmTypes.ALG_TYPE_BLOCK | AlgorithmSubIds.ALG_SID_SKIPJACK,
            CALG_TEK = AlgorithmClasses.ALG_CLASS_DATA_ENCRYPT | AlgorithmTypes.ALG_TYPE_BLOCK | AlgorithmSubIds.ALG_SID_TEK,
            [Obsolete("Deprecated. Do not use.")]
            CALG_CYLINK_MEK = AlgorithmClasses.ALG_CLASS_DATA_ENCRYPT | AlgorithmTypes.ALG_TYPE_BLOCK | AlgorithmSubIds.ALG_SID_CYLINK_MEK,
            CALG_SSL3_SHAMD5 = AlgorithmClasses.ALG_CLASS_HASH | AlgorithmTypes.ALG_TYPE_ANY | AlgorithmSubIds.ALG_SID_SSL3SHAMD5,
            CALG_SSL3_MASTER = AlgorithmClasses.ALG_CLASS_MSG_ENCRYPT | AlgorithmTypes.ALG_TYPE_SECURECHANNEL | AlgorithmSubIds.ALG_SID_SSL3_MASTER,
            CALG_SCHANNEL_MASTER_HASH = AlgorithmClasses.ALG_CLASS_MSG_ENCRYPT | AlgorithmTypes.ALG_TYPE_SECURECHANNEL | AlgorithmSubIds.ALG_SID_SCHANNEL_MASTER_HASH,
            CALG_SCHANNEL_MAC_KEY = AlgorithmClasses.ALG_CLASS_MSG_ENCRYPT | AlgorithmTypes.ALG_TYPE_SECURECHANNEL | AlgorithmSubIds.ALG_SID_SCHANNEL_MAC_KEY,
            CALG_SCHANNEL_ENC_KEY = AlgorithmClasses.ALG_CLASS_MSG_ENCRYPT | AlgorithmTypes.ALG_TYPE_SECURECHANNEL | AlgorithmSubIds.ALG_SID_SCHANNEL_ENC_KEY,
            CALG_PCT1_MASTER = AlgorithmClasses.ALG_CLASS_MSG_ENCRYPT | AlgorithmTypes.ALG_TYPE_SECURECHANNEL | AlgorithmSubIds.ALG_SID_PCT1_MASTER,
            CALG_SSL2_MASTER = AlgorithmClasses.ALG_CLASS_MSG_ENCRYPT | AlgorithmTypes.ALG_TYPE_SECURECHANNEL | AlgorithmSubIds.ALG_SID_SSL2_MASTER,
            CALG_TLS1_MASTER = AlgorithmClasses.ALG_CLASS_MSG_ENCRYPT | AlgorithmTypes.ALG_TYPE_SECURECHANNEL | AlgorithmSubIds.ALG_SID_TLS1_MASTER,
            CALG_RC5 = AlgorithmClasses.ALG_CLASS_DATA_ENCRYPT | AlgorithmTypes.ALG_TYPE_BLOCK | AlgorithmSubIds.ALG_SID_RC5,
            CALG_HMAC = AlgorithmClasses.ALG_CLASS_HASH | AlgorithmTypes.ALG_TYPE_ANY | AlgorithmSubIds.ALG_SID_HMAC,
            CALG_TLS1PRF = AlgorithmClasses.ALG_CLASS_HASH | AlgorithmTypes.ALG_TYPE_ANY | AlgorithmSubIds.ALG_SID_TLS1PRF,
            CALG_HASH_REPLACE_OWF = AlgorithmClasses.ALG_CLASS_HASH | AlgorithmTypes.ALG_TYPE_ANY | AlgorithmSubIds.ALG_SID_HASH_REPLACE_OWF,
            CALG_AES_128 = AlgorithmClasses.ALG_CLASS_DATA_ENCRYPT | AlgorithmTypes.ALG_TYPE_BLOCK | AlgorithmSubIds.ALG_SID_AES_128,
            CALG_AES_192 = AlgorithmClasses.ALG_CLASS_DATA_ENCRYPT | AlgorithmTypes.ALG_TYPE_BLOCK | AlgorithmSubIds.ALG_SID_AES_192,
            CALG_AES_256 = AlgorithmClasses.ALG_CLASS_DATA_ENCRYPT | AlgorithmTypes.ALG_TYPE_BLOCK | AlgorithmSubIds.ALG_SID_AES_256,
            CALG_AES = AlgorithmClasses.ALG_CLASS_DATA_ENCRYPT | AlgorithmTypes.ALG_TYPE_BLOCK | AlgorithmSubIds.ALG_SID_AES,
            CALG_SHA_256 = AlgorithmClasses.ALG_CLASS_HASH | AlgorithmTypes.ALG_TYPE_ANY | AlgorithmSubIds.ALG_SID_SHA_256,
            CALG_SHA_384 = AlgorithmClasses.ALG_CLASS_HASH | AlgorithmTypes.ALG_TYPE_ANY | AlgorithmSubIds.ALG_SID_SHA_384,
            CALG_SHA_512 = AlgorithmClasses.ALG_CLASS_HASH | AlgorithmTypes.ALG_TYPE_ANY | AlgorithmSubIds.ALG_SID_SHA_512,
            CALG_ECDH = AlgorithmClasses.ALG_CLASS_KEY_EXCHANGE | AlgorithmTypes.ALG_TYPE_DH | AlgorithmSubIds.ALG_SID_ECDH,
            CALG_ECDH_EPHEM = AlgorithmClasses.ALG_CLASS_KEY_EXCHANGE | AlgorithmTypes.ALG_TYPE_ECDH | AlgorithmSubIds.ALG_SID_ECDH_EPHEM,
            CALG_ECMQV = AlgorithmClasses.ALG_CLASS_KEY_EXCHANGE | AlgorithmTypes.ALG_TYPE_ANY | AlgorithmSubIds.ALG_SID_ECMQV,
            CALG_ECDSA = AlgorithmClasses.ALG_CLASS_SIGNATURE | AlgorithmTypes.ALG_TYPE_DSS | AlgorithmSubIds.ALG_SID_ECDSA,
            CALG_NULLCIPHER = AlgorithmClasses.ALG_CLASS_DATA_ENCRYPT | AlgorithmTypes.ALG_TYPE_ANY | 0,
            CALG_THIRDPARTY_KEY_EXCHANGE = AlgorithmClasses.ALG_CLASS_KEY_EXCHANGE | AlgorithmTypes.ALG_TYPE_THIRDPARTY | AlgorithmSubIds.ALG_SID_THIRDPARTY_ANY,
            CALG_THIRDPARTY_SIGNATURE = AlgorithmClasses.ALG_CLASS_SIGNATURE | AlgorithmTypes.ALG_TYPE_THIRDPARTY | AlgorithmSubIds.ALG_SID_THIRDPARTY_ANY,
            CALG_THIRDPARTY_CIPHER = AlgorithmClasses.ALG_CLASS_DATA_ENCRYPT | AlgorithmTypes.ALG_TYPE_THIRDPARTY | AlgorithmSubIds.ALG_SID_THIRDPARTY_ANY,
            CALG_THIRDPARTY_HASH = AlgorithmClasses.ALG_CLASS_HASH | AlgorithmTypes.ALG_TYPE_THIRDPARTY | AlgorithmSubIds.ALG_SID_THIRDPARTY_ANY,
        }

        private enum AlgorithmClasses
        {
            ALG_CLASS_ANY = 0,
            ALG_CLASS_SIGNATURE = 1 << 13,
            ALG_CLASS_MSG_ENCRYPT = 2 << 13,
            ALG_CLASS_DATA_ENCRYPT = 3 << 13,
            ALG_CLASS_HASH = 4 << 13,
            ALG_CLASS_KEY_EXCHANGE = 5 << 13,
            ALG_CLASS_ALL = 7 << 13,
        }

        private enum AlgorithmTypes
        {
            ALG_TYPE_ANY = 0,
            ALG_TYPE_DSS = 1 << 9,
            ALG_TYPE_RSA = 2 << 9,
            ALG_TYPE_BLOCK = 3 << 9,
            ALG_TYPE_STREAM = 4 << 9,
            ALG_TYPE_DH = 5 << 9,
            ALG_TYPE_SECURECHANNEL = 6 << 9,
            ALG_TYPE_ECDH = 7 << 9,
            ALG_TYPE_THIRDPARTY = 8 << 9,
        }

        private enum AlgorithmSubIds
        {
            // Hash
            ALG_SID_MD2 = 1,
            ALG_SID_MD4 = 2,
            ALG_SID_MD5 = 3,
            ALG_SID_SHA = 4,
            ALG_SID_SHA1 = 4,
            ALG_SID_MAC = 5,
            ALG_SID_RIPEMD = 6,
            ALG_SID_RIPEMD160 = 7,
            ALG_SID_SSL3SHAMD5 = 8,
            ALG_SID_HMAC = 9,
            ALG_SID_TLS1PRF = 10,
            ALG_SID_HASH_REPLACE_OWF = 11,
            ALG_SID_SHA_256 = 12,
            ALG_SID_SHA_384 = 13,
            ALG_SID_SHA_512 = 14,
            ALG_SID_SSL3_MASTER = 1,
            ALG_SID_SCHANNEL_MASTER_HASH = 2,
            ALG_SID_SCHANNEL_MAC_KEY = 3,
            ALG_SID_PCT1_MASTER = 4,
            ALG_SID_SSL2_MASTER = 5,
            ALG_SID_TLS1_MASTER = 6,
            ALG_SID_SCHANNEL_ENC_KEY = 7,
            ALG_SID_ECMQV = 1,

            // RSA
            ALG_SID_RSA_ANY = 0,
            ALG_SID_RSA_PKCS = 1,
            ALG_SID_RSA_MSATWORK = 2,
            ALG_SID_RSA_ENTRUST = 3,
            ALG_SID_RSA_PGP = 4,

            // DSS
            ALG_SID_DSS_ANY = 0,
            ALG_SID_DSS_PKCS = 1,
            ALG_SID_DSS_DMS = 2,
            ALG_SID_ECDSA = 3,

            // Block
            ALG_SID_DES = 1,
            ALG_SID_3DES = 3,
            ALG_SID_DESX = 4,
            ALG_SID_IDEA = 5,
            ALG_SID_CAST = 6,
            ALG_SID_SAFERSK64 = 7,
            ALG_SID_SAFERSK128 = 8,
            ALG_SID_3DES_112 = 9,
            ALG_SID_CYLINK_MEK = 12,
            ALG_SID_RC5 = 13,
            ALG_SID_AES_128 = 14,
            ALG_SID_AES_192 = 15,
            ALG_SID_AES_256 = 16,
            ALG_SID_AES = 17,

            // Fortezza
            ALG_SID_SKIPJACK = 10,
            ALG_SID_TEK = 11,

            // RC2
            ALG_SID_RC2 = 2,

            // Stream
            ALG_SID_RC4 = 1,
            ALG_SID_SEAL = 2,

            // Diffie Hellman
            ALG_SID_DH_SANDF = 1,
            ALG_SID_DH_EPHEM = 2,
            ALG_SID_AGREED_KEY_ANY = 3,
            ALG_SID_KEA = 4,
            ALG_SID_ECDH = 5,
            ALG_SID_ECDH_EPHEM = 6,

            // Generic
            ALG_SID_ANY = 0,

            // Generic third party
            ALG_SID_THIRDPARTY_ANY = 0,
        }
    }
}
