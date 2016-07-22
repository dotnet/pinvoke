// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Runtime.InteropServices;

    /// <content>
    /// Contains the <see cref="JOB_OBJECT_EXTENDED_LIMIT_INFORMATION"/> nested type.
    /// </content>
    public partial class Kernel32
    {
        /// <summary>
        /// Contains basic and extended limit information for a job object.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct JOB_OBJECT_EXTENDED_LIMIT_INFORMATION
        {
            /// <summary>
            /// A JOBOBJECT_BASIC_LIMIT_INFORMATION structure that contains basic limit information.
            /// </summary>
            public JOB_OBJECT_BASIC_LIMIT_INFORMATION BasicLimitInformation;

            /// <summary>
            /// Reserved.
            /// </summary>
            public IO_COUNTERS IoInfo;

            /// <summary>
            /// If the LimitFlags member of the JOBOBJECT_BASIC_LIMIT_INFORMATION structure specifies the JOB_OBJECT_LIMIT_PROCESS_MEMORY value, this member specifies the limit for the virtual memory that can be committed by a process. Otherwise, this member is ignored.
            /// </summary>
            public UIntPtr ProcessMemoryLimit;

            /// <summary>
            /// If the LimitFlags member of the JOBOBJECT_BASIC_LIMIT_INFORMATION structure specifies the JOB_OBJECT_LIMIT_JOB_MEMORY value, this member specifies the limit for the virtual memory that can be committed for the job. Otherwise, this member is ignored.
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
