// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System.Runtime.InteropServices;

    /// <content>
    /// Contains the <see cref="DISPLAYCONFIG_SOURCE_MODE_INFO"/> nested type.
    /// </content>
    public partial class User32
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct DISPLAYCONFIG_SOURCE_MODE_INFO
        {
            private uint bitvector1;

            public uint CloneGroupId
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

            public uint SourceModeInfoIdx
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