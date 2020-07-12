// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PInvoke
{
    /// <content>
    /// Contains the <see cref="ProcessProtectionLevel"/> nested type.
    /// </content>
    public partial class Kernel32
    {
        /// <summary>
        /// Process ProtectionLevel values.
        /// </summary>
        public enum ProcessProtectionLevel : uint
        {
            /// <summary>
            /// For internal use only
            /// </summary>
            PROTECTION_LEVEL_WINTCB_LIGHT = 0x00000000,

            /// <summary>
            /// For internal use only
            /// </summary>
            PROTECTION_LEVEL_WINDOWS = 0x00000001,

            /// <summary>
            /// For internal use only
            /// </summary>
            PROTECTION_LEVEL_WINDOWS_LIGHT = 0x00000002,

            /// <summary>
            /// For internal use only
            /// </summary>
            PROTECTION_LEVEL_ANTIMALWARE_LIGHT = 0x00000003,

            /// <summary>
            /// For internal use only
            /// </summary>
            PROTECTION_LEVEL_LSA_LIGHT = 0x00000004,

            /// <summary>
            /// Not implemented
            /// </summary>
            PROTECTION_LEVEL_WINTCB = 0x00000005,

            /// <summary>
            /// Not implemented
            /// </summary>
            PROTECTION_LEVEL_CODEGEN_LIGHT = 0x00000006,

            /// <summary>
            /// Not implemented
            /// </summary>
            PROTECTION_LEVEL_AUTHENTICODE = 0x00000007,

            /// <summary>
            /// The process is a third party app that is using process protection.
            /// </summary>
            PROTECTION_LEVEL_PPL_APP = 0x00000008,

            /// <summary>
            /// The process is not protected.
            /// </summary>
            /// <remarks>
            /// This is only used as a value for ProtectionLevel when querying
            /// ProcessProtectionLevelInfo in GetProcessInformation.
            /// </remarks>
            PROTECTION_LEVEL_NONE = 0xFFFFFFFE,

            /// <summary>
            /// Supplied for testing only
            /// </summary>
            PROTECTION_LEVEL_SAME = 0xFFFFFFFF,
        }
    }
}
