// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PInvoke
{
    /// <content>
    /// Contains the <see cref="MemoryPriority"/> nested type.
    /// </content>
    public partial class Kernel32
    {
        /// <summary>
        /// The memory priority for the thread or process can be one of the following values.
        /// </summary>
        /// <remarks>
        /// The memory priority of a thread or process serves as a hint to the memory manager when it trims pages from the working set.
        /// Other factors being equal, pages with lower memory priority are trimmed before pages with higher memory priority.
        /// See also <a href="https://docs.microsoft.com/en-us/windows/desktop/Memory/working-set">Working Set</a>.
        /// </remarks>
        public enum MemoryPriority : uint
        {
            /// <summary>
            /// Lowest memory priority
            /// </summary>
            MEMORY_PRIORITY_LOWEST = 0,

            /// <summary>
            /// Very low memory priority
            /// </summary>
            MEMORY_PRIORITY_VERY_LOW = 1,

            /// <summary>
            /// Low memory priority
            /// </summary>
            MEMORY_PRIORITY_LOW = 2,

            /// <summary>
            /// Medium memory priority
            /// </summary>
            MEMORY_PRIORITY_MEDIUM = 3,

            /// <summary>
            /// Below normal memory priority
            /// </summary>
            MEMORY_PRIORITY_BELOW_NORMAL = 4,

            /// <summary>
            /// Normal memory priority. This is the default priority for all threads and processes on the system
            /// </summary>
            MEMORY_PRIORITY_NORMAL = 5,
        }
    }
}
