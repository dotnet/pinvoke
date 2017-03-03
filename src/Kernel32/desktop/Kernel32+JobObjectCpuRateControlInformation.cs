// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System.Runtime.InteropServices;

    /// <content>
    /// Contains the <see cref="JOBOBJECT_CPU_RATE_CONTROL_INFORMATION "/> nested type.
    /// </content>
    public partial class Kernel32
    {
        /// <summary>
        /// Contains CPU rate control information for a job object. This structure is used by the SetInformationJobObject and QueryInformationJobObject functions with the JobObjectCpuRateControlInformation information class.
        /// </summary>
        [StructLayout(LayoutKind.Explicit)]
        public struct JOBOBJECT_CPU_RATE_CONTROL_INFORMATION
        {
            /// <summary>
            /// The scheduling policy for CPU rate control.
            /// </summary>
            [FieldOffset(0)]
            public JOBOBJECT_CPU_RATE_CONTROL_FLAGS ControlFlags;

            /// <summary>
            /// Specifies the portion of processor cycles that the threads in a job object can use during each scheduling interval, as the number of cycles per 10,000 cycles. If the ControlFlags member specifies JOB_OBJECT_CPU_RATE_WEIGHT_BASED or JOB_OBJECT_CPU_RATE_CONTROL_MIN_MAX_RATE, this member is not used.
            /// </summary>
            [FieldOffset(4)]
            public uint CpuRate;

            /// <summary>
            /// If the ControlFlags member specifies JOB_OBJECT_CPU_RATE_WEIGHT_BASED, this member specifies the scheduling weight of the job object, which determines the share of processor time given to the job relative to other workloads on the processor.
            /// </summary>
            [FieldOffset(4)]
            public uint Weight;

            /// <summary>
            /// Specifies the minimum portion of the processor cycles that the threads in a job object can reserve during each scheduling interval. Specify this rate as a percentage times 100. For example, to set a minimum rate of 50%, specify 50 times 100, or 5,000.
            /// </summary>
            [FieldOffset(4)]
            public ushort MinRate;

            /// <summary>
            /// Specifies the maximum portion of processor cycles that the threads in a job object can use during each scheduling interval. Specify this rate as a percentage times 100. For example, to set a maximum rate of 50%, specify 50 times 100, or 5,000.
            /// </summary>
            [FieldOffset(6)]
            public ushort MaxRate;
        }
    }
}
