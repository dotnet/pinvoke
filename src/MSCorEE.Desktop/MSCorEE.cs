// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Runtime.InteropServices;

    /// <summary>
    /// Exported functions from the MSCorEE.dll Windows library
    /// that are available to Desktop and Store apps.
    /// </summary>
    [OfferFriendlyOverloads]
    public static partial class MSCorEE
    {
        /// <summary>
        /// Gets the public key from a public/private key pair. The key pair can be supplied either as a key container name within a cryptographic service provider (CSP) or as a raw collection of bytes.
        /// </summary>
        /// <param name="szKeyContainer">
        /// The name of the key container that contains the public/private key pair. If <paramref name="pbKeyBlob"/> is null, <paramref name="szKeyContainer"/> must specify a valid container within the CSP. In this case, the ICLRStrongName::StrongNameGetPublicKey method extracts the public key from the key pair stored in the container.
        /// If <paramref name="pbKeyBlob"/> is not null, the key pair is assumed to be contained in the key binary large object (BLOB).
        /// The keys must be 1024-bit Rivest-Shamir-Adleman (RSA) signing keys. No other types of keys are supported at this time.
        /// </param>
        /// <param name="pbKeyBlob">
        /// A pointer to the public/private key pair. This pair is in the format created by the Win32 CryptExportKey function. If <paramref name="pbKeyBlob"/> is null, the key container specified by <paramref name="szKeyContainer"/> is assumed to contain the key pair.
        /// </param>
        /// <param name="cbKeyBlob">The size, in bytes, of <paramref name="pbKeyBlob"/>.</param>
        /// <param name="ppbPublicKeyBlob">
        /// The returned public key BLOB. The <paramref name="ppbPublicKeyBlob"/> parameter is allocated by the common language runtime and returned to the caller. The caller must free the memory by using the ICLRStrongName::StrongNameFreeBuffer method.
        /// </param>
        /// <param name="pcbPublicKeyBlob">The size of the returned public key BLOB.</param>
        /// <returns>
        /// S_OK if the method completed successfully; otherwise, an HRESULT value that indicates failure.
        /// </returns>
        /// <remarks>
        /// The public key is contained in a PublicKeyBlob structure.
        /// </remarks>
        [DllImport(nameof(MSCorEE), CharSet = CharSet.Unicode, PreserveSig = true)]
        public static extern unsafe int StrongNameGetPublicKey(
            string szKeyContainer,
            byte* pbKeyBlob,
            int cbKeyBlob,
            out byte* ppbPublicKeyBlob,
            out int pcbPublicKeyBlob);

        /// <summary>
        /// Gets a token that represents a public key. A strong name token is the shortened form of a public key.
        /// </summary>
        /// <param name="pbPublicKeyBlob">A structure of type PublicKeyBlob that contains the public portion of the key pair used to generate the strong name signature.</param>
        /// <param name="cbPublicKeyBlob">The size, in bytes, of <paramref name="pbPublicKeyBlob"/>.</param>
        /// <param name="ppbStrongNameToken">The strong name token corresponding to the key passed in <paramref name="pbPublicKeyBlob"/>. The common language runtime allocates the memory in which to return the token. The caller must free this memory by using the <see cref="StrongNameFreeBuffer(byte*)"/> method.</param>
        /// <param name="pcbStrongNameToken">The size, in bytes, of the returned strong name token.</param>
        /// <returns>
        /// S_OK if the method completed successfully; otherwise, an HRESULT value that indicates failure.
        /// </returns>
        [DllImport(nameof(MSCorEE), PreserveSig = true)]
        public static extern unsafe int StrongNameTokenFromPublicKey(
            byte* pbPublicKeyBlob,
            int cbPublicKeyBlob,
            out byte* ppbStrongNameToken,
            out int pcbStrongNameToken);

        /// <summary>
        /// Frees memory that was allocated with a previous call to a strong name method such as
        /// <see cref="StrongNameGetPublicKey(string, byte*, int, out byte*, out int)"/>,
        /// <see cref="StrongNameTokenFromPublicKey(byte*, int, out byte*, out int)"/>, or
        /// ICLRStrongName::StrongNameSignatureGeneration.
        /// </summary>
        /// <param name="pbMemory">A pointer to the memory to free.</param>
        /// <returns>
        /// S_OK if the method completed successfully; otherwise, an HRESULT value that indicates failure.
        /// </returns>
        [DllImport(nameof(MSCorEE), PreserveSig = true)]
        public static extern unsafe int StrongNameFreeBuffer(byte* pbMemory);
    }
}
