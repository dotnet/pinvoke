// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;

    /// <content>
    /// Contains the <see cref="AlgorithmOperations"/> nested type.
    /// </content>
    public partial class NCrypt
    {
        /// <summary>
        /// Algorithm operations that may be enumerated.
        /// </summary>
        [Flags]
        public enum AlgorithmOperations : uint
        {
            /// <summary>
            /// Enumerate all algorithms.
            /// </summary>
            All = 0x0,

            /// <summary>
            /// Include the cipher algorithms in the enumeration.
            /// </summary>
            NCRYPT_CIPHER_OPERATION = BCrypt.AlgorithmOperations.BCRYPT_CIPHER_OPERATION,

            /// <summary>
            /// Include the hash algorithms in the enumeration.
            /// </summary>
            NCRYPT_HASH_OPERATION = BCrypt.AlgorithmOperations.BCRYPT_HASH_OPERATION,

            /// <summary>
            /// Include the asymmetric encryption algorithms in the enumeration.
            /// </summary>
            NCRYPT_ASYMMETRIC_ENCRYPTION_OPERATION = BCrypt.AlgorithmOperations.BCRYPT_ASYMMETRIC_ENCRYPTION_OPERATION,

            /// <summary>
            /// Include the secret agreement algorithms in the enumeration.
            /// </summary>
            NCRYPT_SECRET_AGREEMENT_OPERATION = BCrypt.AlgorithmOperations.BCRYPT_SECRET_AGREEMENT_OPERATION,

            /// <summary>
            /// Include the signature algorithms in the enumeration.
            /// </summary>
            NCRYPT_SIGNATURE_OPERATION = BCrypt.AlgorithmOperations.BCRYPT_SIGNATURE_OPERATION,

            /// <summary>
            /// Include the random number generator (RNG) algorithms in the enumeration.
            /// </summary>
            NCRYPT_RNG_OPERATION = BCrypt.AlgorithmOperations.BCRYPT_RNG_OPERATION,

            NCRYPT_KEY_DERIVATION_OPERATION = BCrypt.AlgorithmOperations.BCRYPT_KEY_DERIVATION_OPERATION,
        }
    }
}
