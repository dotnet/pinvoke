// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PInvoke
{
    using System;

    /// <content>
    /// Contains the <see cref="PFXImportCertStoreFlags"/> nested type.
    /// </content>
    public partial class Crypt32
    {
        /// <summary>
        /// Option flags for the <see cref="PFXImportCertStore(ref CRYPT_DATA_BLOB, string, PFXImportCertStoreFlags)"/> method.
        /// </summary>
        [Flags]
        public enum PFXImportCertStoreFlags
        {
            /// <summary>
            /// No flags.
            /// </summary>
            None = 0x0,

            /// <summary>
            /// Imported keys are marked as exportable. If this flag is not used, calls to the CryptExportKey function with the key handle fail.
            /// </summary>
            CRYPT_EXPORTABLE = 0x1,

            /// <summary>
            /// The user is to be notified through a dialog box or other method when certain attempts to use this key are made. The precise behavior is specified by the cryptographic service provider (CSP) being used.
            /// Prior to Internet Explorer 4.0, Microsoft cryptographic service providers ignored this flag. Starting with Internet Explorer 4.0, Microsoft providers support this flag.
            /// If the provider context was opened with the CRYPT_SILENT flag set, using this flag causes a failure and the last error is set to NTE_SILENT_CONTEXT.
            /// </summary>
            CRYPT_USER_PROTECTED = 0x2,

            /// <summary>
            /// The private keys are stored under the local computer and not under the current user.
            /// </summary>
            CRYPT_MACHINE_KEYSET = 0x20,

            /// <summary>
            /// The private keys are stored under the current user and not under the local computer even if the PFX BLOB specifies that they should go into the local computer.
            /// </summary>
            CRYPT_USER_KEYSET = 0x1000,

            /// <summary>
            /// Indicates that the CNG key storage provider (KSP) is preferred. If the CSP is specified in the PFX file, then the CSP is used, otherwise the KSP is preferred. If the CNG KSP is unavailable, the PFXImportCertStore function will fail.
            /// Windows Server 2003 and Windows XP:  This value is not supported.
            /// </summary>
            PKCS12_PREFER_CNG_KSP = 0x100,

            /// <summary>
            /// Indicates that the CNG KSP is always used. When specified, PFXImportCertStore attempts to use the CNG KSP irrespective of provider information in the PFX file. If the CNG KSP is unavailable, the import will not fail.
            /// Windows Server 2003 and Windows XP:  This value is not supported.
            /// </summary>
            PKCS12_ALWAYS_CNG_KSP = 0x200,

            /// <summary>
            /// Allow overwrite of the existing key. Specify this flag when you encounter a scenario in which you must import a PFX file that contains a key name that already exists. For example, when you import a PFX file, it is possible that a container of the same name is already present because there is no unique namespace for key containers. If you have created a "TestKey" on your computer, and then you import a PFX file that also has "TestKey" as the key container, the PKCS12_ALLOW_OVERWRITE_KEY setting allows the key to be overwritten.
            /// Windows Server 2003 and Windows XP:  This value is not supported.
            /// </summary>
            PKCS12_ALLOW_OVERWRITE_KEY = 0x4000,

            /// <summary>
            /// Do not persist the key. Specify this flag when you do not want to persist the key. For example, if it is not necessary to store the key after verification, then instead of creating a container and then deleting it, you can specify this flag to dispose of the key immediately.
            /// Note  If the PKCS12_NO_PERSIST_KEY flag is not set, keys are persisted on disk. If you do not want to persist the keys beyond their usage, you must delete them by calling the CryptAcquireContext function with the CRYPT_DELETEKEYSET flag set in the dwFlags parameter.
            /// Windows Server 2003 and Windows XP:  This value is not supported.
            /// </summary>
            PKCS12_NO_PERSIST_KEY = 0x8000,

            /// <summary>
            /// Import all extended properties on the certificate that were saved on the certificate when it was exported.
            /// Windows Server 2003 and Windows XP:  This value is not supported.
            /// </summary>
            PKCS12_INCLUDE_EXTENDED_PROPERTIES = 0x10,

            /// <summary>
            /// Unpack but do not persist the results.
            /// </summary>
            UnnamedValue = 0x10000000,
        }
    }
}
