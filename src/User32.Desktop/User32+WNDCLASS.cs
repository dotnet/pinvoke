// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Runtime.InteropServices;

    /// <content>
    /// Contains the <see cref="WNDCLASS"/> nested type.
    /// </content>
    public partial class User32
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct WNDCLASS
        {
            public int cbClsExtra;
            public int cbWndExtra;
            public IntPtr hbrBackground;
            public IntPtr hCursor;
            public IntPtr hIcon;
            public IntPtr hInstance;

            [MarshalAs(UnmanagedType.FunctionPtr)]
            public WndProc lpfnWndProc;

            [MarshalAs(UnmanagedType.LPTStr)]
            public string lpszClassName;

            [MarshalAs(UnmanagedType.LPTStr)]
            public string lpszMenuName;

            public ClassStyles style;
        }
    }
}