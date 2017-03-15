// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;

    /// <content>
    /// Contains the <see cref="HeapReAllocFlags"/> nested type.
    /// </content>
    public partial class Kernel32
    {
        /// <summary>
        /// Flags for the <see cref="HeapReAlloc(IntPtr, HeapReAllocFlags, void*, IntPtr)"/> method.
        /// </summary>
        [Flags]
        public enum HeapReAllocFlags
        {
            None = 0,

            /// <summary>
            /// The operating-system raises an exception to indicate a function failure, such as an out-of-memory condition, instead of returning NULL.
            /// </summary>
            /// <remarks>
            /// To ensure that exceptions are generated for all calls to this function, specify HEAP_GENERATE_EXCEPTIONS in the call to HeapCreate.
            /// In this case, it is not necessary to additionally specify HEAP_GENERATE_EXCEPTIONS in this function call.
            /// </remarks>
            HEAP_GENERATE_EXCEPTIONS = 0x00000004,

            /// <summary>
            /// Serialized access will not be used.
            /// </summary>
            /// <remarks>
            /// <para>
            /// To ensure that serialized access is disabled for all calls to this function, specify HEAP_NO_SERIALIZE in the call to HeapCreate.
            /// In this case, it is not necessary to additionally specify HEAP_NO_SERIALIZE in this function call.
            /// </para>
            /// <para>
            /// This value should not be specified when accessing the process's default heap.
            /// The system may create additional threads within the application's process, such as a CTRL+C handler, that simultaneously access the process's default heap.
            /// </para>
            /// </remarks>
            HEAP_NO_SERIALIZE = 0x00000001,

            /// <summary>
            /// There can be no movement when reallocating a memory block.
            /// If this value is not specified, the function may move the block to a new location.
            /// If this value is specified and the block cannot be resized without moving, the function fails, leaving the original memory block unchanged.
            /// </summary>
            HEAP_REALLOC_IN_PLACE_ONLY = 0x00000010,

            /// <summary>
            /// If the reallocation request is for a larger size, the additional region of memory beyond the original size be initialized to zero.
            /// The contents of the memory block up to its original size are unaffected.
            /// </summary>
            HEAP_ZERO_MEMORY = 0x00000008
        }
    }
}
