// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;

    /// <content>
    /// Contains the <see cref="CharacteristicsType"/> nested type.
    /// </content>
    public partial struct IMAGE_FILE_HEADER
    {
        /// <summary>
        /// Enumerates the expected values from the <see cref="Characteristics"/> field.
        /// </summary>
        [Flags]
        public enum CharacteristicsType : ushort
        {
            /// <summary>
            /// Relocation information was stripped from the file. The file must be loaded at its preferred base address. If the base address is not available, the loader reports an error.
            /// </summary>
            IMAGE_FILE_RELOCS_STRIPPED = 0x0001,

            /// <summary>
            /// The file is executable (there are no unresolved external references).
            /// </summary>
            IMAGE_FILE_EXECUTABLE_IMAGE = 0x0002,

            /// <summary>
            /// COFF line numbers were stripped from the file.
            /// </summary>
            IMAGE_FILE_LINE_NUMS_STRIPPED = 0x0004,

            /// <summary>
            /// COFF symbol table entries were stripped from file.
            /// </summary>
            IMAGE_FILE_LOCAL_SYMS_STRIPPED = 0x0008,

            /// <summary>
            /// Aggressively trim the working set. This value is obsolete.
            /// </summary>
            [Obsolete]
            IMAGE_FILE_AGGRESIVE_WS_TRIM = 0x0010,

            /// <summary>
            /// The application can handle addresses larger than 2 GB.
            /// </summary>
            IMAGE_FILE_LARGE_ADDRESS_AWARE = 0x0020,

            /// <summary>
            /// The bytes of the word are reversed. This flag is obsolete.
            /// </summary>
            [Obsolete]
            IMAGE_FILE_BYTES_REVERSED_LO = 0x0080,

            /// <summary>
            /// The computer supports 32-bit words.
            /// </summary>
            IMAGE_FILE_32BIT_MACHINE = 0x0100,

            /// <summary>
            /// Debugging information was removed and stored separately in another file.
            /// </summary>
            IMAGE_FILE_DEBUG_STRIPPED = 0x0200,

            /// <summary>
            /// If the image is on removable media, copy it to and run it from the swap file.
            /// </summary>
            IMAGE_FILE_REMOVABLE_RUN_FROM_SWAP = 0x0400,

            /// <summary>
            /// If the image is on the network, copy it to and run it from the swap file.
            /// </summary>
            IMAGE_FILE_NET_RUN_FROM_SWAP = 0x0800,

            /// <summary>
            /// The image is a system file.
            /// </summary>
            IMAGE_FILE_SYSTEM = 0x1000,

            /// <summary>
            /// The image is a DLL file. While it is an executable file, it cannot be run directly.
            /// </summary>
            IMAGE_FILE_DLL = 0x2000,

            /// <summary>
            /// The file should be run only on a uniprocessor computer.
            /// </summary>
            IMAGE_FILE_UP_SYSTEM_ONLY = 0x4000,

            /// <summary>
            /// The bytes of the word are reversed. This flag is obsolete.
            /// </summary>
            [Obsolete]
            IMAGE_FILE_BYTES_REVERSED_HI = 0x8000,
        }
    }
}
