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
        [StructLayout(LayoutKind.Sequential)]
        public struct INPUT
        {
            /// <summary>
            /// The type of the input event.
            /// </summary>
            public InputType type;

            /// <summary>
            /// The union of mouse, keyboard and hardware input.
            /// </summary>
            public InputUnion Inputs;

            /// <summary>
            /// Describes some kind of input.
            /// </summary>
            /// <remarks>
            /// This struct is a union where all fields share memory address space.
            /// </remarks>
            /// <devremarks>
            /// From http://www.pinvoke.net/default.aspx/Structures/INPUT.html:
            /// The last 3 fields are a union, which is why they are all at the same memory offset.
            /// On 64-Bit systems, the offset of the <see cref="mi"/>, <see cref="ki"/> and <see cref="hi"/> fields is 8,
            /// because the nested struct uses the alignment of its biggest member, which is 8
            /// (due to the 64-bit pointer in <see cref="KEYBDINPUT.dwExtraInfo"/>).
            /// By separating the union into its own structure, rather than placing the
            /// <see cref="mi"/>, <see cref="ki"/> and <see cref="hi"/> fields directly in the INPUT structure,
            /// we assure that the .NET structure will have the correct alignment on both 32 and 64 bit.
            /// </devremarks>
            [StructLayout(LayoutKind.Explicit)]
            public struct InputUnion
            {
                /// <summary>
                /// The information about a simulated mouse event.
                /// This field shares memory with the <see cref="ki"/> and <see cref="hi"/> fields.
                /// </summary>
                [FieldOffset(0)]
                public MOUSEINPUT mi;

                /// <summary>
                /// The information about a simulated keyboard event.
                /// This field shares memory with the <see cref="mi"/> and <see cref="hi"/> fields.
                /// </summary>
                [FieldOffset(0)]
                public KEYBDINPUT ki;

                /// <summary>
                /// The information about a simulated hardware event.
                /// This field shares memory with the <see cref="mi"/> and <see cref="ki"/> fields.
                /// </summary>
                [FieldOffset(0)]
                public HARDWAREINPUT hi;
            }
        }
    }
}