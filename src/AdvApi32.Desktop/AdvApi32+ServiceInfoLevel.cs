// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    /// <content>
    /// Contains the <see cref="ServiceInfoLevel"/> nested type.
    /// </content>
    public static partial class AdvApi32
    {
        /// <summary>
        /// Describes the configuration information to be changed.
        /// </summary>
        public enum ServiceInfoLevel
        {
            /// <summary>
            /// The lpInfo parameter is a pointer to a <see cref="ServiceDescription"/> structure.
            /// </summary>
            SERVICE_CONFIG_DESCRIPTION = 1,

            /// <summary>
            /// The lpInfo parameter is a pointer to a <see cref="ServiceFailureActions"/> structure.
            /// If the service controller handles the <see cref="ServiceControlActionType.SC_ACTION_REBOOT"/> action, the caller must have the SE_SHUTDOWN_NAME privilege.
            /// </summary>
            SERVICE_CONFIG_FAILURE_ACTIONS = 2,

            /// <summary>
            /// The lpInfo parameter is a pointer to a <see cref="ServiceDelayedAutoStartInfo"/> struct.
            /// Windows Server 2003 and Windows XP:  This value is not supported.
            /// </summary>
            SERVICE_CONFIG_DELAYED_AUTO_START_INFO = 3,

            /// <summary>
            /// The lpInfo parameter is a pointer to a <see cref="ServiceFailureActions"/> structure.
            /// Windows Server 2003 and Windows XP:  This value is not supported.
            /// </summary>
            SERVICE_CONFIG_FAILURE_ACTIONS_FLAG = 4,

            /// <summary>
            /// The lpInfo parameter is a pointer to a <see cref="ServiceSidInfo"/> structure.
            /// </summary>
            SERVICE_CONFIG_SERVICE_SID_INFO = 5,

            /// <summary>
            /// The lpInfo parameter is a pointer to a <see cref="ServiceRequiredPrivilegesInfo"/> structure.
            /// Windows Server 2003 and Windows XP:  This value is not supported.
            /// </summary>
            SERVICE_CONFIG_REQUIRED_PRIVILEGES_INFO = 6,

            /// <summary>
            /// The lpInfo parameter is a pointer to a <see cref="ServicePreshutdownInfo"/> structure.
            /// Windows Server 2003 and Windows XP:  This value is not supported.
            /// </summary>
            SERVICE_CONFIG_PRESHUTDOWN_INFO = 7,

            /// <summary>
            /// The lpInfo parameter is a pointer to a SERVICE_TRIGGER_INFO structure.
            /// Windows Server 2008, Windows Vista, Windows Server 2003, and Windows XP:  This value is not supported until Windows Server 2008 R2.
            /// </summary>
            SERVICE_CONFIG_TRIGGER_INFO = 8,

            /// <summary>
            /// The lpInfo parameter is a pointer to a SERVICE_PREFERRED_NODE_INFO structure.
            /// Windows Server 2008, Windows Vista, Windows Server 2003, and Windows XP:  This value is not supported.
            /// </summary>
            SERVICE_CONFIG_PREFERRED_NODE = 9,

            /// <summary>
            /// The lpInfo parameter is a pointer a <see cref="ServiceLaunchProtected"/> structure.
            /// Note  This value is supported starting with Windows 8.1.
            /// </summary>
            SERVICE_CONFIG_LAUNCH_PROTECTED = 12
        }
    }
}
