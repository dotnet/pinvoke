// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Runtime.InteropServices;

    /// <content>
    /// Contains the <see cref="DISPLAYCONFIG_VIDEO_SIGNAL_INFO"/> nested type.
    /// </content>
    public partial class User32
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct DISPLAYCONFIG_ADDITIONAL_SIGNAL_INFO
        {
            private uint bitvector;

            public uint VideoStandard
            {
                get { return this.bitvector & 0xFFFF; }
                set { this.bitvector = value | this.bitvector; }
            }

            public uint VSyncFreqDivider
            {
                get { return (this.bitvector & 0x3F0000) / 0x10000; }
                set { this.bitvector = (value * 0x10000) | this.bitvector; }
            }

            public uint Reserved
            {
                get { return (this.bitvector & 0xFFC00000) / 0x400000; }
                set { this.bitvector = (value * 0x400000) | this.bitvector; }
            }
        }
    }
}