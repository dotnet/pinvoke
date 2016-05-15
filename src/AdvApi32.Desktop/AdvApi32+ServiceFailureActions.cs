// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System.Runtime.InteropServices;

    /// <content>
    /// Contains the <see cref="ServiceFailureActions"/> nested type.
    /// </content>
    public static partial class AdvApi32
    {
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        public struct ServiceFailureActions
        {
            /// <summary>
            /// The time after which to reset the failure count to zero if there are no failures, in seconds.
            /// Specify <see cref="Constants.INFINITE"/> to indicate that this value should never be reset.
            /// </summary>
            public int dwResetPeriod;

            /// <summary>
            /// The message to be broadcast to server users before rebooting in response to the <see cref="ServiceControlActionType.SC_ACTION_REBOOT"/> service controller action.
            /// If this value is NULL, the reboot message is unchanged. If the value is an empty string (""), the reboot message is deleted and no message is broadcast.
            /// This member can specify a localized string using the following format:
            /// @[path\]
            /// dllname,-strID
            /// The string with identifier strID is loaded from dllname; the path is optional.For more information, see RegLoadMUIString.
            /// Windows Server 2003 and Windows XP:  Localized strings are not supported until Windows Vista.
            /// </summary>
            public string lpRebootMsg;

            /// <summary>
            /// The command line of the process for the CreateProcess function to execute in response to the <see cref="ServiceControlActionType.SC_ACTION_RUN_COMMAND"/> service controller action.
            /// This process runs under the same account as the service. If this value is NULL, the command is unchanged.
            /// If the value is an empty string (""), the command is deleted and no program is run when the service fails.
            /// </summary>
            public string lpCommand;

            /// <summary>
            /// The number of elements in the lpsaActions array.
            /// If this value is 0, but <see cref="lpsaActions"/> is not NULL, the reset period and array of failure actions are deleted.
            /// </summary>
            public int cActions;

            /// <summary>
            /// A pointer to an array of <see cref="ServiceControlAction"/> structures.
            /// If this value is NULL, the <see cref="cActions"/> and <see cref="dwResetPeriod"/> members are ignored.
            /// </summary>
            public ServiceControlAction[] lpsaActions;
        }
    }
}
