// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Runtime.InteropServices;

    /// <content>
    /// Contains the <see cref="WINDOWINFO"/> nested type.
    /// </content>
    public partial class User32
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct WINDOWINFO
        {
            public ushort atomWindowType;
            public uint cbSize;
            public uint cxWindowBorders;
            public uint cyWindowBorders;
            public uint dwExStyle;
            public uint dwStyle;
            public uint dwWindowStatus;
            public RECT rcClient;
            public RECT rcWindow;
            public ushort wCreatorVersion;

            public static WINDOWINFO Create()
            {
                var nw = default(WINDOWINFO);
                nw.cbSize = (uint)Marshal.SizeOf(typeof(WINDOWINFO));
                return nw;
            }
        }
    }
}
