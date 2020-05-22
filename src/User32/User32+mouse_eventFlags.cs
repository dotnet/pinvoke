// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PInvoke
{
    using System;

    /// <content>
    /// Contains the <see cref="mouse_eventFlags"/> nested type.
    /// </content>
    public partial class User32
    {
        /// <summary>
        /// Controls various aspects of mouse motion and button clicking.
        /// </summary>
        [Flags]
#pragma warning disable SA1300 // Element must begin with upper-case letter
        public enum mouse_eventFlags : uint
#pragma warning restore SA1300 // Element must begin with upper-case letter
        {
            /// <summary>
            /// The dx and dy parameters contain normalized absolute coordinates. If not set, those parameters contain relative data: the change in position since the last reported position. This flag can be set, or not set, regardless of what kind of mouse or mouse-like device, if any, is connected to the system. For further information about relative mouse motion, see the following Remarks section.
            /// </summary>
            MOUSEEVENTF_ABSOLUTE = 0x8000,

            /// <summary>
            /// The left button is down.
            /// </summary>
            MOUSEEVENTF_LEFTDOWN = 0x0002,

            /// <summary>
            /// The left button is up.
            /// </summary>
            MOUSEEVENTF_LEFTUP = 0x0004,

            /// <summary>
            /// The middle button is down.
            /// </summary>
            MOUSEEVENTF_MIDDLEDOWN = 0x0020,

            /// <summary>
            /// The middle button is up.
            /// </summary>
            MOUSEEVENTF_MIDDLEUP = 0x0040,

            /// <summary>
            /// Movement occurred.
            /// </summary>
            MOUSEEVENTF_MOVE = 0x0001,

            /// <summary>
            /// The right button is down.
            /// </summary>
            MOUSEEVENTF_RIGHTDOWN = 0x0008,

            /// <summary>
            /// The right button is up.
            /// </summary>
            MOUSEEVENTF_RIGHTUP = 0x0010,

            /// <summary>
            /// The wheel has been moved, if the mouse has a wheel. The amount of movement is specified in dwData
            /// </summary>
            MOUSEEVENTF_WHEEL = 0x0800,

            /// <summary>
            /// An X button was pressed.
            /// </summary>
            MOUSEEVENTF_XDOWN = 0x0080,

            /// <summary>
            /// An X button was released.
            /// </summary>
            MOUSEEVENTF_XUP = 0x0100,

            /// <summary>
            /// The wheel button is tilted.
            /// </summary>
            MOUSEEVENTF_HWHEEL = 0x01000,
        }
    }
}
