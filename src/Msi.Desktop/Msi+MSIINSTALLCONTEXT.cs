// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;

    /// <content>
    /// Contains the <see cref="MSIINSTALLCONTEXT"/> nested type.
    /// </content>
    public partial class Msi
    {
        /// <summary>
        /// Flags that may be passed into the dwContext parameter of the <see cref="MsiEnumProductsEx(string, string, MSIINSTALLCONTEXT, int, char*, MSIINSTALLCONTEXT*, char*, int*)"/> method.
        /// </summary>
        [Flags]
        public enum MSIINSTALLCONTEXT : uint
        {
            /// <summary>
            /// Product visible to the current user.
            /// </summary>
            MSIINSTALLCONTEXT_FIRSTVISIBLE = 0,

            /// <summary>
            /// Invalid context for a product
            /// </summary>
            MSIINSTALLCONTEXT_NONE = 0,

            /// <summary>
            /// Enumeration extended to all per–user–managed installations for the users specified by szUserSid. An invalid SID returns no items.
            /// </summary>
            MSIINSTALLCONTEXT_USERMANAGED = 0x1,

            /// <summary>
            /// Enumeration extended to all per–user–unmanaged installations for the users specified by szUserSid. An invalid SID returns no items.
            /// </summary>
            MSIINSTALLCONTEXT_USERUNMANAGED = 0x2,

            /// <summary>
            /// Enumeration extended to all per-machine installations. When dwInstallContext is set to MSIINSTALLCONTEXT_MACHINE only, the szUserSID parameter must be NULL.
            /// </summary>
            MSIINSTALLCONTEXT_MACHINE = 0x4,

            /// <summary>
            /// All contexts. OR of all valid values
            /// </summary>
            MSIINSTALLCONTEXT_ALL = MSIINSTALLCONTEXT_USERMANAGED | MSIINSTALLCONTEXT_USERUNMANAGED | MSIINSTALLCONTEXT_MACHINE,

            /// <summary>
            /// All user-managed contexts.
            /// </summary>
            MSIINSTALLCONTEXT_ALLUSERMANAGED = 0x8,
        }
    }
}
