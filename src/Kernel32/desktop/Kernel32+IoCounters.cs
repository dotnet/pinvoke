// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System.Runtime.InteropServices;

    /// <content>
    /// Contains the <see cref="IO_COUNTERS"/> nested type.
    /// </content>
    public partial class Kernel32
    {
        /// <summary>
        /// Contains I/O accounting information for a process or a job object. For a job object, the counters include all operations performed by all processes that have ever been associated with the job, in addition to all processes currently associated with the job.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct IO_COUNTERS
        {
            /// <summary>
            /// The number of read operations performed.
            /// </summary>
            public ulong ReadOperationCount;

            /// <summary>
            /// The number of write operations performed.
            /// </summary>
            public ulong WriteOperationCount;

            /// <summary>
            /// The number of I/O operations performed, other than read and write operations.
            /// </summary>
            public ulong OtherOperationCount;

            /// <summary>
            /// The number of bytes read.
            /// </summary>
            public ulong ReadTransferCount;

            /// <summary>
            /// The number of bytes written.
            /// </summary>
            public ulong WriteTransferCount;

            /// <summary>
            /// The number of bytes transferred during operations other than read and write operations.
            /// </summary>
            public ulong OtherTransferCount;
        }
    }
}
