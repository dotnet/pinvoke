// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    /// <content>
    /// Contains the <see cref="UninstallDisposition"/> nested type.
    /// </content>
    public partial class Fusion
    {
        /// <summary>
        /// Enumerates values that may be returned by the <see cref="IAssemblyCache.UninstallAssembly"/> function.
        /// </summary>
        public enum UninstallDisposition
        {
            IASSEMBLYCACHE_UNINSTALL_DISPOSITION_UNINSTALLED = 1,
            IASSEMBLYCACHE_UNINSTALL_DISPOSITION_STILL_IN_USE = 2,
            IASSEMBLYCACHE_UNINSTALL_DISPOSITION_ALREADY_UNINSTALLED = 3,
            IASSEMBLYCACHE_UNINSTALL_DISPOSITION_DELETE_PENDING = 4,
            IASSEMBLYCACHE_UNINSTALL_DISPOSITION_HAS_INSTALL_REFERENCES = 5,
            IASSEMBLYCACHE_UNINSTALL_DISPOSITION_REFERENCE_NOT_FOUND = 6,
        }
    }
}
