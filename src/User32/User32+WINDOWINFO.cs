// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PInvoke
{
    using System.Runtime.InteropServices;

    /// <content>
    /// Contains the <see cref="WINDOWINFO"/> nested type.
    /// </content>
    public partial class User32
    {
        public struct WINDOWINFO
        {
            public uint cbSize;
            public RECT rcWindow;
            public RECT rcClient;
            public uint dwStyle;
            public uint dwExStyle;
            public uint dwWindowStatus;
            public uint cxWindowBorders;
            public uint cyWindowBorders;
            public ushort atomWindowType;
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
