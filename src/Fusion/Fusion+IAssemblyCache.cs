// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Text;

    /// <content>
    /// Contains the <see cref="IAssemblyCache"/> nested type.
    /// </content>
    public partial class Fusion
    {
        /// <summary>
        /// Represents the global assembly cache for use by the fusion technology.
        /// </summary>
        [ComImport]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        [Guid("e707dcde-d1cd-11d2-bab9-00c04f8eceae")]
        public interface IAssemblyCache
        {
            /// <summary>
            /// Uninstalls the specified assembly from the global assembly cache.
            /// </summary>
            /// <param name="dwFlags">Flags defined in Fusion.idl.</param>
            /// <param name="pszAssemblyName">The name of the assembly to uninstall.</param>
            /// <param name="pRefData">A <see cref="FUSION_INSTALL_REFERENCE"/> structure that contains the installation data for the assembly.</param>
            /// <param name="pulDisposition">One of the disposition values defined in Fusion.idl.</param>
            /// <returns>An <see cref="HResult"/></returns>
            [PreserveSig]
            unsafe HResult UninstallAssembly(
                /* [in] */ UninstallAssemblyFlags dwFlags,
                /* [in] */ string pszAssemblyName,
                /* [in] */ FUSION_INSTALL_REFERENCE* pRefData,
                /* [optional][out] */ UninstallDisposition* pulDisposition);

            /// <summary>
            /// Gets the requested data about the specified assembly.
            /// </summary>
            /// <param name="dwFlags">Flags defined in Fusion.idl.</param>
            /// <param name="pszAssemblyName">The name of the assembly for which data will be retrieved.</param>
            /// <param name="pAsmInfo">An <see cref="ASSEMBLY_INFO"/> structure that contains data about the assembly.</param>
            /// <returns>An <see cref="HResult"/></returns>
            [PreserveSig]
            unsafe HResult QueryAssemblyInfo(
                /* [in] */ QueryAssemblyInfoFlags dwFlags,
                /* [in] */ string pszAssemblyName,
                /* [out][in] */ ASSEMBLY_INFO* pAsmInfo);

            /// <summary>
            /// Gets a reference to a new <see cref="IAssemblyCacheItem"/> object.
            /// </summary>
            /// <param name="dwFlags">Flags defined in Fusion.idl.</param>
            /// <param name="pvReserved">Reserved for future extensibility. <paramref name="pvReserved"/> must be a null reference.</param>
            /// <param name="ppAsmItem">The returned <see cref="IAssemblyCacheItem"/> pointer</param>
            /// <param name="pszAssemblyName">Uncanonicalized, comma-separated name=value pairs. Optional.</param>
            /// <returns>An <see cref="HResult"/></returns>
            [PreserveSig]
            HResult CreateAssemblyCacheItem(
                /* [in] */ AssemblyCacheInstallFlags dwFlags,
                /* [in] */ object pvReserved,
                /* [out] */ out IAssemblyCacheItem ppAsmItem,
                /* [optional][in] */ string pszAssemblyName);

            /// <summary>
            /// Reserved for internal use by the fusion technology.
            /// </summary>
            /// <param name="ppUnkReserved">The returned IUnknown pointer</param>
            /// <returns>An <see cref="HResult"/></returns>
            [PreserveSig]
            HResult CreateAssemblyScavenger(
                /* [out] */ out object ppUnkReserved);

            /// <summary>
            /// Installs the specified assembly in the global assembly cache.
            /// </summary>
            /// <param name="dwFlags">Flags defined in Fusion.idl.</param>
            /// <param name="pszManifestFilePath">The path to the manifest for the assembly to install.</param>
            /// <param name="pRefData">A <see cref="FUSION_INSTALL_REFERENCE"/> structure that contains data for the installation.</param>
            /// <returns>An <see cref="HResult"/></returns>
            [PreserveSig]
            unsafe HResult InstallAssembly(
                /* [in] */ AssemblyCacheInstallFlags dwFlags,
                /* [in] */ string pszManifestFilePath,
                /* [in] */ FUSION_INSTALL_REFERENCE* pRefData);
        }
    }
}