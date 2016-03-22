// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;

    /// <content>
    /// Contains the <see cref="NCryptOpenKeyFlags"/> nested type.
    /// </content>
    public partial class NCrypt
    {
        /// <summary>
        /// The flags that may be passed to the <see cref="NCryptOpenKey(SafeProviderHandle, out SafeKeyHandle, string, LegacyKeySpec, NCryptOpenKeyFlags)"/> method.
        /// </summary>
        [Flags]
        public enum NCryptOpenKeyFlags : uint
        {
            /// <summary>
            /// No flags.
            /// </summary>
            None = 0x0,

            /// <summary>
            /// Open the key for the local computer. If this flag is not present, the current user key is opened.
            /// </summary>
            NCRYPT_MACHINE_KEY_FLAG = 0x00000020,

            /// <summary>
            /// Requests that the key service provider (KSP) not display any user interface. If the provider must display the UI to operate, the call fails and the KSP should set the NTE_SILENT_CONTEXT error code as the last error.
            /// </summary>
            NCRYPT_SILENT_FLAG = 0x00000040,
        }
    }
}
