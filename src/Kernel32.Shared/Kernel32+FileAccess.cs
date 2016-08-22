// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using static Kernel32.ACCESS_MASK.StandardRight;

    /// <content>
    /// Contains the <see cref="FileAccess"/> nested type.
    /// </content>
    public partial class Kernel32
    {
        /// <summary>
        /// Enumerates the <see cref="ACCESS_MASK.SpecificRights"/> that may apply to files.
        /// </summary>
        /// <remarks>
        /// These flags may be passed to CreateFile.
        /// </remarks>
        public static class FileAccess
        {
            /// <summary>
            ///     For a file object, the right to read the corresponding file data. For a directory object, the right to read
            ///     the corresponding directory data.
            /// </summary>
            public const uint FILE_READ_DATA = 0x0001; // file & pipe

            /// <summary>For a directory, the right to list the contents of the directory.</summary>
            public const uint FILE_LIST_DIRECTORY = 0x0001; // directory

            /// <summary>
            ///     For a file object, the right to write data to the file. For a directory object, the right to create a file in
            ///     the directory (<see cref="FILE_ADD_FILE" />).
            /// </summary>
            public const uint FILE_WRITE_DATA = 0x0002; // file & pipe

            /// <summary>For a directory, the right to create a file in the directory.</summary>
            public const uint FILE_ADD_FILE = 0x0002; // directory

            /// <summary>
            ///     For a file object, the right to append data to the file. (For local files, write operations will not overwrite
            ///     existing data if this flag is specified without <see cref="FILE_WRITE_DATA" />.) For a directory object, the right
            ///     to create a subdirectory (<see cref="FILE_ADD_SUBDIRECTORY" />).
            /// </summary>
            public const uint FILE_APPEND_DATA = 0x0004; // file

            /// <summary>For a directory, the right to create a subdirectory.</summary>
            public const uint FILE_ADD_SUBDIRECTORY = 0x0004; // directory

            /// <summary>For a named pipe, the right to create a pipe.</summary>
            public const uint FILE_CREATE_PIPE_INSTANCE = 0x0004; // named pipe

            /// <summary>The right to read extended file attributes.</summary>
            public const uint FILE_READ_EA = 0x0008; // file & directory

            /// <summary>The right to write extended file attributes.</summary>
            public const uint FILE_WRITE_EA = 0x0010; // file & directory

            /// <summary>
            ///     For a native code file, the right to execute the file. This access right given to scripts may cause the script
            ///     to be executable, depending on the script interpreter.
            /// </summary>
            public const uint FILE_EXECUTE = 0x0020; // file

            /// <summary>
            ///     For a directory, the right to traverse the directory. By default, users are assigned the
            ///     BYPASS_TRAVERSE_CHECKING privilege, which ignores the FILE_TRAVERSE access right.
            /// </summary>
            public const uint FILE_TRAVERSE = 0x0020; // directory

            /// <summary>For a directory, the right to delete a directory and all the files it contains, including read-only files.</summary>
            public const uint FILE_DELETE_CHILD = 0x0040; // directory

            /// <summary>The right to read file attributes.</summary>
            public const uint FILE_READ_ATTRIBUTES = 0x0080; // all

            /// <summary>The right to write file attributes.</summary>
            public const uint FILE_WRITE_ATTRIBUTES = 0x0100; // all

            public const uint SPECIFIC_RIGHTS_ALL = 0x00FFFF;

            public const uint FILE_ALL_ACCESS = (uint)STANDARD_RIGHTS_REQUIRED | (uint)SYNCHRONIZE | 0x1FF;

            public const uint FILE_GENERIC_READ = (uint)STANDARD_RIGHTS_READ | FILE_READ_DATA | FILE_READ_ATTRIBUTES | FILE_READ_EA | (uint)SYNCHRONIZE;

            public const uint FILE_GENERIC_WRITE = (uint)STANDARD_RIGHTS_WRITE | FILE_WRITE_DATA | FILE_WRITE_ATTRIBUTES | FILE_WRITE_EA | FILE_APPEND_DATA | (uint)SYNCHRONIZE;

            public const uint FILE_GENERIC_EXECUTE = (uint)STANDARD_RIGHTS_EXECUTE | FILE_READ_ATTRIBUTES | FILE_EXECUTE | (uint)SYNCHRONIZE;
        }
    }
}
