// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    /// <content>
    /// Contains the <see cref="ServiceLaunchProtected"/> nested type.
    /// </content>
    public static partial class AdvApi32
    {
        /// <summary>
        /// The protection type of the service
        /// </summary>
        public enum ServiceLaunchProtected
        {
            SERVICE_LAUNCH_PROTECTED_NONE = 0,
            SERVICE_LAUNCH_PROTECTED_WINDOWS = 1,
            SERVICE_LAUNCH_PROTECTED_WINDOWS_LIGHT = 2,
            SERVICE_LAUNCH_PROTECTED_ANTIMALWARE_LIGHT = 3
        }
    }
}
