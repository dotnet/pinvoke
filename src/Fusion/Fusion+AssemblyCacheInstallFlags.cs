// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;

    /// <content>
    /// Contains the <see cref="AssemblyCacheInstallFlags"/> nested type.
    /// </content>
    public partial class Fusion
    {
        [Flags]
        public enum AssemblyCacheInstallFlags
        {
            None = 0x0,
            IASSEMBLYCACHE_INSTALL_FLAG_REFRESH = 0x1,
            IASSEMBLYCACHE_INSTALL_FLAG_FORCE_REFRESH = 0x2,
        }
    }
}
