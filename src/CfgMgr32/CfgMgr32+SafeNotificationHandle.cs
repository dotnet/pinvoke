// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Runtime.InteropServices;
    using Microsoft.Win32.SafeHandles;

    /// <content>
    /// Contains the <see cref="SafeNotificationHandle"/> nested enum.
    /// </content>
    public static partial class CfgMgr32
    {
        /// <summary>
        /// A handle which represents a notification context.
        /// </summary>
        public class SafeNotificationHandle : SafeHandleZeroOrMinusOneIsInvalid
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="SafeNotificationHandle"/> class.
            /// </summary>
            public SafeNotificationHandle()
                : base(true)
            {
            }

            /// <inheritdoc/>
            protected override bool ReleaseHandle()
            {
                return CfgMgr32.CM_Unregister_Notification(this.handle) == CONFIGRET.CR_SUCCESS;
            }
        }
    }
}
