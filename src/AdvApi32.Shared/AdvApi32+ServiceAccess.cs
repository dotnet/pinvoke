// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;
    using static Kernel32;
    using static Kernel32.ACCESS_MASK.StandardRight;

    /// <content>
    /// Contains the <see cref="ServiceAccess"/> nested enum.
    /// </content>
    public partial class AdvApi32
    {
        /// <summary>
        /// Enumerates the <see cref="ACCESS_MASK.SpecificRights"/> that may apply to services.
        /// </summary>
        [Flags]
        public enum ServiceAccess : uint
        {
            SERVICE_QUERY_CONFIG = 0x0001,
            SERVICE_CHANGE_CONFIG = 0x0002,
            SERVICE_QUERY_STATUS = 0x0004,
            SERVICE_ENUMERATE_DEPENDENTS = 0x0008,
            SERVICE_START = 0x0010,
            SERVICE_STOP = 0x0020,
            SERVICE_PAUSE_CONTINUE = 0x0040,
            SERVICE_INTERROGATE = 0x0080,
            SERVICE_USER_DEFINED_CONTROL = 0x0100,
            SERVICE_ALL_ACCESS = STANDARD_RIGHTS_REQUIRED |
                                 SERVICE_QUERY_CONFIG |
                                 SERVICE_CHANGE_CONFIG |
                                 SERVICE_QUERY_STATUS |
                                 SERVICE_ENUMERATE_DEPENDENTS |
                                 SERVICE_START |
                                 SERVICE_STOP |
                                 SERVICE_PAUSE_CONTINUE |
                                 SERVICE_INTERROGATE |
                                 SERVICE_USER_DEFINED_CONTROL
        }
    }
}
