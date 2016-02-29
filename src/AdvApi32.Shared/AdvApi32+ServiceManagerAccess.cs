// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;
    using static Kernel32;
    using static Kernel32.ACCESS_MASK.StandardRight;

    /// <content>
    /// Contains the <see cref="ServiceManagerAccess"/> nested enum.
    /// </content>
    public partial class AdvApi32
    {
        /// <summary>
        /// Enumerates the <see cref="ACCESS_MASK.SpecificRights"/> that may apply to service managers.
        /// </summary>
        [Flags]
        public enum ServiceManagerAccess : uint
        {
            SC_MANAGER_CONNECT = 0x0001,
            SC_MANAGER_CREATE_SERVICE = 0x0002,
            SC_MANAGER_ENUMERATE_SERVICE = 0x0004,
            SC_MANAGER_LOCK = 0x0008,
            SC_MANAGER_QUERY_LOCK_STATUS = 0x0010,
            SC_MANAGER_MODIFY_BOOT_CONFIG = 0x0020,
            SC_MANAGER_ALL_ACCESS = STANDARD_RIGHTS_REQUIRED |
                                    SC_MANAGER_CONNECT |
                                    SC_MANAGER_CREATE_SERVICE |
                                    SC_MANAGER_ENUMERATE_SERVICE |
                                    SC_MANAGER_LOCK |
                                    SC_MANAGER_QUERY_LOCK_STATUS |
                                    SC_MANAGER_MODIFY_BOOT_CONFIG
        }
    }
}
