// Copyright (c) All contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PInvoke
{
    /// <content>
    /// Contains the <see cref="HashParameters"/> nested type.
    /// </content>
    public static partial class AdvApi32
    {
        /// <summary>
        ///     Hash Parameters
        /// </summary>
        public enum HashParameters
        {
            /// <summary>
            ///     Get the algorithm of the hash
            /// </summary>
            HP_ALGID = 0x0001,

            /// <summary>
            ///     Get the value of the hash
            /// </summary>
            HP_HASHVAL = 0x0002,

            /// <summary>
            ///     Get the size of the hash
            /// </summary>
            HP_HASHSIZE = 0x0004
        }
    }
}
