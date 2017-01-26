// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

#pragma warning disable SA1625 // Element documentation must not be copied and pasted

namespace PInvoke
{
    using System;
    using System.Runtime.InteropServices;
    using System.Text;
    using static Kernel32.ACCESS_MASK.GenericRight;

    /// <summary>
    /// Exported functions from the Kernel32.dll Windows library.
    /// </summary>
    public static partial class Kernel32
    {
        /// <summary>
        ///     Used to specify to <see cref="CreateNamedPipe(string, PipeAccessMode, PipeMode, int, int, int, int, SECURITY_ATTRIBUTES*)" /> that the number of pipe instances that can be created is
        ///     limited only by the availability of system resources.
        /// </summary>
        public const int PIPE_UNLIMITED_INSTANCES = 255;

        /// <summary>
        /// All processes start at this shutdown level
        /// </summary>
        public const int DefaultShutdownLevel = 0x280;

        /// <summary>The time-out interval is the default value specified by the server process in the
        ///     <see cref="CreateNamedPipe(string, PipeAccessMode, PipeMode, int, int, int, int, SECURITY_ATTRIBUTES*)" /> function.
        ///     <para>This constant is a special value for named pipes timeouts.</para>
        /// </summary>
        public const int NMPWAIT_USE_DEFAULT_WAIT = 0x00000000;

        /// <summary>The function does not return until an instance of the named pipe is available.
        ///     <para>This constant is a special value for named pipes timeouts.</para>
        /// </summary>
        public const int NMPWAIT_WAIT_FOREVER = Constants.INFINITE;

        /// <summary>Does not wait for the named pipe. If the named pipe is not available, the function returns an error.
        ///     <para>This constant is a special value for named pipes timeouts.</para>
        /// </summary>
        public const int NMPWAIT_NOWAIT = 0x00000001;

        /// <summary>
        ///     An application-defined callback function used with the EnumResourceNames and EnumResourceNamesEx functions. It
        ///     receives the type and name of a resource. The ENUMRESNAMEPROC type defines a pointer to this callback function.
        ///     EnumResNameProc is a placeholder for the application-defined function name.
        /// </summary>
        /// <param name="hModule">
        ///     A handle to the module whose executable file contains the resources that are being enumerated.
        ///     <para>
        ///         If this parameter is <see langword="null" />, the function enumerates the resource names in the
        ///         module used to create the current process.
        ///     </para>
        /// </param>
        /// <param name="lpszType">
        ///     The type of resource for which the name is being enumerated. Alternately, rather than a pointer,
        ///     this parameter can be <see cref="MAKEINTRESOURCE" />(ID), where ID is an integer value representing a predefined
        ///     resource type.
        /// </param>
        /// <param name="lpszName">
        ///     The name of a resource of the type being enumerated. Alternately, rather than a pointer, this
        ///     parameter can be <see cref="MAKEINTRESOURCE" />(ID), where ID is the integer identifier of the resource. For more
        ///     information, see the Remarks section below.
        /// </param>
        /// <param name="lParam">
        ///     An application-defined parameter passed to the <see cref="EnumResourceNames(SafeLibraryHandle,char*,EnumResNameProc,IntPtr)" /> or
        ///     EnumResourceNamesEx function. This parameter can be used in error checking.
        /// </param>
        /// <returns>Returns TRUE to continue enumeration or FALSE to stop enumeration.</returns>
        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        public unsafe delegate bool EnumResNameProc(IntPtr hModule, char* lpszType, char* lpszName, IntPtr lParam);

        /// <summary>
        /// Callback function used with the <see cref="SetConsoleCtrlHandler"/> function.
        /// A console process uses this function to handle control signals received by the process.
        /// When the signal is received, the system creates a new thread in the process to execute the function.
        /// </summary>
        /// <param name="dwCtrlType">The type of control signal received by the handler. This parameter can be one of the following values.</param>
        /// <returns>If the function handles the control signal, it should return TRUE. If it returns FALSE, the next handler function in the list of handlers for this process is used.</returns>
        /// <remarks>
        /// <para>
        /// Because the system creates a new thread in the process to execute the handler function,
        /// it is possible that the handler function will be terminated by another thread in the process.
        /// Be sure to synchronize threads in the process with the thread for the handler function.
        /// Each console process has its own list of <see cref="HandlerRoutine"/> callbacks.
        /// Initially, this list contains only a default handler function that calls <see cref="ExitProcess"/>.
        /// A console process adds or removes additional handler functions by calling the <see cref="SetConsoleCtrlHandler"/> function,
        /// which does not affect the list of handler functions for other processes. When a console process receives any of the control signals,
        /// its handler functions are called on a last-registered, first-called basis until one of the handlers returns TRUE.
        /// If none of the handlers returns TRUE, the default handler is called.
        /// </para>
        /// <para>
        /// The <see cref="ControlType.CTRL_CLOSE_EVENT"/>, <see cref="ControlType.CTRL_LOGOFF_EVENT"/>, and <see cref="ControlType.CTRL_SHUTDOWN_EVENT"/> signals give the process
        /// an opportunity to clean up before termination. A <see cref="HandlerRoutine"/> can perform any necessary cleanup, then take one of the following actions:
        /// </para>
        /// <list>
        /// <item>Call the <see cref="ExitProcess"/> function to terminate the process.</item>
        /// <item>Return FALSE. If none of the registered handler functions returns TRUE, the default handler terminates the process.</item>
        /// <item>Return TRUE. In this case, no other handler functions are called and the system terminates the process.</item>
        /// </list>
        /// <para>
        /// A process can use the <see cref="SetProcessShutdownParameters"/> function to prevent the system from displaying a dialog box to the user during logoff or shutdown.
        /// In this case, the system terminates the process when <see cref="HandlerRoutine"/> returns TRUE or when the time-out period elapses.
        /// When a console application is run as a service, it receives a modified default console control handler.
        /// This modified handler does not call <see cref="ExitProcess"/> when processing the <see cref="ControlType.CTRL_LOGOFF_EVENT"/> and <see cref="ControlType.CTRL_SHUTDOWN_EVENT"/> signals.
        /// This allows the service to continue running after the user logs off.
        /// If the service installs its own console control handler, this handler is called before the default handler.
        /// If the installed handler calls <see cref="ExitProcess"/> when processing the <see cref="ControlType.CTRL_LOGOFF_EVENT"/> signal, the service exits when the user logs off.
        /// </para>
        /// <para>
        /// Note that a third-party library or DLL can install a console control handler for your application.
        /// If it does, this handler overrides the default handler, and can cause the application to exit when the user logs off.
        /// </para>
        /// </remarks>
        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public unsafe delegate bool HandlerRoutine(ControlType dwCtrlType);

        /// <summary>
        ///     An application-defined callback function used with the EnumResourceLanguages and EnumResourceLanguagesEx
        ///     functions. It receives the type, name, and language of a resource item. The ENUMRESLANGPROC type defines
        ///     a pointer to this callback function. EnumResLangProc is a placeholder for the application-defined
        ///     function name.
        /// </summary>
        /// <param name="hModule">
        ///     A handle to the module whose executable file contains the resources for which the languages are being
        ///     enumerated.
        ///     <para>
        ///         If this parameter is NULL, the function enumerates the resource languages in the module used to
        ///         create the current process.
        ///     </para>
        /// </param>
        /// <param name="lpType">
        ///     The type of resource for which the language is being enumerated. Alternately, rather than a pointer,
        ///     this parameter can be <see cref="MAKEINTRESOURCE" />(ID), where ID is an integer value representing a predefined
        ///     resource type. For standard resource types, see Resource Types. For more information, see the Remarks
        ///     section below.
        /// </param>
        /// <param name="lpName">
        ///     The name of the resource for which the language is being enumerated. Alternately, rather than a
        ///     pointer, this parameter can be <see cref="MAKEINTRESOURCE" />(ID), where ID is the integer identifier
        ///     of the resource. For more information, see the Remarks section below.
        /// </param>
        /// <param name="wLanguage">
        ///     The language identifier for the resource for which the language is being enumerated. The
        ///     EnumResourceLanguages or EnumResourceLanguagesEx function provides this value. For a list of the primary
        ///     language identifiers and sublanguage identifiers that constitute a language identifier, see
        ///     <see cref="MAKELANGID(ushort, ushort)" />.
        /// </param>
        /// <param name="lParam">
        ///     The application-defined parameter passed to the <see cref="EnumResourceLanguages(SafeLibraryHandle, char*, char*, EnumResLangProc, void*)"/> EnumResourceLanguages
        ///     or EnumResourceLanguagesEx function. This parameter can be used in error checking.
        /// </param>
        /// <returns>Returns TRUE to continue enumeration or FALSE to stop enumeration.</returns>
        [UnmanagedFunctionPointer(CallingConvention.Winapi)]
        public unsafe delegate bool EnumResLangProc(IntPtr hModule, char* lpType, char* lpName, LANGID wLanguage, void* lParam);

        /// <summary>
        /// Generates simple tones on the speaker. The function is synchronous; it performs an alertable wait and does not return control to its caller until the sound finishes.
        /// </summary>
        /// <param name="frequency">The frequency of the sound, in hertz. This parameter must be in the range 37 through 32,767 (0x25 through 0x7FFF).</param>
        /// <param name="duration">The duration of the sound, in milliseconds.</param>
        /// <returns>
        /// If the function succeeds, the return value is nonzero.
        /// If the function fails, the return value is zero. To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        [DllImport(nameof(Kernel32), SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool Beep(int frequency, int duration);

        /// <summary>
        /// Terminates the specified process and all of its threads.
        /// </summary>
        /// <param name="hProcess">
        /// A handle to the process to be terminated.
        /// The handle must have the PROCESS_TERMINATE access right
        /// </param>
        /// <param name="uExitCode">
        /// The exit code to be used by the process and threads terminated as a result of this call.
        /// Use the <see cref="GetExitCodeProcess"/> function to retrieve a process's exit value.
        /// Use the <see cref="GetExitCodeThread"/> function to retrieve a thread's exit value.
        /// </param>
        /// <returns>If the function succeeds, the return value is true, else the return value is zero. To get extended error information, call <see cref="GetLastError"/>.</returns>
        /// <remarks>
        /// <para>
        /// The TerminateProcess function is used to unconditionally cause a process to exit.
        /// The state of global data maintained by dynamic-link libraries (DLLs) may be compromised if TerminateProcess is used rather than <see cref="ExitProcess"/>.
        /// </para>
        /// <para>
        /// This function stops execution of all threads within the process and requests cancellation of all pending I/O.
        /// The terminated process cannot exit until all pending I/O has been completed or canceled.When a process terminates,
        /// its kernel object is not destroyed until all processes that have open handles to the process have released those handles.
        /// TerminateProcess is asynchronous; it initiates termination and returns immediately.
        /// If you need to be sure the process has terminated, call the <see cref="WaitForSingleObject"/> function with a handle to the process.
        /// A process cannot prevent itself from being terminated.
        /// </para>
        /// </remarks>
        [DllImport(nameof(Kernel32), SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool TerminateProcess(IntPtr hProcess, int uExitCode);

        /// <summary>
        /// Terminates a thread.
        /// </summary>
        /// <param name="hThread">A handle to the thread to be terminated. The handle must have the THREAD_TERMINATE access right.</param>
        /// <param name="dwExitCode">The exit code for the thread. Use the <see cref="GetExitCodeThread"/> function to retrieve a thread's exit value.</param>
        /// <returns>If the function succeeds, the return value is true, else the return value is zero. To get extended error information, call <see cref="GetLastError"/>.</returns>
        /// <remarks>
        /// TerminateThread is used to cause a thread to exit.
        /// When this occurs, the target thread has no chance to execute any user-mode code.
        /// DLLs attached to the thread are not notified that the thread is terminating.
        /// The system frees the thread's initial stack.
        /// </remarks>
        [DllImport(nameof(Kernel32), SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool TerminateThread(IntPtr hThread, int dwExitCode);

        /// <summary>
        /// Ends the calling process and all its threads.
        /// </summary>
        /// <param name="uExitCode">The exit code for the process and all threads.</param>
        /// <remarks>
        /// <para>
        /// Use the <see cref="GetExitCodeProcess"/> function to retrieve the process's exit value. Use the <see cref="GetExitCodeThread"/> function to retrieve a thread's exit value.
        /// Exiting a process causes the following:
        /// </para>
        /// <list>
        /// <item>All of the threads in the process, except the calling thread, terminate their execution without receiving a DLL_THREAD_DETACH notification.</item>
        /// <item>The states of all of the threads terminated in step 1 become signaled.</item>
        /// <item>The entry-point functions of all loaded dynamic-link libraries (DLLs) are called with DLL_PROCESS_DETACH.</item>
        /// <item>After all attached DLLs have executed any process termination code, the ExitProcess function terminates the current process, including the calling thread.</item>
        /// <item>The state of the calling thread becomes signaled.</item>
        /// <item>All of the object handles opened by the process are closed.</item>
        /// <item>The termination status of the process changes from STILL_ACTIVE to the exit value of the process.</item>
        /// <item>The state of the process object becomes signaled, satisfying any threads that had been waiting for the process to terminate.</item>
        /// </list>
        /// <para>
        /// If one of the terminated threads in the process holds a lock and the DLL detach code in one of the loaded DLLs attempts to acquire the same lock,
        /// then calling ExitProcess results in a deadlock. In contrast, if a process terminates by calling <see cref="TerminateProcess"/>,
        /// the DLLs that the process is attached to are not notified of the process termination.
        /// Therefore, if you do not know the state of all threads in your process, it is better to call <see cref="TerminateProcess"/> than <see cref="ExitProcess"/>.
        /// Note that returning from the main function of an application results in a call to <see cref="ExitProcess"/>.
        /// </para>
        /// <para>
        /// Calling ExitProcess in a DLL can lead to unexpected application or system errors.
        /// Be sure to call <see cref="ExitProcess"/> from a DLL only if you know which applications or system components
        /// will load the DLL and that it is safe to call <see cref="ExitProcess"/> in this context.
        /// Exiting a process does not cause child processes to be terminated.
        /// Exiting a process does not necessarily remove the process object from the operating system.
        /// A process object is deleted when the last handle to the process is closed.
        /// </para>
        /// </remarks>
        [DllImport(nameof(Kernel32))]
        public static extern void ExitProcess(int uExitCode);

        /// <summary>
        /// Ends the calling thread.
        /// </summary>
        /// <param name="dwExitCode">The exit code for the thread.</param>
        /// <remarks>
        /// <para>
        /// ExitThread is the preferred method of exiting a thread in C code.
        /// However, in C++ code, the thread is exited before any destructors can be called or any other automatic cleanup can be performed.
        /// Therefore, in C++ code, you should return from your thread function.
        /// When this function is called (either explicitly or by returning from a thread procedure), the current thread's stack is deallocated,
        /// all pending I/O initiated by the thread is canceled, and the thread terminates.
        /// The entry-point function of all attached dynamic-link libraries (DLLs) is invoked with a value indicating that the thread is detaching from the DLL.
        /// If the thread is the last thread in the process when this function is called, the thread's process is also terminated.
        /// The state of the thread object becomes signaled, releasing any other threads that had been waiting for the thread to terminate.
        /// The thread's termination status changes from STILL_ACTIVE to the value of the dwExitCode parameter.
        /// </para>
        /// <para>
        /// Terminating a thread does not necessarily remove the thread object from the operating system.
        /// A thread object is deleted when the last handle to the thread is closed.
        /// The <see cref="ExitProcess"/>, ExitThread, CreateThread"/>, CreateRemoteThread functions,
        /// and a process that is starting (as the result of a CreateProcess call) are serialized between each other within a process.
        /// Only one of these events can happen in an address space at a time.
        /// This means the following restrictions hold:
        /// </para>
        /// <list>
        /// <item>During process startup and DLL initialization routines, new threads can be created, but they do not begin execution until DLL initialization is done for the process.</item>
        /// <item>Only one thread in a process can be in a DLL initialization or detach routine at a time.</item>
        /// <item>ExitProcess does not return until no threads are in their DLL initialization or detach routines.</item>
        /// </list>
        /// <para>
        /// A thread in an executable that is linked to the static C run-time library(CRT) should use _beginthread and _endthread for thread management
        /// rather than CreateThread and ExitThread.
        /// Failure to do so results in small memory leaks when the thread calls ExitThread.
        /// Another work around is to link the executable to the CRT in a DLL instead of the static CRT.
        /// Note that this memory leak only occurs from a DLL if the DLL is linked to the static CRT and a thread calls the DisableThreadLibraryCalls function.
        /// Otherwise, it is safe to call CreateThread and ExitThread from a thread in a DLL that links to the static CRT.
        /// </para>
        /// </remarks>
        [DllImport(nameof(Kernel32))]
        public static extern void ExitThread(int dwExitCode);

        /// <summary>
        /// Retrieves the termination status of the specified thread.
        /// </summary>
        /// <param name="hThread">
        /// A handle to the thread. The handle must have the THREAD_QUERY_INFORMATION or THREAD_QUERY_LIMITED_INFORMATION access right.
        /// Windows Server 2003 and Windows XP:  The handle must have the THREAD_QUERY_INFORMATION access right.
        /// </param>
        /// <param name="lpExitCode">A pointer to a variable to receive the thread termination status. For more information, see Remarks.</param>
        /// <returns>If the function is succeeds, the return value is true, else the return value is zero.  To get extended error information, call <see cref="GetLastError"/>.</returns>
        /// <remarks>
        /// <para>
        /// This function returns immediately. If the specified thread has not terminated and the function succeeds, the status returned is STILL_ACTIVE.
        /// If the thread has terminated and the function succeeds, the status returned is one of the following values:
        /// </para>
        /// <list>
        /// <item>The exit value specified in the <see cref="ExitThread"/> or <see cref="TerminateThread"/> function.</item>
        /// <item>The return value from the thread function.</item>
        /// <item>he exit value of the thread's process.</item>
        /// </list>
        /// <para>
        /// Important: The GetExitCodeThread function returns a valid error code defined by the application only after the thread terminates.
        /// Therefore, an application should not use STILL_ACTIVE (259) as an error code.
        /// If a thread returns STILL_ACTIVE (259) as an error code, applications that test for this value could interpret it to mean that the thread is still running
        /// and continue to test for the completion of the thread after the thread has terminated, which could put the application into an infinite loop.
        /// </para>
        /// </remarks>
        [DllImport(nameof(Kernel32), SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetExitCodeThread(IntPtr hThread, out int lpExitCode);

        /// <summary>
        /// Retrieves the termination status of the specified process.
        /// </summary>
        /// <param name="hProcess">
        /// A handle to the process. The handle must have the PROCESS_QUERY_INFORMATION or PROCESS_QUERY_LIMITED_INFORMATION access right.
        /// Windows Server 2003 and Windows XP:  The handle must have the PROCESS_QUERY_INFORMATION access right.
        /// </param>
        /// <param name="lpExitCode">A pointer to a variable to receive the process termination status. For more information, see Remarks.</param>
        /// <returns>If the function is succeeds, the return value is true, else the return value is zero.  To get extended error information, call <see cref="GetLastError"/>.</returns>
        /// <remarks>
        /// <para>
        /// This function returns immediately.
        /// If the process has not terminated and the function succeeds, the status returned is STILL_ACTIVE.
        /// If the process has terminated and the function succeeds, the status returned is one of the following values:
        /// </para>
        /// <list>
        /// <item>The exit value specified in the <see cref="ExitProcess"/> or <see cref="TerminateProcess"/> function.</item>
        /// <item>The return value from the main or WinMain function of the process.</item>
        /// <item>The exception value for an unhandled exception that caused the process to terminate.</item>
        /// </list>
        /// <para>
        /// Important: The GetExitCodeProcess function returns a valid error code defined by the application only after the thread terminates.
        /// Therefore, an application should not use STILL_ACTIVE (259) as an error code.
        /// If a thread returns STILL_ACTIVE (259) as an error code, applications that test for this value could interpret it to mean that the thread is still running
        /// and continue to test for the completion of the thread after the thread has terminated, which could put the application into an infinite loop.
        /// </para>
        /// </remarks>
        [DllImport(nameof(Kernel32), SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetExitCodeProcess(IntPtr hProcess, out int lpExitCode);

        /// <summary>
        /// Sets shutdown parameters for the currently calling process. This function sets a shutdown order for a process relative to the other processes in the system.
        /// </summary>
        /// <param name="dwLevel">
        /// The shutdown priority for a process relative to other processes in the system. The system shuts down processes from high dwLevel values to low.
        /// The highest and lowest shutdown priorities are reserved for system components.
        /// This parameter must be in the following range of values:
        /// <list>
        /// <item>0x000-0x0FF: System reserved last shutdown range.</item>
        /// <item>100-1FF: Application reserved last shutdown range.</item>
        /// <item>200-2FF: Application reserved "in between" shutdown range.</item>
        /// <item>0x280: All processes start at this shutdown level.</item>         /// <item>300-3FF: Application reserved first shutdown range.</item>
        /// <item>400-4FF: System reserved first shutdown range.</item>
        /// </list>
        /// </param>
        /// <param name="dwFlags">Flag to indicate if a retry box should appear for the user when the process terminate.</param>
        /// <returns>If the function is succeeds, the return value is true, else the return value is zero.  To get extended error information, call <see cref="GetLastError"/>.</returns>
        /// <remarks>
        /// Applications running in the system security context do not get shut down by the operating system.
        /// They get notified of shutdown or logoff through the callback function installable via <see cref="SetConsoleCtrlHandler"/>.
        /// They also get notified in the order specified by the dwLevel parameter.
        /// </remarks>
        [DllImport(nameof(Kernel32), SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetProcessShutdownParameters(int dwLevel, ProcessShutdownFlags dwFlags);

        /// <summary>
        /// Creates a new process and its primary thread. The new process runs in the security context of the calling process.
        /// If the calling process is impersonating another user, the new process uses the token for the calling process, not the impersonation token. To run the new process in the security context of the user represented by the impersonation token, use the <see cref="CreateProcessAsUser(IntPtr, string, string, SECURITY_ATTRIBUTES*, SECURITY_ATTRIBUTES*, bool, CreateProcessFlags, void*, string, ref STARTUPINFO, out PROCESS_INFORMATION)"/> or CreateProcessWithLogonW function.
        /// </summary>
        /// <param name="lpApplicationName">
        /// The name of the module to be executed. This module can be a Windows-based application. It can be some other type of module (for example, MS-DOS or OS/2) if the appropriate subsystem is available on the local computer.
        /// The string can specify the full path and file name of the module to execute or it can specify a partial name. In the case of a partial name, the function uses the current drive and current directory to complete the specification. The function will not use the search path. This parameter must include the file name extension; no default extension is assumed.
        /// The lpApplicationName parameter can be NULL. In that case, the module name must be the first white space–delimited token in the lpCommandLine string. If you are using a long file name that contains a space, use quoted strings to indicate where the file name ends and the arguments begin; otherwise, the file name is ambiguous. For example, consider the string "c:\program files\sub dir\program name". This string can be interpreted in a number of ways.
        /// See MSDN docs for more information.
        /// </param>
        /// <param name="lpCommandLine">
        /// The command line to be executed. The maximum length of this string is 32K characters. If lpApplicationName is NULL, the module name portion of lpCommandLine is limited to MAX_PATH characters.
        /// The Unicode version of this function, CreateProcessAsUserW, can modify the contents of this string. Therefore, this parameter cannot be a pointer to read-only memory (such as a const variable or a literal string). If this parameter is a constant string, the function may cause an access violation.
        /// The lpCommandLine parameter can be NULL. In that case, the function uses the string pointed to by lpApplicationName as the command line.
        /// If both lpApplicationName and lpCommandLine are non-NULL, *lpApplicationName specifies the module to execute, and *lpCommandLine specifies the command line. The new process can use GetCommandLine to retrieve the entire command line. Console processes written in C can use the argc and argv arguments to parse the command line. Because argv[0] is the module name, C programmers generally repeat the module name as the first token in the command line.
        /// If lpApplicationName is NULL, the first white space–delimited token of the command line specifies the module name. If you are using a long file name that contains a space, use quoted strings to indicate where the file name ends and the arguments begin (see the explanation for the lpApplicationName parameter). If the file name does not contain an extension, .exe is appended. Therefore, if the file name extension is .com, this parameter must include the .com extension. If the file name ends in a period (.) with no extension, or if the file name contains a path, .exe is not appended.
        /// See MSDN docs for more information.
        /// </param>
        /// <param name="lpProcessAttributes">
        /// A pointer to a <see cref="SECURITY_ATTRIBUTES"/> structure that specifies a security descriptor for the new process object and determines whether child processes can inherit the returned handle to the process. If lpProcessAttributes is NULL or lpSecurityDescriptor is NULL, the process gets a default security descriptor and the handle cannot be inherited. The default security descriptor is that of the user referenced in the hToken parameter. This security descriptor may not allow access for the caller, in which case the process may not be opened again after it is run. The process handle is valid and will continue to have full access rights.
        /// </param>
        /// <param name="lpThreadAttributes">
        /// A pointer to a <see cref="SECURITY_ATTRIBUTES"/> structure that specifies a security descriptor for the new thread object and determines whether child processes can inherit the returned handle to the thread. If lpThreadAttributes is NULL or lpSecurityDescriptor is NULL, the thread gets a default security descriptor and the handle cannot be inherited. The default security descriptor is that of the user referenced in the hToken parameter. This security descriptor may not allow access for the caller.
        /// </param>
        /// <param name="bInheritHandles">
        /// If this parameter is TRUE, each inheritable handle in the calling process is inherited by the new process. If the parameter is FALSE, the handles are not inherited. Note that inherited handles have the same value and access rights as the original handles.
        /// Terminal Services:  You cannot inherit handles across sessions. Additionally, if this parameter is TRUE, you must create the process in the same session as the caller.
        /// </param>
        /// <param name="dwCreationFlags">
        /// The flags that control the priority class and the creation of the process. For a list of values, see Process Creation Flags.
        /// This parameter also controls the new process's priority class, which is used to determine the scheduling priorities of the process's threads. For a list of values, see GetPriorityClass. If none of the priority class flags is specified, the priority class defaults to NORMAL_PRIORITY_CLASS unless the priority class of the creating process is IDLE_PRIORITY_CLASS or BELOW_NORMAL_PRIORITY_CLASS. In this case, the child process receives the default priority class of the calling process.
        /// </param>
        /// <param name="lpEnvironment">
        /// A pointer to an environment block for the new process. If this parameter is NULL, the new process uses the environment of the calling process.
        /// An environment block consists of a null-terminated block of null-terminated strings. Each string is in the following form:
        /// name=value\0
        /// Because the equal sign is used as a separator, it must not be used in the name of an environment variable.
        /// An environment block can contain either Unicode or ANSI characters. If the environment block pointed to by lpEnvironment contains Unicode characters, be sure that dwCreationFlags includes CREATE_UNICODE_ENVIRONMENT. If this parameter is NULL and the environment block of the parent process contains Unicode characters, you must also ensure that dwCreationFlags includes CREATE_UNICODE_ENVIRONMENT.
        /// The ANSI version of this function, CreateProcessAsUserA fails if the total size of the environment block for the process exceeds 32,767 characters.
        /// Note that an ANSI environment block is terminated by two zero bytes: one for the last string, one more to terminate the block. A Unicode environment block is terminated by four zero bytes: two for the last string, two more to terminate the block.
        /// See MSDN docs for more information.
        /// </param>
        /// <param name="lpCurrentDirectory">
        /// The full path to the current directory for the process. The string can also specify a UNC path.
        /// If this parameter is NULL, the new process will have the same current drive and directory as the calling process. (This feature is provided primarily for shells that need to start an application and specify its initial drive and working directory.)
        /// </param>
        /// <param name="lpStartupInfo">
        /// A pointer to a <see cref="STARTUPINFO"/> or <see cref="STARTUPINFOEX"/> structure.
        /// The user must have full access to both the specified window station and desktop. If you want the process to be interactive, specify winsta0\default. If the lpDesktop member is NULL, the new process inherits the desktop and window station of its parent process. If this member is an empty string, "", the new process connects to a window station using the rules described in Process Connection to a Window Station.
        /// To set extended attributes, use a <see cref="STARTUPINFOEX"/> structure and specify <see cref="CreateProcessFlags.EXTENDED_STARTUPINFO_PRESENT"/> in the <paramref name="dwCreationFlags"/> parameter.
        /// Handles in <see cref="STARTUPINFO"/> or <see cref="STARTUPINFOEX"/> must be closed with CloseHandle when they are no longer needed.
        /// Important  The caller is responsible for ensuring that the standard handle fields in <see cref="STARTUPINFO"/> contain valid handle values. These fields are copied unchanged to the child process without validation, even when the dwFlags member specifies <see cref="StartupInfoFlags.STARTF_USESTDHANDLES"/>. Incorrect values can cause the child process to misbehave or crash. Use the Application Verifier runtime verification tool to detect invalid handles.
        /// </param>
        /// <param name="lpProcessInformation">
        /// A pointer to a <see cref="PROCESS_INFORMATION"/> structure that receives identification information about the new process.
        /// Handles in <see cref="PROCESS_INFORMATION"/> must be closed with CloseHandle when they are no longer needed.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is nonzero.
        /// If the function fails, the return value is zero. To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        [DllImport(api_ms_win_core_processthreads_l1_1_1, SetLastError = true, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static unsafe extern bool CreateProcess(
            string lpApplicationName,
            string lpCommandLine,
            [Friendly(FriendlyFlags.In | FriendlyFlags.Optional)] SECURITY_ATTRIBUTES* lpProcessAttributes,
            [Friendly(FriendlyFlags.In | FriendlyFlags.Optional)] SECURITY_ATTRIBUTES* lpThreadAttributes,
            [MarshalAs(UnmanagedType.Bool)] bool bInheritHandles,
            CreateProcessFlags dwCreationFlags,
            void* lpEnvironment, // pointer because it may point to unicode or ANSI characters, based on a flag.
            string lpCurrentDirectory,
            ref STARTUPINFO lpStartupInfo,
            out PROCESS_INFORMATION lpProcessInformation);

        /// <summary>
        /// Creates a new process and its primary thread. The new process runs in the security context of the user represented by the specified token.
        /// Typically, the process that calls the CreateProcessAsUser function must have the SE_INCREASE_QUOTA_NAME privilege and may require the SE_ASSIGNPRIMARYTOKEN_NAME privilege if the token is not assignable. If this function fails with ERROR_PRIVILEGE_NOT_HELD (1314), use the CreateProcessWithLogonW function instead. CreateProcessWithLogonW requires no special privileges, but the specified user account must be allowed to log on interactively. Generally, it is best to use CreateProcessWithLogonW to create a process with alternate credentials.
        /// </summary>
        /// <param name="hToken">
        /// A handle to the primary token that represents a user. The handle must have the TOKEN_QUERY, TOKEN_DUPLICATE, and TOKEN_ASSIGN_PRIMARY access rights. For more information, see Access Rights for Access-Token Objects. The user represented by the token must have read and execute access to the application specified by the <paramref name="lpApplicationName"/> or the <paramref name="lpCommandLine"/> parameter.
        /// To get a primary token that represents the specified user, call the LogonUser function. Alternatively, you can call the DuplicateTokenEx function to convert an impersonation token into a primary token. This allows a server application that is impersonating a client to create a process that has the security context of the client.
        /// If hToken is a restricted version of the caller's primary token, the SE_ASSIGNPRIMARYTOKEN_NAME privilege is not required. If the necessary privileges are not already enabled, CreateProcessAsUser enables them for the duration of the call. For more information, see Running with Special Privileges.
        /// Terminal Services:  The process is run in the session specified in the token. By default, this is the same session that called LogonUser. To change the session, use the SetTokenInformation function.
        /// </param>
        /// <param name="lpApplicationName">
        /// The name of the module to be executed. This module can be a Windows-based application. It can be some other type of module (for example, MS-DOS or OS/2) if the appropriate subsystem is available on the local computer.
        /// The string can specify the full path and file name of the module to execute or it can specify a partial name. In the case of a partial name, the function uses the current drive and current directory to complete the specification. The function will not use the search path. This parameter must include the file name extension; no default extension is assumed.
        /// The lpApplicationName parameter can be NULL. In that case, the module name must be the first white space–delimited token in the lpCommandLine string. If you are using a long file name that contains a space, use quoted strings to indicate where the file name ends and the arguments begin; otherwise, the file name is ambiguous. For example, consider the string "c:\program files\sub dir\program name". This string can be interpreted in a number of ways.
        /// See MSDN docs for more information.
        /// </param>
        /// <param name="lpCommandLine">
        /// The command line to be executed. The maximum length of this string is 32K characters. If lpApplicationName is NULL, the module name portion of lpCommandLine is limited to MAX_PATH characters.
        /// The Unicode version of this function, CreateProcessAsUserW, can modify the contents of this string. Therefore, this parameter cannot be a pointer to read-only memory (such as a const variable or a literal string). If this parameter is a constant string, the function may cause an access violation.
        /// The lpCommandLine parameter can be NULL. In that case, the function uses the string pointed to by lpApplicationName as the command line.
        /// If both lpApplicationName and lpCommandLine are non-NULL, *lpApplicationName specifies the module to execute, and *lpCommandLine specifies the command line. The new process can use GetCommandLine to retrieve the entire command line. Console processes written in C can use the argc and argv arguments to parse the command line. Because argv[0] is the module name, C programmers generally repeat the module name as the first token in the command line.
        /// If lpApplicationName is NULL, the first white space–delimited token of the command line specifies the module name. If you are using a long file name that contains a space, use quoted strings to indicate where the file name ends and the arguments begin (see the explanation for the lpApplicationName parameter). If the file name does not contain an extension, .exe is appended. Therefore, if the file name extension is .com, this parameter must include the .com extension. If the file name ends in a period (.) with no extension, or if the file name contains a path, .exe is not appended.
        /// See MSDN docs for more information.
        /// </param>
        /// <param name="lpProcessAttributes">
        /// A pointer to a <see cref="SECURITY_ATTRIBUTES"/> structure that specifies a security descriptor for the new process object and determines whether child processes can inherit the returned handle to the process. If lpProcessAttributes is NULL or lpSecurityDescriptor is NULL, the process gets a default security descriptor and the handle cannot be inherited. The default security descriptor is that of the user referenced in the hToken parameter. This security descriptor may not allow access for the caller, in which case the process may not be opened again after it is run. The process handle is valid and will continue to have full access rights.
        /// </param>
        /// <param name="lpThreadAttributes">
        /// A pointer to a <see cref="SECURITY_ATTRIBUTES"/> structure that specifies a security descriptor for the new thread object and determines whether child processes can inherit the returned handle to the thread. If lpThreadAttributes is NULL or lpSecurityDescriptor is NULL, the thread gets a default security descriptor and the handle cannot be inherited. The default security descriptor is that of the user referenced in the hToken parameter. This security descriptor may not allow access for the caller.
        /// </param>
        /// <param name="bInheritHandles">
        /// If this parameter is TRUE, each inheritable handle in the calling process is inherited by the new process. If the parameter is FALSE, the handles are not inherited. Note that inherited handles have the same value and access rights as the original handles.
        /// Terminal Services:  You cannot inherit handles across sessions. Additionally, if this parameter is TRUE, you must create the process in the same session as the caller.
        /// </param>
        /// <param name="dwCreationFlags">
        /// The flags that control the priority class and the creation of the process. For a list of values, see Process Creation Flags.
        /// This parameter also controls the new process's priority class, which is used to determine the scheduling priorities of the process's threads. For a list of values, see GetPriorityClass. If none of the priority class flags is specified, the priority class defaults to NORMAL_PRIORITY_CLASS unless the priority class of the creating process is IDLE_PRIORITY_CLASS or BELOW_NORMAL_PRIORITY_CLASS. In this case, the child process receives the default priority class of the calling process.
        /// </param>
        /// <param name="lpEnvironment">
        /// A pointer to an environment block for the new process. If this parameter is NULL, the new process uses the environment of the calling process.
        /// An environment block consists of a null-terminated block of null-terminated strings. Each string is in the following form:
        /// name=value\0
        /// Because the equal sign is used as a separator, it must not be used in the name of an environment variable.
        /// An environment block can contain either Unicode or ANSI characters. If the environment block pointed to by lpEnvironment contains Unicode characters, be sure that dwCreationFlags includes CREATE_UNICODE_ENVIRONMENT. If this parameter is NULL and the environment block of the parent process contains Unicode characters, you must also ensure that dwCreationFlags includes CREATE_UNICODE_ENVIRONMENT.
        /// The ANSI version of this function, CreateProcessAsUserA fails if the total size of the environment block for the process exceeds 32,767 characters.
        /// Note that an ANSI environment block is terminated by two zero bytes: one for the last string, one more to terminate the block. A Unicode environment block is terminated by four zero bytes: two for the last string, two more to terminate the block.
        /// See MSDN docs for more information.
        /// </param>
        /// <param name="lpCurrentDirectory">
        /// The full path to the current directory for the process. The string can also specify a UNC path.
        /// If this parameter is NULL, the new process will have the same current drive and directory as the calling process. (This feature is provided primarily for shells that need to start an application and specify its initial drive and working directory.)
        /// </param>
        /// <param name="lpStartupInfo">
        /// A pointer to a <see cref="STARTUPINFO"/> or <see cref="STARTUPINFOEX"/> structure.
        /// The user must have full access to both the specified window station and desktop. If you want the process to be interactive, specify winsta0\default. If the lpDesktop member is NULL, the new process inherits the desktop and window station of its parent process. If this member is an empty string, "", the new process connects to a window station using the rules described in Process Connection to a Window Station.
        /// To set extended attributes, use a <see cref="STARTUPINFOEX"/> structure and specify <see cref="CreateProcessFlags.EXTENDED_STARTUPINFO_PRESENT"/> in the <paramref name="dwCreationFlags"/> parameter.
        /// Handles in <see cref="STARTUPINFO"/> or <see cref="STARTUPINFOEX"/> must be closed with CloseHandle when they are no longer needed.
        /// Important  The caller is responsible for ensuring that the standard handle fields in <see cref="STARTUPINFO"/> contain valid handle values. These fields are copied unchanged to the child process without validation, even when the dwFlags member specifies <see cref="StartupInfoFlags.STARTF_USESTDHANDLES"/>. Incorrect values can cause the child process to misbehave or crash. Use the Application Verifier runtime verification tool to detect invalid handles.
        /// </param>
        /// <param name="lpProcessInformation">
        /// A pointer to a <see cref="PROCESS_INFORMATION"/> structure that receives identification information about the new process.
        /// Handles in <see cref="PROCESS_INFORMATION"/> must be closed with CloseHandle when they are no longer needed.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is nonzero.
        /// If the function fails, the return value is zero. To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        [DllImport(api_ms_win_core_processthreads_l1_1_1, SetLastError = true, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static unsafe extern bool CreateProcessAsUser(
            IntPtr hToken,
            string lpApplicationName,
            string lpCommandLine,
            [Friendly(FriendlyFlags.Optional | FriendlyFlags.In)] SECURITY_ATTRIBUTES* lpProcessAttributes,
            [Friendly(FriendlyFlags.Optional | FriendlyFlags.In)] SECURITY_ATTRIBUTES* lpThreadAttributes,
            [MarshalAs(UnmanagedType.Bool)] bool bInheritHandles,
            CreateProcessFlags dwCreationFlags,
            void* lpEnvironment, // pointer because it may point to unicode or ANSI characters, based on a flag.
            string lpCurrentDirectory,
            ref STARTUPINFO lpStartupInfo,
            out PROCESS_INFORMATION lpProcessInformation);

        /// <summary>
        /// Retrieves the contents of the <see cref="STARTUPINFO"/> structure that was specified when the calling process was created.
        /// </summary>
        /// <param name="lpStartupInfo">
        /// A pointer to a <see cref="STARTUPINFO"/> structure that receives the startup information.
        /// </param>
        /// <remarks>
        /// This function does not return a value, and does not fail.
        /// </remarks>
        [DllImport(api_ms_win_core_processthreads_l1_1_1, CharSet = CharSet.Unicode)]
        public static extern void GetStartupInfo(
            out STARTUPINFO lpStartupInfo);

        /// <summary>
        /// Initializes the specified list of attributes for process and thread creation.
        /// </summary>
        /// <param name="lpAttributeList">
        /// The attribute list. This parameter can be NULL to determine the buffer size required to support the specified number of attributes.
        /// </param>
        /// <param name="dwAttributeCount">
        /// The count of attributes to be added to the list.
        /// </param>
        /// <param name="dwFlags">
        /// This parameter is reserved and must be zero.
        /// </param>
        /// <param name="lpSize">
        /// If lpAttributeList is not NULL, this parameter specifies the size in bytes of the lpAttributeList buffer on input. On output, this parameter receives the size in bytes of the initialized attribute list.
        /// If lpAttributeList is NULL, this parameter receives the required buffer size in bytes.</param>
        /// <returns>
        /// If the function succeeds, the return value is nonzero.
        /// If the function fails, the return value is zero. To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// First, call this function with the <paramref name="dwAttributeCount "/> parameter set to the maximum number of attributes you will be using and the lpAttributeList to NULL. The function returns the required buffer size in bytes in the lpSize parameter. Allocate enough space for the data in the lpAttributeList buffer and call the function again to initialize the buffer.
        /// To add attributes to the list, call the <see cref="UpdateProcThreadAttribute(PROC_THREAD_ATTRIBUTE_LIST*, uint, ref uint, void*, IntPtr, ref IntPtr, ref IntPtr)"/> function. To specify these attributes when creating a process, specify <see cref="CreateProcessFlags.EXTENDED_STARTUPINFO_PRESENT"/> in the dwCreationFlag parameter and a <see cref="STARTUPINFOEX"/> structure in the lpStartupInfo parameter. Note that you can specify the same <see cref="STARTUPINFOEX"/> structure to multiple child processes.
        /// When you have finished using the list, call the <see cref="DeleteProcThreadAttributeList(PROC_THREAD_ATTRIBUTE_LIST*)"/> function.
        /// </remarks>
        [DllImport(api_ms_win_core_processthreads_l1_1_1, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static unsafe extern bool InitializeProcThreadAttributeList(
            PROC_THREAD_ATTRIBUTE_LIST* lpAttributeList,
            int dwAttributeCount,
            uint dwFlags,
            ref IntPtr lpSize); // SIZE_T (the size varies with the bitness)

        /// <summary>
        /// Updates the specified attribute in a list of attributes for process and thread creation.
        /// </summary>
        /// <param name="lpAttributeList">
        /// A pointer to an attribute list created by the <see cref="InitializeProcThreadAttributeList(PROC_THREAD_ATTRIBUTE_LIST*, int, uint, ref IntPtr)"/> function.
        /// </param>
        /// <param name="dwFlags">
        /// This parameter is reserved and must be zero.
        /// </param>
        /// <param name="Attribute">
        /// The attribute key to update in the attribute list.
        /// </param>
        /// <param name="lpValue">
        /// A pointer to the attribute value. This value should persist until the attribute is destroyed using the <see cref="DeleteProcThreadAttributeList(PROC_THREAD_ATTRIBUTE_LIST*)"/> function.
        /// </param>
        /// <param name="cbSize">
        /// The size of the attribute value specified by the <paramref name="lpValue"/> parameter.
        /// </param>
        /// <param name="lpPreviousValue">
        /// This parameter is reserved and must be NULL.
        /// </param>
        /// <param name="lpReturnSize">This parameter is reserved and must be NULL.</param>
        /// <returns>
        /// If the function succeeds, the return value is nonzero.
        /// If the function fails, the return value is zero. To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        [DllImport(api_ms_win_core_processthreads_l1_1_1, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static unsafe extern bool UpdateProcThreadAttribute(
            PROC_THREAD_ATTRIBUTE_LIST* lpAttributeList,
            uint dwFlags,
            ref uint Attribute,
            void* lpValue,
            IntPtr cbSize, // SIZE_T varies by bitness
            ref IntPtr lpPreviousValue,
            ref IntPtr lpReturnSize);

        /// <summary>
        /// Deletes the specified list of attributes for process and thread creation.
        /// </summary>
        /// <param name="lpAttributeList">
        /// The attribute list. This list is created by the <see cref="InitializeProcThreadAttributeList(PROC_THREAD_ATTRIBUTE_LIST*, int, uint, ref IntPtr)"/> function.
        /// </param>
        [DllImport(api_ms_win_core_processthreads_l1_1_1)]
        public static unsafe extern void DeleteProcThreadAttributeList(
            PROC_THREAD_ATTRIBUTE_LIST* lpAttributeList);

        /// <summary>
        /// Allocates a new console for the calling process.
        /// </summary>
        /// <returns>
        /// If the function succeeds, the return value is nonzero.
        /// If the function fails, the return value is zero. To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        [DllImport(api_ms_win_core_console_l1_1_0, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool AllocConsole();

        /// <summary>
        /// Detaches the calling process from its console.
        /// </summary>
        /// <returns>
        /// If the function succeeds, the return value is nonzero.
        /// If the function fails, the return value is zero. To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        [DllImport(api_ms_win_core_console_l2_1_0, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool FreeConsole();

        /// <summary>
        /// Attaches the calling process to the console of the specified process.
        /// </summary>
        /// <param name="dwProcessId">
        /// The identifier of the process whose console is to be used. This parameter can be one of the following values.
        /// pid: Use the console of the specified process.
        /// -1: Use the console of the parent of the current process.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is nonzero.
        /// If the function fails, the return value is zero. To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        [DllImport(api_ms_win_core_console_l2_1_0, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool AttachConsole(int dwProcessId);

        /// <summary>
        /// Creates or opens a file or I/O device. The most commonly used I/O devices are as follows: file, file stream, directory, physical disk, volume, console buffer, tape drive, communications resource, mailslot, and pipe. The function returns a handle that can be used to access the file or device for various types of I/O depending on the file or device and the flags and attributes specified.
        /// To perform this operation as a transacted operation, which results in a handle that can be used for transacted I/O, use the CreateFileTransacted function.
        /// </summary>
        /// <param name="filename">
        /// The name of the file or device to be created or opened. You may use either forward slashes (/) or backslashes (\) in this name.
        /// In the ANSI version of this function, the name is limited to <see cref="MAX_PATH"/> characters. To extend this limit to 32,767 wide characters, call the Unicode version of the function and prepend "\\?\" to the path. For more information, see Naming Files, Paths, and Namespaces.
        /// For information on special device names, see Defining an MS-DOS Device Name.
        /// To create a file stream, specify the name of the file, a colon, and then the name of the stream.For more information, see File Streams.
        /// </param>
        /// <param name="access">
        /// The requested access to the file or device, which can be summarized as read, write, both or neither zero).
        /// The most commonly used values are <see cref="GENERIC_READ"/>, <see cref="GENERIC_WRITE"/>, or both(<see cref="GENERIC_READ"/> | <see cref="GENERIC_WRITE"/>). For more information, see Generic Access Rights, File Security and Access Rights, File Access Rights Constants, and ACCESS_MASK.
        /// If this parameter is zero, the application can query certain metadata such as file, directory, or device attributes without accessing that file or device, even if <see cref="GENERIC_READ"/> access would have been denied.
        /// You cannot request an access mode that conflicts with the sharing mode that is specified by the dwShareMode parameter in an open request that already has an open handle.
        /// For more information, see the Remarks section of this topic and Creating and Opening Files.
        /// Common specific rights are defined in <seealso cref="FileAccess"/>.
        /// </param>
        /// <param name="share">
        /// The requested sharing mode of the file or device, which can be read, write, both, delete, all of these, or none (refer to the following table). Access requests to attributes or extended attributes are not affected by this flag.
        /// If this parameter is zero and <see cref="CreateFile(string, ACCESS_MASK, FileShare, SECURITY_ATTRIBUTES*, CreationDisposition, CreateFileFlags, SafeObjectHandle)"/> succeeds, the file or device cannot be shared and cannot be opened again until the handle to the file or device is closed. For more information, see the Remarks section.
        /// You cannot request a sharing mode that conflicts with the access mode that is specified in an existing request that has an open handle. <see cref="CreateFile(string, ACCESS_MASK, FileShare, SECURITY_ATTRIBUTES*, CreationDisposition, CreateFileFlags, SafeObjectHandle)"/> would fail and the <see cref="GetLastError"/> function would return ERROR_SHARING_VIOLATION.
        /// To enable a process to share a file or device while another process has the file or device open, use a compatible combination of one or more of the following values. For more information about valid combinations of this parameter with the dwDesiredAccess parameter, see Creating and Opening Files.
        /// </param>
        /// <param name="securityAttributes">
        /// A pointer to a SECURITY_ATTRIBUTES structure that contains two separate but related data members: an optional security descriptor, and a Boolean value that determines whether the returned handle can be inherited by child processes.
        /// This parameter can be NULL.
        /// If this parameter is NULL, the handle returned by CreateFile cannot be inherited by any child processes the application may create and the file or device associated with the returned handle gets a default security descriptor.
        /// The <see cref="SECURITY_ATTRIBUTES.lpSecurityDescriptor"/> member of the structure specifies a <see cref="SECURITY_DESCRIPTOR"/> for a file or device. If this member is NULL, the file or device associated with the returned handle is assigned a default security descriptor.
        /// CreateFile ignores the <see cref="SECURITY_ATTRIBUTES.lpSecurityDescriptor"/> member when opening an existing file or device, but continues to use the <see cref="SECURITY_ATTRIBUTES.bInheritHandle"/> member.
        /// The <see cref="SECURITY_ATTRIBUTES.bInheritHandle"/> member of the structure specifies whether the returned handle can be inherited.
        /// </param>
        /// <param name="creationDisposition">
        /// An action to take on a file or device that exists or does not exist.
        /// For devices other than files, this parameter is usually set to <see cref="CreationDisposition.OPEN_EXISTING"/>.
        /// </param>
        /// <param name="flagsAndAttributes">
        /// The file or device attributes and flags, <see cref="CreateFileFlags.FILE_ATTRIBUTE_NORMAL"/> being the most common default value for files.
        /// This parameter can include any combination of the available file attributes (CreateFileFlags.*Attribute). All other file attributes override <see cref="CreateFileFlags.FILE_ATTRIBUTE_NORMAL"/>.
        /// This parameter can also contain combinations of flags (CreateFileFlags.*Flag) for control of file or device caching behavior, access modes, and other special-purpose flags. These combine with any CreateFileFlags.*Attribute values.
        /// This parameter can also contain Security Quality of Service (SQOS) information by specifying the SECURITY_SQOS_PRESENT flag. Additional SQOS-related flags information is presented in the table following the attributes and flags tables.
        /// Note When CreateFile opens an existing file, it generally combines the file flags with the file attributes of the existing file, and ignores any file attributes supplied as part of dwFlagsAndAttributes. Special cases are detailed in Creating and Opening Files.
        /// Some of the following file attributes and flags may only apply to files and not necessarily all other types of devices that CreateFile can open.For additional information, see the Remarks section of this topic and Creating and Opening Files.
        /// For more advanced access to file attributes, see SetFileAttributes. For a complete list of all file attributes with their values and descriptions, see File Attribute Constants.
        /// </param>
        /// <param name="templateFile">
        /// A valid handle to a template file with the <see cref="GENERIC_READ"/> access right. The template file supplies file attributes and extended attributes for the file that is being created.
        /// This parameter can be NULL.
        /// When opening an existing file, CreateFile ignores this parameter.
        /// When opening a new encrypted file, the file inherits the discretionary access control list from its parent directory.For additional information, see File Encryption.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is an open handle to the specified file, device, named pipe, or mail slot.
        /// If the function fails, the return value is INVALID_HANDLE_VALUE.To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        [DllImport(api_ms_win_core_file_l1_2_0, CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern unsafe SafeObjectHandle CreateFile(
            string filename,
            ACCESS_MASK access,
            FileShare share,
            [Friendly(FriendlyFlags.In | FriendlyFlags.Optional)] SECURITY_ATTRIBUTES* securityAttributes,
            CreationDisposition creationDisposition,
            CreateFileFlags flagsAndAttributes,
            SafeObjectHandle templateFile);

        /// <summary>
        /// Searches a directory for a file or subdirectory with a name that matches a specific name (or partial name if wildcards are used).
        /// To specify additional attributes to use in a search, use the FindFirstFileEx function.
        /// To perform this operation as a transacted operation, use the FindFirstFileTransacted function.
        /// </summary>
        /// <param name="lpFileName">
        /// The directory or path, and the file name, which can include wildcard characters, for example, an asterisk (*) or a question mark (?).
        /// This parameter should not be NULL, an invalid string (for example, an empty string or a string that is missing the terminating null character), or end in a trailing backslash(\).
        /// If the string ends with a wildcard, period(.), or directory name, the user must have access permissions to the root and all subdirectories on the path.
        /// In the ANSI version of this function, the name is limited to MAX_PATH characters. To extend this limit to 32,767 wide characters, call the Unicode version of the function and prepend "\\?\" to the path. For more information, see Naming a File.
        /// </param>
        /// <param name="lpFindFileData">A pointer to the WIN32_FIND_DATA structure that receives information about a found file or directory.</param>
        /// <returns>
        /// If the function succeeds, the return value is a search handle used in a subsequent call to FindNextFile or FindClose, and the lpFindFileData parameter contains information about the first file or directory found.
        /// If the function fails or fails to locate files from the search string in the lpFileName parameter, the return value is INVALID_HANDLE_VALUE and the contents of lpFindFileData are indeterminate.To get extended error information, call the <see cref="GetLastError"/> function.
        /// If the function fails because no matching files can be found, the <see cref="GetLastError"/> function returns ERROR_FILE_NOT_FOUND.
        /// </returns>
        [DllImport(api_ms_win_core_file_l1_2_0, SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern SafeFindFilesHandle FindFirstFile(string lpFileName, out WIN32_FIND_DATA lpFindFileData);

        /// <summary>
        /// Continues a file search from a previous call to the <see cref="FindFirstFile"/>, FindFirstFileEx, or FindFirstFileTransacted functions.
        /// </summary>
        /// <param name="hFindFile">The search handle returned by a previous call to the FindFirstFile or FindFirstFileEx function.</param>
        /// <param name="lpFindFileData">A pointer to the WIN32_FIND_DATA structure that receives information about the found file or subdirectory.</param>
        /// <returns>
        /// If the function succeeds, the return value is nonzero and the lpFindFileData parameter contains information about the next file or directory found.
        /// If the function fails, the return value is zero and the contents of lpFindFileData are indeterminate. To get extended error information, call the <see cref="GetLastError"/> function.
        /// If the function fails because no more matching files can be found, the <see cref="GetLastError"/> function returns ERROR_NO_MORE_FILES.
        /// </returns>
        [DllImport(api_ms_win_core_file_l1_2_0, SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern bool FindNextFile(SafeFindFilesHandle hFindFile, out WIN32_FIND_DATA lpFindFileData);

        /// <summary>
        /// Takes a snapshot of the specified processes, as well as the heaps, modules, and threads used by these
        /// processes.
        /// </summary>
        /// <param name="dwFlags">The portions of the system to be included in the snapshot.</param>
        /// <param name="th32ProcessID">
        /// The process identifier of the process to be included in the snapshot. This parameter can be zero to indicate the
        /// current process. This parameter is used when the <see cref="CreateToolhelp32SnapshotFlags.TH32CS_SNAPHEAPLIST" />,
        /// <see cref="CreateToolhelp32SnapshotFlags.TH32CS_SNAPMODULE" />,
        /// <see cref="CreateToolhelp32SnapshotFlags.TH32CS_SNAPMODULE32" />, or
        /// <see cref="CreateToolhelp32SnapshotFlags.TH32CS_SNAPALL" /> value is specified. Otherwise, it is ignored and all
        /// processes are included in the snapshot.
        /// <para>
        /// If the specified process is the Idle process or one of the CSRSS processes, this function fails and the last
        /// error code is <see cref="Win32ErrorCode.ERROR_ACCESS_DENIED" /> because their access restrictions prevent user-level
        /// code from opening them.
        /// </para>
        /// <para>
        /// If the specified process is a 64-bit process and the caller is a 32-bit process, this function fails and the last
        /// error code is <see cref="Win32ErrorCode.ERROR_PARTIAL_COPY" />.
        /// </para>
        /// </param>
        /// <returns>
        /// If the function succeeds, it returns an open handle to the specified snapshot.
        /// <para>
        /// If the function fails, it returns <see cref="INVALID_HANDLE_VALUE" />. To get extended error information, call
        /// <see cref="Marshal.GetLastWin32Error" />. Possible error codes include
        /// <see cref="Win32ErrorCode.ERROR_BAD_LENGTH" />.
        /// </para>
        /// </returns>
        /// <remarks>
        /// The snapshot taken by this function is examined by the other tool help functions to provide their results.Access to the
        /// snapshot is read only.The snapshot handle acts as an object handle and is subject to the same rules regarding which
        /// processes and threads it is valid in.
        /// <para>
        /// To enumerate the heap or module states for all processes, specify
        /// <see cref="CreateToolhelp32SnapshotFlags.TH32CS_SNAPALL" /> and set <paramref name="th32ProcessID" /> to zero.Then, for
        /// each additional process in the snapshot, call CreateToolhelp32Snapshot again, specifying its process identifier and the
        /// <see cref="CreateToolhelp32SnapshotFlags.TH32CS_SNAPHEAPLIST" /> or
        /// <see cref="CreateToolhelp32SnapshotFlags.TH32CS_SNAPMODULE" /> value.
        /// </para>
        /// <para>
        /// When taking snapshots that include heaps and modules for a process other than the current process, the
        /// CreateToolhelp32Snapshot function can fail or return incorrect information for a variety of reasons. For example, if
        /// the loader data table in the target process is corrupted or not initialized, or if the module list changes during the
        /// function call as a result of DLLs being loaded or unloaded, the function might fail with
        /// <see cref="Win32ErrorCode.ERROR_BAD_LENGTH" /> or other error code. Ensure that the target process was not started in a
        /// suspended state, and try calling the function again. If the function fails with
        /// <see cref="Win32ErrorCode.ERROR_BAD_LENGTH" /> when called with
        /// <see cref="CreateToolhelp32SnapshotFlags.TH32CS_SNAPMODULE" /> or
        /// <see cref="CreateToolhelp32SnapshotFlags.TH32CS_SNAPMODULE32" />, call the function again until it succeeds.
        /// </para>
        /// <para>
        /// The <see cref="CreateToolhelp32SnapshotFlags.TH32CS_SNAPMODULE" /> and
        /// <see cref="CreateToolhelp32SnapshotFlags.TH32CS_SNAPMODULE32" /> flags do not retrieve handles for modules that were
        /// loaded with the LOAD_LIBRARY_AS_DATAFILE or similar flags. For more information, see LoadLibraryEx.
        /// </para>
        /// <para>To destroy the snapshot, call <see cref="SafeHandle.Close" /> on the returned handle.</para>
        /// <para>
        /// Note that you can use the
        /// <see cref="QueryFullProcessImageName(SafeObjectHandle, QueryFullProcessImageNameFlags, char*, ref int)" />
        /// function to retrieve the full name of an executable image for both 32- and 64-bit processes from a 32-bit process.
        /// </para>
        /// </remarks>
        [DllImport(nameof(Kernel32), SetLastError = true)]
        public static extern SafeObjectHandle CreateToolhelp32Snapshot(
            CreateToolhelp32SnapshotFlags dwFlags,
            int th32ProcessID);

        /// <summary>Retrieves information about the first process encountered in a system snapshot.</summary>
        /// <param name="hSnapshot">
        /// A handle to the snapshot returned from a previous call to the
        /// <see cref="CreateToolhelp32Snapshot" /> function.
        /// </param>
        /// <param name="lppe">
        /// Contains process information such as the name of the executable file, the process identifier, and
        /// the process identifier of the parent process.
        /// </param>
        /// <returns>
        /// Returns <see langword="true" /> if the first entry of the process list has been copied to the buffer or
        /// <see langword="false" /> otherwise. The <see cref="Win32ErrorCode.ERROR_NO_MORE_FILES" /> error value is returned by
        /// the <see cref="Marshal.GetLastWin32Error" /> function if no processes exist or the snapshot does not contain process
        /// information.
        /// </returns>
        [DllImport(nameof(Kernel32), SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern unsafe bool Process32First(
            SafeObjectHandle hSnapshot,
            [Friendly(FriendlyFlags.Bidirectional)] PROCESSENTRY32* lppe);

        /// <summary>Retrieves information about the next process recorded in a system snapshot.</summary>
        /// <param name="hSnapshot">
        /// A handle to the snapshot returned from a previous call to the
        /// <see cref="CreateToolhelp32Snapshot" /> function.
        /// </param>
        /// <param name="lppe">A <see cref="PROCESSENTRY32" /> structure.</param>
        /// <returns>
        /// Returns <see langword="true" /> if the next entry of the process list has been copied to the buffer or
        /// <see langword="false" /> otherwise. The <see cref="Win32ErrorCode.ERROR_NO_MORE_FILES" /> error value is returned by
        /// the <see cref="Marshal.GetLastWin32Error" /> function if no processes exist or the snapshot does not contain process
        /// information.
        /// </returns>
        /// <remarks>
        /// To retrieve information about the first process recorded in a snapshot, use the
        /// <see cref="Process32First(SafeObjectHandle,PROCESSENTRY32*)" />
        /// function.
        /// </remarks>
        [DllImport(nameof(Kernel32), SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern unsafe bool Process32Next(
            SafeObjectHandle hSnapshot,
            [Friendly(FriendlyFlags.Bidirectional)] PROCESSENTRY32* lppe);

        /// <summary>
        /// Retrieves information about the first module associated with a process.
        /// </summary>
        /// <param name="hSnapshot">A handle to the snapshot returned from a previous call to the <see cref="CreateToolhelp32Snapshot" /> function.</param>
        /// <param name="lpme">A <see cref="MODULEENTRY32"/> structure.</param>
        /// <returns>
        /// Returns <see langword="true" /> if the first entry of the module list has been copied to the buffer or
        /// <see langword="false" /> otherwise. The <see cref="Win32ErrorCode.ERROR_NO_MORE_FILES" /> error value is returned by
        /// the <see cref="Marshal.GetLastWin32Error" /> function if no modules exist or the snapshot does not contain module
        /// information.
        /// </returns>
        [DllImport(nameof(Kernel32), SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern unsafe bool Module32First(
            SafeObjectHandle hSnapshot,
            [Friendly(FriendlyFlags.Bidirectional)] MODULEENTRY32* lpme);

        /// <summary>Retrieves information about the next process recorded in a system snapshot.</summary>
        /// <param name="hSnapshot">A handle to the snapshot returned from a previous call to the
        /// <see cref="CreateToolhelp32Snapshot" /> function.</param>
        /// <param name="lpme">A <see cref="MODULEENTRY32"/> structure.</param>
        /// <returns>Returns <see langword="true" /> if the next entry of the module list has been copied to the buffer or
        /// <see langword="false" /> otherwise. The <see cref="Win32ErrorCode.ERROR_NO_MORE_FILES" /> error value is returned by
        /// the <see cref="Marshal.GetLastWin32Error" /> function if no modules exist or the snapshot does not contain module
        /// information.</returns>
        /// <remarks>
        /// To retrieve information about the first module recorded in a snapshot, use the
        /// <see cref="Module32First(SafeObjectHandle,MODULEENTRY32*)" />
        /// function.
        /// </remarks>
        [DllImport(nameof(Kernel32), SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern unsafe bool Module32Next(
            SafeObjectHandle hSnapshot,
            [Friendly(FriendlyFlags.Bidirectional)] MODULEENTRY32* lpme);

        /// <summary>Retrieves the full name of the executable image for the specified process.</summary>
        /// <param name="hProcess">
        /// A handle to the process. This handle must be created with the
        /// <see cref="ProcessAccess.PROCESS_QUERY_INFORMATION" /> or
        /// <see cref="ProcessAccess.PROCESS_QUERY_LIMITED_INFORMATION" /> access right.
        /// </param>
        /// <param name="dwFlags">One of the <see cref="QueryFullProcessImageNameFlags" /> values.</param>
        /// <param name="lpExeName">The path to the executable image. If the function succeeds, this string is null-terminated.</param>
        /// <param name="lpdwSize">
        /// On input, specifies the size of the lpExeName buffer, in characters. On success, receives the
        /// number of characters written to the buffer, not including the null-terminating character.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is nonzero.
        /// <para>If the function fails, the return value is zero.To get extended error information, call <see cref="GetLastError"/>.</para>
        /// </returns>
        /// <remarks>Minimum OS: Windows Vista / Windows Server 2008.</remarks>
        [DllImport(api_ms_win_core_psapi_l1_1_0, SetLastError = true, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern unsafe bool QueryFullProcessImageName(
            SafeObjectHandle hProcess,
            QueryFullProcessImageNameFlags dwFlags,
            [Friendly(FriendlyFlags.Out | FriendlyFlags.Array)] char* lpExeName,
            ref int lpdwSize);

        /// <summary>Retrieves the full name of the executable image for the specified process.</summary>
        /// <param name="hProcess">
        /// A handle to the process. This handle must be created with the
        /// <see cref="ProcessAccess.PROCESS_QUERY_INFORMATION" /> or
        /// <see cref="ProcessAccess.PROCESS_QUERY_LIMITED_INFORMATION" /> access right.
        /// </param>
        /// <param name="dwFlags">One of the <see cref="QueryFullProcessImageNameFlags" /> values.</param>
        /// <param name="lpExeName">The path to the executable image. If the function succeeds, this string is null-terminated.</param>
        /// <param name="lpdwSize">
        /// On input, specifies the size of the lpExeName buffer, in characters. On success, receives the
        /// number of characters written to the buffer, not including the null-terminating character.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is nonzero.
        /// <para>If the function fails, the return value is zero.To get extended error information, call <see cref="GetLastError"/>.</para>
        /// </returns>
        /// <remarks>Minimum OS: Windows Vista / Windows Server 2008.</remarks>
        [DllImport(api_ms_win_core_psapi_l1_1_0, SetLastError = true, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern unsafe bool QueryFullProcessImageName(
            SafeObjectHandle hProcess,
            QueryFullProcessImageNameFlags dwFlags,
            StringBuilder lpExeName,
            ref int lpdwSize);

        /// <summary>Opens an existing local process object.</summary>
        /// <param name="dwDesiredAccess">
        /// The access to the process object. This access right is checked against the security descriptor for the process. This
        /// parameter can be one or more of the <see cref="ProcessAccess" /> values.
        /// <para>
        /// If the caller has enabled the SeDebugPrivilege privilege, the requested access is granted regardless of the
        /// contents of the security descriptor.
        /// </para>
        /// </param>
        /// <param name="bInheritHandle">
        /// If this value is <see langword="true" />, processes created by this process will inherit
        /// the handle. Otherwise, the processes do not inherit this handle.
        /// </param>
        /// <param name="dwProcessId">
        /// The identifier of the local process to be opened.
        /// <para>
        /// If the specified process is the System Process(0x00000000), the function fails and the last error code is
        /// <see cref="Win32ErrorCode.ERROR_INVALID_PARAMETER" />.If the specified process is the Idle process or one of the CSRSS
        /// processes, this function fails and the last error code is <see cref="Win32ErrorCode.ERROR_ACCESS_DENIED" /> because
        /// their access restrictions prevent user-level code from opening them.
        /// </para>
        /// <para>
        /// If you are using <see cref="GetCurrentProcessId" /> as an argument to this function, consider using
        /// <see cref="GetCurrentProcess"/> instead of OpenProcess, for improved performance.
        /// </para>
        /// </param>
        /// <returns>If the function succeeds, the return value is an open handle to the specified process.</returns>
        [DllImport(api_ms_win_core_processthreads_l1_1_1, SetLastError = true)]
        public static extern SafeObjectHandle OpenProcess(
            ACCESS_MASK dwDesiredAccess,
            bool bInheritHandle,
            int dwProcessId);

        /// <summary>
        /// Retrieves the results of an overlapped operation on the specified file, named pipe, or communications device.
        /// To specify a timeout interval or wait on an alertable thread, use GetOverlappedResultEx.
        /// </summary>
        /// <param name="hFile">
        /// A handle to the file, named pipe, or communications device. This is the same handle that was
        /// specified when the overlapped operation was started by a call to the ReadFile, WriteFile, ConnectNamedPipe,
        /// TransactNamedPipe, DeviceIoControl, or WaitCommEvent function.
        /// </param>
        /// <param name="lpOverlapped">
        /// A pointer to an <see cref="OVERLAPPED" /> structure that was specified when the overlapped
        /// operation was started.
        /// </param>
        /// <param name="lpNumberOfBytesTransferred">
        /// A pointer to a variable that receives the number of bytes that were actually
        /// transferred by a read or write operation. For a TransactNamedPipe operation, this is the number of bytes that were read
        /// from the pipe. For a DeviceIoControl operation, this is the number of bytes of output data returned by the device
        /// driver. For a ConnectNamedPipe or WaitCommEvent operation, this value is undefined.
        /// </param>
        /// <param name="bWait">
        /// If this parameter is TRUE, and the Internal member of the lpOverlapped structure is STATUS_PENDING,
        /// the function does not return until the operation has been completed. If this parameter is FALSE and the operation is
        /// still pending, the function returns FALSE and the <see cref="GetLastError" /> function returns
        /// <see cref="Win32ErrorCode.ERROR_IO_INCOMPLETE" />.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is nonzero.
        /// <para>
        /// If the function fails, the return value is zero.To get extended error information, call
        /// <see cref="GetLastError" />.
        /// </para>
        /// </returns>
        /// <remarks>
        /// The results reported by the GetOverlappedResult function are those of the specified handle's last overlapped operation
        /// to which the specified <see cref="OVERLAPPED" /> structure was provided, and for which the operation's results were
        /// pending. A pending operation is indicated when the function that started the operation returns FALSE, and the
        /// GetLastError function returns <see cref="Win32ErrorCode.ERROR_IO_PENDING" />. When an I/O operation is pending, the
        /// function that started the operation resets the hEvent member of the <see cref="OVERLAPPED" /> structure to the
        /// nonsignaled state. Then when the pending operation has been completed, the system sets the event object to the signaled
        /// state.
        /// <para>
        /// If the bWait parameter is TRUE, GetOverlappedResult determines whether the pending operation has been completed
        /// by waiting for the event object to be in the signaled state.
        /// </para>
        /// <para>
        /// If the hEvent member of the <see cref="OVERLAPPED" /> structure is NULL, the system uses the state of the hFile
        /// handle to signal when the operation has been completed. Use of file, named pipe, or communications-device handles for
        /// this purpose is discouraged. It is safer to use an event object because of the confusion that can occur when multiple
        /// simultaneous overlapped operations are performed on the same file, named pipe, or communications device. In this
        /// situation, there is no way to know which operation caused the object's state to be signaled.
        /// </para>
        /// </remarks>
        [DllImport(api_ms_win_core_io_l1_1_1, SetLastError = true)]
        public static extern unsafe bool GetOverlappedResult(
            SafeObjectHandle hFile,
            OVERLAPPED* lpOverlapped,
            out int lpNumberOfBytesTransferred,
            bool bWait);

        /// <summary>
        /// Cancels all pending input and output (I/O) operations that are issued by the calling thread for the specified file. The
        /// function does not cancel I/O operations that other threads issue for a file handle.
        /// <para>To cancel I/O operations from another thread, use the CancelIoEx function.</para>
        /// </summary>
        /// <param name="hFile">
        /// A handle to the file.
        /// <para>The function cancels all pending I/O operations for this file handle.</para>
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is nonzero. The cancel operation for all pending I/O operations issued by
        /// the calling thread for the specified file handle was successfully requested. The thread can use the
        /// <see cref="GetOverlappedResult(SafeObjectHandle, OVERLAPPED*, out int, bool)" /> function to determine when the I/O operations themselves have been completed.
        /// <para>
        /// If the function fails, the return value is zero (0). To get extended error information, call the
        /// <see cref="GetLastError" /> function.
        /// </para>
        /// </returns>
        /// <remarks>
        /// If there are any pending I/O operations in progress for the specified file handle, and they are issued by the calling
        /// thread, the CancelIo function cancels them. CancelIo cancels only outstanding I/O on the handle, it does not change the
        /// state of the handle; this means that you cannot rely on the state of the handle because you cannot know whether the
        /// operation was completed successfully or canceled.
        /// <para>
        /// The I/O operations must be issued as overlapped I/O. If they are not, the I/O operations do not return to allow
        /// the thread to call the CancelIo function. Calling the CancelIo function with a file handle that is not opened with
        /// FILE_FLAG_OVERLAPPED does nothing.
        /// </para>
        /// <para>
        /// All I/O operations that are canceled complete with the error
        /// <see cref="Win32ErrorCode.ERROR_OPERATION_ABORTED" />, and all completion notifications for the I/O operations occur
        /// normally.
        /// </para>
        /// </remarks>
        [DllImport(api_ms_win_core_io_l1_1_1, SetLastError = true)]
        public static extern bool CancelIo(SafeObjectHandle hFile);

        /// <summary>
        /// Determines whether the specified process is running under WOW64 (x86 emulator that allows 32-bit Windows-based
        /// applications to run seamlessly on 64-bit Windows)
        /// </summary>
        /// <param name="hProcess">
        /// A handle to the process. The handle must have the <see cref="ProcessAccess.PROCESS_QUERY_INFORMATION" /> or
        /// <see cref="ProcessAccess.PROCESS_QUERY_LIMITED_INFORMATION" /> access right.
        /// <para>
        /// Windows Server 2003 and Windows XP:  The handle must have the
        /// <see cref="ProcessAccess.PROCESS_QUERY_INFORMATION" /> access right.
        /// </para>
        /// </param>
        /// <param name="Wow64Process">
        /// A pointer to a value that is set to <see langword="true" /> if the process is running under
        /// WOW64. If the process is running under 32-bit Windows, the value is set to <see langword="false" />. If the process is
        /// a 64-bit application running under 64-bit Windows, the value is also set to <see langword="false" />.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is a nonzero value.
        /// <para>
        /// If the function fails, the return value is zero. To get extended error information, call
        /// <see cref="GetLastError" />.
        /// </para>
        /// </returns>
        [DllImport(nameof(Kernel32), SetLastError = true)]
        public static extern bool IsWow64Process(SafeObjectHandle hProcess, out bool Wow64Process);

        /// <summary>Creates an anonymous pipe, and returns handles to the read and write ends of the pipe.</summary>
        /// <param name="hReadPipe">A pointer to a variable that receives the read handle for the pipe.</param>
        /// <param name="hWritePipe">A pointer to a variable that receives the write handle for the pipe.</param>
        /// <param name="lpPipeAttributes">
        ///     A pointer to a <see cref="SECURITY_ATTRIBUTES" /> structure that determines whether the returned handle can be
        ///     inherited by child processes. If <paramref name="lpPipeAttributes"/>  is NULL, the handle cannot be inherited.
        ///     <para>
        ///         The <see cref="SECURITY_ATTRIBUTES.lpSecurityDescriptor" /> member of the structure specifies a security
        ///         descriptor for the new pipe. If <paramref name="lpPipeAttributes"/>  is NULL, the pipe gets a default security descriptor. The ACLs
        ///         in the default security descriptor for a pipe come from the primary or impersonation token of the creator.
        ///     </para>
        /// </param>
        /// <param name="nSize">
        ///     The size of the buffer for the pipe, in bytes. The size is only a suggestion; the system uses the
        ///     value to calculate an appropriate buffering mechanism. If this parameter is zero, the system uses the default
        ///     buffer size.
        /// </param>
        /// <returns>
        ///     If the function succeeds, the return value is a nonzero value.
        ///     <para>
        ///         If the function fails, the return value is zero. To get extended error information, call
        ///         <see cref="GetLastError" />.
        ///     </para>
        /// </returns>
        [DllImport(api_ms_win_core_namedpipe_l1_2_0, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern unsafe bool CreatePipe(
            out SafeObjectHandle hReadPipe,
            out SafeObjectHandle hWritePipe,
            [Friendly(FriendlyFlags.In | FriendlyFlags.Optional)] SECURITY_ATTRIBUTES* lpPipeAttributes,
            int nSize);

        /// <summary>Removes as many pages as possible from the working set of the specified process.</summary>
        /// <param name="hProcess">
        ///     A handle to the process. The handle must have the PROCESS_QUERY_INFORMATION or
        ///     PROCESS_QUERY_LIMITED_INFORMATION access right and the PROCESS_SET_QUOTA access right.
        /// </param>
        /// <returns>
        ///     If the function succeeds, the return value is nonzero.
        ///     <para>
        ///         If the function fails, the return value is zero. To get extended error information, call
        ///         <see cref="GetLastError" />.
        ///     </para>
        /// </returns>
        /// <remarks>
        ///     This function is exported by kernel32.dll only since Windows 7, on previous version of windows it's
        ///     exported by Psapi.dll as "EmptyWorkingSet".
        /// </remarks>
        [DllImport(api_ms_win_core_psapi_l1_1_0, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool K32EmptyWorkingSet(SafeObjectHandle hProcess);

        /// <summary>Retrieves the window handle used by the console associated with the calling process.</summary>
        /// <returns>
        ///     The return value is a handle to the window used by the console associated with the calling process or
        ///     <see cref="IntPtr.Zero" /> if there is no such associated console.
        /// </returns>
        [DllImport(nameof(Kernel32))]
        public static extern IntPtr GetConsoleWindow();

        /// <summary>
        ///     Loads the specified module into the address space of the calling process. The specified module may cause other
        ///     modules to be loaded.
        ///     <para>For additional load options, use the LoadLibraryEx function.</para>
        /// </summary>
        /// <param name="lpFileName">
        ///     The name of the module. This can be either a library module (a .dll file) or an executable module (an .exe file).
        ///     The name specified is the file name of the module and is not related to the name stored in the library module
        ///     itself, as specified by the LIBRARY keyword in the module-definition (.def) file.
        ///     <para>If the string specifies a full path, the function searches only that path for the module.</para>
        ///     <para>
        ///         If the string specifies a relative path or a module name without a path, the function uses a standard search
        ///         strategy to find the module.
        ///     </para>
        ///     <para>
        ///         If the function cannot find the module, the function fails. When specifying a path, be sure to use
        ///         backslashes (\), not forward slashes (/).
        ///     </para>
        ///     <para>
        ///         If the string specifies a module name without a path and the file name extension is omitted, the function
        ///         appends the default library extension .dll to the module name. To prevent the function from appending .dll to
        ///         the module name, include a trailing point character (.) in the module name string.
        ///     </para>
        /// </param>
        /// <returns>
        ///     If the function succeeds, the return value is a handle to the loaded module.
        ///     <para>
        ///         If the function fails, the return value is an invalid handle. To get extended error information, call
        ///         <see cref="GetLastError" />.
        ///     </para>
        /// </returns>
        [DllImport(nameof(Kernel32), SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern SafeLibraryHandle LoadLibrary(string lpFileName);

        /// <summary>
        ///     Loads the specified module into the address space of the calling process. The specified module may cause other
        ///     modules to be loaded.
        /// </summary>
        /// <param name="lpFileName">
        ///     <para>
        ///         A string that specifies the file name of the module to load. This name is not related to the name stored in a
        ///         library module itself, as specified by the LIBRARY keyword in the module-definition (.def) file.
        ///     </para>
        ///     <para>
        ///         The module can be a library module (a .dll file) or an executable module (an .exe file). If the specified
        ///         module is an executable module, static imports are not loaded; instead, the module is loaded as if
        ///         <see cref="LoadLibraryExFlags.DONT_RESOLVE_DLL_REFERENCES" /> was specified. See the
        ///         <paramref name="dwFlags" /> parameter for more information.
        ///     </para>
        ///     <para>
        ///         If the string specifies a module name without a path and the file name extension is omitted, the function
        ///         appends the default library extension .dll to the module name. To prevent the function from appending .dll to
        ///         the module name, include a trailing point character (.) in the module name string.
        ///     </para>
        ///     <para>
        ///         If the string specifies a fully qualified path, the function searches only that path for the module. When
        ///         specifying a path, be sure to use backslashes (\), not forward slashes (/). For more information about paths,
        ///         see Naming Files, Paths, and Namespaces.
        ///     </para>
        ///     <para>
        ///         If the string specifies a module name without a path and more than one loaded module has the same base name
        ///         and extension, the function returns a handle to the module that was loaded first.
        ///     </para>
        ///     <para>
        ///         If the string specifies a module name without a path and a module of the same name is not already loaded, or
        ///         if the string specifies a module name with a relative path, the function searches for the specified module. The
        ///         function also searches for modules if loading the specified module causes the system to load other associated
        ///         modules (that is, if the module has dependencies). The directories that are searched and the order in which
        ///         they are searched depend on the specified path and the dwFlags parameter.
        ///     </para>
        ///     <para>If the function cannot find the module or one of its dependencies, the function fails.</para>
        /// </param>
        /// <param name="hFile">This parameter is reserved for future use. It must be <see langword="null" />.</param>
        /// <param name="dwFlags">
        ///     The action to be taken when loading the module. If <see cref="LoadLibraryExFlags.None" /> is
        ///     specified, the behavior of this function is identical to that of the LoadLibrary function.
        /// </param>
        /// <returns>
        ///     If the function succeeds, the return value is a handle to the loaded module.
        ///     <para>
        ///         If the function fails, the return value is an invalid handle. To get extended error information, call
        ///         <see cref="GetLastError" />.
        ///     </para>
        /// </returns>
        [DllImport(nameof(Kernel32), SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern SafeLibraryHandle LoadLibraryEx(string lpFileName, IntPtr hFile, LoadLibraryExFlags dwFlags);

        [DllImport(nameof(Kernel32), CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern IntPtr AddDllDirectory(string NewDirectory);

        [DllImport(nameof(Kernel32), CharSet = CharSet.Unicode, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static unsafe extern bool GetDllDirectory(
            int nBufferLength,
            [Friendly(FriendlyFlags.Array | FriendlyFlags.Out)] char* lpBuffer);

        [DllImport(nameof(Kernel32), CharSet = CharSet.Unicode, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetDllDirectory(string lpPathName);

        /// <summary>
        /// Retrieves a module handle for the specified module. The module must have been loaded by the calling process.
        /// </summary>
        /// <param name="lpModuleName">
        /// The name of the loaded module (either a .dll or .exe file).
        /// If the file name extension is omitted, the default library extension .dll is appended.
        /// The file name string can include a trailing point character (.) to indicate that the module name has no extension.
        /// The string does not have to specify a path. When specifying a path, be sure to use backslashes (\), not forward slashes (/).
        /// The name is compared (case independently) to the names of modules currently mapped into the address space of the calling process.
        /// If this parameter is NULL, it returns a handle to the file used to create the calling process (.exe file).
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is a handle to the specified module.
        /// If the function fails, the return value is NULL.To get extended error information, call GetLastError.
        /// </returns>
        /// <remarks>
        /// This function does not retrieve handles for modules that were loaded using the <see cref="LoadLibraryExFlags.LOAD_LIBRARY_AS_DATAFILE"/> flag.
        /// This function returns a handle to a mapped module without incrementing its reference count.
        /// However, if this handle is passed to the <see cref="FreeLibrary"/> function, the reference count of the mapped module will be decremented.
        /// Therefore, do not pass a handle returned by this function to the <see cref="FreeLibrary"/> function. Doing so can cause a DLL module to be unmapped prematurely.
        /// </remarks>
        [DllImport(nameof(Kernel32), SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern SafeLibraryHandle GetModuleHandle(string lpModuleName);

        /// <summary>
        /// Retrieves a module handle for the specified module and increments the module's reference count unless <see cref="GetModuleHandleExFlags.GET_MODULE_HANDLE_EX_FLAG_UNCHANGED_REFCOUNT"/> is specified.
        /// The module must have been loaded by the calling process.
        /// </summary>
        /// <param name="dwFlags">
        /// This parameter can be zero or one or more of the following values.
        /// If the module's reference count is incremented, the caller must use the <see cref="FreeLibrary"/> function to decrement the reference count when the module handle is no longer needed.</param>
        /// <param name="lpModuleName">The name of the loaded module (either a .dll or .exe file), or an address in the module (if <paramref name="dwFlags"/> is <see cref="GetModuleHandleExFlags.GET_MODULE_HANDLE_EX_FLAG_FROM_ADDRESS"/>).</param>
        /// <param name="phModule">
        /// A handle to the specified module. If the function fails, this parameter is NULL.
        /// </param>
        /// <returns>
        /// If the function succeeds, returns true. If the function fails, the returns false.
        /// To get extended error information, see <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// The handle returned is not global or inheritable. It cannot be duplicated or used by another process.
        /// This function does not retrieve handles for modules that were loaded using the <see cref="LoadLibraryExFlags.LOAD_LIBRARY_AS_DATAFILE"/> flag.
        /// </remarks>
        [DllImport(nameof(Kernel32), SetLastError = true, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetModuleHandleEx(GetModuleHandleExFlags dwFlags, string lpModuleName, out SafeLibraryHandle phModule);

        /// <summary>
        ///     Creates an instance of a named pipe and returns a handle for subsequent pipe operations. A named pipe server
        ///     process uses this function either to create the first instance of a specific named pipe and establish its basic
        ///     attributes or to create a new instance of an existing named pipe.
        /// </summary>
        /// <param name="lpName">
        ///     The unique pipe name. This string must have the following form:
        ///     <para>
        ///         <code>\\.\pipe\pipename</code>
        ///     </para>
        ///     <para>
        ///         The pipename part of the name can include any character other than a backslash, including numbers and special
        ///         characters. The entire pipe name string can be up to 256 characters long. Pipe names are not case sensitive.
        ///     </para>
        /// </param>
        /// <param name="dwOpenMode">
        ///     The open mode. The function fails if dwOpenMode specifies anything other than 0 or the flags
        ///     from <see cref="PipeAccessMode" />.
        ///     <para>The same mode must be specified for each instance of the pipe.</para>
        /// </param>
        /// <param name="dwPipeMode">
        ///     The pipe mode. The function fails if dwPipeMode specifies anything other than 0 or the flags from
        ///     <see cref="PipeMode" />.
        ///     <para>
        ///         One of the following type modes can be specified. The same type mode must be specified for each instance of
        ///         the pipe.
        ///     </para>
        /// </param>
        /// <param name="nMaxInstances">
        ///     The maximum number of instances that can be created for this pipe. The first instance of
        ///     the pipe can specify this value; the same number must be specified for other instances of the pipe. Acceptable
        ///     values are in the range 1 through <see cref="PIPE_UNLIMITED_INSTANCES" /> (255). If this parameter is
        ///     <see cref="PIPE_UNLIMITED_INSTANCES" />, the number of pipe instances that can be created is limited only by the
        ///     availability of system resources. If nMaxInstances is greater than <see cref="PIPE_UNLIMITED_INSTANCES" />, the
        ///     return value is an invalid handle and <see cref="GetLastError" /> returns
        ///     <see cref="Win32ErrorCode.ERROR_INVALID_PARAMETER" />.
        /// </param>
        /// <param name="nOutBufferSize">The number of bytes to reserve for the output buffer.</param>
        /// <param name="nInBufferSize">The number of bytes to reserve for the input buffer.</param>
        /// <param name="nDefaultTimeOut">
        ///     The default time-out value, in milliseconds, if the <see cref="WaitNamedPipe"/> function specifies
        ///     NMPWAIT_USE_DEFAULT_WAIT. Each instance of a named pipe must specify the same value.
        /// </param>
        /// <param name="lpSecurityAttributes">
        ///     A pointer to a <see cref="SECURITY_ATTRIBUTES" /> structure that specifies a
        ///     security descriptor for the new named pipe and determines whether child processes can inherit the returned handle.
        ///     If lpSecurityAttributes is NULL, the named pipe gets a default security descriptor and the handle cannot be
        ///     inherited. The ACLs in the default security descriptor for a named pipe grant full control to the LocalSystem
        ///     account, administrators, and the creator owner. They also grant read access to members of the Everyone group and
        ///     the anonymous account.
        /// </param>
        /// <returns>
        ///     If the function succeeds, the return value is a handle to the server end of a named pipe instance. If the
        ///     function fails, the return value is an invalid handle. To get extended error information, call
        ///     <see cref="GetLastError" />.
        /// </returns>
        [DllImport(api_ms_win_core_namedpipe_l1_2_0, SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern unsafe SafeObjectHandle CreateNamedPipe(
            string lpName,
            PipeAccessMode dwOpenMode,
            PipeMode dwPipeMode,
            int nMaxInstances,
            int nOutBufferSize,
            int nInBufferSize,
            int nDefaultTimeOut,
            [Friendly(FriendlyFlags.In | FriendlyFlags.Optional)] SECURITY_ATTRIBUTES* lpSecurityAttributes);

        /// <summary>
        ///     Waits until either a time-out interval elapses or an instance of the specified named pipe is available for
        ///     connection (that is, the pipe's server process has a pending <see cref="ConnectNamedPipe(SafeObjectHandle, OVERLAPPED*)" /> operation on the
        ///     pipe).
        /// </summary>
        /// <param name="lpNamedPipeName">
        ///     The name of the named pipe. The string must include the name of the computer on which the server process is
        ///     executing. A period may be used for the servername if the pipe is local. The following pipe name format is used:
        ///     <para>
        ///         <code>\\servername\pipe\pipename</code>
        ///     </para>
        /// </param>
        /// <param name="nTimeOut">
        ///     The number of milliseconds that the function will wait for an instance of the named pipe to be
        ///     available. You can also use either <see cref="NMPWAIT_USE_DEFAULT_WAIT" /> or <see cref="NMPWAIT_WAIT_FOREVER" />
        ///     instead of specifying a number of milliseconds.
        /// </param>
        /// <returns>
        ///     If an instance of the pipe is available before the time-out interval elapses, the return value is nonzero.
        ///     <para>
        ///         If an instance of the pipe is not available before the time-out interval elapses, the return value is zero.
        ///         To get extended error information, call <see cref="GetLastError" />.
        ///     </para>
        ///     <para>
        ///         If no instances of the specified named pipe exist, the WaitNamedPipe function returns immediately, regardless
        ///         of the time-out value.
        ///     </para>
        ///     <para>
        ///         If the time-out interval expires, the WaitNamedPipe function will fail with the error
        ///         <see cref="Win32ErrorCode.ERROR_SEM_TIMEOUT" />.
        ///     </para>
        ///     <para>
        ///         If the function succeeds, the process should use the <see cref="CreateFile(string, ACCESS_MASK, FileShare, SECURITY_ATTRIBUTES*, CreationDisposition, CreateFileFlags, SafeObjectHandle)" /> function to open a handle to
        ///         the named pipe. A return value of TRUE indicates that there is at least one instance of the pipe available. A
        ///         subsequent <see cref="CreateFile(string, ACCESS_MASK, FileShare, SECURITY_ATTRIBUTES*, CreationDisposition, CreateFileFlags, SafeObjectHandle)" /> call to the pipe can fail, because the instance was closed by the server
        ///         or opened by another client.
        ///     </para>
        /// </returns>
        [DllImport(api_ms_win_core_namedpipe_l1_2_0, SetLastError = true, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool WaitNamedPipe(
            string lpNamedPipeName,
            int nTimeOut);

        /// <summary>
        ///     Enables a named pipe server process to wait for a client process to connect to an instance of a named pipe. A
        ///     client process connects by calling either the CreateFile or CallNamedPipe function.
        /// </summary>
        /// <param name="hNamedPipe">
        ///     A handle to the server end of a named pipe instance. This handle is returned by the
        ///     CreateNamedPipe function.
        /// </param>
        /// <param name="lpOverlapped">
        ///     A pointer to an OVERLAPPED structure.
        ///     <para>
        ///         If hNamedPipe was opened with FILE_FLAG_OVERLAPPED, the lpOverlapped parameter must not be NULL. It must
        ///         point to a valid OVERLAPPED structure. If hNamedPipe was opened with FILE_FLAG_OVERLAPPED and lpOverlapped is
        ///         NULL, the function can incorrectly report that the connect operation is complete.
        ///     </para>
        ///     <para>
        ///         If hNamedPipe was created with FILE_FLAG_OVERLAPPED and lpOverlapped is not NULL, the OVERLAPPED structure
        ///         should contain a handle to a manual-reset event object (which the server can create by using the CreateEvent
        ///         function).
        ///     </para>
        ///     <para>
        ///         If hNamedPipe was not opened with FILE_FLAG_OVERLAPPED, the function does not return until a client is
        ///         connected or an error occurs. Successful synchronous operations result in the function returning a nonzero
        ///         value if a client connects after the function is called.
        ///     </para>
        /// </param>
        /// <returns>
        ///     If the operation is synchronous, ConnectNamedPipe does not return until the operation has completed. If the
        ///     function succeeds, the return value is nonzero. If the function fails, the return value is zero. To get extended
        ///     error information, call GetLastError.
        ///     <para>
        ///         If the operation is asynchronous, ConnectNamedPipe returns immediately. If the operation is still pending,
        ///         the return value is zero and GetLastError returns ERROR_IO_PENDING. (You can use the HasOverlappedIoCompleted
        ///         macro to determine when the operation has finished.) If the function fails, the return value is zero and
        ///         GetLastError returns a value other than ERROR_IO_PENDING or ERROR_PIPE_CONNECTED.
        ///     </para>
        ///     <para>
        ///         If a client connects before the function is called, the function returns zero and GetLastError returns
        ///         ERROR_PIPE_CONNECTED. This can happen if a client connects in the interval between the call to CreateNamedPipe
        ///         and the call to ConnectNamedPipe. In this situation, there is a good connection between client and server, even
        ///         though the function returns zero.
        ///     </para>
        /// </returns>
        [DllImport(api_ms_win_core_namedpipe_l1_2_0, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern unsafe bool ConnectNamedPipe(
            SafeObjectHandle hNamedPipe,
            OVERLAPPED* lpOverlapped);

        /// <summary>
        ///     Connects to a message-type pipe (and waits if an instance of the pipe is not available), writes to and reads
        ///     from the pipe, and then closes the pipe.
        /// </summary>
        /// <param name="lpNamedPipeName">The pipe name.</param>
        /// <param name="lpInBuffer">The data to be written to the pipe.</param>
        /// <param name="nInBufferSize">The size of the write buffer, in bytes.</param>
        /// <param name="lpOutBuffer">A pointer to the buffer that receives the data read from the pipe.</param>
        /// <param name="nOutBufferSize">The size of the read buffer, in bytes.</param>
        /// <param name="lpBytesRead">A pointer to a variable that receives the number of bytes read from the pipe.</param>
        /// <param name="nTimeOut">
        ///     The number of milliseconds to wait for the named pipe to be available. In addition to numeric
        ///     values, <see cref="NMPWAIT_NOWAIT" />, <see cref="NMPWAIT_WAIT_FOREVER" /> and
        ///     <see cref="NMPWAIT_USE_DEFAULT_WAIT" /> can be specified.
        /// </param>
        /// <returns>
        ///     If the function succeeds, the return value is nonzero.
        ///     <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
        ///     <para>
        ///         If the message written to the pipe by the server process is longer than nOutBufferSize, CallNamedPipe returns
        ///         FALSE, and GetLastError returns ERROR_MORE_DATA. The remainder of the message is discarded, because
        ///         CallNamedPipe closes the handle to the pipe before returning.
        ///     </para>
        /// </returns>
        [DllImport(nameof(Kernel32), SetLastError = true, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern unsafe bool CallNamedPipe(
            string lpNamedPipeName,
            void* lpInBuffer,
            int nInBufferSize,
            void* lpOutBuffer,
            int nOutBufferSize,
            out int lpBytesRead,
            int nTimeOut);

        /// <summary>Retrieves the client computer name for the specified named pipe.</summary>
        /// <param name="Pipe">
        ///     A handle to an instance of a named pipe. This handle must be created by the CreateNamedPipe
        ///     function.
        /// </param>
        /// <param name="ClientComputerName">The computer name.</param>
        /// <param name="ClientComputerNameLength">The size of the ClientComputerName buffer, in bytes.</param>
        /// <returns>
        ///     If the function succeeds, the return value is nonzero.
        ///     <para>
        ///         If the function fails, the return value is zero. To get extended error information, call
        ///         <see cref="GetLastError" />.
        ///     </para>
        /// </returns>
        [DllImport(api_ms_win_core_namedpipe_l1_2_0, SetLastError = true, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern unsafe bool GetNamedPipeClientComputerName(
            SafeObjectHandle Pipe,
            StringBuilder ClientComputerName,
            int ClientComputerNameLength);

        /// <summary>Disconnects the server end of a named pipe instance from a client process.</summary>
        /// <param name="hNamedPipe">
        ///     A handle to an instance of a named pipe. This handle must be created by the CreateNamedPipe
        ///     function.
        /// </param>
        /// <returns>
        ///     If the function succeeds, the return value is nonzero.
        ///     <para>
        ///         If the function fails, the return value is zero. To get extended error information, call
        ///         <see cref="GetLastError" />.
        ///     </para>
        /// </returns>
        [DllImport(api_ms_win_core_namedpipe_l1_2_0, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool DisconnectNamedPipe(
            SafeObjectHandle hNamedPipe);

        /// <summary>Retrieves the client computer name for the specified named pipe.</summary>
        /// <param name="Pipe">
        ///     A handle to an instance of a named pipe. This handle must be created by the CreateNamedPipe
        ///     function.
        /// </param>
        /// <param name="ClientComputerName">The computer name.</param>
        /// <param name="ClientComputerNameLength">The size of the ClientComputerName buffer, in bytes.</param>
        /// <returns>
        ///     If the function succeeds, the return value is nonzero.
        ///     <para>
        ///         If the function fails, the return value is zero. To get extended error information, call
        ///         <see cref="GetLastError" />.
        ///     </para>
        /// </returns>
        [DllImport(api_ms_win_core_namedpipe_l1_2_0, SetLastError = true, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern unsafe bool GetNamedPipeClientComputerName(
            SafeObjectHandle Pipe,
            [Friendly(FriendlyFlags.Out | FriendlyFlags.Array)] char* ClientComputerName,
            int ClientComputerNameLength);

        /// <summary>Retrieves the client process identifier for the specified named pipe.</summary>
        /// <param name="Pipe">
        ///     A handle to an instance of a named pipe. This handle must be created by the CreateNamedPipe
        ///     function.
        /// </param>
        /// <param name="ClientProcessId">The process identifier.</param>
        /// <returns>
        ///     If the function succeeds, the return value is nonzero.
        ///     <para>
        ///         If the function fails, the return value is zero. To get extended error information, call
        ///         <see cref="GetLastError" />.
        ///     </para>
        /// </returns>
        [DllImport(nameof(Kernel32), SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetNamedPipeClientProcessId(
            SafeObjectHandle Pipe,
            out int ClientProcessId);

        /// <summary>
        /// Retrieves the client session identifier for the specified named pipe.
        /// </summary>
        /// <param name="Pipe">
        ///     A handle to an instance of a named pipe. This handle must be created by the CreateNamedPipe
        ///     function.
        /// </param>
        /// <param name="ClientSessionId">The session identifier.</param>
        /// <returns>
        ///     If the function succeeds, the return value is nonzero.
        ///     <para>
        ///         If the function fails, the return value is zero. To get extended error information, call
        ///         <see cref="GetLastError" />.
        ///     </para>
        /// </returns>
        [DllImport(nameof(Kernel32), SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetNamedPipeClientSessionId(
            SafeObjectHandle Pipe,
            out int ClientSessionId);

        /// <summary>
        ///     Retrieves information about a specified named pipe. The information returned can vary during the lifetime of
        ///     an instance of the named pipe.
        /// </summary>
        /// <param name="hNamedPipe">
        ///     A handle to the named pipe for which information is wanted. The handle must have GENERIC_READ
        ///     access for a read-only or read/write pipe, or it must have GENERIC_WRITE and FILE_READ_ATTRIBUTES access for a
        ///     write-only pipe.
        ///     <para>This parameter can also be a handle to an anonymous pipe, as returned by the CreatePipe function.</para>
        /// </param>
        /// <param name="lpState">
        ///     A pointer to a variable that indicates the current state of the handle. Either or both of
        ///     <see cref="PipeMode.PIPE_NOWAIT" /> and <see cref="PipeMode.PIPE_READMODE_MESSAGE" /> can be specified.
        /// </param>
        /// <param name="lpCurInstances">
        ///     A pointer to a variable that receives the number of current pipe instances. This parameter
        ///     can be NULL if this information is not required.
        /// </param>
        /// <param name="lpMaxCollectionCount">
        ///     A pointer to a variable that receives the maximum number of bytes to be collected on
        ///     the client's computer before transmission to the server. This parameter must be NULL if the specified pipe handle
        ///     is to the server end of a named pipe or if client and server processes are on the same computer. This parameter can
        ///     be NULL if this information is not required.
        /// </param>
        /// <param name="lpCollectDataTimeout">
        ///     A pointer to a variable that receives the maximum time, in milliseconds, that can
        ///     pass before a remote named pipe transfers information over the network. This parameter must be NULL if the
        ///     specified pipe handle is to the server end of a named pipe or if client and server processes are on the same
        ///     computer. This parameter can be NULL if this information is not required.
        /// </param>
        /// <param name="lpUserName">
        ///     A pointer to a buffer that receives the user name string associated with the client application. The server can
        ///     only retrieve this information if the client opened the pipe with SECURITY_IMPERSONATION access.
        ///     <para>
        ///         This parameter must be NULL if the specified pipe handle is to the client end of a named pipe. This parameter
        ///         can be NULL if this information is not required.
        ///     </para>
        /// </param>
        /// <param name="nMaxUserNameSize">
        ///     The size of the buffer specified by the lpUserName parameter, in chars. This parameter
        ///     is ignored if lpUserName is NULL.
        /// </param>
        /// <returns>
        ///     If the function succeeds, the return value is nonzero.
        ///     <para>
        ///         If the function fails, the return value is zero. To get extended error information, call
        ///         <see cref="GetLastError" />.
        ///     </para>
        /// </returns>
        [DllImport(nameof(Kernel32), SetLastError = true, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern unsafe bool GetNamedPipeHandleState(
            SafeObjectHandle hNamedPipe,
            out PipeMode lpState,
            [Friendly(FriendlyFlags.Bidirectional | FriendlyFlags.Optional)] int* lpCurInstances,
            [Friendly(FriendlyFlags.Bidirectional | FriendlyFlags.Optional)] int* lpMaxCollectionCount,
            [Friendly(FriendlyFlags.Bidirectional | FriendlyFlags.Optional)] int* lpCollectDataTimeout,
            StringBuilder lpUserName,
            int nMaxUserNameSize);

        /// <summary>
        ///     Retrieves information about a specified named pipe. The information returned can vary during the lifetime of
        ///     an instance of the named pipe.
        /// </summary>
        /// <param name="hNamedPipe">
        ///     A handle to the named pipe for which information is wanted. The handle must have GENERIC_READ
        ///     access for a read-only or read/write pipe, or it must have GENERIC_WRITE and FILE_READ_ATTRIBUTES access for a
        ///     write-only pipe.
        ///     <para>This parameter can also be a handle to an anonymous pipe, as returned by the CreatePipe function.</para>
        /// </param>
        /// <param name="lpState">
        ///     A pointer to a variable that indicates the current state of the handle. Either or both of
        ///     <see cref="PipeMode.PIPE_NOWAIT" /> and <see cref="PipeMode.PIPE_READMODE_MESSAGE" /> can be specified.
        /// </param>
        /// <param name="lpCurInstances">
        ///     A pointer to a variable that receives the number of current pipe instances. This parameter
        ///     can be NULL if this information is not required.
        /// </param>
        /// <param name="lpMaxCollectionCount">
        ///     A pointer to a variable that receives the maximum number of bytes to be collected on
        ///     the client's computer before transmission to the server. This parameter must be NULL if the specified pipe handle
        ///     is to the server end of a named pipe or if client and server processes are on the same computer. This parameter can
        ///     be NULL if this information is not required.
        /// </param>
        /// <param name="lpCollectDataTimeout">
        ///     A pointer to a variable that receives the maximum time, in milliseconds, that can
        ///     pass before a remote named pipe transfers information over the network. This parameter must be NULL if the
        ///     specified pipe handle is to the server end of a named pipe or if client and server processes are on the same
        ///     computer. This parameter can be NULL if this information is not required.
        /// </param>
        /// <param name="lpUserName">
        ///     A pointer to a buffer that receives the user name string associated with the client application. The server can
        ///     only retrieve this information if the client opened the pipe with SECURITY_IMPERSONATION access.
        ///     <para>
        ///         This parameter must be NULL if the specified pipe handle is to the client end of a named pipe. This parameter
        ///         can be NULL if this information is not required.
        ///     </para>
        /// </param>
        /// <param name="nMaxUserNameSize">
        ///     The size of the buffer specified by the lpUserName parameter, in chars. This parameter
        ///     is ignored if lpUserName is NULL.
        /// </param>
        /// <returns>
        ///     If the function succeeds, the return value is nonzero.
        ///     <para>
        ///         If the function fails, the return value is zero. To get extended error information, call
        ///         <see cref="GetLastError" />.
        ///     </para>
        /// </returns>
        [DllImport(nameof(Kernel32), SetLastError = true, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern unsafe bool GetNamedPipeHandleState(
            SafeObjectHandle hNamedPipe,
            out PipeMode lpState,
            [Friendly(FriendlyFlags.Bidirectional | FriendlyFlags.Optional)] int* lpCurInstances,
            [Friendly(FriendlyFlags.Bidirectional | FriendlyFlags.Optional)] int* lpMaxCollectionCount,
            [Friendly(FriendlyFlags.Bidirectional | FriendlyFlags.Optional)] int* lpCollectDataTimeout,
            [Friendly(FriendlyFlags.Bidirectional | FriendlyFlags.Array)] char* lpUserName,
            int nMaxUserNameSize);

        /// <summary>Retrieves information about the specified named pipe.</summary>
        /// <param name="hNamedPipe">
        ///     A handle to the named pipe instance. The handle must have GENERIC_READ access to the named
        ///     pipe for a read-only or read/write pipe, or it must have GENERIC_WRITE and FILE_READ_ATTRIBUTES access for a
        ///     write-only pipe.
        ///     <para>
        ///         This parameter can also be a handle to an anonymous pipe, as returned by the <see cref="CreatePipe(out SafeObjectHandle, out SafeObjectHandle, SECURITY_ATTRIBUTES*, int)" />
        ///         function.
        ///     </para>
        /// </param>
        /// <param name="lpFlags">Receives the type of the named pipe.</param>
        /// <param name="lpOutBufferSize">
        ///     Receives the size of the buffer for outgoing data, in bytes. If the buffer size is zero,
        ///     the buffer is allocated as needed.
        /// </param>
        /// <param name="lpInBufferSize">
        ///     Receives the size of the buffer for incoming data, in bytes. If the buffer size is zero,
        ///     the buffer is allocated as needed.
        /// </param>
        /// <param name="lpMaxInstances">
        ///     Receives the maximum number of pipe instances that can be created. If the variable is set
        ///     to <see cref="PIPE_UNLIMITED_INSTANCES" /> (255), the number of pipe instances that can be created is limited only
        ///     by the availability of system resources.
        /// </param>
        /// <returns>
        ///     If the function succeeds, the return value is nonzero.
        ///     <para>
        ///         If the function fails, the return value is zero. To get extended error information, call
        ///         <see cref="GetLastError" />.
        ///     </para>
        /// </returns>
        [DllImport(nameof(Kernel32), SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetNamedPipeInfo(
            SafeObjectHandle hNamedPipe,
            out NamedPipeInfoFlags lpFlags,
            out int lpOutBufferSize,
            out int lpInBufferSize,
            out int lpMaxInstances);

        /// <summary>Retrieves the server process identifier for the specified named pipe.</summary>
        /// <param name="Pipe">
        ///     A handle to an instance of a named pipe. This handle must be created by the
        ///     <see cref="CreateNamedPipe(string, PipeAccessMode, PipeMode, int, int, int, int, SECURITY_ATTRIBUTES*)" /> function.
        /// </param>
        /// <param name="ServerProcessId">The process identifier.</param>
        /// <returns>
        ///     If the function succeeds, the return value is nonzero.
        ///     <para>
        ///         If the function fails, the return value is zero. To get extended error information, call
        ///         <see cref="GetLastError" />.
        ///     </para>
        /// </returns>
        [DllImport(nameof(Kernel32), SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetNamedPipeServerProcessId(
            SafeObjectHandle Pipe,
            out int ServerProcessId);

        /// <summary>
        /// Retrieves the server session identifier for the specified named pipe.
        /// </summary>
        /// <param name="Pipe">
        ///     A handle to an instance of a named pipe. This handle must be created by the
        ///     <see cref="CreateNamedPipe(string, PipeAccessMode, PipeMode, int, int, int, int, SECURITY_ATTRIBUTES*)" /> function.
        /// </param>
        /// <param name="ServerSessionId">The session identifier.</param>
        /// <returns>
        ///     If the function succeeds, the return value is nonzero.
        ///     <para>
        ///         If the function fails, the return value is zero. To get extended error information, call
        ///         <see cref="GetLastError" />.
        ///     </para>
        /// </returns>
        [DllImport(nameof(Kernel32), SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetNamedPipeServerSessionId(
            SafeObjectHandle Pipe,
            out int ServerSessionId);

        /// <summary>
        ///     Copies data from a named or anonymous pipe into a buffer without removing it from the pipe. It also returns
        ///     information about data in the pipe.
        /// </summary>
        /// <param name="hNamedPipe">
        ///     A handle to the pipe. This parameter can be a handle to a named pipe instance, as returned by
        ///     the <see cref="CreateNamedPipe(string, PipeAccessMode, PipeMode, int, int, int, int, SECURITY_ATTRIBUTES*)" /> or <see cref="CreateFile(string, ACCESS_MASK, FileShare, SECURITY_ATTRIBUTES*, CreationDisposition, CreateFileFlags, SafeObjectHandle)" /> function, or it can be a handle to the read end of
        ///     an anonymous pipe, as returned by the <see cref="CreatePipe(out SafeObjectHandle, out SafeObjectHandle, SECURITY_ATTRIBUTES*, int)" /> function. The handle must have GENERIC_READ access
        ///     to the pipe.
        /// </param>
        /// <param name="lpBuffer">
        ///     A pointer to a buffer that receives data read from the pipe. This parameter can be NULL if no
        ///     data is to be read.
        /// </param>
        /// <param name="nBufferSize">
        ///     The size of the buffer specified by the lpBuffer parameter, in bytes. This parameter is
        ///     ignored if lpBuffer is NULL.
        /// </param>
        /// <param name="lpBytesRead">A pointer to a variable that receives the number of bytes read from the pipe.</param>
        /// <param name="lpTotalBytesAvail">
        ///     A pointer to a variable that receives the total number of bytes available to be read
        ///     from the pipe.
        /// </param>
        /// <param name="lpBytesLeftThisMessage">
        ///     A pointer to a variable that receives the number of bytes remaining in this
        ///     message. This parameter will be zero for byte-type named pipes or for anonymous pipes.
        /// </param>
        /// <returns>
        ///     If the function succeeds, the return value is nonzero.
        ///     <para>
        ///         If the function fails, the return value is zero. To get extended error information, call
        ///         <see cref="GetLastError" />.
        ///     </para>
        /// </returns>
        [DllImport(api_ms_win_core_namedpipe_l1_2_0, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern unsafe bool PeekNamedPipe(
            SafeObjectHandle hNamedPipe,
            void* lpBuffer,
            int nBufferSize,
            out int lpBytesRead,
            out int lpTotalBytesAvail,
            out int lpBytesLeftThisMessage);

        /// <summary>
        ///     Sets the read mode and the blocking mode of the specified named pipe. If the specified handle is to the client
        ///     end of a named pipe and if the named pipe server process is on a remote computer, the function can also be used to
        ///     control local buffering.
        /// </summary>
        /// <param name="hNamedPipe">
        ///     A handle to the named pipe instance. This parameter can be a handle to the server end of the
        ///     pipe, as returned by the <see cref="CreateNamedPipe(string, PipeAccessMode, PipeMode, int, int, int, int, SECURITY_ATTRIBUTES*)" /> function, or to the client end of the pipe, as returned by
        ///     the <see cref="CreateFile(string, ACCESS_MASK, FileShare, SECURITY_ATTRIBUTES*, CreationDisposition, CreateFileFlags, SafeObjectHandle)" /> function. The handle must have GENERIC_WRITE access to the named pipe for a
        ///     write-only or read/write pipe, or it must have GENERIC_READ and FILE_WRITE_ATTRIBUTES access for a read-only pipe.
        ///     <para>
        ///         This parameter can also be a handle to an anonymous pipe, as returned by the <see cref="CreatePipe(out SafeObjectHandle, out SafeObjectHandle, SECURITY_ATTRIBUTES*, int)" />
        ///         function.
        ///     </para>
        /// </param>
        /// <param name="lpMode">The new pipe mode. The mode is a combination of a read-mode flag and a wait-mode flag.</param>
        /// <param name="lpMaxCollectionCount">
        ///     The maximum number of bytes collected on the client computer before transmission to
        ///     the server. This parameter must be NULL if the specified pipe handle is to the server end of a named pipe or if
        ///     client and server processes are on the same machine. This parameter is ignored if the client process specifies the
        ///     FILE_FLAG_WRITE_THROUGH flag in the CreateFile function when the handle was created. This parameter can be NULL if
        ///     the collection count is not being set.
        /// </param>
        /// <param name="lpCollectDataTimeout">
        ///     The maximum time, in milliseconds, that can pass before a remote named pipe
        ///     transfers information over the network. This parameter must be NULL if the specified pipe handle is to the server
        ///     end of a named pipe or if client and server processes are on the same computer. This parameter is ignored if the
        ///     client process specified the FILE_FLAG_WRITE_THROUGH flag in the CreateFile function when the handle was created.
        ///     This parameter can be NULL if the collection count is not being set.
        /// </param>
        /// <returns>
        ///     If the function succeeds, the return value is nonzero.
        ///     <para>
        ///         If the function fails, the return value is zero. To get extended error information, call
        ///         <see cref="GetLastError" />.
        ///     </para>
        /// </returns>
        [DllImport(api_ms_win_core_namedpipe_l1_2_0, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern unsafe bool SetNamedPipeHandleState(
            SafeObjectHandle hNamedPipe,
            [Friendly(FriendlyFlags.Optional | FriendlyFlags.In)] PipeMode* lpMode,
            [Friendly(FriendlyFlags.Optional | FriendlyFlags.In)] int* lpMaxCollectionCount,
            [Friendly(FriendlyFlags.Optional | FriendlyFlags.In)] int* lpCollectDataTimeout);

        /// <summary>
        ///     Combines the functions that write a message to and read a message from the specified named pipe into a single
        ///     network operation.
        /// </summary>
        /// <param name="hNamedPipe">
        ///     A handle to the named pipe returned by the <see cref="CreateNamedPipe(string, PipeAccessMode, PipeMode, int, int, int, int, SECURITY_ATTRIBUTES*)" /> or
        ///     <see cref="CreateFile(string, ACCESS_MASK, FileShare, SECURITY_ATTRIBUTES*, CreationDisposition, CreateFileFlags, SafeObjectHandle)" /> function.
        ///     <para>
        ///         This parameter can also be a handle to an anonymous pipe, as returned by the <see cref="CreatePipe(out SafeObjectHandle, out SafeObjectHandle, SECURITY_ATTRIBUTES*, int)" />
        ///         function.
        ///     </para>
        /// </param>
        /// <param name="lpInBuffer">A pointer to the buffer containing the data to be written to the pipe.</param>
        /// <param name="nInBufferSize">The size of the input buffer, in bytes.</param>
        /// <param name="lpOutBuffer">A pointer to the buffer that receives the data read from the pipe.</param>
        /// <param name="nOutBufferSize">The size of the output buffer, in bytes.</param>
        /// <param name="lpBytesRead">A pointer to the variable that receives the number of bytes read from the pipe.</param>
        /// <param name="lpOverlapped">
        ///     A pointer to an <see cref="OVERLAPPED" /> structure. This structure is required if hNamedPipe was opened with
        ///     FILE_FLAG_OVERLAPPED.
        ///     <para>
        ///         If hNamedPipe was opened with FILE_FLAG_OVERLAPPED, the lpOverlapped parameter must not be NULL. It must
        ///         point to a valid <see cref="OVERLAPPED" /> structure. If hNamedPipe was created with FILE_FLAG_OVERLAPPED and
        ///         lpOverlapped is NULL, the function can incorrectly report that the operation is complete.
        ///     </para>
        ///     <para>
        ///         If hNamedPipe was opened with FILE_FLAG_OVERLAPPED and lpOverlapped is not NULL, TransactNamedPipe is
        ///         executed as an overlapped operation. The <see cref="OVERLAPPED" /> structure should contain a manual-reset
        ///         event object (which can be created by using the CreateEvent function). If the operation cannot be completed
        ///         immediately, TransactNamedPipe returns FALSE and GetLastError returns ERROR_IO_PENDING. In this situation, the
        ///         event object is set to the nonsignaled state before TransactNamedPipe returns, and it is set to the signaled
        ///         state when the transaction has finished. Also, you can be notified when an overlapped operation completes by
        ///         using the GetQueuedCompletionStatus or GetQueuedCompletionStatusEx functions. In this case, you do not need to
        ///         assign the manual-reset event in the <see cref="OVERLAPPED" /> structure, and the completion happens against
        ///         <paramref name="hNamedPipe" /> in the same way as an asynchronous read or write operation.
        ///     </para>
        ///     <para>
        ///         If hNamedPipe was not opened with FILE_FLAG_OVERLAPPED, TransactNamedPipe does not return until the operation
        ///         is complete.
        ///     </para>
        /// </param>
        /// <returns>
        ///     If the function succeeds, the return value is nonzero.
        ///     <para>
        ///         If the function fails, the return value is zero. To get extended error information, call
        ///         <see cref="GetLastError" />.
        ///     </para>
        ///     <para>
        ///         If the message to be read is longer than the buffer specified by the <paramref name="nOutBufferSize" />
        ///         parameter, TransactNamedPipe returns FALSE and the <see cref="GetLastError" /> function returns
        ///         <see cref="Win32ErrorCode.ERROR_MORE_DATA" />. The remainder of the message can be read by a subsequent call to
        ///         <see cref="ReadFile(SafeObjectHandle,void*,int,int*,OVERLAPPED*)" />, ReadFileEx, or PeekNamedPipe.
        ///     </para>
        /// </returns>
        [DllImport(api_ms_win_core_namedpipe_l1_2_0, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern unsafe bool TransactNamedPipe(
            SafeObjectHandle hNamedPipe,
            void* lpInBuffer,
            int nInBufferSize,
            void* lpOutBuffer,
            int nOutBufferSize,
            out int lpBytesRead,
            OVERLAPPED* lpOverlapped);

        /// <summary>
        /// Allocates the specified number of bytes from the heap.
        /// </summary>
        /// <param name="uFlags">
        /// The memory allocation attributes. The default is the <see cref="LocalAllocFlags.LMEM_FIXED"/> value.
        /// This parameter can be one or more of the following values, except for the incompatible combinations that are specifically noted.
        /// </param>
        /// <param name="uBytes">
        /// The number of bytes to allocate. If this parameter is zero and the <paramref name="uFlags"/> parameter specifies <see cref="LocalAllocFlags.LMEM_MOVEABLE"/>,
        /// the function returns a handle to a memory object that is marked as discarded.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is a handle to the newly allocated memory object.
        /// If the function fails, the return value is NULL. To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        [DllImport(nameof(Kernel32), SetLastError = true)]
        public static extern unsafe void* LocalAlloc(LocalAllocFlags uFlags, IntPtr uBytes);

        /// <summary>
        /// Changes the size or the attributes of a specified local memory object. The size can increase or decrease.
        /// </summary>
        /// <param name="hMem">
        /// A handle to the local memory object to be reallocated.
        /// This handle is returned by either the <see cref="LocalAlloc(LocalAllocFlags, IntPtr)"/> or <see cref="LocalReAlloc(void*, IntPtr, LocalReAllocFlags)"/> function.
        /// </param>
        /// <param name="uBytes">The new size of the memory block, in bytes. If uFlags specifies <see cref="LocalReAllocFlags.LMEM_MODIFY"/>, this parameter is ignored.</param>
        /// <param name="uFlags">
        /// The reallocation options. If <see cref="LocalReAllocFlags.LMEM_MODIFY"/> is specified, the function modifies the attributes of the memory object only
        /// (the uBytes parameter is ignored.) Otherwise, the function reallocates the memory object.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is a handle to the reallocated memory object.
        /// If the function fails, the return value is NULL. To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// If LocalReAlloc fails, the original memory is not freed, and the original handle and pointer are still valid.
        /// If LocalReAlloc reallocates a fixed object, the value of the handle returned is the address of the first byte of the memory block.
        /// To access the memory, a process can simply cast the return value to a pointer.
        /// </remarks>
        [DllImport(nameof(Kernel32), SetLastError = true)]
        public static extern unsafe void* LocalReAlloc(void* hMem, IntPtr uBytes, LocalReAllocFlags uFlags);

        /// <summary>
        /// Frees the specified local memory object and invalidates its handle.
        /// </summary>
        /// <param name="hMem">
        /// A handle to the local memory object. This handle is returned by either the <see cref="LocalAlloc(LocalAllocFlags, IntPtr)"/> or
        /// <see cref="LocalReAlloc(void*, IntPtr, LocalReAllocFlags)"/> function. It is not safe to free memory allocated with <see cref="GlobalAlloc(GlobalAllocFlags, IntPtr)"/>.
        /// If the hMem parameter is NULL, LocalFree ignores the parameter and returns NULL.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is NULL.
        /// If the function fails, the return value is equal to a handle to <paramref name="hMem"/>. To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        [DllImport(nameof(Kernel32), SetLastError = true)]
        public static extern unsafe void* LocalFree(void* hMem);

        /// <summary>
        /// Locks a local memory object and returns a pointer to the first byte of the object's memory block.
        /// </summary>
        /// <param name="hMem">A handle to the local memory object. This handle is returned by either the <see cref="LocalAlloc(LocalAllocFlags, IntPtr)"/> or <see cref="LocalReAlloc(void*, int, LocalReAllocFlags)"/> function.</param>
        /// <returns>
        /// If the function succeeds, the return value is a pointer to the first byte of the memory block.
        /// If the function fails, the return value is <see cref="IntPtr.Zero"/>. To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        [DllImport(nameof(Kernel32), SetLastError = true)]
        public static unsafe extern void* LocalLock(void* hMem);

        /// <summary>
        /// Decrements the lock count associated with a memory object that was allocated with <see cref="LocalAllocFlags.LMEM_MOVEABLE"/>.
        /// This function has no effect on memory objects allocated with <see cref="LocalAllocFlags.LMEM_FIXED"/>.
        /// </summary>
        /// <param name="hMem">A handle to the local  memory object. This handle is returned by either the <see cref="LocalAlloc(LocalAllocFlags, IntPtr)"/> or <see cref="LocalReAlloc(void*, int, LocalReAllocFlags)"/> function.</param>
        /// <returns>
        /// If the memory object is still locked after decrementing the lock count, the return value is true.
        /// If the memory object is unlocked after decrementing the lock count, the function returns false and <see cref="GetLastError"/> returns <see cref="Win32ErrorCode.ERROR_SUCCESS"/>.
        /// If the function fails, the return value is false and <see cref="GetLastError"/> returns a value other than <see cref="Win32ErrorCode.ERROR_SUCCESS"/>.
        /// </returns>
        [DllImport(nameof(Kernel32), SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static unsafe extern bool LocalUnlock(void* hMem);

        /// <summary>
        /// Allocates the specified number of bytes from the heap.
        /// </summary>
        /// <param name="uFlags">
        /// The memory allocation attributes. The default is the <see cref="GlobalAllocFlags.GMEM_FIXED"/> value.
        /// This parameter can be one or more of the following values, except for the incompatible combinations that are specifically noted.
        /// </param>
        /// <param name="uBytes">
        /// The number of bytes to allocate. If this parameter is zero and the uFlags parameter specifies <see cref="GlobalAllocFlags.GMEM_MOVEABLE"/>,
        /// the function returns a handle to a memory object that is marked as discarded.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is a handle to the newly allocated memory object.
        /// If the function fails, the return value is NULL. To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        [DllImport(nameof(Kernel32), SetLastError = true)]
        public static extern unsafe void* GlobalAlloc(GlobalAllocFlags uFlags, IntPtr uBytes);

        /// <summary>
        /// Changes the size or attributes of a specified global memory object. The size can increase or decrease.
        /// </summary>
        /// <param name="hMem">
        /// A handle to the global memory object to be reallocated.
        /// This handle is returned by either the <see cref="GlobalAlloc(GlobalAllocFlags, IntPtr)"/> or <see cref="GlobalReAlloc(void*, IntPtr, GlobalReAllocFlags)"/> function.
        /// </param>
        /// <param name="uBytes">The new size of the memory block, in bytes. If uFlags specifies <see cref="GlobalAllocFlags.GMEM_MODIFY"/>, this parameter is ignored.</param>
        /// <param name="uFlags">
        /// The reallocation options. If <see cref="LocalReAllocFlags.LMEM_MODIFY"/> is specified, the function modifies the attributes of the memory object only
        /// (the uBytes parameter is ignored.) Otherwise, the function reallocates the memory object.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is a handle to the reallocated memory object.
        /// If the function fails, the return value is NULL. To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// If GlobalReAlloc fails, the original memory is not freed, and the original handle and pointer are still valid.
        /// If GlobalReAlloc reallocates a fixed object, the value of the handle returned is the address of the first byte of the memory block.
        /// To access the memory, a process can simply cast the return value to a pointer.
        /// </remarks>
        [DllImport(nameof(Kernel32), SetLastError = true)]
        public static extern unsafe void* GlobalReAlloc(void* hMem, IntPtr uBytes, GlobalReAllocFlags uFlags);

        /// <summary>
        /// Frees the specified global memory object and invalidates its handle.
        /// </summary>
        /// <param name="hMem">
        /// A handle to the global memory object. This handle is returned by either the <see cref="GlobalAlloc(GlobalAllocFlags, IntPtr)"/> or
        /// <see cref="GlobalReAlloc(void*, IntPtr, GlobalReAllocFlags)"/> function. It is not safe to free memory allocated with <see cref="LocalAlloc(LocalAllocFlags, IntPtr)"/>.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is NULL.
        /// If the function fails, the return value is equal to a handle to <paramref name="hMem"/>. To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        [DllImport(nameof(Kernel32), SetLastError = true)]
        public static extern unsafe void* GlobalFree(void* hMem);

        /// <summary>
        /// Locks a global memory object and returns a pointer to the first byte of the object's memory block.
        /// </summary>
        /// <param name="hMem">A handle to the global memory object. This handle is returned by either the <see cref="GlobalAlloc(GlobalAllocFlags, IntPtr)"/> or <see cref="GlobalReAlloc(void*, IntPtr, GlobalReAllocFlags)"/> function.</param>
        /// <returns>
        /// If the function succeeds, the return value is a pointer to the first byte of the memory block.
        ///  If the function fails, the return value is <see cref="IntPtr.Zero"/>. To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        [DllImport(nameof(Kernel32), SetLastError = true)]
        public static unsafe extern void* GlobalLock(void* hMem);

        /// <summary>
        /// Decrements the lock count associated with a memory object that was allocated with <see cref="GlobalAllocFlags.GMEM_MOVEABLE"/>.
        /// This function has no effect on memory objects allocated with <see cref="GlobalAllocFlags.GMEM_FIXED"/>.
        /// </summary>
        /// <param name="hMem">A handle to the global memory object. This handle is returned by either the <see cref="GlobalAlloc(GlobalAllocFlags, IntPtr)"/> or <see cref="GlobalReAlloc(void*, IntPtr, GlobalReAllocFlags)"/> function.</param>
        /// <returns>
        /// If the memory object is still locked after decrementing the lock count, the return value is true.
        /// If the memory object is unlocked after decrementing the lock count, the function returns false and <see cref="GetLastError"/> returns <see cref="Win32ErrorCode.ERROR_SUCCESS"/>.
        /// If the function fails, the return value is false and <see cref="GetLastError"/> returns a value other than <see cref="Win32ErrorCode.ERROR_SUCCESS"/>.
        /// </returns>
        [DllImport(nameof(Kernel32), SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static unsafe extern bool GlobalUnlock(void* hMem);

        /// <summary>
        /// Allocates a block of memory from a heap. The allocated memory is not movable.
        /// </summary>
        /// <param name="hHeap">A handle to the heap from which the memory will be allocated. This handle is returned by the HeapCreate or  function.</param>
        /// <param name="uFlags">The heap allocation options. Specifying any of these values will override the corresponding value specified when the heap was created with HeapCreate.</param>
        /// <param name="uBytes">
        /// The number of bytes to be allocated. If the heap specified by the hHeap parameter is a "non-growable" heap,
        /// dwBytes must be less than 0x7FFF8.
        /// You create a non-growable heap by calling the HeapCreate function with a nonzero value.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is a pointer to the allocated memory block.
        /// If the function fails and you have not specified <see cref="HeapAllocFlags.HEAP_GENERATE_EXCEPTIONS"/>, the return value is NULL.
        /// If the function fails and you have specified <see cref="HeapAllocFlags.HEAP_GENERATE_EXCEPTIONS"/>,
        /// the function may generate either of the exceptions listed in the following table:
        /// <list>
        /// <item>STATUS_NO_MEMORY: The allocation attempt failed because of a lack of available memory or heap corruption.</item>
        /// <item>STATUS_ACCESS_VIOLATION: The allocation attempt failed because of heap corruption or improper function parameters.</item>
        /// </list>
        /// The particular exception depends upon the nature of the heap corruption. For more information, see GetExceptionCode.
        /// </returns>
        /// <remarks>If the function fails, it does not call SetLastError. An application cannot call <see cref="GetLastError"/> for extended error information.</remarks>
        [DllImport(nameof(Kernel32), SetLastError = false)]
        public static extern unsafe void* HeapAlloc(IntPtr hHeap, HeapAllocFlags uFlags, IntPtr uBytes);

        /// <summary>
        /// Reallocates a block of memory from a heap. This function enables you to resize a memory block and change other memory block properties.
        /// The allocated memory is not movable.
        /// </summary>
        /// <param name="hHeap">A handle to the heap from which the memory is to be reallocated. This handle is a returned by either the HeapCreate or GetProcessHeap function.</param>
        /// <param name="uFlags">
        /// The heap reallocation options. Specifying a value overrides the corresponding value specified in the flOptions parameter
        /// when the heap was created by using the HeapCreate function.
        /// </param>
        /// <param name="hMem">
        /// A pointer to the block of memory that the function reallocates.
        /// This pointer is returned by an earlier call to the <see cref="HeapAlloc(IntPtr, HeapAllocFlags, IntPtr)"/> or <see cref="HeapReAlloc(IntPtr, HeapReAllocFlags, void*, IntPtr)"/> function.
        /// </param>
        /// <param name="uBytes">
        /// The new size of the memory block, in bytes. A memory block's size can be increased or decreased by using this function.
        /// If the heap specified by the hHeap parameter is a "non-growable" heap, dwBytes must be less than 0x7FFF8.
        /// You create a non-growable heap by calling the HeapCreate function with a nonzero value.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is a pointer to the reallocated memory block.
        /// If the function fails and you have not specified <see cref="HeapAllocFlags.HEAP_GENERATE_EXCEPTIONS"/>, the return value is NULL.
        /// If the function fails and you have specified <see cref="HeapAllocFlags.HEAP_GENERATE_EXCEPTIONS"/>,
        /// the function may generate either of the exceptions listed in the following table:
        /// <list>
        /// <item>STATUS_NO_MEMORY: The allocation attempt failed because of a lack of available memory or heap corruption.</item>
        /// <item>STATUS_ACCESS_VIOLATION: The allocation attempt failed because of heap corruption or improper function parameters.</item>
        /// </list>
        /// The particular exception depends upon the nature of the heap corruption. For more information, see GetExceptionCode.
        /// </returns>
        /// <remarks>If the function fails, it does not call SetLastError. An application cannot call <see cref="GetLastError"/> for extended error information.</remarks>
        [DllImport(nameof(Kernel32), SetLastError = false)]
        public static extern unsafe void* HeapReAlloc(IntPtr hHeap, HeapReAllocFlags uFlags, void* hMem, IntPtr uBytes);

        /// <summary>
        /// Frees a memory block allocated from a heap by the <see cref="HeapAlloc(IntPtr, HeapAllocFlags, IntPtr)"/> or <see cref="HeapReAlloc(IntPtr, HeapReAllocFlags, void*, IntPtr)"/> function.
        /// </summary>
        /// <param name="hHeap">
        /// A handle to the heap whose memory block is to be freed. This handle is returned by either the HeapCreate or
        /// GetProcessHeap function.
        /// </param>
        /// <param name="dwFlags">The heap free options. Specifying the following value overrides the corresponding value specified in the flOptions parameter
        /// when the heap was created by using the HeapCreate function.</param>
        /// <param name="hMem">
        /// A pointer to the memory block to be freed. This pointer is returned by the <see cref="HeapAlloc(IntPtr, HeapAllocFlags, IntPtr)"/> or <see cref="HeapReAlloc(IntPtr, HeapReAllocFlags, void*, IntPtr)"/> function.
        /// If this pointer is NULL, the behavior is undefined.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is true. If the function fails, the return value false. To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        [DllImport(nameof(Kernel32), SetLastError = true)]
        [return:MarshalAs(UnmanagedType.Bool)]
        public static extern unsafe bool HeapFree(IntPtr hHeap, HeapFreeFlags dwFlags, void* hMem);

        /// <summary>
        /// Attempts to acquire the critical section object, or lock, that is associated with a specified heap.
        /// </summary>
        /// <param name="hMem">A handle to the heap to be locked. This handle is returned by either the <see cref="HeapAlloc(IntPtr, HeapAllocFlags, IntPtr)"/> or <see cref="HeapReAlloc(IntPtr, HeapReAllocFlags, void*, IntPtr)"/> function.</param>
        /// <returns>
        /// If the function succeeds, the return value is true. If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        [DllImport(nameof(Kernel32), SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool HeapLock(IntPtr hMem);

        /// <summary>
        /// Releases ownership of the critical section object, or lock, that is associated with a specified heap. It reverses the action of the <see cref="HeapLock"/> function.
        /// </summary>
        /// <param name="hHeap">A handle to the heap to be unlocked. This handle is returned by either the HeapCreate or GetProcessHeap function.</param>
        /// <returns>
        /// If the function succeeds, the return value is true. If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        [DllImport(nameof(Kernel32), SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool HeapUnlock(IntPtr hHeap);

        /// <summary>
        /// Copies a block of memory from one location to another.
        /// </summary>
        /// <param name="Destination">A pointer to the starting address of the copied block's destination.</param>
        /// <param name="Source">A pointer to the starting address of the block of memory to copy.</param>
        /// <param name="Length">The size of the block of memory to copy, in bytes.</param>
        /// <remarks>
        /// This function is defined as the RtlCopyMemory function.
        /// If the source and destination blocks overlap, the results are undefined.
        /// For overlapped blocks, use the <see cref="MoveMemory(void*, void*, IntPtr)"/> function.
        /// </remarks>
        [DllImport(nameof(Kernel32), SetLastError = false)]
        public static unsafe extern void CopyMemory(void* Destination, void* Source, IntPtr Length);

        /// <summary>
        /// Moves a block of memory from one location to another.
        /// </summary>
        /// <param name="Destination">A pointer to the starting address of the move destination.</param>
        /// <param name="Source">A pointer to the starting address of the block of memory to be moved.</param>
        /// <param name="Length">The size of the block of memory to move, in bytes.</param>
        /// <remarks>
        /// <para>
        /// This function is defined as the RtlMoveMemory function.
        /// The source and destination blocks may overlap.
        /// </para>
        /// <para>
        /// The first parameter, <paramref name="Destination"/>, must be large enough to hold <paramref name="Length"/> bytes of <paramref name="Source"/>;
        /// otherwise, a buffer overrun may occur.
        /// This may lead to a denial of service attack against the application if an access violation occurs or, in the worst case,
        /// allow an attacker to inject executable code into your process.
        /// This is especially true if <paramref name="Destination"/> is a stack-based buffer.
        /// Be aware that the last parameter, <paramref name="Length"/>, is the number of bytes to copy into <paramref name="Destination"/>, not the size of the <paramref name="Destination"/>.
        /// </para>
        /// </remarks>
        [DllImport(nameof(Kernel32), SetLastError = false)]
        public static unsafe extern void MoveMemory(void* Destination, void* Source, IntPtr Length);

        /// <summary>
        ///     Enumerates resources of a specified type within a binary module. For Windows Vista and later, this is
        ///     typically a language-neutral Portable Executable (LN file), and the enumeration will also include resources from
        ///     the corresponding language-specific resource files (.mui files) that contain localizable language resources. It is
        ///     also possible for hModule to specify an .mui file, in which case only that file is searched for resources.
        /// </summary>
        /// <param name="hModule">
        ///     A handle to a module to be searched. Starting with Windows Vista, if this is an LN file, then appropriate .mui
        ///     files (if any exist) are included in the search.
        ///     <para>
        ///         If this parameter is NULL, that is equivalent to passing in a handle to the module used to create the current
        ///         process.
        ///     </para>
        /// </param>
        /// <param name="lpszType">
        ///     The type of the resource for which the name is being enumerated. Alternately, rather than a
        ///     pointer, this parameter can be <see cref="MAKEINTRESOURCE" />(ID), where ID is an integer value representing a
        ///     predefined resource type.
        /// </param>
        /// <param name="lpEnumFunc">A pointer to the callback function to be called for each enumerated resource name or ID.</param>
        /// <param name="lParam">
        ///     An application-defined value passed to the callback function. This parameter can be used in error
        ///     checking.
        /// </param>
        /// <returns>
        ///     The return value is TRUE if the function succeeds or FALSE if the function does not find a resource of the
        ///     type specified, or if the function fails for another reason. To get extended error information, call
        ///     <see cref="GetLastError" />.
        /// </returns>
        [DllImport(nameof(Kernel32), SetLastError = true, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern unsafe bool EnumResourceNames(SafeLibraryHandle hModule, char* lpszType, EnumResNameProc lpEnumFunc, IntPtr lParam);

        /// <summary>
        ///     Enumerates language-specific resources, of the specified type and name, associated with a binary module.
        /// </summary>
        /// <param name="hModule">
        ///     The handle to a module to be searched. Starting with Windows Vista, if this is a language-neutral Portable
        ///     Executable (LN file), then appropriate .mui files (if any exist) are included in the search. If this is a
        ///     specific .mui file, only that file is searched for resources.
        ///     <para>
        ///         If this parameter is NULL, that is equivalent to passing in a handle to the module used to create the current process.
        ///     </para>
        /// </param>
        /// <param name="lpType">
        ///     The type of resource for which the language is being enumerated. Alternately, rather than a pointer, this
        ///     parameter can be <see cref="MAKEINTRESOURCE(int)"/>(ID), where ID is an integer value representing a predefined resource type.
        /// </param>
        /// <param name="lpName">
        ///     The name of the resource for which the language is being enumerated. Alternately, rather than a pointer,
        ///     this parameter can be <see cref="MAKEINTRESOURCE(int)"/>(ID), where ID is the integer identifier of the resource.
        /// </param>
        /// <param name="lpEnumFunc">
        ///     A pointer to the callback function to be called for each enumerated resource language. For more information,
        ///     see <see cref="EnumResLangProc"/>.
        /// </param>
        /// <param name="lParam">
        ///     An application-defined value passed to the callback function. This parameter can be used in error checking.
        /// </param>
        /// <returns>Returns TRUE if successful or FALSE otherwise. To get extended error information, call <see cref="GetLastError"/>.</returns>
        [DllImport(nameof(Kernel32), SetLastError = true, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern unsafe bool EnumResourceLanguages(SafeLibraryHandle hModule, char* lpType, char* lpName, EnumResLangProc lpEnumFunc, void* lParam);

        /// <summary>Determines whether a value is an integer identifier for a resource.</summary>
        /// <param name="p">The pointer to be tested whether it contains an integer resource identifier.</param>
        /// <returns>If the value is a resource identifier, the return value is TRUE. Otherwise, the return value is FALSE.</returns>
        public static unsafe bool IS_INTRESOURCE(char* p) => (long)p >> 16 == 0;

        /// <summary>
        ///     Converts an integer value to a resource type compatible with the resource-management functions. This macro is
        ///     used in place of a string containing the name of the resource.
        /// </summary>
        /// <param name="wInteger">The integer value to be converted.</param>
        /// <returns>The return value is the specified value in the low-order word and zero in the high-order word.</returns>
        public static unsafe char* MAKEINTRESOURCE(int wInteger) => (char*)wInteger;

        /// <summary>
        ///     Determines the location of a resource with the specified type and name in the specified module.
        ///     <para>To specify a language, use the FindResourceEx function.</para>
        /// </summary>
        /// <param name="hModule">
        ///     A handle to the module whose portable executable file or an accompanying MUI file contains the
        ///     resource. If this parameter is <see cref="SafeLibraryHandle.Null" />, the function searches the module used to
        ///     create the current process.
        /// </param>
        /// <param name="lpName">
        ///     The name of the resource. Alternately, rather than a pointer, this parameter can be
        ///     <see cref="MAKEINTRESOURCE" />, where wInteger is the integer identifier of the resource.
        /// </param>
        /// <param name="lpType">
        ///     The resource type. Alternately, rather than a pointer, this parameter can be
        ///     <see cref="MAKEINTRESOURCE" />, where wInteger is the integer identifier of the given resource type.
        /// </param>
        /// <returns>
        ///     If the function succeeds, the return value is a handle to the specified resource's information block. To obtain a
        ///     handle to the resource, pass this handle to the <see cref="LoadResource"/> function.
        ///     <para>
        ///         If the function fails, the return value is NULL. To get extended error information, call
        ///         <see cref="GetLastError" />.
        ///     </para>
        /// </returns>
        [DllImport(nameof(Kernel32), CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern unsafe IntPtr FindResource(SafeLibraryHandle hModule, char* lpName, char* lpType);

        /// <summary>Retrieves the size, in bytes, of the specified resource.</summary>
        /// <param name="hModule">A handle to the module whose executable file contains the resource.</param>
        /// <param name="hResInfo">
        ///     handle to the resource. This handle must be created by using the <see cref="FindResource(SafeLibraryHandle,char*,char*)" /> or
        ///     FindResourceEx function.
        /// </param>
        /// <returns>
        ///     If the function succeeds, the return value is the number of bytes in the resource.
        ///     <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
        /// </returns>
        [DllImport(nameof(Kernel32), SetLastError = true)]
        public static extern int SizeofResource(SafeLibraryHandle hModule, IntPtr hResInfo);

        /// <summary>
        /// Suspends the specified WOW64 thread.
        /// </summary>
        /// <param name="hThread">
        /// A handle to the thread that is to be suspended.
        /// The handle must have the THREAD_SUSPEND_RESUME access right. For more information, see Thread Security and Access Rights.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is the thread's previous suspend count; otherwise, it is (DWORD) -1. To get extended error information, use the <see cref="GetLastError"/> function.
        /// </returns>
        [DllImport(nameof(Kernel32), SetLastError = true)]
        public static extern int Wow64SuspendThread(SafeObjectHandle hThread);

        /// <summary>
        /// Assigns a process to an existing job object.
        /// </summary>
        /// <param name="hJob">
        /// A handle to the job object to which the process will be associated.
        /// The CreateJobObject or OpenJobObject function returns this handle.
        /// The handle must have the JOB_OBJECT_ASSIGN_PROCESS access right. For more information, see Job Object Security and Access Rights.
        /// </param>
        /// <param name="hProcess">
        /// A handle to the process to associate with the job object. The handle must have the PROCESS_SET_QUOTA and PROCESS_TERMINATE access rights. For more information, see Process Security and Access Rights.
        /// If the process is already associated with a job, the job specified by hJob must be empty or it must be in the hierarchy of nested jobs to which the process already belongs, and it cannot have UI limits set(SetInformationJobObject with JobObjectBasicUIRestrictions).
        /// For more information, see Remarks.
        /// Windows 7, Windows Server 2008 R2, Windows XP with SP3, Windows Server 2008, Windows Vista, and Windows Server 2003:  The process must not already be assigned to a job; if it is, the function fails with ERROR_ACCESS_DENIED.This behavior changed starting in Windows 8 and Windows Server 2012.
        /// Terminal Services:  All processes within a job must run within the same session as the job.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is nonzero.
        /// If the function fails, the return value is zero.To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        [DllImport(nameof(Kernel32), SetLastError = true)]
        public static extern bool AssignProcessToJobObject(SafeObjectHandle hJob, SafeObjectHandle hProcess);

        /// <summary>
        /// Creates or opens a job object.
        /// </summary>
        /// <param name="lpJobAttributes">A pointer to a <see cref="SECURITY_ATTRIBUTES"/> structure that specifies the security descriptor for the job object and determines whether child processes can inherit the returned handle.
        /// If lpJobAttributes is NULL, the job object gets a default security descriptor and the handle cannot be inherited.
        /// The ACLs in the default security descriptor for a job object come from the primary or impersonation token of the creator.
        /// </param>
        /// <param name="lpName">The name of the job. The name is limited to MAX_PATH characters. Name comparison is case-sensitive.
        /// If lpName is NULL, the job is created without a name.
        /// If lpName matches the name of an existing event, semaphore, mutex, waitable timer, or file-mapping object, the function fails and the GetLastError function returns ERROR_INVALID_HANDLE.
        /// This occurs because these objects share the same namespace.The object can be created in a private namespace.For more information, see Object Namespaces.
        /// Terminal Services:  The name can have a "Global\" or "Local\" prefix to explicitly create the object in the global or session namespace. The remainder of the name can contain any character except the backslash character (\). For more information, see Kernel Object Namespaces.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is a handle to the job object. The handle has the JOB_OBJECT_ALL_ACCESS access right. If the object existed before the function call, the function returns a handle to the existing job object and GetLastError returns ERROR_ALREADY_EXISTS.
        /// If the function fails, the return value is NULL.To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        [DllImport(nameof(Kernel32), SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern unsafe SafeObjectHandle CreateJobObject(SECURITY_ATTRIBUTES* lpJobAttributes, string lpName);

        /// <summary>
        /// Determines whether the process is running in the specified job.
        /// </summary>
        /// <param name="hProcess">
        /// A handle to the process to be tested. The handle must have the PROCESS_QUERY_INFORMATION or PROCESS_QUERY_LIMITED_INFORMATION access right. For more information, see Process Security and Access Rights.
        /// Windows Server 2003 and Windows XP:  The handle must have the PROCESS_QUERY_INFORMATION access right.
        /// </param>
        /// <param name="hJob">
        /// A handle to the job. If this parameter is NULL, the function tests if the process is running under any job.
        /// If this parameter is not NULL, the handle must have the JOB_OBJECT_QUERY access right. For more information, see Job Object Security and Access Rights.
        /// </param>
        /// <param name="result">
        /// A pointer to a value that receives TRUE if the process is running in the job, and FALSE otherwise.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is nonzero.
        /// If the function fails, the return value is zero.To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        [DllImport(nameof(Kernel32), SetLastError = true)]
        public static extern bool IsProcessInJob(SafeObjectHandle hProcess, SafeObjectHandle hJob, out bool result);

        /// <summary>
        /// Sets limits for a job object.
        /// </summary>
        /// <param name="hJob">
        /// A handle to the job whose limits are being set. The CreateJobObject or OpenJobObject function returns this handle. The handle must have the JOB_OBJECT_SET_ATTRIBUTES access right. For more information, see Job Object Security and Access Rights.
        /// </param>
        /// <param name="jobObjectInfoClass">
        /// The information class for the limits to be set.
        /// </param>
        /// <param name="lpJobObjectInfo">T
        /// he limits or job state to be set for the job. The format of this data depends on the value of JobObjectInfoClass.
        /// </param>
        /// <param name="cbJobObjectInfoLength">
        /// The size of the job information being set, in bytes.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is nonzero.
        /// If the function fails, the return value is zero.To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        [DllImport(nameof(Kernel32), SetLastError = true)]
        public static extern unsafe bool SetInformationJobObject(SafeObjectHandle hJob, JOBOBJECT_INFO_CLASS jobObjectInfoClass, void* lpJobObjectInfo, uint cbJobObjectInfoLength);

        [DllImport(nameof(Kernel32), SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GenerateConsoleCtrlEvent(ControlType dwCtrlEvent, uint dwProcessGroupId);

        [DllImport(nameof(Kernel32), CharSet = CharSet.Unicode, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool AddConsoleAlias(string Source, string Target, string ExeName);

        [DllImport(nameof(Kernel32), SetLastError = true)]
        public static unsafe extern IntPtr CreateConsoleScreenBuffer(
            ACCESS_MASK dwDesiredAccess,
            FileShare dwShareMode,
            [Friendly(FriendlyFlags.Optional | FriendlyFlags.In)] SECURITY_ATTRIBUTES* lpSecurityAttributes,
            ConsoleScreenBufferFlag dwFlags,
            void* lpScreenBufferData);

        [DllImport(nameof(Kernel32), SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool FlushConsoleInputBuffer(IntPtr hConsoleInput);

        [DllImport(nameof(Kernel32), CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern unsafe int GetConsoleAliases(
            [Friendly(FriendlyFlags.Out | FriendlyFlags.Array)] char* lpAliasBuffer,
            int AliasBufferLength,
            string lpExeName);

        [DllImport(nameof(Kernel32), CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern int GetConsoleAliasesLength(string lpExeName);

        [DllImport(nameof(Kernel32), CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern unsafe int GetConsoleAliasExes(
            [Friendly(FriendlyFlags.Out | FriendlyFlags.Array)] char* lpExeNameBuffer,
            int ExeNameBufferLength);

        [DllImport(nameof(Kernel32), SetLastError = true)]
        public static extern int GetConsoleAliasExesLength();

        [DllImport(nameof(Kernel32), CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern unsafe int GetConsoleAlias(
            string lpSource,
            [Friendly(FriendlyFlags.Out | FriendlyFlags.Array)] char* lpTargetBuffer,
            int TargetBufferLength,
            string lpExeName);

        [DllImport(nameof(Kernel32), SetLastError = true)]
        public static extern uint GetConsoleCP();

        [DllImport(nameof(Kernel32), SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetConsoleDisplayMode(out ConsoleDisplayMode lpModeFlags);

        [DllImport(nameof(Kernel32), SetLastError = true)]
        public static extern COORD GetConsoleFontSize(IntPtr hConsoleOutput, uint nFont);

        [DllImport(nameof(Kernel32), SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetConsoleMode(IntPtr hConsoleHandle, out ConsoleBufferModes lpMode);

        [DllImport(nameof(Kernel32), SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetConsoleMode(IntPtr hConsoleHandle, ConsoleBufferModes dwMode);

        [DllImport(nameof(Kernel32), SetLastError = true)]
        public static extern uint GetConsoleOutputCP();

        [DllImport(nameof(Kernel32), SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetConsoleOutputCP(uint wCodePageID);

        [DllImport(nameof(Kernel32), SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetConsoleCP(uint wCodePageID);

        [DllImport(nameof(Kernel32), SetLastError = true)]
        public static unsafe extern int GetConsoleProcessList(
            [Friendly(FriendlyFlags.Array | FriendlyFlags.Out)] uint* lpdwProcessList,
            int dwProcessCount);

        [DllImport(nameof(Kernel32), SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static unsafe extern bool GetConsoleScreenBufferInfo(
            IntPtr hConsoleOutput,
            [Friendly(FriendlyFlags.Out)] CONSOLE_SCREEN_BUFFER_INFO* lpConsoleScreenBufferInfo);

        [DllImport(nameof(Kernel32), SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static unsafe extern bool GetConsoleSelectionInfo(
            [Friendly(FriendlyFlags.Out)] CONSOLE_SELECTION_INFO* lpConsoleSelectionInfo);

        [DllImport(nameof(Kernel32), CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern unsafe int GetConsoleTitle(
            [Friendly(FriendlyFlags.Out | FriendlyFlags.Array)] char* lpConsoleTitle,
            int nSize);

        [DllImport(nameof(Kernel32), CharSet = CharSet.Unicode, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetConsoleTitle(string lpConsoleTitle);

        [DllImport(nameof(Kernel32), SetLastError = true)]
        public static extern COORD GetLargestConsoleWindowSize(IntPtr hConsoleOutput);

        [DllImport(nameof(Kernel32), SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetNumberOfConsoleInputEvents(IntPtr hConsoleInput, out int lpNumberOfEvents);

        [DllImport(nameof(Kernel32), CharSet = CharSet.Unicode, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool PeekConsoleInput(IntPtr hConsoleInput, out INPUT_RECORD lpBuffer, int nLength, out int lpNumberOfEventsRead);

        [DllImport(nameof(Kernel32), CharSet = CharSet.Unicode, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool ReadConsoleOutput(IntPtr hConsoleOutput, out CHAR_INFO lpBuffer, COORD dwBufferSize, COORD dwBufferCoord, ref SMALL_RECT lpReadRegion);

        [DllImport(nameof(Kernel32), CharSet = CharSet.Unicode, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static unsafe extern bool ReadConsole(
            IntPtr hConsoleInput,
            void* lpBuffer,
            int nNumberOfCharsToRead,
            [Friendly(FriendlyFlags.Out)] int lpNumberOfCharsRead,
            IntPtr lpReserved);

        [DllImport(nameof(Kernel32), CharSet = CharSet.Unicode, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool ReadConsoleInput(IntPtr hConsoleInput, out INPUT_RECORD lpBuffer, int nLength, out int lpNumberOfEventsRead);

        [DllImport(nameof(Kernel32), CharSet = CharSet.Unicode, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static unsafe extern bool ScrollConsoleScreenBuffer(
            IntPtr hConsoleOutput,
            [Friendly(FriendlyFlags.In)] SMALL_RECT* lpScrollRectangle,
            [Friendly(FriendlyFlags.In | FriendlyFlags.Optional)] SMALL_RECT* lpClipRectangle,
            COORD dwDestinationOrigin,
            [Friendly(FriendlyFlags.In)] CHAR_INFO* lpFill);

        [DllImport(nameof(Kernel32), SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetConsoleActiveScreenBuffer(IntPtr hConsoleOutput);

        [DllImport(nameof(Kernel32), SetLastError = true)]
        public static extern uint WTSGetActiveConsoleSessionId();

        [DllImport(nameof(Kernel32), CharSet = CharSet.Unicode, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static unsafe extern bool WriteConsole(
            IntPtr hConsoleOutput,
            void* lpBuffer,
            int nNumberOfCharsToWrite,
            [Friendly(FriendlyFlags.Out)] int* lpNumberOfCharsWritten,
            IntPtr lpReserved);

        [DllImport(nameof(Kernel32), CharSet = CharSet.Unicode, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static unsafe extern bool WriteConsoleOutput(
            IntPtr hConsoleOutput,
            [Friendly(FriendlyFlags.In)] CHAR_INFO* lpBuffer,
            COORD dwBufferSize,
            COORD dwBufferCoord,
            [Friendly(FriendlyFlags.In | FriendlyFlags.Out)] SMALL_RECT* lpWriteRegion);

        [DllImport(nameof(Kernel32), CharSet = CharSet.Unicode, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static unsafe extern bool WriteConsoleInput(
            IntPtr hConsoleInput,
            [Friendly(FriendlyFlags.In)] INPUT_RECORD* lpBuffer,
            int nLength,
            [Friendly(FriendlyFlags.Out)] int* lpNumberOfEventsWritten);

        [DllImport(nameof(Kernel32), SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetConsoleTextAttribute(IntPtr hConsoleOutput, CharacterAttributesFlags wAttributes);

        [DllImport(nameof(Kernel32), SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetConsoleCursorPosition(IntPtr hConsoleOutput, COORD dwCursorPosition);

        /// <summary>
        /// Adds or removes an application-defined HandlerRoutine function from the list of handler
        /// functions for the calling process. If no handler function is specified, the function sets
        /// an inheritable attribute that determines whether the calling process ignores CTRL+C signals.
        /// </summary>
        /// <param name="handlerRoutine">
        /// A pointer to the application-defined HandlerRoutine function to be added or removed. This
        /// parameter can be NULL.
        /// </param>
        /// <param name="add">
        /// <para>
        /// If this parameter is TRUE, the handler is added; if it is FALSE, the handler is removed.
        /// </para>
        /// <para>
        /// If the HandlerRoutine parameter is NULL, a TRUE value causes the calling process to
        /// ignore CTRL+C input, and a FALSE value restores normal processing of CTRL+C input. This
        /// attribute of ignoring or processing CTRL+C is inherited by child processes.
        /// </para>
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is nonzero. If the function fails, the return
        /// value is zero.To get extended error information, call GetLastError.
        /// </returns>
        /// <remarks>
        /// <para>
        /// This function provides a similar notification for console application and services that
        /// WM_QUERYENDSESSION provides for graphical applications with a message pump. You could
        /// also use this function from a graphical application, but there is no guarantee it would
        /// arrive before the notification from WM_QUERYENDSESSION.
        /// </para>
        /// <para>
        /// Each console process has its own list of application-defined HandlerRoutine functions
        /// that handle CTRL+C and CTRL+BREAK signals. The handler functions also handle signals
        /// generated by the system when the user closes the console, logs off, or shuts down the
        /// system. Initially, the handler list for each process contains only a default handler
        /// function that calls the ExitProcess function. A console process adds or removes
        /// additional handler functions by calling the SetConsoleCtrlHandler function, which does
        /// not affect the list of handler functions for other processes. When a console process
        /// receives any of the control signals, its handler functions are called on a
        /// last-registered, first-called basis until one of the handlers returns TRUE. If none of
        /// the handlers returns TRUE, the default handler is called.
        /// </para>
        /// </remarks>
        [DllImport(nameof(Kernel32), SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetConsoleCtrlHandler(HandlerRoutine handlerRoutine, [MarshalAs(UnmanagedType.Bool)] bool add);

        /// <summary>
        /// Enables an application to inform the system that it is in use, thereby preventing the system from entering sleep or turning off the display while the application is running.
        /// </summary>
        /// <param name="esFlags">The thread's execution requirements.</param>
        /// <returns>
        /// If the function succeeds, the return value is the previous thread execution state.
        /// If the function fails, the return value is <see cref="EXECUTION_STATE.None"/>.
        /// </returns>
        [DllImport(nameof(Kernel32))]
        public static extern EXECUTION_STATE SetThreadExecutionState(EXECUTION_STATE esFlags);

        /// <summary>
        /// Writes data to an area of memory in a specified process. The entire area to be written to must be accessible or the operation fails.
        /// </summary>
        /// <param name="hProcess">A handle to the process memory to be modified. The handle must have <see cref="ProcessAccess.PROCESS_VM_WRITE"/> and <see cref="ProcessAccess.PROCESS_VM_OPERATION"/> access to the process.</param>
        /// <param name="lpBaseAddress">A pointer to the base address in the specified process to which data is written. Before data transfer occurs, the system verifies that all data in the base address and memory of the specified size is accessible for write access, and if it is not accessible, the function fails.</param>
        /// <param name="lpBuffer">A pointer to the buffer that contains data to be written in the address space of the specified process.</param>
        /// <param name="nSize">The number of bytes to be written to the specified process.</param>
        /// <param name="lpNumberOfBytesWritten">A pointer to a variable that receives the number of bytes transferred into the specified process. This parameter is optional. If <paramref name="lpNumberOfBytesWritten"/> is NULL, the parameter is ignored.</param>
        /// <returns>
        /// If the function succeeds, the return value is nonzero.
        /// If the function fails, the return value is 0 (zero). To get extended error information, call GetLastError. The function fails if the requested write operation crosses into an area of the process that is inaccessible.
        /// </returns>
        [DllImport(nameof(Kernel32), SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static unsafe extern bool WriteProcessMemory(
            IntPtr hProcess,
            void* lpBaseAddress,
            void* lpBuffer,
            IntPtr nSize,
            [Friendly(FriendlyFlags.Out | FriendlyFlags.Optional)] IntPtr* lpNumberOfBytesWritten);

        /// <summary>
        /// Reads data from an area of memory in a specified process. The entire area to be read must be accessible or the operation fails.
        /// </summary>
        /// <param name="hProcess">A handle to the process with memory that is being read. The handle must have <see cref="ProcessAccess.PROCESS_VM_READ"/> access to the process.</param>
        /// <param name="lpBaseAddress">A pointer to the base address in the specified process from which to read. Before any data transfer occurs, the system verifies that all data in the base address and memory of the specified size is accessible for read access, and if it is not accessible the function fails.</param>
        /// <param name="lpBuffer">A pointer to a buffer that receives the contents from the address space of the specified process.</param>
        /// <param name="nSize">The number of bytes to be read from the specified process.</param>
        /// <param name="lpNumberOfBytesRead">A pointer to a variable that receives the number of bytes transferred into the specified buffer. If <paramref name="lpNumberOfBytesRead"/> is NULL, the parameter is ignored.</param>
        /// <returns>
        /// If the function succeeds, the return value is nonzero.
        /// If the function fails, the return value is 0 (zero). To get extended error information, call GetLastError.
        /// The function fails if the requested read operation crosses into an area of the process that is inaccessible.
        /// </returns>
        [DllImport(nameof(Kernel32), SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static unsafe extern bool ReadProcessMemory(
            IntPtr hProcess,
            void* lpBaseAddress,
            void* lpBuffer,
            IntPtr nSize,
            [Friendly(FriendlyFlags.Out | FriendlyFlags.Optional)] IntPtr* lpNumberOfBytesRead);

        /// <summary>
        /// Retrieves a handle to the specified standard device (standard input, standard output, or standard error).
        /// </summary>
        /// <param name="nStdHandle">The standard device.</param>
        /// <returns>
        /// If the function succeeds, the return value is a handle to the specified device, or a redirected handle set by a previous call to <see cref="SetStdHandle"/>. The handle has GENERIC_READ and GENERIC_WRITE access rights, unless the application has used <see cref="SetStdHandle"/> to set a standard handle with lesser access.
        /// If the function fails, the return value is <see cref="INVALID_HANDLE_VALUE"/>. To get extended error information, call <see cref="GetLastError"/>.
        /// If an application does not have associated standard handles, such as a service running on an interactive desktop, and has not redirected them, the return value is NULL.
        /// </returns>
        [DllImport(nameof(Kernel32), SetLastError = true)]
        public static extern IntPtr GetStdHandle(StdHandle nStdHandle);

        /// <summary>
        /// Sets the handle for the specified standard device (standard input, standard output, or standard error).
        /// </summary>
        /// <param name="nStdHandle">The standard device for which the handle is to be set.</param>
        /// <param name="nHandle">The handle for the standard device.</param>
        /// <returns>
        /// If the function succeeds, the return value is nonzero.
        /// If the function fails, the return value is zero. To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        [DllImport(nameof(Kernel32), SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetStdHandle(StdHandle nStdHandle, IntPtr nHandle);
    }
}
