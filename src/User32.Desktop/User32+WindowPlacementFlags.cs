// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;

    /// <content>Contains the <see cref="WindowPlacementFlags" /> nested type.</content>
    public partial class User32
    {
        /// <summary>Flags for the flags member of <see cref="WINDOWPLACEMENT" /> structure.</summary>
        [Flags]
        public enum WindowPlacementFlags
        {
            None = 0x0000,

            /// <summary>
            /// The coordinates of the minimized window may be specified.
            /// <para>
            /// This flag must be specified if the coordinates are set in the <see cref="WINDOWPLACEMENT.ptMinPosition" />
            /// member.
            /// </para>
            /// </summary>
            WPF_SETMINPOSITION = 0x001,

            /// <summary>
            /// The restored window will be maximized, regardless of whether it was maximized before it was minimized. This setting is
            /// only valid the next time the window is restored. It does not change the default restoration behavior.
            /// <para>
            /// This flag is only valid when the <see cref="WindowShowStyle.SW_SHOWMINIMIZED" /> value is specified for the
            /// <see cref="WINDOWPLACEMENT.showCmd" /> member.
            /// </para>
            /// </summary>
            WPF_RESTORETOMAXIMIZED = 0x002,

            /// <summary>
            /// If the calling thread and the thread that owns the window are attached to different input queues, the system
            /// posts the request to the thread that owns the window. This prevents the calling thread from blocking its execution
            /// while other threads process the request.
            /// </summary>
            WPF_ASYNCWINDOWPLACEMENT = 0x004
        }
    }
}