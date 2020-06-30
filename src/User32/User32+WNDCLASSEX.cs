// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Runtime.InteropServices;

    /// <content>
    /// Contains the <see cref="WNDCLASSEX"/> nested type.
    /// </content>
    public partial class User32
    {
        /// <summary>
        /// Contains window class information. It is used with the <see cref="RegisterClassEx"/> and <see cref="GetClassInfoEx"/> functions.
        /// The <see cref="WNDCLASSEX"/> structure is similar to the <see cref="WNDCLASS"/> structure. There are two differences. <see cref="WNDCLASSEX"/> includes the <see cref="cbSize"/> member, which specifies the size of the structure, and the <see cref="hIconSm"/> member, which contains a handle to a small icon associated with the window class.
        /// </summary>
        [OfferIntPtrPropertyAccessors]
        public unsafe partial struct WNDCLASSEX
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

            public char* lpszMenuName;

            public char* lpszClassName;

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
