// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

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
    }
}
