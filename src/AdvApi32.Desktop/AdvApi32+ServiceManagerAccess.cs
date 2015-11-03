// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;

    /// <content>
    /// Contains the <see cref="ServiceManagerAccess"/> nested enum.
    /// </content>
    public partial class AdvApi32
    {
        /// <summary>
        /// Describes service manager access flags.
        /// </summary>
        [Flags]
        public enum ServiceManagerAccess : uint
        {
            GenericRead = 0x80000000,
            GenericWrite = 0x40000000,
            GenericExecute = 0x20000000,

            AccessSystemSecurity = 0x1000000,
            Delete = 0x10000,
            ReadControl = 0x20000,
            WriteDAC = 0x40000,
            WriteOwner = 0x80000,

            STANDARD_RIGHTS_REQUIRED = 0xF0000,

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
