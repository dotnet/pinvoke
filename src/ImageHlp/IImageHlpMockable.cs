// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Runtime.InteropServices;
    using static DbgHelp;
	public interface IImageHlpMockable {        /// <summary>
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
        bool InvokeMapAndLoad(
            string ImageName,
            string DllPath,
            out LOADED_IMAGE LoadedImage,
            bool DotDll,
            bool ReadOnly);
	}
}
