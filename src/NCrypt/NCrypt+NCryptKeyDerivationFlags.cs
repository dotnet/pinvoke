// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    /// <content>
    /// Contains the <see cref="NCryptKeyDerivationFlags"/> nested type.
    /// </content>
    public partial class NCrypt
    {
        /// <summary>
        /// Flags that may be passed to the <see cref="NCryptKeyDerivation(SafeKeyHandle, NCryptBufferDesc*, byte*, int, out int, NCryptKeyDerivationFlags)"/> method.
        /// </summary>
        public enum NCryptKeyDerivationFlags : uint
        {
            /// <summary>
            /// No flags.
            /// </summary>
            None = 0x0,

            /// <summary>
            /// Specifies that the target algorithm is AES and that the key therefore must be double expanded. This flag is only valid with the CAPI_KDF algorithm.
            /// </summary>
            BCRYPT_CAPI_AES_FLAG = 0x00000010,

            /// <summary>
            /// Requests that the key service provider (KSP) not display any user interface. If the provider must display the UI to operate, the call fails and the KSP should set the NTE_SILENT_CONTEXT error code as the last error.
            /// </summary>
            NCRYPT_SILENT_FLAG = 0x00000040,
        }
    }
}
