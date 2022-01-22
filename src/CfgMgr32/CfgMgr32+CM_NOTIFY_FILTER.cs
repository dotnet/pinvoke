// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Runtime.InteropServices;
    using System.Text;

    /// <content>
    /// Contains the <see cref="CM_NOTIFY_FILTER"/> nested enum.
    /// </content>
    public static partial class CfgMgr32
    {
        /// <summary>
        /// Device notification filter structure.
        /// </summary>
        /// <seealso href="https://docs.microsoft.com/en-us/windows/win32/api/cfgmgr32/ns-cfgmgr32-cm_notify_filter"/>
        [StructLayout(LayoutKind.Explicit)]
        public unsafe struct CM_NOTIFY_FILTER
        {
            /// <summary>
            /// The size of the structure.
            /// </summary>
            [FieldOffset(0)]
            public int cbSize;

            /// <summary>
            /// A combination of flags which define the behavior of the filter type.
            /// </summary>
            [FieldOffset(4)]
            public CM_NOTIFY_FILTER_FLAG Flags;

            /// <summary>
            /// The filter type.
            /// </summary>
            [FieldOffset(8)]
            public CM_NOTIFY_FILTER_TYPE FilterType;

            /// <summary>
            /// Set to 0.
            /// </summary>
            [FieldOffset(12)]
            public uint Reserved;

            /// <summary>
            /// When <see cref="FilterType"/> is <see cref="CM_NOTIFY_FILTER_TYPE.CM_NOTIFY_FILTER_TYPE_DEVICEINSTANCE"/>,
            /// the device instance ID of the device to receive notifications for.
            /// </summary>
            [FieldOffset(16)]
            public fixed char InstanceId[CfgMgr32.MAX_DEVICE_ID_LEN];

            /// <summary>
            /// When <see cref="FilterType"/> is <see cref="CM_NOTIFY_FILTER_TYPE.CM_NOTIFY_FILTER_TYPE_DEVICEHANDLE"/>,
            /// a handle to the device to receive notifications for.
            /// </summary>
            [FieldOffset(16)]
            public IntPtr hTarget;

            /// <summary>
            /// When <see cref="FilterType"/> is <see cref="CM_NOTIFY_FILTER_TYPE.CM_NOTIFY_FILTER_TYPE_DEVICEINTERFACE"/>,
            /// the GUID of the device interface class to receive notifications for.
            /// </summary>
            [FieldOffset(16)]
            public Guid ClassGuid;

            /// <summary>
            /// Gets a <see cref="CM_NOTIFY_FILTER"/> which represents a request to receive notifications for PnP events for all device interface classes.
            /// </summary>
            public static CM_NOTIFY_FILTER AllInterfaces
            {
                get
                {
                    CM_NOTIFY_FILTER filter = Create();
                    filter.Flags = CM_NOTIFY_FILTER_FLAG.ALL_DEVICE_INSTANCES;
                    filter.FilterType = CM_NOTIFY_FILTER_TYPE.CM_NOTIFY_FILTER_TYPE_DEVICEINSTANCE;
                    return filter;
                }
            }

            /// <summary>
            /// Gets a <see cref="CM_NOTIFY_FILTER"/> which represents a request to receive notifications for PnP events for all devices.
            /// </summary>
            public static CM_NOTIFY_FILTER AllDevices
            {
                get
                {
                    CM_NOTIFY_FILTER filter = Create();
                    filter.Flags = CM_NOTIFY_FILTER_FLAG.ALL_INTERFACE_CLASSES;
                    filter.FilterType = CM_NOTIFY_FILTER_TYPE.CM_NOTIFY_FILTER_TYPE_DEVICEINTERFACE;
                    return filter;
                }
            }

            /// <summary>
            /// Creates a <see cref="CM_NOTIFY_FILTER"/> with <see cref="cbSize"/> pre-initialized.
            /// </summary>
            /// <returns>
            /// A new instance of the <see cref="CM_NOTIFY_FILTER"/> struct.
            /// </returns>
            public static CM_NOTIFY_FILTER Create()
            {
                return new CM_NOTIFY_FILTER()
                {
                    cbSize = sizeof(CM_NOTIFY_FILTER),
                };
            }

            /// <summary>
            /// Creates a <see cref="CM_NOTIFY_FILTER"/>, registering notifications for a device
            /// interface.
            /// </summary>
            /// <param name="classGuid">
            /// The <see cref="Guid"/> of the device interface class for which to receive notifications.
            /// </param>
            /// <returns>
            /// A new instance of the <see cref="CM_NOTIFY_FILTER"/> struct.
            /// </returns>
            public static CM_NOTIFY_FILTER Create(Guid classGuid)
            {
                return new CM_NOTIFY_FILTER()
                {
                    cbSize = sizeof(CM_NOTIFY_FILTER),
                    ClassGuid = classGuid,
                    FilterType = CM_NOTIFY_FILTER_TYPE.CM_NOTIFY_FILTER_TYPE_DEVICEINTERFACE,
                };
            }

            /// <summary>
            /// Creates a <see cref="CM_NOTIFY_FILTER"/>, registering notifications for a device
            /// instance.
            /// </summary>
            /// <param name="target">
            /// A handle to the device for which to receive notifications.
            /// </param>
            /// <returns>
            /// A new instance of the <see cref="CM_NOTIFY_FILTER"/> struct.
            /// </returns>
            public static CM_NOTIFY_FILTER Create(IntPtr target)
            {
                return new CM_NOTIFY_FILTER()
                {
                    cbSize = sizeof(CM_NOTIFY_FILTER),
                    hTarget = target,
                    FilterType = CM_NOTIFY_FILTER_TYPE.CM_NOTIFY_FILTER_TYPE_DEVICEHANDLE,
                };
            }

            /// <summary>
            /// Creates a <see cref="CM_NOTIFY_FILTER"/>, registering notifications for a device
            /// instance.
            /// </summary>
            /// <param name="instanceId">
            /// The device instance ID for the device for which to receive notifications.
            /// </param>
            /// <returns>
            /// A new instance of the <see cref="CM_NOTIFY_FILTER"/> struct.
            /// </returns>
            public static CM_NOTIFY_FILTER Create(string instanceId)
            {
                if (instanceId == null)
                {
                    throw new ArgumentNullException(nameof(instanceId));
                }

                if (instanceId.Length > CfgMgr32.MAX_DEVICE_ID_LEN)
                {
                    throw new ArgumentException("The length of instanceId cannot exceed " + nameof(MAX_DEVICE_ID_LEN), nameof(instanceId));
                }

                var filter = new CM_NOTIFY_FILTER()
                {
                    cbSize = sizeof(CM_NOTIFY_FILTER),
                    FilterType = CM_NOTIFY_FILTER_TYPE.CM_NOTIFY_FILTER_TYPE_DEVICEINSTANCE,
                };

                fixed (char* pInstanceId = instanceId)
                {
                    for (int i = 0; i < instanceId.Length; i++)
                    {
                        filter.InstanceId[i] = pInstanceId[i];
                    }
                }

                return filter;
            }
        }
    }
}
