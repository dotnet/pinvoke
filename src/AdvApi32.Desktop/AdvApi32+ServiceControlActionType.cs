// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    /// <content>
    /// Contains the <see cref="ServiceControlActionType"/> nested type.
    /// </content>
    public static partial class AdvApi32
    {
        /// <summary>
        /// Specifies action levels for the Type member of the <see cref="ServiceControlAction"/> struct.
        /// </summary>
        public enum ServiceControlActionType
        {
            /// <summary>
            /// No action.
            /// </summary>
            SC_ACTION_NONE = 0,

            /// <summary>
            /// Restart the service.
            /// </summary>
            SC_ACTION_RESTART = 1,

            /// <summary>
            /// Reboot the computer.
            /// </summary>
            SC_ACTION_REBOOT = 2,

            /// <summary>
            /// Run a command.
            /// </summary>
            SC_ACTION_RUN_COMMAND = 3
        }
    }
}