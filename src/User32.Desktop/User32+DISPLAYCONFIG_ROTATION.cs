// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Runtime.InteropServices;

    /// <content>
    /// Contains the <see cref="DISPLAYCONFIG_ROTATION"/> nested type.
    /// </content>
    public partial class User32
    {
        public enum DISPLAYCONFIG_ROTATION
        {
            DISPLAYCONFIG_ROTATION_IDENTITY = 1,

            DISPLAYCONFIG_ROTATION_ROTATE90 = 2,

            DISPLAYCONFIG_ROTATION_ROTATE180 = 3,

            DISPLAYCONFIG_ROTATION_ROTATE270 = 4,

            DISPLAYCONFIG_ROTATION_FORCE_UINT32 = -1,
        }
    }
}
