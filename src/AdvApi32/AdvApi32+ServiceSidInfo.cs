// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PInvoke
{
    using System.Runtime.InteropServices;

    /// <content>
    /// Contains the <see cref="ServiceSidInfo"/> nested type.
    /// </content>
    public static partial class AdvApi32
    {
        /// <summary>
        /// Represents a service security identifier (SID).
        /// </summary>
        public struct ServiceSidInfo
        {
            /// <summary>
            /// The service SID type.
            /// </summary>
            public ServiceSidType dwServiceSidType;
        }
    }
}
