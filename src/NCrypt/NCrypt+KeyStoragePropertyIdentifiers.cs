// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    /// <content>
    /// Contains the <see cref="KeyStoragePropertyIdentifiers"/> nested type.
    /// </content>
    public static partial class NCrypt
    {
        /// <summary>
        /// Defines the names of the built-in key storage property identifiers
        /// as documented by https://msdn.microsoft.com/en-us/library/windows/desktop/aa376242(v=vs.85).aspx
        /// </summary>
        public static class KeyStoragePropertyIdentifiers
        {
            /// <summary>
            /// A null-terminated Unicode string that contains the name of the object's algorithm group. This property only applies to keys.
            /// </summary>
            public const string NCRYPT_ALGORITHM_GROUP_PROPERTY = "Algorithm Group";

            /// <summary>
            /// A null-terminated Unicode string that contains the name of the object's algorithm. This can be one of the predefined CNG <see cref="AlgorithmIdentifiers"/> or another registered algorithm identifier. This property only applies to keys.
            /// </summary>
            public const string NCRYPT_ALGORITHM_PROPERTY = "Algorithm Name";

            /// <summary>
            /// An LPWSTR value that indicates the container name of the Elliptic Curve Diffie-Hellman (ECDH) key to use during logon for a given handle to an Elliptic Curve Digital Signature Algorithm (ECDSA) key. If there are no ECDH keys on the card, the key storage provider (KSP) returns NTE_NOT_FOUND. This property applies to ECDSA keys for logon with smart cards. The property is supported by the Microsoft Smart Card key storage provider and not by the Microsoft Software key storage provider.
            /// Windows Server 2008 and Windows Vista:  This value is not supported.
            /// </summary>
            public const string NCRYPT_ASSOCIATED_ECDH_KEY = "SmartCardAssociatedECDHKey";

            /// <summary>
            /// A DWORD that contains the length, in bytes, of the encryption block. This property only applies to keys that support encryption.
            /// </summary>
            public const string NCRYPT_BLOCK_LENGTH_PROPERTY = "Block Length";

            /// <summary>
            /// A BLOB that contains an X.509 certificate that is associated with the key.
            /// Windows Server 2008 R2, Windows 7, Windows Server 2008, and Windows Vista:  A BLOB that contains the smart card key certificate. This property is not supported by the Microsoft Software Key Storage Provider.
            /// </summary>
            public const string NCRYPT_CERTIFICATE_PROPERTY = "SmartCardKeyCertificate";

            /// <summary>
            /// Specifies parameters to use with a Diffie-Hellman key. This data type is a pointer to a BCRYPT_DH_PARAMETER_HEADER structure. This property can only be set and must be set for the key before the key is completed.
            /// </summary>
            public const string NCRYPT_DH_PARAMETERS_PROPERTY = "DHParameters";

            // TODO: add more constants.

            /// <summary>
            /// A DWORD that contains a set of flags that define implementation details of the provider. This property only applies to key storage providers.
            /// This can contain zero or a combination of one or more of the values defined by the <see cref="KeyStorageImplementationType"/> enum.
            /// </summary>
            public const string NCRYPT_IMPL_TYPE_PROPERTY = "Impl Type";
        }
    }
}
