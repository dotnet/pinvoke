// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PInvoke
{
    /// <content>
    /// Contains the <see cref="SC_ACTION_TYPE"/> nested type.
    /// </content>
    public static partial class AdvApi32
    {
        /// <summary>
        /// Specifies action levels for the Type member of the <see cref="SC_ACTION"/> struct.
        /// </summary>
        public enum SC_ACTION_TYPE
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
            SC_ACTION_RUN_COMMAND = 3,

            SC_ACTION_OWN_RESTART = 4,
        }
    }
}
