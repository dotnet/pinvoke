// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;

    /// <content>
    /// Contains the <see cref="MouseEvents"/> nested type.
    /// </content>
    public partial class Kernel32
    {
        /// <summary>
        /// Describes the type of the mouse event.
        /// </summary>
        [Flags]
        public enum MouseEvents
        {
            /// <summary>
            /// If this is the value, it indicates a mouse button being pressed or released. Otherwise, it takes one of the other values.
            /// </summary>
            None = 0,

            /// <summary>
            /// The second click (button press) of a double-click occurred. The first click is returned as a regular button-press event.
            /// </summary>
            DOUBLE_CLICK = 0x0002,

            /// <summary>
            /// The horizontal mouse wheel was moved.
            /// If the high word of the <see cref="MOUSE_EVENT_RECORD.dwButtonState"/> member contains a positive value,
            /// the wheel was rotated to the right. Otherwise, the wheel was rotated to the left.
            /// </summary>
            MOUSE_HWHEELED = 0x0008,

            /// <summary>
            /// A change in mouse position occurred.
            /// </summary>
            MOUSE_MOVED = 0x0001,

            /// <summary>
            /// The vertical mouse wheel was moved.
            /// If the high word of the <see cref="MOUSE_EVENT_RECORD.dwButtonState"/>  member contains a positive value,
            /// the wheel was rotated forward, away from the user. Otherwise, the wheel was rotated backward, toward the user.
            /// </summary>
            MOUSE_WHEELED = 0x0004
        }
    }
}
