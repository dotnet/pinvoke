// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PInvoke
{
    using System.Runtime.InteropServices;

    /// <summary>
    /// The RECT structure defines the coordinates of the upper-left and lower-right corners of a rectangle.
    /// </summary>
    /// <remarks>
    /// This structure is used by console functions to specify rectangular areas of console screen buffers,
    /// where the coordinates specify the rows and columns of screen-buffer character cells.
    /// </remarks>
    public struct SMALL_RECT
    {
        /// <summary>
        /// The x-coordinate of the upper-left corner of the rectangle.
        /// </summary>
        public short Left;

        /// <summary>
        /// The y-coordinate of the upper-left corner of the rectangle.
        /// </summary>
        public short Top;

        /// <summary>
        /// The x-coordinate of the lower-right corner of the rectangle.
        /// </summary>
        public short Right;

        /// <summary>
        /// The y-coordinate of the lower-right corner of the rectangle.
        /// </summary>
        public short Bottom;
    }
}
