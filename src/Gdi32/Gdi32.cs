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
        /// When nIndex is <see cref="DeviceCap.BITSPIXEL"/> and the device has 15bpp or 16bpp, the return value is 16.
        /// </returns>
        [DllImport(nameof(Gdi32), SetLastError = false)]
        public static extern int GetDeviceCaps(
            User32.SafeDCHandle hdc,
            DeviceCap nIndex);

        /// <summary>
        /// The GetDeviceCaps function retrieves device-specific information for the specified device.
        /// </summary>
        /// <param name="hdc">A handle to the DC.</param>
        /// <param name="nIndex">The item to be returned.</param>
        /// <returns>
        /// The return value specifies the value of the desired item.
        /// When nIndex is BITSPIXEL (12) and the device has 15bpp or 16bpp, the return value is 16.
        /// </returns>
        [DllImport(nameof(Gdi32), SetLastError = false)]
        public static extern int GetDeviceCaps(
            User32.SafeDCHandle hdc,
            int nIndex);

        [DllImport(nameof(Gdi32))]
        public static extern IntPtr GetStockObject(StockObject fnObject);

        [DllImport(nameof(Gdi32))]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool DeleteObject(IntPtr hObject);

        [DllImport(nameof(Gdi32))]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool DeleteDC(User32.SafeDCHandle hDC);

        [DllImport(nameof(Gdi32))]
        public static extern IntPtr SelectObject(User32.SafeDCHandle hDC, IntPtr hObject);

        [DllImport(nameof(Gdi32))]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool BitBlt(IntPtr hObject, int nXDest, int nYDest, int nWidth, int nHeight, IntPtr hObjectSource, int nXSrc, int nYSrc, int dwRop);

        [DllImport(nameof(Gdi32))]
        public static extern IntPtr CreateCompatibleBitmap(User32.SafeDCHandle hDC, int nWidth, int nHeight);

        [DllImport(nameof(Gdi32))]
        public static extern User32.SafeDCHandle CreateCompatibleDC(User32.SafeDCHandle hDC);
    }
}
