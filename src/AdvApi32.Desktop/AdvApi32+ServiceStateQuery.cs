// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;

    /// <content>
    /// Contains the <see cref="ServiceStateQuery"/> nested type.
    /// </content>
    public partial class AdvApi32
    {
        /// <summary>
        /// Represents the state of the services to be enumerated (<see cref="EnumServicesStatus(SafeServiceHandle,ServiceType,ServiceStateQuery,byte*,int,ref int,ref int,ref int)"/> or EnumServicesStatusEx).
        /// </summary>
        [Flags]
        public enum ServiceStateQuery
        {
            /// <summary>
            /// Enumerates services that are in the following states:
            /// <list type="bullet">
            /// <item>
            /// <see cref="ServiceState.SERVICE_START_PENDING"/>
            /// </item>
            /// <item>
            /// <see cref="ServiceState.SERVICE_STOP_PENDING"/>
            /// </item>
            /// <item>
            /// <see cref="ServiceState.SERVICE_RUNNING"/>
            /// </item>
            /// <item>
            /// <see cref="ServiceState.SERVICE_CONTINUE_PENDING"/>
            /// </item>
            /// <item>
            /// <see cref="ServiceState.SERVICE_PAUSE_PENDING"/>
            /// </item>
            /// <item>
            /// <see cref="ServiceState.SERVICE_PAUSED"/>
            /// </item>
            /// </list>
            /// </summary>
            SERVICE_ACTIVE = 0x00000001,

            /// <summary>
            /// Enumerates services that are in the <see cref="ServiceState.SERVICE_STOPPED"/> state.
            /// </summary>
            SERVICE_INACTIVE = 0x00000002,

            /// <summary>
            /// Combines the following states: <see cref="SERVICE_ACTIVE"/> and <see cref="SERVICE_INACTIVE"/>.
            /// </summary>
            SERVICE_STATE_ALL = SERVICE_ACTIVE | SERVICE_INACTIVE
        }
    }
}
