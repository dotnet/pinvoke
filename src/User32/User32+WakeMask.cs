// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PInvoke
{
    using System;

    /// <content>Contains the <see cref="WakeMask" /> nested type.</content>
    public partial class User32
    {
        /// <summary>
        /// The mask passed to <see cref="MsgWaitForMultipleObjectsEx(uint, IntPtr, uint, WakeMask, MsgWaitForMultipleObjectsExFlags)"/>.
        /// </summary>
        [Flags]
        public enum WakeMask : uint
        {
            /// <summary>
            /// An input, <see cref="WindowMessage.WM_TIMER" />, <see cref="WindowMessage.WM_PAINT" />, <see cref="WindowMessage.WM_HOTKEY" />, or posted message is in the queue.
            /// This value is a combination of <see cref="QS_INPUT" />, <see cref="QS_POSTMESSAGE" />, <see cref="QS_TIMER" />, <see cref="QS_PAINT" />, and <see cref="QS_HOTKEY" />.
            /// </summary>
            QS_ALLEVENTS = 0x04BF,

            /// <summary>
            /// Any message is in the queue.
            /// This value is a combination of <see cref="QS_INPUT" />, <see cref="QS_POSTMESSAGE" />, <see cref="QS_TIMER" />, <see cref="QS_PAINT" />, <see cref="QS_HOTKEY" />, and <see cref="QS_SENDMESSAGE" />.
            /// </summary>
            QS_ALLINPUT = 0x04FF,

            /// <summary>
            /// A posted message is in the queue.
            /// This value is cleared when you call <see cref="GetMessage(MSG*, IntPtr, WindowMessage, WindowMessage)"/> or <see cref="PeekMessage(MSG*, IntPtr, WindowMessage, WindowMessage, PeekMessageRemoveFlags)"/> without filtering messages.
            /// </summary>
            QS_ALLPOSTMESSAGE = 0x0100,

            /// <summary>
            /// A <see cref="WindowMessage.WM_HOTKEY"/> message is in the queue.
            /// </summary>
            QS_HOTKEY = 0x0080,

            /// <summary>
            /// An input message is in the queue.
            /// This value is a combination of <see cref="QS_MOUSE" />, <see cref="QS_KEY" />, and <see cref="QS_RAWINPUT" />.
            /// </summary>
            QS_INPUT = 0x0407,

            /// <summary>
            /// A <see cref="WindowMessage.WM_KEYUP" />, <see cref="WindowMessage.WM_KEYDOWN" />, <see cref="WindowMessage.WM_SYSKEYUP" />, or <see cref="WindowMessage.WM_SYSKEYDOWN " />message is in the queue.
            /// </summary>
            QS_KEY = 0x0001,

            /// <summary>
            /// A <see cref="WindowMessage.WM_MOUSEMOVE"/> message or mouse-button message (<see cref="WindowMessage.WM_LBUTTONUP"/>, <see cref="WindowMessage.WM_RBUTTONDOWN"/>, and so on).
            /// This value is a combination of <see cref="QS_MOUSEMOVE"/> and <see cref="QS_MOUSEBUTTON"/>.
            /// </summary>
            QS_MOUSE = QS_MOUSEMOVE | QS_MOUSEBUTTON,

            /// <summary>
            /// A mouse-button message (<see cref="WindowMessage.WM_LBUTTONUP"/>, <see cref="WindowMessage.WM_RBUTTONDOWN"/>, and so on).
            /// </summary>
            QS_MOUSEBUTTON = 0x0004,

            /// <summary>
            /// A <see cref="WindowMessage.WM_MOUSEMOVE"/> message is in the queue.
            /// </summary>
            QS_MOUSEMOVE = 0x0002,

            /// <summary>
            /// A <see cref="WindowMessage.WM_PAINT"/> message is in the queue.
            /// </summary>
            QS_PAINT = 0x0020,

            /// <summary>
            /// A posted message is in the queue.
            /// This value is cleared when you call <see cref="GetMessage(MSG*, IntPtr, WindowMessage, WindowMessage)"/> or <see cref="PeekMessage(MSG*, IntPtr, WindowMessage, WindowMessage, PeekMessageRemoveFlags)"/>, whether or not you are filtering messages.
            /// </summary>
            QS_POSTMESSAGE = 0x0008,

            /// <summary>
            /// A raw input message is in the queue. For more information, see Raw Input.
            /// </summary>
            QS_RAWINPUT = 0x0400,

            /// <summary>
            /// A message sent by another thread or application is in the queue.
            /// </summary>
            QS_SENDMESSAGE = 0x0040,

            /// <summary>
            /// A <see cref="WindowMessage.WM_TIMER"/> message is in the queue.
            /// </summary>
            QS_TIMER = 0x0010,
        }
    }
}
