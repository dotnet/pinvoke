// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PInvoke
{
    using System;

    /// <content>
    /// Contains the <see cref="LocalAllocFlags"/> nested type.
    /// </content>
    public partial class Kernel32
    {
        /// <summary>
        /// Flags for the <see cref="LocalAlloc(LocalAllocFlags, IntPtr)"/> method.
        /// </summary>
        [Flags]
        public enum LocalAllocFlags
        {
            /// <summary>
            /// Allocates fixed memory. The return value is a pointer to the memory object.
            /// </summary>
            LMEM_FIXED = 0x000,

            /// <summary>
            /// Combines LMEM_MOVEABLE and LMEM_ZEROINIT
            /// </summary>
            LHND = LMEM_MOVEABLE | LMEM_ZEROINIT,

            /// <summary>
            /// Allocates movable memory. Memory blocks are never moved in physical memory, but they can be moved within the default heap.
            /// The return value is a handle to the memory object. To translate the handle to a pointer, use the LocalLock function.
            /// This value cannot be combined with <see cref="LMEM_FIXED"/>.
            /// </summary>
            LMEM_MOVEABLE = 0x0002,

            /// <summary>
            /// Initializes memory contents to zero.
            /// </summary>
            LMEM_ZEROINIT = 0x0040,

            /// <summary>
            /// Combines <see cref="LMEM_FIXED"/> and <see cref="LMEM_ZEROINIT"/>.
            /// </summary>
            LPTR = LMEM_FIXED | LMEM_ZEROINIT,

            /// <summary>
            /// Same as <see cref="LMEM_MOVEABLE"/>
            /// </summary>
            NONZEROLHND = LMEM_MOVEABLE,

            /// <summary>
            /// Same as <see cref="LMEM_FIXED"/>
            /// </summary>
            NONZEROLPTR = LMEM_FIXED,
        }
    }
}
