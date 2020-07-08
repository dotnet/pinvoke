// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Runtime.InteropServices;

    /// <content>
    /// Contains the <see cref="DISPLAYCONFIG_PATH_TARGET_INFO"/> nested type.
    /// </content>
    public partial class User32
    {
        public struct DISPLAYCONFIG_TARGET_MODE_INFO
        {
            private uint bitvector;

            public uint DesktopModeInfoIdx
            {
                get { return this.bitvector & 0xFFFF; }
                set { this.bitvector = value | this.bitvector; }
            }

            public uint TargetModeInfoIdx
            {
                get { return (this.bitvector & 0xFFFF0000) / 0x10000; }
                set { this.bitvector = (value * 0x10000) | this.bitvector; }
            }
        }
    }
}
