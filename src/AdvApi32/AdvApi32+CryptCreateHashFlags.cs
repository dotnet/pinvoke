// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PInvoke
{
    using System;

    /// <content>
    /// Contains the <see cref="CryptCreateHashFlags"/> nested type.
    /// </content>
    public partial class AdvApi32
    {
        /// <summary>
        /// Flags for the <see cref="CryptCreateHash"/> method.
        /// </summary>
        [Flags]
        public enum CryptCreateHashFlags : uint
        {
            /// <summary>
            /// No flags.
            /// </summary>
            None = 0x0,

            /// <summary>
            /// This flag is not used.
            /// </summary>
            CRYPT_SECRETDIGEST = 0x1,
        }
    }
}
