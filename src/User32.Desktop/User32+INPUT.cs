// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

#pragma warning disable SA1300 // Element must begin with upper-case letter

namespace PInvoke
{
    using System.Runtime.InteropServices;

    /// <content>
    /// Contains the <see cref="INPUT"/> nested type.
    /// </content>
    public partial class User32
    {
        /// <summary>
        /// Used by <see cref="SendInput(int, INPUT*, int)"/> to store information for synthesizing input events such as keystrokes, mouse movement, and mouse clicks.
        /// </summary>
        [StructLayout(LayoutKind.Explicit)]
        public struct INPUT
        {
            /// <summary>
            /// The type of the input event.
            /// </summary>
            [FieldOffset(0)]
            public InputType type;

            /// <summary>
            /// The information about a simulated mouse event.
            /// This field shares memory with the <see cref="ki"/> and <see cref="hi"/> fields.
            /// </summary>
            [FieldOffset(4)]
            public MOUSEINPUT mi;

            /// <summary>
            /// The information about a simulated keyboard event.
            /// This field shares memory with the <see cref="mi"/> and <see cref="hi"/> fields.
            /// </summary>
            [FieldOffset(4)]
            public KEYBDINPUT ki;

            /// <summary>
            /// The information about a simulated hardware event.
            /// This field shares memory with the <see cref="mi"/> and <see cref="ki"/> fields.
            /// </summary>
            [FieldOffset(4)]
            public HARDWAREINPUT hi;
        }
    }
}