// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Runtime.InteropServices;

    /// <content>
    /// Contains the <see cref="JOBOBJECT_EXTENDED_LIMIT_INFORMATION"/> nested type.
    /// </content>
    public partial class Kernel32
    {
        /// <summary>
        /// Contains basic and extended limit information for a job object.
        /// </summary>
        /// <remarks>
        /// <para>The system tracks the value of PeakProcessMemoryUsed and PeakJobMemoryUsed constantly. This allows you know the peak memory usage of each job. You can use this information to establish a memory limit using the JOB_OBJECT_LIMIT_PROCESS_MEMORY or JOB_OBJECT_LIMIT_JOB_MEMORY value.</para>
        /// <para>Note that the job memory and process memory limits are very similar in operation, but they are independent. You could set a job-wide limit of 100 MB with a per-process limit of 10 MB. In this scenario, no single process could commit more than 10 MB, and the set of processes associated with a job could never exceed 100 MB.</para>
        /// <para>To register for notifications that a job has exceeded its peak memory limit while allowing processes to continue to commit memory, use the SetInformationJobObject function with the JobObjectNotificationLimitInformation information class.</para>
        /// </remarks>
        public struct JOBOBJECT_EXTENDED_LIMIT_INFORMATION
        {
            /// <summary>
            /// A <see cref="JOBOBJECT_BASIC_LIMIT_INFORMATION"/> structure that contains basic limit information.
            /// </summary>
            public JOBOBJECT_BASIC_LIMIT_INFORMATION BasicLimitInformation;

            /// <summary>
            /// Reserved.
            /// </summary>
            public IO_COUNTERS IoInfo;

            /// <summary>
            /// If the <see cref="JOBOBJECT_BASIC_LIMIT_INFORMATION.LimitFlags"/> member of the <see cref="JOBOBJECT_BASIC_LIMIT_INFORMATION"/> structure specifies the
            /// <see cref="JOB_OBJECT_LIMIT_FLAGS.JOB_OBJECT_LIMIT_PROCESS_MEMORY"/> value, this member specifies the limit for the virtual memory that can be committed by a process.
            /// Otherwise, this member is ignored.
            /// </summary>
            public UIntPtr ProcessMemoryLimit;

            /// <summary>
            /// If the <see cref="JOBOBJECT_BASIC_LIMIT_INFORMATION.LimitFlags"/> member of the <see cref="JOBOBJECT_BASIC_LIMIT_INFORMATION"/> structure specifies the
            /// <see cref="JOB_OBJECT_LIMIT_FLAGS.JOB_OBJECT_LIMIT_JOB_MEMORY"/> value,
            /// this member specifies the limit for the virtual memory that can be committed for the job. Otherwise, this member is ignored.
            /// </summary>
            public UIntPtr JobMemoryLimit;

            /// <summary>
            /// The peak memory used by any process ever associated with the job.
            /// </summary>
            public UIntPtr PeakProcessMemoryUsed;

            /// <summary>
            /// The peak memory usage of all processes currently associated with the job.
            /// </summary>
            public UIntPtr PeakJobMemoryUsed;
        }
    }
}
