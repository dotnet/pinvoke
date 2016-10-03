// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Runtime.InteropServices;

    /// <content>
    /// Contains the <see cref="DISPLAYCONFIG_PATH_SOURCE_INFO"/> nested type.
    /// </content>
    public partial class User32
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct DISPLAYCONFIG_PATH_SOURCE_INFO
        {
            public LUID adapterId;

            public uint id;

            public DISPLAYCONFIG_MODE_GROUP_UNION modeGroup;

            public DISPLAYCONFIG_PATH_SOURCE_INFOFlags statusFlags;
        }

        [Flags]
        public enum DISPLAYCONFIG_PATH_SOURCE_INFOFlags
        {
            None = 0,

            /// <summary>
            /// This source is in use by at least one active path.
            /// </summary>
            DISPLAYCONFIG_SOURCE_IN_USE = 0x00000001,
        }
    }
}