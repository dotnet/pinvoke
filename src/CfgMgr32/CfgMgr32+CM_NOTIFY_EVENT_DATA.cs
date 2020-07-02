// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

// StyleCop wants us to write `ref public unsafe struct`, which doesn't make much sense
#pragma warning disable SA1206

namespace PInvoke
{
    using System;
    using System.Runtime.InteropServices;

    /// <content>
    /// Contains the <see cref="CM_NOTIFY_EVENT_DATA"/> nested struct.
    /// </content>
    public static partial class CfgMgr32
    {
        /// <summary>
        /// This is a device notification event data structure.
        /// </summary>
        /// <seealso hcref="https://docs.microsoft.com/en-us/windows/win32/api/cfgmgr32/ns-cfgmgr32-cm_notify_event_data"/>
        [StructLayout(LayoutKind.Explicit)]
        public unsafe ref struct CM_NOTIFY_EVENT_DATA
        {
            /// <summary>
            /// The <see cref="CM_NOTIFY_FILTER_TYPE"/> from the <see cref="CM_NOTIFY_FILTER"/> structure that was used in
            /// the registration that generated this notification event data.
            /// </summary>
            [FieldOffset(0)]
            public CM_NOTIFY_FILTER_TYPE FilterType;

            /// <summary>
            /// Reserved. Must be 0.
            /// </summary>
            [FieldOffset(4)]
            public uint Reserved;

            // DeviceInterface

            /// <summary>
            /// The GUID of the device interface class for the device interface to which the notification event data pertains.
            /// </summary>
            [FieldOffset(8)]
            public Guid ClassGuid;

            /// <summary>
            /// The first character of the symbolic link path of the device interface to which the notification event data pertains.
            /// Use <see cref="GetSymbolicLink(CM_NOTIFY_EVENT_DATA*, int)"/> to retrieve this value.
            /// </summary>
            [FieldOffset(SymbolicLinkOffset)]
            public fixed char SymbolicLink[1];

            // DeviceHandle

            /// <summary>
            /// The GUID for the custom event.
            /// </summary>
            [FieldOffset(8)]
            public Guid EventGuid;

            /// <summary>
            /// The offset of an optional string buffer. Usage depends on the contract for the EventGuid.
            /// </summary>
            [FieldOffset(24)]
            public int NameOffset;

            /// <summary>
            /// The number of bytes that can be read from the Data member.
            /// </summary>
            [FieldOffset(28)]
            public int DataSize;

            /// <summary>
            /// The first byte of optional binary data. Usage depends on the contract for the EventGuid.
            /// </summary>
            [FieldOffset(32)]
            public fixed byte Data[1];

            // DeviceInstance

            /// <summary>
            /// The first character of the device instance ID of the device to which the notification event data pertains.
            /// Use <see cref="GetInstanceId(CM_NOTIFY_EVENT_DATA*, int)"/> to retrieve this value.
            /// </summary>
            [FieldOffset(InstanceIdOffset)]
            public fixed char InstanceId[1];

            private const int SymbolicLinkOffset = 24;
            private const int InstanceIdOffset = 8;

            /// <summary>
            /// Gets the symbolic link path of the device interface to which the notification event data pertains.
            /// </summary>
            /// <param name="eventData">
            /// The event notification.
            /// </param>
            /// <param name="eventDataSize">
            /// The event notification size.
            /// </param>
            /// <returns>
            /// The symbolic link path of the device interface to which the notification event data pertains
            /// </returns>
            public static string GetSymbolicLink(CM_NOTIFY_EVENT_DATA* eventData, int eventDataSize)
            {
                if (eventData->FilterType != CM_NOTIFY_FILTER_TYPE.CM_NOTIFY_FILTER_TYPE_DEVICEINTERFACE)
                {
                    throw new InvalidOperationException();
                }

                // Offset and count are represented in characters. Each character is 2 bytes wide.
                // Trim the terminating \0 character at the end.
                return new string((char*)eventData, SymbolicLinkOffset / sizeof(char), ((eventDataSize - SymbolicLinkOffset) / sizeof(char)) - 1);
            }

            /// <summary>
            /// Gets the device instance ID of the device to which the notification event data pertains.
            /// </summary>
            /// <param name="eventData">
            /// The event notification.
            /// </param>
            /// <param name="eventDataSize">
            /// The event notification size.
            /// </param>
            /// <returns>
            /// The device instance ID of the device to which the notification event data pertains.
            /// </returns>
            public static string GetInstanceId(CM_NOTIFY_EVENT_DATA* eventData, int eventDataSize)
            {
                if (eventData->FilterType != CM_NOTIFY_FILTER_TYPE.CM_NOTIFY_FILTER_TYPE_DEVICEINSTANCE)
                {
                    throw new InvalidOperationException();
                }

                // Offset and count are represented in characters. Each character is 2 bytes wide.
                // Trim the terminating \0 character at the end.
                return new string((char*)eventData, InstanceIdOffset / sizeof(char), ((eventDataSize - InstanceIdOffset) / sizeof(char)) - 1);
            }
        }
    }
}
