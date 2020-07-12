// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PInvoke
{
    /// <content>
    /// Contains the <see cref="PROCESSOR_NUMBER"/> nested type.
    /// </content>
    public partial class Kernel32
    {
        /// <summary>
        /// Represents a logical processor in a processor group.
        /// </summary>
        public struct PROCESSOR_NUMBER
        {
            /// <summary>
            /// The processor group to which the logical processor is assigned.
            /// </summary>
            public ushort Group;

            /// <summary>
            /// The number of the logical processor relative to the group.
            /// </summary>
            public byte Number;

            /// <summary>
            /// This parameter is reserved.
            /// </summary>
            public byte Reserved;
        }
    }
}
