// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    /// <content>
    /// Contains the <see cref="SymmetricKeyBlobTypes"/> nested type.
    /// </content>
    public partial class BCrypt
    {
        public class SymmetricKeyBlobTypes
        {
            /// <summary>
            /// Import a symmetric key from an AES key–wrapped key BLOB. The hImportKey parameter must reference a valid BCRYPT_KEY_HANDLE pointer to the key encryption key.
            /// </summary>
            public const string BCRYPT_AES_WRAP_KEY_BLOB = "Rfc3565KeyWrapBlob";

            /// <summary>
            /// Import a symmetric key from a data BLOB. The pbInput parameter is a pointer to a <see cref="BCRYPT_KEY_DATA_BLOB_HEADER"/> structure immediately followed by the key BLOB.
            /// </summary>
            public const string BCRYPT_KEY_DATA_BLOB = "KeyDataBlob";

            /// <summary>
            /// Import a symmetric key BLOB in a format that is specific to a single CSP. Opaque BLOBs are not transferable and must be imported by using the same CSP that generated the BLOB. Opaque BLOBs are only intended to be used for interprocess transfer of keys and are not suitable to be persisted and read in across versions of a provider.
            /// </summary>
            public const string BCRYPT_OPAQUE_KEY_BLOB = "OpaqueKeyBlob";

            /// <summary>
            /// Initializes a new instance of the <see cref="SymmetricKeyBlobTypes"/> class.
            /// </summary>
            /// <remarks>
            /// Suppresses generation of a public default constructor.
            /// </remarks>
            protected SymmetricKeyBlobTypes()
            {
            }
        }
    }
}
