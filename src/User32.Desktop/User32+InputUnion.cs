// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System.Runtime.InteropServices;

    /// <content>
    /// Contains the <see cref="InputUnion"/> nested type.
    /// </content>
    public partial class User32
    {
        /// <summary>
        /// Union meant to help correctly marshalling <see cref="INPUT" /> with the different input types.
        /// </summary>
        [StructLayout(LayoutKind.Explicit)]
        public struct InputUnion
        {
            /// <summary>
            /// The information about a simulated mouse event.
            /// </summary>
            [FieldOffset(0)]
            public MOUSEINPUT mi;

            /// <summary>
            /// The information about a simulated keyboard event.
            /// </summary>
            [FieldOffset(0)]
            public KEYBDINPUT ki;

            /// <summary>
            /// The information about a simulated hardware event.
            /// </summary>
            [FieldOffset(0)]
            public HARDWAREINPUT hi;
        }
    }
}