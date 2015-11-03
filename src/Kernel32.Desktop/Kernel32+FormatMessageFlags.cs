// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;

    /// <content>
    /// Contains the <see cref="FormatMessageFlags"/> nested enum.
    /// </content>
    public partial class Kernel32
    {
        /// <summary>
        /// Flags passed to the <see cref="FormatMessage"/> method.
        /// </summary>
        [Flags]
        public enum FormatMessageFlags
        {
            /// <summary>
            /// The function allocates a buffer large enough to hold the formatted message, and places a pointer to the allocated buffer at the address specified by lpBuffer. The nSize parameter specifies the minimum number of TCHARs to allocate for an output message buffer. The caller should use the LocalFree function to free the buffer when it is no longer needed.
            /// If the length of the formatted message exceeds 128K bytes, then FormatMessage will fail and a subsequent call to <see cref="GetLastError"/> will return <see cref="Win32ErrorCode.ERROR_MORE_DATA"/>.
            /// In previous versions of Windows, this value was not available for use when compiling Windows Store apps. As of Windows 10 this value can be used.
            /// Windows Server 2003 and Windows XP:
            /// If the length of the formatted message exceeds 128K bytes, then FormatMessage will not automatically fail with an error of <see cref="Win32ErrorCode.ERROR_MORE_DATA"/>.
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
            /// If the module has no message table resource, the function fails with <see cref="Win32ErrorCode.ERROR_RESOURCE_TYPE_NOT_FOUND"/>.
            /// </summary>
            FromHModule = 0x800,

            /// <summary>
            /// The lpSource parameter is a pointer to a null-terminated string that contains a message definition. The message definition may contain insert sequences, just as the message text in a message table resource may. This flag cannot be used with <see cref="FromHModule"/> or <see cref="FromSystem"/>.
            /// </summary>
            FromString = 0x400,

            /// <summary>
            /// The function should search the system message-table resource(s) for the requested message. If this flag is specified with <see cref="FromHModule"/>, the function searches the system message table if the message is not found in the module specified by lpSource. This flag cannot be used with <see cref="FromString"/>.
            /// If this flag is specified, an application can pass the result of the <see cref="GetLastError"/> function to retrieve the message text for a system-defined error.
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
    }
}
