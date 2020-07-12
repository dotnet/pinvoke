// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PInvoke
{
    /// <content>
    /// Contains the <see cref="PROCESS_INFORMATION_CLASS"/> nested type.
    /// </content>
    public partial class Kernel32
    {
        /// <summary>
        /// Indicates a specific class of process information. Values from this enumeration are passed into
        /// the <see cref="GetProcessInformation(SafeObjectHandle, PROCESS_INFORMATION_CLASS, void*, uint)"/>
        /// and <see cref="SetProcessInformation(SafeObjectHandle, PROCESS_INFORMATION_CLASS, void*, uint)"/>
        /// functions to specify the type of process information passed in the void pointer argument of the function call.
        /// </summary>
        public enum PROCESS_INFORMATION_CLASS
        {
            /// <summary>
            /// The process information is represented by a <see cref="MEMORY_PRIORITY_INFORMATION"/> structure.
            /// Allows applications to lower the default memory priority of threads that perform background operations or access files and data
            /// that are not expected to be accessed again soon.
            /// </summary>
            ProcessMemoryPriority,

            /// <summary>
            /// The process information is represented by a <see cref="PROCESS_MEMORY_EXHAUSTION_INFO"/> structure.
            /// Allows applications to configure a process to terminate if an allocation fails to commit memory.
            /// </summary>
            ProcessMemoryExhaustionInfo,

            /// <summary>
            /// The process information is represented by a <see cref="APP_MEMORY_INFORMATION"/> structure.
            /// Allows applications to query the commit usage and the additional commit available to this process. Does not
            /// allow the caller to actually get a commit limit.
            /// </summary>
            ProcessAppMemoryInfo,

            /// <summary>
            /// If a process is set to ProcessInPrivate mode, and a trace session has set the EVENT_ENABLE_PROPERTY_EXCLUDE_INPRIVATE flag, then the
            /// trace session will drop all events from that process.
            /// </summary>
            ProcessInPrivateInfo,

            /// <summary>
            /// The process information is represented by a <see cref="PROCESS_POWER_THROTTLING_STATE"/> structure. Allows applications to configure how
            /// the system should throttle the target process’s activity when managing power.
            /// </summary>
            ProcessPowerThrottling,

            /// <summary>
            /// Reserved
            /// </summary>
            ProcessReservedValue1,

            /// <summary>
            /// Reserved
            /// </summary>
            ProcessTelemetryCoverageInfo,

            /// <summary>
            /// The process information is represented by a <see cref="PROCESS_PROTECTION_LEVEL_INFORMATION"/> structure.
            /// </summary>
            ProcessProtectionLevelInfo,

            /// <summary>
            /// The process information is represented by a <see cref="PROCESS_LEAP_SECOND_INFO"/> structure.
            /// </summary>
            ProcessLeapSecondInfo,

            /// <summary>
            /// The maximum value for this enumeration. This value may change in a future version.
            /// </summary>
            ProcessInformationClassMax,
        }
    }
}
