// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Runtime.InteropServices;

    /// <content>
    /// Contains the <see cref="HELPINFO"/> nested type.
    /// </content>
    public partial class User32
    {
        public struct HELPINFO
        {
            public int cbSize;
            public int iContextType;
            public int iCtrlId;
            public IntPtr hItemHandle;
            public uint dwContextId;
            public POINT MousePos;

            public static unsafe HELPINFO Create() => new HELPINFO { cbSize = sizeof(HELPINFO) };
        }
    }
}
