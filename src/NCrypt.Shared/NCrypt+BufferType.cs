// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    /// <content>
    /// Contains the <seealso cref="BufferType"/> nested type.
    /// </content>
    public partial class NCrypt
    {
        /// <summary>
        /// Types of data stored in <see cref="NCryptBuffer"/>.
        /// </summary>
        /// <seealso cref="BCrypt.BufferType"/>
        public enum BufferType
        {
            /// <summary>
            /// The buffer is a key derivation function (KDF) parameter that contains a null-terminated Unicode string that identifies the hash algorithm. This can be one of the standard hash algorithm identifiers from CNG Algorithm Identifiers or the identifier for another registered hash algorithm.
            /// The size specified by the <see cref="NCryptBuffer.cbBuffer"/> member of this structure must include the terminating NULL character.
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
            /// The buffer is a KDF parameter that contains the secret agreement handle. The <see cref="NCryptBuffer.pvBuffer"/> member contains a BCRYPT_SECRET_HANDLE value and is not a pointer.
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

            /// <summary>
            /// The buffer contains the random number of the SSL client.
            /// </summary>
            NCRYPTBUFFER_SSL_CLIENT_RANDOM = 20,

            /// <summary>
            /// The buffer contains the random number of the SSL server.
            /// </summary>
            NCRYPTBUFFER_SSL_SERVER_RANDOM = 21,

            /// <summary>
            /// The buffer contains the highest SSL version supported.
            /// </summary>
            NCRYPTBUFFER_SSL_HIGHEST_VERSION = 22,

            /// <summary>
            /// The buffer contains the clear portion of the SSL master key.
            /// </summary>
            NCRYPTBUFFER_SSL_CLEAR_KEY = 23,

            /// <summary>
            /// The buffer contains the SSL key argument data.
            /// </summary>
            NCRYPTBUFFER_SSL_KEY_ARG_DATA = 24,

            /// <summary>
            /// The buffer contains a null-terminated ANSI string that contains the PKCS object identifier.
            /// </summary>
            NCRYPTBUFFER_PKCS_OID = 40,

            /// <summary>
            /// The buffer contains a null-terminated ANSI string that contains the PKCS algorithm object identifier.
            /// </summary>
            NCRYPTBUFFER_PKCS_ALG_OID = 41,

            /// <summary>
            /// The buffer contains the PKCS algorithm parameters.
            /// </summary>
            NCRYPTBUFFER_PKCS_ALG_PARAM = 42,

            /// <summary>
            /// The buffer contains the PKCS algorithm identifier.
            /// </summary>
            NCRYPTBUFFER_PKCS_ALG_ID = 43,

            /// <summary>
            /// The buffer contains the PKCS attributes.
            /// </summary>
            NCRYPTBUFFER_PKCS_ATTRS = 44,

            /// <summary>
            /// The buffer contains a null-terminated Unicode string that contains the key name.
            /// </summary>
            NCRYPTBUFFER_PKCS_KEY_NAME = 45,

            /// <summary>
            /// The buffer contains a null-terminated Unicode string that contains the PKCS8 password. This parameter is optional and can be NULL.
            /// </summary>
            NCRYPTBUFFER_PKCS_SECRET = 46,

            /// <summary>
            /// The buffer contains a serialized certificate store that contains the PKCS certificate. This serialized store is obtained by using the CertSaveStore function with the CERT_STORE_SAVE_TO_MEMORY option. When this property is being retrieved, you can access the certificate store by passing this serialized store to the CertOpenStore function with the CERT_STORE_PROV_SERIALIZED option.
            /// </summary>
            NCRYPTBUFFER_CERT_BLOB = 47,
        }
    }
}
