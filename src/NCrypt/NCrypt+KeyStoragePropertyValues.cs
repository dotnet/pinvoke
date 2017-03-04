// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <content>
    /// Sourced from: https://msdn.microsoft.com/en-us/library/windows/desktop/aa376242(v=vs.85).aspx
    /// </content>
    public partial class NCrypt
    {
        public static class KeyStoragePropertyValues
        {
            /// <summary>
            /// Specifies the maximum size of a property value, in bytes.
            /// </summary>
            public const int NCRYPT_MAX_PROPERTY_DATA = 0x100000;

            /// <summary>
            /// Specifies the maximum size of a property name, in characters.
            /// </summary>
            public const int NCRYPT_MAX_PROPERTY_NAME = 64;

            [Flags]
            public enum NCRYPT_EXPORT_POLICY_PROPERTY
            {
                /// <summary>
                /// No flags.
                /// </summary>
                None = 0x0,

                /// <summary>
                /// The private key can be exported.
                /// </summary>
                NCRYPT_ALLOW_EXPORT_FLAG = 0x1,

                /// <summary>
                /// The private key can be exported in plaintext form.
                /// </summary>
                NCRYPT_ALLOW_PLAINTEXT_EXPORT_FLAG = 0x2,

                /// <summary>
                /// The private key can be exported once for archiving purposes. This flag only applies to the original key handle on which it is set. This policy can only be applied to the original key handle. After the key handle has been closed, the key can no longer be exported for archiving purposes.
                /// </summary>
                NCRYPT_ALLOW_ARCHIVING_FLAG = 0x4,

                /// <summary>
                /// The private key can be exported once in plaintext form for archiving purposes. This flag only applies to the original key handle on which it is set. This policy can only be applied to the original key handle. After the key handle has been closed, the key can no longer be exported for archiving purposes.
                /// </summary>
                NCRYPT_ALLOW_PLAINTEXT_ARCHIVING_FLAG = 0x8,
            }

            [Flags]
            public enum NCRYPT_IMPL_TYPE_PROPERTY
            {
                /// <summary>
                /// No flags.
                /// </summary>
                None = 0x0,

                /// <summary>
                /// The provider is hardware based.
                /// </summary>
                NCRYPT_IMPL_HARDWARE_FLAG = 0x1,

                /// <summary>
                /// The provider is software based.
                /// </summary>
                NCRYPT_IMPL_SOFTWARE_FLAG = 0x2,

                /// <summary>
                /// The provider is removable.
                /// </summary>
                NCRYPT_IMPL_REMOVABLE_FLAG = 0x8,

                /// <summary>
                /// The provider is a hardware based random number generator.
                /// </summary>
                NCRYPT_IMPL_HARDWARE_RNG_FLAG = 0x10,
            }

            public enum NCRYPT_KEY_TYPE_PROPERTY
            {
                /// <summary>
                /// No flags.
                /// </summary>
                None = 0x0,

                /// <summary>
                /// The key applies to the local computer. If this flag is not present, the key applies to the current user.
                /// </summary>
                NCRYPT_MACHINE_KEY_FLAG = 0x1,
            }

            [Flags]
            public enum NCRYPT_KEY_USAGE_PROPERTY
            {
                /// <summary>
                /// No flags.
                /// </summary>
                None = 0x0,

                /// <summary>
                /// The key can be used for decryption.
                /// </summary>
                NCRYPT_ALLOW_DECRYPT_FLAG = 0x1,

                /// <summary>
                /// The key can be used for signing.
                /// </summary>
                NCRYPT_ALLOW_SIGNING_FLAG = 0x2,

                /// <summary>
                /// The key can be used for secret agreement encryption.
                /// </summary>
                NCRYPT_ALLOW_KEY_AGREEMENT_FLAG = 0x4,

                /// <summary>
                /// The key can be used for any purpose.
                /// </summary>
                NCRYPT_ALLOW_ALL_USAGES = 0x00ffffff,
            }

            public static class NCRYPT_ALGORITHM_GROUP_PROPERTY
            {
                /// <summary>
                /// The RSA algorithm group.
                /// </summary>
                public const string NCRYPT_RSA_ALGORITHM_GROUP = "RSA";

                /// <summary>
                /// The Diffie-Hellman algorithm group.
                /// </summary>
                public const string NCRYPT_DH_ALGORITHM_GROUP = "DH";

                /// <summary>
                /// The DSA algorithm group.
                /// </summary>
                public const string NCRYPT_DSA_ALGORITHM_GROUP = "DSA";

                /// <summary>
                /// The elliptic curve DSA algorithm group.
                /// </summary>
                public const string NCRYPT_ECDSA_ALGORITHM_GROUP = "ECDSA";

                /// <summary>
                /// The elliptic curve Diffie-Hellman algorithm group.
                /// </summary>
                public const string NCRYPT_ECDH_ALGORITHM_GROUP = "ECDH";
            }
        }
    }
}
