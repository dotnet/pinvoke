// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Runtime.InteropServices;
    using Microsoft.Win32.SafeHandles;
    using static Kernel32;

    /// <content>
    /// Exported functions from the AdvApi32.dll Windows library
    /// that are available to Desktop apps only.
    /// </content>
    [OfferFriendlyOverloads]
    public static partial class AdvApi32
    {
        /// <summary>
        /// Used to prefix group names so that they can be distinguished from a service name,
        /// because services and service groups share the same name space.
        /// </summary>
        public const string SC_GROUP_IDENTIFIER = "+";
        public const uint SERVICE_NO_CHANGE = 0xFFFFFFFF;

#pragma warning disable SA1303 // Const field names must begin with upper-case letter
#if APISets
        private const string api_ms_win_service_core_l1_1_1 = ApiSets.api_ms_win_service_core_l1_1_1;
        private const string api_ms_win_service_management_l1_1_0 = ApiSets.api_ms_win_service_management_l1_1_0;
        private const string api_ms_win_service_management_l2_1_0 = ApiSets.api_ms_win_service_management_l2_1_0;
        private const string api_ms_win_core_processthreads_l1_1_1 = ApiSets.api_ms_win_core_processthreads_l1_1_1;
        private const string api_ms_win_security_base_l1_2_0 = ApiSets.api_ms_win_security_base_l1_2_0;
        private const string api_ms_win_service_winsvc_l1_2_0 = ApiSets.api_ms_win_service_winsvc_l1_2_0;
#else
        private const string api_ms_win_service_core_l1_1_1 = nameof(AdvApi32);
        private const string api_ms_win_service_management_l1_1_0 = nameof(AdvApi32);
        private const string api_ms_win_service_management_l2_1_0 = nameof(AdvApi32);
        private const string api_ms_win_core_processthreads_l1_1_1 = nameof(AdvApi32);
        private const string api_ms_win_security_base_l1_2_0 = nameof(AdvApi32);
        private const string api_ms_win_service_winsvc_l1_2_0 = nameof(AdvApi32);
#endif
#pragma warning restore SA1303 // Const field names must begin with upper-case letter

        /// <summary>
        /// An application-defined callback function used with the <see cref="RegisterServiceCtrlHandler"/> function.
        /// A service program can use it as the control handler function of a particular service.
        /// </summary>
        /// <param name="dwControl">The control code.</param>
        /// <remarks>
        /// <para>
        /// This function has been superseded by the HandlerEx control handler function used with the <see cref="RegisterServiceCtrlHandlerEx(string, LPHANDLER_FUNCTION_EX, void*)"/> function.
        /// A service can use either control handler, but the new control handler supports user-defined context data and additional extended control codes.
        /// </para>
        /// <para>
        /// <paramref name="dwControl" /> with values in the 128 to 255 range is meant to be used by programmers.
        /// This range is meant to hold user-defined control codes to send actions to the service.
        /// </para>
        /// </remarks>
        [Obsolete("Use LPHANDLER_FUNCTION_EX with RegisterServiceCtrlHandlerEx instead")]
        public delegate void LPHANDLER_FUNCTION(ServiceControl dwControl);

        /// <summary>
        /// An application-defined callback function used with the <see cref="RegisterServiceCtrlHandlerEx(string, LPHANDLER_FUNCTION_EX, void*)"/> function.
        /// A service program can use it as the control handler function of a particular service.
        /// </summary>
        /// <param name="dwControl">The control code.</param>
        /// <param name="dwEventType">The type of event that has occurred. It should be a Window Message code.</param>
        /// <param name="lpEventData">Additional device information, if required. The format of this data depends on the value of the <paramref name="dwControl"/> and <paramref name="dwEventType"/> parameters.</param>
        /// <param name="lpContext">User-defined data passed from <see cref="RegisterServiceCtrlHandlerEx(string, LPHANDLER_FUNCTION_EX, void*)"/>. When multiple services share a process, the lpContext parameter can help identify the service.</param>
        /// <returns>
        /// The return value for this function depends on the control code received:
        /// <list>
        /// <item>In general, if your service does not handle the control, return ERROR_CALL_NOT_IMPLEMENTED. However, your service should return <see cref="Win32ErrorCode.ERROR_SUCCESS"/> for SERVICE_CONTROL_INTERROGATE even if your service does not handle it.</item>
        /// <item>If your service handles SERVICE_CONTROL_STOP or SERVICE_CONTROL_SHUTDOWN, return <see cref="Win32ErrorCode.ERROR_SUCCESS"/>.</item>
        /// <item>If your service handles SERVICE_CONTROL_DEVICEEVENT, return <see cref="Win32ErrorCode.ERROR_SUCCESS"/> to grant the request and an error code to deny the request.</item>
        /// <item>If your service handles SERVICE_CONTROL_HARDWAREPROFILECHANGE, return <see cref="Win32ErrorCode.ERROR_SUCCESS"/> to grant the request and an error code to deny the request.</item>
        /// <item>If your service handles SERVICE_CONTROL_POWEREVENT, return <see cref="Win32ErrorCode.ERROR_SUCCESS"/> to grant the request and an error code to deny the request.</item>
        /// <item>For all other control codes your service handles, return <see cref="Win32ErrorCode.ERROR_SUCCESS"/>.</item>
        /// </list>
        /// </returns>
        /// <remarks>
        /// <para>
        /// <paramref name="dwControl" /> with values in the 128 to 255 range is meant to be used by programmers.
        /// This range is meant to hold user-defined control codes to send actions to the service.
        /// </para>
        /// </remarks>
        public delegate Win32ErrorCode LPHANDLER_FUNCTION_EX(ServiceControl dwControl, uint dwEventType, IntPtr lpEventData, IntPtr lpContext);

        /// <summary>
        /// Changes the configuration parameters of a service.
        /// To change the optional configuration parameters, use the <see cref="ChangeServiceConfig2(SafeServiceHandle, ServiceInfoLevel, void*)"/> function.
        /// </summary>
        /// <param name="hService">
        /// A handle to the service.
        /// This handle is returned by the <see cref="OpenService"/> or <see cref="CreateService(SafeServiceHandle,string,string,ACCESS_MASK,ServiceType,ServiceStartType,ServiceErrorControl,string,string,int, string,string,string)"/> function and
        /// must have the <see cref="ServiceAccess.SERVICE_CHANGE_CONFIG"/> access right.
        /// </param>
        /// <param name="dwServiceType">
        /// The type of service. Specify <see cref="SERVICE_NO_CHANGE"/> if you are not changing the existing service type;
        /// otherwise, specify one of the following service types.
        /// <list type="bullet">
        /// <item>
        /// <see cref="ServiceType.SERVICE_FILE_SYSTEM_DRIVER"/>
        /// </item>
        /// <item>
        /// <see cref="ServiceType.SERVICE_KERNEL_DRIVER"/>
        /// </item>
        /// <item>
        /// <see cref="ServiceType.SERVICE_WIN32_OWN_PROCESS"/>
        /// </item>
        /// <item>
        /// <see cref="ServiceType.SERVICE_WIN32_SHARE_PROCESS"/>
        /// </item>
        /// </list>
        /// </param>
        /// If you specify either <see cref="ServiceType.SERVICE_WIN32_OWN_PROCESS"/> or <see cref="ServiceType.SERVICE_WIN32_SHARE_PROCESS"/>,
        /// and the service is running in the context of the LocalSystem account, you can also specify the following type.
        /// <see cref="ServiceType.SERVICE_INTERACTIVE_PROCESS"/>
        /// <param name="dwStartType">
        /// The type of service. Specify <see cref="SERVICE_NO_CHANGE"/> if you are not changing the existing service type;
        /// otherwise, specify one of the following service types.
        /// <list type="bullet">
        /// <item>
        /// <see cref="ServiceStartType.SERVICE_AUTO_START"/>
        /// </item>
        /// <item>
        /// <see cref="ServiceStartType.SERVICE_BOOT_START"/>
        /// </item>
        /// <item>
        /// <see cref="ServiceStartType.SERVICE_DEMAND_START"/>
        /// </item>
        /// <item>
        /// <see cref="ServiceStartType.SERVICE_DISABLED"/>
        /// </item>
        /// <item>
        /// <see cref="ServiceStartType.SERVICE_SYSTEM_START"/>
        /// </item>
        /// </list>
        /// </param>
        /// <param name="dwErrorControl">
        /// The severity of the error, and action taken, if this service fails to start. Specify SERVICE_NO_CHANGE if you are not changing the existing error control;
        /// otherwise, specify one of the following values.
        /// <list type="bullet">
        /// <item>
        /// <see cref="ServiceErrorControl.SERVICE_ERROR_CRITICAL"/>
        /// </item>
        /// <item>
        /// <see cref="ServiceErrorControl.SERVICE_ERROR_IGNORE"/>
        /// </item>
        /// <item>
        /// <see cref="ServiceErrorControl.SERVICE_ERROR_NORMAL"/>
        /// </item>
        /// <item>
        /// <see cref="ServiceErrorControl.SERVICE_ERROR_SEVERE"/>
        /// </item>
        /// </list>
        /// </param>
        /// <param name="lpBinaryPathName">
        /// The fully qualified path to the service binary file. Specify NULL if you are not changing the existing path.
        /// If the path contains a space, it must be quoted so that it is correctly interpreted.
        /// For example, "d:\\my share\\myservice.exe" should be specified as "\"d:\\my share\\myservice.exe\"".
        /// The path can also include arguments for an auto-start service.
        /// For example, "d:\\myshare\\myservice.exe arg1 arg2". These arguments are passed to the service entry point (typically the main function).
        /// If you specify a path on another computer, the share must be accessible by the computer account of the local computer because this is the security context used in the remote call.
        /// However, this requirement allows any potential vulnerabilities in the remote computer to affect the local computer. Therefore, it is best to use a local file.
        /// </param>
        /// <param name="lpLoadOrderGroup">
        /// The name of the load ordering group of which this service is a member. Specify NULL if you are not changing the existing group. Specify an empty string if the service does not belong to a group.
        /// The startup program uses load ordering groups to load groups of services in a specified order with respect to the other groups. The list of load ordering groups is contained in the ServiceGroupOrder value of the following registry key:
        /// HKEY_LOCAL_MACHINE\System\CurrentControlSet\Control
        /// </param>
        /// <param name="lpdwTagId">
        /// A pointer to a variable that receives a tag value that is unique in the group specified in the lpLoadOrderGroup parameter. Specify NULL if you are not changing the existing tag.
        /// You can use a tag for ordering service startup within a load ordering group by specifying a tag order vector in the following registry value:
        /// HKEY_LOCAL_MACHINE\System\CurrentControlSet\Control\GroupOrderList
        /// Tags are only evaluated for driver services that have <see cref="ServiceStartType.SERVICE_BOOT_START"/> or <see cref="ServiceStartType.SERVICE_SYSTEM_START"/> start types.
        /// </param>
        /// <param name="lpDependencies">
        /// A pointer to a double null-terminated array of null-separated names of services or load ordering groups that the system must start before this service. Specify NULL or an empty string if the service has no dependencies.
        /// Dependency on a group means that this service can run if at least one member of the group is running after an attempt to start all members of the group.
        /// You must prefix group names with SC_GROUP_IDENTIFIER so that they can be distinguished from a service name, because services and service groups share the same name space.
        /// </param>
        /// <param name="lpServiceStartName">
        /// The name of the account under which the service should run.
        /// If the service type is <see cref="ServiceType.SERVICE_WIN32_OWN_PROCESS"/>, use an account name in the form DomainName\UserName.
        /// The service process will be logged on as this user.
        /// If the account belongs to the built-in domain, you can specify .\UserName.
        /// </param>
        /// <param name="lpPassword">
        /// The password to the account name specified by the lpServiceStartName parameter.
        /// Specify an empty string if the account has no password or if the service runs in the LocalService, NetworkService, or LocalSystem account.
        /// If the account name specified by the lpServiceStartName parameter is the name of a managed service account or virtual account name, the lpPassword parameter must be NULL.
        /// Passwords are ignored for driver services.
        /// </param>
        /// <param name="lpDisplayName">
        /// The display name to be used by applications to identify the service for its users. Specify NULL if you are not changing the existing display name; otherwise, this string has a maximum length of 256 characters. The name is case-preserved in the service control manager. Display name comparisons are always case-insensitive.
        /// This parameter can specify a localized string using the following format:
        /// @[path\]dllname,-strID
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is nonzero.
        /// If the function fails, the return value is zero. To get extended error information, call GetLastError.
        /// The following error codes may be set by the service control manager.
        /// Other error codes may be set by the registry functions that are called by the service control manager.
        /// <list type="bullet">
        /// <item>
        /// <see cref="Win32ErrorCode.ERROR_ACCESS_DENIED"/>
        /// </item>
        /// <item>
        /// <see cref="Win32ErrorCode.ERROR_CIRCULAR_DEPENDENCY"/>
        /// </item>
        /// <item>
        /// <see cref="Win32ErrorCode.ERROR_DUPLICATE_SERVICE_NAME"/>
        /// </item>
        /// <item>
        /// <see cref="Win32ErrorCode.ERROR_INVALID_HANDLE"/>
        /// </item>
        /// <item>
        /// <see cref="Win32ErrorCode.ERROR_INVALID_PARAMETER"/>
        /// </item>
        /// <item>
        /// <see cref="Win32ErrorCode.ERROR_INVALID_SERVICE_ACCOUNT"/>
        /// </item>
        /// <item>
        /// <see cref="Win32ErrorCode.ERROR_SERVICE_MARKED_FOR_DELETE"/>
        /// </item>
        /// </list>
        /// </returns>
        [DllImport(api_ms_win_service_management_l2_1_0, SetLastError = true, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool ChangeServiceConfig(
            SafeServiceHandle hService,
            ServiceType dwServiceType,
            ServiceStartType dwStartType,
            ServiceErrorControl dwErrorControl,
            string lpBinaryPathName,
            string lpLoadOrderGroup,
            int lpdwTagId,
            string lpDependencies,
            string lpServiceStartName,
            string lpPassword,
            string lpDisplayName);

        /// <summary>
        /// Changes the optional configuration parameters of a service.
        /// </summary>
        /// <param name="hService">
        /// A handle to the service.
        /// This handle is returned by the <see cref="OpenService"/> or <see cref="CreateService(SafeServiceHandle,string,string,ACCESS_MASK,ServiceType,ServiceStartType,ServiceErrorControl,string,string,int, string,string,string)"/> function and
        /// must have the <see cref="ServiceAccess.SERVICE_CHANGE_CONFIG"/> access right.
        /// </param>
        /// <param name="dwInfoLevel">
        /// The configuration information to be changed.
        /// This parameter can be one value from <see cref="ServiceStartType"/>.
        /// </param>
        /// <param name="lpInfo">
        /// A pointer to the new value to be set for the configuration information.
        /// The format of this data depends on the value of the <paramref name="dwInfoLevel"/> parameter.
        /// If this value is NULL, the information remains unchanged.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is nonzero.
        /// If the function fails, the return value is zero
        /// </returns>
        [DllImport(api_ms_win_service_management_l2_1_0, SetLastError = true, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static unsafe extern bool ChangeServiceConfig2(SafeServiceHandle hService, ServiceInfoLevel dwInfoLevel, void* lpInfo);

        /// <summary>
        /// Sends a control code to a service.
        /// To specify additional information when stopping a service, use the ControlServiceEx function.
        /// </summary>
        /// <param name="hService">
        /// A handle to the service. This handle is returned by the <see cref="OpenService"/> or <see cref="CreateService(SafeServiceHandle,string,string,ACCESS_MASK,ServiceType,ServiceStartType,ServiceErrorControl,string,string,int, string,string,string)"/> function.
        /// The access rights required for this handle depend on the <paramref name="dwControl"/> code requested.
        /// </param>
        /// <param name="dwControl">
        /// This parameter can be one of the following control codes.
        /// <list type="bullet">
        /// <item>
        /// <see cref="ServiceControl.SERVICE_CONTROL_CONTINUE"/>
        /// </item>
        /// <item>
        /// <see cref="ServiceControl.SERVICE_CONTROL_INTERROGATE"/>
        /// </item>
        /// <item>
        /// <see cref="ServiceControl.SERVICE_CONTROL_NETBINDADD"/>
        /// </item>
        /// <item>
        /// <see cref="ServiceControl.SERVICE_CONTROL_NETBINDDISABLE"/>
        /// </item>
        /// <item>
        /// <see cref="ServiceControl.SERVICE_CONTROL_NETBINDENABLE"/>
        /// </item>
        /// <item>
        /// <see cref="ServiceControl.SERVICE_CONTROL_NETBINDREMOVE"/>
        /// </item>
        /// <item>
        /// <see cref="ServiceControl.SERVICE_CONTROL_PARAMCHANGE"/>
        /// </item>
        /// <item>
        /// <see cref="ServiceControl.SERVICE_CONTROL_PAUSE"/>
        /// </item>
        /// <item>
        /// <see cref="ServiceControl.SERVICE_CONTROL_STOP"/>
        /// </item>
        /// </list>
        /// </param>
        /// This value can also be a user-defined control code (Range 128 to 255).
        /// The service defines the action associated with the control code. The hService handle must have the <see cref="ServiceAccess.SERVICE_USER_DEFINED_CONTROL"/> access right.
        /// <param name="lpServiceStatus">
        /// A pointer to a <see cref="SERVICE_STATUS"/> structure that receives the latest service status information.
        /// The information returned reflects the most recent status that the service reported to the service control manager.
        /// The service control manager fills in the structure only when ControlService returns one of the following error codes:
        /// <see cref="Win32ErrorCode.ERROR_SUCCESS"/>, <see cref="Win32ErrorCode.ERROR_INVALID_SERVICE_CONTROL"/>, ERROR_SERVICE_CANNOT_ACCEPT_CTRL, or <see cref="Win32ErrorCode.ERROR_SERVICE_NOT_ACTIVE"/>.
        /// Otherwise, the structure is not filled in.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is nonzero.
        /// If the function fails, the return value is zero. To get extended error information, call GetLastError.
        /// </returns>
        [DllImport(api_ms_win_service_management_l1_1_0, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool ControlService(SafeServiceHandle hService, ServiceControl dwControl, ref SERVICE_STATUS lpServiceStatus);

        /// <summary>
        /// Creates a service object and adds it to the specified service control manager database.
        /// </summary>
        /// <param name="hSCManager">
        /// A handle to the service control manager database.
        /// This handle is returned by the <see cref="OpenSCManager"/> function and must have the <see cref="ServiceManagerAccess.SC_MANAGER_CREATE_SERVICE"/> access right.
        /// </param>
        /// <param name="lpServiceName">
        /// The name of the service to install.
        /// The maximum string length is 256 characters.
        /// The service control manager database preserves the case of the characters,
        /// but service name comparisons are always case insensitive.
        /// Forward-slash (/) and backslash (\) are not valid service name characters.
        /// </param>
        /// <param name="lpDisplayName">
        /// The display name to be used by user interface programs to identify the service.
        /// This string has a maximum length of 256 characters.
        /// The name is case-preserved in the service control manager.
        /// Display name comparisons are always case-insensitive.
        /// </param>
        /// <param name="dwDesiredAccess">
        /// Before granting the requested access, the system checks the access token of the calling process.
        /// Common specific rights are defined in <seealso cref="ServiceAccess"/>.
        /// </param>
        /// <param name="dwServiceType">
        /// The service type (<see cref="ServiceType"/>).
        /// </param>
        /// <param name="dwStartType">
        /// The service start options (<see cref="ServiceStartType"/>).
        /// </param>
        /// <param name="dwErrorControl">
        /// The severity of the error (<see cref="ServiceErrorControl"/>), and action taken, if this service fails to start.
        /// </param>
        /// <param name="lpBinaryPathName">
        /// The fully qualified path to the service binary file. If the path contains a space, it must be quoted so that it is correctly interpreted. For example, "d:\\my share\\myservice.exe" should be specified as "\"d:\\my share\\myservice.exe\"".
        /// The path can also include arguments for an auto-start service.For example, "d:\\myshare\\myservice.exe arg1 arg2". These arguments are passed to the service entry point (typically the main function).
        /// If you specify a path on another computer, the share must be accessible by the computer account of the local computer because this is the security context used in the remote call.However, this requirement allows any potential vulnerabilities in the remote computer to affect the local computer. Therefore, it is best to use a local file.
        /// </param>
        /// <param name="lpLoadOrderGroup">
        /// The names of the load ordering group of which this service is a member. Specify NULL or an empty string if the service does not belong to a group.
        /// The startup program uses load ordering groups to load groups of services in a specified order with respect to the other groups.
        /// The list of load ordering groups is contained in the following registry value:
        /// HKEY_LOCAL_MACHINE\System\CurrentControlSet\Control\ServiceGroupOrder
        /// </param>
        /// <param name="lpdwTagId">
        /// A pointer to a variable that receives a tag value that is unique in the group specified in the lpLoadOrderGroup parameter. Specify NULL if you are not changing the existing tag.
        /// You can use a tag for ordering service startup within a load ordering group by specifying a tag order vector in the following registry value:
        /// HKEY_LOCAL_MACHINE\System\CurrentControlSet\Control\GroupOrderList
        /// Tags are only evaluated for driver services that have <see cref="ServiceStartType.SERVICE_BOOT_START"/> or <see cref="ServiceStartType.SERVICE_SYSTEM_START"/> start types.
        /// </param>
        /// <param name="lpDependencies">
        /// A pointer to a double null-terminated array of null-separated names of services or load ordering groups that the system must start before this service. Specify NULL or an empty string if the service has no dependencies.
        /// Dependency on a group means that this service can run if at least one member of the group is running after an attempt to start all members of the group.
        /// You must prefix group names with SC_GROUP_IDENTIFIER so that they can be distinguished from a service name, because services and service groups share the same name space.
        /// </param>
        /// <param name="lpServiceStartName">
        /// The name of the account under which the service should run.
        /// If the service type is <see cref="ServiceType.SERVICE_WIN32_OWN_PROCESS"/>, use an account name in the form DomainName\UserName.
        /// The service process will be logged on as this user.
        /// If the account belongs to the built-in domain, you can specify .\UserName.
        /// </param>
        /// <param name="lpPassword">
        /// The password to the account name specified by the lpServiceStartName parameter.
        /// Specify an empty string if the account has no password or if the service runs in the LocalService, NetworkService, or LocalSystem account.
        /// If the account name specified by the lpServiceStartName parameter is the name of a managed service account or virtual account name, the lpPassword parameter must be NULL.
        /// Passwords are ignored for driver services.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is a handle to the service.
        /// If the function fails, the return value is NULL
        /// </returns>
        [DllImport(api_ms_win_service_management_l1_1_0, SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern SafeServiceHandle CreateService(SafeServiceHandle hSCManager, string lpServiceName, string lpDisplayName, ACCESS_MASK dwDesiredAccess, ServiceType dwServiceType, ServiceStartType dwStartType, ServiceErrorControl dwErrorControl, string lpBinaryPathName, string lpLoadOrderGroup, int lpdwTagId, string lpDependencies, string lpServiceStartName, string lpPassword);

        /// <summary>
        /// Retrieves parameters that govern the operations of a cryptographic service provider (CSP).
        /// </summary>
        /// <param name="hProv">A handle of the CSP target of the query. This handle must have been created by using the CryptAcquireContext function.</param>
        /// <param name="dwParam">The nature of the query.</param>
        /// <param name="pbData">
        /// A pointer to a buffer to receive the data. The form of this data varies depending on the value of <paramref name="dwFlags"/>.
        /// When <paramref name="dwFlags"/> is set to <see cref="CryptGetProvParamQuery.PP_USE_HARDWARE_RNG"/>, <paramref name="pbData"/> must be set to NULL.
        /// This parameter can be NULL to set the size of this information for memory allocation purposes.
        /// </param>
        /// <param name="pdwDataLen">
        /// A pointer to a DWORD value that specifies the size, in bytes, of the buffer pointed to by the <paramref name="pbData"/> parameter.
        /// When the function returns, the DWORD value contains the number of bytes stored or to be stored in the buffer.
        /// </param>
        /// <param name="dwFlags">
        /// If <paramref name="dwParam"/> is <see cref="CryptGetProvParamQuery.PP_KEYSET_SEC_DESCR"/>, the security descriptor on the key container where the keys are stored is retrieved.
        /// For this case, <paramref name="dwFlags"/> is used to pass in the <see cref="SECURITY_INFORMATION"/> bit flags that indicate the requested security information,
        /// as defined in the Platform SDK. <see cref="SECURITY_INFORMATION"/> bit flags can be combined with a bitwise-OR operation.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is nonzero.
        /// If the function fails, the return value is zero.
        /// </returns>
        [DllImport(api_ms_win_service_management_l1_1_0, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern unsafe bool CryptGetProvParam(
                SafeHandle hProv,
                CryptGetProvParamQuery dwParam,
                [Friendly(FriendlyFlags.Out | FriendlyFlags.Optional)] byte* pbData,
                ref int pdwDataLen,
                uint dwFlags);

        /// <summary>
        /// Customizes the operations of a cryptographic service provider (CSP). This function is commonly used to set a security descriptor on the key container associated with a CSP to control access to the private keys in that key container.
        /// </summary>
        /// <param name="hProv">The handle of a CSP for which to set values. This handle must have already been created by using the CryptAcquireContext function.</param>
        /// <param name="dwParam">Specifies the parameter to set.</param>
        /// <param name="pbData">
        /// A pointer to a data buffer that contains the value to be set as a provider parameter.
        /// The form of this data varies depending on the dwParam value. If dwFlags contains <see cref="CryptSetProvParamQuery.PP_USE_HARDWARE_RNG"/>, this parameter must be NULL.
        /// </param>
        /// <param name="dwFlags">
        /// If <paramref name="dwFlags"/> contains <see cref="CryptSetProvParamQuery.PP_KEYSET_SEC_DESCR"/>, <paramref name="dwFlags"/> contains the <see cref="SECURITY_INFORMATION"/> applicable bit flags, as defined in the Platform SDK.
        /// Key-container security is handled by using SetFileSecurity and GetFileSecurity.
        /// These bit flags can be combined by using a bitwise-OR operation.For more information, see <see cref="CryptGetProvParam(SafeHandle,CryptGetProvParamQuery,byte*,ref int,uint)"/>.
        /// If dwParam is <see cref="CryptSetProvParamQuery.PP_USE_HARDWARE_RNG"/> or <see cref="CryptSetProvParamQuery.PP_DELETEKEY"/>, <paramref name="dwFlags"/> must be set to zero.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is nonzero.
        /// If the function fails, the return value is zero.
        /// </returns>
        [DllImport(api_ms_win_service_management_l1_1_0, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern unsafe bool CryptSetProvParam(
                SafeHandle hProv,
                CryptSetProvParamQuery dwParam,
                [Friendly(FriendlyFlags.In | FriendlyFlags.Optional)] byte* pbData,
                uint dwFlags);

        /// <summary>
        /// Marks the specified service for deletion from the service control manager database.
        /// </summary>
        /// <param name="hService">
        /// A handle to the service. This handle is returned by the <see cref="OpenService"/> or <see cref="CreateService(SafeServiceHandle,string,string,ACCESS_MASK,ServiceType,ServiceStartType,ServiceErrorControl,string,string,int, string,string,string)"/> function, and it must have the <see cref="ACCESS_MASK.StandardRight.DELETE"/> access right
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is nonzero.
        /// If the function fails, the return value is zero
        /// </returns>
        [DllImport(api_ms_win_service_management_l1_1_0, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool DeleteService(SafeServiceHandle hService);

        /// <summary>
        /// Establishes a connection to the service control manager on the specified computer and opens the specified service control manager database.
        /// </summary>
        /// <param name="lpMachineName">
        /// The name of the target computer.
        /// If the pointer is NULL or points to an empty string,
        /// the function connects to the service control manager on the local computer.
        /// </param>
        /// <param name="lpDatabaseName">
        /// The name of the service control manager database.
        /// This parameter should be set to SERVICES_ACTIVE_DATABASE.
        /// If it is NULL, the SERVICES_ACTIVE_DATABASE database is opened by default.
        /// </param>
        /// <param name="dwDesiredAccess">
        /// The access to the service control manager. For a list of access rights, see Service Security and Access Rights.
        /// Before granting the requested access rights, the system checks the access token of the calling process against the discretionary access-control list of the security descriptor associated with the service control manager.
        /// The <see cref="ServiceManagerAccess.SC_MANAGER_CONNECT"/> access right is implicitly specified by calling this function.
        /// Common specific rights are defined in <seealso cref="ServiceManagerAccess"/>.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is a handle to the specified service control manager database.
        /// If the function fails, the return value is NULL.To get extended error information, call <see cref="Kernel32.GetLastError"/>.
        /// </returns>
        [DllImport(api_ms_win_service_management_l1_1_0, SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern SafeServiceHandle OpenSCManager(string lpMachineName, string lpDatabaseName, ACCESS_MASK dwDesiredAccess);

        /// <summary>
        /// Opens an existing service.
        /// </summary>
        /// <param name="hSCManager">
        /// A handle to the service control manager database. The <see cref="OpenSCManager"/> function returns this handle.
        /// </param>
        /// <param name="lpServiceName">
        /// The name of the service to be opened. This is the name specified by the lpServiceName parameter of the CreateService function when the service object was created, not the service display name that is shown by user interface applications to identify the service.
        /// The maximum string length is 256 characters.The service control manager database preserves the case of the characters, but service name comparisons are always case insensitive.Forward-slash(/) and backslash(\) are invalid service name characters.
        /// </param>
        /// <param name="dwDesiredAccess">
        /// Before granting the requested access, the system checks the access token of the calling process against the discretionary access-control list of the security descriptor associated with the service object.
        /// Common specific rights are defined in <seealso cref="ServiceAccess"/>.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is a handle to the service.
        /// If the function fails, the return value is NULL.
        /// </returns>
        [DllImport(api_ms_win_service_management_l1_1_0, SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern SafeServiceHandle OpenService(SafeServiceHandle hSCManager, string lpServiceName, ACCESS_MASK dwDesiredAccess);

        /// <summary>
        /// Starts a service.
        /// </summary>
        /// <param name="hService">
        /// A handle to the service. This handle is returned by the <see cref="OpenService"/> or <see cref="CreateService(SafeServiceHandle,string,string,ACCESS_MASK,ServiceType,ServiceStartType,ServiceErrorControl,string,string,int, string,string,string)"/> function, and it must have the <see cref="ServiceAccess.SERVICE_START"/> access right.
        /// </param>
        /// <param name="dwNumServiceArgs">
        /// The number of strings in the lpServiceArgVectors array. If lpServiceArgVectors is NULL, this parameter can be zero.
        /// </param>
        /// <param name="lpServiceArgVectors">
        /// The null-terminated strings to be passed to the ServiceMain function for the service as arguments. If there are no arguments, this parameter can be NULL. Otherwise, the first argument (lpServiceArgVectors[0]) is the name of the service, followed by any additional arguments (lpServiceArgVectors[1] through lpServiceArgVectors[dwNumServiceArgs-1]).
        /// Driver services do not receive these arguments.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is nonzero.
        /// If the function fails, the return value is zero.
        /// </returns>
        [DllImport(api_ms_win_service_management_l1_1_0, SetLastError = true, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool StartService(SafeServiceHandle hService, int dwNumServiceArgs, string lpServiceArgVectors);

        /// <summary>Opens the access token associated with a process.</summary>
        /// <param name="processHandle">
        ///     A handle to the process whose access token is opened. The process must have the
        ///     PROCESS_QUERY_INFORMATION access permission.
        /// </param>
        /// <param name="desiredAccess">
        ///     Specifies an access mask that specifies the requested types of access to the access token.
        ///     These requested access types are compared with the discretionary access control list (DACL) of the token to
        ///     determine which accesses are granted or denied.
        ///     Common specific rights are defined in <seealso cref="TokenAccessRights"/>.
        /// </param>
        /// <param name="tokenHandle">A handle that identifies the newly opened access token when the function returns.</param>
        /// <returns>
        ///     If the function succeeds, the return value is a nonzero value.
        ///     <para>
        ///         If the function fails, the return value is zero. To get extended error information, call
        ///         <see cref="GetLastError" />.
        ///     </para>
        /// </returns>
        [DllImport(api_ms_win_core_processthreads_l1_1_1, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool OpenProcessToken(
            IntPtr processHandle,
            ACCESS_MASK desiredAccess,
            out SafeObjectHandle tokenHandle);

        /// <summary>
        ///     The GetTokenInformation function retrieves a specified type of information about an access token. The calling
        ///     process must have appropriate access rights to obtain the information.
        ///     <para>
        ///         To determine if a user is a member of a specific group, use the CheckTokenMembership function. To determine
        ///         group membership for app container tokens, use the CheckTokenMembershipEx function.
        ///     </para>
        /// </summary>
        /// <param name="TokenHandle">
        ///     A handle to an access token from which information is retrieved. If TokenInformationClass
        ///     specifies TokenSource, the handle must have TOKEN_QUERY_SOURCE access. For all other TokenInformationClass values,
        ///     the handle must have TOKEN_QUERY access.
        /// </param>
        /// <param name="TokenInformationClass">
        ///     Specifies a value from the TOKEN_INFORMATION_CLASS enumerated type to identify the
        ///     type of information the function retrieves. Any callers who check the TokenIsAppContainer and have it return 0
        ///     should also verify that the caller token is not an identify level impersonation token. If the current token is not
        ///     an app container but is an identity level token, you should return AccessDenied.
        /// </param>
        /// <param name="TokenInformation">
        ///     A pointer to a buffer the function fills with the requested information. The structure
        ///     put into this buffer depends upon the type of information specified by the
        ///     <paramref name="TokenInformationClass" /> parameter.
        /// </param>
        /// <param name="TokenInformationLength">
        ///     Specifies the size, in bytes, of the buffer pointed to by the TokenInformation
        ///     parameter. If <paramref name="TokenInformation" /> is NULL, this parameter must be zero.
        /// </param>
        /// <param name="ReturnLength">
        ///     A pointer to a variable that receives the number of bytes needed for the buffer pointed to by the TokenInformation
        ///     parameter. If this value is larger than the value specified in the TokenInformationLength parameter, the function
        ///     fails and stores no data in the buffer.
        ///     <para>
        ///         If the value of the <paramref name="TokenInformationClass" /> parameter is
        ///         <see cref="TOKEN_INFORMATION_CLASS.TokenDefaultDacl" /> and the token has no default DACL, the function sets
        ///         the variable pointed to by ReturnLength to sizeof(TOKEN_DEFAULT_DACL) and sets the DefaultDacl member of the
        ///         TOKEN_DEFAULT_DACL structure to NULL.
        ///     </para>
        /// </param>
        /// <returns>
        ///     If the function succeeds, the return value is a nonzero value.
        ///     <para>
        ///         If the function fails, the return value is zero. To get extended error information, call
        ///         <see cref="GetLastError" />.
        ///     </para>
        /// </returns>
        [DllImport(api_ms_win_security_base_l1_2_0, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern unsafe bool GetTokenInformation(
            SafeObjectHandle TokenHandle,
            TOKEN_INFORMATION_CLASS TokenInformationClass,
            void* TokenInformation,
            int TokenInformationLength,
            out int ReturnLength);

        /// <summary>
        ///     The QueryServiceObjectSecurity function retrieves a copy of the security descriptor associated with a service
        ///     object. You can also use the GetNamedSecurityInfo function to retrieve a security descriptor.
        /// </summary>
        /// <param name="hService">
        ///     A handle to the service control manager or the service. Handles to the service control manager
        ///     are returned by the <see cref="OpenSCManager" /> function, and handles to a service are returned by either the
        ///     <see cref="OpenService" /> or <see cref="CreateService(SafeServiceHandle,string,string,ACCESS_MASK,ServiceType,ServiceStartType,ServiceErrorControl,string,string,int, string,string,string)" /> function. The handle must have the READ_CONTROL access
        ///     right.
        /// </param>
        /// <param name="dwSecurityInformation">
        ///     A set of bit flags that indicate the type of security information to retrieve. This
        ///     parameter can be a combination of the <see cref="SECURITY_INFORMATION" /> flags, with the exception that this
        ///     function does not support the <see cref="SECURITY_INFORMATION.LABEL_SECURITY_INFORMATION" /> value.
        /// </param>
        /// <param name="lpSecurityDescriptor">
        ///     A pointer to a buffer that receives a copy of the security descriptor of the
        ///     specified service object. The calling process must have the appropriate access to view the specified aspects of the
        ///     security descriptor of the object. The SECURITY_DESCRIPTOR structure is returned in self-relative format.
        /// </param>
        /// <param name="cbBufSize">
        ///     The size of the buffer pointed to by the <paramref name="lpSecurityDescriptor" /> parameter, in
        ///     bytes. The largest size allowed is 8 kilobytes.
        /// </param>
        /// <param name="pcbBytesNeeded">
        ///     A pointer to a variable that receives the number of bytes needed to return the requested
        ///     security descriptor information, if the function fails.
        /// </param>
        /// <returns>
        ///     If the function succeeds, the return value is a nonzero value.
        ///     <para>
        ///         If the function fails, the return value is zero. To get extended error information, call
        ///         <see cref="GetLastError" />.
        ///     </para>
        /// </returns>
        [DllImport(api_ms_win_service_management_l2_1_0, SetLastError = true)]
        public static extern bool QueryServiceObjectSecurity(
            SafeServiceHandle hService,
            SECURITY_INFORMATION dwSecurityInformation,
            byte[] lpSecurityDescriptor,
            int cbBufSize,
            out int pcbBytesNeeded);

        /// <summary>
        /// Retrieves the current status of the specified service.
        /// This function has been superseded by the <see cref="QueryServiceStatusEx(SafeServiceHandle, SC_STATUS_TYPE, void*, int, out int)"/> function. <see cref="QueryServiceStatusEx(SafeServiceHandle, SC_STATUS_TYPE, void*, int, out int)"/> returns the same information <see cref="QueryServiceStatus"/> returns, with the addition of the process identifier and additional information for the service.
        /// </summary>
        /// <param name="hService">
        /// A handle to the service. This handle is returned by the <see cref="OpenService"/> or the <see cref="CreateService(SafeServiceHandle,string,string,ACCESS_MASK,ServiceType,ServiceStartType,ServiceErrorControl,string,string,int, string,string,string)"/> function, and it must have the <see cref="ServiceAccess.SERVICE_QUERY_STATUS"/> access right.
        /// </param>
        /// <param name="dwServiceStatus">
        /// A pointer to a <see cref="SERVICE_STATUS"/> structure that receives the status information.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is nonzero.
        /// If the function fails, the return value is zero. To get extended error information, call GetLastError.
        /// </returns>
        [DllImport(api_ms_win_service_winsvc_l1_2_0, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool QueryServiceStatus(SafeServiceHandle hService, ref SERVICE_STATUS dwServiceStatus);

        /// <summary>The SetServiceObjectSecurity function sets the security descriptor of a service object.</summary>
        /// <param name="hService">
        ///     A handle to the service. This handle is returned by the <see cref="OpenService" /> or
        ///     <see cref="CreateService(SafeServiceHandle,string,string,ACCESS_MASK,ServiceType,ServiceStartType,ServiceErrorControl,string,string,int, string,string,string)" /> function. The access required for this handle depends on the security information
        ///     specified in the <paramref name="dwSecurityInformation" /> parameter.
        /// </param>
        /// <param name="dwSecurityInformation">
        ///     Specifies the components of the security descriptor to set. This parameter can be a
        ///     combination of the following values : <see cref="SECURITY_INFORMATION.DACL_SECURITY_INFORMATION" />,
        ///     <see cref="SECURITY_INFORMATION.GROUP_SECURITY_INFORMATION" />,
        ///     <see cref="SECURITY_INFORMATION.OWNER_SECURITY_INFORMATION" />,
        ///     <see cref="SECURITY_INFORMATION.SACL_SECURITY_INFORMATION" />. Note that flags not handled by
        ///     SetServiceObjectSecurity will be silently ignored.
        /// </param>
        /// <param name="lpSecurityDescriptor">
        ///     A pointer to a SECURITY_DESCRIPTOR structure that contains the new security
        ///     information.
        /// </param>
        /// <returns>
        ///     If the function succeeds, the return value is a nonzero value.
        ///     <para>
        ///         If the function fails, the return value is zero. To get extended error information, call
        ///         <see cref="GetLastError" />.
        ///     </para>
        /// </returns>
        [DllImport(api_ms_win_service_management_l2_1_0, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetServiceObjectSecurity(
            SafeServiceHandle hService,
            SECURITY_INFORMATION dwSecurityInformation,
            byte[] lpSecurityDescriptor);

        /// <summary>
        /// Updates the service control manager's status information for the calling service.
        /// </summary>
        /// <param name="hServiceStatus">
        /// A handle to the status information structure for the current service.
        /// This handle is returned by the RegisterServiceCtrlHandlerEx function.
        /// The service status handle does not have to be closed.
        /// </param>
        /// <param name="lpServiceStatus">
        /// A pointer to the <see cref="SERVICE_STATUS"/> structure the contains the latest status information for the calling service.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is nonzero.
        /// If the function fails, the return value is zero. To get extended error information, call GetLastError.
        /// The following error codes can be set by the service control manager.
        /// Other error codes can be set by the registry functions that are called by the service control manager.
        /// <list type="bullet">
        /// <item>
        /// <see cref="Win32ErrorCode.ERROR_INVALID_DATA"/>
        /// </item>
        /// <item>
        /// <see cref="Win32ErrorCode.ERROR_INVALID_HANDLE"/>
        /// </item>
        /// </list>
        /// </returns>
        [DllImport(api_ms_win_service_core_l1_1_1, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetServiceStatus(IntPtr hServiceStatus, ref SERVICE_STATUS lpServiceStatus);

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

        /// <summary>
        /// Retrieves the current status of the specified service based on the specified information level.
        /// </summary>
        /// <param name="hService">
        /// A handle to the service. This handle is returned by the <see cref="CreateService(SafeServiceHandle,string,string,ACCESS_MASK,ServiceType,ServiceStartType,ServiceErrorControl,string,string,int, string,string,string)"/> or <see cref="OpenService"/> function, and it must have the <see cref="ServiceAccess.SERVICE_QUERY_STATUS"/> access right. For more information, see Service Security and Access Rights.
        /// </param>
        /// <param name="InfoLevel">
        /// The service attributes to be returned. Use <see cref="SC_STATUS_TYPE.SC_STATUS_PROCESS_INFO"/> to retrieve the service status information.
        /// The <paramref name="lpBuffer"/> parameter is a pointer to a <see cref="SERVICE_STATUS_PROCESS"/> structure.</param>
        /// <param name="lpBuffer">
        /// A pointer to the buffer that receives the status information. The format of this data depends on the value of the <paramref name="InfoLevel"/> parameter.
        /// The maximum size of this array is 8K bytes. To determine the required size, specify NULL for this parameter and 0 for the <paramref name="cbBufSize" /> parameter.The function will fail and <see cref="GetLastError "/> will return ERROR_INSUFFICIENT_BUFFER.The <paramref name="pcbBytesNeeded" /> parameter will receive the required size.
        /// </param>
        /// <param name="cbBufSize">
        /// The size of the buffer pointed to by the <paramref name="lpBuffer"/> parameter, in bytes.
        /// </param>
        /// <param name="pcbBytesNeeded">
        /// A pointer to a variable that receives the number of bytes needed to store all status information, if the function fails with <see cref="Win32ErrorCode.ERROR_INSUFFICIENT_BUFFER"/>.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is nonzero.
        /// If the function fails, the return value is zero. To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        [DllImport(nameof(AdvApi32), SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static unsafe extern bool QueryServiceStatusEx(
            SafeServiceHandle hService,
            SC_STATUS_TYPE InfoLevel,
            void* lpBuffer,
            int cbBufSize,
            out int pcbBytesNeeded);

        /// <summary>
        /// Registers a function to handle service control requests.
        /// </summary>
        /// <param name="lpServiceName">
        /// The name of the service run by the calling thread. This is the service name that the service control program specified in the CreateService function when creating the service.
        /// If the service type is SERVICE_WIN32_OWN_PROCESS, the function does not verify that the specified name is valid, because there is only one registered service in the process.
        /// </param>
        /// <param name="lpHandlerProc">A reference to the handler function to be registered.</param>
        /// <returns>If the function succeeds, the return value is a service status handle If the function fails, the return value is zero. </returns>
        /// <remarks>
        /// This function has been superseded by the <see cref="RegisterServiceCtrlHandlerEx(string, LPHANDLER_FUNCTION_EX, void*)"/> function.
        /// A service can use either function, but the new function supports user-defined context data, and the new handler function supports additional extended control codes.
        /// </remarks>
        [DllImport(nameof(AdvApi32), CharSet = CharSet.Unicode)]
        [Obsolete("Use LPHANDLER_FUNCTION_EX with RegisterServiceCtrlHandlerEx instead")]
#pragma warning disable CS0618 // Type or member is obsolete
        public static extern IntPtr RegisterServiceCtrlHandler(string lpServiceName, LPHANDLER_FUNCTION lpHandlerProc);
#pragma warning restore CS0618 // Type or member is obsolete

        /// <summary>
        /// Registers a function to handle extended service control requests.
        /// </summary>
        /// <param name="lpServiceName">
        /// The name of the service run by the calling thread. This is the service name that the service control program specified in the CreateService function when creating the service.
        /// </param>
        /// <param name="lpHandlerProc">A reference to the handler function to be registered.</param>
        /// <param name="lpContext">Any user-defined data. This parameter, which is passed to the handler function, can help identify the service when multiple services share a process.</param>
        /// <returns>If the function succeeds, the return value is a service status handle If the function fails, the return value is zero. </returns>
        /// <remarks>
        /// This function has been superseded by the <see cref="RegisterServiceCtrlHandlerEx(string, LPHANDLER_FUNCTION_EX, void*)"/> function.
        /// A service can use either function, but the new function supports user-defined context data, and the new handler function supports additional extended control codes.
        /// </remarks>
        [DllImport(nameof(AdvApi32), CharSet = CharSet.Unicode)]
        public static unsafe extern IntPtr RegisterServiceCtrlHandlerEx(
            string lpServiceName,
            LPHANDLER_FUNCTION_EX lpHandlerProc,
            void* lpContext);

        /// <summary>
        /// The GetSecurityInfo function retrieves a copy of the security descriptor for an object specified by a handle.
        /// </summary>
        /// <param name="handle">A handle to the object from which to retrieve security information.</param>
        /// <param name="ObjectType">SE_OBJECT_TYPE enumeration value that indicates the type of object.</param>
        /// <param name="SecurityInfo">A set of bit flags that indicate the type of security information to retrieve. This parameter can be a combination of the <see cref="SECURITY_INFORMATION"/> bit flags.</param>
        /// <param name="ppsidOwner">A pointer to a variable that receives a pointer to the owner SID in the security descriptor returned in ppSecurityDescriptor or NULL if the security descriptor has no owner SID. The returned pointer is valid only if you set the OWNER_SECURITY_INFORMATION flag. Also, this parameter can be NULL if you do not need the owner SID.</param>
        /// <param name="ppsidGroup">A pointer to a variable that receives a pointer to the primary group SID in the returned security descriptor or NULL if the security descriptor has no group SID. The returned pointer is valid only if you set the GROUP_SECURITY_INFORMATION flag. Also, this parameter can be NULL if you do not need the group SID.</param>
        /// <param name="ppDacl">A pointer to a variable that receives a pointer to the DACL in the returned security descriptor or NULL if the security descriptor has no DACL. The returned pointer is valid only if you set the DACL_SECURITY_INFORMATION flag. Also, this parameter can be NULL if you do not need the DACL.</param>
        /// <param name="ppSacl">A pointer to a variable that receives a pointer to the SACL in the returned security descriptor or NULL if the security descriptor has no SACL. The returned pointer is valid only if you set the SACL_SECURITY_INFORMATION flag. Also, this parameter can be NULL if you do not need the SACL.</param>
        /// <param name="ppSecurityDescriptor">
        /// A pointer to a variable that receives a pointer to the security descriptor of the object. When you have finished using the pointer, free the returned buffer by calling the <see cref="LocalFree(void*)"/> function.
        /// This parameter is required if any one of the <paramref name="ppsidOwner"/>, <paramref name="ppsidGroup"/>, <paramref name="ppDacl"/>, or <paramref name="ppSacl"/> parameters is not NULL.
        /// </param>
        /// <returns>If the function succeeds, the return value is <see cref="Win32ErrorCode.ERROR_SUCCESS"/>, otherwise it return one of the default error codes.</returns>
        [DllImport(nameof(AdvApi32), SetLastError = true)]
        public static unsafe extern uint GetSecurityInfo(
            IntPtr handle,
            SE_OBJECT_TYPE ObjectType,
            SECURITY_INFORMATION SecurityInfo,
            ref void* ppsidOwner,
            ref void* ppsidGroup,
            [Friendly(FriendlyFlags.Out | FriendlyFlags.Optional)] Kernel32.ACL* ppDacl,
            [Friendly(FriendlyFlags.Out | FriendlyFlags.Optional)] Kernel32.ACL* ppSacl,
            [Friendly(FriendlyFlags.Out | FriendlyFlags.Optional)] SECURITY_DESCRIPTOR* ppSecurityDescriptor);

        /// <summary>
        /// The GetNamedSecurityInfo function retrieves a copy of the security descriptor for an object specified by name.
        /// </summary>
        /// <param name="pObjectName">Specifies the name of the object from which to retrieve security information. For descriptions of the string formats for the different object types, see <see cref="SE_OBJECT_TYPE"/>.</param>
        /// <param name="ObjectType">Specifies a value from the <see cref="SE_OBJECT_TYPE"/> enumeration that indicates the type of object named by the <paramref name="pObjectName"/> parameter.</param>
        /// <param name="SecurityInfo">A set of bit flags that indicate the type of security information to retrieve. This parameter can be a combination of the <see cref="SECURITY_INFORMATION"/> bit flags.</param>
        /// <param name="ppsidOwner">A pointer to a variable that receives a pointer to the owner SID in the security descriptor returned in ppSecurityDescriptor or NULL if the security descriptor has no owner SID. The returned pointer is valid only if you set the OWNER_SECURITY_INFORMATION flag. Also, this parameter can be NULL if you do not need the owner SID.</param>
        /// <param name="ppsidGroup">A pointer to a variable that receives a pointer to the primary group SID in the returned security descriptor or NULL if the security descriptor has no group SID. The returned pointer is valid only if you set the GROUP_SECURITY_INFORMATION flag. Also, this parameter can be NULL if you do not need the group SID.</param>
        /// <param name="ppDacl">A pointer to a variable that receives a pointer to the DACL in the returned security descriptor or NULL if the security descriptor has no DACL. The returned pointer is valid only if you set the DACL_SECURITY_INFORMATION flag. Also, this parameter can be NULL if you do not need the DACL.</param>
        /// <param name="ppSacl">A pointer to a variable that receives a pointer to the SACL in the returned security descriptor or NULL if the security descriptor has no SACL. The returned pointer is valid only if you set the SACL_SECURITY_INFORMATION flag. Also, this parameter can be NULL if you do not need the SACL.</param>
        /// <param name="ppSecurityDescriptor">
        /// A pointer to a variable that receives a pointer to the security descriptor of the object. When you have finished using the pointer, free the returned buffer by calling the <see cref="LocalFree(void*)"/> function.
        /// This parameter is required if any one of the <paramref name="ppsidOwner"/>, <paramref name="ppsidGroup"/>, <paramref name="ppDacl"/>, or <paramref name="ppSacl"/> parameters is not NULL.
        /// </param>
        /// <returns>If the function succeeds, the return value is <see cref="Win32ErrorCode.ERROR_SUCCESS"/>, otherwise it return one of the default error codes.</returns>
        [DllImport(nameof(AdvApi32), CharSet = CharSet.Unicode, SetLastError = true)]
        public static unsafe extern Win32ErrorCode GetNamedSecurityInfo(
            string pObjectName,
            SE_OBJECT_TYPE ObjectType,
            SECURITY_INFORMATION SecurityInfo,
            ref void* ppsidOwner,
            ref void* ppsidGroup,
            [Friendly(FriendlyFlags.Out | FriendlyFlags.Optional)] Kernel32.ACL* ppDacl,
            [Friendly(FriendlyFlags.Out | FriendlyFlags.Optional)] Kernel32.ACL* ppSacl,
            [Friendly(FriendlyFlags.Out | FriendlyFlags.Optional)] SECURITY_DESCRIPTOR* ppSecurityDescriptor);

        /// <summary>
        /// The SetSecurityInfo function sets specified security information in the security descriptor of a specified object. The caller identifies the object by a handle.
        /// To set the SACL of an object, the caller must have the SE_SECURITY_NAME privilege enabled.
        /// </summary>
        /// <param name="handle">A handle to the object for which to set security information.</param>
        /// <param name="ObjectType">A member of the SE_OBJECT_TYPE enumeration that indicates the type of object identified by the handle parameter.</param>
        /// <param name="SecurityInfo">A set of bit flags that indicate the type of security information to set. This parameter can be a combination of the <see cref="SECURITY_INFORMATION"/> bit flags.</param>
        /// <param name="psidOwner">A pointer to a SID structure that identifies the owner of the object. If the caller does not have the SeRestorePrivilege constant (see Privilege Constants), this SID must be contained in the caller's token, and must have the SE_GROUP_OWNER permission enabled. The SecurityInfo parameter must include the OWNER_SECURITY_INFORMATION flag. To set the owner, the caller must have WRITE_OWNER access to the object or have the SE_TAKE_OWNERSHIP_NAME privilege enabled. If you are not setting the owner SID, this parameter can be NULL.</param>
        /// <param name="psidGroup">A pointer to a SID that identifies the primary group of the object. The SecurityInfo parameter must include the GROUP_SECURITY_INFORMATION flag. If you are not setting the primary group SID, this parameter can be NULL.</param>
        /// <param name="pDacl">A pointer to the new DACL for the object. The SecurityInfo parameter must include the DACL_SECURITY_INFORMATION flag. The caller must have WRITE_DAC access to the object or be the owner of the object. If you are not setting the DACL, this parameter can be NULL.</param>
        /// <param name="pSacl">A pointer to the new SACL for the object. The SecurityInfo parameter must include any of the following flags: SACL_SECURITY_INFORMATION, LABEL_SECURITY_INFORMATION, ATTRIBUTE_SECURITY_INFORMATION, SCOPE_SECURITY_INFORMATION, or BACKUP_SECURITY_INFORMATION.</param>
        /// <returns>If the function succeeds, the return value is <see cref="Win32ErrorCode.ERROR_SUCCESS"/>, otherwise it return one of the default error codes.</returns>
        [DllImport(nameof(AdvApi32), SetLastError = true)]
        public static unsafe extern uint SetSecurityInfo(
            IntPtr handle,
            SE_OBJECT_TYPE ObjectType,
            SECURITY_INFORMATION SecurityInfo,
            void* psidOwner,
            void* psidGroup,
            [Friendly(FriendlyFlags.Out | FriendlyFlags.Optional)] Kernel32.ACL* pDacl,
            [Friendly(FriendlyFlags.Out | FriendlyFlags.Optional)] Kernel32.ACL* pSacl);

        /// <summary>
        /// The SetNamedSecurityInfo function sets specified security information in the security descriptor of a specified object. The caller identifies the object by name.
        /// </summary>
        /// <param name="pObjectName">Specifies the name of the object from which to set security information. For descriptions of the string formats for the different object types, see <see cref="SE_OBJECT_TYPE"/>.</param>
        /// <param name="ObjectType">Specifies a value from the <see cref="SE_OBJECT_TYPE"/> enumeration that indicates the type of object named by the <paramref name="pObjectName"/> parameter.</param>
        /// <param name="SecurityInfo">A set of bit flags that indicate the type of security information to set. This parameter can be a combination of the <see cref="SECURITY_INFORMATION"/> bit flags.</param>
        /// <param name="psidOwner">A pointer to a SID structure that identifies the owner of the object. If the caller does not have the SeRestorePrivilege constant (see Privilege Constants), this SID must be contained in the caller's token, and must have the SE_GROUP_OWNER permission enabled. The SecurityInfo parameter must include the OWNER_SECURITY_INFORMATION flag. To set the owner, the caller must have WRITE_OWNER access to the object or have the SE_TAKE_OWNERSHIP_NAME privilege enabled. If you are not setting the owner SID, this parameter can be NULL.</param>
        /// <param name="psidGroup">A pointer to a SID that identifies the primary group of the object. The SecurityInfo parameter must include the GROUP_SECURITY_INFORMATION flag. If you are not setting the primary group SID, this parameter can be NULL.</param>
        /// <param name="pDacl">A pointer to the new DACL for the object. The SecurityInfo parameter must include the DACL_SECURITY_INFORMATION flag. The caller must have WRITE_DAC access to the object or be the owner of the object. If you are not setting the DACL, this parameter can be NULL.</param>
        /// <param name="pSacl">A pointer to the new SACL for the object. The SecurityInfo parameter must include any of the following flags: SACL_SECURITY_INFORMATION, LABEL_SECURITY_INFORMATION, ATTRIBUTE_SECURITY_INFORMATION, SCOPE_SECURITY_INFORMATION, or BACKUP_SECURITY_INFORMATION.</param>
        /// <returns>If the function succeeds, the return value is <see cref="Win32ErrorCode.ERROR_SUCCESS"/>, otherwise it return one of the default error codes.</returns>
        [DllImport(nameof(AdvApi32), CharSet = CharSet.Unicode, SetLastError = true)]
        public static unsafe extern uint SetNamedSecurityInfo(
            string pObjectName,
            SE_OBJECT_TYPE ObjectType,
            SECURITY_INFORMATION SecurityInfo,
            void* psidOwner,
            void* psidGroup,
            [Friendly(FriendlyFlags.Out | FriendlyFlags.Optional)] Kernel32.ACL* pDacl,
            [Friendly(FriendlyFlags.Out | FriendlyFlags.Optional)] Kernel32.ACL* pSacl);

        /// <summary>
        /// The DuplicateTokenEx function creates a new access token that duplicates an existing token.
        /// This function can create either a primary token or an impersonation token.
        /// </summary>
        /// <param name="hExistingToken">A handle to an access token opened with <see cref="TokenAccessRights.TOKEN_DUPLICATE"/>
        /// access.</param>
        /// <param name="dwDesiredAccess">Specifies the requested access rights for the new token. The <see cref="DuplicateTokenEx(SafeObjectHandle, ACCESS_MASK, SECURITY_ATTRIBUTES*, SECURITY_IMPERSONATION_LEVEL, TOKEN_TYPE, out SafeObjectHandle)"/> function
        /// compares the requested access rights with the existing token's discretionary access control list (DACL) to determine
        /// which rights are granted or denied. To request the same access rights as the existing token, specify zero. To request
        /// all access rights that are valid for the caller, specify <see cref="ACCESS_MASK.SpecialRight.MAXIMUM_ALLOWED"/>.</param>
        /// <param name="lpTokenAttributes">A pointer to a <see cref="SECURITY_ATTRIBUTES"/> structure that specifies a security
        /// descriptor for the new token and determines whether child processes can inherit the token.
        /// If lpTokenAttributes is NULL, the token gets a default security descriptor and the handle cannot be inherited.
        /// If the security descriptor contains a system access control list (SACL), the token gets
        /// <see cref="ACCESS_MASK.SpecialRight.ACCESS_SYSTEM_SECURITY"/> access right, even if it was not requested in dwDesiredAccess.
        /// To set the owner in the security descriptor for the new token, the caller's process token must have the SE_RESTORE_NAME
        /// privilege set.</param>
        /// <param name="ImpersonationLevel">Specifies a value from the <see cref="SECURITY_IMPERSONATION_LEVEL"/>
        /// enumeration that indicates the impersonation level of the new token.</param>
        /// <param name="TokenType">pecifies one of the following values from the <see cref="TokenType"/> enumeration.</param>
        /// <param name="phNewToken">A pointer to a <see cref="SafeObjectHandle"/> variable that receives the new token.</param>
        /// <returns>If the function succeeds, the function returns a nonzero value.
        /// If the function fails, it returns zero.To get extended error information, call GetLastError.</returns>
        [DllImport(api_ms_win_security_base_l1_2_0, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static unsafe extern bool DuplicateTokenEx(
            SafeObjectHandle hExistingToken,
            ACCESS_MASK dwDesiredAccess,
            [Friendly(FriendlyFlags.In | FriendlyFlags.Optional)] SECURITY_ATTRIBUTES* lpTokenAttributes,
            SECURITY_IMPERSONATION_LEVEL ImpersonationLevel,
            TOKEN_TYPE TokenType,
            out SafeObjectHandle phNewToken);

        /// <summary>
        /// The ConvertSidToStringSid function converts a security identifier (SID) to a string format suitable for display, storage, or transmission.
        /// To convert the string-format SID back to a valid, functional SID, call the <see cref="ConvertStringSidToSid(string, ref void*)"/> function.
        /// </summary>
        /// <param name="sid">A pointer to the SID structure to be converted.</param>
        /// <param name="sidString">A pointer to a variable that receives a pointer to a null-terminated SID string. To free the returned buffer, call the <see cref="LocalFree(void*)"/> function.</param>
        /// <returns>If the function succeeds, the return value is true, otherwise the return value is false.</returns>
        /// <remarks>The ConvertSidToStringSid function uses the standard S-R-I-S-S… format for SID strings.</remarks>
        [DllImport(nameof(AdvApi32), CharSet = CharSet.Unicode, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static unsafe extern bool ConvertSidToStringSid(
            IntPtr sid,
            ref char* sidString);

        /// <summary>
        /// The ConvertStringSidToSid function converts a string-format security identifier (SID) into a valid, functional SID.
        /// You can use this function to retrieve a SID that the <see cref="ConvertSidToStringSid(IntPtr, ref char*)"/> function converted to string format.
        /// </summary>
        /// <param name="StringSid">The string-format SID to convert. The SID string can use either the standard S-R-I-S-S… format for SID strings, or the SID string constant format, such as "BA" for built-in administrators.</param>
        /// <param name="sid">A pointer to a variable that receives a pointer to the converted SID. To free the returned buffer, call the <see cref="LocalFree(void*)"/> function.</param>
        /// <returns>If the function succeeds, the return value is true, otherwise the return value is false.</returns>
        [DllImport(nameof(AdvApi32), CharSet = CharSet.Unicode, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static unsafe extern bool ConvertStringSidToSid(string StringSid, ref void* sid);

        /// <summary>
        /// Closes a handle to a service control manager or service object.
        /// </summary>
        /// <param name="hSCObject">
        /// A handle to the service control manager object or the service object to close.
        /// Handles to service control manager objects are returned by the <see cref="OpenSCManager"/> function,
        /// and handles to service objects are returned by either the <see cref="OpenService"/> or <see cref="CreateService(SafeServiceHandle,string,string,ACCESS_MASK,ServiceType,ServiceStartType,ServiceErrorControl,string,string,int, string,string,string)"/> function.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is nonzero.
        /// If the function fails, the return value is zero.
        /// </returns>
        [DllImport(api_ms_win_service_management_l1_1_0, SetLastError = true)]
        private static extern bool CloseServiceHandle(IntPtr hSCObject);

        /// <summary>
        /// Releases the handle of a cryptographic service provider (CSP) and a key container. At each call to this function, the reference count on the CSP is reduced by one.
        /// When the reference count reaches zero, the context is fully released and it can  no longer be used by any function in the application.
        /// An application calls this function after finishing the use of the CSP. After this function is called,
        /// the released CSP handle is no longer valid.This function does not destroy key containers or key pairs.
        /// </summary>
        /// <param name="hProv">Handle of a cryptographic service provider (CSP) created by a call to CryptAcquireContext.</param>
        /// <param name="dwFlags">Reserved for future use and must be zero. If dwFlags is not set to zero, this function returns FALSE but the CSP is released.</param>
        /// <returns>
        /// If the function succeeds, the return value is nonzero.
        /// If the function fails, the return value is zero.
        /// </returns>
        [DllImport(api_ms_win_service_management_l1_1_0, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool CryptReleaseContext(IntPtr hProv, uint dwFlags);
    }
}
