// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;

    /// <content>
    /// Contains the <see cref="HeapFreeFlags"/> nested type.
    /// </content>
    public partial class Kernel32
    {
        /// <summary>
        /// Flags for the <see cref="HeapFree(IntPtr, HeapFreeFlags, void*)"/> method.
        /// </summary>
        [Flags]
        public enum HeapFreeFlags
        {
            None = 0,

            /// <summary>
            /// Serialized access will not be used.
            /// </summary>
            /// <remarks>
            /// <para>
            /// To ensure that serialized access is disabled for all calls to this function, specify HEAP_NO_SERIALIZE in the call to HeapCreate.
            /// In this case, it is not necessary to additionally specify HEAP_NO_SERIALIZE in this function call.
            /// </para>
            /// <para>
            /// Do not specify this value when accessing the process heap. The system may create additional threads within the application's process,
            /// such as a CTRL+C handler, that simultaneously access the process heap.
            /// </para>
            /// </remarks>
            HEAP_NO_SERIALIZE = 0x00000001
        }
    }
}