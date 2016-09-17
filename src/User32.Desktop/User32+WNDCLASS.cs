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
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        public unsafe struct WNDCLASS
        {
            public ClassStyles style;

            [MarshalAs(UnmanagedType.FunctionPtr)]
            public WndProc lpfnWndProc;

            public int cbClsExtra;

            public int cbWndExtra;

            public IntPtr hInstance;

            public IntPtr hIcon;

            public IntPtr hCursor;

            public IntPtr hbrBackground;

            public char* lpszMenuName;

            public char* lpszClassName;
        }
    }
}