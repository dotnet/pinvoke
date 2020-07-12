// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PInvoke
{
    /// <content>
    /// Contains the <see cref="MEMORY_PRIORITY_INFORMATION"/> nested type.
    /// </content>
    public partial class Kernel32
    {
        /// <summary>
        /// Specifies the memory priority for a thread or process.
        /// This structure is used by the GetProcessInformation, SetProcessInformation, GetThreadInformation, and SetThreadInformation
        /// functions.
        /// </summary>
        public struct MEMORY_PRIORITY_INFORMATION
        {
            /// <summary>
            /// The memory priority for the thread or process.
            /// </summary>
            public MemoryPriority MemoryPriority;
        }
    }
}
