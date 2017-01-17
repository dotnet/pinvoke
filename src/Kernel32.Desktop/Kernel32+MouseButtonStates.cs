// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;

    /// <content>
    /// Contains the <see cref="MouseButtonStates"/> nested type.
    /// </content>
    public partial class Kernel32
    {
        /// <summary>
        /// Describes the state of the mouse buttons.
        /// </summary>
        [Flags]
        public enum MouseButtonStates
        {
            /// <summary>
            /// The leftmost mouse button.
            /// </summary>
            FROM_LEFT_1ST_BUTTON_PRESSED = 0x0001,

            /// <summary>
            /// The second button from the left.
            /// </summary>
            FROM_LEFT_2ND_BUTTON_PRESSED = 0x0004,

            /// <summary>
            /// The third button from the left.
            /// </summary>
            FROM_LEFT_3RD_BUTTON_PRESSED = 0x0008,

            /// <summary>
            /// The fourth button from the left.
            /// </summary>
            FROM_LEFT_4TH_BUTTON_PRESSED = 0x0010,

            /// <summary>
            /// The rightmost mouse button.
            /// </summary>
            RIGHTMOST_BUTTON_PRESSED = 0x0002
        }
    }
}
