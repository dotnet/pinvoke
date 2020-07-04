// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Runtime.InteropServices;

    /// <content>
    /// Contains the <see cref="CURSORINFO"/> nested type.
    /// </content>
    public static partial class User32
    {
        /// <summary>
        /// Contains global cursor information.
        /// </summary>
        public struct CURSORINFO
        {
            /// <summary>
            /// The size of the structure, in bytes. The caller must set this to sizeof(CURSORINFO).
            /// </summary>
            public int cbSize;

            /// <summary>
            /// The cursor state.
            /// </summary>
            public CURSORINFOFlags flags;

            /// <summary>
            /// A handle to the cursor. An HCURSOR. Consider exposing as an <see cref="SafeCursorHandle" />.
            /// </summary>
            public IntPtr hCursor;

            /// <summary>
            /// A structure that receives the screen coordinates of the cursor.
            /// </summary>
            public POINT ptScreenPos;

            /// <summary>
            /// Initializes a new instance of the <see cref="CURSORINFO" /> struct
            /// with the <see cref="cbSize" /> field initialized.
            /// </summary>
            /// <returns>
            /// An instance of the structure.
            /// </returns>
            public static unsafe CURSORINFO Create() => new CURSORINFO { cbSize = sizeof(CURSORINFO) };
        }
    }
}
