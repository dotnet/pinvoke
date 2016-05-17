// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Runtime.InteropServices;

    /// <content>
    /// Contains the <see cref="SECURITY_DESCRIPTOR"/> nested type.
    /// </content>
    public partial class Kernel32
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct SECURITY_DESCRIPTOR
        {
            public byte Revision;
            public byte Sbz1;
            public ushort Control;
            public IntPtr Owner;
            public IntPtr Group;
            public IntPtr Sacl;
            public IntPtr Dacl;
        }
    }
}
