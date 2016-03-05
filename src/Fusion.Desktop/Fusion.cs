// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Runtime.InteropServices;

    /// <summary>
    /// Exported functions from the Fusion.dll Windows library
    /// that are available to Desktop apps only.
    /// </summary>
    [OfferFriendlyOverloads]
    public static partial class Fusion
    {
        /// <summary>
        /// Gets a pointer to a new <see cref="IAssemblyCache"/> instance that represents the global assembly cache.
        /// </summary>
        /// <param name="ppAsmCache">The returned <see cref="IAssemblyCache"/> pointer.</param>
        /// <param name="dwReserved">Reserved for future extensibility. dwReserved must be 0 (zero).</param>
        /// <returns>An <see cref="HResult"/>.</returns>
        [DllImport(nameof(Fusion))]
        public static extern HResult CreateAssemblyCache(
            out IAssemblyCache ppAsmCache,
            int dwReserved);
    }
}
