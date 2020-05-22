// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PInvoke
{
    using System;

    /// <content>
    /// Contains the <see cref="LoadImageFlags"/> nested type.
    /// </content>
    public static partial class User32
    {
        /// <summary>
        /// Represents various image types.
        /// </summary>
        [Flags]
        public enum LoadImageFlags : uint
        {
            /// <summary>
            /// When the uType parameter specifies <see cref="ImageType.IMAGE_BITMAP"/>, causes the function to return a DIB section bitmap rather than a compatible bitmap. This flag is useful for loading a bitmap without mapping it to the colors of the display device.
            /// </summary>
            LR_CREATEDIBSECTION = 0x00002000,

            /// <summary>
            /// The default flag; it does nothing. All it means is "not <see cref="LR_MONOCHROME"/>".
            /// </summary>
            LR_DEFAULTCOLOR = 0x0,

            /// <summary>
            /// Uses the width or height specified by the system metric values for cursors or icons, if the cxDesired or cyDesired values are set to zero. If this flag is not specified and cxDesired and cyDesired are set to zero, the function uses the actual resource size. If the resource contains multiple images, the function uses the size of the first image.
            /// </summary>
            LR_DEFAULTSIZE = 0x00000040,

            /// <summary>
            /// Loads the stand-alone image from the file specified by lpszName (icon, cursor, or bitmap file).
            /// </summary>
            LR_LOADFROMFILE = 0x00000010,

            /// <summary>
            /// Searches the color table for the image and replaces the following shades of gray with the corresponding 3-D color.
            /// <list type="bullet">
            /// <item>Dk Gray, RGB(128,128,128) with COLOR_3DSHADOW</item>
            /// <item>Gray, RGB(192,192,192) with COLOR_3DFACE</item>
            /// <item>Lt Gray, RGB(223,223,223) with COLOR_3DLIGHT</item>
            /// </list>
            /// Do not use this option if you are loading a bitmap with a color depth greater than 8bpp.
            /// </summary>
            LR_LOADMAP3DCOLORS = 0x00001000,

            /// <summary>
            /// Retrieves the color value of the first pixel in the image and replaces the corresponding entry in the color table with the default window color (COLOR_WINDOW). All pixels in the image that use that entry become the default window color. This value applies only to images that have corresponding color tables.
            /// Do not use this option if you are loading a bitmap with a color depth greater than 8bpp.
            /// If fuLoad includes both the <see cref="LR_LOADTRANSPARENT"/> and <see cref="LR_LOADMAP3DCOLORS"/> values, <see cref="LR_LOADTRANSPARENT"/> takes precedence. However, the color table entry is replaced with COLOR_3DFACE rather than COLOR_WINDOW.
            /// </summary>
            LR_LOADTRANSPARENT = 0x00000020,

            /// <summary>
            /// Loads the image in black and white.
            /// </summary>
            LR_MONOCHROME = 0x00000001,

            /// <summary>
            /// Shares the image handle if the image is loaded multiple times. If <see cref="LR_SHARED"/> is not set, a second call to LoadImage for the same resource will load the image again and return a different handle.
            /// When you use this flag, the system will destroy the resource when it is no longer needed.
            /// Do not use <see cref="LR_SHARED"/> for images that have non-standard sizes, that may change after loading, or that are loaded from a file.
            /// When loading a system icon or cursor, you must use <see cref="LR_SHARED"/> or the function will fail to load the resource.
            /// This function finds the first image in the cache with the requested resource name, regardless of the size requested.
            /// </summary>
            LR_SHARED = 0x00008000,

            /// <summary>
            /// Uses true VGA colors.
            /// </summary>
            LR_VGACOLOR = 0x00000080,
        }
    }
}
