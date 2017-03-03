// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;

    /// <content>
    /// Contains the <see cref="StdHandle"/> nested type.
    /// </content>
    public partial class Kernel32
    {
        /// <summary>
        /// Standard handles for the <see cref="GetStdHandle(StdHandle)"/> and <see cref="SetStdHandle"/> methods.
        /// </summary>
        [Flags]
        public enum StdHandle
        {
            /// <summary>
            /// The standard input device. Initially, this is the console input buffer, CONIN$.
            /// </summary>
            STD_INPUT_HANDLE = -10,

            /// <summary>
            /// The standard output device. Initially, this is the active console screen buffer, CONOUT$.
            /// </summary>
            STD_OUTPUT_HANDLE = -11,

            /// <summary>
            /// The standard error device. Initially, this is the active console screen buffer, CONOUT$.
            /// </summary>
            STD_ERROR_HANDLE = -12,
        }
    }
}
