// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Runtime.InteropServices;

    /// <content>
    /// Contains the <see cref="DISPLAYCONFIG_PATH_TARGET_INFO"/> nested type.
    /// </content>
    public partial class User32
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct DISPLAYCONFIG_TARGET_MODE_INFO
        {
            public uint bitvector1;

            public uint DesktopModeInfoIdx
            {
                get
                {
                    return this.bitvector1 & 65535u;
                }

                set
                {
                    this.bitvector1 = value | this.bitvector1;
                }
            }

            public uint TargetModeInfoIdx
            {
                get
                {
                    return (this.bitvector1 & 4294901760u) / 65536;
                }

                set
                {
                    this.bitvector1 = (value * 65536) | this.bitvector1;
                }
            }
        }
    }
}