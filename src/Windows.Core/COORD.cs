// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System.Runtime.InteropServices;

    /// <summary>
    /// The COORD structure defines the X- and Y- coordinates of a point.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct COORD
    {
        /// <summary>
        ///  The x-coordinate of the point.
        /// </summary>
        public short X;

        /// <summary>
        /// The x-coordinate of the point.
        /// </summary>
        public short Y;
    }
}
