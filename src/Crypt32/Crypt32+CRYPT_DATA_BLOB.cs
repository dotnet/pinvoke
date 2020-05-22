// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PInvoke
{
    /// <content>
    /// Contains the <see cref="CRYPT_DATA_BLOB"/> nested type.
    /// </content>
    public partial class Crypt32
    {
        /// <summary>
        /// A structure that contains an arbitrary array of bytes. The structure definition includes aliases appropriate to the various functions that use it.
        /// </summary>
        [OfferIntPtrPropertyAccessors]
        public unsafe partial struct CRYPT_DATA_BLOB
        {
            /// <summary>
            /// A DWORD variable that contains the count, in bytes, of data.
            /// </summary>
            public int cbData;

            /// <summary>
            /// A pointer to the data buffer.
            /// </summary>
            public byte* pbData;
        }
    }
}
