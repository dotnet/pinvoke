// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PInvoke
{
    using System.Runtime.InteropServices;

    /// <content>
    /// Contains the <see cref="ServiceLaunchProtectedInfo"/> nested type.
    /// </content>
    public static partial class AdvApi32
    {
        /// <summary>
        /// Indicates a service protection type.
        /// </summary>
        public struct ServiceLaunchProtectedInfo
        {
            /// <summary>
            /// The protection type of the service.
            /// </summary>
            public ServiceLaunchProtected dwPreshutdownTimeout;
        }
    }
}
