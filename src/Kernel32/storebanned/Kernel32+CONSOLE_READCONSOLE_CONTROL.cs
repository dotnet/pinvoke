// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PInvoke
{
    /// <content>
    /// Contains the <see cref="CONSOLE_READCONSOLE_CONTROL"/> nested type.
    /// </content>
    public partial class Kernel32
    {
        /// <summary>
        /// Contains information for a console read operation.
        /// </summary>
        public struct CONSOLE_READCONSOLE_CONTROL
        {
            /// <summary>
            /// The size of the structure. Set this member to <c>sizeof(<see cref="CONSOLE_READCONSOLE_CONTROL"/>)</c>.
            /// </summary>
            public int nLength;

            /// <summary>
            /// The number of characters to skip (and thus preserve) before writing newly read input in the buffer passed to the <see cref="ReadConsole(System.IntPtr, char*, int, out int, CONSOLE_READCONSOLE_CONTROL*)"/>
            /// function. This value must be less than the nNumberOfCharsToRead parameter of the <see cref="ReadConsole(System.IntPtr, char*, int, out int, CONSOLE_READCONSOLE_CONTROL*)"/> function.
            /// </summary>
            public uint nInitialChars;

            /// <summary>
            /// A user-defined control character used to signal that the read is complete.
            /// </summary>
            public uint dwCtrlWakeupMask;

            /// <summary>
            /// The state of the control keys.
            /// </summary>
            public ControlKeyStates dwControlKeyState;

            /// <summary>
            /// Initializes a new instance of the <see cref="CONSOLE_READCONSOLE_CONTROL"/> struct
            /// with the <see cref="nLength"/> field initialized.
            /// </summary>
            /// <returns>The newly initialized struct.</returns>
            public static unsafe CONSOLE_READCONSOLE_CONTROL Create() => new CONSOLE_READCONSOLE_CONTROL { nLength = sizeof(CONSOLE_READCONSOLE_CONTROL) };
        }
    }
}
