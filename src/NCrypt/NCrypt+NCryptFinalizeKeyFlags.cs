// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;

    /// <content>
    /// Contains the <see cref="NCryptFinalizeKeyFlags"/> nested type.
    /// </content>
    public static partial class NCrypt
    {
        /// <summary>
        /// Flags that may be passed to the <see cref="NCryptFinalizeKey"/> function.
        /// </summary>
        [Flags]
        public enum NCryptFinalizeKeyFlags
        {
            /// <summary>
            /// No flags.
            /// </summary>
            None = 0x0,

            /// <summary>
            /// Do not validate the public portion of the key pair. This flag only applies to public/private key pairs.
            /// </summary>
            NCRYPT_NO_KEY_VALIDATION = 0x00000008,

            /// <summary>
            /// Also save the key in legacy storage. This allows the key to be used with CryptoAPI. This flag only applies to RSA keys.
            /// </summary>
            NCRYPT_WRITE_KEY_TO_LEGACY_STORE_FLAG = 0x00000200,

            /// <summary>
            /// Requests that the key service provider (KSP) not display any user interface. If the provider must display the UI to operate, the call fails and the KSP should set the NTE_SILENT_CONTEXT error code as the last error.
            /// </summary>
            NCRYPT_SILENT_FLAG = 0x00000040,
        }
    }
}
