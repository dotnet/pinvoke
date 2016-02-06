// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Runtime.InteropServices;

    /// <summary>
    /// Exported functions from the Gdi32.dll Windows library.
    /// </summary>
    public static partial class Gdi32
    {
        /// <summary>
        /// The GetDeviceCaps function retrieves device-specific information for the specified device.
        /// </summary>
        /// <param name="hdc">A handle to the DC.</param>
        /// <param name="nIndex">The item to be returned.</param>
        /// <returns>
        /// The return value specifies the value of the desired item.
        /// When nIndex is BITSPIXEL and the device has 15bpp or 16bpp, the return value is 16.
        /// </returns>
        [DllImport(nameof(Gdi32), SetLastError = false)]
        public static extern int GetDeviceCaps(
            User32.SafeDCHandle hdc,
            int nIndex);

        [DllImport(nameof(Gdi32))]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool DeleteObject(IntPtr hObject);
    }
}
