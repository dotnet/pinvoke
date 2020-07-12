// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PInvoke
{
    using System;

    /// <content>
    /// Contains the <see cref="ConsoleDisplayMode"/> nested type.
    /// </content>
    public partial class Kernel32
    {
        /// <summary>
        /// Designates the console display mode on the <see cref="GetConsoleDisplayMode"/> functions.
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
            CONSOLE_WINDOWED_MODE = 2,
        }
    }
}
