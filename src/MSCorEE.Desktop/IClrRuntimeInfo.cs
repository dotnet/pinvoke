// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Text;

    /// <summary>
    /// Provides methods that return information about a specific common language runtime (CLR), including version, directory, and load status.
    /// This interface also provides runtime-specific functionality without initializing the runtime.
    /// It includes the runtime-relative LoadLibrary method, the runtime module-specific GetProcAddress method, and runtime-provided interfaces through the GetInterface method.
    /// </summary>
    [Guid("BD39D1D2-BA2F-486A-89B0-B4B0CB466891")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface IClrRuntimeInfo
    {
        /// <summary>
        /// Gets common language runtime (CLR) version information associated with a given ICLRRuntimeInfo interface. This method supersedes GetRequestedRuntimeInfo and GetRequestedRuntimeVersion functions.
        /// </summary>
        /// <param name="buffer">
        /// <para>
        /// The .NET Framework compilation version in the format "vA.B[.X]". A, B, and X are decimal numbers that correspond to the major version, the minor version, and the build number. X is optional. If X is not present, there is no trailing period.
        /// </para>
        /// <para>
        /// This parameter must match the directory name for the .NET Framework version, as it appears under C:\Windows\Microsoft.NET\Framework.
        /// </para>
        /// <para>
        /// Example values are "v1.0.3705", "v1.1.4322", "v2.0.50727", and "v4.0.x", where x depends on the build number installed. Note that the "v" prefix is mandatory.
        /// </para>
        /// </param><param name="bufferLength">Specifies the size of pwzBuffer to avoid buffer overruns. If pwzBuffer is null, pchBuffer returns the required size of pwzBuffer to allow preallocation.</param>
        /// <returns><see cref="HResult"/></returns>
        [MethodImpl(MethodImplOptions.PreserveSig)]
        HResult GetVersionString([MarshalAs(UnmanagedType.LPWStr), Out] StringBuilder buffer, [In, Out] ref uint bufferLength);

        /// <summary>
        /// Gets the installation directory of the common language runtime (CLR) associated with this interface. This method supersedes the GetCORSystemDirectory function provided in the .NET Framework versions 2.0, 3.0, and 3.5.
        /// </summary>
        /// <param name="buffer">Returns the CLR installation directory. The installation path is fully qualified; for example, "c:\windows\microsoft.net\framework\v1.0.3705\".</param><param name="bufferLength">Specifies the size of pwzBuffer to avoid buffer overruns. If pwzBuffer is null, pchBuffer returns the required size of pwzBuffer.</param>
        /// <returns><see cref="HResult"/></returns>
        [MethodImpl(MethodImplOptions.PreserveSig)]
        HResult GetRuntimeDirectory([MarshalAs(UnmanagedType.LPWStr), Out] StringBuilder buffer, [In, Out] ref uint bufferLength);

        /// <summary>
        /// Indicates whether the common language runtime (CLR) associated with the ICLRRuntimeInfo interface is loaded into a process. A runtime can be loaded without also being started.
        /// </summary>
        /// <param name="processHandle">A handle to the process.</param><param name="isLoaded">True if the CLR is loaded into the process; otherwise, false.</param>
        /// <returns><see cref="HResult"/></returns>
        [MethodImpl(MethodImplOptions.PreserveSig)]
        HResult IsLoaded([In] IntPtr processHandle, [MarshalAs(UnmanagedType.Bool)] out bool isLoaded);

        /// <summary>
        /// Translates an HRESULT value into an appropriate error message for the specified culture. This method supersedes the following functions: LoadStringRC, LoadStringRCEx.
        /// </summary>
        /// <param name="resourceId">The HRESULT to translate.</param><param name="buffer">The message string associated with the given HRESULT.</param><param name="bufferLength">The size of pwzbuffer to avoid buffer overruns. If pwzbuffer is null, pcchBuffer provides the expected size of pwzbuffer to allow preallocation.</param>
        /// <returns><see cref="HResult"/></returns>
        [LCIDConversion(3)]
        [MethodImpl(MethodImplOptions.PreserveSig)]
        HResult LoadErrorString([In] int resourceId, [MarshalAs(UnmanagedType.LPWStr), Out] StringBuilder buffer, [In, Out] ref uint bufferLength);

        /// <summary>
        /// Loads a .NET Framework library from the common language runtime (CLR) represented by an ICLRRuntimeInfo interface. This method supersedes the LoadLibraryShim function.
        /// </summary>
        /// <param name="dllName">The name of the assembly to be loaded.</param><param name="hModule">A handle to the loaded assembly.</param>
        /// <returns><see cref="HResult"/></returns>
        [MethodImpl(MethodImplOptions.PreserveSig)]
        HResult LoadLibrary([MarshalAs(UnmanagedType.LPWStr), In] string dllName, out IntPtr hModule);

        /// <summary>
        /// Gets the address of a specified function that was exported from the common language runtime (CLR) associated with this interface. This method supersedes the GetRealProcAddress function.
        /// </summary>
        /// <param name="procName">The name of the exported function.</param><param name="pProc">The address of the exported function.</param>
        /// <returns><see cref="HResult"/></returns>
        [MethodImpl(MethodImplOptions.PreserveSig)]
        HResult GetProcAddress([MarshalAs(UnmanagedType.LPStr), In] string procName, out IntPtr pProc);

        /// <summary>
        /// Loads the CLR into the current process and returns runtime interface pointers, such as ICLRRuntimeHost, ICLRStrongName, ICorDebug, and IMetaDataDispenserEx. This method supersedes all the CorBindTo* functions in the .NET Framework 1.1 and 2.0 Hosting Global Static Functions section.
        /// </summary>
        /// <param name="clsid">The CLSID interface for the coclass.</param><param name="iid">The IID of the requested rclsid interface.</param><param name="ppUnk">A pointer to the queried interface.</param>
        /// <returns><see cref="HResult"/></returns>>
        [MethodImpl(MethodImplOptions.PreserveSig)]
        HResult GetInterface([MarshalAs(UnmanagedType.LPStruct), In] Guid clsid, [MarshalAs(UnmanagedType.LPStruct), In] Guid iid, [MarshalAs(UnmanagedType.Interface)] out object ppUnk);

        /// <summary>
        /// Indicates whether the runtime associated with this interface can be loaded into the current process, taking into account other runtimes that might already be loaded into the process.
        /// </summary>
        /// <param name="isLoaded">True if this runtime could be loaded into the current process; otherwise, false.</param>
        /// <returns><see cref="HResult"/></returns>
        /// <remarks>
        /// If another runtime is already loaded into the process and the runtime associated with this interface can be loaded for in-process side-by-side execution, pbLoadable returns true. If the two runtimes cannot run side-by-side in-process, pbLoadable returns false. For example, the common language runtime (CLR) version 4 can run side-by-side in the same process with CLR version 2.0 or CLR version 1.1. However, CLR version 1.1 and CLR version 2.0 cannot run side-by-side in-process.
        /// If no runtimes are loaded into the process, this method always returns true.
        /// </remarks>
        [MethodImpl(MethodImplOptions.PreserveSig)]
        HResult IsLoadable([MarshalAs(UnmanagedType.Bool)] out bool isLoaded);

        /// <summary>
        /// Sets the startup flags and the host configuration file that will be used to start the runtime. This method supersedes the use of the startupFlags parameter in the CorBindToRuntimeEx and CorBindToRuntimeHost functions.
        /// </summary>
        /// <param name="dwStartupFlags">The host startup flags to set. Use the same flags as with the CorBindToRuntimeEx and CorBindToRuntimeHost functions.</param><param name="pwzHostConfigFile">The directory path of the host configuration file to set.</param>
        /// <returns><see cref="HResult"/></returns>
        [MethodImpl(MethodImplOptions.PreserveSig)]
        HResult SetDefaultStartupFlags([In] uint dwStartupFlags, [MarshalAs(UnmanagedType.LPWStr), In] string pwzHostConfigFile);

        /// <summary>
        /// Gets the startup flags and host configuration file that will be used to start the runtime.
        /// </summary>
        /// <param name="dwStartupFlags">A pointer to the host startup flags that are currently set.</param><param name="pwzHostConfigFile">A pointer to the directory path of the current host configuration file.</param><param name="pcchHostConfigFile">On input, the size of pwzHostConfigFile, to avoid buffer overruns. If pwzHostConfigFile is null, the method returns the required size of pwzHostConfigFile for pre-allocation.</param>
        /// <returns><see cref="HResult"/></returns>
        /// <remarks>
        /// This method returns the default flag values (STARTUP_CONCURRENT_GC and NULL), or the values provided by a previous call to the ICLRRuntimeInfo::SetDefaultStartupFlags method, or the values set by any of the CorBind* methods if they are bound to this runtime.
        /// </remarks>
        [MethodImpl(MethodImplOptions.PreserveSig)]
        HResult GetDefaultStartupFlags(out uint dwStartupFlags, [MarshalAs(UnmanagedType.LPWStr), Out] StringBuilder pwzHostConfigFile, [In, Out] ref uint pcchHostConfigFile);

        /// <summary>
        /// Binds the current runtime for all legacy common language runtime (CLR) version 2 activation policy decisions.
        /// </summary>
        /// <returns><see cref="HResult"/></returns>
        /// <remarks>
        /// If the current runtime is already bound for all legacy CLR version 2 activation policy decisions (for example, by using the useLegacyV2RuntimeActivationPolicy attribute on the &lt;startup&gt; element in the configuration file), this method does not return an error result; instead, the result is S_OK, just as it would be if the method had successfully bound legacy activation policy.
        /// </remarks>
        [MethodImpl(MethodImplOptions.PreserveSig)]
        HResult BindAsLegacyV2Runtime();

        /// <summary>
        /// Indicates whether the runtime has been started (that is, whether the ICLRRuntimeHost::Start method has been called and has succeeded).
        /// </summary>
        /// <param name="isStarted">True if this runtime is started; otherwise, false.</param><param name="dwStartupFlags">Returns the flags that were used to start the runtime.</param>
        /// <returns><see cref="HResult"/></returns>
        [MethodImpl(MethodImplOptions.PreserveSig)]
        HResult IsStarted([MarshalAs(UnmanagedType.Bool)] out bool isStarted, out uint dwStartupFlags);
    }
}