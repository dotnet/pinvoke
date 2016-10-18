// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    /// <content>
    /// Contains the <see cref="KeySpec"/> nested type.
    /// </content>
    public partial class Crypt32
    {
        /// <summary>
        /// An identifier that specifies the type of key.
        /// </summary>
        public enum KeySpec : uint
        {
            /// <summary>
            /// The key pair is a key exchange pair.
            /// </summary>
            AT_KEYEXCHANGE = 1,

            /// <summary>
            /// The key pair is a signature pair.
            /// </summary>
            AT_SIGNATURE = 2,

            /// <summary>
            /// The key is a CNG key.
            /// Windows Server 2003 and Windows XP:  This value is not supported.
            /// </summary>
            CERT_NCRYPT_KEY_SPEC = 0xFFFFFFFF
        }
    }
}
