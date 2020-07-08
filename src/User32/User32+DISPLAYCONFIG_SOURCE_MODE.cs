// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Runtime.InteropServices;

    /// <content>
    /// Contains the <see cref="DISPLAYCONFIG_SOURCE_MODE"/> nested type.
    /// </content>
    public partial class User32
    {
        public struct DISPLAYCONFIG_SOURCE_MODE
        {
            public uint width;

            public uint height;

            public DISPLAYCONFIG_PIXELFORMAT pixelFormat;

            public POINT position;
        }
    }
}
