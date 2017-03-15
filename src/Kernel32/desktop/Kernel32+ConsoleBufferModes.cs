// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;

    /// <content>
    /// Contains the <see cref="ConsoleBufferModes"/> nested type.
    /// </content>
    public partial class Kernel32
    {
        /// <summary>
        /// Designates the console buffer mode on the <see cref="GetConsoleMode(IntPtr, out ConsoleBufferModes)"/> and <see cref="SetConsoleMode(IntPtr, ConsoleBufferModes)"/> functions
        /// </summary>
        [Flags]
        public enum ConsoleBufferModes
        {
            /// <summary>
            /// CTRL+C is processed by the system and is not placed in the input buffer.
            /// If the input buffer is being read by <see cref="ReadFile(SafeObjectHandle, void*, int)"/> or <see cref="ReadConsole(IntPtr, void*, int, int, IntPtr)"/>,
            /// other control keys are processed by the system and are not returned in the <see cref="ReadFile(SafeObjectHandle, void*, int)"/> or <see cref="ReadConsole(IntPtr, void*, int, int, IntPtr)"/> buffer.
            /// If the <see cref="ENABLE_LINE_INPUT"/> mode is also enabled, backspace, carriage return, and line feed characters are handled by the system.
            /// </summary>
            ENABLE_PROCESSED_INPUT = 0x0001,

            /// <summary>
            /// Characters written by the <see cref="WriteFile(SafeObjectHandle, void*, int)"/> or <see cref="WriteConsole(IntPtr, void*, int, int*, IntPtr)"/> function
            /// or echoed by the <see cref="ReadFile(SafeObjectHandle, void*, int)"/> or <see cref="ReadConsole(IntPtr, void*, int, int, IntPtr)"/> function are parsed for ASCII control sequences, and the correct action is performed.
            /// Backspace, tab, bell, carriage return, and line feed characters are processed.
            /// </summary>
            ENABLE_PROCESSED_OUTPUT = 0x0001,

            /// <summary>
            /// The <see cref="ReadFile(SafeObjectHandle, void*, int)"/> or <see cref="ReadConsole(IntPtr, void*, int, int, IntPtr)"/> function returns only when a carriage return character is read.
            /// If this mode is disabled, the functions return when one or more characters are available.
            /// </summary>
            ENABLE_LINE_INPUT = 0x0002,

            /// <summary>
            /// When writing with <see cref="WriteFile(SafeObjectHandle, void*, int)"/> or <see cref="WriteConsole(IntPtr, void*, int, int*, IntPtr)"/> or echoing with <see cref="ReadFile(SafeObjectHandle, void*, int)"/> or <see cref="ReadConsole(IntPtr, void*, int, int, IntPtr)"/>,
            /// the cursor moves to the beginning of the next row when it reaches the end of the current row. This causes the rows displayed in the console window to scroll up automatically when the cursor advances beyond the last row in the window.
            /// It also causes the contents of the console screen buffer to scroll up (discarding the top row of the console screen buffer) when the cursor advances beyond the last row in the console screen buffer.
            /// If this mode is disabled, the last character in the row is overwritten with any subsequent characters.
            /// </summary>
            ENABLE_WRAP_AT_EOL_OUTPUT = 0x0002,

            /// <summary>
            /// Characters read by the <see cref="ReadFile(SafeObjectHandle, void*, int)"/> or <see cref="ReadConsole(IntPtr, void*, int, int, IntPtr)"/> function are written to the active screen buffer as they are read.
            /// This mode can be used only if the <see cref="ENABLE_LINE_INPUT"/> mode is also enabled.
            /// </summary>
            ENABLE_ECHO_INPUT = 0x0004,

            /// <summary>
            /// When writing with <see cref="WriteFile(SafeObjectHandle, void*, int)"/> or <see cref="WriteConsole(IntPtr, void*, int, int*, IntPtr)"/>, characters are parsed for VT100 and similar control character sequences that control cursor movement,
            /// color/font mode, and other operations that can also be performed via the existing Console APIs.
            /// </summary>
            ENABLE_VIRTUAL_TERMINAL_PROCESSING = 0x0004,

            /// <summary>
            /// User interactions that change the size of the console screen buffer are reported in the console's input buffer.
            /// Information about these events can be read from the input buffer by applications using the <see cref="ReadConsoleInput"/> function, but not by those using <see cref="ReadFile(SafeObjectHandle, void*, int)"/> or <see cref="ReadConsole(IntPtr, void*, int, int, IntPtr)"/>.
            /// </summary>
            ENABLE_WINDOW_INPUT = 0x0008,

            /// <summary>
            /// When writing with <see cref="WriteFile(SafeObjectHandle, void*, int)"/> or <see cref="WriteConsole(IntPtr, void*, int, int*, IntPtr)"/>, this adds an additional state to end-of-line wrapping that can delay the cursor move and buffer scroll operations.
            /// Normally when <see cref="ENABLE_WRAP_AT_EOL_OUTPUT"/> is set and text reaches the end of the line, the cursor will immediately move to the next line and the contents of the buffer will scroll up by one line. In contrast with this flag set,
            /// the scroll operation and cursor move is delayed until the next character arrives. The written character will be printed in the final position on the line and the cursor will remain above this character as if <see cref="ENABLE_WRAP_AT_EOL_OUTPUT"/> was off,
            /// but the next printable character will be printed as if ENABLE_WRAP_AT_EOL_OUTPUT is on. No overwrite will occur. Specifically, the cursor quickly advances down to the following line, a scroll is performed if necessary, the character is printed, and the cursor advances one more position.
            /// The typical usage of this flag is intended in conjunction with setting ENABLE_VIRTUAL_TERMINAL_PROCESSING to better emulate a terminal emulator where writing the final character on the screen (in the bottom right corner) without triggering an immediate scroll is the desired behavior.
            /// </summary>
            DISABLE_NEWLINE_AUTO_RETURN = 0x0008,

            /// <summary>
            /// If the mouse pointer is within the borders of the console window and the window has the keyboard focus, mouse events generated by mouse movement and button presses are placed in the input buffer.
            /// These events are discarded by <see cref="ReadFile(SafeObjectHandle, void*, int)"/> or <see cref="ReadConsole(IntPtr, void*, int, int, IntPtr)"/>, even when this mode is enabled.
            /// </summary>
            ENABLE_MOUSE_INPUT = 0x0010,

            /// <summary>
            /// The APIs for writing character attributes including <see cref="WriteConsoleOutput(IntPtr, CHAR_INFO*, COORD, COORD, SMALL_RECT*)"/> and WriteConsoleOutputAttribute allow the usage of flags from character attributes to adjust the color of the foreground and background of text.
            /// Additionally, a range of DBCS flags was specified with the COMMON_LVB prefix. Historically, these flags only functioned in DBCS code pages for Chinese, Japanese, and Korean languages.
            /// With exception of the leading byte and trailing byte flags, the remaining flags describing line drawing and reverse video (swap foreground and background colors) can be useful for other languages to emphasize portions of output.
            /// Setting this console mode flag will allow these attributes to be used in every code page on every language.
            /// It is off by default to maintain compatibility with known applications that have historically taken advantage of the console ignoring these flags on non-CJK machines to store bits in these fields for their own purposes or by accident.
            /// Note that using the <see cref="ENABLE_VIRTUAL_TERMINAL_PROCESSING"/> mode can result in LVB grid and reverse video flags being set while this flag is still off if the attached application requests underlining or inverse video via Console Virtual Terminal Sequences.
            /// </summary>
            ENABLE_LVB_GRID_WORLDWIDE = 0x0010,

            /// <summary>
            /// When enabled, text entered in a console window will be inserted at the current cursor location and all text following that location will not be overwritten.
            /// When disabled, all following text will be overwritten.
            /// </summary>
            ENABLE_INSERT_MODE = 0x0020,

            /// <summary>
            /// This flag enables the user to use the mouse to select and edit text.
            /// </summary>
            ENABLE_QUICK_EDIT_MODE = 0x0040,
        }
    }
}
