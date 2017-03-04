// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Runtime.InteropServices;

    /// <content>
    /// Contains the <see cref="DeviceContextValues"/> nested type.
    /// </content>
    public partial class User32
    {
        /// <summary>
        /// Values to pass to the <see cref="GetDCEx"/> method describing how to create the DC.
        /// </summary>
        [Flags]
        public enum DeviceContextValues : uint
        {
            /// <summary>
            /// Returns a DC that corresponds to the window rectangle rather than the client rectangle.
            /// </summary>
            DCX_WINDOW = 0x00000001,

            /// <summary>
            /// Returns a DC from the cache, rather than the OWNDC or CLASSDC window.
            /// Essentially overrides CS_OWNDC and CS_CLASSDC.
            /// </summary>
            DCX_CACHE = 0x00000002,

            /// <summary>
            /// Does not reset the attributes of this DC to the default attributes when this DC is released.
            /// </summary>
            DCX_NORESETATTRS = 0x00000004,

            /// <summary>
            /// Excludes the visible regions of all child windows below the window identified by hWnd.
            /// </summary>
            DCX_CLIPCHILDREN = 0x00000008,

            /// <summary>
            /// Excludes the visible regions of all sibling windows above the window identified by hWnd.
            /// </summary>
            DCX_CLIPSIBLINGS = 0x00000010,

            /// <summary>
            /// Uses the visible region of the parent window. The parent's WS_CLIPCHILDREN and CS_PARENTDC style bits are ignored.
            /// The origin is set to the upper-left corner of the window identified by hWnd.
            /// </summary>
            DCX_PARENTCLIP = 0x00000020,

            /// <summary>
            /// The clipping region identified by hrgnClip is excluded from the visible region of the returned DC.
            /// </summary>
            DCX_EXCLUDERGN = 0x00000040,

            /// <summary>
            /// The clipping region identified by hrgnClip is intersected with the visible region of the returned DC.
            /// </summary>
            DCX_INTERSECTRGN = 0x00000080,

            /// <summary>
            /// Undocumented
            /// </summary>
            /// <remarks>Reserved; do not use.</remarks>
            DCX_EXCLUDEUPDATE = 0x00000100,

            /// <summary>
            /// Returns a region that includes the window's update region.
            /// </summary>
            /// <remarks>Reserved; do not use (it is documented on Windows CE GetDCEx function on MSDN).</remarks>
            DCX_INTERSECTUPDATE = 0x00000200,

            /// <summary>
            /// Allows drawing even if there is a LockWindowUpdate call in effect
            /// that would otherwise exclude this window. Used for drawing during tracking.
            /// </summary>
            DCX_LOCKWINDOWUPDATE = 0x00000400,

            /// <summary>
            /// Undocumented, something internal related to WM_NCPAINT message and not using <see cref="DCX_CACHE"/> on updates.
            /// </summary>
            /// <remarks>Internal; do not use</remarks>
            DCX_USESTYLE = 0x00010000,

            /// <summary>
            /// When specified with <see cref="DCX_INTERSECTUPDATE"/>, causes the DC to be completely validated.
            /// Using this function with both <see cref="DCX_INTERSECTUPDATE"/> and <see cref="DCX_VALIDATE"/> is identical to using the <see cref="BeginPaint(IntPtr, PAINTSTRUCT*)"/> function.
            /// </summary>
            /// <remarks>Reserved; do not use (it is documented on Windows CE GetDCEx function on MSDN).</remarks>
            DCX_VALIDATE = 0x00200000,
        }
    }
}