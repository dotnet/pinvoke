// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Runtime.InteropServices;
    using static Kernel32;

    /// <content>
    /// Methods and nested types that are not strictly P/Invokes but provide
    /// a slightly higher level of functionality to ease calling into native code.
    /// </content>
    public static partial class MSCorEE
    {
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
                Marshal.ThrowExceptionForHR(StrongNameGetPublicKey(null, keyBlobPtr, keyBlob.Length, out byte* publicKeyBlob, out int publicKeyBlobLength));
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
            Marshal.ThrowExceptionForHR(StrongNameGetPublicKey(keyContainer, (byte*)null, 0, out byte* publicKeyBlob, out int publicKeyBlobLength));
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
                Marshal.ThrowExceptionForHR(StrongNameTokenFromPublicKey(keyBlobPtr, publicKeyBlob.Length, out byte* strongNameToken, out int strongNameTokenLength));
                return MarshalNativeBuffer(strongNameToken, strongNameTokenLength);
            }
        }

        /// <summary>
        /// Gets the version number of the common language runtime (CLR) that is associated with the specified process handle. This function has been deprecated in the .NET Framework version 4.
        /// </summary>
        /// <param name = "hProcess">A handle to a process.</param>
        /// <returns>
        /// The version number.
        /// </returns>
        /// <remarks>
        /// .NET Framework Versions: 4.5, 4, 3.5 SP1, 3.5, 3.0 SP1, 3.0, 2.0 SP1, 2.0.
        /// </remarks>
        public static string GetVersionFromProcess(SafeHandle hProcess)
        {
            const int insaneSize = 256 * 1024;
            char[] versionChars = new char[32];
            while (true)
            {
                HResult hr = GetVersionFromProcess(hProcess, versionChars, versionChars.Length, out int dwLength);
                if (hr.Succeeded)
                {
                    return new string(versionChars, 0, dwLength);
                }

                if (hr == (int)Win32ErrorCode.ERROR_INSUFFICIENT_BUFFER && versionChars.Length < insaneSize)
                {
                    versionChars = new char[versionChars.Length * 2];
                    continue;
                }

                hr.ThrowOnFailure();
            }
        }

        /// <summary>
        /// Gets the common language runtime (CLR) version information of the specified file, using the specified buffer. This function has been deprecated in the .NET Framework 4.
        /// </summary>
        /// <param name="fileName">The path of the file to be examined.</param>
        /// <returns>
        /// The version information for the file; or <c>null</c> if the native function returns
        /// <see cref="HResult.Code.E_INVALIDARG"/>.
        /// </returns>
        /// <remarks>
        /// .NET Framework Versions: 4.5, 4, 3.5 SP1, 3.5, 3.0 SP1, 3.0, 2.0 SP1, 2.0, 1.1.
        /// </remarks>
        public static string GetFileVersion(string fileName)
        {
            const int insaneSize = 256 * 1024;
            char[] versionChars = new char[32];
            while (true)
            {
                HResult hr = GetFileVersion(fileName, versionChars, versionChars.Length, out int dwLength);
                if (hr.Succeeded)
                {
                    return new string(versionChars, 0, dwLength);
                }

                if (hr == (int)Win32ErrorCode.ERROR_INSUFFICIENT_BUFFER && versionChars.Length < insaneSize)
                {
                    versionChars = new char[versionChars.Length * 2];
                    continue;
                }
                else if (hr == HResult.Code.E_INVALIDARG)
                {
                    return null;
                }

                hr.ThrowOnFailure();
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
