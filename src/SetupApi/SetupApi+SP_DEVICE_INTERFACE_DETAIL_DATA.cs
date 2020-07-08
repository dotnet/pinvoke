// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Runtime.InteropServices;

    /// <content>
    /// Contains the <see cref="SP_DEVICE_INTERFACE_DETAIL_DATA"/> nested type.
    /// </content>
    public partial class SetupApi
    {
        /// <summary>
        /// An SP_DEVICE_INTERFACE_DETAIL_DATA structure contains the path for a device interface.
        /// </summary>
        public unsafe struct SP_DEVICE_INTERFACE_DETAIL_DATA
        {
            /// <summary>
            /// The size, in bytes, of the <see cref="SP_DEVICE_INTERFACE_DETAIL_DATA"/> structure.
            /// </summary>
            /// <remarks>
            /// This member always contains the size of the fixed part of the data structure, not a size reflecting the
            /// variable-length string at the end.
            /// </remarks>
            public int cbSize;

            /// <summary>
            /// A NULL-terminated string that contains the device interface path. This path can be passed to Win32 functions such as CreateFile.
            /// </summary>
            public fixed char DevicePath[1];

            /// <summary>
            /// Gets the value that should be set to the <see cref="cbSize"/> field.
            /// </summary>
            /// <remarks>
            /// The structure size take into account an Int32 and a character.
            /// The character can be 1 or 2 octets depending on ANSI / Unicode,
            /// leading to a total struct size of 5 or 6 bytes.
            /// But on 64-bit OS, we report 8 bytes due to memory alignment.
            /// </remarks>
            public static int ReportableStructSize => IntPtr.Size == 4 ? 4 + Marshal.SystemDefaultCharSize : 8;

            /// <summary>
            /// Gets the full string pointed to by <see cref="DevicePath"/>.
            /// </summary>
            /// <param name="pSelf">
            /// Note that this must be the original struct that was initialized by native memory.
            /// It cannot be copied first as interop will not copy any more than the first character.
            /// </param>
            /// <returns>The full string.</returns>
            /// <remarks>
            /// This is a static method rather than an instance method to try to avoid the easy
            /// mistake of calling the method on an instance that was copied.
            /// </remarks>
            public static string GetDevicePath(SP_DEVICE_INTERFACE_DETAIL_DATA* pSelf)
            {
                return Marshal.PtrToStringUni(new IntPtr(pSelf->DevicePath));
            }
        }
    }
}
