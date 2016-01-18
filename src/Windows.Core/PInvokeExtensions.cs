// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Runtime.InteropServices;
    using static PInvoke.HResult.FacilityCode;

    /// <summary>
    /// Extension methods for commonly defined types.
    /// </summary>
    public static class PInvokeExtensions
    {
        /// <summary>
        /// Converts an <see cref="NTSTATUS"/> to an <see cref="HResult"/>.
        /// </summary>
        /// <param name="status">The <see cref="NTSTATUS"/> to convert.</param>
        /// <returns>The <see cref="HResult"/>.</returns>
        public static HResult ToHResult(this NTSTATUS status)
        {
            // From winerror.h
            // #define HRESULT_FROM_NT(x)      ((HRESULT) ((x) | FACILITY_NT_BIT))
            return status | (int)FACILITY_NT_BIT;
        }

        /// <summary>
        /// Converts a <see cref="Win32ErrorCode"/> to an <see cref="HResult"/>.
        /// </summary>
        /// <param name="error">The <see cref="Win32ErrorCode"/> to convert.</param>
        /// <returns>The <see cref="HResult"/></returns>
        public static HResult ToHResult(this Win32ErrorCode error)
        {
            // From winerror.h
            //  (HRESULT)(x) <= 0 ? (HRESULT)(x) : (HRESULT) (((x) & 0x0000FFFF) | (FACILITY_WIN32 << 16) | 0x80000000)
            return error <= 0
                ? (HResult)(int)error
                : (HResult)(int)(((int)error & 0x0000ffff) | ((int)FACILITY_WIN32 /*<< 16*/) | 0x80000000);
        }

        /// <summary>
        /// Allocates an array of characters to represent the specified string, with a null terminating character as the last array element.
        /// </summary>
        /// <param name="value">The string to represent as a character array.</param>
        /// <returns>The character array with null terminator.</returns>
        public static char[] ToCharArrayWithNullTerminator(this string value)
        {
            char[] buffer = new char[value.Length + 1];
            value.CopyTo(0, buffer, 0, value.Length);
            return buffer;
        }
    }
}
