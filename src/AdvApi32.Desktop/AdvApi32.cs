// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Runtime.InteropServices;
    using System.Security.AccessControl;
    using static Kernel32;

    /// <content>
    /// Exported functions from the AdvApi32.dll Windows library
    /// that are available to Desktop apps only.
    /// </content>
    public static partial class AdvApi32
    {
        /// <summary>
        /// Enumerates services in the specified service control manager database.
        /// The name and status of each service are provided.
        /// This function has been superseded by the EnumServicesStatusEx function.
        /// It returns the same information <see cref="EnumServicesStatus(SafeServiceHandle,ServiceType,ServiceStateQuery,IntPtr,int,ref int,ref int,ref int)"/> returns, plus the process identifier and additional information for the service.
        /// In addition, EnumServicesStatusEx enables you to enumerate services that belong to a specified group.
        /// </summary>
        /// <param name="hSCManager">
        /// A handle to the service control manager database.
        /// This handle is returned by the <see cref="OpenSCManager"/> function, and must have the <see cref="ServiceManagerAccess.SC_MANAGER_ENUMERATE_SERVICE"/> access right.
        /// </param>
        /// <param name="dwServiceType">
        /// The type of services to be enumerated.
        /// This parameter can be one or more of the following values.
        /// <list type="bullet">
        /// <item>
        /// <see cref="ServiceType.SERVICE_DRIVER"/>
        /// </item>
        /// <item>
        /// <see cref="ServiceType.SERVICE_FILE_SYSTEM_DRIVER"/>
        /// </item>
        /// <item>
        /// <see cref="ServiceType.SERVICE_KERNEL_DRIVER"/>
        /// </item>
        /// <item>
        /// <see cref="ServiceType.SERVICE_WIN32"/>
        /// </item>
        /// <item>
        /// <see cref="ServiceType.SERVICE_WIN32_OWN_PROCESS"/>
        /// </item>
        /// <item>
        /// <see cref="ServiceType.SERVICE_WIN32_SHARE_PROCESS"/>
        /// </item>
        /// </list>
        /// </param>
        /// <param name="dwServiceState">
        /// The state of the services to be enumerated.
        /// This parameter can be one of the following values.
        /// <list type="bullet">
        /// <item>
        /// <see cref="ServiceStateQuery.SERVICE_ACTIVE"/>
        /// </item>
        /// <item>
        /// <see cref="ServiceStateQuery.SERVICE_INACTIVE"/>
        /// </item>
        /// <item>
        /// <see cref="ServiceStateQuery.SERVICE_STATE_ALL"/>
        /// </item>
        /// </list>
        /// </param>
        /// <param name="lpServices">
        /// A pointer to a buffer that contains an array of <see cref="ENUM_SERVICE_STATUS"/> structures that receive the name and service status information for each service in the database.
        /// The buffer must be large enough to hold the structures, plus the strings to which their members point.
        /// The maximum size of this array is 256K bytes.
        /// To determine the required size, specify NULL for this parameter and 0 for the <paramref name="cbBufSize" /> parameter.
        /// The function will fail and <see cref="GetLastError"/> will return <see cref="Win32ErrorCode.ERROR_INSUFFICIENT_BUFFER"/>.
        /// The <paramref name="pcbBytesNeeded"/> parameter will receive the required size.
        /// Windows Server 2003 and Windows XP:  The maximum size of this array is 64K bytes.
        /// This limit was increased as of Windows Server 2003 with SP1 and Windows XP with SP2.
        /// </param>
        /// <param name="cbBufSize">
        /// The size of the buffer pointed to by the <paramref name="lpServices"/> parameter, in bytes.
        /// </param>
        /// <param name="pcbBytesNeeded">
        /// A pointer to a variable that receives the number of bytes needed to return the remaining service entries, if the buffer is too small.
        /// </param>
        /// <param name="lpServicesReturned">
        /// A pointer to a variable that receives the number of service entries returned.
        /// </param>
        /// <param name="lpResumeHandle">
        /// A pointer to a variable that, on input, specifies the starting point of enumeration.
        /// You must set this value to zero the first time this function is called. On output, this value is zero if the function succeeds.
        /// However, if the function returns zero and the <see cref="GetLastError"/> function returns <see cref="Win32ErrorCode.ERROR_MORE_DATA"/>,
        /// this value is used to indicate the next service entry to be read when the function is called to retrieve the additional data.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is nonzero.
        /// If the function fails, the return value is zero. To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        [DllImport(nameof(AdvApi32), SetLastError = true, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool EnumServicesStatus(
            SafeServiceHandle hSCManager,
            ServiceType dwServiceType,
            ServiceStateQuery dwServiceState,
            IntPtr lpServices,
            int cbBufSize,
            ref int pcbBytesNeeded,
            ref int lpServicesReturned,
            ref int lpResumeHandle);
    }
}
