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
        /// The key is a CNG key.
        /// Windows Server 2003 and Windows XP:  This value is not supported.
        /// </summary>
        public const uint CERT_NCRYPT_KEY_SPEC = 0xFFFFFFFF;

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
        public static extern SafeCertStoreHandle PFXImportCertStore(
            ref CRYPT_DATA_BLOB pPFX,
            string szPassword,
            PFXImportCertStoreFlags dwFlags);

        /// <summary>
        /// The CertGetCertificateContextProperty function retrieves the information contained in an extended property of a certificate context.
        /// </summary>
        /// <param name="pCertContext">A pointer to the CERT_CONTEXT structure of the certificate that contains the property to be retrieved.</param>
        /// <param name="dwPropId">The property to be retrieved.</param>
        /// <param name="pvData">
        /// A pointer to a buffer to receive the data as determined by dwPropId
        /// Structures pointed to by members of a structure returned are also returned following the base structure. Therefore, the size contained in pcbData often exceeds the size of the base structure.
        /// </param>
        /// <param name="pcbData">
        /// A pointer to a DWORD value that specifies the size, in bytes, of the buffer pointed to by the pvData parameter.
        /// When the function returns, the DWORD value contains the number of bytes to be stored in the buffer.
        /// </param>
        /// <returns>
        /// If the function succeeds, the function returns TRUE.
        /// If the function fails, it returns FALSE.
        /// </returns>
        [DllImport(nameof(Crypt32), SetLastError = true)]
        public static extern unsafe bool CertGetCertificateContextProperty(
            IntPtr pCertContext,
            CERT_PROP_ID dwPropId,
            void* pvData,
            ref int pcbData);

        /// <summary>
        /// Obtains the private key for a certificate. This function is used to obtain access to a user's private key when the user's certificate is available, but the handle of the user's key container is not available. This function can only be used by the owner of a private key and not by any other user.
        /// If a CSP handle and the key container containing a user's private key are available, the CryptGetUserKey function should be used instead.
        /// </summary>
        /// <param name="pCert">The address of a CERT_CONTEXT structure that contains the certificate context for which a private key will be obtained.</param>
        /// <param name="dwFlags">A set of flags that modify the behavior of this function. This can be zero or a combination of one or more of <see cref="CryptAcquireCertificatePrivateKeyFlags"/> values.</param>
        /// <param name="pvParameters">
        /// If the <see cref="CryptAcquireCertificatePrivateKeyFlags.CRYPT_ACQUIRE_WINDOW_HANDLE_FLAG"/> is set, then this is the address of an HWND. If the <see cref="CryptAcquireCertificatePrivateKeyFlags.CRYPT_ACQUIRE_WINDOW_HANDLE_FLAG"/> is not set, then this parameter must be NULL.
        /// Windows Server 2008 R2, Windows 7, Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP:  This parameter was named pvReserved and reserved for future use and must be NULL.
        /// </param>
        /// <param name="phCryptProvOrNCryptKey">
        /// The address of an HCRYPTPROV_OR_NCRYPT_KEY_HANDLE variable that receives the handle of either the CryptoAPI provider or the CNG key. If the <paramref name="pdwKeySpec"/> variable receives the <see cref="CERT_NCRYPT_KEY_SPEC"/> flag, this is a CNG key handle of type NCRYPT_KEY_HANDLE; otherwise, this is a CryptoAPI provider handle of type HCRYPTPROV.
        /// For more information about when and how to release this handle, see the description of the pfCallerFreeProvOrNCryptKey parameter.
        /// </param>
        /// <param name="pdwKeySpec">The address of a DWORD variable that receives additional information about the key.</param>
        /// <param name="pfCallerFreeProvOrNCryptKey">
        /// The address of a BOOL variable that receives a value that indicates whether the caller must free the handle returned in the <paramref name="phCryptProvOrNCryptKey"/> variable.
        /// This receives FALSE if any of the following is true:
        /// - Public key acquisition or comparison fails.
        /// - The <paramref name="dwFlags"/> parameter contains the <see cref="CryptAcquireCertificatePrivateKeyFlags.CRYPT_ACQUIRE_CACHE_FLAG"/> flag.
        /// - The <paramref name="dwFlags"/> parameter contains the <see cref="CryptAcquireCertificatePrivateKeyFlags.CRYPT_ACQUIRE_USE_PROV_INFO_FLAG"/> flag, the certificate context property is set to <see cref="CERT_PROP_ID.CERT_KEY_PROV_INFO_PROP_ID"/> with the <see cref="CRYPT_KEY_PROV_INFO"/> structure, and the <paramref name="dwFlags"/> member of the <see cref="CRYPT_KEY_PROV_INFO"/> structure is set to CERT_SET_KEY_CONTEXT_PROP_ID.
        /// If this variable receives FALSE, the calling application must not release the handle returned in the <paramref name="phCryptProvOrNCryptKey"/> variable.
        /// The handle will be released on the last free action of the certificate context.
        /// If this variable receives TRUE, the caller is responsible for releasing the handle returned in the <paramref name="phCryptProvOrNCryptKey"/> variable.
        /// If the <paramref name="pdwKeySpec"/> variable receives the <see cref="CERT_NCRYPT_KEY_SPEC"/> flag, the handle must be released by passing it to the NCryptFreeObject function;
        /// otherwise, the handle is released by passing it to the CryptReleaseContext function.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is nonzero.
        /// If the function fails, the return value is zero.
        /// </returns>
        /// <devremarks>
        /// This is private because it returns an <see cref="IntPtr"/> for the handle
        /// and we don't expose the release methods publicly.
        /// A helper method strongly types it as either of two <see cref="SafeHandle"/> types.
        /// </devremarks>
        [DllImport(nameof(Crypt32), SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern unsafe bool CryptAcquireCertificatePrivateKey(
                IntPtr pCert,
                CryptAcquireCertificatePrivateKeyFlags dwFlags,
                void* pvParameters,
                out IntPtr phCryptProvOrNCryptKey,
                out uint pdwKeySpec,
                [MarshalAs(UnmanagedType.Bool)] out bool pfCallerFreeProvOrNCryptKey);

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
    }
}
