// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PInvoke
{
    /// <content>
    /// Contains the <see cref="PROCESS_POWER_THROTTLING_STATE"/> nested type.
    /// </content>
    public partial class Kernel32
    {
        /// <summary>
        /// Specifies the throttling policies and how to apply them to a target process when that process is
        /// subject to power management.
        /// </summary>
        public struct PROCESS_POWER_THROTTLING_STATE
        {
            /// <summary>
            /// The current version of the <see cref="PROCESS_POWER_THROTTLING_STATE"/> structure.
            /// </summary>
            public const uint PROCESS_POWER_THROTTLING_CURRENT_VERSION = 1;

            /// <summary>
            /// The version of this structre.
            ///
            /// <list type="table">
            /// <listheader><term>Value</term><term>Meaning</term></listheader>
            /// <item><term><see cref="PROCESS_POWER_THROTTLING_CURRENT_VERSION"/></term><term>The current version</term></item>
            /// </list>
            /// </summary>
            public uint Version;

            /// <summary>
            /// This field enables the caller to take control of the power throttling mechanism.
            ///
            /// <list type="table">
            ///     <listheader>
            ///         <term>Value</term>
            ///         <term>Meaning</term>
            ///     </listheader>
            ///     <item>
            ///         <term><see cref="ProcessorPowerThrottlingFlags.PROCESS_POWER_THROTTLING_EXECUTION_SPEED"/></term>
            ///         <term>Manages the execution speed of the process</term>
            ///     </item>
            /// </list>
            /// </summary>
            public ProcessorPowerThrottlingFlags ControlMask;

            /// <summary>
            /// Manages the power throttling mechanism on/off state.
            ///
            /// <list type="table">
            ///     <listheader>
            ///         <term>Value</term>
            ///         <term>Meaning</term>
            ///     </listheader>
            ///     <item>
            ///         <term><see cref="ProcessorPowerThrottlingFlags.PROCESS_POWER_THROTTLING_EXECUTION_SPEED"/>
            ///         </term><term>Manages the execution speed of the process</term>
            ///     </item>
            /// </list>
            /// </summary>
            public ProcessorPowerThrottlingFlags StateMask;
        }
    }
}
