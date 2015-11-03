// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    /// <content>
    /// Contains the <see cref="ServiceInfoLevel"/> nested enum.
    /// </content>
    public partial class AdvApi32
    {
        /// <summary>
        /// Describes the configuration information to be changed.
        /// </summary>
        public enum ServiceInfoLevel
        {
            SERVICE_CONFIG_DESCRIPTION = 1,
            SERVICE_CONFIG_FAILURE_ACTIONS = 2,
            SERVICE_CONFIG_DELAYED_AUTO_START_INFO = 3,
            SERVICE_CONFIG_FAILURE_ACTIONS_FLAG = 4,
            SERVICE_CONFIG_SERVICE_SID_INFO = 5,
            SERVICE_CONFIG_REQUIRED_PRIVILEGES_INFO = 6,
            SERVICE_CONFIG_PRESHUTDOWN_INFO = 7,
            SERVICE_CONFIG_TRIGGER_INFO = 8,
            SERVICE_CONFIG_PREFERRED_NODE = 9,
            SERVICE_CONFIG_LAUNCH_PROTECTED = 12
        }
    }
}
