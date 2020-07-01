// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Runtime.InteropServices;

    /// <content>
    /// Contains the <see cref="DISPLAYCONFIG_2DREGION"/> nested type.
    /// </content>
    public partial class User32
    {
        public struct DISPLAYCONFIG_2DREGION
        {
            public uint cx;

            public uint cy;
        }
    }
}
