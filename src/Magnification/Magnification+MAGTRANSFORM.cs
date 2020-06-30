// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

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
        public unsafe struct MAGTRANSFORM
        {
            /// <summary>
            /// The transformation matrix. Represents a 2 dimensional array that is always 3x3 in size.
            /// Use the indexer on the declaring struct for convenient 2D indexing into the array.
            /// </summary>
            public fixed float v[OneDimensionLength * OneDimensionLength];

            /// <summary>
            /// Gets the length of each dimension in the flattened array.
            /// </summary>
            private const int OneDimensionLength = 3;

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
