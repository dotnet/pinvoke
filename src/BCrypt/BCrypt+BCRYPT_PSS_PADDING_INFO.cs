// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System.Runtime.InteropServices;

    /// <content>
    /// Contains the <see cref="BCRYPT_PSS_PADDING_INFO"/> nested type.
    /// </content>
    public partial class BCrypt
    {
        /// <summary>
        /// The BCRYPT_PSS_PADDING_INFO structure is used to provide options for the Probabilistic Signature Scheme (PSS) padding scheme.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        [OfferIntPtrPropertyAccessors]
        public unsafe partial struct BCRYPT_PSS_PADDING_INFO
        {
            /// <summary>
            /// A pointer to a null-terminated Unicode string that identifies the cryptographic algorithm to use to create the padding. This algorithm must be a hashing algorithm.
            /// Typically the value comes from a constant defined in <see cref="AlgorithmIdentifiers"/>.
            /// </summary>
            public char* pszAlgId;

            /// <summary>
            /// The size, in bytes, of the random salt to use for the padding.
            /// </summary>
            public int cbSalt;
        }
    }
}
