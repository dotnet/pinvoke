// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Runtime.InteropServices;
    using System.Text;
    using FILETIME = System.Runtime.InteropServices.ComTypes.FILETIME;
	using static Kernel32;
	public class Kernel32Mockable : IKernel32Mockable {
        /// <summary>
        /// Searches a directory for a file or subdirectory with a name and attributes that match those specified.
        /// For the most basic version of this function, see FindFirstFile.
        /// To perform this operation as a transacted operation, use the FindFirstFileTransacted function.
        /// </summary>
        /// <param name="lpFileName">
        /// The directory or path, and the file name, which can include wildcard characters, for example, an asterisk (*) or a question mark (?).
        /// This parameter should not be NULL, an invalid string (for example, an empty string or a string that is missing the terminating null character), or end in a trailing backslash (\).
        /// If the string ends with a wildcard, period, or directory name, the user must have access to the root and all subdirectories on the path.
        /// In the ANSI version of this function, the name is limited to MAX_PATH characters. To extend this limit to approximately 32,000 wide characters, call the Unicode version of the function and prepend "\\?\" to the path. For more information, see Naming a File.
        /// </param>
        /// <param name="fInfoLevelId">
        /// The information level of the returned data.
        /// This parameter is one of the <see cref="FINDEX_INFO_LEVELS"/> enumeration values.
        /// </param>
        /// <param name="lpFindFileData">
        /// A pointer to the buffer that receives the file data.
        /// The pointer type is determined by the level of information that is specified in the <paramref name="fInfoLevelId"/> parameter.
        /// </param>
        /// <param name="fSearchOp">
        /// The type of filtering to perform that is different from wildcard matching.
        /// This parameter is one of the <see cref="FINDEX_SEARCH_OPS"/> enumeration values.
        /// </param>
        /// <param name="lpSearchFilter">
        /// A pointer to the search criteria if the specified <paramref name="fSearchOp"/> needs structured search information.
        /// At this time, none of the supported fSearchOp values require extended search information. Therefore, this pointer must be NULL.
        /// </param>
        /// <param name="dwAdditionalFlags">Specifies additional flags that control the search.</param>
        /// <returns>
        /// If the function succeeds, the return value is a search handle used in a subsequent call to FindNextFile or FindClose, and the lpFindFileData parameter contains information about the first file or directory found.
        /// If the function fails or fails to locate files from the search string in the lpFileName parameter, the return value is INVALID_HANDLE_VALUE and the contents of lpFindFileData are indeterminate.To get extended error information, call the <see cref="GetLastError"/> function.
        /// </returns>
        public SafeFindFilesHandle InvokeFindFirstFileEx(string lpFileName, FINDEX_INFO_LEVELS fInfoLevelId, out WIN32_FIND_DATA lpFindFileData, FINDEX_SEARCH_OPS fSearchOp, IntPtr lpSearchFilter, FindFirstFileExFlags dwAdditionalFlags)
			=> FindFirstFileEx(lpFileName, fInfoLevelId, out lpFindFileData, fSearchOp, lpSearchFilter, dwAdditionalFlags);
	
        /// <summary>
        /// Formats a message string. The function requires a message definition as input. The message definition can come from a buffer passed into the function. It can come from a message table resource in an already-loaded module. Or the caller can ask the function to search the system's message table resource(s) for the message definition. The function finds the message definition in a message table resource based on a message identifier and a language identifier. The function copies the formatted message text to an output buffer, processing any embedded insert sequences if requested.
        /// </summary>
        /// <param name="dwFlags">
        /// The formatting options, and how to interpret the lpSource parameter. The low-order byte of dwFlags specifies how the function handles line breaks in the output buffer. The low-order byte can also specify the maximum width of a formatted output line.
        /// </param>
        /// <param name="lpSource">
        /// The location of the message definition. The type of this parameter depends upon the settings in the <paramref name="dwFlags"/> parameter.
        /// If <see cref="FormatMessageFlags.FromHModule"/>: A handle to the module that contains the message table to search.
        /// If <see cref="FormatMessageFlags.FromString"/>: Pointer to a string that consists of unformatted message text. It will be scanned for inserts and formatted accordingly.
        /// If neither of these flags is set in dwFlags, then lpSource is ignored.
        /// </param>
        /// <param name="dwMessageId">
        /// The message identifier for the requested message. This parameter is ignored if dwFlags includes <see cref="FormatMessageFlags.FromString" />.
        /// </param>
        /// <param name="dwLanguageId">
        /// The language identifier for the requested message. This parameter is ignored if dwFlags includes <see cref="FormatMessageFlags.FromString"/>.
        /// If you pass a specific LANGID in this parameter, FormatMessage will return a message for that LANGID only.If the function cannot find a message for that LANGID, it sets Last-Error to ERROR_RESOURCE_LANG_NOT_FOUND.If you pass in zero, FormatMessage looks for a message for LANGIDs in the following order:
        /// Language neutral
        /// Thread LANGID, based on the thread's locale value
        /// User default LANGID, based on the user's default locale value
        /// System default LANGID, based on the system default locale value
        /// US English
        /// If FormatMessage does not locate a message for any of the preceding LANGIDs, it returns any language message string that is present.If that fails, it returns ERROR_RESOURCE_LANG_NOT_FOUND.
        /// </param>
        /// <param name="lpBuffer">
        /// A pointer to a buffer that receives the null-terminated string that specifies the formatted message. If dwFlags includes <see cref="FormatMessageFlags.AllocateBuffer" />, the function allocates a buffer using the LocalAlloc function, and places the pointer to the buffer at the address specified in lpBuffer.
        /// This buffer cannot be larger than 64K bytes.
        /// </param>
        /// <param name="nSize">
        /// If the <see cref="FormatMessageFlags.AllocateBuffer"/> flag is not set, this parameter specifies the size of the output buffer, in TCHARs. If <see cref="FormatMessageFlags.AllocateBuffer"/> is set,
        /// this parameter specifies the minimum number of TCHARs to allocate for an output buffer.
        /// The output buffer cannot be larger than 64K bytes.
        /// </param>
        /// <param name="Arguments">
        /// An array of values that are used as insert values in the formatted message. A %1 in the format string indicates the first value in the Arguments array; a %2 indicates the second argument; and so on.
        /// The interpretation of each value depends on the formatting information associated with the insert in the message definition.The default is to treat each value as a pointer to a null-terminated string.
        /// By default, the Arguments parameter is of type va_list*, which is a language- and implementation-specific data type for describing a variable number of arguments.The state of the va_list argument is undefined upon return from the function.To use the va_list again, destroy the variable argument list pointer using va_end and reinitialize it with va_start.
        /// If you do not have a pointer of type va_list*, then specify the FORMAT_MESSAGE_ARGUMENT_ARRAY flag and pass a pointer to an array of DWORD_PTR values; those values are input to the message formatted as the insert values.Each insert must have a corresponding element in the array.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is the number of TCHARs stored in the output buffer, excluding the terminating null character.
        /// If the function fails, the return value is zero.To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        public int InvokeFormatMessage(FormatMessageFlags dwFlags, IntPtr lpSource, uint dwMessageId, uint dwLanguageId, StringBuilder lpBuffer, int nSize, IntPtr[] Arguments)
			=> FormatMessage(dwFlags, lpSource, dwMessageId, dwLanguageId, lpBuffer, nSize, Arguments);
	
        /// <summary>
        /// Retrieves the thread identifier of the calling thread.
        /// </summary>
        /// <returns>The thread identifier of the calling thread.</returns>
        public uint InvokeGetCurrentThreadId()
			=> GetCurrentThreadId();
	
        /// <summary>Retrieves the process identifier of the calling process.</summary>
        /// <returns>The process identifier of the calling process.</returns>
        /// <remarks>Until the process terminates, the process identifier uniquely identifies the process throughout the system.</remarks>
        public uint InvokeGetCurrentProcessId()
			=> GetCurrentProcessId();
	
        /// <summary>Retrieves a pseudo handle for the current process.</summary>
        /// <returns>The return value is a pseudo handle to the current process.</returns>
        /// <remarks>
        ///     A pseudo handle is a special constant, currently (HANDLE)-1, that is interpreted as the current process handle. For
        ///     compatibility with future operating systems, it is best to call GetCurrentProcess instead of hard-coding this
        ///     constant value. The calling process can use a pseudo handle to specify its own process whenever a process handle is
        ///     required. Pseudo handles are not inherited by child processes.
        ///     <para>This handle has the PROCESS_ALL_ACCESS access right to the process object.</para>
        ///     <para>
        ///         Windows Server 2003 and Windows XP:  This handle has the maximum access allowed by the security descriptor of
        ///         the process to the primary token of the process.
        ///     </para>
        ///     <para>
        ///         A process can create a "real" handle to itself that is valid in the context of other processes, or that can
        ///         be inherited by other processes, by specifying the pseudo handle as the source handle in a call to the
        ///         DuplicateHandle function. A process can also use the OpenProcess function to open a real handle to itself.
        ///     </para>
        ///     <para>
        ///         The pseudo handle need not be closed when it is no longer needed. Calling the <see cref="CloseHandle" />
        ///         function with a pseudo handle has no effect.If the pseudo handle is duplicated by DuplicateHandle, the
        ///         duplicate handle must be closed.
        ///     </para>
        /// </remarks>
        public SafeObjectHandle InvokeGetCurrentProcess()
			=> GetCurrentProcess();
	
        /// <summary>
        ///     Marks any outstanding I/O operations for the specified file handle. The function only cancels I/O operations
        ///     in the current process, regardless of which thread created the I/O operation.
        /// </summary>
        /// <param name="hFile">A handle to the file.</param>
        /// <param name="lpOverlapped">
        ///     A pointer to an <see cref="OVERLAPPED" /> data structure that contains the data used for asynchronous I/O.
        ///     <para>If this parameter is NULL, all I/O requests for the hFile parameter are canceled.</para>
        ///     <para>
        ///         If this parameter is not NULL, only those specific I/O requests that were issued for the file with the
        ///         specified
        ///         <paramref name="lpOverlapped" /> overlapped structure are marked as canceled, meaning that you can cancel one
        ///         or more requests, while the CancelIo function cancels all outstanding requests on a file handle.
        ///     </para>
        /// </param>
        /// <returns>
        ///     If the function succeeds, the return value is nonzero. The cancel operation for all pending I/O operations issued
        ///     by the calling process for the specified file handle was successfully requested. The application must not free or
        ///     reuse the <see cref="OVERLAPPED" /> structure associated with the canceled I/O operations until they have
        ///     completed. The thread can use the GetOverlappedResult function to determine when the I/O operations themselves have
        ///     been completed.
        ///     <para>
        ///         If the function fails, the return value is 0 (zero). To get extended error information, call the
        ///         <see cref="GetLastError" /> function.
        ///     </para>
        ///     <para>
        ///         If this function cannot find a request to cancel, the return value is 0 (zero), and
        ///         <see cref="GetLastError" />
        ///         returns <see cref="Win32ErrorCode.ERROR_NOT_FOUND" />.
        ///     </para>
        /// </returns>
        unsafe public bool InvokeCancelIoEx(
            SafeObjectHandle hFile,
            OVERLAPPED* lpOverlapped)
			=> CancelIoEx(hFile, lpOverlapped);
	
        /// <summary>
        ///     Reads data from the specified file or input/output (I/O) device. Reads occur at the position specified by the file
        ///     pointer if supported by the device.
        ///     <para>
        ///         This function is designed for both synchronous and asynchronous operations. For a similar function designed
        ///         solely for asynchronous operation, see ReadFileEx.
        ///     </para>
        /// </summary>
        /// <param name="hFile">
        ///     A handle to the device (for example, a file, file stream, physical disk, volume, console buffer, tape drive,
        ///     socket, communications resource, mailslot, or pipe).
        ///     <para>The hFile parameter must have been created with read access.</para>
        ///     <para>
        ///         For asynchronous read operations, hFile can be any handle that is opened with the FILE_FLAG_OVERLAPPED flag
        ///         by the CreateFile function, or a socket handle returned by the socket or accept function.
        ///     </para>
        /// </param>
        /// <param name="lpBuffer">
        ///     A pointer to the buffer that receives the data read from a file or device.
        ///     <para>
        ///         This buffer must remain valid for the duration of the read operation. The caller must not use this buffer
        ///         until the read operation is completed.
        ///     </para>
        /// </param>
        /// <param name="nNumberOfBytesToRead">The maximum number of bytes to be read.</param>
        /// <param name="lpNumberOfBytesRead">
        ///     A pointer to the variable that receives the number of bytes read when using a synchronous hFile parameter. ReadFile
        ///     sets this value to zero before doing any work or error checking. Use <see langword="null" /> for this parameter if
        ///     this is an asynchronous operation to avoid potentially erroneous results.
        ///     <para>
        ///         This parameter can be <see langword="null" /> only when the <paramref name="lpOverlapped" /> parameter is not
        ///         <see langword="null" />.
        ///     </para>
        /// </param>
        /// <param name="lpOverlapped">
        ///     A pointer to an <see cref="OVERLAPPED" /> structure is required if the hFile parameter was opened with
        ///     FILE_FLAG_OVERLAPPED, otherwise it can be <see langword="null" />.
        ///     <para>
        ///         If hFile is opened with FILE_FLAG_OVERLAPPED, the <paramref name="lpOverlapped" /> parameter must point to a
        ///         valid and unique <see cref="OVERLAPPED" /> structure, otherwise the function can incorrectly report that the
        ///         read operation is complete.
        ///     </para>
        ///     <para>
        ///         For an hFile that supports byte offsets, if you use this parameter you must specify a byte offset at which to
        ///         start reading from the file or device. This offset is specified by setting the Offset and OffsetHigh members of
        ///         the <see cref="OVERLAPPED" /> structure. For an hFile that does not support byte offsets, Offset and OffsetHigh
        ///         are ignored.
        ///     </para>
        /// </param>
        /// <returns>
        ///     If the function succeeds, the return value is <see langword="true" />.
        ///     <para>
        ///         If the function fails, or is completing asynchronously, the return value is <see langword="false" />. To get
        ///         extended error information, call the GetLastError function.
        ///     </para>
        ///     <para>
        ///         Note: The <see cref="GetLastError" /> code <see cref="Win32ErrorCode.ERROR_IO_PENDING" /> is not a failure;
        ///         it designates the read operation is pending completion asynchronously.
        ///     </para>
        /// </returns>
        unsafe public bool InvokeReadFile(
            SafeObjectHandle hFile,
            void* lpBuffer,
            uint nNumberOfBytesToRead,
            NullableUInt32 lpNumberOfBytesRead,
            OVERLAPPED* lpOverlapped)
			=> ReadFile(hFile, lpBuffer, nNumberOfBytesToRead, lpNumberOfBytesRead, lpOverlapped);
	
        /// <summary>
        ///     Writes data to the specified file or input/output (I/O) device.
        ///     <para>
        ///         This function is designed for both synchronous and asynchronous operation. For a similar function designed
        ///         solely for asynchronous operation, see WriteFileEx.
        ///     </para>
        /// </summary>
        /// <param name="hFile">
        ///     A handle to the file or I/O device (for example, a file, file stream, physical disk, volume, console buffer, tape
        ///     drive, socket, communications resource, mailslot, or pipe).
        ///     <para>
        ///         The hFile parameter must have been created with the write access. For more information, see Generic Access
        ///         Rights and File Security and Access Rights.
        ///     </para>
        ///     <para>
        ///         For asynchronous write operations, hFile can be any handle opened with the CreateFile function using the
        ///         FILE_FLAG_OVERLAPPED flag or a socket handle returned by the socket or accept function.
        ///     </para>
        /// </param>
        /// <param name="lpBuffer">
        ///     A pointer to the buffer containing the data to be written to the file or device.
        ///     <para>
        ///         This buffer must remain valid for the duration of the write operation. The caller must not use this buffer
        ///         until the write operation is completed.
        ///     </para>
        /// </param>
        /// <param name="nNumberOfBytesToWrite">
        ///     The number of bytes to be written to the file or device.
        ///     <para>
        ///         A value of zero specifies a null write operation. The behavior of a null write operation depends on the
        ///         underlying file system or communications technology.
        ///     </para>
        /// </param>
        /// <param name="lpNumberOfBytesWritten">
        ///     A pointer to the variable that receives the number of bytes written when using a synchronous hFile parameter.
        ///     WriteFile sets this value to zero before doing any work or error checking. Use <see langword="null" />
        ///     for this parameter if this is an asynchronous operation to avoid potentially erroneous results.
        ///     <para>
        ///         This parameter can be NULL only when the <paramref name="lpOverlapped" /> parameter is not
        ///         <see langword="null" />.
        ///     </para>
        /// </param>
        /// <param name="lpOverlapped">
        ///     A pointer to an <see cref="OVERLAPPED" /> structure is required if the hFile parameter was opened with
        ///     FILE_FLAG_OVERLAPPED, otherwise this parameter can be NULL.
        ///     <para>
        ///         For an hFile that supports byte offsets, if you use this parameter you must specify a byte offset at which to
        ///         start writing to the file or device. This offset is specified by setting the Offset and OffsetHigh members of
        ///         the <see cref="OVERLAPPED" /> structure. For an hFile that does not support byte offsets, Offset and OffsetHigh
        ///         are ignored.
        ///     </para>
        ///     <para>
        ///         To write to the end of file, specify both the Offset and OffsetHigh members of the <see cref="OVERLAPPED" />
        ///         structure as 0xFFFFFFFF. This is functionally equivalent to previously calling the CreateFile function to open
        ///         hFile using FILE_APPEND_DATA access.
        ///     </para>
        /// </param>
        /// <returns>
        ///     If the function succeeds, the return value is <see langword="true" />.
        ///     <para>
        ///         If the function fails, or is completing asynchronously, the return value is <see langword="false" />. To get
        ///         extended error information, call the GetLastError function.
        ///     </para>
        ///     <para>
        ///         Note: The <see cref="GetLastError" /> code <see cref="Win32ErrorCode.ERROR_IO_PENDING" /> is not a failure;
        ///         it designates the write operation is pending completion asynchronously.
        ///     </para>
        /// </returns>
        unsafe public bool InvokeWriteFile(
            SafeObjectHandle hFile,
            void* lpBuffer,
            uint nNumberOfBytesToWrite,
            NullableUInt32 lpNumberOfBytesWritten,
            OVERLAPPED* lpOverlapped)
			=> WriteFile(hFile, lpBuffer, nNumberOfBytesToWrite, lpNumberOfBytesWritten, lpOverlapped);
	
        /// <summary>
        /// Suspends the specified thread.
        /// A 64-bit application can suspend a WOW64 thread using the <see cref="Wow64SuspendThread"/> function.
        /// </summary>
        /// <param name="hThread">
        /// A handle to the thread that is to be suspended.
        /// The handle must have the THREAD_SUSPEND_RESUME access right. For more information, see Thread Security and Access Rights.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is the thread's previous suspend count; otherwise, it is (DWORD) -1. To get extended error information, use the <see cref="GetLastError"/> function.
        /// </returns>
        public int InvokeSuspendThread(SafeObjectHandle hThread)
			=> SuspendThread(hThread);
	
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
        public int InvokeWow64SuspendThread(SafeObjectHandle hThread)
			=> Wow64SuspendThread(hThread);
	
        /// <summary>
        /// Decrements a thread's suspend count. When the suspend count is decremented to zero, the execution of the thread is resumed.
        /// </summary>
        /// <param name="hThread">
        /// A handle to the thread to be restarted.
        /// This handle must have the THREAD_SUSPEND_RESUME access right. For more information, see Thread Security and Access Rights.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is the thread's previous suspend count.
        /// If the function fails, the return value is (DWORD) -1. To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        public int InvokeResumeThread(SafeObjectHandle hThread)
			=> ResumeThread(hThread);
	
        /// <summary>
        /// Waits until the specified object is in the signaled state or the time-out interval elapses.
        /// To enter an alertable wait state, use the WaitForSingleObjectEx function. To wait for multiple objects, use WaitForMultipleObjects.
        /// </summary>
        /// <param name="hHandle">
        /// A handle to the object. For a list of the object types whose handles can be specified, see the following Remarks section.
        /// If this handle is closed while the wait is still pending, the function's behavior is undefined.
        /// The handle must have the SYNCHRONIZE access right. For more information, see Standard Access Rights.
        /// </param>
        /// <param name="dwMilliseconds">
        /// The time-out interval, in milliseconds. If a nonzero value is specified, the function waits until the object is signaled or the interval elapses. If dwMilliseconds is zero, the function does not enter a wait state if the object is not signaled; it always returns immediately. If dwMilliseconds is INFINITE, the function will return only when the object is signaled.
        /// See MSDN docs for more information.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value indicates the event that caused the function to return. It can be one of the following values.
        /// </returns>
        public WaitForSingleObjectResult InvokeWaitForSingleObject(
            SafeHandle hHandle,
            uint dwMilliseconds)
			=> WaitForSingleObject(hHandle, dwMilliseconds);
	
        /// <summary>
        /// Closes an open object handle.
        /// </summary>
        /// <param name="hObject">A valid handle to an open object.</param>
        /// <returns>
        /// If the function succeeds, the return value is nonzero.
        /// If the function fails, the return value is zero.To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        public bool InvokeCloseHandle(IntPtr hObject)
			=> CloseHandle(hObject);
	        /// <summary>
        /// Creates a new process and its primary thread. The new process runs in the security context of the calling process.
        /// If the calling process is impersonating another user, the new process uses the token for the calling process, not the impersonation token. To run the new process in the security context of the user represented by the impersonation token, use the <see cref="CreateProcessAsUser"/> or CreateProcessWithLogonW function.
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
        public bool InvokeCreateProcess(
            string lpApplicationName,
            string lpCommandLine,
            SECURITY_ATTRIBUTES lpProcessAttributes,
            SECURITY_ATTRIBUTES lpThreadAttributes,
            [MarshalAs(UnmanagedType.Bool)] bool bInheritHandles,
            CreateProcessFlags dwCreationFlags,
            IntPtr lpEnvironment, // IntPtr because it may point to unicode or ANSI characters, based on a flag.
            string lpCurrentDirectory,
            ref STARTUPINFO lpStartupInfo,
            out PROCESS_INFORMATION lpProcessInformation)
			=> CreateProcess(lpApplicationName, lpCommandLine, lpProcessAttributes, lpThreadAttributes, bInheritHandles, dwCreationFlags, lpEnvironment, lpCurrentDirectory, ref lpStartupInfo, out lpProcessInformation);
	
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
        public bool InvokeCreateProcessAsUser(
            IntPtr hToken,
            string lpApplicationName,
            string lpCommandLine,
            SECURITY_ATTRIBUTES lpProcessAttributes,
            SECURITY_ATTRIBUTES lpThreadAttributes,
            [MarshalAs(UnmanagedType.Bool)] bool bInheritHandles,
            CreateProcessFlags dwCreationFlags,
            IntPtr lpEnvironment, // IntPtr because it may point to unicode or ANSI characters, based on a flag.
            string lpCurrentDirectory,
            ref STARTUPINFO lpStartupInfo,
            out PROCESS_INFORMATION lpProcessInformation)
			=> CreateProcessAsUser(hToken, lpApplicationName, lpCommandLine, lpProcessAttributes, lpThreadAttributes, bInheritHandles, dwCreationFlags, lpEnvironment, lpCurrentDirectory, ref lpStartupInfo, out lpProcessInformation);
	
        /// <summary>
        /// Retrieves the contents of the <see cref="STARTUPINFO"/> structure that was specified when the calling process was created.
        /// </summary>
        /// <param name="lpStartupInfo">
        /// A pointer to a <see cref="STARTUPINFO"/> structure that receives the startup information.
        /// </param>
        /// <remarks>
        /// This function does not return a value, and does not fail.
        /// </remarks>
        public void InvokeGetStartupInfo(
            out STARTUPINFO lpStartupInfo)
			=> GetStartupInfo(out lpStartupInfo);
	
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
        /// To add attributes to the list, call the <see cref="UpdateProcThreadAttribute"/> function. To specify these attributes when creating a process, specify <see cref="CreateProcessFlags.EXTENDED_STARTUPINFO_PRESENT"/> in the dwCreationFlag parameter and a <see cref="STARTUPINFOEX"/> structure in the lpStartupInfo parameter. Note that you can specify the same <see cref="STARTUPINFOEX"/> structure to multiple child processes.
        /// When you have finished using the list, call the <see cref="DeleteProcThreadAttributeList"/> function.
        /// </remarks>
        public bool InvokeInitializeProcThreadAttributeList(
            IntPtr lpAttributeList,
            uint dwAttributeCount,
            uint dwFlags,
            ref IntPtr lpSize)
			=> InitializeProcThreadAttributeList(lpAttributeList, dwAttributeCount, dwFlags, ref lpSize);
	
        /// <summary>
        /// Updates the specified attribute in a list of attributes for process and thread creation.
        /// </summary>
        /// <param name="lpAttributeList">
        /// A pointer to an attribute list created by the <see cref="InitializeProcThreadAttributeList"/> function.
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
        public bool InvokeUpdateProcThreadAttribute(
            IntPtr lpAttributeList,
            uint dwFlags,
            ref uint Attribute,
            IntPtr lpValue,
            IntPtr cbSize, // SIZE_T varies by bitness
            ref IntPtr lpPreviousValue,
            ref IntPtr lpReturnSize)
			=> UpdateProcThreadAttribute(lpAttributeList, dwFlags, ref Attribute, lpValue, cbSize, ref lpPreviousValue, ref lpReturnSize);
	
        /// <summary>
        /// Deletes the specified list of attributes for process and thread creation.
        /// </summary>
        /// <param name="lpAttributeList">
        /// The attribute list. This list is created by the <see cref="InitializeProcThreadAttributeList"/> function.
        /// </param>
        public void InvokeDeleteProcThreadAttributeList(
            IntPtr lpAttributeList)
			=> DeleteProcThreadAttributeList(lpAttributeList);
	
        /// <summary>
        /// Allocates a new console for the calling process.
        /// </summary>
        /// <returns>
        /// If the function succeeds, the return value is nonzero.
        /// If the function fails, the return value is zero. To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        public bool InvokeAllocConsole()
			=> AllocConsole();
	
        /// <summary>
        /// Detaches the calling process from its console.
        /// </summary>
        /// <returns>
        /// If the function succeeds, the return value is nonzero.
        /// If the function fails, the return value is zero. To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        public bool InvokeFreeConsole()
			=> FreeConsole();
	
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
        public bool InvokeAttachConsole(uint dwProcessId)
			=> AttachConsole(dwProcessId);
	
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
        /// The most commonly used values are <see cref="FileAccess.GenericRead"/>, <see cref="FileAccess.GenericWrite"/>, or both(<see cref="FileAccess.GenericRead"/> | <see cref="FileAccess.GenericWrite"/>). For more information, see Generic Access Rights, File Security and Access Rights, File Access Rights Constants, and ACCESS_MASK.
        /// If this parameter is zero, the application can query certain metadata such as file, directory, or device attributes without accessing that file or device, even if <see cref="FileAccess.GenericRead"/> access would have been denied.
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
        /// For devices other than files, this parameter is usually set to <see cref="CreationDisposition.OpenExisting"/>.
        /// </param>
        /// <param name="flagsAndAttributes">
        /// The file or device attributes and flags, <see cref="CreateFileFlags.NormalAttribute"/> being the most common default value for files.
        /// This parameter can include any combination of the available file attributes (CreateFileFlags.*Attribute). All other file attributes override <see cref="CreateFileFlags.NormalAttribute"/>.
        /// This parameter can also contain combinations of flags (CreateFileFlags.*Flag) for control of file or device caching behavior, access modes, and other special-purpose flags. These combine with any CreateFileFlags.*Attribute values.
        /// This parameter can also contain Security Quality of Service (SQOS) information by specifying the SECURITY_SQOS_PRESENT flag. Additional SQOS-related flags information is presented in the table following the attributes and flags tables.
        /// Note When CreateFile opens an existing file, it generally combines the file flags with the file attributes of the existing file, and ignores any file attributes supplied as part of dwFlagsAndAttributes. Special cases are detailed in Creating and Opening Files.
        /// Some of the following file attributes and flags may only apply to files and not necessarily all other types of devices that CreateFile can open.For additional information, see the Remarks section of this topic and Creating and Opening Files.
        /// For more advanced access to file attributes, see SetFileAttributes. For a complete list of all file attributes with their values and descriptions, see File Attribute Constants.
        /// </param>
        /// <param name="templateFile">
        /// A valid handle to a template file with the <see cref="FileAccess.GenericRead"/> access right. The template file supplies file attributes and extended attributes for the file that is being created.
        /// This parameter can be NULL.
        /// When opening an existing file, CreateFile ignores this parameter.
        /// When opening a new encrypted file, the file inherits the discretionary access control list from its parent directory.For additional information, see File Encryption.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is an open handle to the specified file, device, named pipe, or mail slot.
        /// If the function fails, the return value is INVALID_HANDLE_VALUE.To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        public SafeObjectHandle InvokeCreateFile(
            string filename,
            FileAccess access,
            FileShare share,
            SECURITY_ATTRIBUTES securityAttributes,
            CreationDisposition creationDisposition,
            CreateFileFlags flagsAndAttributes,
            SafeObjectHandle templateFile)
			=> CreateFile(filename, access, share, securityAttributes, creationDisposition, flagsAndAttributes, templateFile);
	
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
        public SafeFindFilesHandle InvokeFindFirstFile(string lpFileName, out WIN32_FIND_DATA lpFindFileData)
			=> FindFirstFile(lpFileName, out lpFindFileData);
	
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
        public bool InvokeFindNextFile(SafeFindFilesHandle hFindFile, out WIN32_FIND_DATA lpFindFileData)
			=> FindNextFile(hFindFile, out lpFindFileData);
	
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
        /// <see cref="QueryFullProcessImageName(SafeObjectHandle,QueryFullProcessImageNameFlags,StringBuilder,ref uint)" />
        /// function to retrieve the full name of an executable image for both 32- and 64-bit processes from a 32-bit process.
        /// </para>
        /// </remarks>
        public SafeObjectHandle InvokeCreateToolhelp32Snapshot(
            CreateToolhelp32SnapshotFlags dwFlags,
            uint th32ProcessID)
			=> CreateToolhelp32Snapshot(dwFlags, th32ProcessID);
	
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
        public bool InvokeProcess32First(SafeObjectHandle hSnapshot, [In, Out] PROCESSENTRY32 lppe)
			=> Process32First(hSnapshot, lppe);
	
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
        public bool InvokeProcess32Next(
            SafeObjectHandle hSnapshot,
            [In, Out] PROCESSENTRY32 lppe)
			=> Process32Next(hSnapshot, lppe);
	
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
        public bool InvokeQueryFullProcessImageName(
            SafeObjectHandle hProcess,
            QueryFullProcessImageNameFlags dwFlags,
            StringBuilder lpExeName,
            ref uint lpdwSize)
			=> QueryFullProcessImageName(hProcess, dwFlags, lpExeName, ref lpdwSize);
	
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
        public SafeObjectHandle InvokeOpenProcess(
            ProcessAccess dwDesiredAccess,
            bool bInheritHandle,
            uint dwProcessId)
			=> OpenProcess(dwDesiredAccess, bInheritHandle, dwProcessId);
	
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
        unsafe public bool InvokeGetOverlappedResult(
            SafeObjectHandle hFile,
            OVERLAPPED* lpOverlapped,
            out uint lpNumberOfBytesTransferred,
            bool bWait)
			=> GetOverlappedResult(hFile, lpOverlapped, out lpNumberOfBytesTransferred, bWait);
	
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
        /// <see cref="GetOverlappedResult" /> function to determine when the I/O operations themselves have been completed.
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
        public bool InvokeCancelIo(SafeObjectHandle hFile)
			=> CancelIo(hFile);
	
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
        public bool InvokeIsWow64Process(SafeObjectHandle hProcess, out bool Wow64Process)
			=> IsWow64Process(hProcess, out Wow64Process);
	
        /// <summary>
        /// Creates an anonymous pipe, and returns handles to the read and write ends of the pipe.
        /// </summary>
        /// <param name="hReadPipe">
        /// A pointer to a variable that receives the read handle for the pipe.
        /// </param>
        /// <param name="hWritePipe">
        /// A pointer to a variable that receives the write handle for the pipe.
        /// </param>
        /// <param name="lpPipeAttributes">
        /// A pointer to a SECURITY_ATTRIBUTES structure that determines whether the returned handle can be inherited by child processes. If <paramref name="lpPipeAttributes"/> is NULL, the handle cannot be inherited.
        /// The <see cref="SECURITY_ATTRIBUTES.lpSecurityDescriptor"/> member of the structure specifies a security descriptor for the new pipe. If <paramref name="lpPipeAttributes"/> is NULL, the pipe gets a default security descriptor. The ACLs in the default security descriptor for a pipe come from the primary or impersonation token of the creator.
        /// </param>
        /// <param name="nSize">
        /// The size of the buffer for the pipe, in bytes. The size is only a suggestion; the system uses the value to calculate an appropriate buffering mechanism. If this parameter is zero, the system uses the default buffer size.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is nonzero.
        /// If the function fails, the return value is zero. To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        public bool InvokeCreatePipe(
            out SafeObjectHandle hReadPipe,
            out SafeObjectHandle hWritePipe,
            SECURITY_ATTRIBUTES lpPipeAttributes,
            uint nSize)
			=> CreatePipe(out hReadPipe, out hWritePipe, lpPipeAttributes, nSize);
	}
}
