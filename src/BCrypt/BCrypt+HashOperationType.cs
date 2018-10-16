// Copyright (c) All contributors. All rights reserved.
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
            BCRYPT_HASH_OPERATION_HASH_DATA = 1,
            BCRYPT_HASH_OPERATION_FINISH_HASH = 2,
        }
    }
}
