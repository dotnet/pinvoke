// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    /// <summary>
    /// Extension methods for working with the <see cref="PinnedStruct{T}"/> type.
    /// </summary>
    public static class PinnedStructExtensions
    {
        /// <summary>
        /// Allocate a copy of the structure on the heap and pin it in place, allowing a controlled release (via
        /// <see cref="PinnedStruct{T}.Dispose()" />).
        /// </summary>
        /// <typeparam name="T">Type of the structure to Pin.</typeparam>
        /// <param name="value">The value that will be pinned.</param>
        /// <returns>A <see cref="PinnedStruct{T}" /> instance representing the passed <paramref name="value" />.</returns>
        public static PinnedStruct<T> Pin<T>(this T value)
            where T : struct
        {
            return new PinnedStruct<T>(value);
        }

        /// <summary>
        /// Allocate a copy of the structure on the heap if <paramref name="value" /> is non-null and pin it in place,
        /// allowing a controlled release (Via <see cref="PinnedStruct{T}.Dispose()" />).
        /// If it doesn't contain anything the returned value will represent a <see langword="null" /> pointer.
        /// </summary>
        /// <typeparam name="T">Type of the structure to Pin.</typeparam>
        /// <param name="value">The value that will be pinned.</param>
        /// <returns>A <see cref="PinnedStruct{T}" /> instance representing the passed <paramref name="value" />.</returns>
        public static PinnedStruct<T> Pin<T>(this T? value)
            where T : struct
        {
            return new PinnedStruct<T>(value);
        }
    }
}