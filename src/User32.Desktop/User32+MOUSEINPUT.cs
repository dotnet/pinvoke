// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Runtime.InteropServices;

    /// <content>
    /// Contains the <see cref="MOUSEINPUT"/> nested type.
    /// </content>
    public partial class User32
    {
        /// <summary>
        /// Contains information about a simulated mouse event.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        [OfferIntPtrPropertyAccessors]
        public unsafe partial struct MOUSEINPUT
        {
            /// <summary>
            /// The absolute position of the mouse, or the amount of motion since the last mouse event was generated, depending on the value of the dwFlags member. Absolute data is specified as the x coordinate of the mouse; relative data is specified as the number of pixels moved.
            /// </summary>
            public int dx;

            /// <summary>
            /// The absolute position of the mouse, or the amount of motion since the last mouse event was generated, depending on the value of the dwFlags member. Absolute data is specified as the y coordinate of the mouse; relative data is specified as the number of pixels moved.
            /// </summary>
            public int dy;

            /// <summary>
            /// If dwFlags contains <see cref="MOUSEEVENTF.MOUSEEVENTF_WHEEL"/>, then <see cref="mouseData"/> specifies the amount of wheel movement. A positive value indicates that the wheel was rotated forward, away from the user; a negative value indicates that the wheel was rotated backward, toward the user. One wheel click is defined as <see cref="WHEEL_DELTA"/>, which is 120.
            /// If dwFlags does not contain <see cref="MOUSEEVENTF.MOUSEEVENTF_WHEEL"/>, <see cref="MOUSEEVENTF.MOUSEEVENTF_XDOWN"/>, or <see cref="MOUSEEVENTF.MOUSEEVENTF_XUP"/>, then mouseData should be zero.
            /// If dwFlags contains <see cref="MOUSEEVENTF.MOUSEEVENTF_XDOWN"/> or <see cref="MOUSEEVENTF.MOUSEEVENTF_XUP"/>, then mouseData specifies which X buttons were pressed or released.
            /// </summary>
            public uint mouseData;

            /// <summary>
            /// A set of bit flags that specify various aspects of mouse motion and button clicks. The bits in this member can be any reasonable combination of the following values.
            /// See MSDN docs for more info.
            /// </summary>
            public MOUSEEVENTF dwFlags;

            /// <summary>
            /// The time stamp for the event, in milliseconds. If this parameter is 0, the system will provide its own time stamp.
            /// </summary>
            public uint time;

            /// <summary>
            /// An additional value associated with the mouse event. An application calls GetMessageExtraInfo to obtain this extra information.
            /// </summary>
            public void* dwExtraInfo;
        }
    }
}