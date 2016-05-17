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
            KEYEVENTF_KEY_DOWN = 0x0000,
            KEYEVENTF_EXTENDED_KEY = 0x0001,
            KEYEVENTF_KEY_UP = 0x0002,
            KEYEVENTF_SCANCODE = 0x0008,
            KEYEVENTF_UNICODE = 0x0004
        }
    }
}