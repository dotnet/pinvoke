// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System.Runtime.InteropServices;

    /// <content>
    /// Contains the <see cref="ServiceSidType"/> nested type.
    /// </content>
    public static partial class AdvApi32
    {
        /// <summary>
        /// Represents a service security identifier (SID).
        /// </summary>
        public enum ServiceSidType
        {
            /// <summary>
            /// Use this type to reduce application compatibility issues.
            /// </summary>
            SERVICE_SID_TYPE_NONE = 0x00000000,

            /// <summary>
            /// When the service process is created,
            /// the service SID is added to the service process token with the following attributes: SE_GROUP_ENABLED_BY_DEFAULT | SE_GROUP_OWNER.
            /// </summary>
            SERVICE_SID_TYPE_UNRESTRICTED = 0x00000001,

            /// <summary>
            /// This type includes SERVICE_SID_TYPE_UNRESTRICTED.
            /// The service SID is also added to the restricted SID list of the process token.
            /// Three additional SIDs are also added to the restricted SID list:
            /// <list type="bullet">
            /// <item>World SID S-1-1-0</item>
            /// <item>Service logon SID</item>
            /// <item>Write-restricted SID S-1-5-33</item>
            /// </list>
            /// One ACE that allows GENERIC_ALL access for the service logon SID is also added to the service process token object.
            /// If there are multiple services hosted in the same process and one service has SERVICE_SID_TYPE_RESTRICTED, all services must have SERVICE_SID_TYPE_RESTRICTED.
            /// </summary>
            SERVICE_SID_TYPE_RESTRICTED = 0x00000003
        }
    }
}
