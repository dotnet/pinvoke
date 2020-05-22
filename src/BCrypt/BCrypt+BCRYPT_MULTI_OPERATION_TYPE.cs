// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PInvoke
{
    /// <content>
    /// Contains the <see cref="BCRYPT_MULTI_OPERATION_TYPE"/> nested type.
    /// </content>
    public static partial class BCrypt
    {
        /// <summary>
        /// Enum to specify type of multi-operation is passed to <see cref="BCryptProcessMultiOperations(SafeHashHandle, BCRYPT_MULTI_OPERATION_TYPE, BCRYPT_MULTI_HASH_OPERATION*, int, int)"/>.
        /// </summary>
        public enum BCRYPT_MULTI_OPERATION_TYPE
        {
            /// <summary>
            /// Structure type is <see cref="BCRYPT_MULTI_HASH_OPERATION"/>
            /// </summary>
            BCRYPT_OPERATION_TYPE_HASH = 1,
        }
    }
}
