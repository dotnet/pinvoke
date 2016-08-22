// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.ComponentModel;
    using System.Runtime.InteropServices;
    using System.Text;
    using PInvoke;
    using static Kernel32;

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
        /// <param name="maxLength">The size of the string to return</param>
        /// <returns>The class name string.</returns>
        /// <exception cref="Win32Exception">Thrown when an error occurs.</exception>
        /// <remarks>The suggested class name length is 256 as we didn't find any reference of class name length limits</remarks>
        public static unsafe string GetClassName(IntPtr hWnd, int maxLength = 256)
        {
            char* className = stackalloc char[maxLength];
            int count = GetClassName(hWnd, className, maxLength);
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
            // From MSDN: About Atom Tables - https://msdn.microsoft.com/en-us/library/windows/desktop/ms649053(v=vs.85).aspx
            // The system uses atom tables that are not directly accessible to applications.
            // However, the application uses these atoms when calling a variety of functions.
            // For example, registered clipboard formats are stored in an internal atom table
            // used by the system. An application adds atoms to this atom table using the
            // RegisterClipboardFormat function. Also, registered classes are stored in an
            // internal atom table used by the system. An application adds atoms to this atom table
            // using the RegisterClass or RegisterClassEx function.

            // If we add this knowledge of the internals of this function to the limits we get
            // from registering an Atom with GolbalAddAtom function we see that the limit of
            // the null-terminated string is 255 characters. I placed an extra for the terminating null.
            const int bufferSize = 256;

            char* formatName = stackalloc char[bufferSize]; // max name length
            int count = GetClipboardFormatName(format, formatName, bufferSize);
            if (count == 0)
            {
                throw new Win32Exception();
            }

            return new string(formatName, 0, count);
        }

        /// <summary>
        /// Get the text of the specified window's title bar (if it has one). If the specified window is a control, the
        /// text of the control is returned. However, GetWindowText cannot retrieve the text of a control in another application.
        /// </summary>
        /// <param name="hWnd">A handle to the window or control containing the text.</param>
        /// <returns>
        /// The text of the specified window's title bar. If the specified window is a control, the text of the control is
        /// returned.
        /// </returns>
        public static string GetWindowText(IntPtr hWnd)
        {
            var maxLength = GetWindowTextLength(hWnd);
            if (maxLength == 0)
            {
                var lastError = GetLastError();
                if (lastError != Win32ErrorCode.ERROR_SUCCESS)
                {
                    throw new Win32Exception(lastError);
                }

                return string.Empty;
            }

            var text = new char[maxLength + 1];
            var finalLength = GetWindowText(hWnd, text, maxLength + 1);
            if (finalLength == 0)
            {
                var lastError = GetLastError();
                if (lastError != Win32ErrorCode.ERROR_SUCCESS)
                {
                    throw new Win32Exception(lastError);
                }

                return string.Empty;
            }

            return new string(text, 0, finalLength);
        }

        /// <summary>
        /// Retrieves the position of the mouse cursor, in screen coordinates.
        /// </summary>
        /// <returns>The screen coordinates of the cursor</returns>
        public static unsafe POINT GetCursorPos()
        {
            var result = default(POINT);
            if (!GetCursorPos(&result))
            {
                throw new Win32Exception();
            }

            return result;
        }

        /// <summary>Retrieves the show state and the restored, minimized, and maximized positions of the specified window.</summary>
        /// <param name="hWnd">A handle to the window.</param>
        /// <returns>
        /// A WINDOWPLACEMENT structure with the show state and position information.
        /// </returns>
        public static unsafe WINDOWPLACEMENT GetWindowPlacement(IntPtr hWnd)
        {
            var result = WINDOWPLACEMENT.Create();
            if (!GetWindowPlacement(hWnd, &result))
            {
                throw new Win32Exception();
            }

            return result;
        }
    }
}
