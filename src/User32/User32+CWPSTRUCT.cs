// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Runtime.InteropServices;

    /// <content>
    /// Contains the <see cref="CWPSTRUCT"/> nested type.
    /// </content>
    public partial class User32
    {
        /// <summary>
        /// Defines the message parameters passed to a WH_CALLWNDPROC hook procedure, CallWndProc.
        /// </summary>
        public struct CWPSTRUCT
        {
            /// <summary>
            /// Additional information about the message. The exact meaning depends on the message value.
            /// </summary>
            public IntPtr lParam;

            /// <summary>
            /// Additional information about the message. The exact meaning depends on the message value.
            /// </summary>
            public IntPtr wParam;

            /// <summary>
            /// The message.
            /// </summary>
            public WindowMessage message;

            /// <summary>
            /// A handle to the window to receive the message.
            /// </summary>
            public IntPtr hwnd;
        }
    }
}
