// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PInvoke
{
    using System.Runtime.InteropServices;

    /// <summary>
    /// The POINT structure defines the x- and y- coordinates of a point.
    /// </summary>
    public struct POINT
    {
        /// <summary>
        ///  The x-coordinate of the point.
        /// </summary>
        public int x;

        /// <summary>
        /// The x-coordinate of the point.
        /// </summary>
        public int y;

#if !NETSTANDARD1_1
        public static implicit operator System.Drawing.Point(POINT point) => new System.Drawing.Point(point.x, point.y);

        public static implicit operator POINT(System.Drawing.Point point) => new POINT { x = point.X, y = point.Y };
#endif
    }
}
