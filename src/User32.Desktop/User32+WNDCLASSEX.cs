// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Runtime.InteropServices;

    /// <content>
    /// Contains the <see cref="WNDCLASSEX"/> nested type.
    /// </content>
    public partial class User32
    {
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        public unsafe struct WNDCLASSEX
        {
            public int cbSize;

            public ClassStyles style;

            [MarshalAs(UnmanagedType.FunctionPtr)]
            public WndProc lpfnWndProc;

            public int cbClsExtra;

            public int cbWndExtra;

            public IntPtr hInstance;

            public IntPtr hIcon;

            public IntPtr hCursor;

            public IntPtr hbrBackground;

            public char* lpszClassName;

            public char* lpszMenuName;

            public IntPtr hIconSm;

            public static WNDCLASSEX Create()
            {
                var nw = default(WNDCLASSEX);
                nw.cbSize = Marshal.SizeOf(typeof(WNDCLASSEX));
                return nw;
            }
        }
    }
}
