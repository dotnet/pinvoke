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
        [Flags]
        public enum DISPLAYCONFIG_PATH_SOURCE_INFOFlags
        {
            None = 0,

            /// <summary>
            /// This source is in use by at least one active path.
            /// </summary>
            DISPLAYCONFIG_SOURCE_IN_USE = 0x00000001,
        }

        [StructLayout(LayoutKind.Explicit)]
        public struct DISPLAYCONFIG_PATH_SOURCE_INFO
        {
            [FieldOffset(0)]
            public LUID adapterId;

            [FieldOffset(8)]
            public uint id;

            [FieldOffset(12)]
            public uint modeInfoIdx;

            [FieldOffset(12)]
            public ushort cloneGroupId;

            [FieldOffset(14)]
            public ushort sourceModeInfoIdx;

            [FieldOffset(16)]
            public DISPLAYCONFIG_PATH_SOURCE_INFOFlags statusFlags;
        }
    }
}