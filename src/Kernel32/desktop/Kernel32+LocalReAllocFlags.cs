// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;

    /// <content>
    /// Contains the <see cref="LocalReAllocFlags"/> nested type.
    /// </content>
    public partial class Kernel32
    {
        /// <summary>
        /// Flags for the <see cref="LocalReAlloc(void*, IntPtr, LocalReAllocFlags)"/> method.
        /// </summary>
        [Flags]
        public enum LocalReAllocFlags
        {
            /// <summary>
            /// modifies the attributes of the memory object only (the uBytes parameter is ignored.) Otherwise, the function reallocates the memory object.
            /// </summary>
            LMEM_MODIFY = 0x0080,

            /// <summary>
            /// Allocates fixed or movable memory.
            /// If the memory is a locked <see cref="LocalAllocFlags.LMEM_MOVEABLE"/> memory block or
            /// a <see cref="LocalAllocFlags.LMEM_FIXED"/> memory block and this flag is not specified, the memory can only be reallocated in place.
            /// </summary>
            LMEM_MOVEABLE = 0x0002,

            /// <summary>
            /// Causes the additional memory contents to be initialized to zero if the memory object is growing in size.
            /// </summary>
            /// <remarks>If the parameter does not specify <see cref="LMEM_MODIFY"/>, you can use this value.</remarks>
            LMEM_ZEROINIT = 0x0040,
        }
    }
}
