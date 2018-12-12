// Copyright (c) All contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PInvoke
{
    /// <content>
    /// Contains the <see cref="ALG_ID"/> nested type.
    /// </content>
    public static partial class AdvApi32
    {
        /// <summary>
        ///     ALG HASH Base ID
        /// </summary>
        public const int ALG_CLASS_HASH = 4 << 13;

        /// <summary>
        ///     SHA1 hashing ID
        /// </summary>
        public const int ALG_SID_SHA1 = 4;

        /// <summary>
        ///     Hashing Algorithms
        /// </summary>
        public enum ALG_ID
        {
            /// <summary>
            ///     MD5 Algorithm
            /// </summary>
            CALG_MD5 = 0x00008003,

            /// <summary>
            ///     SHA1 Algorithm
            /// </summary>
            CALG_SHA1 = ALG_CLASS_HASH | ALG_SID_SHA1
        }
    }
}
