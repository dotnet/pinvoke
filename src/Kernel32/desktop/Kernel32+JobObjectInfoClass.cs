// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    /// <content>
    /// Contains the <see cref="JOBOBJECT_INFO_CLASS"/> nested type.
    /// </content>
    public partial class Kernel32
    {
        /// <summary>
        /// The information class for the limits to be set.
        /// </summary>
        /// <remarks>
        /// Taken from https://msdn.microsoft.com/en-us/library/windows/desktop/ms686216(v=vs.85).aspx
        /// </remarks>
        public enum JOBOBJECT_INFO_CLASS
        {
            /// <summary>
            /// The lpJobObjectInfo parameter is a pointer to a JOBOBJECT_BASIC_LIMIT_INFORMATION structure.
            /// </summary>
            JobObjectBasicLimitInformation = 2,

            /// <summary>
            /// The lpJobObjectInfo parameter is a pointer to a JOBOBJECT_BASIC_UI_RESTRICTIONS structure.
            /// </summary>
            JobObjectBasicUIRestrictions = 4,

            /// <summary>
            /// This flag is not supported. Applications must set security limitations individually for each process.
            /// </summary>
            JobObjectSecurityLimitInformation = 5,

            /// <summary>
            /// The lpJobObjectInfo parameter is a pointer to a JOBOBJECT_END_OF_JOB_TIME_INFORMATION structure.
            /// </summary>
            JobObjectEndOfJobTimeInformation = 6,

            /// <summary>
            /// The lpJobObjectInfo parameter is a pointer to a JOBOBJECT_ASSOCIATE_COMPLETION_PORT structure.
            /// </summary>
            JobObjectAssociateCompletionPortInformation = 7,

            /// <summary>
            /// The lpJobObjectInfo parameter is a pointer to a JOBOBJECT_EXTENDED_LIMIT_INFORMATION structure.
            /// </summary>
            JobObjectExtendedLimitInformation = 9,

            /// <summary>
            /// The lpJobObjectInfo parameter is a pointer to a USHORT value that specifies the list of processor groups to assign the job to.
            /// The cbJobObjectInfoLength parameter is set to the size of the group data. Divide this value by sizeof(USHORT) to determine the number of groups.
            /// </summary>
            JobObjectGroupInformation = 11,

            /// <summary>
            /// The lpJobObjectInfo parameter is a pointer to a JOBOBJECT_NOTIFICATION_LIMIT_INFORMATION structure.
            /// </summary>
            JobObjectNotificationLimitInformation = 12,

            /// <summary>
            /// The lpJobObjectInfo parameter is a pointer to a buffer that contains an array of GROUP_AFFINITY structures that specify the affinity of the job for the processor groups to which the job is currently assigned.
            /// The cbJobObjectInfoLength parameter is set to the size of the group affinity data. Divide this value by sizeof(GROUP_AFFINITY) to determine the number of groups.
            /// </summary>
            JobObjectGroupInformationEx = 14,

            /// <summary>
            /// The lpJobObjectInfo parameter is a pointer to a JOBOBJECT_CPU_RATE_CONTROL_INFORMATION structure.
            /// </summary>
            JobObjectCpuRateControlInformation = 15,

            /// <summary>
            /// The lpJobObjectInfo parameter is a pointer to a JOBOBJECT_NET_RATE_CONTROL_INFORMATION structure.
            /// </summary>
            JobObjectNetRateControlInformation = 32,

            /// <summary>
            /// The lpJobObjectInfo parameter is a pointer to a JOBOBJECT_NOTIFICATION_LIMIT_INFORMATION_2 structure.
            /// </summary>
            JobObjectNotificationLimitInformation2 = 34,

            /// <summary>
            /// The lpJobObjectInfo parameter is a pointer to a JOBOBJECT_LIMIT_VIOLATION_INFORMATION_2 structure.
            /// </summary>
            JobObjectLimitViolationInformation2 = 35
        }
    }
}