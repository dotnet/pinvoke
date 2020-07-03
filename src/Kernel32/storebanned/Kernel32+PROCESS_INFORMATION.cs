// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Runtime.InteropServices;

    /// <content>
    /// Contains the <see cref="PROCESS_INFORMATION"/> nested type.
    /// </content>
    public partial class Kernel32
    {
        /// <summary>
        /// Contains information about a newly created process and its primary thread. It is used with the <see cref="CreateProcess(string, string, SECURITY_ATTRIBUTES*, SECURITY_ATTRIBUTES*, bool, CreateProcessFlags, void*, string, ref STARTUPINFO, out PROCESS_INFORMATION)"/>,
        /// <see cref="CreateProcessAsUser(IntPtr, string, string, SECURITY_ATTRIBUTES*, SECURITY_ATTRIBUTES*, bool, CreateProcessFlags, void*, string, ref STARTUPINFO, out PROCESS_INFORMATION)"/>, CreateProcessWithLogonW, or CreateProcessWithTokenW function.
        /// </summary>
        public struct PROCESS_INFORMATION
        {
            /// <summary>
            /// A handle to the newly created process. The handle is used to specify the process in all functions that perform operations on the process object.
            /// </summary>
            public IntPtr hProcess;

            /// <summary>
            /// A handle to the primary thread of the newly created process. The handle is used to specify the thread in all functions that perform operations on the thread object.
            /// </summary>
            public IntPtr hThread;

            /// <summary>
            /// A value that can be used to identify a process. The value is valid from the time the process is created until all handles to the process are closed and the process object is freed; at this point, the identifier may be reused.
            /// </summary>
            public int dwProcessId;

            /// <summary>
            /// A value that can be used to identify a thread. The value is valid from the time the thread is created until all handles to the thread are closed and the thread object is freed; at this point, the identifier may be reused.
            /// </summary>
            public int dwThreadId;
        }
    }
}
