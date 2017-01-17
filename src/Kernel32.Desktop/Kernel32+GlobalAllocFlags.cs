// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;

    /// <content>
    /// Contains the <see cref="GlobalAllocFlags"/> nested type.
    /// </content>
    public partial class Kernel32
    {
        /// <summary>
        /// Flags for the <see cref="GlobalAlloc(GlobalAllocFlags, IntPtr)"/> method.
        /// </summary>
        [Flags]
        public enum GlobalAllocFlags : uint
        {
            /// <summary>
            /// Allocates fixed memory. The return value is a pointer.
            /// </summary>
            /// <remarks>Cannot be combined with the <see cref="GMEM_MOVEABLE"/> flags.</remarks>
            GMEM_FIXED = 0x0000,

            /// <summary>
            /// Allocates movable memory. Memory blocks are never moved in physical memory, but they can
            /// be moved within the default heap. The return value is a handle to the memory object. To
            /// translate the handle into a pointer, use the <see cref="GlobalLock(void*)"/> function.
            /// </summary>
            /// <remarks>This value cannot be combined with <see cref="GMEM_FIXED"/>.</remarks>
            GMEM_MOVEABLE = 0x0002,

            /// <summary>
            /// Does not compact or discard memory to satisfy the allocation request.
            /// </summary>
            GMEM_NOCOMPACT = 0x0010,

            /// <summary>
            /// Does not discard memory to satisfy the allocation request.
            /// </summary>
            GMEM_NODISCARD = 0x0020,

            /// <summary>
            /// Initializes memory contents to zero
            /// </summary>
            GMEM_ZEROINIT = 0x0040,

            /// <summary>
            /// Combines <see cref="GMEM_FIXED"/> and <see cref="GMEM_ZEROINIT"/>
            /// </summary>
            GPTR = GMEM_FIXED | GMEM_ZEROINIT,

            /// <summary>
            /// Combines <see cref="GMEM_MOVEABLE"/> and <see cref="GMEM_ZEROINIT"/>
            /// </summary>
            GHND = GMEM_MOVEABLE | GMEM_ZEROINIT,

            GMEM_MODIFY = 0x0080,

            /// <summary>
            /// Allocates discardable memory.
            /// </summary>
            /// <remarks>This flag can only be used with the GMEM_MOVEABLE flag.</remarks>
            GMEM_DISCARDABLE = 0x0100,

            /// <summary>
            /// Allocates non-banked memory (memory is not within the <see cref="GMEM_NOTIFY"/> flag).
            /// Same as <see cref="GMEM_LOWER"/>.
            /// </summary>
            /// <remarks>This flag is ignored in Windows 3.1.</remarks>
            GMEM_NOT_BANKED = 0x1000,

            /// <summary>
            /// Allocates non-banked memory (memory is not within the <see cref="GMEM_NOTIFY"/> flag).
            /// Same as <see cref="GMEM_NOT_BANKED"/>.
            /// </summary>
            /// <remarks>This flag is ignored in Windows 3.1.</remarks>
            GMEM_LOWER = GMEM_NOT_BANKED,

            /// <summary>
            /// Allocates memory that can be shared with other applications. This flag is used for
            /// dynamic data exchange (DDE) only.
            /// </summary>
            /// <remarks>This flag is equivalent to <see cref="GMEM_SHARE"/>.</remarks>
            GMEM_DDESHARE = 0x2000,

            /// <summary>
            /// Allocates memory that can be shared with other applications. This flag is used for
            /// dynamic data exchange (DDE) only.
            /// </summary>
            /// <remarks>This flag is equivalent to <see cref="GMEM_DDESHARE"/>.</remarks>
            GMEM_SHARE = GMEM_DDESHARE,

            /// <summary>
            /// Calls the notification routine if the memory object is discarded.
            /// </summary>
            GMEM_NOTIFY = 0x4000
        }
    }
}