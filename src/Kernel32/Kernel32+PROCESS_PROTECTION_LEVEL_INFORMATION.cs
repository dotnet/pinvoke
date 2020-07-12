// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PInvoke
{
    /// <content>
    /// Contains the <see cref="PROCESS_PROTECTION_LEVEL_INFORMATION"/> nested type.
    /// </content>
    public partial class Kernel32
    {
        /// <summary>
        /// Specifies whether Protected Process Light (PPL) is enabled.
        /// </summary>
        public struct PROCESS_PROTECTION_LEVEL_INFORMATION
        {
            /// <summary>
            /// Process protection level.
            /// </summary>
            public ProcessProtectionLevel ProtectionLevel;
        }
    }
}
