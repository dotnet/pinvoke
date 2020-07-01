// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Runtime.InteropServices;

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
            public uint cbSize;

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
            public IntPtr Target;

            /// <summary>
            /// When <see cref="FilterType"/> is <see cref="CM_NOTIFY_FILTER_TYPE.CM_NOTIFY_FILTER_TYPE_DEVICEINTERFACE"/>,
            /// the GUID of the device interface class to receive notifications for.
            /// </summary>
            [FieldOffset(16)]
            public Guid ClassGuid;
        }
    }
}
