// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Runtime.InteropServices;
    using static DbgHelp;

    /// <summary>
    /// Exported functions from the ImageHlp.dll Windows library
    /// that are available to Desktop and Store apps.
    /// </summary>
    [OfferFriendlyOverloads]
    public static partial class ImageHlp
    {
        /// <summary>
        /// Maps an image and preloads data from the mapped file.
        /// </summary>
        /// <param name="ImageName">The file name of the image (executable file or DLL) that is loaded.</param>
        /// <param name="DllPath">The path used to locate the image if the name provided cannot be found. If this parameter is NULL, then the search path rules set using the SearchPath function apply.</param>
        /// <param name="LoadedImage">A pointer to a <see cref="LOADED_IMAGE"/> structure that receives information about the image after it is loaded.</param>
        /// <param name="DotDll">The default extension to be used if the image name does not contain a file name extension. If the value is TRUE, a .DLL extension is used. If the value is FALSE, then an .EXE extension is used.</param>
        /// <param name="ReadOnly">The access mode. If this value is TRUE, the file is mapped for read-access only. If the value is FALSE, the file is mapped for read and write access.</param>
        /// <returns>
        /// If the function succeeds, the return value is TRUE.
        /// If the function fails, the return value is FALSE. To retrieve extended error information, call <see cref="Marshal.GetLastWin32Error"/>.
        /// </returns>
        [DllImport(nameof(ImageHlp), SetLastError = true, CharSet = CharSet.Ansi)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool MapAndLoad(
            string ImageName,
            string DllPath,
            out LOADED_IMAGE LoadedImage,
            bool DotDll,
            bool ReadOnly);

        /// <summary>
        /// Deallocate all resources that are allocated by a previous call to the <see cref="MapAndLoad"/> function.
        /// </summary>
        /// <param name="LoadedImage">
        /// A pointer to a <see cref="LOADED_IMAGE"/> structure. This structure is obtained through a call to the <see cref="MapAndLoad"/> function.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is TRUE.
        /// If the function fails, the return value is FALSE. To retrieve extended error information, call <see cref="Marshal.GetLastWin32Error"/>.
        /// </returns>
        [DllImport(nameof(ImageHlp), SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool UnMapAndLoad(
            ref LOADED_IMAGE LoadedImage);
    }
}
