// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;

    /// <content>
    /// Contains the <see cref="CreateProcessFlags"/> nested type.
    /// </content>
    public partial class Kernel32
    {
        /// <summary>
        /// Flags that may be passed to the <see cref="CreateProcess(string, string, SECURITY_ATTRIBUTES*, SECURITY_ATTRIBUTES*, bool, CreateProcessFlags, void*, string, ref STARTUPINFO, out PROCESS_INFORMATION)"/> function.
        /// </summary>
        [Flags]
        public enum CreateProcessFlags
        {
            /// <summary>
            /// No flags.
            /// </summary>
            None = 0x0,

            /// <summary>
            /// The child processes of a process associated with a job are not associated with the job.
            /// If the calling process is not associated with a job, this constant has no effect. If the calling process is associated with a job, the job must set the JOB_OBJECT_LIMIT_BREAKAWAY_OK limit.
            /// </summary>
            CREATE_BREAKAWAY_FROM_JOB = 0x01000000,

            /// <summary>
            /// The new process does not inherit the error mode of the calling process. Instead, the new process gets the default error mode.
            /// This feature is particularly useful for multithreaded shell applications that run with hard errors disabled.
            /// The default behavior is for the new process to inherit the error mode of the caller. Setting this flag changes that default behavior.
            /// </summary>
            CREATE_DEFAULT_ERROR_MODE = 0x04000000,

            /// <summary>
            /// The new process has a new console, instead of inheriting its parent's console (the default). For more information, see Creation of a Console.
            /// This flag cannot be used with DETACHED_PROCESS.
            /// </summary>
            CREATE_NEW_CONSOLE = 0x00000010,

            /// <summary>
            /// The new process is the root process of a new process group. The process group includes all processes that are descendants of this root process. The process identifier of the new process group is the same as the process identifier, which is returned in the lpProcessInformation parameter. Process groups are used by the GenerateConsoleCtrlEvent function to enable sending a CTRL+BREAK signal to a group of console processes.
            /// If this flag is specified, CTRL+C signals will be disabled for all processes within the new process group.
            /// This flag is ignored if specified with <see cref="CREATE_NEW_CONSOLE"/>.
            /// </summary>
            CREATE_NEW_PROCESS_GROUP = 0x00000200,

            /// <summary>
            /// The process is a console application that is being run without a console window. Therefore, the console handle for the application is not set.
            /// This flag is ignored if the application is not a console application, or if it is used with either <see cref="CREATE_NEW_CONSOLE"/> or <see cref="DETACHED_PROCESS"/>.
            /// </summary>
            CREATE_NO_WINDOW = 0x08000000,

            /// <summary>
            /// The process is to be run as a protected process. The system restricts access to protected processes and the threads of protected processes. For more information on how processes can interact with protected processes, see Process Security and Access Rights.
            /// To activate a protected process, the binary must have a special signature. This signature is provided by Microsoft but not currently available for non-Microsoft binaries. There are currently four protected processes: media foundation, audio engine, Windows error reporting, and system. Components that load into these binaries must also be signed. Multimedia companies can leverage the first two protected processes. For more information, see Overview of the Protected Media Path.
            /// Windows Server 2003 and Windows XP:  This value is not supported.
            /// </summary>
            CREATE_PROTECTED_PROCESS = 0x00040000,

            /// <summary>
            /// Allows the caller to execute a child process that bypasses the process restrictions that would normally be applied automatically to the process.
            /// </summary>
            CREATE_PRESERVE_CODE_AUTHZ_LEVEL = 0x02000000,

            /// <summary>
            /// This flag is valid only when starting a 16-bit Windows-based application. If set, the new process runs in a private Virtual DOS Machine (VDM). By default, all 16-bit Windows-based applications run as threads in a single, shared VDM. The advantage of running separately is that a crash only terminates the single VDM; any other programs running in distinct VDMs continue to function normally. Also, 16-bit Windows-based applications that are run in separate VDMs have separate input queues. That means that if one application stops responding momentarily, applications in separate VDMs continue to receive input. The disadvantage of running separately is that it takes significantly more memory to do so. You should use this flag only if the user requests that 16-bit applications should run in their own VDM.
            /// </summary>
            CREATE_SEPARATE_WOW_VDM = 0x00000800,

            /// <summary>
            /// The flag is valid only when starting a 16-bit Windows-based application. If the DefaultSeparateVDM switch in the Windows section of WIN.INI is TRUE, this flag overrides the switch. The new process is run in the shared Virtual DOS Machine.
            /// </summary>
            CREATE_SHARED_WOW_VDM = 0x00001000,

            /// <summary>
            /// The primary thread of the new process is created in a suspended state, and does not run until the <see cref="ResumeThread"/> function is called.
            /// </summary>
            CREATE_SUSPENDED = 0x00000004,

            /// <summary>
            /// If this flag is set, the environment block pointed to by lpEnvironment uses Unicode characters. Otherwise, the environment block uses ANSI characters.
            /// </summary>
            CREATE_UNICODE_ENVIRONMENT = 0x00000400,

            /// <summary>
            /// The calling thread starts and debugs the new process. It can receive all related debug events using the WaitForDebugEvent function.
            /// </summary>
            DEBUG_ONLY_THIS_PROCESS = 0x00000002,

            /// <summary>
            /// The calling thread starts and debugs the new process and all child processes created by the new process. It can receive all related debug events using the WaitForDebugEvent function.
            /// A process that uses <see cref="DEBUG_PROCESS"/> becomes the root of a debugging chain. This continues until another process in the chain is created with <see cref="DEBUG_PROCESS"/>.
            /// If this flag is combined with <see cref="DEBUG_ONLY_THIS_PROCESS"/>, the caller debugs only the new process, not any child processes.
            /// </summary>
            DEBUG_PROCESS = 0x00000001,

            /// <summary>
            /// For console processes, the new process does not inherit its parent's console (the default). The new process can call the <see cref="AllocConsole"/> function at a later time to create a console. For more information, see Creation of a Console.
            /// This value cannot be used with <see cref="CREATE_NEW_CONSOLE"/>.
            /// </summary>
            DETACHED_PROCESS = 0x00000008,

            /// <summary>
            /// The process is created with extended startup information; the lpStartupInfo parameter specifies a <see cref="STARTUPINFOEX"/> structure.
            /// Windows Server 2003 and Windows XP:  This value is not supported.
            /// </summary>
            EXTENDED_STARTUPINFO_PRESENT = 0x00080000,

            /// <summary>
            /// The process inherits its parent's affinity. If the parent process has threads in more than one processor group, the new process inherits the group-relative affinity of an arbitrary group in use by the parent.
            /// Windows Server 2008, Windows Vista, Windows Server 2003, and Windows XP:  This value is not supported.
            /// </summary>
            INHERIT_PARENT_AFFINITY = 0x00010000,
            NORMAL_PRIORITY_CLASS = 0x00000020,
            IDLE_PRIORITY_CLASS = 0x00000040,
            HIGH_PRIORITY_CLASS = 0x00000080,
            REALTIME_PRIORITY_CLASS = 0x00000100,
            CREATE_FORCEDOS = 0x00002000,
            BELOW_NORMAL_PRIORITY_CLASS = 0x00004000,
            ABOVE_NORMAL_PRIORITY_CLASS = 0x00008000,
            PROCESS_MODE_BACKGROUND_BEGIN = 0x00100000,
            PROCESS_MODE_BACKGROUND_END = 0x00200000,
            PROFILE_USER = 0x10000000,
            PROFILE_KERNEL = 0x20000000,
            PROFILE_SERVER = 0x40000000
        }
    }
}
