// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PInvoke
{
    /// <content>
    /// Contains the <see cref="CURSORINFOFlags"/> nested type.
    /// </content>
    public static partial class User32
    {
        /// <summary>
        /// Flags for the <see cref="CURSORINFO.flags" /> field.
        /// </summary>
        public enum CURSORINFOFlags
        {
            /// <summary>The cursor is hidden.</summary>
            CURSOR_HIDDEN = 0,

            /// <summary>The cursor is showing.</summary>
            CURSOR_SHOWING = 1,

            /// <summary>
            /// Windows 8: The cursor is suppressed. This flag indicates that the system is not drawing the cursor because the user is providing input through touch or pen instead of the mouse.
            /// </summary>
            CURSOR_SUPPRESSED = 2,
        }
    }
}
