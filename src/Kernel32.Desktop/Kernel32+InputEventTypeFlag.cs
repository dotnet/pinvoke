// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Runtime.InteropServices;

    /// <content>
    /// Contains the <see cref="InputEventTypeFlag"/> nested type.
    /// </content>
    public partial class Kernel32
    {
        /// <summary>
        /// A handle to the type of input event and the event record stored in the <see cref="INPUT_RECORD.Event"/> member.
        /// </summary>
        public enum InputEventTypeFlag : short
        {
            /// <summary>
            /// The Event member contains a <see cref="FOCUS_EVENT_RECORD"/> structure. These events are used internally and should be ignored
            /// </summary>
            FOCUS_EVENT = 0x0010,

            /// <summary>
            /// The Event member contains a <see cref="KEY_EVENT_RECORD"/> structure with information about a keyboard event.
            /// </summary>
            KEY_EVENT = 0x0001,

            /// <summary>
            /// The Event member contains a <see cref="MENU_EVENT_RECORD"/> structure. These events are used internally and should be ignored.
            /// </summary>
            MENU_EVENT = 0x0008,

            /// <summary>
            /// The Event member contains a <see cref="MOUSE_EVENT_RECORD"/> structure with information about a mouse movement or button press event.
            /// </summary>
            MOUSE_EVENT = 0x0002,

            /// <summary>
            /// The Event member contains a <see cref="WINDOW_BUFFER_SIZE_RECORD"/> structure with information about the new size of the console screen buffer.
            /// </summary>
            WINDOW_BUFFER_SIZE_EVENT = 0x0004
        }
    }
}
