// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

using System.Runtime.InteropServices;

namespace PInvoke
{
    partial class Kernel32
    {
        /// <summary>
        /// Represents an icon as stored in a '.ico' file
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct ICONDIRENTRY
        {
            /// <summary>
            /// Width, in pixels, of the image
            /// </summary>
            public byte bWidth;

            /// <summary>
            /// Height, in pixels, of the image
            /// </summary>
            public byte bHeight;

            /// <summary>
            /// Number of colors in image (0 if >= 8bpp)
            /// </summary>
            public byte bColorCount;

            /// <summary>
            /// Reserved
            /// </summary>
            public byte bReserved;

            /// <summary>
            /// Color Planes
            /// </summary>
            public ushort wPlanes;

            /// <summary>
            /// Bits per pixel
            /// </summary>
            public ushort wBitCount;

            /// <summary>
            /// How many bytes in this resource
            /// </summary>
            public uint dwBytesInRes;

            /// <summary>
            /// Location (relative to the start of the ICO file) of the actual image data.
            /// </summary>
            public ushort dwImageOffset;
        }
    }
}
