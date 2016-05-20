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
            /// The union of three fields.
            /// </summary>
            private InputUnion union;

            /// <summary>
            /// Gets or sets the information about a simulated mouse event.
            /// </summary>
            public MOUSEINPUT mi
            {
                get { return this.union.mi; }
                set { this.union.mi = value; }
            }

            /// <summary>
            /// Gets or sets the information about a simulated keyboard event.
            /// </summary>
            public KEYBDINPUT ki
            {
                get { return this.union.ki; }
                set { this.union.ki = value; }
            }

            /// <summary>
            /// Gets or sets the information about a simulated hardware event.
            /// </summary>
            public HARDWAREINPUT hi
            {
                get { return this.union.hi; }
                set { this.union.hi = value; }
            }
        }
    }
}