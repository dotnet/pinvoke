// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;

    /// <content>
    /// Contains the <see cref="NetUserEnumFilter"/> nested type.
    /// </content>
    public partial class NetApi32
    {
        /// <summary>
        /// Allowed values for the filter parameter of the <see cref="NetUserEnum(string, NetUserEnumLevel, NetUserEnumFilter, byte*, uint, out uint, out uint, ref uint)"/> function.
        /// </summary>
        [Flags]
        public enum NetUserEnumFilter : uint
        {
            /// <summary>
            /// Enumerates account data for users whose primary account is in another domain. This account type provides user access to this domain, but not to any domain that trusts this domain. The User Manager refers to this account type as a local user account.
            /// </summary>
            FILTER_TEMP_DUPLICATE_ACCOUNT = 0x0001,

            /// <summary>
            /// Enumerates normal user account data. This account type is associated with a typical user.
            /// </summary>
            FILTER_NORMAL_ACCOUNT = 0x0002,

            /// <summary>
            /// Enumerates interdomain trust account data. This account type is associated with a trust account for a domain that trusts other domains.
            /// </summary>
            FILTER_INTERDOMAIN_TRUST_ACCOUNT = 0x0008,

            /// <summary>
            /// Enumerates workstation or member server trust account data. This account type is associated with a machine account for a computer that is a member of the domain.
            /// </summary>
            FILTER_WORKSTATION_TRUST_ACCOUNT = 0x0010,

            /// <summary>
            /// numerates member server machine account data. This account type is associated with a computer account for a backup domain controller that is a member of the domain.
            /// </summary>
            FILTER_SERVER_TRUST_ACCOUNT = 0x0020,
        }
    }
}
