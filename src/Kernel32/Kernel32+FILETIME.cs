// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Runtime.InteropServices;

    /// <content>
    /// Contains the <see cref="FILETIME"/> nested type.
    /// </content>
    public partial class Kernel32
    {
        /// <summary>
        /// A 64-bit representation of a file timestamp.
        /// </summary>
        /// <remarks>
        /// This type is equivalent to <see cref="System.Runtime.InteropServices.ComTypes.FILETIME"/>.
        /// We couldn't use that type directly even though it's in the portable profile because
        /// Xamarin.Android and Xamarin.iOS omit the type and it causes link failures.
        /// See https://github.com/dotnet/pinvoke/issues/232
        /// </remarks>
        public struct FILETIME
        {
            /// <summary>
            /// Specifies the low 32 bits of the FILETIME.
            /// </summary>
            public int dwLowDateTime;

            /// <summary>
            /// Specifies the high 32 bits of the FILETIME.
            /// </summary>
            public int dwHighDateTime;

            /// <summary>
            /// Initializes a new instance of the <see cref="FILETIME"/> struct.
            /// </summary>
            /// <param name="dateTime">The DateTime to initialize to.</param>
            public FILETIME(DateTime dateTime)
            {
                if (!SystemTimeToFileTime(dateTime, out FILETIME temp))
                {
                    throw new Win32Exception();
                }

                this.dwLowDateTime = temp.dwLowDateTime;
                this.dwHighDateTime = temp.dwHighDateTime;
            }

            /// <summary>
            /// Convert to <see cref="long"/> to ease interop with <see cref="System.TimeSpan"/> or <see cref="System.DateTime"/>
            /// </summary>
            /// <param name="fileTime"> The fileTime structure to be converted to long.</param>
            public static implicit operator long(FILETIME fileTime)
            {
                return ((long)fileTime.dwHighDateTime << 32) + (uint)fileTime.dwLowDateTime;
            }

            /// <summary>
            /// Creates a <see cref="DateTime"/> value that represents the same time as this value.
            /// </summary>
            /// <param name="fileTime">The value to be converted.</param>
            public static explicit operator DateTime(FILETIME fileTime)
            {
                if (!FileTimeToSystemTime(fileTime, out SYSTEMTIME st))
                {
                    throw new Win32Exception();
                }

                return new DateTime(st.wYear, st.wMonth, st.wDay, st.wHour, st.wMinute, st.wSecond, st.wMilliseconds);
            }
        }
    }
}
