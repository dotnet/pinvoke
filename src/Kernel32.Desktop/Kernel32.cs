// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

#pragma warning disable SA1625 // Element documentation must not be copied and pasted

namespace PInvoke
{
    using System;
    using System.Runtime.InteropServices;
    using System.Text;

    /// <summary>
    /// Exported functions from the Kernel32.dll Windows library.
    /// </summary>
    public static partial class Kernel32
    {
        /// <summary>
        ///     Used to specify to <see cref="CreateNamedPipe" /> that the number of pipe instances that can be created is
        ///     limited only by the availability of system resources.
        /// </summary>
        public const int PIPE_UNLIMITED_INSTANCES = 255;

        /// <summary>The time-out interval is the default value specified by the server process in the
        ///     <see cref="CreateNamedPipe" /> function.
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
        /// Creates a new process and its primary thread. The new process runs in the security context of the calling process.
        /// If the calling process is impersonating another user, the new process uses the token for the calling process, not the impersonation token. To run the new process in the security context of the user represented by the impersonation token, use the <see cref="CreateProcessAsUser(IntPtr, string, string, SECURITY_ATTRIBUTES, SECURITY_ATTRIBUTES, bool, CreateProcessFlags, void*, string, ref STARTUPINFO, out PROCESS_INFORMATION)"/> or CreateProcessWithLogonW function.
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
            SECURITY_ATTRIBUTES lpProcessAttributes,
            SECURITY_ATTRIBUTES lpThreadAttributes,
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
            SECURITY_ATTRIBUTES lpProcessAttributes,
            SECURITY_ATTRIBUTES lpThreadAttributes,
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
        /// To add attributes to the list, call the <see cref="UpdateProcThreadAttribute(PROC_THREAD_ATTRIBUTE_LIST*, uint, ref uint, IntPtr, IntPtr, ref IntPtr, ref IntPtr)"/> function. To specify these attributes when creating a process, specify <see cref="CreateProcessFlags.EXTENDED_STARTUPINFO_PRESENT"/> in the dwCreationFlag parameter and a <see cref="STARTUPINFOEX"/> structure in the lpStartupInfo parameter. Note that you can specify the same <see cref="STARTUPINFOEX"/> structure to multiple child processes.
        /// When you have finished using the list, call the <see cref="DeleteProcThreadAttributeList"/> function.
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
        /// A pointer to the attribute value. This value should persist until the attribute is destroyed using the <see cref="DeleteProcThreadAttributeList"/> function.
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
            IntPtr lpValue,
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
        public static extern void DeleteProcThreadAttributeList(
            IntPtr lpAttributeList);

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
        /// The most commonly used values are <see cref="FileAccess.GENERIC_READ"/>, <see cref="FileAccess.GENERIC_WRITE"/>, or both(<see cref="FileAccess.GENERIC_READ"/> | <see cref="FileAccess.GENERIC_WRITE"/>). For more information, see Generic Access Rights, File Security and Access Rights, File Access Rights Constants, and ACCESS_MASK.
        /// If this parameter is zero, the application can query certain metadata such as file, directory, or device attributes without accessing that file or device, even if <see cref="FileAccess.GENERIC_READ"/> access would have been denied.
        /// You cannot request an access mode that conflicts with the sharing mode that is specified by the dwShareMode parameter in an open request that already has an open handle.
        /// For more information, see the Remarks section of this topic and Creating and Opening Files.
        /// </param>
        /// <param name="share">
        /// The requested sharing mode of the file or device, which can be read, write, both, delete, all of these, or none (refer to the following table). Access requests to attributes or extended attributes are not affected by this flag.
        /// If this parameter is zero and <see cref="CreateFile"/> succeeds, the file or device cannot be shared and cannot be opened again until the handle to the file or device is closed. For more information, see the Remarks section.
        /// You cannot request a sharing mode that conflicts with the access mode that is specified in an existing request that has an open handle. <see cref="CreateFile"/> would fail and the <see cref="GetLastError"/> function would return ERROR_SHARING_VIOLATION.
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
        /// A valid handle to a template file with the <see cref="FileAccess.GENERIC_READ"/> access right. The template file supplies file attributes and extended attributes for the file that is being created.
        /// This parameter can be NULL.
        /// When opening an existing file, CreateFile ignores this parameter.
        /// When opening a new encrypted file, the file inherits the discretionary access control list from its parent directory.For additional information, see File Encryption.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is an open handle to the specified file, device, named pipe, or mail slot.
        /// If the function fails, the return value is INVALID_HANDLE_VALUE.To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        [DllImport(api_ms_win_core_file_l1_2_0, CharSet = CharSet.Auto, SetLastError = true)]
        public static extern SafeObjectHandle CreateFile(
            string filename,
            FileAccess access,
            FileShare share,
            SECURITY_ATTRIBUTES securityAttributes,
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
        /// <see cref="QueryFullProcessImageName(SafeObjectHandle,QueryFullProcessImageNameFlags,StringBuilder,ref int)" />
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
        public static extern bool Process32First(SafeObjectHandle hSnapshot, [In, Out] PROCESSENTRY32 lppe);

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
        /// <see cref="Process32First(SafeObjectHandle,PROCESSENTRY32)" />
        /// function.
        /// </remarks>
        [DllImport(nameof(Kernel32), SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern bool Process32Next(
            SafeObjectHandle hSnapshot,
            [In, Out] PROCESSENTRY32 lppe);

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
        public static extern bool QueryFullProcessImageName(
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
            ProcessAccess dwDesiredAccess,
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
        public static extern bool CreatePipe(
            out SafeObjectHandle hReadPipe,
            out SafeObjectHandle hWritePipe,
            SECURITY_ATTRIBUTES lpPipeAttributes,
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
        ///     If the function succeeds, the return value is a nonzero value.
        ///     <para>
        ///         If the function fails, the return value is zero. To get extended error information, call
        ///         <see cref="GetLastError" />.
        ///     </para>
        /// </returns>
        [DllImport(nameof(Kernel32), SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern SafeLibraryHandle LoadLibrary(string lpFileName);

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
        public static extern SafeObjectHandle CreateNamedPipe(
            string lpName,
            PipeAccessMode dwOpenMode,
            PipeMode dwPipeMode,
            int nMaxInstances,
            int nOutBufferSize,
            int nInBufferSize,
            int nDefaultTimeOut,
            SECURITY_ATTRIBUTES lpSecurityAttributes);

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
        ///         If the function succeeds, the process should use the <see cref="CreateFile" /> function to open a handle to
        ///         the named pipe. A return value of TRUE indicates that there is at least one instance of the pipe available. A
        ///         subsequent <see cref="CreateFile" /> call to the pipe can fail, because the instance was closed by the server
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
        public static extern bool GetNamedPipeClientComputerName(
            SafeObjectHandle Pipe,
            StringBuilder ClientComputerName,
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
        public static extern bool GetNamedPipeHandleState(
            SafeObjectHandle hNamedPipe,
            out PipeMode lpState,
            [In, Out] NullableUInt32 lpCurInstances,
            [In, Out] NullableUInt32 lpMaxCollectionCount,
            [In, Out] NullableUInt32 lpCollectDataTimeout,
            StringBuilder lpUserName,
            int nMaxUserNameSize);

        /// <summary>Retrieves information about the specified named pipe.</summary>
        /// <param name="hNamedPipe">
        ///     A handle to the named pipe instance. The handle must have GENERIC_READ access to the named
        ///     pipe for a read-only or read/write pipe, or it must have GENERIC_WRITE and FILE_READ_ATTRIBUTES access for a
        ///     write-only pipe.
        ///     <para>
        ///         This parameter can also be a handle to an anonymous pipe, as returned by the <see cref="CreatePipe" />
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
        ///     <see cref="CreateNamedPipe" /> function.
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
        ///     <see cref="CreateNamedPipe" /> function.
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
        ///     the <see cref="CreateNamedPipe" /> or <see cref="CreateFile" /> function, or it can be a handle to the read end of
        ///     an anonymous pipe, as returned by the <see cref="CreatePipe" /> function. The handle must have GENERIC_READ access
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
        ///     pipe, as returned by the <see cref="CreateNamedPipe" /> function, or to the client end of the pipe, as returned by
        ///     the <see cref="CreateFile" /> function. The handle must have GENERIC_WRITE access to the named pipe for a
        ///     write-only or read/write pipe, or it must have GENERIC_READ and FILE_WRITE_ATTRIBUTES access for a read-only pipe.
        ///     <para>
        ///         This parameter can also be a handle to an anonymous pipe, as returned by the <see cref="CreatePipe" />
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
        public static extern bool SetNamedPipeHandleState(
            SafeObjectHandle hNamedPipe,
            NullablePipeMode lpMode,
            NullableUInt32 lpMaxCollectionCount,
            NullableUInt32 lpCollectDataTimeout);

        /// <summary>
        ///     Combines the functions that write a message to and read a message from the specified named pipe into a single
        ///     network operation.
        /// </summary>
        /// <param name="hNamedPipe">
        ///     A handle to the named pipe returned by the <see cref="CreateNamedPipe" /> or
        ///     <see cref="CreateFile" /> function.
        ///     <para>
        ///         This parameter can also be a handle to an anonymous pipe, as returned by the <see cref="CreatePipe" />
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
        ///         <see cref="ReadFile(SafeObjectHandle,void*,int,NullableUInt32,OVERLAPPED*)" />, ReadFileEx, or PeekNamedPipe.
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
        ///     Frees the loaded dynamic-link library (DLL) module and, if necessary, decrements its reference count. When the
        ///     reference count reaches zero, the module is unloaded from the address space of the calling process and the handle
        ///     is no longer valid.
        /// </summary>
        /// <param name="hModule">
        ///     A handle to the loaded library module. The LoadLibrary, LoadLibraryEx, GetModuleHandle, or
        ///     GetModuleHandleEx function returns this handle.
        /// </param>
        /// <returns>
        ///     If the function succeeds, the return value is a nonzero value.
        ///     <para>
        ///         If the function fails, the return value is zero. To get extended error information, call
        ///         <see cref="GetLastError" />.
        ///     </para>
        /// </returns>
        [DllImport(api_ms_win_core_libraryloader_l1_1_1, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool FreeLibrary(IntPtr hModule);
    }
}
