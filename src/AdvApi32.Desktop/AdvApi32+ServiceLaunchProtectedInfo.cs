// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

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
        [StructLayout(LayoutKind.Sequential)]
        public struct ServiceLaunchProtectedInfo
        {
            /// <summary>
            /// The protection type of the service.
            /// </summary>
            public ServiceLaunchProtected dwPreshutdownTimeout;
        }
    }
}
