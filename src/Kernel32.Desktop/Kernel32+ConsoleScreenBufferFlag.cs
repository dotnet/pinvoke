// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;

    /// <content>
    /// Contains the <see cref="ConsoleScreenBufferFlag"/> nested type.
    /// </content>
    public partial class Kernel32
    {
        /// <summary>
        /// Designates how to create the screen buffer on the <see cref="CreateConsoleScreenBuffer(ACCESS_MASK, FileShare, SECURITY_ATTRIBUTES*, ConsoleScreenBufferFlag, void*)"/> function
        /// </summary>
        public enum ConsoleScreenBufferFlag
        {
            /// <summary>
            /// Creates a default console
            /// </summary>
            None = 0,

            /// <summary>
            /// Creates a console with a text mode buffer
            /// </summary>
            /// <remarks>Actual meaning not documented</remarks>
            CONSOLE_TEXTMODE_BUFFER = 1
        }
    }
}
