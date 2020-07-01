// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PInvoke
{
    using System;

    /// <content>
    /// Contains the <see cref="CM_NOTIFY_FILTER_TYPE"/> nested enum.
    /// </content>
    public static partial class CfgMgr32
    {
        /// <summary>
        /// Specifies the kind of event filter being used.
        /// </summary>
        /// <seealso href="https://docs.microsoft.com/en-us/windows/win32/api/cfgmgr32/ns-cfgmgr32-cm_notify_filter"/>
        public enum CM_NOTIFY_FILTER_TYPE
        {
            /// <summary>
            /// Register for notifications for device interface events. <see cref="CM_NOTIFY_FILTER.ClassGuid"/> should be
            /// filled in with the <see cref="Guid"/> of the device interface class to receive notifications for.
            /// </summary>
            CM_NOTIFY_FILTER_TYPE_DEVICEINTERFACE = 0,

            /// <summary>
            /// Register for notifications for device handle events. <c>CM_NOTIFY_FILTER.Target</c> must be filled
            /// in with a handle to the device to receive notifications for.
            /// </summary>
            CM_NOTIFY_FILTER_TYPE_DEVICEHANDLE,

            /// <summary>
            /// Register for notifications for device instance events. <see cref="CM_NOTIFY_FILTER.InstanceId"/> should be filled
            /// in with the device instance ID of the device to receive notifications for.
            /// </summary>
            CM_NOTIFY_FILTER_TYPE_DEVICEINSTANCE,

            /// <summary>
            /// Do not use.
            /// </summary>
            CM_NOTIFY_FILTER_TYPE_MAX,
        }
    }
}
