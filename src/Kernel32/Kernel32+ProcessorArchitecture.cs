// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PInvoke
{
    using System;

    /// <content>
    /// Contains the <see cref="ProcessorArchitecture"/> nested type.
    /// </content>
    public partial class Kernel32
    {
        /// <summary>
        /// The processor architecture of the installed operating system.
        /// </summary>
        public enum ProcessorArchitecture : ushort
        {
            /// <summary>
            /// x64 (AMD or Intel)
            /// </summary>
            PROCESSOR_ARCHITECTURE_AMD64 = 9,

            /// <summary>
            /// ARM
            /// </summary>
            PROCESSOR_ARCHITECTURE_ARM = 5,

            /// <summary>
            /// ARM64
            /// </summary>
            PROCESSOR_ARCHITECTURE_ARM64 = 12,

            /// <summary>
            /// Intel Itanium-based
            /// </summary>
            PROCESSOR_ARCHITECTURE_IA64 = 6,

            /// <summary>
            /// x86
            /// </summary>
            PROCESSOR_ARCHITECTURE_INTEL = 0,

            /// <summary>
            /// Unknown architecture.
            /// </summary>
            PROCESSOR_ARCHITECTURE_UNKNOWN = 0xFFFF,
        }
    }
}
