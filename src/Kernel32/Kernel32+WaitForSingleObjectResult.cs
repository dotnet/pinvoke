// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PInvoke
{
    /// <content>
    /// Contains the <see cref="WaitForSingleObjectResult"/> nested type.
    /// </content>
    public static partial class Kernel32
    {
        /// <summary>
        /// Values that may be returned from the <see cref="WaitForSingleObject(System.Runtime.InteropServices.SafeHandle, int)"/> function.
        /// </summary>
        public enum WaitForSingleObjectResult : uint
        {
            /// <summary>
            /// The specified object is a mutex object that was not released by the thread that owned the mutex object before the owning thread terminated. Ownership of the mutex object is granted to the calling thread and the mutex state is set to nonsignaled.
            /// If the mutex was protecting persistent state information, you should check it for consistency.
            /// </summary>
            WAIT_ABANDONED = 0x00000080,

            /// <summary>
            /// The state of the specified object is signaled.
            /// </summary>
            WAIT_OBJECT_0 = 0x0,

            /// <summary>
            /// The time-out interval elapsed, and the object's state is nonsignaled.
            /// </summary>
            WAIT_TIMEOUT = 0x00000102,

            /// <summary>
            /// The function has failed. To get extended error information, call <see cref="GetLastError"/>.
            /// </summary>
            WAIT_FAILED = 0xFFFFFFFF,
        }
    }
}
