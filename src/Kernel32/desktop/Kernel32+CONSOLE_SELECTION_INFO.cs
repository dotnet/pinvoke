// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System.Runtime.InteropServices;

    /// <content>
    /// Contains the <see cref="CONSOLE_SELECTION_INFO"/> nested type.
    /// </content>
    public partial class Kernel32
    {
        /// <summary>
        /// Contains information for a console selection.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct CONSOLE_SELECTION_INFO
        {
            /// <summary>
            /// The selection indicator.
            /// </summary>
            public ConsoleSelectionFlags dwFlags;

            /// <summary>
            /// A <see cref="COORD"/> structure that specifies the selection anchor, in characters.
            /// </summary>
            public COORD dwSelectionAnchor;

            /// <summary>
            /// A <see cref="SMALL_RECT"/> structure that specifies the selection rectangle.
            /// </summary>
            public SMALL_RECT srSelection;
        }
    }
}
