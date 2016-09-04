// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.namespace PInvoke{    using System;    using System.Runtime.InteropServices;    /// <content>    /// Contains the <see cref="MSG"/> nested type.    /// </content>    public partial class User32    {        /// <summary>
        /// Contains message information from a thread's message queue.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct MSG
        {
            /// <summary>
            /// A handle to the window whose window procedure receives the message. This member is <see cref="IntPtr.Zero" /> when
            /// the message is a thread message.
            /// </summary>
            public IntPtr hwnd;

            /// <summary>
            /// The message identifier. Applications can only use the low word; the high word is reserved by the system.
            /// </summary>
            public WindowMessage message;

            /// <summary>
            /// Additional information about the message. The exact meaning depends on the value of the message member.
            /// </summary>
            public IntPtr wParam;

            /// <summary>
            /// Additional information about the message. The exact meaning depends on the value of the message member.
            /// </summary>
            public IntPtr lParam;

            /// <summary>
            /// The time at which the message was posted.
            /// </summary>
            public int time;

            /// <summary>
            /// The cursor position, in screen coordinates, when the message was posted.
            /// </summary>
            public POINT pt;
        }    }}