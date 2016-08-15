// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using static Kernel32;
    using static Kernel32.ACCESS_MASK.StandardRight;

    /// <content>
    /// Contains the <see cref="TokenAccessRights"/> nested type.
    /// </content>
    public partial class AdvApi32
    {
        /// <summary>
        /// Enumerates the <see cref="ACCESS_MASK.SpecificRights"/> that may apply to tokens.
        /// </summary>
        public static class TokenAccessRights
        {
            /// <summary>
            ///     Required to attach a primary token to a process. The SE_ASSIGNPRIMARYTOKEN_NAME privilege is also required to
            ///     accomplish this task.
            /// </summary>
            public const uint TOKEN_ASSIGN_PRIMARY = 0x0001;

            /// <summary>Required to duplicate an access token.</summary>
            public const uint TOKEN_DUPLICATE = 0x0002;

            /// <summary>Required to attach an impersonation access token to a process.</summary>
            public const uint TOKEN_IMPERSONATE = 0x0004;

            /// <summary>Required to query an access token.</summary>
            public const uint TOKEN_QUERY = 0x0008;

            /// <summary>Required to query the source of an access token.</summary>
            public const uint TOKEN_QUERY_SOURCE = 0x0010;

            /// <summary>Required to enable or disable the privileges in an access token.</summary>
            public const uint TOKEN_ADJUST_PRIVILEGES = 0x0020;

            /// <summary>Required to adjust the attributes of the groups in an access token.</summary>
            public const uint TOKEN_ADJUST_GROUPS = 0x0040;

            /// <summary>Required to change the default owner, primary group, or DACL of an access token.</summary>
            public const uint TOKEN_ADJUST_DEFAULT = 0x0080;

            /// <summary>Required to adjust the session ID of an access token. The SE_TCB_NAME privilege is required.</summary>
            public const uint TOKEN_ADJUST_SESSIONID = 0x0100;

            /// <summary>Combines STANDARD_RIGHTS_READ and TOKEN_QUERY.</summary>
            public const uint TOKEN_READ = (uint)STANDARD_RIGHTS_READ | TOKEN_QUERY;

            /// <summary>Combines STANDARD_RIGHTS_WRITE, TOKEN_ADJUST_PRIVILEGES, TOKEN_ADJUST_GROUPS, and TOKEN_ADJUST_DEFAULT.</summary>
            public const uint TOKEN_WRITE = (uint)STANDARD_RIGHTS_WRITE | TOKEN_ADJUST_PRIVILEGES | TOKEN_ADJUST_GROUPS | TOKEN_ADJUST_DEFAULT;

            /// <summary>Combines STANDARD_RIGHTS_EXECUTE and TOKEN_IMPERSONATE.</summary>
            public const uint TOKEN_EXECUTE = (uint)STANDARD_RIGHTS_EXECUTE | TOKEN_IMPERSONATE;

            /// <summary>Combines all possible access rights for a token.</summary>
            public const uint TOKEN_ALL_ACCESS = (uint)STANDARD_RIGHTS_REQUIRED |
                                                       TOKEN_ASSIGN_PRIMARY |
                                                       TOKEN_DUPLICATE |
                                                       TOKEN_IMPERSONATE |
                                                       TOKEN_QUERY |
                                                       TOKEN_QUERY_SOURCE |
                                                       TOKEN_ADJUST_PRIVILEGES |
                                                       TOKEN_ADJUST_GROUPS |
                                                       TOKEN_ADJUST_DEFAULT;
        }
    }
}