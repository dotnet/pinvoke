// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Runtime.InteropServices;

    /// <content>
    /// Contains the <see cref="IAssemblyCacheItem"/> nested type.
    /// </content>
    public partial class Fusion
    {
        /// <summary>
        /// Represents a single assembly in the global assembly cache.
        /// </summary>
        [ComImport]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        [Guid("9e3aaeb4-d1cd-11d2-bab9-00c04f8eceae")]
        public interface IAssemblyCacheItem
        {
            /// <summary>
            /// Creates a stream with the specified name and format.
            /// </summary>
            /// <param name="dwFlags">Flags defined in Fusion.idl.</param>
            /// <param name="pszStreamName">The name of the stream to be created.</param>
            /// <param name="dwFormat">The format of the file to be streamed.</param>
            /// <param name="dwFormatFlags">Format-specific flags defined in Fusion.idl.</param>
            /// <param name="ppIStream">A pointer to the address of the returned <see cref="mscoree.IStream"/> instance.</param>
            /// <param name="puliMaxSize">The maximum size of the stream referenced by <paramref name="ppIStream"/>.</param>
            /// <returns>An <see cref="HResult"/>.</returns>
            [PreserveSig]
            unsafe HResult CreateStream(
                /* [in] */ uint dwFlags,
                /* [in] */ string pszStreamName,
                /* [in] */ uint dwFormat,
                /* [in] */ uint dwFormatFlags,
                /* [out] */ out mscoree.IStream ppIStream,
                /* [optional][in] */ ulong* puliMaxSize);

            /// <summary>
            /// Commits the cached assembly reference to memory.
            /// </summary>
            /// <param name="dwFlags">Flags defined in Fusion.idl.</param>
            /// <param name="pulDisposition">A value that indicates the result of the operation.</param>
            /// <returns>An <see cref="HResult"/>.</returns>
            [PreserveSig]
            unsafe HResult Commit(
                /* [in] */ uint dwFlags,
                /* [optional][out] */ uint* pulDisposition);

            /// <summary>
            /// Allows the assembly in the global assembly cache to perform cleanup operations before it is released.
            /// </summary>
            /// <returns>An <see cref="HResult"/>.</returns>
            [PreserveSig]
            HResult AbortItem();
        }
    }
}
