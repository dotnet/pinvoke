// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    /// <content>Contains the <see cref="ProcessAccess" /> nested type.</content>
    public partial class Kernel32
    {
        /// <summary>
        /// Enumerates the <see cref="ACCESS_MASK.SpecificRights"/> that may apply to processes.
        /// </summary>
        public static class ProcessAccess
        {
            /// <summary>Required to create a process.</summary>
            public const uint PROCESS_CREATE_PROCESS = 0x0080;

            /// <summary>Required to create a thread.</summary>
            public const uint PROCESS_CREATE_THREAD = 0x0002;

            /// <summary>Required to duplicate a handle using DuplicateHandle.</summary>
            public const uint PROCESS_DUP_HANDLE = 0x0040;

            /// <summary>
            /// Required to retrieve certain information about a process, such as its token, exit code, and priority class
            /// (see OpenProcessToken).
            /// </summary>
            public const uint PROCESS_QUERY_INFORMATION = 0x0400;

            /// <summary>
            /// Required to retrieve certain information about a process (see GetExitCodeProcess, GetPriorityClass,
            /// IsProcessInJob, QueryFullProcessImageName). A handle that has the <see cref="PROCESS_QUERY_INFORMATION" /> access right
            /// is automatically granted <see cref="PROCESS_QUERY_LIMITED_INFORMATION" />.
            /// </summary>
            /// <remarks>Windows Server 2003 and Windows XP:  This access right is not supported.</remarks>
            public const uint PROCESS_QUERY_LIMITED_INFORMATION = 0x1000;

            /// <summary>Required to set certain information about a process, such as its priority class (see SetPriorityClass).</summary>
            public const uint PROCESS_SET_INFORMATION = 0x0200;

            /// <summary>Required to set memory limits using SetProcessWorkingSetSize.</summary>
            public const uint PROCESS_SET_QUOTA = 0x0100;

            /// <summary>Required to suspend or resume a process.</summary>
            public const uint PROCESS_SUSPEND_RESUME = 0x0800;

            /// <summary>Required to terminate a process using TerminateProcess.</summary>
            public const uint PROCESS_TERMINATE = 0x0001;

            /// <summary>
            /// Required to perform an operation on the address space of a process (see VirtualProtectEx and
            /// WriteProcessMemory).
            /// </summary>
            public const uint PROCESS_VM_OPERATION = 0x0008;

            /// <summary>Required to read memory in a process using ReadProcessMemory.</summary>
            public const uint PROCESS_VM_READ = 0x0010;

            /// <summary>Required to write to memory in a process using WriteProcessMemory.</summary>
            public const uint PROCESS_VM_WRITE = 0x0020;
        }
    }
}
