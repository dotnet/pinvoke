// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Runtime.InteropServices;

    /// <content>
    /// Contains the <see cref="DISPLAYCONFIG_DESKTOP_IMAGE_INFO"/> nested type.
    /// </content>
    public partial class User32
    {
        public struct DISPLAYCONFIG_DESKTOP_IMAGE_INFO
        {
            public POINT PathSourceSize;

            public RECT DesktopImageRegion;

            public RECT DesktopImageClip;
        }
    }
}
