// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Runtime.InteropServices;

    /// <content>
    /// Contains the <see cref="MAGCOLOREFFECT"/> nested type.
    /// </content>
    public partial class Magnification
    {
        /// <summary>
        /// Describes a color transformation matrix that a magnifier control uses to apply a color effect to magnified screen content.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public unsafe struct MAGCOLOREFFECT
        {
            /// <summary>
            /// Gets the length of each dimension in the flattened array.
            /// </summary>
            private const int OneDimensionLength = 5;

            /// <summary>
            /// The transformation matrix. Always 5x5.
            /// </summary>
            private fixed float transform[OneDimensionLength * OneDimensionLength];

            /// <summary>Gets or sets a value of the <see cref="transform" /> field of this struct.</summary>
            /// <param name="x">The index into the first dimension of the array.</param>
            /// <param name="y">The index into the second dimension of the array.</param>
            public float this[int x, int y]
            {
                get
                {
                    CheckArrayRange(x, y, OneDimensionLength);
                    fixed (float* array = this.transform)
                    {
                        return array[IndexIntoTwoDimensionalArray(x, y, OneDimensionLength)];
                    }
                }

                set
                {
                    CheckArrayRange(x, y, OneDimensionLength);
                    fixed (float* array = this.transform)
                    {
                        array[IndexIntoTwoDimensionalArray(x, y, OneDimensionLength)] = value;
                    }
                }
            }
        }
    }
}
