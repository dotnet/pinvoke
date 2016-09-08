// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Runtime.InteropServices;

    /// <content>
    /// Contains the <see cref="DISPLAYCONFIG_TOPOLOGY_ID"/> nested type.
    /// </content>
    public partial class User32
    {
        public enum DISPLAYCONFIG_TOPOLOGY_ID
        {
            DISPLAYCONFIG_TOPOLOGY_INTERNAL = 1,

            DISPLAYCONFIG_TOPOLOGY_CLONE = 2,

            DISPLAYCONFIG_TOPOLOGY_EXTEND = 4,

            DISPLAYCONFIG_TOPOLOGY_EXTERNAL = 8,

            DISPLAYCONFIG_TOPOLOGY_FORCE_UINT32 = -1,
        }
    }
}
