// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PInvoke
{
    using System;

    /// <content>
    /// Contains the <see cref="SYSTEM_INFO"/> nested type.
    /// </content>
    public partial class Kernel32
    {
        /// <summary>
        /// Contains information about the current computer system. This includes the architecture and type of
        /// the processor, the number of processors in the system, the page size, and other such information.
        /// </summary>
        public unsafe struct SYSTEM_INFO
        {
            /// <summary>
            /// The processor architecture of the installed operating system.
            /// </summary>
            public ProcessorArchitecture wProcessorArchitecture;

            /// <summary>
            /// This member is reserved for future use.
            /// </summary>
            public ushort wReserved;

            /// <summary>
            /// The page size and the granularity of page protection and commitment.
            /// This is the page size used by the <c>VirtualAlloc</c> function.
            /// </summary>
            public int dwPageSize;

            /// <summary>
            /// A pointer to the lowest memory address accessible to applications and dynamic-link libraries (DLLs).
            /// </summary>
            public void* lpMinimumApplicationAddress;

            /// <summary>
            /// A pointer to the highest memory address accessible to applications and DLLs.
            /// </summary>
            public void* lpMaximumApplicationAddress;

            /// <summary>
            /// A mask representing the set of processors configured into the system.
            /// Bit 0 is processor 0; bit 31 is processor 31.
            /// </summary>
            public IntPtr dwActiveProcessorMask;

            /// <summary>
            /// The number of logical processors in the current group.
            /// </summary>
            public int dwNumberOfProcessors;

            /// <summary>
            /// An obsolete member that is retained for compatibility.
            /// </summary>
            public ProcessorType dwProcessorType;

            /// <summary>
            /// The granularity for the starting address at which virtual memory can be allocated.
            /// </summary>
            public int dwAllocationGranularity;

            /// <summary>
            /// The architecture-dependent processor level. It should be used only for display purposes.
            /// </summary>
            public ushort wProcessorLevel;

            /// <summary>
            /// The architecture-dependent processor revision.
            /// </summary>
            public ushort wProcessorRevision;
        }
    }
}
