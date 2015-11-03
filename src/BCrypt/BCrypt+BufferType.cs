// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    /// <content>
    /// Contains the <see cref="BufferType"/> nested enum.
    /// </content>
    public partial class BCrypt
    {
        /// <summary>
        /// Types of data stored in <see cref="BCryptBuffer"/>.
        /// </summary>
        public enum BufferType
        {
            KDF_HASH_ALGORITHM = 0,
            KDF_SECRET_PREPEND = 1,
            KDF_SECRET_APPEND = 2,
            KDF_HMAC_KEY = 3,
            KDF_TLS_PRF_LABEL = 4,
            KDF_TLS_PRF_SEED = 5,
            KDF_SECRET_HANDLE = 6,
            KDF_TLS_PRF_PROTOCOL = 7,
            KDF_ALGORITHMID = 8,
            KDF_PARTYUINFO = 9,
            KDF_PARTYVINFO = 10,
            KDF_SUPPPUBINFO = 11,
            KDF_SUPPPRIVINFO = 12,
            KDF_LABEL = 13,
            KDF_CONTEXT = 14,
            KDF_SALT = 15,
            KDF_ITERATION_COUNT = 16,
        }
    }
}
