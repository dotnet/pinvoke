// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Runtime.InteropServices;

    /// <content>
    /// Contains the <see cref="DISPLAYCONFIG_PIXELFORMAT"/> nested type.
    /// </content>
    public partial class User32
    {
        public enum DISPLAYCONFIG_PIXELFORMAT
        {
            DISPLAYCONFIG_PIXELFORMAT_8BPP = 1,

            DISPLAYCONFIG_PIXELFORMAT_16BPP = 2,

            DISPLAYCONFIG_PIXELFORMAT_24BPP = 3,

            DISPLAYCONFIG_PIXELFORMAT_32BPP = 4,

            DISPLAYCONFIG_PIXELFORMAT_NONGDI = 5,

            DISPLAYCONFIG_PIXELFORMAT_FORCE_UINT32 = -1,
        }
    }
}