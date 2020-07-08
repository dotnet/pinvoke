// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PInvoke
{
    using System;

    /// <content>Contains the <see cref="ThreadAccess" /> nested type.</content>
    public partial class Kernel32
    {
        /// <summary>
        /// Enumerates the <see cref="ACCESS_MASK.SpecificRights"/> that may apply to threads.
        /// </summary>
        [Flags]
        public enum ThreadAccess : uint
        {
            /// <summary>
            /// Enables the use of the thread handle in any of the wait functions.
            /// </summary>
            SYNCHRONIZE = ACCESS_MASK.StandardRight.SYNCHRONIZE,

            /// <summary>
            /// All possible access rights for a thread object.
            ///
            /// Windows Server 2003 and Windows XP: The value of the <see cref="THREAD_ALL_ACCESS"/> flag increased on Windows Server 2008 and Windows Vista. If
            /// an application compiled for Windows Server 2008 and Windows Vista is run on Windows Server 2003 or Windows XP, the <see cref="THREAD_ALL_ACCESS"/>
            /// flag contains access bits that are not supported and the function specifying this flag fails with <see cref="Win32ErrorCode.ERROR_ACCESS_DENIED"/>.
            /// To avoid this problem, specify the minimum set of access rights required for the operation. If <see cref="THREAD_ALL_ACCESS"/> must be used, set
            /// _WIN32_WINNT (C, C++ applications) to the minimum operating system targeted by your application (for example, #define _WIN32_WINNT _WIN32_WINNT_WINXP).
            ///
            /// In case of C# applications that must rely on <see cref="THREAD_ALL_ACCESS"/>, ensure that the application targets only Windows Vista or newer platforms.
            /// If Windows XP/Windows Server 2003 must be targeted, use the(obsolete) <see cref="THREAD_ALL_ACCESS_WINXP"/> value.
            ///
            /// For more information, see Using the Windows Headers.
            /// </summary>
            THREAD_ALL_ACCESS = ACCESS_MASK.StandardRight.STANDARD_RIGHTS_REQUIRED | SYNCHRONIZE | 0xFFFF,

            /// <summary>
            /// All possible access rights for a thread object.
            ///
            /// See Windows XP/Windows Server 2003 specific remarks in <see cref="THREAD_ALL_ACCESS"/> for details.
            /// </summary>
            [Obsolete]
            THREAD_ALL_ACCESS_WINXP = ACCESS_MASK.StandardRight.STANDARD_RIGHTS_REQUIRED | SYNCHRONIZE | 0x3FF,

            /// <summary>
            /// Required for a server thread that impersonates a client.
            /// </summary>
            THREAD_DIRECT_IMPERSONATION = 0x0200,

            /// <summary>
            /// Required to read the context of a thread using GetThreadContext.
            /// </summary>
            THREAD_GET_CONTEXT = 0x0008,

            /// <summary>
            /// Required to use a thread's security information directly without calling it by using a communication mechanism that provides impersonation services.
            /// </summary>
            THREAD_IMPERSONATE = 0x0100,

            /// <summary>
            /// Required to read certain information from the thread object, such as the exit code (see GetExitCodeThread).
            /// </summary>
            THREAD_QUERY_INFORMATION = 0x0040,

            /// <summary>
            /// Required to read certain information from the thread objects (see GetProcessIdOfThread). A handle that has the
            /// <see cref="THREAD_QUERY_INFORMATION"/> access right is automatically granted <see cref="THREAD_QUERY_LIMITED_INFORMATION"/>.
            ///
            /// Windows Server 2003 and Windows XP: This access right is not supported.
            /// </summary>
            THREAD_QUERY_LIMITED_INFORMATION = 0x0800,

            /// <summary>
            /// Required to write the context of a thread using SetThreadContext.
            /// </summary>
            THREAD_SET_CONTEXT = 0x0010,

            /// <summary>
            /// Required to set certain information in the thread object.
            /// </summary>
            THREAD_SET_INFORMATION = 0x0020,

            /// <summary>
            /// Required to set certain information in the thread object. A handle that has the <see cref="THREAD_SET_INFORMATION"/> access right is automatically granted
            /// <see cref="THREAD_SET_LIMITED_INFORMATION"/>.
            ///
            /// Windows Server 2003 and Windows XP: This access right is not supported.
            /// </summary>
            THREAD_SET_LIMITED_INFORMATION = 0x0400,

            /// <summary>
            /// Required to set the impersonation token for a thread using SetThreadToken.
            /// </summary>
            THREAD_SET_THREAD_TOKEN = 0x0080,

            /// <summary>
            /// Required to suspend or resume a thread (see <see cref="SuspendThread(SafeObjectHandle)"/> and <see cref="ResumeThread(SafeObjectHandle)"/>).
            /// </summary>
            THREAD_SUSPEND_RESUME = 0x0002,

            /// <summary>
            /// Required to terminate a thread using TerminateThread.
            /// </summary>
            THREAD_TERMINATE = 0x0001,
        }
    }
}
