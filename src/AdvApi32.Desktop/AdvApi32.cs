// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Runtime.InteropServices;
    using System.Security.AccessControl;
    using Microsoft.Win32.SafeHandles;
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
        /// It returns the same information <see cref="EnumServicesStatus(SafeServiceHandle,ServiceType,ServiceStateQuery,byte*,int,ref int,ref int,ref int)"/> returns, plus the process identifier and additional information for the service.
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
        public static unsafe extern bool EnumServicesStatus(
            SafeServiceHandle hSCManager,
            ServiceType dwServiceType,
            ServiceStateQuery dwServiceState,
            byte* lpServices,
            int cbBufSize,
            ref int pcbBytesNeeded,
            ref int lpServicesReturned,
            ref int lpResumeHandle);

        /// <summary>
        /// Converts an NTSTATUS code returned by an LSA function to a Windows error code.
        /// </summary>
        /// <param name="Status">An NTSTATUS code returned by an LSA function call. This value will be converted to a System error code.</param>
        /// <returns>
        /// The return value is the Windows error code that corresponds to the Status parameter. If there is no corresponding Windows error code, the return value is <see cref="Win32ErrorCode.ERROR_MR_MID_NOT_FOUND"/>.
        /// </returns>
        [DllImport(nameof(AdvApi32))]
        public static extern Win32ErrorCode LsaNtStatusToWinError(NTSTATUS Status);

        /// <summary>
        ///     Opens the specified registry key. Note that key names are not case sensitive.
        ///     <para>To perform transacted registry operations on a key, call the RegOpenKeyTransacted function.</para>
        /// </summary>
        /// <param name="hKey">
        ///     A handle to an open registry key.
        ///     <para>
        ///         This handle is returned by the RegCreateKeyEx, RegCreateKeyTransacted, <see cref="RegOpenKeyEx" />, or
        ///         RegOpenKeyTransacted function. It can also be one of the following predefined keys:
        ///         <see cref="HKEY_CLASSES_ROOT" />,
        ///         <see cref="HKEY_CURRENT_CONFIG" />,
        ///         <see cref="HKEY_CURRENT_USER" />,
        ///         <see cref="HKEY_LOCAL_MACHINE" />,
        ///         <see cref="HKEY_PERFORMANCE_DATA" /> and
        ///         <see cref="HKEY_USERS" />
        ///     </para>
        /// </param>
        /// <param name="lpSubKey">
        ///     The name of the registry subkey to be opened.
        ///     <para>Key names are not case sensitive.</para>
        ///     <para>
        ///         The lpSubKey parameter can be an empty string. If lpSubKey is a pointer to an empty string and
        ///         <paramref name="hKey" /> is <see cref="HKEY_CLASSES_ROOT" />, <paramref name="phkResult" /> receives the same
        ///         <paramref name="hKey" /> handle passed into the function. Otherwise, <paramref name="phkResult" /> receives a
        ///         new handle to the key specified by <paramref name="hKey" />.
        ///     </para>
        ///     <para>
        ///         The lpSubKey parameter can be <c>null</c> only if hKey is one of the predefined keys. If lpSubKey is
        ///         <c>null</c> and hKey is <see cref="HKEY_CLASSES_ROOT" />, <paramref name="phkResult" /> receives a new handle
        ///         to the key specified by <paramref name="hKey" />. Otherwise, <paramref name="phkResult" /> receives the same
        ///         <paramref name="hKey" /> handle passed in to the function.
        ///     </para>
        /// </param>
        /// <param name="ulOptions">Specifies the option to apply when opening the key.</param>
        /// <param name="samDesired">
        ///     A mask that specifies the desired access rights to the key to be opened. The function fails if
        ///     the security descriptor of the key does not permit the requested access for the calling process.
        /// </param>
        /// <param name="phkResult">
        ///     A variable that receives a handle to the opened key. If the key is not one of the predefined
        ///     registry keys, it should be disposed after you have finished using the handle.
        /// </param>
        /// <returns>
        ///     If the function succeeds, the return value is <see cref="Win32ErrorCode.ERROR_SUCCESS" />. If the function
        ///     fails the error code is returned.
        /// </returns>
        [DllImport(nameof(AdvApi32), CharSet = CharSet.Unicode)]
        public static extern Win32ErrorCode RegOpenKeyEx(
            SafeRegistryHandle hKey,
            string lpSubKey,
            RegOpenKeyOptions ulOptions,
            ACCESS_MASK samDesired,
            out SafeRegistryHandle phkResult);

        /// <summary>Writes all the attributes of the specified open registry key into the registry.</summary>
        /// <param name="hKey">
        ///     A handle to an open registry key. The key must have been opened with the <see cref="KEY_QUERY_VALUE" /> access
        ///     right.
        ///     <para>
        ///         This handle is returned by the RegCreateKeyEx, RegCreateKeyTransacted, <see cref="RegOpenKeyEx" />, or
        ///         RegOpenKeyTransacted function. It can also be one of the following predefined keys:
        ///         <see cref="HKEY_CLASSES_ROOT" />,
        ///         <see cref="HKEY_CURRENT_CONFIG" />,
        ///         <see cref="HKEY_CURRENT_USER" />,
        ///         <see cref="HKEY_LOCAL_MACHINE" />,
        ///         <see cref="HKEY_PERFORMANCE_DATA" /> and
        ///         <see cref="HKEY_USERS" />
        ///     </para>
        /// </param>
        /// <returns>
        ///     If the function succeeds, the return value is <see cref="Win32ErrorCode.ERROR_SUCCESS" />. If the function
        ///     fails the error code is returned.
        /// </returns>
        [DllImport(nameof(AdvApi32))]
        public static extern Win32ErrorCode RegFlushKey(SafeRegistryHandle hKey);

        /// <summary>Notifies the caller about changes to the attributes or contents of a specified registry key.</summary>
        /// <param name="hKey">
        ///     A handle to an open registry key.
        ///     <para>
        ///         This handle is returned by the RegCreateKeyEx, RegCreateKeyTransacted, <see cref="RegOpenKeyEx" />, or
        ///         RegOpenKeyTransacted function. It can also be one of the following predefined keys:
        ///         <see cref="HKEY_CLASSES_ROOT" />,
        ///         <see cref="HKEY_CURRENT_CONFIG" />,
        ///         <see cref="HKEY_CURRENT_USER" />,
        ///         <see cref="HKEY_LOCAL_MACHINE" />,
        ///         <see cref="HKEY_PERFORMANCE_DATA" /> and
        ///         <see cref="HKEY_USERS" />
        ///     </para>
        ///     <para>
        ///         This parameter must be a local handle. If <see cref="RegNotifyChangeKeyValue" /> is called with a remote
        ///         handle, it returns <see cref="Win32ErrorCode.ERROR_INVALID_HANDLE" />.
        ///     </para>
        ///     <para>The key must have been opened with the <see cref="KEY_NOTIFY" /> access right.</para>
        /// </param>
        /// <param name="bWatchSubtree">
        ///     If this parameter is <c>true</c>, the function reports changes in the specified key and its
        ///     subkeys. If the parameter is <c>false</c>, the function reports changes only in the specified key.
        /// </param>
        /// <param name="dwNotifyFilter">A value that indicates the changes that should be reported.</param>
        /// <param name="hEvent">
        ///     A handle to an event. If the <paramref name="fAsynchronous" /> parameter is <c>true</c>, the
        ///     function returns immediately and changes are reported by signaling this event. If <paramref name="fAsynchronous" />
        ///     is <c>false</c>, hEvent is ignored.
        /// </param>
        /// <param name="fAsynchronous">
        ///     If this parameter is <c>true</c>, the function returns immediately and reports changes by
        ///     signaling the specified event. If this parameter is <c>false</c>, the function does not return until a change has
        ///     occurred.
        ///     <para>
        ///         If <paramref name="hEvent" /> does not specify a valid event, the fAsynchronous parameter cannot be
        ///         <c>true</c>.
        ///     </para>
        /// </param>
        /// <returns>
        ///     If the function succeeds, the return value is <see cref="Win32ErrorCode.ERROR_SUCCESS" />. If the function
        ///     fails the error code is returned.
        /// </returns>
        [DllImport(nameof(AdvApi32))]
        public static extern Win32ErrorCode RegNotifyChangeKeyValue(
            SafeRegistryHandle hKey,
            bool bWatchSubtree,
            RegNotifyFilter dwNotifyFilter,
            SafeWaitHandle hEvent,
            bool fAsynchronous);
    }
}
