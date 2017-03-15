// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Runtime.InteropServices;

    /// <content>
    /// Contains the <see cref="WINDOW_BUFFER_SIZE_RECORD"/> nested type.
    /// </content>
    public partial class Kernel32
    {
        /// <summary>
        /// Describes a change in the size of the screen buffer in a console <see cref="INPUT_RECORD"/> structure.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct WINDOW_BUFFER_SIZE_RECORD
        {
            /// <summary>
            /// A <see cref="COORD"/> structure that contains the size of the console screen buffer, in character cell columns and rows.
            /// </summary>
            public COORD dwSize;
        }
    }
}
