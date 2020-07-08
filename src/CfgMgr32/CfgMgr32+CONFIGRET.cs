// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PInvoke
{
    /// <content>
    /// Contains the <see cref="CONFIGRET"/> nested enum.
    /// </content>
    public static partial class CfgMgr32
    {
        /// <summary>
        /// The OBJECT_ATTRIBUTES structure specifies attributes that can be applied to objects or object handles by routines that create objects and/or return handles to objects.
        /// </summary>
        public enum CONFIGRET
        {
            /// <summary>
            /// The operation completed successfully.
            /// </summary>
            CR_SUCCESS = 0x00000000,

            /// <summary>
            /// The default value.
            /// </summary>
            CR_DEFAULT = 0x00000001,

            /// <summary>
            /// There's not enough memory available.
            /// </summary>
            CR_OUT_OF_MEMORY = 0x00000002,

            /// <summary>
            /// Invalid pointer.
            /// </summary>
            CR_INVALID_POINTER = 0x00000003,

            /// <summary>
            /// Invalid flag.
            /// </summary>
            CR_INVALID_FLAG = 0x00000004,

            /// <summary>
            /// Invalid device node.
            /// </summary>
            CR_INVALID_DEVNODE = 0x00000005,

            /// <summary>
            /// The resource descriptor is invalid.
            /// </summary>
            CR_INVALID_RES_DES = 0x00000006,

            /// <summary>
            /// The logical configuration is invalid.
            /// </summary>
            CR_INVALID_LOG_CONF = 0x00000007,

            /// <summary>
            /// Invalid arbitrator.
            /// </summary>
            CR_INVALID_ARBITRATOR = 0x00000008,

            /// <summary>
            /// Invalid node list.
            /// </summary>
            CR_INVALID_NODELIST = 0x00000009,

            /// <summary>
            /// Device node has requirements.
            /// </summary>
            CR_DEVNODE_HAS_REQS = 0x0000000A,

            /// <summary>
            /// Invalid resource IDs.
            /// </summary>
            CR_INVALID_RESOURCEID = 0x0000000B,

            /// <summary>
            /// There's no such device node.
            /// </summary>
            CR_NO_SUCH_DEVNODE = 0x0000000D,

            /// <summary>
            /// No more logical configurations are available.
            /// </summary>
            CR_NO_MORE_LOG_CONF = 0x0000000E,

            /// <summary>
            /// No more resource descriptors are available.
            /// </summary>
            CR_NO_MORE_RES_DES = 0x0000000F,

            /// <summary>
            /// Such a device node already exists.
            /// </summary>
            CR_ALREADY_SUCH_DEVNODE = 0x00000010,

            /// <summary>
            /// The list range is invalid.
            /// </summary>
            CR_INVALID_RANGE_LIST = 0x00000011,

            /// <summary>
            /// The range is invalid.
            /// </summary>
            CR_INVALID_RANGE = 0x00000012,

            /// <summary>
            /// A failure has occurred.
            /// </summary>
            CR_FAILURE = 0x00000013,

            /// <summary>
            /// There's no such logical device.
            /// </summary>
            CR_NO_SUCH_LOGICAL_DEV = 0x00000014,

            /// <summary>
            /// The create operation has been blocked.
            /// </summary>
            CR_CREATE_BLOCKED = 0x00000015,

            /// <summary>
            /// The removal request has been vetoed.
            /// </summary>
            CR_REMOVE_VETOED = 0x00000017,

            /// <summary>
            /// The APM request has been vetoed.
            /// </summary>
            CR_APM_VETOED = 0x00000018,

            /// <summary>
            /// The load type is invalid.
            /// </summary>
            CR_INVALID_LOAD_TYPE = 0x00000019,

            /// <summary>
            /// The buffer is too small.
            /// </summary>
            CR_BUFFER_SMALL = 0x0000001A,

            /// <summary>
            /// No arbitrator is available.
            /// </summary>
            CR_NO_ARBITRATOR = 0x0000001B,

            /// <summary>
            /// No registry handle is available.
            /// </summary>
            CR_NO_REGISTRY_HANDLE = 0x0000001C,

            /// <summary>
            /// A registry error has occurred.
            /// </summary>
            CR_REGISTRY_ERROR = 0x0000001D,

            /// <summary>
            /// The device ID is invalid.
            /// </summary>
            CR_INVALID_DEVICE_ID = 0x0000001E,

            /// <summary>
            /// The device data is invalid.
            /// </summary>
            CR_INVALID_DATA = 0x0000001F,

            /// <summary>
            /// The API is invalid.
            /// </summary>
            CR_INVALID_API = 0x00000020,

            /// <summary>
            /// The device loader is not ready.
            /// </summary>
            CR_DEVLOADER_NOT_READY = 0x00000021,

            /// <summary>
            /// A system reboot is required.
            /// </summary>
            CR_NEED_RESTART = 0x00000022,

            /// <summary>
            /// No more hardware profiles are available.
            /// </summary>
            CR_NO_MORE_HW_PROFILES = 0x00000023,

            /// <summary>
            /// The device is not there.
            /// </summary>
            CR_DEVICE_NOT_THERE = 0x00000024,

            /// <summary>
            /// The requested value is not available.
            /// </summary>
            CR_NO_SUCH_VALUE = 0x00000025,

            /// <summary>
            /// The value type is incorrect.
            /// </summary>
            CR_WRONG_TYPE = 0x00000026,

            /// <summary>
            /// The priority is invalid.
            /// </summary>
            CR_INVALID_PRIORITY = 0x00000027,

            /// <summary>
            /// The device cannot be disabled.
            /// </summary>
            CR_NOT_DISABLEABLE = 0x00000028,

            /// <summary>
            /// The resources have been freed.
            /// </summary>
            CR_FREE_RESOURCES = 0x00000029,

            /// <summary>
            /// The query has been vetoed.
            /// </summary>
            CR_QUERY_VETOED = 0x0000002A,

            /// <summary>
            /// The IRQ cannot be shared.
            /// </summary>
            CR_CANT_SHARE_IRQ = 0x0000002B,

            /// <summary>
            /// There's no dependent resource.
            /// </summary>
            CR_NO_DEPENDENT = 0x0000002C,

            /// <summary>
            /// The two resources represent the same resource.
            /// </summary>
            CR_SAME_RESOURCES = 0x0000002D,

            /// <summary>
            /// There's no such registry key.
            /// </summary>
            CR_NO_SUCH_REGISTRY_KEY = 0x0000002E,

            /// <summary>
            /// The machine name is invalid.
            /// </summary>
            CR_INVALID_MACHINENAME = 0x0000002F,

            /// <summary>
            /// The remote communication has failed.
            /// </summary>
            CR_REMOTE_COMM_FAILURE = 0x00000030,

            /// <summary>
            /// The remote machine is unavailable.
            /// </summary>
            CR_MACHINE_UNAVAILABLE = 0x00000031,

            /// <summary>
            /// The remote machine has no configuration management services.
            /// </summary>
            CR_NO_CM_SERVICES = 0x00000032,

            /// <summary>
            /// Access has been denied.
            /// </summary>
            CR_ACCESS_DENIED = 0x00000033,

            /// <summary>
            /// The requested call is not implemented.
            /// </summary>
            CR_CALL_NOT_IMPLEMENTED = 0x00000034,

            /// <summary>
            /// The property is invalid.
            /// </summary>
            CR_INVALID_PROPERTY = 0x00000035,

            /// <summary>
            /// The device interface is active.
            /// </summary>
            CR_DEVICE_INTERFACE_ACTIVE = 0x00000036,

            /// <summary>
            /// There's no such device interface.
            /// </summary>
            CR_NO_SUCH_DEVICE_INTERFACE = 0x00000037,

            /// <summary>
            /// The reference string is invalid.
            /// </summary>
            CR_INVALID_REFERENCE_STRING = 0x00000038,

            /// <summary>
            /// The conflict list is invalid.
            /// </summary>
            CR_INVALID_CONFLICT_LIST = 0x00000039,

            /// <summary>
            /// The index is invalid.
            /// </summary>
            CR_INVALID_INDEX = 0x0000003A,

            /// <summary>
            /// The structure size is invalid.
            /// </summary>
            CR_INVALID_STRUCTURE_SIZE = 0x0000003B,
        }
    }
}
