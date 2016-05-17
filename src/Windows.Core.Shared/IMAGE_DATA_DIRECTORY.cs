// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    /// <summary>
    /// Represents the data directory.
    /// </summary>
    /// <remarks>
    /// See remarks on MSDN: https://msdn.microsoft.com/en-us/library/windows/desktop/ms680305(v=vs.85).aspx
    /// </remarks>
    public struct IMAGE_DATA_DIRECTORY
    {
        /// <summary>
        /// The relative virtual address of the table.
        /// </summary>
        public uint VirtualAddress;

        /// <summary>
        /// The size of the table, in bytes.
        /// </summary>
        public uint Size;
    }
}
