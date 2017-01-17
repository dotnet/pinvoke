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
        [StructLayout(LayoutKind.Explicit)]
        public struct DISPLAYCONFIG_VIDEO_SIGNAL_INFO
        {
            [FieldOffset(0)]
            public ulong pixelRate;

            [FieldOffset(8)]
            public DISPLAYCONFIG_RATIONAL hSyncFreq;

            [FieldOffset(16)]
            public DISPLAYCONFIG_RATIONAL vSyncFreq;

            [FieldOffset(24)]
            public DISPLAYCONFIG_2DREGION activeSize;

            [FieldOffset(32)]
            public DISPLAYCONFIG_2DREGION totalSize;

            [FieldOffset(40)]
            public DISPLAYCONFIG_ADDITIONAL_SIGNAL_INFO AdditionalSignalInfo;

            [FieldOffset(40)]
            public uint videoStandard;

            [FieldOffset(44)]
            public DISPLAYCONFIG_SCANLINE_ORDERING scanLineOrdering;
        }
    }
}