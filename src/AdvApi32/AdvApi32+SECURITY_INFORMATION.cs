// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;

    /// <content>
    /// Contains the <see cref="SECURITY_INFORMATION"/> nested type.
    /// </content>
    public partial class AdvApi32
    {
        /// <summary>
        /// Identifies the object-related security information being set or queried.
        /// </summary>
        [Flags]
        public enum SECURITY_INFORMATION : uint
        {
            /// <summary>
            ///     The resource properties of the object being referenced. The resource properties are stored in
            ///     SYSTEM_RESOURCE_ATTRIBUTE_ACE types in the SACL of the security descriptor.
            /// </summary>
            /// <remarks>
            ///     Windows Server 2008 R2, Windows 7, Windows Server 2008, Windows Vista, Windows Server 2003, and Windows XP:
            ///     This bit flag is not available.
            /// </remarks>
            ATTRIBUTE_SECURITY_INFORMATION = 0x00000020,

            /// <summary>
            ///     All parts of the security descriptor. This is useful for backup and restore software that needs to preserve
            ///     the entire security descriptor.
            /// </summary>
            /// <remarks>
            ///     Windows Server 2008 R2, Windows 7, Windows Server 2008, Windows Vista, Windows Server 2003, and Windows XP:
            ///     This bit flag is not available.
            /// </remarks>
            BACKUP_SECURITY_INFORMATION = 0x00010000,

            /// <summary>The DACL of the object is being referenced.</summary>
            DACL_SECURITY_INFORMATION = 0x00000004,

            /// <summary>The primary group identifier of the object is being referenced.</summary>
            GROUP_SECURITY_INFORMATION = 0x00000002,

            /// <summary>
            ///     The mandatory integrity label is being referenced. The mandatory integrity label is an ACE in the SACL of the
            ///     object.
            /// </summary>
            /// <remarks>Windows Server 2003 and Windows XP:  This bit flag is not available.</remarks>
            LABEL_SECURITY_INFORMATION = 0x00000010,

            /// <summary>The owner identifier of the object is being referenced.</summary>
            OWNER_SECURITY_INFORMATION = 0x00000001,

            /// <summary>The DACL cannot inherit access control entries (ACEs).</summary>
            PROTECTED_DACL_SECURITY_INFORMATION = 0x80000000,

            /// <summary>The SACL cannot inherit ACEs.</summary>
            PROTECTED_SACL_SECURITY_INFORMATION = 0x40000000,

            /// <summary>The SACL of the object is being referenced.</summary>
            SACL_SECURITY_INFORMATION = 0x00000008,

            /// <summary>
            ///     The Central Access Policy (CAP) identifier applicable on the object that is being referenced. Each CAP
            ///     identifier is stored in a SYSTEM_SCOPED_POLICY_ID_ACE type in the SACL of the SD.
            /// </summary>
            /// <remarks>
            ///     Windows Server 2008 R2, Windows 7, Windows Server 2008, Windows Vista, Windows Server 2003, and Windows XP:
            ///     This bit flag is not available.
            /// </remarks>
            SCOPE_SECURITY_INFORMATION = 0x00000040,

            /// <summary>The DACL inherits ACEs from the parent object.</summary>
            UNPROTECTED_DACL_SECURITY_INFORMATION = 0x20000000,

            /// <summary>The SACL inherits ACEs from the parent object.</summary>
            UNPROTECTED_SACL_SECURITY_INFORMATION = 0x10000000,

            PROCESS_TRUST_LABEL_SECURITY_INFORMATION = 0x00000080
        }
    }
}