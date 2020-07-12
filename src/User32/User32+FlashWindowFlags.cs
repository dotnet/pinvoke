// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PInvoke
{
    /// <content>
    /// Contains the <see cref="FlashWindowFlags"/> nested type.
    /// </content>
    public partial class User32
    {
        /// <summary>The flash status stored in <see cref="FLASHWINFO" /> and used in <see cref="FlashWindowEx" />.</summary>
        public enum FlashWindowFlags
        {
            /// <summary>
            ///     Flash both the window caption and taskbar button. This is equivalent to setting the FLASHW_CAPTION |
            ///     FLASHW_TRAY flags.
            /// </summary>
            FLASHW_ALL = 0x00000003,

            /// <summary>Flash the window caption.</summary>
            FLASHW_CAPTION = 0x00000001,

            /// <summary>Stop flashing. The system restores the window to its original state.</summary>
            FLASHW_STOP = 0,

            /// <summary>Flash continuously, until the <see cref="FLASHW_STOP" /> flag is set.</summary>
            FLASHW_TIMER = 0x00000004,

            /// <summary>Flash continuously until the window comes to the foreground.</summary>
            FLASHW_TIMERNOFG = 0x0000000C,

            /// <summary>Flash the taskbar button.</summary>
            FLASHW_TRAY = 0x00000002,
        }
    }
}
