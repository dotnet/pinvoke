// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Runtime.InteropServices;

    /// <content>
    /// Contains the <see cref="DWM_BLURBEHIND"/> nested type.
    /// </content>
    public partial class DwmApi
    {
        /// <summary>
        /// Specifies Desktop Window Manager (DWM) blur-behind properties. Used by the <see cref="DwmEnableBlurBehindWindow(IntPtr, DWM_BLURBEHIND*)"/> function.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public partial struct DWM_BLURBEHIND
        {
            /// <summary>
            /// A bitwise combination of <see cref="DWM_BLURBEHINDFlags"/> constant values that indicates which of the members of this structure have been set.
            /// </summary>
            public DWM_BLURBEHINDFlags dwFlags;

            /// <summary>
            /// TRUE to register the window handle to DWM blur behind; FALSE to unregister the window handle from DWM blur behind.
            /// </summary>
            public byte fEnable;

            /// <summary>
            /// The region within the client area where the blur behind will be applied. A NULL value will apply the blur behind the entire client area.
            /// </summary>
            public IntPtr hRgnBlur;

            /// <summary>
            /// TRUE if the window's colorization should transition to match the maximized windows; otherwise, FALSE.
            /// </summary>
            public byte fTransitionOnMaximized;

            /// <summary>
            /// Gets or sets a value indicating whether to register the window handle to DWM blur behind;
            /// Use <c>false</c> to unregister the window handle from DWM blur behind.
            /// </summary>
            public bool Enable
            {
                get { return this.fEnable != 0; }
                set { this.fEnable = value ? (byte)1 : (byte)0; }
            }

            /// <summary>
            /// Gets a <see cref="Region"/> object from the <see cref="hRgnBlur"/> handle.
            /// </summary>
            public System.Drawing.Region Region => System.Drawing.Region.FromHrgn(this.hRgnBlur);

            /// <summary>
            /// Gets or sets a value indicating whether the window's colorization should transition to match the maximized windows.
            /// </summary>
            public bool TransitionOnMaximized
            {
                get { return this.fTransitionOnMaximized != 0; }
                set { this.fTransitionOnMaximized = value ? (byte)1 : (byte)0; }
            }
        }
    }
}
