// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Runtime.InteropServices;

    /// <content>
    /// Contains the <see cref="DISPLAYCONFIG_MODE_INFO_TYPE"/> nested type.
    /// </content>
    public partial class User32
    {
        public enum DISPLAYCONFIG_MODE_INFO_TYPE
        {
            DISPLAYCONFIG_MODE_INFO_TYPE_SOURCE = 1,

            DISPLAYCONFIG_MODE_INFO_TYPE_TARGET = 2,

            DISPLAYCONFIG_MODE_INFO_TYPE_DESKTOP_IMAGE = 3,

            DISPLAYCONFIG_MODE_INFO_TYPE_FORCE_UINT32 = -1,
        }
    }
}
