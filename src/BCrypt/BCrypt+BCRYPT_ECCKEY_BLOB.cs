// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    /// <content>
    /// Contains the <see cref="BCRYPT_ECCKEY_BLOB"/> nested type.
    /// </content>
    public partial class BCrypt
    {
        /// <summary>
        /// A key blob format for transporting ECC keys.
        /// Used as a header for an elliptic curve public key or private key BLOB in memory.
        /// </summary>
        public struct BCRYPT_ECCKEY_BLOB
        {
            /// <summary>
            /// The key is a 256 bit elliptic curve Diffie-Hellman public key.
            /// </summary>
            public const uint BCRYPT_ECDH_PUBLIC_P256_MAGIC = 0x314B4345; // ECK1

            /// <summary>
            /// The key is a 256 bit elliptic curve Diffie-Hellman private key.
            /// </summary>
            public const uint BCRYPT_ECDH_PRIVATE_P256_MAGIC = 0x324B4345; // ECK2

            /// <summary>
            /// The key is a 384 bit elliptic curve Diffie-Hellman public key.
            /// </summary>
            public const uint BCRYPT_ECDH_PUBLIC_P384_MAGIC = 0x334B4345; // ECK3

            /// <summary>
            /// The key is a 384 bit elliptic curve Diffie-Hellman private key.
            /// </summary>
            public const uint BCRYPT_ECDH_PRIVATE_P384_MAGIC = 0x344B4345; // ECK4

            /// <summary>
            /// The key is a 521 bit elliptic curve Diffie-Hellman public key.
            /// </summary>
            public const uint BCRYPT_ECDH_PUBLIC_P521_MAGIC = 0x354B4345; // ECK5

            /// <summary>
            /// The key is a 521 bit elliptic curve Diffie-Hellman private key.
            /// </summary>
            public const uint BCRYPT_ECDH_PRIVATE_P521_MAGIC = 0x364B4345; // ECK6

            /// <summary>
            /// The key is a 256 bit elliptic curve DSA public key.
            /// </summary>
            public const uint BCRYPT_ECDSA_PUBLIC_P256_MAGIC = 0x31534345; // ECS1

            /// <summary>
            /// The key is a 256 bit elliptic curve DSA private key.
            /// </summary>
            public const uint BCRYPT_ECDSA_PRIVATE_P256_MAGIC = 0x32534345; // ECS2

            /// <summary>
            /// The key is a 384 bit elliptic curve DSA public key.
            /// </summary>
            public const uint BCRYPT_ECDSA_PUBLIC_P384_MAGIC = 0x33534345; // ECS3

            /// <summary>
            /// The key is a 384 bit elliptic curve DSA private key.
            /// </summary>
            public const uint BCRYPT_ECDSA_PRIVATE_P384_MAGIC = 0x34534345; // ECS4

            /// <summary>
            /// The key is a 521 bit elliptic curve DSA public key.
            /// </summary>
            public const uint BCRYPT_ECDSA_PUBLIC_P521_MAGIC = 0x35534345; // ECS5

            /// <summary>
            /// The key is a 521 bit elliptic curve DSA private key.
            /// </summary>
            public const uint BCRYPT_ECDSA_PRIVATE_P521_MAGIC = 0x36534345; // ECS6

            /// <summary>
            /// Specifies the type of key this BLOB represents. The possible values for this member depend on the type of BLOB this structure represents.
            /// </summary>
            public uint dwMagic;

            /// <summary>
            /// The length, in bytes, of the key.
            /// </summary>
            public uint cbKey;
        }
    }
}
