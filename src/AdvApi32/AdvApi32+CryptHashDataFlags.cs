// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PInvoke
{
    using System;

    /// <content>
    /// Contains the <see cref="CryptHashDataFlags"/> nested type.
    /// </content>
    public partial class AdvApi32
    {
        /// <summary>
        /// Flags for the <see cref="CryptHashData(SafeHashHandle, byte*, int, CryptHashDataFlags)"/> method.
        /// </summary>
        [Flags]
        public enum CryptHashDataFlags : uint
        {
            /// <summary>
            /// No flags.
            /// </summary>
            None = 0x0,

            /// <summary>
            /// This flag is not used.
            /// </summary>
            [Obsolete("This flag is not used.")]
            CRYPT_OWF_REPL_LM_HASH = 0x1,

            /// <summary>
            /// All Microsoft Cryptographic Providers ignore this parameter. For any CSP that does not ignore this parameter, if this flag is set, the CSP prompts the user to input data directly. This data is added to the hash. The application is not allowed access to the data. This flag can be used to allow the user to enter a PIN into the system.
            /// </summary>
            CRYPT_USERDATA = 0x1,
        }
    }
}
