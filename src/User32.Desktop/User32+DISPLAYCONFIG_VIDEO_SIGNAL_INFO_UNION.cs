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
        public struct DISPLAYCONFIG_VIDEO_SIGNAL_INFO_UNION
        {
            [FieldOffset(0)]
            public DISPLAYCONFIG_ADDITIONAL_SINGAL_INFO AdditionalSignalInfo;

            [FieldOffset(0)]
            public uint videoStandard;
        }
    }
}