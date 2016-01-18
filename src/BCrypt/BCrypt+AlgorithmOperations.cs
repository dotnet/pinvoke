// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;

    /// <content>
    /// Contains the <see cref="AlgorithmOperations"/> nested type.
    /// </content>
    public partial class BCrypt
    {
        /// <summary>
        /// Algorithm operations that may be enumerated.
        /// </summary>
        [Flags]
        public enum AlgorithmOperations : uint
        {
            /// <summary>
            /// Include the cipher algorithms in the enumeration.
            /// </summary>
            BCRYPT_CIPHER_OPERATION = 0x00000001,

            /// <summary>
            /// Include the hash algorithms in the enumeration.
            /// </summary>
            BCRYPT_HASH_OPERATION = 0x00000002,

            /// <summary>
            /// Include the asymmetric encryption algorithms in the enumeration.
            /// </summary>
            BCRYPT_ASYMMETRIC_ENCRYPTION_OPERATION = 0x00000004,

            /// <summary>
            /// Include the secret agreement algorithms in the enumeration.
            /// </summary>
            BCRYPT_SECRET_AGREEMENT_OPERATION = 0x00000008,

            /// <summary>
            /// Include the signature algorithms in the enumeration.
            /// </summary>
            BCRYPT_SIGNATURE_OPERATION = 0x00000010,

            /// <summary>
            /// Include the random number generator (RNG) algorithms in the enumeration.
            /// </summary>
            BCRYPT_RNG_OPERATION = 0x00000020,

            BCRYPT_KEY_DERIVATION_OPERATION = 0x00000040,
        }
    }
}
