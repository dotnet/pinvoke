// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PInvoke
{
    using System;

    [Flags]
    public enum FriendlyFlags
    {
        Array = 0x1,

        In = 0x2,

        Out = 0x4,

        Optional = 0x8,

        /// <summary>
        /// Represents a native integer whose size is platform specific, i.e., 32-bits on 32-bit h/w and OS, and
        /// 64-bits on 64-bit h/w and OS.
        /// </summary>
        /// <remarks>Intended for use on <see cref="IntPtr"/> or <see cref="UIntPtr"/></remarks>
        NativeInt = 0x16,

        Bidirectional = In | Out,
    }
}
