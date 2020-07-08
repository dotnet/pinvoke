// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PInvoke
{
    /// <content>
    /// Contains the <see cref="CM_NOTIFY_FILTER_FLAG"/> nested enum.
    /// </content>
    public static partial class CfgMgr32
    {
        /// <summary>
        /// Refines the behavior of <see cref="CM_NOTIFY_FILTER.FilterType"/>.
        /// </summary>
        /// <seealso href="https://docs.microsoft.com/en-us/windows/win32/api/cfgmgr32/ns-cfgmgr32-cm_notify_filter"/>
        public enum CM_NOTIFY_FILTER_FLAG
        {
            /// <summary>
            /// Register to receive notifications for PnP events for all device interface classes.
            /// The memory at <see cref="CM_NOTIFY_FILTER.ClassGuid"/> must be zeroes.
            /// Do not use this flag with <see cref="CM_NOTIFY_FILTER_FLAG.ALL_DEVICE_INSTANCES"/>.
            /// This flag is only valid if <see cref="CM_NOTIFY_FILTER.FilterType"/> is <see cref="CM_NOTIFY_FILTER_TYPE.CM_NOTIFY_FILTER_TYPE_DEVICEINTERFACE"/>.
            /// </summary>
            ALL_INTERFACE_CLASSES = 0x00000001,

            /// <summary>
            /// Register to receive notifications for PnP events for all devices. <see cref="CM_NOTIFY_FILTER.InstanceId"/> must be an empty string.
            /// Do not use this flag with <see cref="CM_NOTIFY_FILTER_FLAG.ALL_INTERFACE_CLASSES"/>.
            /// This flag is only valid if <see cref="CM_NOTIFY_FILTER.FilterType"/> is <see cref="CM_NOTIFY_FILTER_TYPE.CM_NOTIFY_FILTER_TYPE_DEVICEINSTANCE"/>.
            /// </summary>
            ALL_DEVICE_INSTANCES = 0x00000002,
        }
    }
}
