// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    /// <content>
    /// Contains the <see cref="ServiceControl"/> nested type.
    /// </content>
    public static partial class AdvApi32
    {
        /// <summary>
        ///  Represents a control code that can be sent to a service <see cref="AdvApi32.ControlService"/>.
        /// </summary>
        public enum ServiceControl
        {
            /// <summary>
            /// Notifies a service that it should stop. The hService handle must have the <see cref="ServiceAccess.SERVICE_STOP"/> access right.
            /// After sending the stop request to a service, you should not send other controls to the service.
            /// </summary>
            SERVICE_CONTROL_STOP = 0x00000001,

            /// <summary>
            /// Notifies a service that it should pause. The hService handle must have the <see cref="ServiceAccess.SERVICE_PAUSE_CONTINUE"/> access right.
            /// </summary>
            SERVICE_CONTROL_PAUSE = 0x00000002,

            /// <summary>
            /// Notifies a paused service that it should resume. The hService handle must have the <see cref="ServiceAccess.SERVICE_PAUSE_CONTINUE"/> access right.
            /// </summary>
            SERVICE_CONTROL_CONTINUE = 0x00000003,

            /// <summary>
            /// Notifies a service that it should report its current status information to the service control manager.
            /// The hService handle must have the <see cref="ServiceAccess.SERVICE_INTERROGATE"/> access right.
            /// Note that this control is not generally useful as the SCM is aware of the current state of the service.
            /// </summary>
            SERVICE_CONTROL_INTERROGATE = 0x00000004,

            /// <summary>
            /// Notifies a service that the system is shutting down so the service can perform cleanup tasks.
            /// Note that services that register for <see cref="ServiceControl.SERVICE_CONTROL_PRESHUTDOWN"/> notifications cannot receive this notification because they have already stopped.
            /// If a service accepts this control code, it must stop after it performs its cleanup tasks and return NO_ERROR.
            /// After the SCM sends this control code, it will not send other control codes to the service.
            /// </summary>
            SERVICE_CONTROL_SHUTDOWN = 0x00000005,

            /// <summary>
            /// Notifies a service that its startup parameters have changed. The hService handle must have the <see cref="ServiceAccess.SERVICE_PAUSE_CONTINUE"/> access right.
            /// </summary>
            SERVICE_CONTROL_PARAMCHANGE = 0x00000006,

            /// <summary>
            /// Notifies a network service that there is a new component for binding.
            /// The hService handle must have the <see cref="ServiceAccess.SERVICE_PAUSE_CONTINUE"/> access right.
            /// However, this control code has been deprecated; use Plug and Play functionality instead.
            /// </summary>
            SERVICE_CONTROL_NETBINDADD = 0x00000007,

            /// <summary>
            /// Notifies a network service that a component for binding has been removed.
            /// The hService handle must have the <see cref="ServiceAccess.SERVICE_PAUSE_CONTINUE"/> access right.
            /// However, this control code has been deprecated; use Plug and Play functionality instead.
            /// </summary>
            SERVICE_CONTROL_NETBINDREMOVE = 0x00000008,

            /// <summary>
            /// Notifies a network service that a disabled binding has been enabled.
            /// The hService handle must have the <see cref="ServiceAccess.SERVICE_PAUSE_CONTINUE"/> access right.
            /// However, this control code has been deprecated; use Plug and Play functionality instead.
            /// </summary>
            SERVICE_CONTROL_NETBINDENABLE = 0x00000009,

            /// <summary>
            /// Notifies a network service that one of its bindings has been disabled.
            /// The hService handle must have the <see cref="ServiceAccess.SERVICE_PAUSE_CONTINUE"/> access right.
            /// However, this control code has been deprecated; use Plug and Play functionality instead.
            /// </summary>
            SERVICE_CONTROL_NETBINDDISABLE = 0x0000000A,

            /// <summary>
            /// Notifies a service of device events.
            /// (The service must have registered to receive these notifications using the RegisterDeviceNotification function.)
            /// The dwEventType and lpEventData parameters contain additional information.
            /// </summary>
            SERVICE_CONTROL_DEVICEEVENT = 0x0000000B,

            /// <summary>
            /// Notifies a service that the computer's hardware profile has changed.
            /// The dwEventType parameter contains additional information.
            /// </summary>
            SERVICE_CONTROL_HARDWAREPROFILECHANGE = 0x0000000C,

            /// <summary>
            /// Notifies a service of system power events. The dwEventType parameter contains additional information.
            /// If dwEventType is PBT_POWERSETTINGCHANGE, the lpEventData parameter also contains additional information.
            /// </summary>
            SERVICE_CONTROL_POWEREVENT = 0x0000000D,

            /// <summary>
            /// Notifies a service of session change events.
            /// Note that a service will only be notified of a user logon if it is fully loaded before the logon attempt is made.
            /// The dwEventType and lpEventData parameters contain additional information.
            /// </summary>
            SERVICE_CONTROL_SESSIONCHANGE = 0x0000000E,

            /// <summary>
            /// Notifies a service that the system will be shutting down.
            /// Services that need additional time to perform cleanup tasks beyond the tight time restriction at system shutdown can use this notification.
            /// The service control manager sends this notification to applications that have registered for it before sending a <see cref="SERVICE_CONTROL_SHUTDOWN"/> notification to applications that have registered for that notification.
            /// A service that handles this notification blocks system shutdown until the service stops or the preshutdown time-out interval specified through SERVICE_PRESHUTDOWN_INFO expires.
            /// Because this affects the user experience, services should use this feature only if it is absolutely necessary to avoid data loss or significant recovery time at the next system start.
            /// </summary>
            SERVICE_CONTROL_PRESHUTDOWN = 0x0000000F
        }
    }
}