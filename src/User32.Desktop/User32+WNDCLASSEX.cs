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
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public struct WNDCLASSEX
        {
            public int cbClsExtra;

            [MarshalAs(UnmanagedType.U4)]
            public int cbSize;

            public int cbWndExtra;

            public IntPtr hbrBackground;

            public IntPtr hCursor;

            public IntPtr hIcon;

            public IntPtr hIconSm;

            public IntPtr hInstance;

            public IntPtr lpfnWndProc;

            public string lpszClassName;

            public string lpszMenuName;

            [MarshalAs(UnmanagedType.U4)]
            public int style;

            public static WNDCLASSEX Build()
            {
                var nw = default(WNDCLASSEX);
                nw.cbSize = Marshal.SizeOf(typeof(WNDCLASSEX));
                return nw;
            }
        }
    }
}
