// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Runtime.InteropServices;

    /// <content>
    /// Contains the <see cref="KEYEVENTF"/> nested type.
    /// </content>
    public partial class User32
    {
        /// <summary>
        /// Specifies various aspects of a keystroke. This member can be certain combinations of the following values.
        /// </summary>
        [Flags]
        public enum KEYEVENTF : uint
        {
            /// <summary>
            /// If specified, the scan code was preceded by a prefix byte that has the value 0xE0 (224).
            /// </summary>
            KEYEVENTF_EXTENDED_KEY = 0x0001,

            /// <summary>
            /// If specified, the key is being released. If not specified, the key is being pressed.
            /// </summary>
            KEYEVENTF_KEYUP = 0x0002,

            /// <summary>
            /// If specified, <see cref="KEYBDINPUT.wScan"/> identifies the key and <see cref="KEYBDINPUT.wVk"/> is ignored.
            /// </summary>
            KEYEVENTF_SCANCODE = 0x0008,

            /// <summary>
            /// If specified, the system synthesizes a <see cref="VirtualKey.VK_PACKET"/> keystroke.
            /// The <see cref="KEYBDINPUT.wVk"/> parameter must be zero.
            /// This flag can only be combined with the <see cref="KEYEVENTF_KEYUP"/> flag.
            /// For more information, see the Remarks section.
            /// </summary>
            KEYEVENTF_UNICODE = 0x0004
        }
    }
}