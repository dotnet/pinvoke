// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PInvoke;

using System;

[Flags]
public enum FriendlyFlags
{
    /// <summary>
    /// The pointer is to the first element in an array.
    /// </summary>
    Array = 0x1,

    /// <summary>
    /// The value is at least partially initialized by the caller.
    /// </summary>
    In = 0x2,

    /// <summary>
    /// The value is initialized or modified by the p/invoked method.
    /// </summary>
    Out = 0x4,

    /// <summary>
    /// The value is optional. Null is an acceptable pointer value for this parameter.
    /// </summary>
    Optional = 0x8,

    /// <summary>
    /// Represents a native integer whose size is platform specific, i.e., 32-bits on 32-bit h/w and OS, and
    /// 64-bits on 64-bit h/w and OS.
    /// </summary>
    /// <remarks>Intended for use on <see cref="IntPtr"/> or <see cref="UIntPtr"/>.</remarks>
    NativeInt = 0x16,

    /// <summary>
    /// The union of the <see cref="In"/> and <see cref="Out"/> flags,
    /// indicating that the value for this parameter may be at least partially initialized by the caller
    /// and modified by the p/invoked method.
    /// </summary>
    Bidirectional = In | Out,
}
