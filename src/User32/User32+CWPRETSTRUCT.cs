// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Runtime.InteropServices;

    /// <content>
    /// Contains the <see cref="CWPRETSTRUCT"/> nested type.
    /// </content>
    public partial class User32
    {
        /// <summary>
        /// Defines the message parameters passed to a WH_CALLWNDPROCRET hook procedure, CallWndRetProc.
        /// </summary>
        public struct CWPRETSTRUCT
        {
            /// <summary>
            /// The return value of the window procedure that processed the message specified by the message value.
            /// </summary>
            public IntPtr lResult;

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
            /// A handle to the window that processed the message specified by the message value.
            /// </summary>
            public IntPtr hwnd;
        }
    }
}
