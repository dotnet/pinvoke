// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Runtime.InteropServices;

    /// <content>
    /// Contains the <see cref="SpecialWindowHandles"/> nested type.
    /// </content>
    public partial class User32
    {
        /// <summary>
        /// Special window handles
        /// </summary>
        public static class SpecialWindowHandles
        {
            /// <summary>
            /// Places the window at the top of the Z order.
            /// </summary>
            public static readonly IntPtr HWND_TOP = new IntPtr(0);

            /// <summary>
            /// Places the window at the bottom of the Z order. If the hWnd parameter identifies a
            /// topmost window, the window loses its topmost status and is placed at the bottom of all
            /// other windows.
            /// </summary>
            public static readonly IntPtr HWND_BOTTOM = new IntPtr(1);

            /// <summary>
            /// Places the window above all non-topmost windows. The window maintains its topmost
            /// position even when it is deactivated.
            /// </summary>
            public static readonly IntPtr HWND_TOPMOST = new IntPtr(-1);

            /// <summary>
            /// Places the window above all non-topmost windows (that is, behind all topmost windows).
            /// This flag has no effect if the window is already a non-topmost window.
            /// </summary>
            public static readonly IntPtr HWND_NOTOPMOST = new IntPtr(-2);
        }
    }
}