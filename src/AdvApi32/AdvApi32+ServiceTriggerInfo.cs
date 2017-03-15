// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Runtime.InteropServices;

    /// <content>
    /// Contains the <see cref="ServiceTriggerInfo"/> nested type.
    /// </content>
    public static partial class AdvApi32
    {
        /// <summary>
        /// Contains trigger event information for a service. This structure is used by the <see cref="ChangeServiceConfig2(SafeServiceHandle, ServiceInfoLevel, void*)"/> and QueryServiceConfig2 functions.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct ServiceTriggerInfo
        {
            /// <summary>
            /// The number of triggers in the array of SERVICE_TRIGGER structures pointed to by the pTriggers member.
            /// If this member is 0 in a SERVICE_TRIGGER_INFO structure passed to ChangeServiceConfig2, all previously configured triggers are removed from the service.If the service has no triggers configured, ChangeServiceConfig2 fails with ERROR_INVALID_PARAMETER.
            /// </summary>
            public int cTriggers;

            /// <summary>
            /// A pointer to an array of <see cref="ServiceTrigger"/> structures that specify the trigger events for the service.
            /// If the cTriggers member is 0, this member is not used.
            /// </summary>
            public ServiceTrigger[] pTriggers;

            /// <summary>
            /// This member is reserved and must be NULL.
            /// </summary>
            public IntPtr pReserved;
        }
    }
}
