// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Runtime.InteropServices;

    /// <content>
    /// Contains the <see cref="LASTINPUTINFO"/> nested type.
    /// </content>
    public partial class User32
    {
        /// <summary>
        /// Contains the time of the last input. It is used with the <see cref="GetLastInputInfo(LASTINPUTINFO*)"/> function.
        /// </summary>
        public struct LASTINPUTINFO
        {
            /// <summary>
            /// The size of the structure, in bytes. This member must be set to <c>sizeof(LASTINPUTINFO)</c>.
            /// </summary>
            public int cbSize;

            /// <summary>
            /// The tick count when the last input event was received.
            /// </summary>
            public uint dwTime;

            /// <summary>
            /// Initializes a new instance of the <see cref="LASTINPUTINFO"/> struct.
            /// </summary>
            /// <returns>An initialized instance of the struct.</returns>
            public static unsafe LASTINPUTINFO Create() => new LASTINPUTINFO { cbSize = sizeof(LASTINPUTINFO) };
        }
    }
}
