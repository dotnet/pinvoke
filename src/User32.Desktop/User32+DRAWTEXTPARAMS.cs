// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Runtime.InteropServices;

    /// <content>
    /// Contains the <see cref="DRAWTEXTPARAMS"/> nested type.
    /// </content>
    public partial class User32
    {
        /// <summary>
        /// Values to pass to the <see cref="DrawTextEx(SafeDCHandle, char*, int, RECT*, uint, DRAWTEXTPARAMS*)"/> method describing extended formatting options for the text.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct DRAWTEXTPARAMS
        {
            /// <summary>
            /// The structure size, in bytes.
            /// </summary>
            public uint cbSize;

            /// <summary>
            /// The size of each tab stop, in units equal to the average character width.
            /// </summary>
            public int iTabLength;

            /// <summary>
            /// The left margin, in units equal to the average character width.
            /// </summary>
            public int iLeftMargin;

            /// <summary>
            /// The right margin, in units equal to the average character width.
            /// </summary>
            public int iRightMargin;

            /// <summary>
            /// Receives the number of characters processed by <see cref="DrawTextEx(SafeDCHandle, char*, int, RECT*, uint, DRAWTEXTPARAMS*)"/>,
            /// including white-space characters. The number can be the length of the string or the index of the first line that falls below the drawing area.
            /// Note that <see cref="DrawTextEx(SafeDCHandle, char*, int, RECT*, uint, DRAWTEXTPARAMS*)"/> always processes the entire string if the <see cref="TextFormats.DT_NOCLIP"/> formatting flag is specified.
            /// </summary>
            public uint uiLengthDrawn;
        }
    }
}
