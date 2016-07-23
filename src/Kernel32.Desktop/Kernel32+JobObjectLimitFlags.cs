// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;

    /// <content>
    /// Contains the <see cref="JOB_OBJECT_LIMIT_FLAGS"/> nested type.
    /// </content>
    public partial class Kernel32
    {
        /// <summary>
        /// The limit flags that are in effect
        /// </summary>
        [Flags]
        public enum JOB_OBJECT_LIMIT_FLAGS
        {
            /// <summary>
            /// Causes all processes associated with the job to use the same minimum and maximum working set sizes.
            /// </summary>
            JOB_OBJECT_LIMIT_WORKINGSET = 0x1,

            /// <summary>
            /// Causes all processes associated with the job to use the same priority class.
            /// </summary>
            JOB_OBJECT_LIMIT_PROCESS_TIME = 0x2,

            /// <summary>
            /// Establishes a user-mode execution time limit for the job.
            /// </summary>
            JOB_OBJECT_LIMIT_JOB_TIME = 0x4,

            /// <summary>
            /// Establishes a maximum number of simultaneously active processes associated with the job.
            /// </summary>
            JOB_OBJECT_LIMIT_ACTIVE_PROCESS = 0x8,

            /// <summary>
            /// Causes all processes associated with the job to use the same processor affinity.
            /// </summary>
            JOB_OBJECT_LIMIT_AFFINITY = 0x10,

            /// <summary>
            /// Causes all processes associated with the job to use the same priority class.
            /// </summary>
            JOB_OBJECT_LIMIT_PRIORITY_CLASS = 0x20,

            /// <summary>
            /// Preserves any job time limits you previously set. As long as this flag is set, you can establish a per-job time limit once, then alter other limits in subsequent calls.
            /// </summary>
            JOB_OBJECT_LIMIT_PRESERVE_JOB_TIME = 0x40,

            /// <summary>
            /// Causes all processes in the job to use the same scheduling class.
            /// </summary>
            JOB_OBJECT_LIMIT_SCHEDULING_CLASS = 0x80,

            /// <summary>
            /// Causes all processes associated with the job to limit their committed memory.
            /// </summary>
            JOB_OBJECT_LIMIT_PROCESS_MEMORY = 0x100,

            /// <summary>
            /// Causes all processes associated with the job to limit the job-wide sum of their committed memory.
            /// </summary>
            JOB_OBJECT_LIMIT_JOB_MEMORY = 0x200,

            /// <summary>
            /// Forces a call to the SetErrorMode function with the SEM_NOGPFAULTERRORBOX flag for each process associated with the job.
            /// </summary>
            JOB_OBJECT_LIMIT_DIE_ON_UNHANDLED_EXCEPTION = 0x400,

            /// <summary>
            /// If any process associated with the job creates a child process using the CREATE_BREAKAWAY_FROM_JOB flag while this limit is in effect, the child process is not associated with the job.
            /// </summary>
            JOB_OBJECT_LIMIT_BREAKAWAY_OK = 0x800,

            /// <summary>
            /// Allows any process associated with the job to create child processes that are not associated with the job.
            /// </summary>
            JOB_OBJECT_LIMIT_SILENT_BREAKAWAY_OK = 0x1000,

            /// <summary>
            /// Causes all processes associated with the job to terminate when the last handle to the job is closed.
            /// </summary>
            JOB_OBJECT_LIMIT_KILL_ON_JOB_CLOSE = 0x2000,

            /// <summary>
            /// Allows processes to use a subset of the processor affinity for all processes associated with the job.
            /// </summary>
            JOB_OBJECT_LIMIT_SUBSET_AFFINITY = 0x4000,
        }
    }
}
