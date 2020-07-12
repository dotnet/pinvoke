// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PInvoke
{
    using System;

    /// <summary>
    /// Contains the <see cref="ProcessPriorityClass"/> nested type.
    /// </summary>
    public partial class Kernel32
    {
        /// <summary>
        /// Process' priority class.
        /// </summary>
        /// <remarks>
        /// Every thread has a base priority level determined by the thread's priority value and the priority class of its process. The operating system
        /// uses the base priority level of all executable threads to determine which thread gets the next slice of CPU time. Threads are scheduled in a
        /// round-robin fashion at each priority level, and only when there are no executable threads at a higher level will scheduling of threads at a
        /// lower level take place.
        ///
        /// For a table that shows the base priority levels for each combination of priority class and thread priority value, see
        /// <a href="https://docs.microsoft.com/en-us/windows/desktop/ProcThread/scheduling-priorities">Scheduling Priorities</a>
        ///
        /// Priority class is maintained by the executive, so all processes have a priority class that can be queried.
        /// </remarks>
        [Flags]
        public enum ProcessPriorityClass
        {
            /// <summary>
            /// Process that has priority above <see cref="NORMAL_PRIORITY_CLASS"/> but below <see cref="HIGH_PRIORITY_CLASS"/>.
            /// </summary>
            ABOVE_NORMAL_PRIORITY_CLASS = CreateProcessFlags.ABOVE_NORMAL_PRIORITY_CLASS,

            /// <summary>
            /// Process that has priority above <see cref="IDLE_PRIORITY_CLASS"/> but below <see cref="NORMAL_PRIORITY_CLASS"/>.
            /// </summary>
            BELOW_NORMAL_PRIORITY_CLASS = CreateProcessFlags.BELOW_NORMAL_PRIORITY_CLASS,

            /// <summary>
            /// Process that performs time-critical tasks that must be executed immediately for it to run correctly. The threads of a high-priority
            /// class process preempt the threads of normal or idle priority class processes. An example is the Task List, which must respond quickly
            /// when called by the user, regardless of the load on the operating system. Use extreme care when using the high-priority class, because a
            /// high-priority class CPU-bound application can use nearly all available cycles.
            /// </summary>
            HIGH_PRIORITY_CLASS = CreateProcessFlags.HIGH_PRIORITY_CLASS,

            /// <summary>
            /// Process whose threads run only when the system is idle and are preempted by the threads of any process running in a higher priority class.
            /// An example is a screen saver. The idle priority class is inherited by child processes.
            /// </summary>
            IDLE_PRIORITY_CLASS = CreateProcessFlags.IDLE_PRIORITY_CLASS,

            /// <summary>
            /// Process with no special scheduling needs.
            /// </summary>
            NORMAL_PRIORITY_CLASS = CreateProcessFlags.NORMAL_PRIORITY_CLASS,

            /// <summary>
            /// Process that has the highest possible priority. The threads of a real-time priority class process preempt the threads of all other processes,
            /// including operating system processes performing important tasks. For example, a real-time process that executes for more than a very brief
            /// interval can cause disk caches not to flush or cause the mouse to be unresponsive.
            /// </summary>
            REALTIME_PRIORITY_CLASS = CreateProcessFlags.REALTIME_PRIORITY_CLASS,
        }
    }
}
