// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PInvoke
{
    using System.Runtime.InteropServices;

    /// <content>
    /// Contains the <see cref="BCRYPT_PKCS1_PADDING_INFO"/> nested type.
    /// </content>
    public partial class BCrypt
    {
        /// <summary>
        /// The BCRYPT_PKCS1_PADDING_INFO structure is used to provide options for the PKCS #1 padding scheme.
        /// </summary>
        [OfferIntPtrPropertyAccessors]
        public unsafe partial struct BCRYPT_PKCS1_PADDING_INFO
        {
            /// <summary>
            /// A pointer to a null-terminated Unicode string that identifies the cryptographic algorithm to use to create the padding. This algorithm must be a hashing algorithm. When creating a signature, the object identifier (OID) that corresponds to this algorithm is added to the DigestInfo element in the signature, and if this member is NULL, then the OID is not added. When verifying a signature, the verification fails if the OID that corresponds to this member is not the same as the OID in the signature. If there is no OID in the signature, then verification fails unless this member is NULL.
            /// Typically the value comes from a constant defined in <see cref="AlgorithmIdentifiers"/>.
            /// </summary>
            public char* pszAlgId;
        }
    }
}
