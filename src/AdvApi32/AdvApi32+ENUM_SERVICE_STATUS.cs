// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PInvoke
{
    using System.Runtime.InteropServices;

    /// <content>
    /// Contains the <see cref="ENUM_SERVICE_STATUS"/> nested type.
    /// </content>
    public partial class AdvApi32
    {
        /// <summary>
        /// Contains the name of a service in a service control manager database and information about that service.
        /// It is used by the EnumDependentServices and EnumServicesStatus functions.
        /// </summary>
        public struct ENUM_SERVICE_STATUS
        {
            /// <summary>
            /// The name of a service in the service control manager database.
            /// The maximum string length is 256 characters. The service control manager database preserves the case of the characters,
            /// but service name comparisons are always case insensitive.
            /// A slash (/), backslash (\), comma, and space are invalid service name characters.
            /// </summary>
            public string lpServiceName;

            /// <summary>
            /// A display name that can be used by service control programs, such as Services in Control Panel, to identify the service.
            /// This string has a maximum length of 256 characters. The name is case-preserved in the service control manager.
            /// Display name comparisons are always case-insensitive.
            /// </summary>
            public string lpDisplayName;

            /// <summary>
            /// A <see cref="SERVICE_STATUS"/> structure that contains status information for the <see cref="lpServiceName"/> service.
            /// </summary>
            public SERVICE_STATUS ServiceStatus;
        }
    }
}
