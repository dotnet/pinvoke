// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    /// <content>
    /// Contains the <see cref="MachineType"/> nested type.
    /// </content>
    public partial struct IMAGE_FILE_HEADER
    {
        /// <summary>
        /// Describes the expected values of the <see cref="Machine"/> field.
        /// </summary>
        public enum MachineType : ushort
        {
            /// <summary>
            /// x86
            /// </summary>
            IMAGE_FILE_MACHINE_I386 = 0x014c,

            /// <summary>
            /// Intel Itanium
            /// </summary>
            IMAGE_FILE_MACHINE_IA64 = 0x0200,

            /// <summary>
            /// x64
            /// </summary>
            IMAGE_FILE_MACHINE_AMD64 = 0x8664,
        }
    }
}
