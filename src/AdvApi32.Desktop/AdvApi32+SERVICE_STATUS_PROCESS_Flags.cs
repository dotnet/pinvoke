// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;

    /// <content>
    /// Contains the <see cref="SERVICE_STATUS_PROCESS_Flags"/> nested type.
    /// </content>
    public partial class AdvApi32
    {
        /// <summary>
        /// Flags associated with a <see cref="SERVICE_STATUS_PROCESS"/> structure.
        /// </summary>
        [Flags]
        public enum SERVICE_STATUS_PROCESS_Flags
        {
            /// <summary>
            /// The service is running in a process that is not a system process, or it is not running.
            /// If the service is running in a process that is not a system process, <see cref="SERVICE_STATUS_PROCESS.dwProcessId"/> is nonzero.
            /// If the service is not running, <see cref="SERVICE_STATUS_PROCESS.dwProcessId"/> is zero.
            /// </summary>
            None = 0x0,

            /// <summary>
            /// The service runs in a system process that must always be running.
            /// </summary>
            SERVICE_RUNS_IN_SYSTEM_PROCESS = 0x1,
        }
    }
}
