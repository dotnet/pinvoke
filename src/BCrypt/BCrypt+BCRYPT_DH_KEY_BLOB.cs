// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System.Runtime.InteropServices;

    /// <content>
    /// Contains the <see cref="BCRYPT_DH_KEY_BLOB"/> nested type.
    /// </content>
    public partial class BCrypt
    {
        /// <summary>
        /// A key blob format for transporting DH keys.
        /// Used as a header for a Diffie-Hellman public key or private key BLOB in memory.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct BCRYPT_DH_KEY_BLOB
        {
            public const uint BCRYPT_DH_PUBLIC_MAGIC = 0x42504844;  // DHPB
            public const uint BCRYPT_DH_PRIVATE_MAGIC = 0x56504844; // DHPV

            /// <summary>
            /// Determines the type of key this structure represents. This can be one of the following values:
            /// <see cref="BCRYPT_DH_PUBLIC_MAGIC"/>, <see cref="BCRYPT_DH_PRIVATE_MAGIC"/>.
            /// </summary>
            public uint dwMagic;

            /// <summary>
            /// The length, in bytes, of the key.
            /// </summary>
            public uint cbKey;
        }
    }
}
