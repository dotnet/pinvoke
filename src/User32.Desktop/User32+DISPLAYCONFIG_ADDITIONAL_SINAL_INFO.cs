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
        public struct DISPLAYCONFIG_ADDITIONAL_SINGAL_INFO
        {
            public uint bitvector1;

            public uint VideoStandard
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

            public uint VSyncFreqDivider
            {
                get
                {
                    return (this.bitvector1 & 4128768u) / 65536;
                }

                set
                {
                    this.bitvector1 = (value * 65536) | this.bitvector1;
                }
            }

            public uint Reserved
            {
                get
                {
                    return (this.bitvector1 & 4290772992u) / 4194304;
                }

                set
                {
                    this.bitvector1 = (value * 4194304) | this.bitvector1;
                }
            }
        }
    }
}