// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;

    /// <content>
    /// Contains the <see cref="TokenAccessRights"/> nested type.
    /// </content>
    public partial class AdvApi32
    {
        /// <summary>
        /// The different access rights allowed to access an access token.
        /// </summary>
        [Flags]
        public enum TokenAccessRights : uint
        {
            /// <summary>The right to delete the object.</summary>
            DELETE = 0x00010000,

            /// <summary>
            ///     The right to read the information in the object's security descriptor, not including the information in the
            ///     system access control list (SACL).
            /// </summary>
            READ_CONTROL = 0x00020000,

            /// <summary>The right to modify the discretionary access control list (DACL) in the object's security descriptor.</summary>
            WRITE_DAC = 0x00040000,

            /// <summary>The right to change the owner in the object's security descriptor.</summary>
            WRITE_OWNER = 0x00080000,

            /// <summary>Combines DELETE, READ_CONTROL, WRITE_DAC, and WRITE_OWNER access.</summary>
            STANDARD_RIGHTS_REQUIRED = 0x000F0000,

            /// <summary>Currently defined to equal READ_CONTROL.</summary>
            STANDARD_RIGHTS_READ = READ_CONTROL,

            /// <summary>Currently defined to equal READ_CONTROL.</summary>
            STANDARD_RIGHTS_WRITE = READ_CONTROL,

            /// <summary>Currently defined to equal READ_CONTROL.</summary>
            STANDARD_RIGHTS_EXECUTE = READ_CONTROL,

            /// <summary>
            ///     Required to attach a primary token to a process. The SE_ASSIGNPRIMARYTOKEN_NAME privilege is also required to
            ///     accomplish this task.
            /// </summary>
            TOKEN_ASSIGN_PRIMARY = 0x0001,

            /// <summary>Required to duplicate an access token.</summary>
            TOKEN_DUPLICATE = 0x0002,

            /// <summary>Required to attach an impersonation access token to a process.</summary>
            TOKEN_IMPERSONATE = 0x0004,

            /// <summary>Required to query an access token.</summary>
            TOKEN_QUERY = 0x0008,

            /// <summary>Required to query the source of an access token.</summary>
            TOKEN_QUERY_SOURCE = 0x0010,

            /// <summary>Required to enable or disable the privileges in an access token.</summary>
            TOKEN_ADJUST_PRIVILEGES = 0x0020,

            /// <summary>Required to adjust the attributes of the groups in an access token.</summary>
            TOKEN_ADJUST_GROUPS = 0x0040,

            /// <summary>Required to change the default owner, primary group, or DACL of an access token.</summary>
            TOKEN_ADJUST_DEFAULT = 0x0080,

            /// <summary>Required to adjust the session ID of an access token. The SE_TCB_NAME privilege is required.</summary>
            TOKEN_ADJUST_SESSIONID = 0x0100,

            /// <summary>Combines STANDARD_RIGHTS_READ and TOKEN_QUERY.</summary>
            TOKEN_READ = STANDARD_RIGHTS_READ | TOKEN_QUERY,

            /// <summary>Combines STANDARD_RIGHTS_WRITE, TOKEN_ADJUST_PRIVILEGES, TOKEN_ADJUST_GROUPS, and TOKEN_ADJUST_DEFAULT.</summary>
            TOKEN_WRITE = STANDARD_RIGHTS_WRITE | TOKEN_ADJUST_PRIVILEGES | TOKEN_ADJUST_GROUPS | TOKEN_ADJUST_DEFAULT,

            /// <summary>Required to wait for the process to terminate using the wait functions.</summary>
            ACCESS_SYSTEM_SECURITY = 0x01000000,

            /// <summary>Combines STANDARD_RIGHTS_EXECUTE and TOKEN_IMPERSONATE.</summary>
            TOKEN_EXECUTE = STANDARD_RIGHTS_EXECUTE | TOKEN_IMPERSONATE,

            /// <summary>Combines all possible access rights for a token.</summary>
            TOKEN_ALL_ACCESS = STANDARD_RIGHTS_REQUIRED |
                               TOKEN_ASSIGN_PRIMARY |
                               TOKEN_DUPLICATE |
                               TOKEN_IMPERSONATE |
                               TOKEN_QUERY |
                               TOKEN_QUERY_SOURCE |
                               TOKEN_ADJUST_PRIVILEGES |
                               TOKEN_ADJUST_GROUPS |
                               TOKEN_ADJUST_DEFAULT
        }
    }
}