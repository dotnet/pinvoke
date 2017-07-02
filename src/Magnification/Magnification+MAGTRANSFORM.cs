// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Runtime.InteropServices;

    /// <content>
    /// Contains the <see cref="MAGTRANSFORM"/> nested type.
    /// </content>
    public partial class Magnification
    {
        /// <summary>
        /// Describes a transformation matrix that a magnifier control uses to magnify screen content.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public unsafe struct MAGTRANSFORM
        {
            /// <summary>
            /// Gets the length of each dimension in the flattened array.
            /// </summary>
            private const int OneDimensionLength = 3;

            /// <summary>
            /// The transformation matrix. Always 3x3.
            /// </summary>
            private fixed float v[OneDimensionLength * OneDimensionLength];

            /// <summary>Gets or sets a value of the <see cref="v" /> field of this struct.</summary>
            /// <param name="x">The index into the first dimension of the array.</param>
            /// <param name="y">The index into the second dimension of the array.</param>
            public float this[int x, int y]
            {
                get
                {
                    CheckArrayRange(x, y, OneDimensionLength);
                    fixed (float* array = this.v)
                    {
                        return array[IndexIntoTwoDimensionalArray(x, y, OneDimensionLength)];
                    }
                }

                set
                {
                    CheckArrayRange(x, y, OneDimensionLength);
                    fixed (float* array = this.v)
                    {
                        array[IndexIntoTwoDimensionalArray(x, y, OneDimensionLength)] = value;
                    }
                }
            }
        }
    }
}
