// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    /// <content>
    /// Contains the <see cref="MagicType"/> nested type.
    /// </content>
    public partial struct IMAGE_OPTIONAL_HEADER
    {
        /// <summary>
        /// Expected values for the <see cref="Magic"/> field.
        /// </summary>
        public enum MagicType : ushort
        {
            /// <summary>
            /// The file is a 32-bit executable image.
            /// </summary>
            IMAGE_NT_OPTIONAL_HDR32_MAGIC = 0x10b,

            /// <summary>
            /// The file is a 64-bit executable image.
            /// </summary>
            IMAGE_NT_OPTIONAL_HDR64_MAGIC = 0x20b,

            /// <summary>
            /// The file is a ROM image.
            /// </summary>
            IMAGE_ROM_OPTIONAL_HDR_MAGIC = 0x107,
        }
    }
}