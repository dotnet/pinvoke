// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    /// <content>
    /// Contains the <see cref="BufferType"/> nested type.
    /// </content>
    public partial class BCrypt
    {
        /// <summary>
        /// Types of data stored in <see cref="BCryptBuffer"/>.
        /// </summary>
        public enum BufferType
        {
            /// <summary>
            /// The buffer is a key derivation function (KDF) parameter that contains a null-terminated Unicode string that identifies the hash algorithm. This can be one of the standard hash algorithm identifiers from CNG Algorithm Identifiers or the identifier for another registered hash algorithm.
            /// The size specified by the <see cref="BCryptBuffer.cbBuffer"/> member of this structure must include the terminating NULL character.
            /// </summary>
            KDF_HASH_ALGORITHM = 0,

            /// <summary>
            /// The buffer is a KDF parameter that contains the value to add to the beginning of the message that is input to the hash function.
            /// </summary>
            KDF_SECRET_PREPEND = 1,

            /// <summary>
            /// The buffer is a KDF parameter that contains the value to add to the end of the message that is input to the hash function.
            /// </summary>
            KDF_SECRET_APPEND = 2,

            /// <summary>
            /// The buffer is a KDF parameter that contains the plain text value of the HMAC key.
            /// </summary>
            KDF_HMAC_KEY = 3,

            /// <summary>
            /// The buffer is a KDF parameter that contains an ANSI string that contains the transport layer security (TLS) pseudo-random function (PRF) label.
            /// </summary>
            KDF_TLS_PRF_LABEL = 4,

            /// <summary>
            /// The buffer is a KDF parameter that contains the PRF seed value. The seed must be 64 bytes long.
            /// </summary>
            KDF_TLS_PRF_SEED = 5,

            /// <summary>
            /// The buffer is a KDF parameter that contains the secret agreement handle. The <see cref="BCryptBuffer.pvBuffer"/> member contains a BCRYPT_SECRET_HANDLE value and is not a pointer.
            /// </summary>
            KDF_SECRET_HANDLE = 6,

            /// <summary>
            /// The buffer is a KDF parameter that contains a DWORD value identifying the SSL/TLS protocol version whose PRF algorithm is to be used.
            /// </summary>
            KDF_TLS_PRF_PROTOCOL = 7,

            /// <summary>
            /// The buffer is a KDF parameter that contains the byte array to use as the AlgorithmID subfield of the OtherInfo parameter to the SP 800-56A KDF.
            /// </summary>
            KDF_ALGORITHMID = 8,

            /// <summary>
            /// The buffer is a KDF parameter that contains the byte array to use as the PartyUInfo subfield of the OtherInfo parameter to the SP 800-56A KDF.
            /// </summary>
            KDF_PARTYUINFO = 9,

            /// <summary>
            /// The buffer is a KDF parameter that contains the byte array to use as the PartyVInfo subfield of the OtherInfo parameter to the SP 800-56A KDF.
            /// </summary>
            KDF_PARTYVINFO = 10,

            /// <summary>
            /// The buffer is a KDF parameter that contains the byte array to use as the SuppPubInfo subfield of the OtherInfo parameter to the SP 800-56A KDF.
            /// </summary>
            KDF_SUPPPUBINFO = 11,

            /// <summary>
            /// The buffer is a KDF parameter that contains the byte array to use as the SuppPrivInfo subfield of the OtherInfo parameter to the SP 800-56A KDF.
            /// </summary>
            KDF_SUPPPRIVINFO = 12,

            KDF_LABEL = 13,

            KDF_CONTEXT = 14,

            KDF_SALT = 15,

            KDF_ITERATION_COUNT = 16,
        }
    }
}
