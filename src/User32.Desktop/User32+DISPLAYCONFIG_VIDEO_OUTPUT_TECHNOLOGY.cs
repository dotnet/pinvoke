// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Runtime.InteropServices;

    /// <content>
    /// Contains the <see cref="DISPLAYCONFIG_VIDEO_OUTPUT_TECHNOLOGY"/> nested type.
    /// </content>
    public partial class User32
    {
        public enum DISPLAYCONFIG_VIDEO_OUTPUT_TECHNOLOGY
        {
            DISPLAYCONFIG_OUTPUT_TECHNOLOGY_OTHER = -1,

            DISPLAYCONFIG_OUTPUT_TECHNOLOGY_HD15 = 0,

            DISPLAYCONFIG_OUTPUT_TECHNOLOGY_SVIDEO = 1,

            DISPLAYCONFIG_OUTPUT_TECHNOLOGY_COMPOSITE_VIDEO = 2,

            DISPLAYCONFIG_OUTPUT_TECHNOLOGY_COMPONENT_VIDEO = 3,

            DISPLAYCONFIG_OUTPUT_TECHNOLOGY_DVI = 4,

            DISPLAYCONFIG_OUTPUT_TECHNOLOGY_HDMI = 5,

            DISPLAYCONFIG_OUTPUT_TECHNOLOGY_LVDS = 6,

            DISPLAYCONFIG_OUTPUT_TECHNOLOGY_D_JPN = 8,

            DISPLAYCONFIG_OUTPUT_TECHNOLOGY_SDI = 9,

            DISPLAYCONFIG_OUTPUT_TECHNOLOGY_DISPLAYPORT_EXTERNAL = 10,

            DISPLAYCONFIG_OUTPUT_TECHNOLOGY_DISPLAYPORT_EMBEDDED = 11,

            DISPLAYCONFIG_OUTPUT_TECHNOLOGY_UDI_EXTERNAL = 12,

            DISPLAYCONFIG_OUTPUT_TECHNOLOGY_UDI_EMBEDDED = 13,

            DISPLAYCONFIG_OUTPUT_TECHNOLOGY_SDTVDONGLE = 14,

            DISPLAYCONFIG_OUTPUT_TECHNOLOGY_MIRACAST = 15,

            DISPLAYCONFIG_OUTPUT_TECHNOLOGY_INTERNAL = -2147483648,

            DISPLAYCONFIG_OUTPUT_TECHNOLOGY_FORCE_UINT32 = -1,
        }
    }
}
