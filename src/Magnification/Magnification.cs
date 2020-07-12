// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Runtime.InteropServices;

    /// <summary>
    /// Exported functions from the Magnification.dll Windows library
    /// that are available to Desktop and Store apps.
    /// </summary>
    [OfferFriendlyOverloads]
    public static partial class Magnification
    {
        /// <summary>
        /// Creates and initializes the magnifier run-time objects.
        /// </summary>
        /// <returns>Returns TRUE if successful, or FALSE otherwise.</returns>
        [DllImport(nameof(Magnification))]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool MagInitialize();

        /// <summary>
        /// Destroys the magnifier run-time objects.
        /// </summary>
        /// <returns>Returns TRUE if successful, or FALSE otherwise.</returns>
        [DllImport(nameof(Magnification))]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool MagUninitialize();

        /// <summary>
        /// Shows or hides the system cursor.
        /// </summary>
        /// <param name="fShowCursor">TRUE to show the system cursor, or FALSE to hide it.</param>
        /// <returns>Returns TRUE if successful, or FALSE otherwise.</returns>
        [DllImport(nameof(Magnification))]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool MagShowSystemCursor(
            [MarshalAs(UnmanagedType.Bool)] bool fShowCursor);

        /// <summary>
        /// Sets the transformation matrix for a magnifier control.
        /// </summary>
        /// <param name="hwnd">The magnification window.</param>
        /// <param name="pTransform">A transformation matrix.</param>
        /// <returns>Returns TRUE if successful, or FALSE otherwise.</returns>
        [DllImport(nameof(Magnification))]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern unsafe bool MagSetWindowTransform(
            IntPtr hwnd,
            [Friendly(FriendlyFlags.In)] MAGTRANSFORM* pTransform);

        /// <summary>
        /// Retrieves the transformation matrix associated with a magnifier control.
        /// </summary>
        /// <param name="hwnd">The magnification window.</param>
        /// <param name="pTransform">The transformation matrix.</param>
        /// <returns>Returns TRUE if successful, or FALSE otherwise.</returns>
        [DllImport(nameof(Magnification))]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern unsafe bool MagGetWindowTransform(
            IntPtr hwnd,
            [Friendly(FriendlyFlags.Out)] MAGTRANSFORM* pTransform);

        /// <summary>
        /// Sets the color transformation matrix for a magnifier control.
        /// </summary>
        /// <param name="hwnd">The magnification window.</param>
        /// <param name="pEffect">The color transformation matrix, or NULL to remove the current color effect, if any.</param>
        /// <returns>Returns TRUE if successful, or FALSE otherwise.</returns>
        [DllImport(nameof(Magnification))]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern unsafe bool MagSetColorEffect(
            IntPtr hwnd,
            [Friendly(FriendlyFlags.In)] MAGCOLOREFFECT* pEffect);

        /// <summary>
        /// Gets the color transformation matrix for a magnifier control.
        /// </summary>
        /// <param name="hwnd">The magnification window.</param>
        /// <param name="pEffect">The color transformation matrix, or NULL if no color effect has been set.</param>
        /// <returns>Returns TRUE if successful, or FALSE otherwise.</returns>
        [DllImport(nameof(Magnification))]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern unsafe bool MagGetColorEffect(
            IntPtr hwnd,
            [Friendly(FriendlyFlags.Out | FriendlyFlags.Optional)] MAGCOLOREFFECT* pEffect);

        /// <summary>
        /// Changes the color transformation matrix associated with the full-screen magnifier.
        /// </summary>
        /// <param name="pEffect">The new color transformation matrix. This parameter must not be NULL.</param>
        /// <returns>Returns TRUE if successful, or FALSE otherwise.</returns>
        [DllImport(nameof(Magnification))]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern unsafe bool MagSetFullscreenColorEffect(
            [Friendly(FriendlyFlags.In)] MAGCOLOREFFECT* pEffect);

        /// <summary>
        /// Retrieves the color transformation matrix associated with the full-screen magnifier.
        /// </summary>
        /// <param name="pEffect">The color transformation matrix, or the identity matrix if no color effect has been set.</param>
        /// <returns>Returns TRUE if successful, or FALSE otherwise.</returns>
        [DllImport(nameof(Magnification))]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern unsafe bool MagGetFullscreenColorEffect(
            [Friendly(FriendlyFlags.Out)] MAGCOLOREFFECT* pEffect);

        /// <summary>
        /// Changes the magnification settings for the full-screen magnifier.
        /// </summary>
        /// <param name="magLevel">The new magnification factor for the full-screen magnifier. The minimum value of this parameter is 1.0, and the maximum value is 4096.0. If this value is 1.0, the screen content is not magnified and no offsets are applied.</param>
        /// <param name="xOffset">The new x-coordinate offset, in pixels, for the upper-left corner of the magnified view. The offset is relative to the upper-left corner of the primary monitor, in unmagnified coordinates. The minimum value of the parameter is -262144, and the maximum value is 262144.</param>
        /// <param name="yOffset">The new y-coordinate offset, in pixels, for the upper-left corner of the magnified view. The offset is relative to the upper-left corner of the primary monitor, in unmagnified coordinates. The minimum value of the parameter is -262144, and the maximum value is 262144.</param>
        /// <returns>Returns TRUE if successful, or FALSE otherwise.</returns>
        [DllImport(nameof(Magnification))]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool MagSetFullscreenTransform(
           float magLevel,
           int xOffset,
           int yOffset);
    }
}
