// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Runtime.InteropServices;

    /// <content>
    /// Methods and nested types that are not strictly P/Invokes but provide
    /// a slightly higher level of functionality to ease calling into native code.
    /// </content>
    public static partial class Kernel32
    {
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

            var bytesWritten = (NullableUInt32)0;
            if (!WriteFile(hFile, lpBuffer, nNumberOfBytesToWrite, bytesWritten, null))
            {
                throw new Win32Exception();
            }

            return (int)bytesWritten.Value;
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

            var bytesRead = (NullableUInt32)0;
            if (!ReadFile(hFile, lpBuffer, nNumberOfBytesToRead, bytesRead, null))
            {
                throw new Win32Exception();
            }

            return (int)bytesRead.Value;
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
    }
}
