// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PInvoke
{
    using System;

    /// <content>
    /// Contains the <see cref="BCryptOpenAlgorithmProviderFlags"/> nested type.
    /// </content>
    public partial class BCrypt
    {
        /// <summary>
        /// Flags that can be passed to <see cref="BCryptOpenAlgorithmProvider(string, string, BCryptOpenAlgorithmProviderFlags)"/>.
        /// </summary>
        [Flags]
        public enum BCryptOpenAlgorithmProviderFlags
        {
            /// <summary>
            /// No flags.
            /// </summary>
            None = 0x0,

            /// <summary>
            /// The provider will perform the Hash-Based Message Authentication Code (HMAC)
            /// algorithm with the specified hash algorithm. This flag is only used by hash
            /// algorithm providers.
            /// </summary>
            BCRYPT_ALG_HANDLE_HMAC_FLAG = 0x8,

            /// <summary>
            /// Creates a reusable hashing object. The object can be used for a new hashing
            /// operation immediately after calling BCryptFinishHash. For more information,
            /// see Creating a Hash with CNG.
            /// </summary>
            BCRYPT_HASH_REUSABLE_FLAG = 0x20,

            /// <summary>
            /// Needed for use with <see cref="BCryptCreateMultiHash(SafeAlgorithmHandle, out SafeHashHandle, int, byte*, int, byte*, int, BCryptCreateHashFlags)"/>.
            /// </summary>
            BCRYPT_MULTI_FLAG = 0x40,
        }
    }
}
