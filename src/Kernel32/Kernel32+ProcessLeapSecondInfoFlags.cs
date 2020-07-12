// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PInvoke
{
    using System;

    /// <content>
    /// Contains the <see cref="ProcessLeapSecondInfoFlags"/> nested type.
    /// </content>
    public partial class Kernel32
    {
        /// <summary>
        /// Flags used in <see cref="PROCESS_LEAP_SECOND_INFO.Flags"/> field.
        /// </summary>
        [Flags]
        public enum ProcessLeapSecondInfoFlags : uint
        {
            /// <summary>
            /// No flags
            /// </summary>
            None = 0x0,

            /// <summary>
            /// This value changes the way positive leap seconds are handled by system. Specifically, it changes how the seconds field during a positive
            /// leap second is handled by the system. If this value is used, then the positive leap second will be shown
            /// (For example: 23:59:59 -> 23:59:60 -> 00:00:00. If this value is not used, then "sixty seconds" is disabled, and the 59th second preceding a positive
            /// leap second will be shown for 2 seconds with the milliseconds value ticking twice as slow. So 23:59:59 -> 23:59:59.500 -> 00:00:00, which takes 2
            /// seconds in wall clock time. Disabling "sixty second" can help with legacy apps that do not support seeing the seconds value as 60 during the positive
            /// leap second. Such apps may crash or misbehave. Therefore, in these cases, we display the 59th second for twice as long during the positive leap second.
            /// Note that this setting is per-process, and does not persist if the process is restarted. Developers should test their app for compatibility with seeing
            /// the system return "60", and add a call to their app startup routines to either enable or disable "sixty seconds". "Sixty seconds" is disabled by default
            /// for each process. Obviously, this setting has no effect if leap seconds are disabled system-wide, because then the system will never even encounter a
            /// leap second.
            /// </summary>
            PROCESS_LEAP_SECOND_INFO_FLAG_ENABLE_SIXTY_SECOND = 0x1,
        }
    }
}
