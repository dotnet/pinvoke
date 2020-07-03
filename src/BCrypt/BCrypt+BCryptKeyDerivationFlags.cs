// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PInvoke
{
    /// <content>
    /// Contains the <see cref="BCryptKeyDerivationFlags"/> nested type.
    /// </content>
    public partial class BCrypt
    {
        /// <summary>
        /// Flags that may be passed to the <see cref="BCryptKeyDerivation(SafeKeyHandle, BCryptBufferDesc*, byte*, int, out int, BCryptKeyDerivationFlags)"/> method.
        /// </summary>
        public enum BCryptKeyDerivationFlags : uint
        {
            /// <summary>
            /// No flags.
            /// </summary>
            None = 0x0,

            /// <summary>
            /// Specifies that the target algorithm is AES and that the key therefore must be double expanded. This flag is only valid with the CAPI_KDF algorithm.
            /// </summary>
            BCRYPT_CAPI_AES_FLAG = 0x00000010,
        }
    }
}
