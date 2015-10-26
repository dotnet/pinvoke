// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Runtime.InteropServices;
    using FILETIME = System.Runtime.InteropServices.ComTypes.FILETIME;

    /// <summary>
    /// Exported functions from the Kernel32.dll Windows library.
    /// </summary>
    public static partial class Kernel32
    {
        /// <summary>
        /// Constant for invalid handle value
        /// </summary>
        public static readonly IntPtr INVALID_HANDLE_VALUE = new IntPtr(-1);

        public enum FINDEX_INFO_LEVELS
        {
            FindExInfoStandard,
            FindExInfoMaxInfoLevel,
        }

        public enum FINDEX_SEARCH_OPS
        {
            FindExSearchNameMatch,
            FindExSearchLimitToDirectories,
            FindExSearchLimitToDevices,
            FindExSearchMaxSearchOp,
        }

        /// <summary>
        /// Optional flags to pass to the <see cref="FindFirstFileEx"/> method.
        /// </summary>
        [Flags]
        public enum FindFirstFileExFlags
        {
            /// <summary>
            /// Searches are case-sensitive.
            /// </summary>
            CaseSensitive,

            /// <summary>
            /// Uses a larger buffer for directory queries, which can increase performance of the find operation.
            /// </summary>
            LargeFetch,
        }

        /// <summary>
        /// Searches a directory for a file or subdirectory with a name and attributes that match those specified.
        /// For the most basic version of this function, see <see cref="FindFirstFile"/>.
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
        /// If the function fails or fails to locate files from the search string in the lpFileName parameter, the return value is INVALID_HANDLE_VALUE and the contents of lpFindFileData are indeterminate.To get extended error information, call the GetLastError function.
        /// </returns>
        [DllImport(nameof(Kernel32))]
        public static extern SafeFindFilesHandle FindFirstFileEx(string lpFileName, FINDEX_INFO_LEVELS fInfoLevelId, out WIN32_FIND_DATA lpFindFileData, FINDEX_SEARCH_OPS fSearchOp, IntPtr lpSearchFilter, FindFirstFileExFlags dwAdditionalFlags);

        /// <summary>
        /// Closes a file search handle opened by the FindFirstFile, FindFirstFileEx, FindFirstFileNameW, FindFirstFileNameTransactedW, FindFirstFileTransacted, FindFirstStreamTransactedW, or FindFirstStreamW functions.
        /// </summary>
        /// <param name="hFindFile">The file search handle.</param>
        /// <returns>
        /// If the function succeeds, the return value is nonzero.
        /// If the function fails, the return value is zero. To get extended error information, call GetLastError.
        /// </returns>
        [DllImport(nameof(Kernel32), SetLastError = true)]
        public static extern bool FindClose(IntPtr hFindFile);

        /// <summary>
        /// Closes an open object handle.
        /// </summary>
        /// <param name="hObject">A valid handle to an open object.</param>
        /// <returns>
        /// If the function succeeds, the return value is nonzero.
        /// If the function fails, the return value is zero.To get extended error information, call GetLastError.
        /// </returns>
        [DllImport(nameof(Kernel32), SetLastError = true)]
        public static extern bool CloseHandle(IntPtr hObject);

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
