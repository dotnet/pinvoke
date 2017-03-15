// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using static Kernel32;
    using static Kernel32.ACCESS_MASK.StandardRight;

    /// <content>
    /// Contains the <see cref="ServiceAccess"/> nested type.
    /// </content>
    public partial class AdvApi32
    {
        /// <summary>
        /// Enumerates the <see cref="ACCESS_MASK.SpecificRights"/> that may apply to services.
        /// </summary>
        public static class ServiceAccess
        {
            public const uint SERVICE_QUERY_CONFIG = 0x0001;
            public const uint SERVICE_CHANGE_CONFIG = 0x0002;
            public const uint SERVICE_QUERY_STATUS = 0x0004;
            public const uint SERVICE_ENUMERATE_DEPENDENTS = 0x0008;
            public const uint SERVICE_START = 0x0010;
            public const uint SERVICE_STOP = 0x0020;
            public const uint SERVICE_PAUSE_CONTINUE = 0x0040;
            public const uint SERVICE_INTERROGATE = 0x0080;
            public const uint SERVICE_USER_DEFINED_CONTROL = 0x0100;
            public const uint SERVICE_ALL_ACCESS = (uint)STANDARD_RIGHTS_REQUIRED |
                                                         SERVICE_QUERY_CONFIG |
                                                         SERVICE_CHANGE_CONFIG |
                                                         SERVICE_QUERY_STATUS |
                                                         SERVICE_ENUMERATE_DEPENDENTS |
                                                         SERVICE_START |
                                                         SERVICE_STOP |
                                                         SERVICE_PAUSE_CONTINUE |
                                                         SERVICE_INTERROGATE |
                                                         SERVICE_USER_DEFINED_CONTROL;
        }
    }
}
