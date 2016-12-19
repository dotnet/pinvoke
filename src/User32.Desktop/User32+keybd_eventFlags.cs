// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

#pragma warning disable SA1300 // Element documentation must not be copied and pasted

namespace PInvoke
{
    using System;

    /// <content>
    /// Contains the <see cref="keybd_eventFlags"/> nested type.
    /// </content>
    public partial class User32
    {
        /// <summary>Flags for the <see cref="keybd_event(byte, byte, keybd_eventFlags, void*)" /> method.</summary>
        [Flags]
        public enum keybd_eventFlags : uint
        {
            /// <summary>If specified, the scan code was preceded by a prefix byte having the value 0xE0 (224).</summary>
            KEYEVENTF_EXTENDEDKEY = 0x0001,

            /// <summary>If specified, the key is being released. If not specified, the key is being depressed.</summary>
            KEYEVENTF_KEYUP = 0x0002,
        }
    }
}