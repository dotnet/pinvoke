// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Text;

    /// <summary>
    /// Provides methods that return a specific version of the common language runtime (CLR) based on its version number, list all installed CLRs, list all runtimes that are loaded in a specified process, discover the CLR version used to compile an assembly, exit a process with a clean runtime shutdown, and query legacy API binding.
    /// </summary>
    /// <code>
    /// ICLRMetaHost* pMetaHost = NULL;
    /// HRESULT hr = CLRCreateInstance(CLSID_CLRMetaHost, IID_ICLRMetaHost, (LPVOID*) &amp; pMetaHost);
    /// </code>
    /// <remarks>
    /// .NET Framework Versions: 4.5, 4.
    /// </remarks>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("D332DB9E-B9B3-4125-8207-A14884F53216")]
    [ComImport]
    public interface IClrMetaHost
    {
        /// <summary>
        /// Gets the ICLRRuntimeInfo interface that corresponds to a particular version of the common language runtime (CLR). This method supersedes the CorBindToRuntimeEx function used with the STARTUP_LOADER_SAFEMODE flag.
        /// </summary>
        /// <returns><see cref="HResult"/></returns>
        /// HRESULT GetRuntime([in] LPCWSTR pwzVersion, [in, REFIID riid, [out, iid_is(riid), retval] LPVOID* ppRuntime);
        [MethodImpl(MethodImplOptions.PreserveSig)]
        HResult GetRuntime([MarshalAs(UnmanagedType.LPWStr), In] string version, [MarshalAs(UnmanagedType.LPStruct), In] Guid interfaceId, [MarshalAs(UnmanagedType.Interface)] out object ppRuntime);

        /// <summary>
        /// Gets an assembly's original .NET Framework compilation version (stored in the metadata), given its file path. This method supersedes the GetFileVersion function.
        /// </summary>
        /// <returns><see cref="HResult"/></returns>
        /// HRESULT GetVersionFromFile([in] LPCWSTR pwzFilePath, [out, size_is(*pcchBuffer)] LPWSTR pwzBuffer, [in, out] DWORD* pcchBuffer);
        [MethodImpl(MethodImplOptions.PreserveSig)]
        HResult GetVersionFromFile([MarshalAs(UnmanagedType.LPWStr), In] string filePath, [MarshalAs(UnmanagedType.LPWStr), Out] StringBuilder buffer, [Out] out uint bufferLength);

        /// <summary>
        /// Returns an enumeration that contains a valid ICLRRuntimeInfo interface for each version of the common language runtime (CLR) that is installed on a computer.
        /// </summary>
        /// <returns><see cref="HResult"/></returns>
        /// HRESULT EnumerateInstalledRuntimes([out, retval] IEnumUnknown** ppEnumerator);
        [MethodImpl(MethodImplOptions.PreserveSig)]
        HResult EnumerateInstalledRuntimes([MarshalAs(UnmanagedType.Interface)] out IEnumUnknown ppEnumerator);

        /// <summary>
        /// Returns an enumeration that includes a valid ICLRRuntimeInfo interface pointer for each version of the common language runtime (CLR) that is loaded in a given process. This method supersedes the GetVersionFromProcess function.
        /// </summary>
        /// <returns><see cref="HResult"/></returns>
        /// HRESULT EnumerateLoadedRuntimes([in] HANDLE hndProcess, [out, retval] IEnumUnknown** ppEnumerator);
        [MethodImpl(MethodImplOptions.PreserveSig)]
        HResult EnumerateLoadedRuntimes([In] IntPtr processHandle, [MarshalAs(UnmanagedType.Interface)] out IEnumUnknown ppEnumerator);

        /// <summary>
        /// Provides a callback function that is guaranteed to be called when a common language runtime (CLR) version is first loaded, but not yet started. This method supersedes the LockClrVersion function.
        /// </summary>
        /// <returns><see cref="HResult"/></returns>
        /// HRESULT RequestRuntimeLoadedNotification([in] RuntimeLoadedCallbackFnPtr pCallbackFunction);
        [MethodImpl(MethodImplOptions.PreserveSig)]
        HResult RequestRuntimeLoadedNotification([In] IntPtr pCallbackFunction);

        /// <summary>
        /// Returns an interface that represents a runtime to which legacy activation policy has been bound, for example, by using the useLegacyV2RuntimeActivationPolicy attribute on the [startup] element configuration file entry, by direct use of the legacy activation APIs, or by calling the ICLRRuntimeInfo::BindAsLegacyV2Runtime method.
        /// </summary>
        /// <returns><see cref="HResult"/></returns>
        /// HRESULT QueryLegacyV2RuntimeBinding([in] REFIID riid, [out, iid_is(riid), retval] LPVOID* ppUnk);
        [MethodImpl(MethodImplOptions.PreserveSig)]
        HResult QueryLegacyV2RuntimeBinding([MarshalAs(UnmanagedType.LPStruct), In] Guid riid, [MarshalAs(UnmanagedType.Interface)] out object ppUnk);
    }
}