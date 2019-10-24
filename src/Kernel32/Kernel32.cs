// Copyright (c) All contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PInvoke
{
    using System;
#if NETFRAMEWORK || NETSTANDARD2_0_ORLATER
    using System.Runtime.ConstrainedExecution;
#endif
    using System.Runtime.InteropServices;
    using System.Security;
    using System.Text;

    /// <summary>
    /// Exported functions from the Kernel32.dll Windows library.
    /// </summary>
    [OfferFriendlyOverloads]
    public static partial class Kernel32
    {
        /// <summary>
        /// The maximum length of a name for a process module.
        /// </summary>
        public const int MAX_MODULE_NAME32 = 255;

        /// <summary>
        /// The maximum length of file paths for most Win32 functions.
        /// </summary>
        public const int MAX_PATH = 260;

        /// <summary>
        /// Constant for invalid handle value
        /// </summary>
        public static readonly IntPtr INVALID_HANDLE_VALUE = new IntPtr(-1);

#pragma warning disable SA1303 // Const field names must begin with upper-case letter
#if APISets
        private const string api_ms_win_core_localization_l1_2_0 = ApiSets.api_ms_win_core_localization_l1_2_0;
        private const string api_ms_win_core_processthreads_l1_1_1 = ApiSets.api_ms_win_core_processthreads_l1_1_1;
        private const string api_ms_win_core_io_l1_1_1 = ApiSets.api_ms_win_core_io_l1_1_1;
        private const string api_ms_win_core_file_l1_2_0 = ApiSets.api_ms_win_core_file_l1_2_0;
        private const string api_ms_win_core_synch_l1_2_0 = ApiSets.api_ms_win_core_synch_l1_2_0;
        private const string api_ms_win_core_handle_l1_1_0 = ApiSets.api_ms_win_core_handle_l1_1_0;
        private const string api_ms_win_core_console_l1_1_0 = ApiSets.api_ms_win_core_console_l1_1_0;
        private const string api_ms_win_core_console_l2_1_0 = ApiSets.api_ms_win_core_console_l2_1_0;
        private const string api_ms_win_core_psapi_l1_1_0 = ApiSets.api_ms_win_core_psapi_l1_1_0;
        private const string api_ms_win_core_namedpipe_l1_2_0 = ApiSets.api_ms_win_core_namedpipe_l1_2_0;
        private const string api_ms_win_core_libraryloader_l1_1_1 = ApiSets.api_ms_win_core_libraryloader_l1_1_1;
        private const string api_ms_win_core_sysinfo_l1_2_1 = ApiSets.api_ms_win_core_sysinfo_l1_2_1;
        private const string api_ms_win_core_sysinfo_l1_2_0 = ApiSets.api_ms_win_core_sysinfo_l1_2_0;
        private const string api_ms_win_core_errorhandling_l1_1_1 = ApiSets.api_ms_win_core_errorhandling_l1_1_1;
#else
        private const string api_ms_win_core_localization_l1_2_0 = nameof(Kernel32);
        private const string api_ms_win_core_processthreads_l1_1_1 = nameof(Kernel32);
        private const string api_ms_win_core_io_l1_1_1 = nameof(Kernel32);
        private const string api_ms_win_core_file_l1_2_0 = nameof(Kernel32);
        private const string api_ms_win_core_synch_l1_2_0 = nameof(Kernel32);
        private const string api_ms_win_core_handle_l1_1_0 = nameof(Kernel32);
        private const string api_ms_win_core_console_l1_1_0 = nameof(Kernel32);
        private const string api_ms_win_core_console_l2_1_0 = nameof(Kernel32);
        private const string api_ms_win_core_psapi_l1_1_0 = nameof(Kernel32);
        private const string api_ms_win_core_namedpipe_l1_2_0 = nameof(Kernel32);
        private const string api_ms_win_core_libraryloader_l1_1_1 = nameof(Kernel32);
        private const string api_ms_win_core_sysinfo_l1_2_1 = nameof(Kernel32);
        private const string api_ms_win_core_sysinfo_l1_2_0 = nameof(Kernel32);
        private const string api_ms_win_core_errorhandling_l1_1_1 = nameof(Kernel32);
#endif
#pragma warning restore SA1303 // Const field names must begin with upper-case letter

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
        [DllImport(api_ms_win_core_file_l1_2_0, EntryPoint = "FindFirstFileExW", ExactSpelling = true, CharSet = CharSet.Unicode)]
        public static unsafe extern SafeFindFilesHandle FindFirstFileEx(string lpFileName, FINDEX_INFO_LEVELS fInfoLevelId, out WIN32_FIND_DATA lpFindFileData, FINDEX_SEARCH_OPS fSearchOp, void* lpSearchFilter, FindFirstFileExFlags dwAdditionalFlags);

        /// <summary>
        /// Formats a message string. The function requires a message definition as input. The message definition can come from a buffer passed into the function. It can come from a message table resource in an already-loaded module. Or the caller can ask the function to search the system's message table resource(s) for the message definition. The function finds the message definition in a message table resource based on a message identifier and a language identifier. The function copies the formatted message text to an output buffer, processing any embedded insert sequences if requested.
        /// </summary>
        /// <param name="dwFlags">
        /// The formatting options, and how to interpret the lpSource parameter. The low-order byte of dwFlags specifies how the function handles line breaks in the output buffer. The low-order byte can also specify the maximum width of a formatted output line.
        /// </param>
        /// <param name="lpSource">
        /// The location of the message definition. The type of this parameter depends upon the settings in the <paramref name="dwFlags"/> parameter.
        /// If <see cref="FormatMessageFlags.FORMAT_MESSAGE_FROM_HMODULE"/>: A handle to the module that contains the message table to search.
        /// If <see cref="FormatMessageFlags.FORMAT_MESSAGE_FROM_STRING"/>: Pointer to a string that consists of unformatted message text. It will be scanned for inserts and formatted accordingly.
        /// If neither of these flags is set in dwFlags, then lpSource is ignored.
        /// </param>
        /// <param name="dwMessageId">
        /// The message identifier for the requested message. This parameter is ignored if dwFlags includes <see cref="FormatMessageFlags.FORMAT_MESSAGE_FROM_STRING" />.
        /// </param>
        /// <param name="dwLanguageId">
        /// The language identifier for the requested message. This parameter is ignored if dwFlags includes <see cref="FormatMessageFlags.FORMAT_MESSAGE_FROM_STRING"/>.
        /// If you pass a specific LANGID in this parameter, FormatMessage will return a message for that LANGID only.If the function cannot find a message for that LANGID, it sets Last-Error to ERROR_RESOURCE_LANG_NOT_FOUND.If you pass in zero, FormatMessage looks for a message for LANGIDs in the following order:
        /// Language neutral
        /// Thread LANGID, based on the thread's locale value
        /// User default LANGID, based on the user's default locale value
        /// System default LANGID, based on the system default locale value
        /// US English
        /// If FormatMessage does not locate a message for any of the preceding LANGIDs, it returns any language message string that is present.If that fails, it returns ERROR_RESOURCE_LANG_NOT_FOUND.
        /// </param>
        /// <param name="lpBuffer">
        /// A pointer to a buffer that receives the null-terminated string that specifies the formatted message. If dwFlags includes <see cref="FormatMessageFlags.FORMAT_MESSAGE_ALLOCATE_BUFFER" />, the function allocates a buffer using the LocalAlloc function, and places the pointer to the buffer at the address specified in lpBuffer.
        /// This buffer cannot be larger than 64K bytes.
        /// </param>
        /// <param name="nSize">
        /// If the <see cref="FormatMessageFlags.FORMAT_MESSAGE_ALLOCATE_BUFFER"/> flag is not set, this parameter specifies the size of the output buffer, in TCHARs. If <see cref="FormatMessageFlags.FORMAT_MESSAGE_ALLOCATE_BUFFER"/> is set,
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
        /// If the function fails, the return value is zero. To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        [DllImport(api_ms_win_core_localization_l1_2_0, CharSet = CharSet.Unicode, EntryPoint = "FormatMessageW", ExactSpelling = true, SetLastError = true)]
        public static unsafe extern int FormatMessage(FormatMessageFlags dwFlags, void* lpSource, int dwMessageId, int dwLanguageId, StringBuilder lpBuffer, int nSize, IntPtr[] Arguments);

        /// <summary>
        /// Retrieves the thread identifier of the calling thread.
        /// </summary>
        /// <returns>The thread identifier of the calling thread.</returns>
        [DllImport(api_ms_win_core_processthreads_l1_1_1)]
        public static extern int GetCurrentThreadId();

        /// <summary>Retrieves the process identifier of the calling process.</summary>
        /// <returns>The process identifier of the calling process.</returns>
        /// <remarks>Until the process terminates, the process identifier uniquely identifies the process throughout the system.</remarks>
        [DllImport(api_ms_win_core_processthreads_l1_1_1)]
        public static extern int GetCurrentProcessId();

        /// <summary>
        /// Retrieves the process identifier of the specified process.
        /// </summary>
        /// <param name="Process">A handle to the process. The handle must have the PROCESS_QUERY_INFORMATION or PROCESS_QUERY_LIMITED_INFORMATION access right. For more information, see Process Security and Access Rights.</param>
        /// <returns>The process identifier of the specified process.</returns>
        [DllImport(api_ms_win_core_processthreads_l1_1_1)]
        public static extern int GetProcessId(IntPtr Process);

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
        [DllImport(api_ms_win_core_processthreads_l1_1_1)]
        public static extern SafeObjectHandle GetCurrentProcess();

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
        [DllImport(api_ms_win_core_io_l1_1_1, SetLastError = true)]
        public static extern unsafe bool CancelIoEx(
            SafeObjectHandle hFile,
            OVERLAPPED* lpOverlapped);

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
        [DllImport(api_ms_win_core_file_l1_2_0, SetLastError = true)]
        public static extern unsafe bool ReadFile(
            SafeObjectHandle hFile,
            void* lpBuffer,
            int nNumberOfBytesToRead,
            [Friendly(FriendlyFlags.Out | FriendlyFlags.Optional)] int* lpNumberOfBytesRead,
            OVERLAPPED* lpOverlapped);

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
        [DllImport(api_ms_win_core_file_l1_2_0, SetLastError = true)]
        public static extern unsafe bool WriteFile(
            SafeObjectHandle hFile,
            void* lpBuffer,
            int nNumberOfBytesToWrite,
            [Friendly(FriendlyFlags.Out | FriendlyFlags.Optional)] int* lpNumberOfBytesWritten,
            OVERLAPPED* lpOverlapped);

        /// <summary>
        /// Suspends the specified thread.
        /// A 64-bit application can suspend a WOW64 thread using the Wow64SuspendThread function (desktop only).
        /// </summary>
        /// <param name="hThread">
        /// A handle to the thread that is to be suspended.
        /// The handle must have the THREAD_SUSPEND_RESUME access right. For more information, see Thread Security and Access Rights.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is the thread's previous suspend count; otherwise, it is (DWORD) -1. To get extended error information, use the <see cref="GetLastError"/> function.
        /// </returns>
        [DllImport(api_ms_win_core_processthreads_l1_1_1, SetLastError = true)]
        public static extern int SuspendThread(SafeObjectHandle hThread);

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
        [DllImport(api_ms_win_core_processthreads_l1_1_1, SetLastError = true)]
        public static extern int ResumeThread(SafeObjectHandle hThread);

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
        [DllImport(api_ms_win_core_synch_l1_2_0, SetLastError = true)]
        public static extern WaitForSingleObjectResult WaitForSingleObject(
            SafeHandle hHandle,
            int dwMilliseconds);

        /// <summary>
        /// Closes an open object handle.
        /// </summary>
        /// <param name="hObject">A valid handle to an open object.</param>
        /// <returns>
        /// If the function succeeds, the return value is nonzero.
        /// If the function fails, the return value is zero.To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
#if NETFRAMEWORK || NETSTANDARD2_0_ORLATER
        [SuppressUnmanagedCodeSecurity]
        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
#endif
        [DllImport(api_ms_win_core_handle_l1_1_0, SetLastError = true)]
        public static extern bool CloseHandle(IntPtr hObject);

        /// <summary>
        /// Sets certain properties of an object handle.
        /// </summary>
        /// <param name="hObject">
        /// <para>
        /// A handle to an object whose information is to be set.
        /// </para>
        /// <para>
        /// You can specify a handle to one of the following types of objects: access token, console input buffer, console screen buffer, event, file, file mapping, job, mailslot, mutex, pipe, printer, process, registry key, semaphore, serial communication device, socket, thread, or waitable timer.
        /// </para>
        /// </param>
        /// <param name="dwMask">
        /// A mask that specifies the bit flags to be changed. Use the same constants shown in the description of <paramref name="dwFlags"/>.
        /// </param>
        /// <param name="dwFlags">
        /// Set of bit flags that specifies properties of the object handle. This parameter can be 0 or one or more of the values of <see cref="HandleFlags"/>.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero. To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// To set or clear the associated bit flag in <paramref name="dwFlags"/>, you must set a change mask bit flag in <paramref name="dwMask"/>.
        /// </remarks>
        [DllImport(api_ms_win_core_handle_l1_1_0, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetHandleInformation([In] SafeHandle hObject, HandleFlags dwMask, HandleFlags dwFlags);

        /// <summary>
        /// Retrieves certain properties of an object handle.
        /// </summary>
        /// <param name="hObject">
        /// <para>
        /// A handle to an object whose information is to be retrieved.
        /// </para>
        /// <para>
        /// You can specify a handle to one of the following types of objects: access token, console input buffer, console screen buffer, event, file, file mapping, job, mailslot, mutex, pipe, printer, process, registry key, semaphore, serial communication device, socket, thread, or waitable timer.
        /// </para>
        /// </param>
        /// <param name="lpdwFlags">
        /// A pointer to a variable that receives a set of bit flags that specify properties of the object handle or 0. The values are defined at <see cref="HandleFlags"/>.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero. To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        [DllImport(api_ms_win_core_handle_l1_1_0, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern unsafe bool GetHandleInformation([In] SafeHandle hObject, [Out] out HandleFlags* lpdwFlags);

        /// <summary>Flushes the buffers of a specified file and causes all buffered data to be written to a file.</summary>
        /// <param name="hFile">
        ///     A handle to the open file.
        ///     <para>
        ///         The file handle must have the GENERIC_WRITE access right. For more information, see File Security and Access
        ///         Rights.
        ///     </para>
        ///     <para>If hFile is a handle to a communications device, the function only flushes the transmit buffer.</para>
        ///     <para>
        ///         If hFile is a handle to the server end of a named pipe, the function does not return until the client has
        ///         read all buffered data from the pipe.
        ///     </para>
        /// </param>
        /// <returns>
        ///     If the function succeeds, the return value is nonzero.
        ///     <para>
        ///         If the function fails, the return value is zero. To get extended error information, call
        ///         <see cref="GetLastError" />.
        ///     </para>
        ///     <para>
        ///         The function fails if hFile is a handle to the console output. That is because the console output is not
        ///         buffered. The function returns FALSE, and <see cref="GetLastError" /> returns
        ///         <see cref="Win32ErrorCode.ERROR_INVALID_HANDLE" />.
        ///     </para>
        /// </returns>
        [DllImport(api_ms_win_core_file_l1_2_0, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool FlushFileBuffers(SafeObjectHandle hFile);

        /// <summary>
        /// Creates or opens a named or unnamed mutex object.
        /// </summary>
        /// <param name="lpMutexAttributes">
        /// A pointer to a <see cref="SECURITY_ATTRIBUTES"/> structure. If this parameter is NULL, the handle cannot be inherited by child processes.
        /// The <see cref="SECURITY_ATTRIBUTES.lpSecurityDescriptor"/> member of the structure specifies a security descriptor for the new mutex. If <paramref name="lpMutexAttributes"/> is NULL, the mutex gets a default security descriptor. The ACLs in the default security descriptor for a mutex come from the primary or impersonation token of the creator. For more information, see Synchronization Object Security and Access Rights.
        /// </param>
        /// <param name="bInitialOwner">
        /// If this value is TRUE and the caller created the mutex, the calling thread obtains initial ownership of the mutex object. Otherwise, the calling thread does not obtain ownership of the mutex. To determine if the caller created the mutex, see the Return Values section.
        /// </param>
        /// <param name="lpName">
        /// The name of the mutex object. The name is limited to MAX_PATH characters. Name comparison is case sensitive.
        /// If lpName matches the name of an existing named mutex object, this function requests the MUTEX_ALL_ACCESS access right. In this case, the bInitialOwner parameter is ignored because it has already been set by the creating process. If the lpMutexAttributes parameter is not NULL, it determines whether the handle can be inherited, but its security-descriptor member is ignored.
        /// If lpName is NULL, the mutex object is created without a name.
        /// If lpName matches the name of an existing event, semaphore, waitable timer, job, or file-mapping object, the function fails and the GetLastError function returns ERROR_INVALID_HANDLE. This occurs because these objects share the same namespace.
        /// The name can have a "Global\" or "Local\" prefix to explicitly create the object in the global or session namespace. The remainder of the name can contain any character except the backslash character (\). For more information, see Kernel Object Namespaces. Fast user switching is implemented using Terminal Services sessions. Kernel object names must follow the guidelines outlined for Terminal Services so that applications can support multiple users.
        /// The object can be created in a private namespace. For more information, see Object Namespaces.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is a handle to the newly created mutex object.
        /// If the function fails, the return value is NULL. To get extended error information, call GetLastError.
        /// If the mutex is a named mutex and the object existed before this function call, the return value is a handle to the existing object, GetLastError returns ERROR_ALREADY_EXISTS, bInitialOwner is ignored, and the calling thread is not granted ownership. However, if the caller has limited access rights, the function will fail with ERROR_ACCESS_DENIED and the caller should use the OpenMutex function.
        /// </returns>
        [DllImport(api_ms_win_core_synch_l1_2_0, EntryPoint = "CreateMutexW", ExactSpelling = true, CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern unsafe SafeObjectHandle CreateMutex(
            [Friendly(FriendlyFlags.Optional | FriendlyFlags.In)] SECURITY_ATTRIBUTES* lpMutexAttributes,
            [MarshalAs(UnmanagedType.Bool)] bool bInitialOwner,
            string lpName);

        /// <summary>
        /// Retrieves the address of an exported function or variable from the specified dynamic-link library (DLL).
        /// </summary>
        /// <param name="hModule">A handle to the DLL module that contains the function or variable. The LoadLibrary, LoadLibraryEx, or GetModuleHandle function returns this handle.</param>
        /// <param name="procName">The function or variable name, or the function's ordinal value. If this parameter is an ordinal value, it must be in the low-order word; the high-order word must be zero.</param>
        /// <returns>
        /// If the function succeeds, the return value is the address of the exported function or variable.
        /// If the function fails, the return value is NULL.To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>This function does not retrieve handles for modules that were loaded using the LoadLibraryExFlags.LOAD_LIBRARY_AS_DATAFILE flag.</remarks>
        [DllImport(api_ms_win_core_libraryloader_l1_1_1, SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = true)]
        public static extern IntPtr GetProcAddress(SafeLibraryHandle hModule, string procName);

        /// <summary>
        /// Retrieves the number of milliseconds that have elapsed since the system was started, up to 49.7 days.
        /// </summary>
        /// <returns>The return value is the number of milliseconds that have elapsed since the system was started.</returns>
        [DllImport(api_ms_win_core_sysinfo_l1_2_1)]
        public static extern uint GetTickCount();

        /// <summary>
        /// Retrieves the number of milliseconds that have elapsed since the system was started.
        /// </summary>
        /// <returns>The number of milliseconds.</returns>
        [DllImport(api_ms_win_core_sysinfo_l1_2_1)]
        public static extern ulong GetTickCount64();

        /// <summary>
        /// Retrieves the current system date and time. The system time is expressed in Coordinated Universal Time (UTC).
        /// To retrieve the current system date and time in local time, use the GetLocalTime function.
        /// </summary>
        /// <param name="lpSystemTime">
        /// A pointer to a SYSTEMTIME structure to receive the current system date and time.
        /// The lpSystemTime parameter must not be NULL. Using NULL will result in an access violation.
        /// </param>
        [DllImport(api_ms_win_core_sysinfo_l1_2_0)]
        public static extern unsafe void GetSystemTime([Friendly(FriendlyFlags.Out)] SYSTEMTIME* lpSystemTime);

        /// <summary>
        /// Sets the last-error code for the calling thread.
        /// </summary>
        /// <param name="dwErrCode">The last-error code for the thread.</param>
        [DllImport(api_ms_win_core_errorhandling_l1_1_1, SetLastError = true)]
        public static extern void SetLastError(uint dwErrCode);

        /// <summary>
        /// Sets the bits of a 64-bit value to indicate the comparison operator to use for a specified operating system version
        /// attribute. This function is used to build the dwlConditionMask parameter of the <see cref="VerifyVersionInfo(OSVERSIONINFOEX*, VER_MASK, long)"/> function.
        /// </summary>
        /// <param name="ConditionMask">A value to be passed as the dwlConditionMask parameter of the <see cref="VerifyVersionInfo(OSVERSIONINFOEX*, VER_MASK, long)"/> function.
        /// The function stores the comparison information in the bits of this variable. Before the first call to <see cref="VerSetConditionMask(long, VER_MASK, VER_CONDITION)"/>,
        /// initialize this variable to zero. For subsequent calls, pass in the variable used in the previous call.</param>
        /// <param name="TypeMask">A mask that indicates the member of the <see cref="OSVERSIONINFOEX"/> structure whose comparison operator
        /// is being set. This value corresponds to one of the bits specified in the dwTypeMask parameter for the
        /// <see cref="VerifyVersionInfo(OSVERSIONINFOEX*, VER_MASK, long)"/> function</param>
        /// <param name="Condition">The operator to be used for the comparison. The <see cref="VerifyVersionInfo(OSVERSIONINFOEX*, VER_MASK, long)"/> function uses this
        /// operator to compare a specified attribute value to the corresponding value for the currently running system.</param>
        /// <returns>The function returns the condition mask value.</returns>
        [DllImport(api_ms_win_core_sysinfo_l1_2_0)]
        public static extern long VerSetConditionMask(long ConditionMask, VER_MASK TypeMask, VER_CONDITION Condition);

        /// <summary>
        /// Compares a set of operating system version requirements to the corresponding values for the currently
        /// running version of the system.This function is subject to manifest-based behavior.
        /// </summary>
        /// <param name="lpVersionInformation">
        /// A pointer to an OSVERSIONINFOEX structure containing the operating system version requirements to compare. The <paramref name="dwTypeMask"/>
        /// parameter indicates the members of this structure that contain information to compare.You must set the
        /// <see cref="OSVERSIONINFOEX.dwOSVersionInfoSize"/> member of this structure to <code>Marshal.SizeOf(typeof(OSVERSIONINFOEX))</code>. You must
        /// also specify valid data for the members indicated by <paramref name="dwTypeMask"/>. The function ignores structure members for which the
        /// corresponding <paramref name="dwTypeMask"/> bit is not set
        /// </param>
        /// <param name="dwTypeMask">A mask that indicates the members of the <see cref="OSVERSIONINFOEX"/> structure to be tested.</param>
        /// <param name="dwlConditionMask">The type of comparison to be used for each <paramref name="lpVersionInformation"/> member being compared. To build this value,
        /// call the <see cref="VerSetConditionMask(long, VER_MASK, VER_CONDITION)"/> function once for each <see cref="OSVERSIONINFOEX"/> member being compared.</param>
        /// <returns>
        /// <para>
        /// If the currently running operating system satisfies the specified requirements, the return value is a nonzero value.
        /// </para>
        /// <para>
        /// If the current system does not satisfy the requirements, the return value is zero and <see cref="GetLastError"/> returns <see cref="Win32ErrorCode.ERROR_OLD_WIN_VERSION"/>.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero and <see cref="GetLastError"/> returns an error code other than <see cref="Win32ErrorCode.ERROR_OLD_WIN_VERSION"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// The <see cref="VerifyVersionInfo(OSVERSIONINFOEX*, VER_MASK, long)"/> function retrieves version information about the currently running operating system and compares it to the valid
        /// members of the <paramref name="lpVersionInformation"/> structure. This enables you to easily determine the presence of a required set of
        /// operating system version conditions. It is preferable to use <see cref="VerifyVersionInfo(OSVERSIONINFOEX*, VER_MASK, long)"/> rather than
        /// calling the GetVersionEx function to perform your own comparisons.
        /// </para>
        /// <para>
        /// Typically, <see cref="VerifyVersionInfo(OSVERSIONINFOEX*, VER_MASK, long)"/> returns a nonzero value only if all specified tests succeed.
        /// However, major, minor, and service pack versions are tested in a hierarchical manner because the operating system version is a combination of
        /// these values. If a condition exists for the major version, it supersedes the conditions specified for minor version and service pack version.
        /// (You cannot test for major version greater than 5 and minor version less than or equal to 1. If you specify such a test, the function will
        /// change the request to test for a minor version greater than 1 because it is performing a greater than operation on the major version.)
        /// </para>
        /// <para>
        /// The function tests these values in this order: major version, minor version, and service pack version.The function continues testing values while
        /// they are equal, and stops when one of the values does not meet the specified condition.For example, if you test for a system greater than or
        /// equal to version 5.1 service pack 1, the test succeeds if the current version is 6.0. (The major version is greater than the specified version,
        /// so the testing stops.) In the same way, if you test for a system greater than or equal to version 5.1 service pack 1, the test succeeds if the
        /// current version is 5.2. (The minor version is greater than the specified versions, so the testing stops.) However, if you test for a system greater
        /// than or equal to version 5.1 service pack 1, the test fails if the current version is 5.0 service pack 2. (The minor version is not greater than
        /// the specified version, so the testing stops.)
        /// </para>
        /// <para>
        /// To verify a range of system versions, you must call <see cref="VerifyVersionInfo(OSVERSIONINFOEX*, VER_MASK, long)"/> twice.For example, to verify
        /// that the system version is greater than 5.0 but less than or equal to 5.1, first call <see cref="VerifyVersionInfo(OSVERSIONINFOEX*, VER_MASK, long)"/> to
        /// test that the major version is 5 and the minor version is greater than 0, then call <see cref="VerifyVersionInfo(OSVERSIONINFOEX*, VER_MASK, long)"/>
        /// again to test that the major version is 5 and the minor version is less than or equal to 1.
        /// </para>
        /// <para>
        /// Identifying the current operating system is usually not the best way to determine whether a particular operating system feature is present.
        /// This is because the operating system may have had new features added in a redistributable DLL. Rather than using GetVersionEx to determine the operating
        /// system platform or version number, test for the presence of the feature itself.
        /// </para>
        /// <para>
        /// To verify whether the current operating system is either the Media Center or Tablet PC version of Windows, call GetSystemMetrics.
        /// </para>
        /// <para>
        /// Windows 10:
        ///     <see cref="VerifyVersionInfo(OSVERSIONINFOEX*, VER_MASK, long)"/> returns false when called by applications that do not have a
        ///     compatibility manifest for Windows 8.1 or Windows 10 if the <paramref name="lpVersionInformation"/> parameter is set so that it specifies
        ///     Windows 8.1 or Windows 10, even when the current operating system version is Windows 8.1 or Windows 10. Specifically,
        ///     <see cref="VerifyVersionInfo(OSVERSIONINFOEX*, VER_MASK, long)"/> has the following behavior:
        ///
        ///     If the application has no manifest, <see cref="VerifyVersionInfo(OSVERSIONINFOEX*, VER_MASK, long)"/> behaves as
        ///         if the operation system version is Windows 8 (6.2).
        ///     If the application has a manifest that contains the GUID that corresponds to Windows 8.1, <see cref="VerifyVersionInfo(OSVERSIONINFOEX*, VER_MASK, long)"/>
        ///         behaves as if the operation system version is Windows 8.1 (6.3).
        ///     If the application has a manifest that contains the GUID that corresponds to Windows 10, <see cref="VerifyVersionInfo(OSVERSIONINFOEX*, VER_MASK, long)"/>
        ///         behaves as if the operation system version is Windows 10 (10.0).
        /// </para>
        /// </remarks>
        [DllImport(nameof(Kernel32))]
        public static unsafe extern NTSTATUS VerifyVersionInfo(
            [Friendly(FriendlyFlags.Bidirectional)] OSVERSIONINFOEX* lpVersionInformation,
            VER_MASK dwTypeMask,
            long dwlConditionMask);

        /// <summary>
        ///     Closes a file search handle opened by the FindFirstFile, FindFirstFileEx, FindFirstFileNameW,
        ///     FindFirstFileNameTransactedW, FindFirstFileTransacted, FindFirstStreamTransactedW, or FindFirstStreamW functions.
        /// </summary>
        /// <param name="hFindFile">The file search handle.</param>
        /// <returns>
        ///     If the function succeeds, the return value is nonzero.
        ///     <para>
        ///         If the function fails, the return value is zero. To get extended error information, call
        ///         <see cref="GetLastError" />.
        ///     </para>
        /// </returns>
        [DllImport(api_ms_win_core_file_l1_2_0, SetLastError = true)]
        private static extern bool FindClose(IntPtr hFindFile);

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
