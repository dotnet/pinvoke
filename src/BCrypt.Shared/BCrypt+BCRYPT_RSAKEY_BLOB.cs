// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System.Runtime.InteropServices;

    /// <content>
    /// Contains the <see cref="BCRYPT_RSAKEY_BLOB"/> nested type.
    /// </content>
    public partial class BCrypt
    {
        /// <summary>
        /// A key blob format for transporting RSA keys.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct BCRYPT_RSAKEY_BLOB
        {
            /// <summary>
            /// Specifies the type of RSA key this BLOB represents.
            /// </summary>
            public MagicNumber Magic;

            /// <summary>
            /// The size, in bits, of the key.
            /// </summary>
            public int BitLength;

            /// <summary>
            /// The size, in bytes, of the exponent of the key.
            /// </summary>
            public int cbPublicExp;

            /// <summary>
            /// The size, in bytes, of the modulus of the key.
            /// </summary>
            public int cbModulus;

            /// <summary>
            /// The size, in bytes, of the first prime number of the key. This is only used for private key BLOBs.
            /// </summary>
            public int cbPrime1;

            /// <summary>
            /// The size, in bytes, of the second prime number of the key. This is only used for private key BLOBs.
            /// </summary>
            public int cbPrime2;

            /// <summary>
            /// Enumerates the values that may be expected in the <see cref="Magic"/> field.
            /// </summary>
            public enum MagicNumber : uint
            {
                BCRYPT_RSAPUBLIC_MAGIC = 0x31415352,  // RSA1
                BCRYPT_RSAPRIVATE_MAGIC = 0x32415352, // RSA2
                BCRYPT_RSAFULLPRIVATE_MAGIC = 0x33415352,  // RSA3
            }
        }
    }
}
