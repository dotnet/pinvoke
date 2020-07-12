// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PInvoke
{
    /// <content>
    /// Contains the <see cref="PROCESS_LEAP_SECOND_INFO"/> nested type.
    /// </content>
    public partial class Kernel32
    {
        /// <summary>
        /// Specifies how the system handles positive leap seconds.
        /// </summary>
        public struct PROCESS_LEAP_SECOND_INFO
        {
            /// <summary>
            /// Flag specifying how the system handles leap seconds.
            /// </summary>
            public ProcessLeapSecondInfoFlags Flags;

            /// <summary>
            /// Reserved for future use.
            /// </summary>
            public uint Reserved;
        }
    }
}
