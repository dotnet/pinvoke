// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;

    /// <content>
    /// Contains the <see cref="NCryptExportKeyFlags"/> nested type.
    /// </content>
    public partial class NCrypt
    {
        /// <summary>
        /// The flags that apply to the <see cref="NCryptExportKey(SafeKeyHandle, SafeKeyHandle, string, NCryptBufferDesc*, byte[], int, out int, NCryptExportKeyFlags)"/> method.
        /// </summary>
        [Flags]
        public enum NCryptExportKeyFlags : uint
        {
            /// <summary>
            /// No flags.
            /// </summary>
            None = 0x0,

            /// <summary>
            /// Requests that the key service provider (KSP) not display any user interface. If the provider must display the UI to operate, the call fails and the KSP should set the NTE_SILENT_CONTEXT error code as the last error.
            /// This flag applies to all providers.
            /// </summary>
            NCRYPT_SILENT_FLAG = 0x00000040,
        }
    }
}
