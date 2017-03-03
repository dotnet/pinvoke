// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Runtime.InteropServices;

    /// <content>
    /// Contains the <see cref="INPUT_RECORD"/> nested type.
    /// </content>
    public partial class Kernel32
    {
        /// <summary>
        /// Describes an input event in the console input buffer.
        /// These records can be read from the input buffer by using the <see cref="ReadConsoleInput"/> or <see cref="PeekConsoleInput"/> function,
        /// or written to the input buffer by using the <see cref="WriteConsoleInput(IntPtr, INPUT_RECORD*, int, int*)"/> function.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct INPUT_RECORD
        {
            /// <summary>
            /// A handle to the type of input event and the event record stored in the <see cref="Event"/> member.
            /// </summary>
            public InputEventTypeFlag EventType;

            /// <summary>
            /// The event information. The format of this member depends on the event type specified by the <see cref="EventType"/> member.
            /// </summary>
            public INPUT_EVENT_RECORD Event;
        }
    }
}
