// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PInvoke
{
    using Microsoft.Win32.SafeHandles;

    /// <content>
    /// Contains the <see cref="SafeNotificationHandle"/> nested enum.
    /// </content>
    public static partial class CfgMgr32
    {
        public class SafeNotificationHandle : SafeHandleZeroOrMinusOneIsInvalid
        {
            public SafeNotificationHandle()
                : base(true)
            {
            }

            protected override bool ReleaseHandle()
            {
                return CfgMgr32.CM_Unregister_Notification(this.handle) == CONFIGRET.CR_SUCCESS;
            }
        }
    }
}
