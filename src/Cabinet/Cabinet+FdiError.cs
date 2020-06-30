// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PInvoke
{
    /// <content>
    /// Contains the <see cref="FdiError"/> nested type.
    /// </content>
    public partial class Cabinet
    {
        /// <summary>
        /// Error values for FDI.
        /// </summary>
        /// <seealso href="https://docs.microsoft.com/en-us/windows/win32/api/fdi_fci_types/ns-fdi_fci_types-erf#members"/>
        public enum FdiError : int
        {
            /// <summary>
            /// No error.
            /// </summary>
            FDIERROR_NONE = 0x00,

            /// <summary>
            /// The cabinet file was not found.
            /// </summary>
            FDIERROR_CABINET_NOT_FOUND = 0x01,

            /// <summary>
            /// The cabinet file does not have the correct format.
            /// </summary>
            FDIERROR_NOT_A_CABINET = 0x02,

            /// <summary>
            /// The cabinet file has an unknown version number.
            /// </summary>
            FDIERROR_UNKNOWN_CABINET_VERSION = 0x03,

            /// <summary>
            /// The cabinet file is corrupt.
            /// </summary>
            FDIERROR_CORRUPT_CABINET = 0x04,

            /// <summary>
            /// Insufficient memory.
            /// </summary>
            FDIERROR_ALLOC_FAIL = 0x05,

            /// <summary>
            /// Unknown compression type used in the cabinet folder.
            /// </summary>
            FDIERROR_BAD_COMPR_TYPE = 0x06,

            /// <summary>
            /// Failure decompressing data from the cabinet file.
            /// </summary>
            FDIERROR_MDI_FAIL = 0x07,

            /// <summary>
            /// Failure writing to the target file.
            /// </summary>
            FDIERROR_TARGET_FILE = 0x08,

            /// <summary>
            /// The cabinets within a set do not have the same RESERVE sizes.
            /// </summary>
            FDIERROR_RESERVE_MISMATCH = 0x09,

            /// <summary>
            /// The cabinet returned by fdintNEXT_CABINET is incorrect.
            /// </summary>
            FDIERROR_WRONG_CABINET = 0x0A,

            /// <summary>
            /// FDI aborted.
            /// </summary>
            FDIERROR_USER_ABORT = 0x0B,
        }
    }
}
