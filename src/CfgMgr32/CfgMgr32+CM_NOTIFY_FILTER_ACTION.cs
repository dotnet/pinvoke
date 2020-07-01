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
        /// This enumeration identifies Plug and Play device event types.
        /// </summary>
        /// <seealso href="https://docs.microsoft.com/en-us/windows/win32/api/cfgmgr32/ne-cfgmgr32-cm_notify_action"/>
        public enum CM_NOTIFY_ACTION
        {
            /* Filter type: CM_NOTIFY_FILTER_TYPE_DEVICEINTERFACE */

            /// <summary>
            /// For this value, set <see cref="CM_NOTIFY_FILTER.FilterType"/>
            /// to CM_NOTIFY_FILTER_TYPE_DEVICEINTERFACE. This action indicates that a device interface that meets your filter criteria has been enabled.
            /// </summary>
            CM_NOTIFY_ACTION_DEVICEINTERFACEARRIVAL = 0,

            /// <summary>
            /// This action indicates that a device interface that meets your filter criteria has been disabled.
            /// </summary>
            /// <remarks>
            /// For this value, set <see cref="CM_NOTIFY_FILTER.FilterType"/> to <see cref="CM_NOTIFY_FILTER_TYPE.CM_NOTIFY_FILTER_TYPE_DEVICEINTERFACE"/>.
            /// </remarks>
            CM_NOTIFY_ACTION_DEVICEINTERFACEREMOVAL,

            /* Filter type: CM_NOTIFY_FILTER_TYPE_DEVICEHANDLE */

            /// <summary>
            /// <para>
            /// This action indicates that the device is being query removed. In order to allow the query remove to succeed, call CloseHandle to close any handles
            /// you have open to the device. If you do not do this, your open handle prevents the query remove of this device from succeeding.
            /// </para>
            /// <para>
            /// To veto the query remove, return ERROR_CANCELLED. However, it is recommended that you do not veto the query remove and allow
            /// it to happen by closing any handles you have open to the device.
            /// </para>
            /// </summary>
            /// <remarks>
            /// For this value, set  <see cref="CM_NOTIFY_FILTER.FilterType"/> to <see cref="CM_NOTIFY_FILTER_TYPE.CM_NOTIFY_FILTER_TYPE_DEVICEHANDLE"/>.
            /// </remarks>
            CM_NOTIFY_ACTION_DEVICEQUERYREMOVE,

            /// <summary>
            /// This action indicates that the query remove of a device was failed. If you closed the handle to this device during a previous notification of
            /// <see cref="CM_NOTIFY_ACTION.CM_NOTIFY_ACTION_DEVICEQUERYREMOVE"/>, open a new handle to the device to continue sending I/O requests to it.
            /// </summary>
            /// <remarks>
            /// For this value, set  <see cref="CM_NOTIFY_FILTER.FilterType"/> to <see cref="CM_NOTIFY_FILTER_TYPE.CM_NOTIFY_FILTER_TYPE_DEVICEHANDLE"/>.
            /// </remarks>
            CM_NOTIFY_ACTION_DEVICEQUERYREMOVEFAILED,

            /// <summary>
            /// <para>
            /// The device will be removed. If you still have an open handle to the device, call CloseHandle to close the device handle.
            /// </para>
            /// <para>
            /// The system may send a <see cref="CM_NOTIFY_ACTION.CM_NOTIFY_ACTION_DEVICEREMOVEPENDING"/> notification without sending
            /// a corresponding <see cref="CM_NOTIFY_ACTION.CM_NOTIFY_ACTION_DEVICEQUERYREMOVE"/> message.
            /// In such cases, the applications and drivers must recover from the loss of the device as best they can.
            /// </para>
            /// </summary>
            /// <remarks>
            /// For this value, set  <see cref="CM_NOTIFY_FILTER.FilterType"/> to <see cref="CM_NOTIFY_FILTER_TYPE.CM_NOTIFY_FILTER_TYPE_DEVICEHANDLE"/>.
            /// </remarks>
            CM_NOTIFY_ACTION_DEVICEREMOVEPENDING,

            /// <summary>
            /// <para>
            /// The device has been removed. If you still have an open handle to the device, call CloseHandle to close the device handle.
            /// </para>
            /// <para>
            /// The system may send a <see cref="CM_NOTIFY_ACTION.CM_NOTIFY_ACTION_DEVICEREMOVECOMPLETE"/> notification without sending
            /// corresponding <see cref="CM_NOTIFY_ACTION.CM_NOTIFY_ACTION_DEVICEQUERYREMOVE"/> or <see cref="CM_NOTIFY_ACTION.CM_NOTIFY_ACTION_DEVICEREMOVEPENDING"/>
            /// messages. In such cases, the applications and drivers must recover from the loss of the device as best they can.
            /// </para>
            /// </summary>
            /// <remarks>
            /// For this value, set <see cref="CM_NOTIFY_FILTER.FilterType"/> to <see cref="CM_NOTIFY_FILTER_TYPE.CM_NOTIFY_FILTER_TYPE_DEVICEHANDLE"/>.
            /// </remarks>
            CM_NOTIFY_ACTION_DEVICEREMOVECOMPLETE,

            /// <summary>
            /// This action is sent when a driver-defined custom event has occurred.
            /// </summary>
            /// <remarks>
            /// For this value, set <see cref="CM_NOTIFY_FILTER.FilterType"/> to <see cref="CM_NOTIFY_FILTER_TYPE.CM_NOTIFY_FILTER_TYPE_DEVICEHANDLE"/>.
            /// </remarks>
            CM_NOTIFY_ACTION_DEVICECUSTOMEVENT,

            /* Filter type: CM_NOTIFY_FILTER_TYPE_DEVICEINSTANCE */

            /// <summary>
            /// This action is sent when a new device instance that meets your filter criteria has been enumerated.
            /// </summary>
            /// <remarks>
            /// For this value, set <see cref="CM_NOTIFY_FILTER.FilterType"/> to <see cref="CM_NOTIFY_FILTER_TYPE.CM_NOTIFY_FILTER_TYPE_DEVICEINSTANCE"/>.
            /// </remarks>
            CM_NOTIFY_ACTION_DEVICEINSTANCEENUMERATED,

            /// <summary>
            /// This action is sent when a device instance that meets your filter criteria becomes started.
            /// </summary>
            /// <remarks>
            /// For this value, set <see cref="CM_NOTIFY_FILTER.FilterType"/> to <see cref="CM_NOTIFY_FILTER_TYPE.CM_NOTIFY_FILTER_TYPE_DEVICEINSTANCE"/>.
            /// </remarks>
            CM_NOTIFY_ACTION_DEVICEINSTANCESTARTED,

            /// <summary>
            /// This action is sent when a device instance that meets your filter criteria is no longer present.
            /// </summary>
            /// <remarks>
            /// For this value, set <see cref="CM_NOTIFY_FILTER.FilterType"/> to <see cref="CM_NOTIFY_FILTER_TYPE.CM_NOTIFY_FILTER_TYPE_DEVICEINSTANCE"/>.
            /// </remarks>
            CM_NOTIFY_ACTION_DEVICEINSTANCEREMOVED,

            /// <summary>
            /// Do not use.
            /// </summary>
            CM_NOTIFY_ACTION_MAX,
        }
    }
}
