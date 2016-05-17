// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;

    /// <content>
    /// Contains the <see cref="NCryptSignHashFlags"/> nested type.
    /// </content>
    public partial class NCrypt
    {
        /// <summary>
        /// Flags that can be passed to <see cref="NCryptSignHash(SafeKeyHandle, void*, byte*, int, byte*, int, out int, NCryptSignHashFlags)"/>.
        /// </summary>
        [Flags]
        public enum NCryptSignHashFlags
        {
            /// <summary>
            /// No flags.
            /// </summary>
            None = 0x0,

            /// <summary>
            /// Use the PKCS1 padding scheme. The pPaddingInfo parameter is a pointer to a <see cref="BCrypt.BCRYPT_PKCS1_PADDING_INFO"/> structure.
            /// </summary>
            BCRYPT_PAD_PKCS1 = 0x2,

            /// <summary>
            /// Use the Probabilistic Signature Scheme (PSS) padding scheme. The pPaddingInfo parameter is a pointer to a <see cref="BCrypt.BCRYPT_PSS_PADDING_INFO"/> structure.
            /// </summary>
            BCRYPT_PAD_PSS = 0x00000008,

            /// <summary>
            /// Requests that the key service provider (KSP) not display any user interface. If the provider must display the UI to operate, the call fails and the KSP should set the NTE_SILENT_CONTEXT error code as the last error.
            /// </summary>
            NCRYPT_SILENT_FLAG = 0x00000040,
        }
    }
}
