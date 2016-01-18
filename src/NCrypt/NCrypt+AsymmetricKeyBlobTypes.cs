// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <content>
    /// Contains the <see cref="AsymmetricKeyBlobTypes"/> nested type.
    /// </content>
    public partial class NCrypt
    {
        /// <summary>
        /// Identifies the blob types of asymmetric keys.
        /// </summary>
        public class AsymmetricKeyBlobTypes : BCrypt.AsymmetricKeyBlobTypes
        {
            /// <summary>
            /// The BLOB is a cipher key contained in a NCRYPT_KEY_BLOB_HEADER structure.
            /// </summary>
            public const string NCRYPT_CIPHER_KEY_BLOB = "CipherKeyBlob";

            /// <summary>
            /// The BLOB is a key in a format that is specific to a single CSP and is suitable for transport. Opaque BLOBs are not transferable and must be imported by using the same CSP that generated the BLOB.
            /// </summary>
            public const string NCRYPT_OPAQUETRANSPORT_BLOB = "OpaqueTransport";

            /// <summary>
            /// The BLOB is a PKCS #7 envelope BLOB. The parameters identified by the pParameterList parameter either can or must contain the following parameters, as indicated by the Required or optional column.
            /// <list type="bullet">
            /// <item>NCRYPTBUFFER_CERT_BLOB: required</item>
            /// <item>NCRYPTBUFFER_PKCS_KEY_NAME: optional</item>
            /// </list>
            /// </summary>
            public const string NCRYPT_PKCS7_ENVELOPE_BLOB = "PKCS7_ENVELOPE";

            /// <summary>
            /// The BLOB is a PKCS #8 private key BLOB. The parameters identified by the pParameterList parameter either can or must contain the following parameters, as indicated by the Required or optional column.
            /// <list type="bullet">
            /// <item>NCRYPTBUFFER_PKCS_KEY_NAME: optional</item>
            /// <item>NCRYPTBUFFER_PKCS_SECRET: optional</item>
            /// </list>
            /// </summary>
            public const string NCRYPT_PKCS8_PRIVATE_KEY_BLOB = "PKCS8_PRIVATEKEY";

            /// <summary>
            /// The BLOB is a protected key contained in a <see cref="NCRYPT_KEY_BLOB_HEADER"/> structure.
            /// </summary>
            public const string NCRYPT_PROTECTED_KEY_BLOB = "ProtectedKeyBlob";

            /// <summary>
            /// Initializes a new instance of the <see cref="AsymmetricKeyBlobTypes"/> class.
            /// </summary>
            /// <remarks>
            /// Suppresses generation of a public default constructor.
            /// </remarks>
            protected AsymmetricKeyBlobTypes()
            {
            }
        }
    }
}
