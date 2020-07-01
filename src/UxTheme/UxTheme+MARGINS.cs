// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Runtime.InteropServices;

    /// <content>
    /// Contains the <see cref="MARGINS"/> nested type.
    /// </content>
    public partial class UxTheme
    {
        /// <summary>
        /// Returned by the <see cref="GetThemeMargins(SafeThemeHandle, User32.SafeDCHandle, int, int, int, RECT*, out MARGINS)"/> function to define the margins of windows that have visual styles applied.
        /// </summary>
        public struct MARGINS
        {
            /// <summary>
            /// Width of the left border that retains its size.
            /// </summary>
            public int cxLeftWidth;

            /// <summary>
            /// Width of the right border that retains its size.
            /// </summary>
            public int cxRightWidth;

            /// <summary>
            /// Height of the top border that retains its size.
            /// </summary>
            public int cyTopHeight;

            /// <summary>
            /// Height of the bottom border that retains its size.
            /// </summary>
            public int cyBottomHeight;
        }
    }
}
