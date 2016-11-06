// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Runtime.InteropServices;

    /// <content>
    /// Methods and nested types that are not strictly P/Invokes but provide
    /// a slightly higher level of functionality to ease calling into native code.
    /// </content>
    public static partial class Crypt32
    {
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
        /// <param name="cryptHandle">
        /// Receives a safe handle to either CNG key handle of type NCRYPT_KEY_HANDLE or CryptoAPI provider handle of type HCRYPTPROV.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is nonzero.
        /// If the function fails, the return value is zero.
        /// </returns>
        public static unsafe bool CryptAcquireCertificatePrivateKey(
            IntPtr pCert,
            CryptAcquireCertificatePrivateKeyFlags dwFlags,
            IntPtr pvParameters,
            out SafeHandle cryptHandle)
        {
            IntPtr cryptProvOrNCryptKey;
            uint keySpec;
            bool callerFreeProvOrNCryptKey;

            if (!CryptAcquireCertificatePrivateKey(
                pCert,
                dwFlags,
                (void*)pvParameters,
                out cryptProvOrNCryptKey,
                out keySpec,
                out callerFreeProvOrNCryptKey))
            {
                cryptHandle = AdvApi32.SafeCryptographicProviderHandle.Null;
                return false;
            }

            if (keySpec == CERT_NCRYPT_KEY_SPEC)
            {
                cryptHandle = new NCrypt.SafeKeyHandle(cryptProvOrNCryptKey, callerFreeProvOrNCryptKey);
            }
            else
            {
                cryptHandle = new AdvApi32.SafeCryptographicProviderHandle(cryptProvOrNCryptKey, callerFreeProvOrNCryptKey);
            }

            return true;
        }
    }
}
