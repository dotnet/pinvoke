// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PInvoke
{
    using System;

    /// <content>
    /// Contains the <see cref="FILE_ZERO_DATA_INFORMATION "/> nested type.
    /// </content>
    public partial class Kernel32
    {
        /// <summary>
        /// Contains a range of a file to set to zeros. This structure is used by the <c>FSCTL_SET_ZERO_DATA</c> control code.
        /// </summary>
        public struct FILE_ZERO_DATA_INFORMATION
        {
            /// <summary>
            /// The file offset of the start of the range to set to zeros, in bytes.
            /// </summary>
            public long FileOffset;

            /// <summary>
            /// The byte offset of the first byte beyond the last zeroed byte.
            /// </summary>
            public long BeyondFinalZero;
        }
    }
}
