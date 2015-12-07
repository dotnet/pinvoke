// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    /// <content>
    /// Contains the <see cref="BCRYPT_RSAKEY_BLOB"/> nested type.
    /// </content>
    public partial class BCrypt
    {
        /// <summary>
        /// A key blob format for transporting RSA keys.
        /// </summary>
        public struct BCRYPT_RSAKEY_BLOB
        {
            public const uint BCRYPT_RSAPUBLIC_MAGIC = 0x31415352;  // RSA1
            public const uint BCRYPT_RSAPRIVATE_MAGIC = 0x32415352; // RSA2
            public const uint BCRYPT_RSAFULLPRIVATE_MAGIC = 0x33415352;  // RSA3

            /// <summary>
            /// Specifies the type of RSA key this BLOB represents.
            /// This can be one of the following values:
            /// <see cref="BCRYPT_RSAPUBLIC_MAGIC"/>, <see cref="BCRYPT_RSAPRIVATE_MAGIC"/>, <see cref="BCRYPT_RSAFULLPRIVATE_MAGIC"/>.
            /// </summary>
            public uint Magic;

            /// <summary>
            /// The size, in bits, of the key.
            /// </summary>
            public uint BitLength;

            /// <summary>
            /// The size, in bytes, of the exponent of the key.
            /// </summary>
            public uint cbPublicExp;

            /// <summary>
            /// The size, in bytes, of the modulus of the key.
            /// </summary>
            public uint cbModulus;

            /// <summary>
            /// The size, in bytes, of the first prime number of the key. This is only used for private key BLOBs.
            /// </summary>
            public uint cbPrime1;

            /// <summary>
            /// The size, in bytes, of the second prime number of the key. This is only used for private key BLOBs.
            /// </summary>
            public uint cbPrime2;
        }
    }
}
