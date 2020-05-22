// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PInvoke
{
    /// <content>
    /// Contains the <see cref="HashOperationType"/> nested type.
    /// </content>
    public static partial class BCrypt
    {
        public enum HashOperationType
        {
            /// <summary>
            /// Equivalent to calling the <see cref="BCryptHashData(SafeHashHandle, byte[], int, BCryptHashDataFlags)"/> function.
            /// </summary>
            BCRYPT_HASH_OPERATION_HASH_DATA = 1,

            /// <summary>
            /// Equivalent to calling the <see cref="BCryptFinishHash(SafeHashHandle, byte[], int, BCryptFinishHashFlags)"/> function.
            /// </summary>
            BCRYPT_HASH_OPERATION_FINISH_HASH = 2,
        }
    }
}
