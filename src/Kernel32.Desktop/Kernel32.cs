// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.IO;
    using System.Runtime.InteropServices;
    using FILETIME = System.Runtime.InteropServices.ComTypes.FILETIME;

    /// <summary>
    /// Exported functions from the Kernel32.dll Windows library.
    /// </summary>
    public static partial class Kernel32
    {
        /// <summary>
        /// Describes file access flags that may be passed to <see cref="CreateFile"/>.
        /// </summary>
        [Flags]
        public enum FileAccess : uint
        {
            GenericRead = 0x80000000,
            GenericWrite = 0x40000000,
            GenericExecute = 0x20000000,
            GenericAll = 0x10000000,

            AccessSystemSecurity = 0x1000000,
            MaximumAllowed = 0x2000000,

            Delete = 0x10000,
            ReadControl = 0x20000,
            WriteDAC = 0x40000,
            WriteOwner = 0x80000,
            Synchronize = 0x100000,

            StandardRightsRequired = 0xF0000,
            StandardRightsRead = ReadControl,
            StandardRightsWrite = ReadControl,
            StandardRightsExecute = ReadControl,
            StandardRightsAll = 0x1F0000,
            SpecificRightsAll = 0xFFFF,

            FILE_READ_DATA = 0x0001,        // file & pipe
            FILE_LIST_DIRECTORY = 0x0001,       // directory
            FILE_WRITE_DATA = 0x0002,       // file & pipe
            FILE_ADD_FILE = 0x0002,         // directory
            FILE_APPEND_DATA = 0x0004,      // file
            FILE_ADD_SUBDIRECTORY = 0x0004,     // directory
            FILE_CREATE_PIPE_INSTANCE = 0x0004, // named pipe
            FILE_READ_EA = 0x0008,          // file & directory
            FILE_WRITE_EA = 0x0010,         // file & directory
            FILE_EXECUTE = 0x0020,          // file
            FILE_TRAVERSE = 0x0020,         // directory
            FILE_DELETE_CHILD = 0x0040,     // directory
            FILE_READ_ATTRIBUTES = 0x0080,      // all
            FILE_WRITE_ATTRIBUTES = 0x0100,     // all

            SPECIFIC_RIGHTS_ALL = 0x00FFFF,
            FILE_ALL_ACCESS = StandardRightsRequired | Synchronize | 0x1FF,
            FILE_GENERIC_READ = StandardRightsRead | FILE_READ_DATA | FILE_READ_ATTRIBUTES | FILE_READ_EA | Synchronize,
            FILE_GENERIC_WRITE = StandardRightsWrite | FILE_WRITE_DATA | FILE_WRITE_ATTRIBUTES | FILE_WRITE_EA | FILE_APPEND_DATA | Synchronize,
            FILE_GENERIC_EXECUTE = StandardRightsExecute | FILE_READ_ATTRIBUTES | FILE_EXECUTE | Synchronize
        }

        [Flags]
        public enum FileShare : uint
        {
            /// <summary>
            ///
            /// </summary>
            None = 0x00000000,

            /// <summary>
            /// Enables subsequent open operations on an object to request read access.
            /// Otherwise, other processes cannot open the object if they request read access.
            /// If this flag is not specified, but the object has been opened for read access, the function fails.
            /// </summary>
            Read = 0x00000001,

            /// <summary>
            /// Enables subsequent open operations on an object to request write access.
            /// Otherwise, other processes cannot open the object if they request write access.
            /// If this flag is not specified, but the object has been opened for write access, the function fails.
            /// </summary>
            Write = 0x00000002,

            /// <summary>
            /// Enables subsequent open operations on an object to request delete access.
            /// Otherwise, other processes cannot open the object if they request delete access.
            /// If this flag is not specified, but the object has been opened for delete access, the function fails.
            /// </summary>
            Delete = 0x00000004
        }

        /// <summary>
        /// Describes an action to take on a file or device that exists or does not exist.
        /// </summary>
        /// <remarks>
        /// These are flags to pass to the <see cref="CreateFile"/> method's dwCreationDisposition parameter.
        /// </remarks>
        public enum CreationDisposition : uint
        {
            /// <summary>
            /// Creates a new file. The function fails if a specified file exists.
            /// </summary>
            New = 1,

            /// <summary>
            /// Creates a new file, always.
            /// If a file exists, the function overwrites the file, clears the existing attributes, combines the specified file attributes,
            /// and flags with FILE_ATTRIBUTE_ARCHIVE, but does not set the security descriptor that the SECURITY_ATTRIBUTES structure specifies.
            /// </summary>
            CreateAlways = 2,

            /// <summary>
            /// Opens a file. The function fails if the file does not exist.
            /// </summary>
            OpenExisting = 3,

            /// <summary>
            /// Opens a file, always.
            /// If a file does not exist, the function creates a file as if dwCreationDisposition is CREATE_NEW.
            /// </summary>
            OpenAlways = 4,

            /// <summary>
            /// Opens a file and truncates it so that its size is 0 (zero) bytes. The function fails if the file does not exist.
            /// The calling process must open the file with the GENERIC_WRITE access right.
            /// </summary>
            TruncateExisting = 5
        }

        /// <summary>
        /// File attributes, flags, and security settings that are passed to the <see cref="CreateFile"/> method.
        /// </summary>
        [Flags]
        public enum CreateFileFlags : uint
        {
            /// <summary>
            /// A file or directory that is an archive file or directory. Applications typically use this attribute to mark files for backup or removal.
            /// </summary>
            ArchiveAttribute = 0x20,

            /// <summary>
            /// A file or directory that is encrypted. For a file, all data streams in the file are encrypted. For a directory, encryption is the default for newly created files and subdirectories.
            /// </summary>
            EncryptedAttribute = 0x4000,

            /// <summary>
            /// The file or directory is hidden. It is not included in an ordinary directory listing.
            /// </summary>
            HiddenAttribute = 0x2,

            /// <summary>
            /// A file that does not have other attributes set. This attribute is valid only when used alone.
            /// </summary>
            NormalAttribute = 0x80,

            /// <summary>
            /// The data of a file is not available immediately. This attribute indicates that the file data is physically moved to offline storage. This attribute is used by Remote Storage, which is the hierarchical storage management software. Applications should not arbitrarily change this attribute.
            /// </summary>
            OfflineAttribute = 0x1000,

            /// <summary>
            /// A file that is read-only. Applications can read the file, but cannot write to it or delete it. This attribute is not honored on directories.
            /// </summary>
            ReadOnlyAttribute = 0x1,

            /// <summary>
            /// A file or directory that the operating system uses a part of, or uses exclusively.
            /// </summary>
            SystemAttribute = 0x4,

            /// <summary>
            /// A file that is being used for temporary storage. File systems avoid writing data back to mass storage if sufficient cache memory is available, because typically, an application deletes a temporary file after the handle is closed. In that scenario, the system can entirely avoid writing the data. Otherwise, the data is written after the handle is closed.
            /// </summary>
            TemporaryAttribute = 0x100,

            /// <summary>
            /// The file is being opened or created for a backup or restore operation. The system ensures that the calling process overrides file security checks when the process has SE_BACKUP_NAME and SE_RESTORE_NAME privileges. For more information, see Changing Privileges in a Token.
            /// You must set this flag to obtain a handle to a directory. A directory handle can be passed to some functions instead of a file handle. For more information, see the Remarks section.
            /// </summary>
            BackupSemanticsFlag = 0x02000000,

            /// <summary>
            /// The file is to be deleted immediately after all of its handles are closed, which includes the specified handle and any other open or duplicated handles.
            /// If there are existing open handles to a file, the call fails unless they were all opened with the <see cref="FileShare.Delete"/> share mode.
            /// Subsequent open requests for the file fail, unless the <see cref="FileShare.Delete"/> share mode is specified.
            /// </summary>
            DeleteOnCloseFlag = 0x04000000,

            /// <summary>
            /// The file or device is being opened with no system caching for data reads and writes. This flag does not affect hard disk caching or memory mapped files.
            /// There are strict requirements for successfully working with files opened with <see cref="CreateFile"/> using the <see cref="NoBufferingFlag"/> flag, for details see File Buffering.
            /// </summary>
            NoBufferingFlag = 0x20000000,

            /// <summary>
            /// The file data is requested, but it should continue to be located in remote storage. It should not be transported back to local storage. This flag is for use by remote storage systems.
            /// </summary>
            OpenNoRecall = 0x00100000,

            /// <summary>
            /// Normal reparse point processing will not occur; CreateFile will attempt to open the reparse point. When a file is opened, a file handle is returned, whether or not the filter that controls the reparse point is operational.
            /// This flag cannot be used with the CREATE_ALWAYS flag.
            /// If the file is not a reparse point, then this flag is ignored.
            /// For more information, see the Remarks section.
            /// </summary>
            OpenReparsePointFlag = 0x00200000,

            /// <summary>
            /// The file or device is being opened or created for asynchronous I/O.
            /// When subsequent I/O operations are completed on this handle, the event specified in the OVERLAPPED structure will be set to the signaled state.
            /// If this flag is specified, the file can be used for simultaneous read and write operations.
            /// If this flag is not specified, then I/O operations are serialized, even if the calls to the read and write functions specify an OVERLAPPED structure.For information about considerations when using a file handle created with this flag, see the Synchronous and Asynchronous I/O Handles section of this topic.
            /// </summary>
            OverlappedFlag = 0x40000000,

            /// <summary>
            /// Access will occur according to POSIX rules. This includes allowing multiple files with names, differing only in case, for file systems that support that naming. Use care when using this option, because files created with this flag may not be accessible by applications that are written for MS-DOS or 16-bit Windows.
            /// </summary>
            PosixSemanticsFlag = 0x0100000,

            /// <summary>
            /// Access is intended to be random. The system can use this as a hint to optimize file caching.
            /// This flag has no effect if the file system does not support cached I/O and <see cref="NoBufferingFlag"/>.
            /// For more information, see the Caching Behavior section of this topic.
            /// </summary>
            RandomAccessFlag = 0x10000000,

            /// <summary>
            /// The file or device is being opened with session awareness. If this flag is not specified, then per-session devices (such as a redirected USB device) cannot be opened by processes running in session 0. This flag has no effect for callers not in session 0. This flag is supported only on server editions of Windows.
            /// </summary>
            SessionAwareFlag = 0x00800000,

            /// <summary>
            /// Access is intended to be sequential from beginning to end. The system can use this as a hint to optimize file caching.
            /// This flag should not be used if read-behind (that is, reverse scans) will be used.
            /// This flag has no effect if the file system does not support cached I/O and <see cref="NoBufferingFlag"/>.
            /// For more information, see the Caching Behavior section of this topic.
            /// </summary>
            SequentialScanFlag = 0x08000000,

            /// <summary>
            /// Write operations will not go through any intermediate cache, they will go directly to disk.
            /// For additional information, see the Caching Behavior section of this topic.
            /// </summary>
            WriteThroughFlag = 0x80000000,

            /// <summary>
            /// When this flag is present, one or more other flags ending with Security may also be specified.
            /// </summary>
            SqosPresentSecurity = 0x00100000,

            /// <summary>
            /// Impersonates a client at the Anonymous impersonation level.
            /// </summary>
            AnonymousSecurity = SecurityImpersonationLevel.SecurityAnonymous << 16,

            /// <summary>
            /// The security tracking mode is dynamic. If this flag is not specified, the security tracking mode is static.
            /// </summary>
            ContextTrackingSecurity = 0x00040000,

            /// <summary>
            /// Impersonates a client at the Delegation impersonation level.
            /// </summary>
            DelegationSecurity = SecurityImpersonationLevel.SecurityDelegation << 16,

            /// <summary>
            /// Only the enabled aspects of the client's security context are available to the server. If you do not specify this flag, all aspects of the client's security context are available.
            /// This allows the client to limit the groups and privileges that a server can use while impersonating the client.
            /// </summary>
            EffectiveOnlySecurity = 0x00080000,

            /// <summary>
            /// Impersonates a client at the Identification impersonation level.
            /// </summary>
            IdentificationSecurity = SecurityImpersonationLevel.SecurityIdentification << 16,

            /// <summary>
            /// Impersonate a client at the impersonation level. This is the default behavior if no other flags are specified along with the SECURITY_SQOS_PRESENT flag.
            /// </summary>
            ImpersonationSecurity = SecurityImpersonationLevel.SecurityImpersonation << 16,
        }

        /// <summary>
        /// Contains values that specify security impersonation levels. Security impersonation levels govern the degree to which a server process can act on behalf of a client process.
        /// </summary>
        /// <remarks>
        /// Equivalent to the native SECURITY_IMPERSONATION_LEVEL enum.
        /// </remarks>
        public enum SecurityImpersonationLevel
        {
            /// <summary>
            /// The server process cannot obtain identification information about the client, and it cannot impersonate the client. It is defined with no value given, and thus, by ANSI C rules, defaults to a value of zero.
            /// </summary>
            SecurityAnonymous,

            /// <summary>
            /// The server process can obtain information about the client, such as security identifiers and privileges, but it cannot impersonate the client. This is useful for servers that export their own objects, for example, database products that export tables and views. Using the retrieved client-security information, the server can make access-validation decisions without being able to use other services that are using the client's security context.
            /// </summary>
            SecurityIdentification,

            /// <summary>
            /// The server process can impersonate the client's security context on its local system. The server cannot impersonate the client on remote systems.
            /// </summary>
            SecurityImpersonation,

            /// <summary>
            /// The server process can impersonate the client's security context on remote systems.
            /// </summary>
            SecurityDelegation,
        }

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
        /// You cannot request a sharing mode that conflicts with the access mode that is specified in an existing request that has an open handle. <see cref="CreateFile"/> would fail and the GetLastError function would return ERROR_SHARING_VIOLATION.
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
        /// If the function fails, the return value is INVALID_HANDLE_VALUE.To get extended error information, call GetLastError.
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
        /// If the function fails or fails to locate files from the search string in the lpFileName parameter, the return value is INVALID_HANDLE_VALUE and the contents of lpFindFileData are indeterminate.To get extended error information, call the GetLastError function.
        /// If the function fails because no matching files can be found, the GetLastError function returns ERROR_FILE_NOT_FOUND.
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
        /// If the function fails, the return value is zero and the contents of lpFindFileData are indeterminate. To get extended error information, call the GetLastError function.
        /// If the function fails because no more matching files can be found, the GetLastError function returns ERROR_NO_MORE_FILES.
        /// </returns>
        [DllImport(nameof(Kernel32), SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern bool FindNextFile(SafeFindFilesHandle hFindFile, out WIN32_FIND_DATA lpFindFileData);

        [StructLayout(LayoutKind.Sequential)]
        public struct SECURITY_ATTRIBUTES
        {
            public uint nLength;
            public IntPtr lpSecurityDescriptor;
            [MarshalAs(UnmanagedType.Bool)]
            public bool bInheritHandle;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct SECURITY_DESCRIPTOR
        {
            public byte Revision;
            public byte Sbz1;
            public ushort Control;
            public IntPtr Owner;
            public IntPtr Group;
            public IntPtr Sacl;
            public IntPtr Dacl;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct ACL
        {
            public byte AclRevision;
            public byte Sbz1;
            public ushort AclSize;
            public ushort AceCount;
            public ushort Sbz2;
        }
    }
}
