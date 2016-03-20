// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Runtime.InteropServices;

    /// <summary>
    /// Exported functions from the Crypt32.dll Windows library
    /// that are available to Desktop and Store apps.
    /// </summary>
    [OfferFriendlyOverloads]
    public static partial class Crypt32
    {
        /// <summary>
        /// The PFXImportCertStore function imports a PFX BLOB and returns the handle of a store that contains certificates and any associated private keys.
        /// </summary>
        /// <param name="pPFX">A pointer to a <see cref="CRYPT_DATA_BLOB"/> structure that contains a PFX packet with the exported and encrypted certificates and keys.</param>
        /// <param name="szPassword">
        /// A string password used to decrypt and verify the PFX packet. Whether set to a string of length greater than zero or set to an empty string or to NULL, this value must be exactly the same as the value that was used to encrypt the packet.
        /// Beginning with Windows 8 and Windows Server 2012, if the PFX packet was created in the PFXExportCertStoreEx function by using the PKCS12_PROTECT_TO_DOMAIN_SIDS flag, the PFXImportCertStore function attempts to decrypt the password by using the Active Directory (AD) principal that was used to encrypt it. The AD principal is specified in the pvPara parameter. If the szPassword parameter in the PFXExportCertStoreEx function was an empty string or NULL and the dwFlags parameter was set to PKCS12_PROTECT_TO_DOMAIN_SIDS, that function randomly generated a password and encrypted it to the AD principal specified in the pvPara parameter. In that case you should set the password to the value, empty string or NULL, that was used when the PFX packet was created. The PFXImportCertStore function will use the AD principal to decrypt the random password, and the randomly generated password will be used to decrypt the PFX certificate.
        /// When you have finished using the password, clear it from memory by calling the SecureZeroMemory function. For more information about protecting passwords, see Handling Passwords.
        /// </param>
        /// <param name="dwFlags">This parameter can be one of the following values.</param>
        /// <returns>
        /// If the function succeeds, the function returns a handle to a certificate store that contains the imported certificates, including available private keys.
        /// If the function fails, that is, if the password parameter does not contain an exact match with the password used to encrypt the exported packet or if there were any other problems decoding the PFX BLOB, the function returns NULL, and an error code can be found by calling the GetLastError function.
        /// </returns>
        [DllImport(nameof(Crypt32), CharSet = CharSet.Unicode, SetLastError = true)]
        public static unsafe extern SafeCertStoreHandle PFXImportCertStore(
            ref CRYPT_DATA_BLOB pPFX,
            string szPassword,
            PFXImportCertStoreFlags dwFlags);

        /// <summary>
        /// The CertCloseStore function closes a certificate store handle and reduces the reference count on the store. There needs to be a corresponding call to CertCloseStore for each successful call to the CertOpenStore or CertDuplicateStore functions.
        /// </summary>
        /// <param name="hCertStore">Handle of the certificate store to be closed.</param>
        /// <param name="dwFlags">
        /// Typically, this parameter uses the default value <see cref="CertCloseStoreFlags.None"/>. The default is to close the store with memory remaining allocated for contexts that have not been freed. In this case, no check is made to determine whether memory for contexts remains allocated.
        /// Set flags can force the freeing of memory for all of a store's certificate, certificate revocation list (CRL), and certificate trust list (CTL) contexts when the store is closed. Flags can also be set that check whether all of the store's certificate, CRL, and CTL contexts have been freed.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is TRUE.
        /// If the function fails, the return value is FALSE. For extended error information, call GetLastError.
        /// If <see cref="CertCloseStoreFlags.CERT_CLOSE_STORE_CHECK_FLAG"/> is not set or if it is set and all contexts associated with the store have been freed, the return value is TRUE.
        /// If <see cref="CertCloseStoreFlags.CERT_CLOSE_STORE_CHECK_FLAG"/> is set and memory for one or more contexts associated with the store remains allocated, the return value is FALSE. The store is always closed even when the function returns FALSE. For details, see Remarks.
        /// GetLastError is set to CRYPT_E_PENDING_CLOSE if memory for contexts associated with the store remains allocated. Any existing value returned by GetLastError is preserved unless <see cref="CertCloseStoreFlags.CERT_CLOSE_STORE_CHECK_FLAG"/> is set.
        /// </returns>
        [DllImport(nameof(Crypt32), SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool CertCloseStore(IntPtr hCertStore, CertCloseStoreFlags dwFlags = CertCloseStoreFlags.None);

        [DllImport(nameof(Crypt32), CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern bool CertGetCertificateContextProperty(
                IntPtr pCertContext,
                CertPropId dwPropId,
                IntPtr pvData,
                ref uint pcbData);
    }
}
