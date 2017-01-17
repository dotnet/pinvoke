// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Runtime.InteropServices;

    /// <content>
    /// Contains the <see cref="MOUSE_EVENT_RECORD"/> nested type.
    /// </content>
    public partial class Kernel32
    {
        /// <summary>
        /// Describes a mouse input event in a console <see cref="INPUT_RECORD"/> structure.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct MOUSE_EVENT_RECORD
        {
            /// <summary>
            /// A <see cref="COORD"/> structure that contains the location of the cursor, in terms of the console screen buffer's character-cell coordinates.
            /// </summary>
            public COORD dwMousePosition;

            /// <summary>
            /// The status of the mouse buttons.
            /// </summary>
            public MouseButtonStates dwButtonState;

            /// <summary>
            /// The state of the control keys.
            /// </summary>
            public ControlKeyStates dwControlKeyState;

            /// <summary>
            /// The type of mouse event. If this value is <see cref="MouseEvents.None"/>, it indicates a mouse button being pressed or released.
            /// </summary>
            public MouseEvents dwEventFlags;
        }
    }
}
