// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;

    /// <content>
    /// Contains the <see cref="ConsoleSelectionFlags"/> nested type.
    /// </content>
    public partial class Kernel32
    {
        /// <summary>
        /// The console selection indicator for <see cref="CONSOLE_SELECTION_INFO.dwFlags"/>
        /// </summary>
        [Flags]
        public enum ConsoleSelectionFlags
        {
            /// <summary>
            /// Mouse is down.
            /// </summary>
            CONSOLE_MOUSE_DOWN = 0x0008,

            /// <summary>
            /// Selecting with the mouse.
            /// </summary>
            CONSOLE_MOUSE_SELECTION = 0x0004,

            /// <summary>
            /// No selection.
            /// </summary>
            CONSOLE_NO_SELECTION = 0x0000,

            /// <summary>
            /// Selection has begun.
            /// </summary>
            CONSOLE_SELECTION_IN_PROGRESS = 0x0001,

            /// <summary>
            /// Selection rectangle is not empty.
            /// </summary>
            CONSOLE_SELECTION_NOT_EMPTY = 0x0002
        }
    }
}