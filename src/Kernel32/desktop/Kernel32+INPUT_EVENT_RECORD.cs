// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Runtime.InteropServices;

    /// <content>
    /// Contains the <see cref="INPUT_EVENT_RECORD"/> nested type.
    /// </content>
    public partial class Kernel32
    {
        /// <summary>
        /// The input event information. The format of this member depends on the event type specified by the <see cref="INPUT_RECORD.EventType"/> member.
        /// </summary>
        [StructLayout(LayoutKind.Explicit)]
        public struct INPUT_EVENT_RECORD
        {
            /// <summary>
            /// Structure with information about a keyboard event.
            /// </summary>
            [FieldOffset(0)]
            public KEY_EVENT_RECORD KeyEvent;

            /// <summary>
            /// Structure with information about a mouse movement or button press event.
            /// </summary>
            [FieldOffset(0)]
            public MOUSE_EVENT_RECORD MouseEvent;

            /// <summary>
            /// Structure with information about the new size of the console screen buffer.
            /// </summary>
            [FieldOffset(0)]
            public WINDOW_BUFFER_SIZE_RECORD WindowBufferSizeEvent;

            /// <summary>
            /// These events are used internally and should be ignored.
            /// </summary>
            [FieldOffset(0)]
            public MENU_EVENT_RECORD MenuEvent;

            /// <summary>
            /// These events are used internally and should be ignored.
            /// </summary>
            [FieldOffset(0)]
            public FOCUS_EVENT_RECORD FocusEvent;
        }
    }
}
