// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Runtime.InteropServices;
    using CLRMetaHost;

    /// <content>
    /// Methods and nested types that are not strictly P/Invokes but provide
    /// a slightly higher level of functionality to ease calling into native code.
    /// </content>
    public static partial class MSCorEE
    {
        /// <summary>
        /// Creates an instance of <see cref="ICLRMetaHost"/>.
        /// </summary>
        /// <returns>The host.</returns>
        public static ICLRMetaHost CreateClrMetaHost()
        {
            object pClrMetaHost;
            HResult result = CLRCreateInstance(CLSID_CLRMetaHost, typeof(ICLRMetaHost).GUID, out pClrMetaHost);
            result.ThrowOnFailure();
            return (ICLRMetaHost)pClrMetaHost;
        }

        /// <summary>
        /// Gets the public key from a public/private key pair.
        /// </summary>
        /// <param name="keyBlob">
        /// The public/private key pair. This pair is in the format created by the Win32 CryptExportKey function.
        /// </param>
        /// <returns>The public key.</returns>
        public static unsafe byte[] StrongNameGetPublicKey(byte[] keyBlob)
        {
            fixed (byte* keyBlobPtr = keyBlob)
            {
                byte* publicKeyBlob;
                int publicKeyBlobLength;
                Marshal.ThrowExceptionForHR(StrongNameGetPublicKey(null, keyBlobPtr, keyBlob.Length, out publicKeyBlob, out publicKeyBlobLength));
                return MarshalNativeBuffer(publicKeyBlob, publicKeyBlobLength);
            }
        }

        /// <summary>
        /// Gets the public key from a public/private key pair.
        /// </summary>
        /// <param name="keyContainer">
        /// The name of the key container that contains the public/private key pair.
        /// The keys must be 1024-bit Rivest-Shamir-Adleman (RSA) signing keys. No other types of keys are supported at this time.
        /// </param>
        /// <returns>The public key.</returns>
        public static unsafe byte[] StrongNameGetPublicKey(string keyContainer)
        {
            byte* publicKeyBlob;
            int publicKeyBlobLength;
            Marshal.ThrowExceptionForHR(StrongNameGetPublicKey(keyContainer, (byte*)null, 0, out publicKeyBlob, out publicKeyBlobLength));
            return MarshalNativeBuffer(publicKeyBlob, publicKeyBlobLength);
        }

        /// <summary>
        /// Gets a token that represents a public key. A strong name token is the shortened form of a public key.
        /// </summary>
        /// <param name="publicKeyBlob">A structure of type PublicKeyBlob that contains the public portion of the key pair used to generate the strong name signature.</param>
        /// <returns>The strong name token corresponding to the key passed in <paramref name="publicKeyBlob"/>.</returns>
        public static unsafe byte[] StrongNameTokenFromPublicKey(byte[] publicKeyBlob)
        {
            fixed (byte* keyBlobPtr = publicKeyBlob)
            {
                byte* strongNameToken;
                int strongNameTokenLength;
                Marshal.ThrowExceptionForHR(StrongNameTokenFromPublicKey(keyBlobPtr, publicKeyBlob.Length, out strongNameToken, out strongNameTokenLength));
                return MarshalNativeBuffer(strongNameToken, strongNameTokenLength);
            }
        }

        /// <summary>
        /// Copies bytes from a native buffer to a managed one and frees the native one.
        /// </summary>
        /// <param name="nativeBuffer">A pointer to the native buffer.</param>
        /// <param name="bufferLength">The length of the native buffer.</param>
        /// <returns>The managed byte array.</returns>
        private static unsafe byte[] MarshalNativeBuffer(byte* nativeBuffer, int bufferLength)
        {
            try
            {
                byte[] result = new byte[bufferLength];
                for (int i = 0; i < result.Length; i++)
                {
                    result[i] = *(nativeBuffer + i);
                }

                return result;
            }
            finally
            {
                Marshal.ThrowExceptionForHR(StrongNameFreeBuffer(nativeBuffer));
            }
        }
    }
}
