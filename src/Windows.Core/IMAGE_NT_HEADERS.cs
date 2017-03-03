// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System.Runtime.InteropServices;

    /// <summary>
    /// Represents the PE header format.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct IMAGE_NT_HEADERS
    {
        /// <summary>
        /// A 4-byte signature identifying the file as a PE image. The bytes are "PE\0\0".
        /// </summary>
        public uint Signature;

        /// <summary>
        /// An <see cref="IMAGE_FILE_HEADER"/> structure that specifies the file header.
        /// </summary>
        public IMAGE_FILE_HEADER FileHeader;

        /// <summary>
        /// An <see cref="IMAGE_OPTIONAL_HEADER"/> structure that specifies the optional file header.
        /// </summary>
        public IMAGE_OPTIONAL_HEADER OptionalHeader;
    }
}
