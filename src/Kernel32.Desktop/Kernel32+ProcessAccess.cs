// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;

    /// <content>Contains the <see cref="ProcessAccess" /> nested struct.</content>
    public partial class Kernel32
    {
        /// <summary>The valid access rights for process objects.</summary>
        [Flags]
        public enum ProcessAccess : uint
        {
            /// <summary>Required to delete the object.</summary>
            DELETE,

            /// <summary>
            /// Required to read information in the security descriptor for the object, not including the information in the
            /// SACL. To read or write the SACL, you must request the <see cref="ACCESS_SYSTEM_SECURITY" /> access right. For more
            /// information, see SACL Access Right.
            /// </summary>
            READ_CONTROL = 0x00020000,

            /// <summary>Required to wait for the process to terminate using the wait functions.</summary>
            SYNCHRONIZE = 0x00100000,

            /// <summary>Required to modify the DACL in the security descriptor for the object.</summary>
            WRITE_DAC = 0x00040000,

            /// <summary>Required to change the owner in the security descriptor for the object.</summary>
            WRITE_OWNER = 0x00080000,

            /// <summary>Required to create a process.</summary>
            PROCESS_CREATE_PROCESS = 0x0080,

            /// <summary>Required to create a thread.</summary>
            PROCESS_CREATE_THREAD = 0x0002,

            /// <summary>Required to duplicate a handle using DuplicateHandle.</summary>
            PROCESS_DUP_HANDLE = 0x0040,

            /// <summary>
            /// Required to retrieve certain information about a process, such as its token, exit code, and priority class
            /// (see OpenProcessToken).
            /// </summary>
            PROCESS_QUERY_INFORMATION = 0x0400,

            /// <summary>
            /// Required to retrieve certain information about a process (see GetExitCodeProcess, GetPriorityClass,
            /// IsProcessInJob, QueryFullProcessImageName). A handle that has the <see cref="PROCESS_QUERY_INFORMATION" /> access right
            /// is automatically granted <see cref="PROCESS_QUERY_LIMITED_INFORMATION" />.
            /// </summary>
            /// <remarks>Windows Server 2003 and Windows XP:  This access right is not supported.</remarks>
            PROCESS_QUERY_LIMITED_INFORMATION = 0x1000,

            /// <summary>Required to set certain information about a process, such as its priority class (see SetPriorityClass).</summary>
            PROCESS_SET_INFORMATION = 0x0200,

            /// <summary>Required to set memory limits using SetProcessWorkingSetSize.</summary>
            PROCESS_SET_QUOTA = 0x0100,

            /// <summary>Required to suspend or resume a process.</summary>
            PROCESS_SUSPEND_RESUME = 0x0800,

            /// <summary>Required to terminate a process using TerminateProcess.</summary>
            PROCESS_TERMINATE = 0x0001,

            /// <summary>
            /// Required to perform an operation on the address space of a process (see VirtualProtectEx and
            /// WriteProcessMemory).
            /// </summary>
            PROCESS_VM_OPERATION = 0x0008,

            /// <summary>Required to read memory in a process using ReadProcessMemory.</summary>
            PROCESS_VM_READ = 0x0010,

            /// <summary>Required to write to memory in a process using WriteProcessMemory.</summary>
            PROCESS_VM_WRITE = 0x0020,

            /// <summary>Required to wait for the process to terminate using the wait functions.</summary>
            ACCESS_SYSTEM_SECURITY = 0x01000000
        }
    }
}
