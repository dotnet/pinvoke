// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    /// <content>
    /// Contains the <see cref="ACCESS_MASK"/> nested type.
    /// </content>
    public partial class NTDll
    {
        /// <summary>
        /// The ACCESS_MASK type is a bitmask that specifies a set of access rights in the access mask of an access control entry.
        /// </summary>
        public enum ACCESS_MASK : uint
        {
            /// <summary>
            /// Delete access.
            /// </summary>
            DELETE = 0x00010000,

            /// <summary>
            /// Read access to the owner, group, and discretionary access control list (DACL) of the security descriptor.
            /// </summary>
            READ_CONTROL = 0x00020000,

            /// <summary>
            /// Write access to the DACL.
            /// </summary>
            WRITE_DAC = 0x00040000,

            /// <summary>
            /// Write access to owner.
            /// </summary>
            WRITE_OWNER = 0x00080000,

            /// <summary>
            /// Synchronize access.
            /// </summary>
            SYNCHRONIZE = 0x00100000,

            STANDARD_RIGHTS_REQUIRED = 0x000F0000,

            STANDARD_RIGHTS_READ = READ_CONTROL,

            STANDARD_RIGHTS_WRITE = READ_CONTROL,

            STANDARD_RIGHTS_EXECUTE = READ_CONTROL,

            STANDARD_RIGHTS_ALL = 0x001F0000,

            SPECIFIC_RIGHTS_ALL = 0x0000FFFF,
        }
    }
}
