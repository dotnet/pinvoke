// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Runtime.InteropServices;

    /// <content>
    /// Contains the <see cref="JOB_OBJECT_BASIC_LIMIT_INFORMATION"/> nested type.
    /// </content>
    public partial class Kernel32
    {
        /// <summary>
        /// Contains basic limit information for a job object.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct JOB_OBJECT_BASIC_LIMIT_INFORMATION
        {
            /// <summary>
            /// If LimitFlags specifies JOB_OBJECT_LIMIT_PROCESS_TIME, this member is the per-process user-mode execution time limit, in 100-nanosecond ticks. Otherwise, this member is ignored.
            /// </summary>
            public long PerProcessUserTimeLimit;

            /// <summary>
            /// If LimitFlags specifies JOB_OBJECT_LIMIT_JOB_TIME, this member is the per-job user-mode execution time limit, in 100-nanosecond ticks. Otherwise, this member is ignored.
            /// </summary>
            public long PerJobUserTimeLimit;

            /// <summary>
            /// The limit flags that are in effect. This member is a bitfield that determines whether other structure members are used.
            /// </summary>
            public JOB_OBJECT_LIMIT_FLAGS LimitFlags;

            /// <summary>
            /// If LimitFlags specifies JOB_OBJECT_LIMIT_WORKINGSET, this member is the minimum working set size in bytes for each process associated with the job. Otherwise, this member is ignored.
            /// </summary>
            public UIntPtr MinWorkingSetSize;

            /// <summary>
            /// If LimitFlags specifies JOB_OBJECT_LIMIT_WORKINGSET, this member is the maximum working set size in bytes for each process associated with the job. Otherwise, this member is ignored.
            /// </summary>
            public UIntPtr MaxWorkingSetSize;

            /// <summary>
            /// If LimitFlags specifies JOB_OBJECT_LIMIT_ACTIVE_PROCESS, this member is the active process limit for the job. Otherwise, this member is ignored.
            /// </summary>
            public uint ActiveProcessLimit;

            /// <summary>
            /// If LimitFlags specifies JOB_OBJECT_LIMIT_AFFINITY, this member is the processor affinity for all processes associated with the job. Otherwise, this member is ignored.
            /// </summary>
            public UIntPtr Affinity;

            /// <summary>
            /// If LimitFlags specifies JOB_OBJECT_LIMIT_PRIORITY_CLASS, this member is the priority class for all processes associated with the job. Otherwise, this member is ignored.
            /// </summary>
            public uint PriorityClass;

            /// <summary>
            /// If LimitFlags specifies JOB_OBJECT_LIMIT_SCHEDULING_CLASS, this member is the scheduling class for all processes associated with the job. Otherwise, this member is ignored.
            /// </summary>
            public uint SchedulingClass;
        }
    }
}
