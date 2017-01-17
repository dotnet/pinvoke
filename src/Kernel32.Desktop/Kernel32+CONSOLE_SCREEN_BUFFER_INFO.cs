// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System.Runtime.InteropServices;

    /// <content>
    /// Contains the <see cref="CONSOLE_SCREEN_BUFFER_INFO"/> nested type.
    /// </content>
    public partial class Kernel32
    {
        /// <summary>
        /// Contains information about a console screen buffer.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct CONSOLE_SCREEN_BUFFER_INFO
        {
            /// <summary>
            /// A <see cref="COORD"/> structure that contains the size of the console screen buffer, in character columns and rows.
            /// </summary>
            public COORD dwSize;

            /// <summary>
            /// A <see cref="COORD"/> structure that contains the column and row coordinates of the cursor in the console screen buffer.
            /// </summary>
            public COORD dwCursorPosition;

            /// <summary>
            /// The attributes of the characters written to a screen buffer by the WriteFile and WriteConsole functions,
            /// or echoed to a screen buffer by the ReadFile and ReadConsole functions.
            /// </summary>
            public CharacterAttributesFlags wAttributes;

            /// <summary>
            /// A <see cref="SMALL_RECT"/> structure that contains the console screen buffer coordinates of the upper-left and lower-right corners of the display window.
            /// </summary>
            public SMALL_RECT srWindow;

            /// <summary>
            /// A <see cref="COORD"/> structure that contains the maximum size of the console window, in character columns and rows,
            /// given the current screen buffer size and font and the screen size.
            /// </summary>
            public COORD dwMaximumWindowSize;
        }
    }
}
