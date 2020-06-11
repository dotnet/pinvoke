// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PInvoke
{
    using System;

    /// <content>
    /// Contains the <see cref="BCryptCreateHashFlags"/> nested type.
    /// </content>
    public partial class BCrypt
    {
        /// <summary>
        /// Flags that can be passed to the <see cref="BCryptCreateHash(SafeAlgorithmHandle, out SafeHashHandle, byte[], int, byte[], int, BCryptCreateHashFlags)"/> method.
        /// </summary>
        [Flags]
        public enum BCryptCreateHashFlags
        {
            None = 0x0,

            /// <summary>
            /// Creates a reusable hashing object. The object can be used for a new hashing operation immediately after calling BCryptFinishHash. For more information, see Creating a Hash with CNG.
            /// Windows Server 2008 R2, Windows 7, Windows Server 2008, and Windows Vista:  This flag is not supported.
            /// </summary>
            BCRYPT_HASH_REUSABLE_FLAG = 0x00000020,
        }
    }
}
