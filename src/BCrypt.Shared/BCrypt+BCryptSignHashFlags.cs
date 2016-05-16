// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;

    /// <content>
    /// Contains the <see cref="BCryptSignHashFlags"/> nested type.
    /// </content>
    public partial class BCrypt
    {
        /// <summary>
        /// Flags that can be passed to <see cref="BCryptSignHash(SafeKeyHandle, byte[], void*, BCryptSignHashFlags)"/>.
        /// </summary>
        [Flags]
        public enum BCryptSignHashFlags
        {
            /// <summary>
            /// No flags.
            /// </summary>
            None = 0x0,

            /// <summary>
            /// Use the PKCS1 padding scheme. The pPaddingInfo parameter is a pointer to a <see cref="BCRYPT_PKCS1_PADDING_INFO"/> structure.
            /// </summary>
            BCRYPT_PAD_PKCS1 = 0x2,

            /// <summary>
            /// Use the Probabilistic Signature Scheme (PSS) padding scheme. The pPaddingInfo parameter is a pointer to a <see cref="BCRYPT_PSS_PADDING_INFO"/> structure.
            /// </summary>
            BCRYPT_PAD_PSS = 0x00000008,
        }
    }
}
