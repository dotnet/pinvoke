// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PInvoke
{
    /// <content>
    /// Contains the <see cref="LegacyKeySpec"/> nested type.
    /// </content>
    public partial class NCrypt
    {
        /// <summary>
        /// A legacy identifier that specifies the type of key.
        /// </summary>
        public enum LegacyKeySpec
        {
            /// <summary>
            /// None of the other types.
            /// </summary>
            None = 0x0,

            /// <summary>
            /// The key is a key exchange key.
            /// </summary>
            AT_KEYEXCHANGE,

            /// <summary>
            /// The key is a signature key.
            /// </summary>
            AT_SIGNATURE,
        }
    }
}
