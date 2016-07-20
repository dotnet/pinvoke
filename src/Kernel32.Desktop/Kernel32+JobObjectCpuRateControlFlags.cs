// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;

    /// <content>
    /// Contains the <see cref="JOBOBJECT_CPU_RATE_CONTROL_FLAGS "/> nested type.
    /// </content>
    public partial class Kernel32
    {
        /// <summary>
        /// The scheduling policy for CPU rate control.
        /// </summary>
        [Flags]
        public enum JOBOBJECT_CPU_RATE_CONTROL_FLAGS : uint
        {
            /// <summary>
            /// This flag enables the job's CPU rate to be controlled based on weight or hard cap. You must set this value if you also set JOB_OBJECT_CPU_RATE_CONTROL_WEIGHT_BASED, JOB_OBJECT_CPU_RATE_CONTROL_HARD_CAP, or JOB_OBJECT_CPU_RATE_CONTROL_MIN_MAX_RATE.
            /// </summary>
            JOB_OBJECT_CPU_RATE_CONTROL_ENABLE = 0x1,

            /// <summary>
            /// The job's CPU rate is calculated based on its relative weight to the weight of other jobs. If this flag is set, the Weight member contains more information. If this flag is clear, the CpuRate member contains more information.
            /// </summary>
            JOB_OBJECT_CPU_RATE_CONTROL_WEIGHT_BASED = 0x2,

            /// <summary>
            /// The job's CPU rate is a hard limit. After the job reaches its CPU cycle limit for the current scheduling interval, no threads associated with the job will run until the next interval.
            /// </summary>
            JOB_OBJECT_CPU_RATE_CONTROL_HARD_CAP = 0x4,

            /// <summary>
            /// Sends messages when the CPU rate for the job exceeds the rate limits for the job during the tolerance interval.
            /// </summary>
            JOB_OBJECT_CPU_RATE_CONTROL_NOTIFY = 0x8,

            /// <summary>
            /// The CPU rate for the job is limited by minimum and maximum rates that you specify in the MinRate and MaxRate members.
            /// </summary>
            JOB_OBJECT_CPU_RATE_CONTROL_MIN_MAX_RATE = 0x10,
        }
    }
}
