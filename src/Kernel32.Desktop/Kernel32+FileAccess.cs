// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;

    /// <content>
    /// Contains the <see cref="FileAccess"/> nested enum.
    /// </content>
    public partial class Kernel32
    {
        /// <summary>
        /// Describes file access flags that may be passed to <see cref="CreateFile(string, FileAccess, FileShare, SECURITY_ATTRIBUTES*, CreationDisposition, CreateFileFlags, SafeObjectHandle)"/>.
        /// </summary>
        [Flags]
        public enum FileAccess : uint
        {
            /// <summary>Read access</summary>
            GENERIC_READ = 0x80000000,

            /// <summary>Write access</summary>
            GENERIC_WRITE = 0x40000000,

            /// <summary>Execute access</summary>
            GENERIC_EXECUTE = 0x20000000,

            /// <summary>All possible access rights</summary>
            GENERIC_ALL = 0x10000000,

            /// <summary>
            ///     used to indicate access to a system access control list (SACL). This type of access requires the calling
            ///     process to have the SE_SECURITY_NAME (Manage auditing and security log) privilege. If this flag is set in the
            ///     access mask of an audit access ACE (successful or unsuccessful access), the SACL access will be audited.
            /// </summary>
            ACCESS_SYSTEM_SECURITY = 0x1000000,

            /// <summary>Maximum allowed</summary>
            MAXIMUM_ALLOWED = 0x2000000,

            /// <summary>The right to delete the object.</summary>
            DELETE = 0x10000,

            /// <summary>
            ///     The right to read the information in the object's security descriptor, not including the information in the
            ///     system access control list (SACL).
            /// </summary>
            READ_CONTROL = 0x20000,

            /// <summary>The right to modify the discretionary access control list (DACL) in the object's security descriptor.</summary>
            WRITE_DAC = 0x40000,

            /// <summary>The right to change the owner in the object's security descriptor.</summary>
            WRITE_OWNER = 0x80000,

            /// <summary>
            ///     The right to use the object for synchronization. This enables a thread to wait until the object is in the
            ///     signaled state. Some object types do not support this access right.
            /// </summary>
            SYNCHRONIZE = 0x100000,

            /// <summary>
            ///     Combines <see cref="DELETE" />, <see cref="READ_CONTROL" />, <see cref="WRITE_DAC" />, and
            ///     <see cref="WRITE_OWNER" /> access.
            /// </summary>
            STANDARD_RIGHTS_REQUIRED = 0xF0000,

            /// <summary>
            ///     Includes <see cref="READ_CONTROL" />, which is the right to read the information in the file or directory
            ///     object's security descriptor. This does not include the information in the SACL.
            /// </summary>
            STANDARD_RIGHTS_READ = READ_CONTROL,

            /// <summary>Currently defined to equal <see cref="READ_CONTROL" />.</summary>
            STANDARD_RIGHTS_WRITE = READ_CONTROL,

            /// <summary>Currently defined to equal <see cref="READ_CONTROL" />.</summary>
            STANDARD_RIGHTS_EXECUTE = READ_CONTROL,

            /// <summary>
            ///     Combines <see cref="DELETE" />, <see cref="READ_CONTROL" />, <see cref="WRITE_DAC" />,
            ///     <see cref="WRITE_OWNER" />, and <see cref="SYNCHRONIZE" /> access.
            /// </summary>
            STANDARD_RIGHTS_ALL = 0x1F0000,

            /// <summary>
            ///     For a file object, the right to read the corresponding file data. For a directory object, the right to read
            ///     the corresponding directory data.
            /// </summary>
            FILE_READ_DATA = 0x0001, // file & pipe

            /// <summary>For a directory, the right to list the contents of the directory.</summary>
            FILE_LIST_DIRECTORY = 0x0001, // directory

            /// <summary>
            ///     For a file object, the right to write data to the file. For a directory object, the right to create a file in
            ///     the directory (<see cref="FILE_ADD_FILE" />).
            /// </summary>
            FILE_WRITE_DATA = 0x0002, // file & pipe

            /// <summary>For a directory, the right to create a file in the directory.</summary>
            FILE_ADD_FILE = 0x0002, // directory

            /// <summary>
            ///     For a file object, the right to append data to the file. (For local files, write operations will not overwrite
            ///     existing data if this flag is specified without <see cref="FILE_WRITE_DATA" />.) For a directory object, the right
            ///     to create a subdirectory (<see cref="FILE_ADD_SUBDIRECTORY" />).
            /// </summary>
            FILE_APPEND_DATA = 0x0004, // file

            /// <summary>For a directory, the right to create a subdirectory.</summary>
            FILE_ADD_SUBDIRECTORY = 0x0004, // directory

            /// <summary>For a named pipe, the right to create a pipe.</summary>
            FILE_CREATE_PIPE_INSTANCE = 0x0004, // named pipe

            /// <summary>The right to read extended file attributes.</summary>
            FILE_READ_EA = 0x0008, // file & directory

            /// <summary>The right to write extended file attributes.</summary>
            FILE_WRITE_EA = 0x0010, // file & directory

            /// <summary>
            ///     For a native code file, the right to execute the file. This access right given to scripts may cause the script
            ///     to be executable, depending on the script interpreter.
            /// </summary>
            FILE_EXECUTE = 0x0020, // file

            /// <summary>
            ///     For a directory, the right to traverse the directory. By default, users are assigned the
            ///     BYPASS_TRAVERSE_CHECKING privilege, which ignores the FILE_TRAVERSE access right.
            /// </summary>
            FILE_TRAVERSE = 0x0020, // directory

            /// <summary>For a directory, the right to delete a directory and all the files it contains, including read-only files.</summary>
            FILE_DELETE_CHILD = 0x0040, // directory

            /// <summary>The right to read file attributes.</summary>
            FILE_READ_ATTRIBUTES = 0x0080, // all

            /// <summary>The right to write file attributes.</summary>
            FILE_WRITE_ATTRIBUTES = 0x0100, // all

            SPECIFIC_RIGHTS_ALL = 0x00FFFF,

            FILE_ALL_ACCESS = STANDARD_RIGHTS_REQUIRED | SYNCHRONIZE | 0x1FF,

            FILE_GENERIC_READ = STANDARD_RIGHTS_READ | FILE_READ_DATA | FILE_READ_ATTRIBUTES | FILE_READ_EA | SYNCHRONIZE,

            FILE_GENERIC_WRITE = STANDARD_RIGHTS_WRITE | FILE_WRITE_DATA | FILE_WRITE_ATTRIBUTES | FILE_WRITE_EA | FILE_APPEND_DATA | SYNCHRONIZE,

            FILE_GENERIC_EXECUTE = STANDARD_RIGHTS_EXECUTE | FILE_READ_ATTRIBUTES | FILE_EXECUTE | SYNCHRONIZE
        }
    }
}
