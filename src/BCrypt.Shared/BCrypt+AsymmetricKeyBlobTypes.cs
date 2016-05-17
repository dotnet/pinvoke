// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

#pragma warning disable SA1124 // Do not use regions

namespace PInvoke
{
    /// <content>
    /// Contains the <see cref="AsymmetricKeyBlobTypes"/> nested type.
    /// </content>
    public partial class BCrypt
    {
        /// <summary>
        /// Defines the asymmetric key blob types supported by Win32.
        /// </summary>
        public class AsymmetricKeyBlobTypes
        {
            #region Structures used to represent key blobs.

            /// <summary>
            /// The BLOB is a generic public key of any type. The type of key in this BLOB is determined by the Magic member of the <see cref="BCRYPT_KEY_BLOB"/> structure.
            /// </summary>
            public const string BCRYPT_PUBLIC_KEY_BLOB = "PUBLICBLOB";

            /// <summary>
            /// The BLOB is a generic private key of any type. The private key does not necessarily contain the public key. The type of key in this BLOB is determined by the Magic member of the <see cref="BCRYPT_KEY_BLOB"/> structure.
            /// </summary>
            public const string BCRYPT_PRIVATE_KEY_BLOB = "PRIVATEBLOB";

            #endregion

            #region The BCRYPT_DH_PUBLIC_BLOB and BCRYPT_DH_PRIVATE_BLOB blob types are used to transport plaintext DH keys. These blob types will be supported by all DH primitive providers.

            /// <summary>
            /// The BLOB is a Diffie-Hellman public key BLOB. The pbInput buffer must contain a <see cref="BCRYPT_DH_KEY_BLOB"/> structure immediately followed by the key data.
            /// </summary>
            public const string BCRYPT_DH_PUBLIC_BLOB = "DHPUBLICBLOB";

            /// <summary>
            /// The BLOB is a Diffie-Hellman public/private key pair BLOB. The pbInput buffer must contain a <see cref="BCRYPT_DH_KEY_BLOB"/> structure immediately followed by the key data.
            /// </summary>
            public const string BCRYPT_DH_PRIVATE_BLOB = "DHPRIVATEBLOB";

            /// <summary>
            /// The BLOB is a Diffie-Hellman public key BLOB that was exported by using CryptoAPI. The Microsoft primitive provider does not support importing this BLOB type.
            /// </summary>
            public const string LEGACY_DH_PUBLIC_BLOB = "CAPIDHPUBLICBLOB";

            /// <summary>
            /// The BLOB is a legacy Diffie-Hellman Version 3 Private Key BLOB that contains a Diffie-Hellman public/private key pair that was exported by using CryptoAPI.
            /// </summary>
            public const string LEGACY_DH_PRIVATE_BLOB = "CAPIDHPRIVATEBLOB";

            #endregion

            #region The BCRYPT_DSA_PUBLIC_BLOB and BCRYPT_DSA_PRIVATE_BLOB blob types are used to transport plaintext DSA keys. These blob types will be supported by all DSA primitive providers.

            /// <summary>
            /// The BLOB is a DSA public key BLOB. The pbInput buffer must contain a <see cref="BCRYPT_DSA_KEY_BLOB"/> or <see cref="BCRYPT_DSA_KEY_BLOB_V2"/> structure immediately followed by the key data. BCRYPT_DSA_KEY_BLOB is used for key lengths from 512 to 1024 bits. BCRYPT_DSA_KEY_BLOB_V2 is used for key lengths that exceed 1024 bits but are less than or equal to 3072 bits.
            /// Windows 8:  Support for <see cref="BCRYPT_DSA_KEY_BLOB_V2"/> begins.
            /// </summary>
            public const string BCRYPT_DSA_PUBLIC_BLOB = "DSAPUBLICBLOB";

            /// <summary>
            /// The BLOB is a DSA public/private key pair BLOB. The pbInput buffer must contain a <see cref="BCRYPT_DSA_KEY_BLOB"/> or <see cref="BCRYPT_DSA_KEY_BLOB_V2"/> structure immediately followed by the key data. BCRYPT_DSA_KEY_BLOB is used for key lengths from 512 to 1024 bits. BCRYPT_DSA_KEY_BLOB_V2 is used for key lengths that exceed 1024 bits but are less than or equal to 3072 bits.
            /// Windows 8:  Support for <see cref="BCRYPT_DSA_KEY_BLOB_V2"/> begins.
            /// </summary>
            public const string BCRYPT_DSA_PRIVATE_BLOB = "DSAPRIVATEBLOB";

            /// <summary>
            /// The BLOB is a DSA public key BLOB that was exported by using CryptoAPI. The Microsoft primitive provider does not support importing this BLOB type.
            /// </summary>
            public const string LEGACY_DSA_PUBLIC_BLOB = "CAPIDSAPUBLICBLOB";

            /// <summary>
            /// The BLOB is a DSA public/private key pair BLOB that was exported by using CryptoAPI.
            /// </summary>
            public const string LEGACY_DSA_PRIVATE_BLOB = "CAPIDSAPRIVATEBLOB";

            public const string LEGACY_DSA_V2_PUBLIC_BLOB = "V2CAPIDSAPUBLICBLOB";

            /// <summary>
            /// The BLOB is a DSA version 2 private key in a form that can be imported by using CryptoAPI.
            /// </summary>
            public const string LEGACY_DSA_V2_PRIVATE_BLOB = "V2CAPIDSAPRIVATEBLOB";

            #endregion

            #region The BCRYPT_ECCPUBLIC_BLOB and BCRYPT_ECCPRIVATE_BLOB blob types are used to transport plaintext ECC keys. These blob types will be supported by all ECC primitive providers.

            /// <summary>
            /// The BLOB is an ECC public key. The pbInput buffer must contain a <see cref="BCRYPT_ECCKEY_BLOB"/> structure immediately followed by the key data.
            /// </summary>
            public const string BCRYPT_ECCPUBLIC_BLOB = "ECCPUBLICBLOB";

            /// <summary>
            /// The BLOB is an elliptic curve cryptography (ECC) private key. The pbInput buffer must contain a <see cref="BCRYPT_ECCKEY_BLOB"/> structure immediately followed by the key data.
            /// </summary>
            public const string BCRYPT_ECCPRIVATE_BLOB = "ECCPRIVATEBLOB";

            #endregion

            #region The BCRYPT_RSAPUBLIC_BLOB and BCRYPT_RSAPRIVATE_BLOB blob types are used to transport plaintext RSA keys. These blob types will be supported by all RSA primitive providers. The BCRYPT_RSAPRIVATE_BLOB includes the following values: Public Exponent, Modulus, Prime1, Prime2

            /// <summary>
            /// The BLOB is an RSA public key BLOB. The pbInput buffer must contain a <see cref="BCRYPT_RSAKEY_BLOB"/> structure immediately followed by the key data.
            /// </summary>
            public const string BCRYPT_RSAPUBLIC_BLOB = "RSAPUBLICBLOB";

            /// <summary>
            /// The BLOB is an RSA public/private key pair BLOB. The pbInput buffer must contain a <see cref="BCRYPT_RSAKEY_BLOB"/> structure immediately followed by the key data.
            /// </summary>
            public const string BCRYPT_RSAPRIVATE_BLOB = "RSAPRIVATEBLOB";

            /// <summary>
            /// The BCRYPT_RSAFULLPRIVATE_BLOB blob type is used to transport
            /// plaintext private RSA keys.  It includes the following values:
            /// Public Exponent
            /// Modulus
            /// Prime1
            /// Prime2
            /// Private Exponent mod (Prime1 - 1)
            /// Private Exponent mod (Prime2 - 1)
            /// Inverse of Prime2 mod Prime1
            /// PrivateExponent
            /// </summary>
            public const string BCRYPT_RSAFULLPRIVATE_BLOB = "RSAFULLPRIVATEBLOB";

            /// <summary>
            /// The BLOB is an RSA public key BLOB that was exported by using CryptoAPI. The Microsoft primitive provider does not support importing this BLOB type.
            /// </summary>
            public const string LEGACY_RSAPUBLIC_BLOB = "CAPIPUBLICBLOB";

            /// <summary>
            /// The BLOB is an RSA public/private key pair BLOB that was exported by using CryptoAPI.
            /// </summary>
            public const string LEGACY_RSAPRIVATE_BLOB = "CAPIPRIVATEBLOB";

            #endregion

            /// <summary>
            /// Initializes a new instance of the <see cref="AsymmetricKeyBlobTypes"/> class.
            /// </summary>
            /// <remarks>
            /// Suppresses generation of a public default constructor.
            /// </remarks>
            protected AsymmetricKeyBlobTypes()
            {
            }
        }
    }
}
