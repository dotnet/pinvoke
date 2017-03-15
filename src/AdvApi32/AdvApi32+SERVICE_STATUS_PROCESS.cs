// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System.Runtime.InteropServices;

    /// <content>
    /// Contains the <see cref="SERVICE_STATUS_PROCESS"/> nested type.
    /// </content>
    public partial class AdvApi32
    {
        /// <summary>
        /// Contains status information for a service.
        /// The ControlService, EnumDependentServices, EnumServicesStatus, and QueryServiceStatus functions use this structure.
        /// A service uses this structure in the <see cref="SetServiceStatus"/> function to report its current status to the service control manager.
        /// </summary>
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        public struct SERVICE_STATUS_PROCESS
        {
            /// <summary>
            /// The type of service. <see cref="ServiceType"/>
            /// </summary>
            public ServiceType dwServiceType;

            /// <summary>
            /// The current state of the service.
            /// </summary>
            public ServiceState dwCurrentState;

            /// <summary>
            /// The control codes the service accepts and processes in its handler function (see Handler and HandlerEx).
            /// A user interface process can control a service by specifying a control command in the <see cref="ControlService"/> or ControlServiceEx function.
            /// By default, all services accept the <see cref="ServiceControl.SERVICE_CONTROL_INTERROGATE"/> value.
            /// To accept the <see cref="ServiceControl.SERVICE_CONTROL_DEVICEEVENT"/> value, the service must register to receive device events by using the RegisterDeviceNotification function.
            /// </summary>
            public int dwControlsAccepted;

            /// <summary>
            /// The error code the service uses to report an error that occurs when it is starting or stopping.
            /// To return an error code specific to the service, the service must set this value to <see cref="Win32ErrorCode.ERROR_SERVICE_SPECIFIC_ERROR"/> to indicate that the <see cref="dwServiceSpecificExitCode"/> member contains the error code.
            /// The service should set this value to NO_ERROR when it is running and on normal termination.
            /// </summary>
            public int dwWin32ExitCode;

            /// <summary>
            /// A service-specific error code that the service returns when an error occurs while the service is starting or stopping.
            /// This value is ignored unless the <see cref="dwWin32ExitCode"/> member is set to <see cref="Win32ErrorCode.ERROR_SERVICE_SPECIFIC_ERROR"/>.
            /// </summary>
            public int dwServiceSpecificExitCode;

            /// <summary>
            /// The check-point value the service increments periodically to report its progress during a lengthy start, stop, pause, or continue operation.
            /// For example, the service should increment this value as it completes each step of its initialization when it is starting up.
            /// The user interface program that invoked the operation on the service uses this value to track the progress of the service during a lengthy operation.
            /// This value is not valid and should be zero when the service does not have a start, stop, pause, or continue operation pending.
            /// </summary>
            public int dwCheckPoint;

            /// <summary>
            /// The estimated time required for a pending start, stop, pause, or continue operation, in milliseconds.
            /// Before the specified amount of time has elapsed, the service should make its next call to the <see cref="SetServiceStatus"/> function with either an incremented <see cref="dwCheckPoint"/> value or a change in dwCurrentState.
            /// If the amount of time specified by <see cref="dwWaitHint"/> passes, and <see cref="dwCheckPoint"/> has not been incremented or <see cref="dwCurrentState"/> has not changed,
            /// the service control manager or service control program can assume that an error has occurred and the service should be stopped.
            /// However, if the service shares a process with other services, the service control manager cannot terminate the service application because it would have to terminate the other services sharing the process as well.
            /// </summary>
            public int dwWaitHint;

            /// <summary>
            /// The process identifier of the service.
            /// </summary>
            public int dwProcessId;

            /// <summary>
            /// Flags describing the service process.
            /// </summary>
            public SERVICE_STATUS_PROCESS_Flags dwServiceFlags;
        }
    }
}
