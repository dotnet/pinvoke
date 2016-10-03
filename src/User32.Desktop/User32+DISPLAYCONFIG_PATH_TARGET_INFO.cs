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
        [Flags]
        public enum DISPLAYCONFIG_PATH_TARGET_INFOFlags
        {
            None = 0x0,
            DISPLAYCONFIG_TARGET_IN_USE = 0x00000001,
            DISPLAYCONFIG_TARGET_FORCIBLE = 0x00000002,
            DISPLAYCONFIG_TARGET_FORCED_AVAILABILITY_BOOT = 0x00000004,
            DISPLAYCONFIG_TARGET_FORCED_AVAILABILITY_PATH = 0x00000008,
            DISPLAYCONFIG_TARGET_FORCED_AVAILABILITY_SYSTEM = 0x00000010,
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct DISPLAYCONFIG_PATH_TARGET_INFO
        {
            public LUID adapterId;

            public uint id;

            public DISPLAYCONFIG_TARGET_MODE_INFO targetModeInfo;

            public DISPLAYCONFIG_VIDEO_OUTPUT_TECHNOLOGY outputTechnology;

            public DISPLAYCONFIG_ROTATION rotation;

            public DISPLAYCONFIG_SCALING scaling;

            public DISPLAYCONFIG_RATIONAL refreshRate;

            public DISPLAYCONFIG_SCANLINE_ORDERING scanLineOrdering;

            [MarshalAs(UnmanagedType.Bool)]
            public bool targetAvailable;

            public DISPLAYCONFIG_PATH_TARGET_INFOFlags statusFlags;
        }
    }
}