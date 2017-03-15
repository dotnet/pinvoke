// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Runtime.InteropServices;

    /// <content>
    /// Contains the <see cref="SERVICE_TRIGGER_SPECIFIC_DATA_ITEM"/> nested type.
    /// </content>
    public partial class AdvApi32
    {
        /// <summary>
        /// Contains trigger-specific data for a service trigger event.
        /// This structure is used by the <see cref="ServiceTrigger"/> structure for <see cref="ServiceTriggerType.SERVICE_TRIGGER_TYPE_CUSTOM"/>, <see cref="ServiceTriggerType.SERVICE_TRIGGER_TYPE_DEVICE_INTERFACE_ARRIVAL"/>, <see cref="ServiceTriggerType.SERVICE_TRIGGER_TYPE_FIREWALL_PORT_EVENT"/>, or <see cref="ServiceTriggerType.SERVICE_TRIGGER_TYPE_NETWORK_ENDPOINT"/> trigger events.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct SERVICE_TRIGGER_SPECIFIC_DATA_ITEM
        {
            /// <summary>
            /// The data type of the trigger-specific data pointed to by <see cref="pData"/>.
            /// </summary>
            public ServiceTriggerDataType dwDataType;

            /// <summary>
            /// The size of the trigger-specific data pointed to <see cref="pData"/>, in bytes.
            /// The maximum value is 1024.
            /// </summary>
            public int cbData;

            /// <summary>
            /// A pointer to the trigger-specific data for the service trigger event.
            /// The trigger-specific data depends on the trigger event type; see Remarks.
            /// If the <see cref="dwDataType"/> member is <see cref="ServiceTriggerDataType.SERVICE_TRIGGER_DATA_TYPE_BINARY"/>, the trigger-specific data is an array of bytes.
            /// If the <see cref="dwDataType"/> member is <see cref="ServiceTriggerDataType.SERVICE_TRIGGER_DATA_TYPE_STRING"/>, the trigger-specific data is a null-terminated string or a multistring of null-terminated strings,
            /// ending with two null-terminating characters.
            /// For example: "5001\0UDP\0%programfiles%\MyApplication\MyServiceProcess.exe\0MyService\0\0".
            /// Strings must be Unicode; ANSI strings are not supported.
            /// </summary>
            public IntPtr pData;
        }
    }
}
