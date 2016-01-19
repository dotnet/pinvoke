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
            /// And may contain any of the values defined by <see cref="KeyStoragePropertyValues.NCRYPT_ALGORITHM_GROUP_PROPERTY"/>.
            /// </summary>
            public const string NCRYPT_ALGORITHM_GROUP_PROPERTY = "Algorithm Group";

            /// <summary>
            /// A null-terminated Unicode string that contains the name of the object's algorithm. This can be one of the predefined CNG <see cref="BCrypt.AlgorithmIdentifiers"/> or another registered algorithm identifier. This property only applies to keys.
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
            public const string NCRYPT_DH_PARAMETERS_PROPERTY = BCrypt.PropertyNames.BCRYPT_DH_PARAMETERS;

            public const string NCRYPT_NAME_PROPERTY = "Name";
            public const string NCRYPT_UNIQUE_NAME_PROPERTY = "Unique Name";
            public const string NCRYPT_LENGTH_PROPERTY = "Length";
            public const string NCRYPT_LENGTHS_PROPERTY = "Lengths";
            public const string NCRYPT_CHAINING_MODE_PROPERTY = "Chaining Mode";
            public const string NCRYPT_AUTH_TAG_LENGTH = "AuthTagLength";
            public const string NCRYPT_UI_POLICY_PROPERTY = "UI Policy";

            /// <summary>
            /// A DWORD that contains a set of flags that specify the export policy for a persisted key. This property only applies to keys.
            /// This can contain zero or a combination of one or more of the values defined by <see cref="KeyStoragePropertyValues.NCRYPT_EXPORT_POLICY_PROPERTY"/>.
            /// </summary>
            public const string NCRYPT_EXPORT_POLICY_PROPERTY = "Export Policy";
            public const string NCRYPT_WINDOW_HANDLE_PROPERTY = "HWND Handle";
            public const string NCRYPT_USE_CONTEXT_PROPERTY = "Use Context";

            /// <summary>
            /// A DWORD that contains a set of flags that define the usage details for a key. This property only applies to keys.
            /// This can contain zero or a combination of one or more of the values defined by <see cref="KeyStoragePropertyValues.NCRYPT_KEY_USAGE_PROPERTY"/>.
            /// </summary>
            public const string NCRYPT_KEY_USAGE_PROPERTY = "Key Usage";

            /// <summary>
            /// A DWORD that contains a set of flags that define the key type. This property only applies to keys.
            /// This can contain zero or the value defined by <see cref="KeyStoragePropertyValues.NCRYPT_KEY_TYPE_PROPERTY"/>.
            /// </summary>
            public const string NCRYPT_KEY_TYPE_PROPERTY = "Key Type";
            public const string NCRYPT_VERSION_PROPERTY = "Version";
            public const string NCRYPT_SECURITY_DESCR_SUPPORT_PROPERTY = "Security Descr Support";
            public const string NCRYPT_SECURITY_DESCR_PROPERTY = "Security Descr";
            public const string NCRYPT_USE_COUNT_ENABLED_PROPERTY = "Enabled Use Count";
            public const string NCRYPT_USE_COUNT_PROPERTY = "Use Count";
            public const string NCRYPT_LAST_MODIFIED_PROPERTY = "Modified";
            public const string NCRYPT_MAX_NAME_LENGTH_PROPERTY = "Max Name Length";
            public const string NCRYPT_PROVIDER_HANDLE_PROPERTY = "Provider Handle";
            public const string NCRYPT_PIN_PROPERTY = "SmartCardPin";
            public const string NCRYPT_READER_PROPERTY = "SmartCardReader";
            public const string NCRYPT_SMARTCARD_GUID_PROPERTY = "SmartCardGuid";
            public const string NCRYPT_PIN_PROMPT_PROPERTY = "SmartCardPinPrompt";
            public const string NCRYPT_USER_CERTSTORE_PROPERTY = "SmartCardUserCertStore";
            public const string NCRYPT_ROOT_CERTSTORE_PROPERTY = "SmartcardRootCertStore";
            public const string NCRYPT_SECURE_PIN_PROPERTY = "SmartCardSecurePin";
            public const string NCRYPT_SCARD_PIN_ID = "SmartCardPinId";
            public const string NCRYPT_SCARD_PIN_INFO = "SmartCardPinInfo";
            public const string NCRYPT_READER_ICON_PROPERTY = "SmartCardReaderIcon";
            public const string NCRYPT_KDF_SECRET_VALUE = "KDFKeySecret";
            public const string NCRYPT_PCP_PLATFORM_TYPE_PROPERTY = "PCP_PLATFORM_TYPE";
            public const string NCRYPT_PCP_PROVIDER_VERSION_PROPERTY = "PCP_PROVIDER_VERSION";
            public const string NCRYPT_PCP_EKPUB_PROPERTY = "PCP_EKPUB";
            public const string NCRYPT_PCP_EKCERT_PROPERTY = "PCP_EKCERT";
            public const string NCRYPT_PCP_EKNVCERT_PROPERTY = "PCP_EKNVCERT";
            public const string NCRYPT_PCP_SRKPUB_PROPERTY = "PCP_SRKPUB";
            public const string NCRYPT_PCP_PCRTABLE_PROPERTY = "PCP_PCRTABLE";
            public const string NCRYPT_PCP_CHANGEPASSWORD_PROPERTY = "PCP_CHANGEPASSWORD";
            public const string NCRYPT_PCP_PASSWORD_REQUIRED_PROPERTY = "PCP_PASSWORD_REQUIRED";
            public const string NCRYPT_PCP_USAGEAUTH_PROPERTY = "PCP_USAGEAUTH";
            public const string NCRYPT_PCP_MIGRATIONPASSWORD_PROPERTY = "PCP_MIGRATIONPASSWORD";
            public const string NCRYPT_PCP_EXPORT_ALLOWED_PROPERTY = "PCP_EXPORT_ALLOWED";
            public const string NCRYPT_PCP_STORAGEPARENT_PROPERTY = "PCP_STORAGEPARENT";
            public const string NCRYPT_PCP_PROVIDERHANDLE_PROPERTY = "PCP_PROVIDERMHANDLE";
            public const string NCRYPT_PCP_PLATFORMHANDLE_PROPERTY = "PCP_PLATFORMHANDLE";
            public const string NCRYPT_PCP_PLATFORM_BINDING_PCRMASK_PROPERTY = "PCP_PLATFORM_BINDING_PCRMASK";
            public const string NCRYPT_PCP_PLATFORM_BINDING_PCRDIGESTLIST_PROPERTY = "PCP_PLATFORM_BINDING_PCRDIGESTLIST";
            public const string NCRYPT_PCP_PLATFORM_BINDING_PCRDIGEST_PROPERTY = "PCP_PLATFORM_BINDING_PCRDIGEST";
            public const string NCRYPT_PCP_KEY_USAGE_POLICY_PROPERTY = "PCP_KEY_USAGE_POLICY";
            public const string NCRYPT_PCP_TPM12_IDBINDING_PROPERTY = "PCP_TPM12_IDBINDING";
            public const string NCRYPT_PCP_TPM12_IDBINDING_DYNAMIC_PROPERTY = "PCP_TPM12_IDBINDING_DYNAMIC";
            public const string NCRYPT_PCP_TPM12_IDACTIVATION_PROPERTY = "PCP_TPM12_IDACTIVATION";
            public const string NCRYPT_PCP_KEYATTESTATION_PROPERTY = "PCP_TPM12_KEYATTESTATION";
            public const string NCRYPT_PCP_ALTERNATE_KEY_STORAGE_LOCATION_PROPERTY = "PCP_ALTERNATE_KEY_STORAGE_LOCATION";

            /// <summary>
            /// A DWORD that contains a set of flags that define implementation details of the provider. This property only applies to key storage providers.
            /// This can contain zero or a combination of one or more of the values defined by the <see cref="KeyStoragePropertyValues.NCRYPT_IMPL_TYPE_PROPERTY"/> enum.
            /// </summary>
            public const string NCRYPT_IMPL_TYPE_PROPERTY = "Impl Type";
        }
    }
}
