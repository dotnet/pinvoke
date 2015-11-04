// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

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
        [DllImport(nameof(Kernel32), CharSet = CharSet.Auto, SetLastError = true)]
        public static extern SafeObjectHandle CreateFile(
            string filename,
            FileAccess access,
            FileShare share,
            IntPtr securityAttributes,
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
        [DllImport(nameof(Kernel32), SetLastError = true, CharSet = CharSet.Unicode)]
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
        [DllImport(nameof(Kernel32), SetLastError = true, CharSet = CharSet.Unicode)]
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
        /// <see cref="QueryFullProcessImageName(SafeObjectHandle,QueryFullProcessImageNameFlags,StringBuilder,ref uint)" />
        /// function to retrieve the full name of an executable image for both 32- and 64-bit processes from a 32-bit process.
        /// </para>
        /// </remarks>
        [DllImport(nameof(Kernel32), SetLastError = true)]
        public static extern SafeObjectHandle CreateToolhelp32Snapshot(
            CreateToolhelp32SnapshotFlags dwFlags,
            uint th32ProcessID);

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
        [DllImport(nameof(Kernel32), SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern bool QueryFullProcessImageName(
            SafeObjectHandle hProcess,
            QueryFullProcessImageNameFlags dwFlags,
            StringBuilder lpExeName,
            ref uint lpdwSize);

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
        /// GetCurrentProcess instead of OpenProcess, for improved performance.
        /// </para>
        /// </param>
        /// <returns>If the function succeeds, the return value is an open handle to the specified process.</returns>
        [DllImport(nameof(Kernel32), SetLastError = true)]
        public static extern SafeObjectHandle OpenProcess(
            ProcessAccess dwDesiredAccess,
            bool bInheritHandle,
            uint dwProcessId);

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
        [DllImport(nameof(Kernel32), SetLastError = true)]
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
        [DllImport(nameof(Kernel32), SetLastError = true)]
        public static extern bool CancelIo(SafeObjectHandle hFile);
    }
}
