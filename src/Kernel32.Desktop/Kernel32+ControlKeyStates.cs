// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;

    /// <content>
    /// Contains the <see cref="ControlKeyStates"/> nested type.
    /// </content>
    public partial class Kernel32
    {
        /// <summary>
        /// Describes the state of the control keys.
        /// </summary>
        [Flags]
        public enum ControlKeyStates
        {
            /// <summary>
            /// The CAPS LOCK light is on.
            /// </summary>
            CAPSLOCK_ON = 0x0080,

            /// <summary>
            /// The key is enhanced.
            /// </summary>
            ENHANCED_KEY = 0x0100,

            /// <summary>
            /// The left ALT key is pressed.
            /// </summary>
            LEFT_ALT_PRESSED = 0x0002,

            /// <summary>
            /// The left CTRL key is pressed.
            /// </summary>
            LEFT_CTRL_PRESSED = 0x0008,

            /// <summary>
            /// The NUM LOCK light is on.
            /// </summary>
            NUMLOCK_ON = 0x0020,

            /// <summary>
            /// The right ALT key is pressed.
            /// </summary>
            RIGHT_ALT_PRESSED = 0x0001,

            /// <summary>
            /// The right CTRL key is pressed.
            /// </summary>
            RIGHT_CTRL_PRESSED = 0x0004,

            /// <summary>
            /// The SCROLL LOCK light is on.
            /// </summary>
            SCROLLLOCK_ON = 0x0040,

            /// <summary>
            /// The SHIFT key is pressed.
            /// </summary>
            SHIFT_PRESSED = 0x0010
        }
    }
}
