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
        public struct DISPLAYCONFIG_VIDEO_SIGNAL_INFO
        {
            public ulong pixelRate;

            public DISPLAYCONFIG_RATIONAL hSyncFreq;

            public DISPLAYCONFIG_RATIONAL vSyncFreq;

            public DISPLAYCONFIG_2DREGION activeSize;

            public DISPLAYCONFIG_2DREGION totalSize;

            public DISPLAYCONFIG_VIDEO_SIGNAL_INFO_UNION signalInfo;

            public DISPLAYCONFIG_SCANLINE_ORDERING scanLineOrdering;
        }
    }
}