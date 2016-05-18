// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.ComponentModel;
    using System.Runtime.InteropServices;
    using PInvoke;

    /// <content>
    /// Methods and nested types that are not strictly P/Invokes but provide
    /// a slightly higher level of functionality to ease calling into native code.
    /// </content>
    public static partial class User32
    {
        /// <summary>
        /// The GetDC function retrieves a handle to a device context (DC) for the client area of a specified window or for the entire screen. You can use the returned handle in subsequent GDI functions to draw in the DC. The device context is an opaque data structure, whose values are used internally by GDI.
        /// The GetDCEx function is an extension to GetDC, which gives an application more control over how and whether clipping occurs in the client area.
        /// </summary>
        /// <param name="hWnd">A handle to the window whose DC is to be retrieved. If this value is NULL, GetDC retrieves the DC for the entire screen.</param>
        /// <returns>
        /// If the function succeeds, the return value is a handle to the DC for the specified window's client area.
        /// If the function fails, the return value is NULL.
        /// </returns>
        public static SafeDCHandle GetDC(IntPtr hWnd)
        {
            var hdc = GetDC_IntPtr(hWnd);
            return hdc != IntPtr.Zero ? new SafeDCHandle(hWnd, hdc) : null;
        }

        /// <summary>
        /// Retrieves the name of the class to which the specified window belongs.
        /// </summary>
        /// <param name = "hWnd">A handle to the window and, indirectly, the class to which the window belongs.</param>
        /// <returns>The class name string.</returns>
        /// <exception cref="Win32Exception">Thrown when an error occurs.</exception>
        public static unsafe string GetClassName(IntPtr hWnd)
        {
            return GetClassName(hWnd, 256);
        }

        /// <summary>
        /// Retrieves the name of the class to which the specified window belongs.
        /// </summary>
        /// <param name = "hWnd">A handle to the window and, indirectly, the class to which the window belongs.</param>
        /// <param name="stringSize">The size of the string to return</param>
        /// <returns>The class name string.</returns>
        /// <exception cref="Win32Exception">Thrown when an error occurs.</exception>
        public static unsafe string GetClassName(IntPtr hWnd, int stringSize)
        {
            char* className = stackalloc char[stringSize]; // max class name length
            int count = GetClassName(hWnd, className, stringSize);
            if (count == 0)
            {
                throw new Win32Exception();
            }

            return new string(className, 0, count);
        }

        /// <summary>
        /// Retrieves from the clipboard the name of the specified registered format.
        /// </summary>
        /// <param name = "format">The type of format to be retrieved. This parameter must not specify any of the predefined clipboard formats.</param>
        /// <returns>The format name string.</returns>
        /// <exception cref="Win32Exception">Thrown when an error occurs.</exception>
        public static unsafe string GetClipboardFormatName(int format)
        {
            const int bufferSize = 256;
            char* formatName = stackalloc char[bufferSize]; // max name length
            int count = GetClipboardFormatName(format, formatName, bufferSize);
            if (count == 0)
            {
                throw new Win32Exception();
            }

            return new string(formatName, 0, count);
        }
    }
}
