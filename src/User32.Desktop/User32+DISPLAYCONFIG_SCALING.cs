// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Runtime.InteropServices;

    /// <content>
    /// Contains the <see cref="DISPLAYCONFIG_SCALING"/> nested type.
    /// </content>
    public partial class User32
    {
        public enum DISPLAYCONFIG_SCALING
        {
            DISPLAYCONFIG_SCALING_IDENTITY = 1,

            DISPLAYCONFIG_SCALING_CENTERED = 2,

            DISPLAYCONFIG_SCALING_STRETCHED = 3,

            DISPLAYCONFIG_SCALING_ASPECTRATIOCENTEREDMAX = 4,

            DISPLAYCONFIG_SCALING_CUSTOM = 5,

            DISPLAYCONFIG_SCALING_PREFERRED = 128,

            DISPLAYCONFIG_SCALING_FORCE_UINT32 = -1,
        }
    }
}
