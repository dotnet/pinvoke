// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System.Runtime.InteropServices;

    /// <content>
    /// Contains the <see cref="WIN32_FIND_DATA"/> nested type.
    /// </content>
    public partial class Kernel32
    {
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        public struct WIN32_FIND_DATA
        {
            /// <summary>
            /// The file attributes of a file.
            /// </summary>
            /// <remarks>
            /// Although the enum we bind to here exists in the .NET Framework
            /// as System.IO.FileAttributes, it is not reliably present.
            /// Portable profiles don't include it, for example. So we have to define our own.
            /// </remarks>
            public FileAttribute dwFileAttributes;

            /// <summary>
            /// A FILETIME structure that specifies when a file or directory was created.
            /// If the underlying file system does not support creation time, this member is zero.
            /// </summary>
            public FILETIME ftCreationTime;

            /// <summary>
            /// A FILETIME structure.
            /// For a file, the structure specifies when the file was last read from, written to, or for executable files, run.
            /// For a directory, the structure specifies when the directory is created.If the underlying file system does not support last access time, this member is zero.
            /// On the FAT file system, the specified date for both files and directories is correct, but the time of day is always set to midnight.
            /// </summary>
            public FILETIME ftLastAccessTime;

            /// <summary>
            /// A FILETIME structure.
            /// For a file, the structure specifies when the file was last written to, truncated, or overwritten, for example, when WriteFile or SetEndOfFile are used.The date and time are not updated when file attributes or security descriptors are changed.
            /// For a directory, the structure specifies when the directory is created.If the underlying file system does not support last write time, this member is zero.
            /// </summary>
            public FILETIME ftLastWriteTime;

            /// <summary>
            /// The high-order DWORD value of the file size, in bytes.
            /// This value is zero unless the file size is greater than MAXDWORD.
            /// The size of the file is equal to(nFileSizeHigh* (MAXDWORD+1)) + nFileSizeLow.
            /// </summary>
            public uint nFileSizeHigh;

            /// <summary>
            /// The low-order DWORD value of the file size, in bytes.
            /// </summary>
            public uint nFileSizeLow;

            /// <summary>
            /// If the dwFileAttributes member includes the FILE_ATTRIBUTE_REPARSE_POINT attribute, this member specifies the reparse point tag.
            /// Otherwise, this value is undefined and should not be used.
            /// For more information see Reparse Point Tags.
            /// </summary>
            public uint dwReserved0;

            /// <summary>
            /// Reserved for future use.
            /// </summary>
            public uint dwReserved1;

            /// <summary>
            /// The name of the file.
            /// </summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
            public string cFileName;

            /// <summary>
            /// An alternative name for the file.
            /// This name is in the classic 8.3 file name format.
            /// </summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 14)]
            public string cAlternateFileName;
        }
    }
}
