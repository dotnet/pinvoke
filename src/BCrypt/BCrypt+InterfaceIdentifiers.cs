// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    /// <content>
    /// Contains the <see cref="InterfaceIdentifiers"/> nested type.
    /// </content>
    public partial class BCrypt
    {
        /// <summary>
        /// Identifiers that are used to identify a CNG cryptographic interface.
        /// In CNG, an interface identifies the type of cryptographic behavior that a provider supports. For example, a provider may be a random number generator or it may be a hashing provider.
        /// </summary>
        public enum InterfaceIdentifiers : uint
        {
            /// <summary>
            /// The symmetric cipher interface.
            /// </summary>
            BCRYPT_CIPHER_INTERFACE = 0x00000001,

            /// <summary>
            /// The hash interface.
            /// </summary>
            BCRYPT_HASH_INTERFACE = 0x00000002,

            /// <summary>
            /// The algorithm belongs to the asymmetric encryption class of algorithms.
            /// </summary>
            BCRYPT_ASYMMETRIC_ENCRYPTION_INTERFACE = 0x00000003,

            /// <summary>
            /// The algorithm belongs to the secret agreement (Diffie-Hellman) class of algorithms.
            /// </summary>
            BCRYPT_SECRET_AGREEMENT_INTERFACE = 0x00000004,

            /// <summary>
            /// The algorithm belongs to the signature class of algorithms.
            /// </summary>
            BCRYPT_SIGNATURE_INTERFACE = 0x00000005,

            /// <summary>
            /// The random number generator interface.
            /// </summary>
            BCRYPT_RNG_INTERFACE = 0x00000006,

            /// <summary>
            /// The key derivation interface.
            /// </summary>
            BCRYPT_KEY_DERIVATION_INTERFACE = 0x00000007,
        }
    }
}
