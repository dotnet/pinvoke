// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Runtime.InteropServices;

    /// <content>
    /// Contains the <see cref="HELPINFO"/> nested type.
    /// </content>
    public partial class User32
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct HELPINFO
        {
            public int cbSize;
            public int iContextType;
            public int iCtrlId;
            public IntPtr hItemHandle;
            public uint dwContextId;
            public POINT MousePos;

            public static HELPINFO Create() => new HELPINFO { cbSize = Marshal.SizeOf(typeof(HELPINFO)) };
        }
    }
}