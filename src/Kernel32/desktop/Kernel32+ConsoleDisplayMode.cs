// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;

    /// <content>
    /// Contains the <see cref="ConsoleDisplayMode"/> nested type.
    /// </content>
    public partial class Kernel32
    {
        /// <summary>
        /// Designates the console display mode on the <see cref="GetConsoleDisplayMode"/> functions
        /// </summary>
        public enum ConsoleDisplayMode
        {
            /// <summary>
            /// Text is displayed in full-screen mode.
            /// </summary>
            CONSOLE_FULLSCREEN_MODE = 1,

            /// <summary>
            /// Text is displayed in a console window.
            /// </summary>
            CONSOLE_WINDOWED_MODE = 2
        }
    }
}
