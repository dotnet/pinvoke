// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;

    /// <content>
    /// Contains the <see cref="BCryptOpenAlgorithmProviderFlags"/> nested type.
    /// </content>
    public partial class BCrypt
    {
        /// <summary>
        /// Flags that can be passed to <see cref="BCryptOpenAlgorithmProvider(string, string, BCryptOpenAlgorithmProviderFlags)"/>
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
            AlgorithmHandleHmac,

            /// <summary>
            /// Creates a reusable hashing object. The object can be used for a new hashing
            /// operation immediately after calling BCryptFinishHash. For more information,
            /// see Creating a Hash with CNG.
            /// </summary>
            HashReusable,
        }
    }
}
