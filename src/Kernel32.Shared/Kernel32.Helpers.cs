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

        public static unsafe uint WriteFile(SafeObjectHandle hFile, void* lpBuffer, uint nNumberOfBytesToWrite)
        {
            var bytesWritten = (NullableUInt32)0;
            if (!WriteFile(hFile, lpBuffer, nNumberOfBytesToWrite, bytesWritten, null))
            {
                throw new Win32Exception();
            }

            return (uint)bytesWritten;
        }

        public static uint WriteFile(SafeObjectHandle hFile, ArraySegment<byte> lpBuffer)
        {
            unsafe
            {
                fixed (byte* pBuffer = lpBuffer.Array)
                {
                    var pStart = pBuffer + lpBuffer.Offset;
                    return WriteFile(hFile, pStart, (uint)lpBuffer.Count);
                }
            }
        }

        public static unsafe uint ReadFile(SafeObjectHandle hFile, void* lpBuffer, uint nNumberOfBytesToRead)
        {
            var bytesRead = (NullableUInt32)0;
            if (!ReadFile(hFile, lpBuffer, nNumberOfBytesToRead, bytesRead, null))
            {
                throw new Win32Exception();
            }

            return (uint)bytesRead;
        }

        public static uint ReadFile(SafeObjectHandle hFile, ArraySegment<byte> lpBuffer)
        {
            unsafe
            {
                fixed (byte* pBuffer = lpBuffer.Array)
                {
                    var pStart = pBuffer + lpBuffer.Offset;
                    return ReadFile(hFile, pStart, (uint)lpBuffer.Count);
                }
            }
        }

        public static ArraySegment<byte> ReadFile(SafeObjectHandle hFile, uint nNumberOfBytesToRead)
        {
            var buffer = new byte[nNumberOfBytesToRead];
            var segment = new ArraySegment<byte>(buffer);

            var bytesRead = ReadFile(hFile, segment);
            return new ArraySegment<byte>(buffer, 0, (int)bytesRead);
        }
    }
}
