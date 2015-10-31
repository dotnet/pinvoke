// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Runtime.InteropServices;
    using System.Text;
    using FILETIME = System.Runtime.InteropServices.ComTypes.FILETIME;

    /// <summary>
    /// Exported functions from the Kernel32.dll Windows library.
    /// </summary>
    public static partial class Kernel32
    {
        /// <summary>
        /// The maximum length of file paths for most Win32 functions.
        /// </summary>
        public const int MAX_PATH = 260;

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
        /// Flags passed to the <see cref="FormatMessage"/> method.
        /// </summary>
        [Flags]
        public enum FormatMessageFlags
        {
            /// <summary>
            /// The function allocates a buffer large enough to hold the formatted message, and places a pointer to the allocated buffer at the address specified by lpBuffer. The nSize parameter specifies the minimum number of TCHARs to allocate for an output message buffer. The caller should use the LocalFree function to free the buffer when it is no longer needed.
            /// If the length of the formatted message exceeds 128K bytes, then FormatMessage will fail and a subsequent call to GetLastError will return ERROR_MORE_DATA.
            /// In previous versions of Windows, this value was not available for use when compiling Windows Store apps. As of Windows 10 this value can be used.
            /// Windows Server 2003 and Windows XP:
            /// If the length of the formatted message exceeds 128K bytes, then FormatMessage will not automatically fail with an error of ERROR_MORE_DATA.
            /// Windows 10:
            /// LocalFree is not in the modern SDK, so it cannot be used to free the result buffer. Instead, use HeapFree (GetProcessHeap(), allocatedMessage). In this case, this is the same as calling LocalFree on memory.
            /// Important: LocalAlloc() has different options: LMEM_FIXED, and LMEM_MOVABLE. FormatMessage() uses LMEM_FIXED, so HeapFree can be used. If LMEM_MOVABLE is used, HeapFree cannot be used.
            /// </summary>
            AllocateBuffer = 0x100,

            /// <summary>
            /// The Arguments parameter is not a va_list structure, but is a pointer to an array of values that represent the arguments.
            /// This flag cannot be used with 64-bit integer values. If you are using a 64-bit integer, you must use the va_list structure.
            /// </summary>
            ArgumentArray = 0x2000,

            /// <summary>
            /// The lpSource parameter is a module handle containing the message-table resource(s) to search. If this lpSource handle is NULL, the current process's application image file will be searched. This flag cannot be used with <see cref="FromString"/>.
            /// If the module has no message table resource, the function fails with ERROR_RESOURCE_TYPE_NOT_FOUND.
            /// </summary>
            FromHModule = 0x800,

            /// <summary>
            /// The lpSource parameter is a pointer to a null-terminated string that contains a message definition. The message definition may contain insert sequences, just as the message text in a message table resource may. This flag cannot be used with <see cref="FromHModule"/> or <see cref="FromSystem"/>.
            /// </summary>
            FromString = 0x400,

            /// <summary>
            /// The function should search the system message-table resource(s) for the requested message. If this flag is specified with <see cref="FromHModule"/>, the function searches the system message table if the message is not found in the module specified by lpSource. This flag cannot be used with <see cref="FromString"/>.
            /// If this flag is specified, an application can pass the result of the GetLastError function to retrieve the message text for a system-defined error.
            /// </summary>
            FromSystem = 0x1000,

            /// <summary>
            /// Insert sequences in the message definition are to be ignored and passed through to the output buffer unchanged. This flag is useful for fetching a message for later formatting. If this flag is set, the Arguments parameter is ignored.
            /// </summary>
            IgnoreInserts = 0x200,

            /// <summary>
            /// The function ignores regular line breaks in the message definition text. The function stores hard-coded line breaks in the message definition text into the output buffer. The function generates no new line breaks.
            /// Without this flag set:
            /// There are no output line width restrictions. The function stores line breaks that are in the message definition text into the output buffer.
            /// It specifies the maximum number of characters in an output line. The function ignores regular line breaks in the message definition text. The function never splits a string delimited by white space across a line break. The function stores hard-coded line breaks in the message definition text into the output buffer. Hard-coded line breaks are coded with the %n escape sequence.
            /// </summary>
            MaxWidthMask = 0xff,
        }

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
        /// If the function fails or fails to locate files from the search string in the lpFileName parameter, the return value is INVALID_HANDLE_VALUE and the contents of lpFindFileData are indeterminate.To get extended error information, call the GetLastError function.
        /// </returns>
        [DllImport(nameof(Kernel32))]
        public static extern SafeFindFilesHandle FindFirstFileEx(string lpFileName, FINDEX_INFO_LEVELS fInfoLevelId, out WIN32_FIND_DATA lpFindFileData, FINDEX_SEARCH_OPS fSearchOp, IntPtr lpSearchFilter, FindFirstFileExFlags dwAdditionalFlags);

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
        /// If the function fails, the return value is zero.To get extended error information, call GetLastError.
        /// </returns>
        [DllImport(nameof(Kernel32), CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern int FormatMessage(FormatMessageFlags dwFlags, IntPtr lpSource, uint dwMessageId, uint dwLanguageId, StringBuilder lpBuffer, int nSize, IntPtr[] Arguments);

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

        /// <summary>
        /// Retrieves the thread identifier of the calling thread.
        /// </summary>
        /// <returns>The thread identifier of the calling thread.</returns>
        [DllImport(nameof(Kernel32))]
        public static extern uint GetCurrentThreadId();

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
