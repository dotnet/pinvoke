// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Runtime.InteropServices;

    /// <content>
    /// Contains the <see cref="DISPLAYCONFIG_RATIONAL"/> nested type.
    /// </content>
    public partial class User32
    {
        public struct DISPLAYCONFIG_RATIONAL
        {
            public uint Numerator;

            public uint Denominator;
        }
    }
}
