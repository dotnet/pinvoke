// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System.Runtime.InteropServices;

    /// <content>
    /// Contains the <see cref="BCRYPT_KEY_BLOB"/> nested type.
    /// </content>
    public partial class BCrypt
    {
        /// <summary>
        /// Represents a key blob header that identifies a key blob format for transporting keys.
        /// The base structure for all CNG key BLOBs. All CNG key BLOBs are based on this structure. For example, the <see cref="BCRYPT_RSAKEY_BLOB"/> structure is based on this structure.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct BCRYPT_KEY_BLOB
        {
            /// <summary>
            /// Specifies the type of key this BLOB represents. The possible values for this member depend on the type of BLOB this structure represents.
            /// </summary>
            public uint dwMagic;
        }
    }
}
