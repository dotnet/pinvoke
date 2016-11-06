// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System.Runtime.InteropServices;

    /// <content>
    /// Contains the <see cref="CERT_CONTEXT"/> nested type.
    /// </content>
    public partial class Crypt32
    {
        /// <summary>
        /// Certificate property identifiers.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        [OfferIntPtrPropertyAccessors]
        public unsafe partial struct CERT_CONTEXT
        {
            /// <summary>
            /// Type of encoding used. It is always acceptable to specify both the certificate and message encoding types by combining them with a bitwise-OR operation as shown in the following example:
            /// X509_ASN_ENCODING | PKCS_7_ASN_ENCODING
            /// Currently defined encoding types are:
            /// X509_ASN_ENCODING
            /// PKCS_7_ASN_ENCODING
            /// </summary>
            public uint dwCertEncodingType; // TODO: make this an enum?

            /// <summary>
            /// A pointer to a buffer that contains the encoded certificate.
            /// </summary>
            public byte* pbCertEncoded;

            /// <summary>
            /// The size, in bytes, of the encoded certificate.
            /// </summary>
            public int cbCertEncoded;

            /// <summary>
            /// The address of a <see cref="CERT_INFO"/> structure that contains the certificate information.
            /// </summary>
            public CERT_INFO* pCertInfo;

            /// <summary>
            /// A handle to the certificate store that contains the certificate context.
            /// </summary>
            public CertStoreSafeHandle hCertStore;
        }
    }
}
