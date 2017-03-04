// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Runtime.InteropServices;

    /// <content>
    /// Contains the <see cref="KEYBDINPUT"/> nested type.
    /// </content>
    public partial class User32
    {
        /// <summary>
        /// Contains information about a simulated keyboard event.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        [OfferIntPtrPropertyAccessors]
        public unsafe partial struct KEYBDINPUT
        {
            /// <summary>
            /// A virtual-key code. The code must be a value in the range 1 to 254. If the dwFlags member specifies KEYEVENTF_UNICODE, wVk must be 0.
            /// </summary>
            public VirtualKey wVk;

            /// <summary>
            /// A hardware scan code for the key.
            /// If <see cref="dwFlags"/> specifies <see cref="KEYEVENTF.KEYEVENTF_UNICODE"/>,
            /// <see cref="wScan"/> specifies a Unicode character which is to be sent to the foreground application.
            /// </summary>
            public ScanCode wScan;

            /// <summary>
            /// Specifies various aspects of a keystroke.
            /// This member can be certain combinations of the following values.
            /// </summary>
            public KEYEVENTF dwFlags;

            /// <summary>
            /// The time stamp for the event, in milliseconds. If this parameter is zero, the system will provide its own time stamp.
            /// </summary>
            public uint time;

            /// <summary>
            /// An additional value associated with the keystroke.
            /// Use the GetMessageExtraInfo function to obtain this information.
            /// </summary>
            public void* dwExtraInfo;
        }
    }
}