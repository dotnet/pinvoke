// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Runtime.InteropServices;

    /// <content>
    /// Methods and nested types that are not strictly P/Invokes but provide
    /// a slightly higher level of functionality to ease calling into native code.
    /// </content>
    public static partial class Magnification
    {
        // This is where you define methods that assist in calling P/Invoke methods.
        // For example, if a P/Invoke method requires allocating unmanaged memory
        // and freeing it up after the call, a helper method in this file would
        // make "P/Invoking" for most callers much easier and is a welcome addition.

        /// <summary>
        /// Gets the index into a one dimensional array that emulates a two dimensional array.
        /// </summary>
        /// <param name="x">The index into the first dimension.</param>
        /// <param name="y">The index into the second dimension.</param>
        /// <param name="dimensionLength">The length of the <paramref name="y" /> dimension.</param>
        /// <returns>The index into a one-dimensional array that is equivalent to the specified two-dimensional indexes.</returns>
        private static unsafe int IndexIntoTwoDimensionalArray(int x, int y, int dimensionLength)
        {
            return (x * dimensionLength) + y;
        }

        /// <summary>
        /// Throws <see cref="ArgumentOutOfRangeException" /> if array indexers are out of range.
        /// </summary>
        /// <param name="x">The index into the first dimension of the array.</param>
        /// <param name="y">The index into the second dimension of the array.</param>
        /// <param name="dimensionLength">The length of both dimensions of the array.</param>
        private static void CheckArrayRange(int x, int y, int dimensionLength)
        {
            if (x < 0 || x >= dimensionLength)
            {
                throw new ArgumentOutOfRangeException(nameof(x));
            }

            if (y < 0 || y >= dimensionLength)
            {
                throw new ArgumentOutOfRangeException(nameof(y));
            }
        }
    }
}
