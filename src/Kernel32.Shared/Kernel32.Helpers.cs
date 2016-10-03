// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Runtime.InteropServices;
    using System.Text;

    /// <content>
    /// Methods and nested types that are not strictly P/Invokes but provide
    /// a slightly higher level of functionality to ease calling into native code.
    /// </content>
    public static partial class Kernel32
    {
        /// <summary>
        /// Formats a message string. The function requires a message definition as input. The message definition can come from a buffer passed into the function. It can come from a message table resource in an already-loaded module. Or the caller can ask the function to search the system's message table resource(s) for the message definition. The function finds the message definition in a message table resource based on a message identifier and a language identifier. The function copies the formatted message text to an output buffer, processing any embedded insert sequences if requested.
        /// </summary>
        /// <param name="dwFlags">
        /// The formatting options, and how to interpret the lpSource parameter. The low-order byte of dwFlags specifies how the function handles line breaks in the output buffer. The low-order byte can also specify the maximum width of a formatted output line.
        /// The <see cref="FormatMessageFlags.FORMAT_MESSAGE_ARGUMENT_ARRAY"/> flag is always added
        /// and the <see cref="FormatMessageFlags.FORMAT_MESSAGE_ALLOCATE_BUFFER"/> flag is always suppressed by this helper method
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
        /// <param name="Arguments">
        /// An array of values that are used as insert values in the formatted message. A %1 in the format string indicates the first value in the Arguments array; a %2 indicates the second argument; and so on.
        /// The interpretation of each value depends on the formatting information associated with the insert in the message definition.The default is to treat each value as a pointer to a null-terminated string.
        /// By default, the Arguments parameter is of type va_list*, which is a language- and implementation-specific data type for describing a variable number of arguments.The state of the va_list argument is undefined upon return from the function.To use the va_list again, destroy the variable argument list pointer using va_end and reinitialize it with va_start.
        /// If you do not have a pointer of type va_list*, then specify the FORMAT_MESSAGE_ARGUMENT_ARRAY flag and pass a pointer to an array of DWORD_PTR values; those values are input to the message formatted as the insert values.Each insert must have a corresponding element in the array.
        /// </param>
        /// <param name="maxAllowedBufferSize">The maximum size of the returned string. If exceeded, <c>null</c> is returned.</param>
        /// <returns>
        /// If the function succeeds, the return value is the number of TCHARs stored in the output buffer, excluding the terminating null character.
        /// If the function fails, the return value is zero. To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        public static unsafe string FormatMessage(FormatMessageFlags dwFlags, void* lpSource, int dwMessageId, int dwLanguageId, IntPtr[] Arguments, int maxAllowedBufferSize)
        {
            string errorMsg;

            var sb = new StringBuilder(256);
            do
            {
                if (TryGetErrorMessage(dwFlags, lpSource, dwMessageId, dwLanguageId, sb, Arguments, out errorMsg))
                {
                    return errorMsg;
                }
                else
                {
                    if (GetLastError() == Win32ErrorCode.ERROR_INSUFFICIENT_BUFFER)
                    {
                        // increase the capacity of the StringBuilder by 4 times.
                        sb.Capacity *= 4;
                    }
                    else
                    {
                        // No message with the given ID was found, or some other error occurred.
                        return null;
                    }
                }
            }
            while (sb.Capacity < maxAllowedBufferSize);

            // If you come here then a size as large as 65K is also not sufficient.
            return null;
        }

        /// <summary>
        ///     Returns the error code returned by the last unmanaged function that was called using platform invoke that has
        ///     the <see cref="DllImportAttribute.SetLastError" /> flag set.
        /// </summary>
        /// <returns>
        ///     The last error code set by a call to the Win32 SetLastError function.
        ///     <para>
        ///         The Return Value section of the documentation for each function that sets the last-error code notes the
        ///         conditions under which the function sets the last-error code. Most functions that set the thread's last-error
        ///         code set it when they fail. However, some functions also set the last-error code when they succeed. If the
        ///         function is not documented to set the last-error code, the value returned by this function is simply the most
        ///         recent last-error code to have been set; some functions set the last-error code to
        ///         <see cref="Win32ErrorCode.ERROR_SUCCESS" /> on success and others do not.
        ///     </para>
        /// </returns>
        /// <remarks>
        ///     This method exists because it is not safe to make a direct platform invoke call to GetLastError to obtain this
        ///     information. If you want to access this error code, you must call <see cref="GetLastError" /> instead of writing
        ///     your own platform invoke definition for GetLastError and calling it. The common language runtime can make internal
        ///     calls to APIs that overwrite the GetLastError maintained by the operating system.
        ///     <para>
        ///         You can use this method to obtain error codes only if you apply the <see cref="DllImportAttribute" /> to the
        ///         method signature and set the <see cref="DllImportAttribute.SetLastError" /> field to true. The process for this
        ///         varies depending upon the source language used: C# and C++ are false by default, but the Declare statement in
        ///         Visual Basic is true.
        ///     </para>
        /// </remarks>
        /// <devremarks>
        ///     See
        ///     https://stackoverflow.com/questions/17918266/winapi-getlasterror-vs-marshal-getlastwin32error/17918729#17918729 for
        ///     more details.
        /// </devremarks>
        public static Win32ErrorCode GetLastError()
        {
            return (Win32ErrorCode)Marshal.GetLastWin32Error();
        }

        /// <summary>Writes data synchronously to the specified file or input/output (I/O) device.</summary>
        /// <param name="hFile">
        ///     A handle to the file or I/O device (for example, a file, file stream, physical disk, volume, console buffer, tape
        ///     drive, socket, communications resource, mailslot, or pipe).
        ///     <para>
        ///         The hFile parameter must have been created with the write access. For more information, see Generic Access
        ///         Rights and File Security and Access Rights.
        ///     </para>
        /// </param>
        /// <param name="lpBuffer">A pointer to the buffer containing the data to be written to the file or device.</param>
        /// <param name="nNumberOfBytesToWrite">
        ///     The number of bytes to be written to the file or device.
        ///     <para>
        ///         A value of zero specifies a null write operation. The behavior of a null write operation depends on the
        ///         underlying file system or communications technology.
        ///     </para>
        /// </param>
        /// <returns>The number of bytes written.</returns>
        /// <exception cref="Win32Exception">Thrown if the native method return false (Write failed).</exception>
        /// <exception cref="ArgumentNullException">If <paramref name="hFile" /> is <see langword="null" />.</exception>
        public static unsafe int WriteFile(SafeObjectHandle hFile, void* lpBuffer, int nNumberOfBytesToWrite)
        {
            if (hFile == null)
            {
                throw new ArgumentNullException(nameof(hFile));
            }

            var bytesWritten = (int?)0;
            if (!WriteFile(hFile, lpBuffer, nNumberOfBytesToWrite, ref bytesWritten, null))
            {
                throw new Win32Exception();
            }

            return bytesWritten.Value;
        }

        /// <summary>Writes data synchronously to the specified file or input/output (I/O) device.</summary>
        /// <param name="hFile">
        ///     A handle to the file or I/O device (for example, a file, file stream, physical disk, volume, console buffer, tape
        ///     drive, socket, communications resource, mailslot, or pipe).
        ///     <para>
        ///         The hFile parameter must have been created with the write access. For more information, see Generic Access
        ///         Rights and File Security and Access Rights.
        ///     </para>
        /// </param>
        /// <param name="lpBuffer">The buffer containing the data to be written to the file or device.</param>
        /// <returns>The number of bytes written.</returns>
        /// <exception cref="Win32Exception">Thrown if the native method return false (Write failed).</exception>
        /// <exception cref="ArgumentNullException">If <paramref name="hFile" /> is <see langword="null" />.</exception>
        public static int WriteFile(SafeObjectHandle hFile, ArraySegment<byte> lpBuffer)
        {
            if (hFile == null)
            {
                throw new ArgumentNullException(nameof(hFile));
            }

            unsafe
            {
                fixed (byte* pBuffer = lpBuffer.Array)
                {
                    var pStart = pBuffer + lpBuffer.Offset;
                    return WriteFile(hFile, pStart, lpBuffer.Count);
                }
            }
        }

        /// <summary>Reads data synchronously from the specified file or input/output (I/O) device.</summary>
        /// <param name="hFile">
        ///     A handle to the device (for example, a file, file stream, physical disk, volume, console buffer,
        ///     tape drive, socket, communications resource, mailslot, or pipe).
        ///     <para>The hFile parameter must have been created with read access.</para>
        /// </param>
        /// <param name="lpBuffer">A pointer to the buffer that receives the data read from a file or device.</param>
        /// <param name="nNumberOfBytesToRead">The maximum number of bytes to be read.</param>
        /// <returns>The number of bytes read.</returns>
        /// <exception cref="Win32Exception">Thrown if the native method return false (Read failed).</exception>
        /// <exception cref="ArgumentNullException">If <paramref name="hFile" /> is <see langword="null" />.</exception>
        public static unsafe int ReadFile(SafeObjectHandle hFile, void* lpBuffer, int nNumberOfBytesToRead)
        {
            if (hFile == null)
            {
                throw new ArgumentNullException(nameof(hFile));
            }

            var bytesRead = (int?)0;
            if (!ReadFile(hFile, lpBuffer, nNumberOfBytesToRead, ref bytesRead, null))
            {
                throw new Win32Exception();
            }

            return bytesRead.Value;
        }

        /// <summary>Reads data synchronously from the specified file or input/output (I/O) device.</summary>
        /// <param name="hFile">
        ///     A handle to the device (for example, a file, file stream, physical disk, volume, console buffer,
        ///     tape drive, socket, communications resource, mailslot, or pipe).
        ///     <para>The hFile parameter must have been created with read access.</para>
        /// </param>
        /// <param name="lpBuffer">A buffer that receives the data read from a file or device.</param>
        /// <returns>The number of bytes read.</returns>
        /// <exception cref="Win32Exception">Thrown if the native method return false (Read failed).</exception>
        /// <exception cref="ArgumentNullException">If <paramref name="hFile" /> is <see langword="null" />.</exception>
        public static int ReadFile(SafeObjectHandle hFile, ArraySegment<byte> lpBuffer)
        {
            unsafe
            {
                fixed (byte* pBuffer = lpBuffer.Array)
                {
                    var pStart = pBuffer + lpBuffer.Offset;
                    return ReadFile(hFile, pStart, lpBuffer.Count);
                }
            }
        }

        /// <summary>Reads data synchronously from the specified file or input/output (I/O) device.</summary>
        /// <param name="hFile">
        ///     A handle to the device (for example, a file, file stream, physical disk, volume, console buffer,
        ///     tape drive, socket, communications resource, mailslot, or pipe).
        ///     <para>The hFile parameter must have been created with read access.</para>
        /// </param>
        /// <param name="nNumberOfBytesToRead">The maximum number of bytes to be read.</param>
        /// <returns>
        ///     The data that has been read. The segment returned might have a size smaller than
        ///     <paramref name="nNumberOfBytesToRead" /> if less bytes than requested have been read.
        /// </returns>
        /// <exception cref="Win32Exception">Thrown if the native method return false (Read failed).</exception>
        /// <exception cref="ArgumentNullException">If <paramref name="hFile" /> is <see langword="null" />.</exception>
        public static ArraySegment<byte> ReadFile(SafeObjectHandle hFile, int nNumberOfBytesToRead)
        {
            var buffer = new byte[nNumberOfBytesToRead];
            var segment = new ArraySegment<byte>(buffer);

            var bytesRead = ReadFile(hFile, segment);
            return new ArraySegment<byte>(buffer, 0, bytesRead);
        }

        /// <summary>
        /// Tries to get the error message text using the supplied buffer.
        /// </summary>
        /// <param name="flags">
        /// The formatting options, and how to interpret the lpSource parameter. The low-order byte of dwFlags specifies how the function handles line breaks in the output buffer. The low-order byte can also specify the maximum width of a formatted output line.
        /// </param>
        /// <param name="source">
        /// The location of the message definition. The type of this parameter depends upon the settings in the <paramref name="flags"/> parameter.
        /// If <see cref="FormatMessageFlags.FORMAT_MESSAGE_FROM_HMODULE"/>: A handle to the module that contains the message table to search.
        /// If <see cref="FormatMessageFlags.FORMAT_MESSAGE_FROM_STRING"/>: Pointer to a string that consists of unformatted message text. It will be scanned for inserts and formatted accordingly.
        /// If neither of these flags is set in dwFlags, then lpSource is ignored.
        /// </param>
        /// <param name="messageId">
        /// The message identifier for the requested message. This parameter is ignored if dwFlags includes <see cref="FormatMessageFlags.FORMAT_MESSAGE_FROM_STRING" />.
        /// </param>
        /// <param name="languageId">
        /// The language identifier for the requested message. This parameter is ignored if dwFlags includes <see cref="FormatMessageFlags.FORMAT_MESSAGE_FROM_STRING"/>.
        /// If you pass a specific LANGID in this parameter, FormatMessage will return a message for that LANGID only.If the function cannot find a message for that LANGID, it sets Last-Error to ERROR_RESOURCE_LANG_NOT_FOUND.If you pass in zero, FormatMessage looks for a message for LANGIDs in the following order:
        /// Language neutral
        /// Thread LANGID, based on the thread's locale value
        /// User default LANGID, based on the user's default locale value
        /// System default LANGID, based on the system default locale value
        /// US English
        /// If FormatMessage does not locate a message for any of the preceding LANGIDs, it returns any language message string that is present.If that fails, it returns ERROR_RESOURCE_LANG_NOT_FOUND.
        /// </param>
        /// <param name="sb">The buffer to use for acquiring the message.</param>
        /// <param name="arguments">
        /// An array of values that are used as insert values in the formatted message. A %1 in the format string indicates the first value in the Arguments array; a %2 indicates the second argument; and so on.
        /// The interpretation of each value depends on the formatting information associated with the insert in the message definition.The default is to treat each value as a pointer to a null-terminated string.
        /// By default, the Arguments parameter is of type va_list*, which is a language- and implementation-specific data type for describing a variable number of arguments.The state of the va_list argument is undefined upon return from the function.To use the va_list again, destroy the variable argument list pointer using va_end and reinitialize it with va_start.
        /// If you do not have a pointer of type va_list*, then specify the FORMAT_MESSAGE_ARGUMENT_ARRAY flag and pass a pointer to an array of DWORD_PTR values; those values are input to the message formatted as the insert values.Each insert must have a corresponding element in the array.
        /// </param>
        /// <param name="errorMsg">Receives the resulting error message.</param>
        /// <returns><c>true</c> if the attempt is successful; <c>false</c> otherwise.</returns>
        private static unsafe bool TryGetErrorMessage(FormatMessageFlags flags, void* source, int messageId, int languageId, StringBuilder sb, IntPtr[] arguments, out string errorMsg)
        {
            errorMsg = string.Empty;
            int result = FormatMessage(
                flags | FormatMessageFlags.FORMAT_MESSAGE_ARGUMENT_ARRAY & ~FormatMessageFlags.FORMAT_MESSAGE_ALLOCATE_BUFFER,
                source,
                messageId,
                languageId,
                sb,
                sb.Capacity + 1,
                arguments);
            if (result > 0)
            {
                int i = sb.Length;
                while (i > 0)
                {
                    char ch = sb[i - 1];
                    if (ch > 32 && ch != '.')
                    {
                        break;
                    }

                    i--;
                }

                errorMsg = sb.ToString(0, i);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
