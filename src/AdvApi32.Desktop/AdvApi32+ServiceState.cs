// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    /// <content>
    /// Contains the <see cref="ServiceState"/> nested type.
    /// </content>
    public partial class AdvApi32
    {
        /// <summary>
        /// Represents the current state of a servies
        /// </summary>
        public enum ServiceState
        {
            /// <summary>
            /// The service is not running.
            /// </summary>
            SERVICE_STOPPED = 0x00000001,

            /// <summary>
            /// The service is starting.
            /// </summary>
            SERVICE_START_PENDING = 0x00000002,

            /// <summary>
            /// The service is stopping.
            /// </summary>
            SERVICE_STOP_PENDING = 0x00000003,

            /// <summary>
            /// The service is running.
            /// </summary>
            SERVICE_RUNNING = 0x00000004,

            /// <summary>
            /// The service continue is pending.
            /// </summary>
            SERVICE_CONTINUE_PENDING = 0x00000005,

            /// <summary>
            /// The service pause is pending.
            /// </summary>
            SERVICE_PAUSE_PENDING = 0x00000006,

            /// <summary>
            /// The service is paused.
            /// </summary>
            SERVICE_PAUSED = 0x00000007
        }
    }
}
