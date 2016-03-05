// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Runtime.InteropServices;
    using CLRMetaHost;

    /// <summary>
    /// Exported functions from the MSCorEE.dll Windows library
    /// that are available to Desktop and Store apps.
    /// </summary>
    [OfferFriendlyOverloads]
    public static partial class MSCorEE
    {
        /// <summary>
        /// The CLSID that may be passed to <see cref="CLRCreateInstance"/> to create an instance of <see cref="ICLRMetaHost"/>.
        /// </summary>
        public static readonly Guid CLSID_CLRMetaHost = new Guid(0x9280188d, 0xe8e, 0x4867, 0xb3, 0xc, 0x7f, 0xa8, 0x38, 0x84, 0xe8, 0xde);

        /// <summary>
        /// The CLSID that may be passed to <see cref="CLRCreateInstance"/> to create an instance of <see cref="ICLRMetaHostPolicy"/>.
        /// </summary>
        public static readonly Guid CLSID_CLRMetaHostPolicy = new Guid(0x2ebcd49a, 0x1b47, 0x4a61, 0xb1, 0x3a, 0x4a, 0x3, 0x70, 0x1e, 0x59, 0x4b);

        /// <summary>
        /// The CLSID that may be passed to <see cref="CLRCreateInstance"/> to create an instance of <see cref="ICLRDebugging"/>.
        /// </summary>
        public static readonly Guid CLSID_CLRDebugging = new Guid(0xbacc578d, 0xfbdd, 0x48a4, 0x96, 0x9f, 0x2, 0xd9, 0x32, 0xb7, 0x46, 0x34);

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

        /// <summary>
        /// Provides one of three interfaces: <see cref="ICLRMetaHost"/>, <see cref="ICLRMetaHostPolicy"/>, or <see cref="ICLRDebugging"/>.
        /// </summary>
        /// <param name="clsid">
        /// One of three class identifiers: <see cref="CLSID_CLRMetaHost"/>, <see cref="CLSID_CLRMetaHostPolicy"/>, or <see cref="CLSID_CLRDebugging"/>
        /// </param>
        /// <param name="riid">One of three interface identifiers (IIDs) accessible via <c>typeof(T)</c> where the type is <see cref="ICLRMetaHost"/>, <see cref="ICLRMetaHostPolicy"/>, or <see cref="ICLRDebugging"/>.</param>
        /// <param name="ppInterface">One of three interfaces: <see cref="ICLRMetaHost"/>, <see cref="ICLRMetaHostPolicy"/>, or <see cref="ICLRDebugging"/>.</param>
        /// <returns>This method returns the following specific HRESULTs as well as HRESULT errors that indicate method failure.</returns>
        [DllImport(nameof(MSCorEE), CharSet = CharSet.Unicode, PreserveSig = true)]
        public static extern int CLRCreateInstance(
            [MarshalAs(UnmanagedType.LPStruct)] Guid clsid,
            [MarshalAs(UnmanagedType.LPStruct)] Guid riid,
            [MarshalAs(UnmanagedType.Interface)] out object ppInterface);

        /// <summary>
        /// Loads a specified version of a DLL that is included in the .NET Framework redistributable package.
        /// This function has been deprecated in the .NET Framework 4. Use the ICLRRuntimeInfo::LoadLibrary method instead.
        /// </summary>
        /// <param name="szDllName">A zero-terminated string that represents the name of the DLL to be loaded from the .NET Framework library.</param>
        /// <param name="szVersion">A zero-terminated string that represents the version of the DLL to be loaded. If szVersion is null, the version selected for loading is the latest version of the specified DLL that is less than version 4. That is, all versions equal to or greater than version 4 are ignored if szVersion is null, and if no version less than version 4 is installed, the DLL fails to load. This is to ensure that installation of the .NET Framework 4 does not affect pre-existing applications or components. See the entry In-Proc SxS and Migration Quick Start in the CLR team blog.</param>
        /// <param name="pvReserved">Reserved for future use.</param>
        /// <param name="phModDll">A pointer to the handle of the module.</param>
        /// <returns>This method returns standard Component Object Model (COM) error codes, as defined in WinError.h, in addition to the following values.
        /// <see cref="HResult.Code.S_OK"/>, CLR_E_SHIM_RUNTIMELOAD
        /// </returns>
        /// <remarks>
        /// This function is used to load DLLs that are included in the .NET Framework redistributable package. It does not load user-generated DLLs.
        /// Beginning with the .NET Framework version 2.0, loading Fusion.dll causes the CLR to be loaded. This is because the functions in Fusion.dll are now wrappers whose implementations are provided by the runtime.
        /// </remarks>
        [DllImport(nameof(MSCorEE), CharSet = CharSet.Unicode)]
        public static extern unsafe HResult LoadLibraryShim(
            string szDllName,
            string szVersion,
            IntPtr pvReserved,
            out IntPtr phModDll);

        /// <summary>
        /// Gets the version number of the common language runtime (CLR) that is associated with the specified process handle. This function has been deprecated in the .NET Framework version 4.
        /// </summary>
        /// <param name="hProcess">A handle to a process.</param>
        /// <param name="pVersion">A buffer that contains the version number string upon successful completion of the method.</param>
        /// <param name="cchBuffer">The length of the version buffer.</param>
        /// <param name="dwLength">A pointer to the length of the version number string.</param>
        /// <returns>
        /// HRESULT
        /// </returns>
        /// <remarks>
        /// .NET Framework Versions: 4.5, 4, 3.5 SP1, 3.5, 3.0 SP1, 3.0, 2.0 SP1, 2.0
        /// </remarks>
        [DllImport(nameof(MSCorEE), CharSet = CharSet.Unicode)]
        public static extern unsafe HResult GetVersionFromProcess(
            SafeHandle hProcess,
            [Friendly(FriendlyFlags.Array | FriendlyFlags.Bidirectional)] char* pVersion,
            int cchBuffer,
            out int dwLength);

        /// <summary>
        /// Gets the common language runtime (CLR) version information of the specified file, using the specified buffer. This function has been deprecated in the .NET Framework 4.
        /// </summary>
        /// <param name="szFileName">The path of the file to be examined.</param>
        /// <param name="szBuffer">The buffer allocated for the version information that is returned.</param>
        /// <param name="cchBuffer">The size, in wide characters, of szBuffer.</param>
        /// <param name="dwLength">The size, in bytes, of the returned szBuffer.</param>
        /// <returns>
        /// HRESULT
        /// </returns>
        /// <remarks>
        /// .NET Framework Versions: 4.5, 4, 3.5 SP1, 3.5, 3.0 SP1, 3.0, 2.0 SP1, 2.0, 1.1
        /// </remarks>
        [DllImport(nameof(MSCorEE), CharSet = CharSet.Unicode)]
        public static extern unsafe HResult GetFileVersion(
            [MarshalAs(UnmanagedType.LPWStr)] string szFileName,
            [Friendly(FriendlyFlags.Array | FriendlyFlags.Bidirectional)] char* szBuffer,
            int cchBuffer,
            out int dwLength);
    }
}
