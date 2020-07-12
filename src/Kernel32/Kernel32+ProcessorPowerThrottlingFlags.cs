// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PInvoke
{
    using System;

    /// <content>
    /// Contains the <see cref="ProcessorPowerThrottlingFlags"/> nested type.
    /// </content>
    public partial class Kernel32
    {
        /// <summary>
        /// Flags used with <see cref="PROCESS_POWER_THROTTLING_STATE"/> fields.
        /// </summary>
        [Flags]
        public enum ProcessorPowerThrottlingFlags : uint
        {
            /// <summary>
            /// Turns off power throttling policy when set on <see cref="PROCESS_POWER_THROTTLING_STATE.StateMask"/>
            /// </summary>
            None = 0x0,

            /// <summary>
            /// Used when <see cref="PROCESS_INFORMATION_CLASS.ProcessPowerThrottling"/> is being set (or queried) using
            /// <see cref="GetProcessInformation(SafeObjectHandle, PROCESS_INFORMATION_CLASS, void*, uint)"/> or
            /// SetProcessInformation.
            ///
            /// When set on <see cref="PROCESS_POWER_THROTTLING_STATE.ControlMask"/>, it indicates that ExecutionSpeed
            /// throttling is being selected.
            ///
            /// When set on <see cref="PROCESS_POWER_THROTTLING_STATE.StateMask"/>, it indicates whether throttling is
            /// on (or off; use <see cref="None"/> to turn off ExecutionSpeed throttling).
            /// </summary>
            PROCESS_POWER_THROTTLING_EXECUTION_SPEED = 0x1,
        }
    }
}
