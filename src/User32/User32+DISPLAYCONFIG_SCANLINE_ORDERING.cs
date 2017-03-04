// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Runtime.InteropServices;

    /// <content>
    /// Contains the <see cref="DISPLAYCONFIG_SCANLINE_ORDERING"/> nested type.
    /// </content>
    public partial class User32
    {
        public enum DISPLAYCONFIG_SCANLINE_ORDERING
        {
            DISPLAYCONFIG_SCANLINE_ORDERING_UNSPECIFIED = 0,

            DISPLAYCONFIG_SCANLINE_ORDERING_PROGRESSIVE = 1,

            DISPLAYCONFIG_SCANLINE_ORDERING_INTERLACED = 2,

            DISPLAYCONFIG_SCANLINE_ORDERING_INTERLACED_UPPERFIELDFIRST = DISPLAYCONFIG_SCANLINE_ORDERING_INTERLACED,

            DISPLAYCONFIG_SCANLINE_ORDERING_INTERLACED_LOWERFIELDFIRST = 3,

            DISPLAYCONFIG_SCANLINE_ORDERING_FORCE_UINT32 = -1,
        }
    }
}