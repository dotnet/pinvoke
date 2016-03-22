// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    /// <content>
    /// Contains the <see cref="InterfaceIdentifiers"/> nested type.
    /// </content>
    public partial class NCrypt
    {
        /// <summary>
        /// Identifiers that are used to identify a CNG cryptographic interface.
        /// In CNG, an interface identifies the type of cryptographic behavior that a provider supports. For example, a provider may be a random number generator or it may be a hashing provider.
        /// </summary>
        public enum InterfaceIdentifiers : uint
        {
            /// <summary>
            /// The algorithm belongs to the asymmetric encryption class of algorithms.
            /// </summary>
            NCRYPT_ASYMMETRIC_ENCRYPTION_INTERFACE = BCrypt.InterfaceIdentifiers.BCRYPT_ASYMMETRIC_ENCRYPTION_INTERFACE,

            /// <summary>
            /// The algorithm belongs to the secret agreement (Diffie-Hellman) class of algorithms.
            /// </summary>
            NCRYPT_SECRET_AGREEMENT_INTERFACE = BCrypt.InterfaceIdentifiers.BCRYPT_SECRET_AGREEMENT_INTERFACE,

            /// <summary>
            /// The algorithm belongs to the signature class of algorithms.
            /// </summary>
            NCRYPT_SIGNATURE_INTERFACE = BCrypt.InterfaceIdentifiers.BCRYPT_SIGNATURE_INTERFACE,

            /// <summary>
            /// The key storage interface.
            /// </summary>
            NCRYPT_KEY_STORAGE_INTERFACE = 0x00010001,

            /// <summary>
            /// The Schannel signature interface.
            /// </summary>
            NCRYPT_SCHANNEL_INTERFACE = 0x00010002,

            /// <summary>
            /// The Schannel cipher suite interface.
            /// </summary>
            NCRYPT_SCHANNEL_SIGNATURE_INTERFACE = 0x00010003,
        }
    }
}
