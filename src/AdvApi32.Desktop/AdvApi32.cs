// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Runtime.InteropServices;

    /// <content>
    /// Exported functions from the AdvApi32.dll Windows library
    /// that are available to Desktop apps only.
    /// </content>
    public static partial class AdvApi32
    {
        /// <summary>
        /// Describes service manager access flags.
        /// </summary>
        [Flags]
        public enum ServiceManagerAccess : uint
        {
            GenericRead = 0x80000000,
            GenericWrite = 0x40000000,
            GenericExecute = 0x20000000,

            AccessSystemSecurity = 0x1000000,
            Delete = 0x10000,
            ReadControl = 0x20000,
            WriteDAC = 0x40000,
            WriteOwner = 0x80000,

            STANDARD_RIGHTS_REQUIRED = 0xF0000,

            SC_MANAGER_CONNECT = 0x0001,
            SC_MANAGER_CREATE_SERVICE = 0x0002,
            SC_MANAGER_ENUMERATE_SERVICE = 0x0004,
            SC_MANAGER_LOCK = 0x0008,
            SC_MANAGER_QUERY_LOCK_STATUS = 0x0010,
            SC_MANAGER_MODIFY_BOOT_CONFIG = 0x0020,
            SC_MANAGER_ALL_ACCESS = STANDARD_RIGHTS_REQUIRED |
                                        SC_MANAGER_CONNECT |
                                        SC_MANAGER_CREATE_SERVICE |
                                        SC_MANAGER_ENUMERATE_SERVICE |
                                        SC_MANAGER_LOCK |
                                        SC_MANAGER_QUERY_LOCK_STATUS |
                                        SC_MANAGER_MODIFY_BOOT_CONFIG
        }

        /// <summary>
        /// Describes service access flags.
        /// </summary>
        [Flags]
        public enum ServiceAccess : uint
        {
            GenericRead = 0x80000000,
            GenericWrite = 0x40000000,
            GenericExecute = 0x20000000,

            AccessSystemSecurity = 0x1000000,
            Delete = 0x10000,
            ReadControl = 0x20000,
            WriteDAC = 0x40000,
            WriteOwner = 0x80000,

            STANDARD_RIGHTS_REQUIRED = 0xF0000,

            SERVICE_QUERY_CONFIG = 0x0001,
            SERVICE_CHANGE_CONFIG = 0x0002,
            SERVICE_QUERY_STATUS = 0x0004,
            SERVICE_ENUMERATE_DEPENDENTS = 0x0008,
            SERVICE_START = 0x0010,
            SERVICE_STOP = 0x0020,
            SERVICE_PAUSE_CONTINUE = 0x0040,
            SERVICE_INTERROGATE = 0x0080,
            SERVICE_USER_DEFINED_CONTROL = 0x0100,
            SERVICE_ALL_ACCESS = STANDARD_RIGHTS_REQUIRED |
                                        SERVICE_QUERY_CONFIG |
                                        SERVICE_CHANGE_CONFIG |
                                        SERVICE_QUERY_STATUS |
                                        SERVICE_ENUMERATE_DEPENDENTS |
                                        SERVICE_START |
                                        SERVICE_STOP |
                                        SERVICE_PAUSE_CONTINUE |
                                        SERVICE_INTERROGATE |
                                        SERVICE_USER_DEFINED_CONTROL
        }

        /// <summary>
        /// Describes service type flags.
        /// </summary>
        [Flags]
        public enum ServiceType : uint
        {
            SERVICE_KERNEL_DRIVER = 0x00000001,
            SERVICE_FILE_SYSTEM_DRIVER = 0x00000002,
            SERVICE_ADAPTER = 0x00000004,
            SERVICE_RECOGNIZER_DRIVER = 0x00000008,
            SERVICE_WIN32_OWN_PROCESS = 0x00000010,
            SERVICE_WIN32_SHARE_PROCESS = 0x00000020,
            SERVICE_INTERACTIVE_PROCESS = 0x00000100
        }

        /// <summary>
        /// Describes service start type.
        /// </summary>
        public enum ServiceStartType : uint
        {
            SERVICE_BOOT_START,
            SERVICE_SYSTEM_START,
            SERVICE_AUTO_START,
            SERVICE_DEMAND_START,
            SERVICE_DISABLED
        }

        /// <summary>
        /// Describes the severity of the error, and action taken, if this service fails to start.
        /// </summary>
        public enum ServiceErrorControl : uint
        {
            SERVICE_ERROR_IGNORE,
            SERVICE_ERROR_NORMAL,
            SERVICE_ERROR_SEVERE,
            SERVICE_ERROR_CRITICAL
        }

        /// <summary>
        /// Describes the configuration information to be changed.
        /// </summary>
        public enum ServiceInfoLevel
        {
            SERVICE_CONFIG_DESCRIPTION = 1,
            SERVICE_CONFIG_FAILURE_ACTIONS,
            SERVICE_CONFIG_DELAYED_AUTO_START_INFO,
            SERVICE_CONFIG_FAILURE_ACTIONS_FLAG,
            SERVICE_CONFIG_SERVICE_SID_INFO,
            SERVICE_CONFIG_REQUIRED_PRIVILEGES_INFO,
            SERVICE_CONFIG_PRESHUTDOWN_INFO,
            SERVICE_CONFIG_TRIGGER_INFO,
            SERVICE_CONFIG_PREFERRED_NODE,
            SERVICE_CONFIG_LAUNCH_PROTECTED = 12
        }

        /// <summary>
        /// Changes the optional configuration parameters of a service.
        /// </summary>
        /// <param name="hService">
        /// A handle to the service.
        /// This handle is returned by the OpenService or CreateService function and
        /// must have the <see cref="ServiceAccess.SERVICE_CHANGE_CONFIG"/> access right.
        /// </param>
        /// <param name="dwInfoLevel">
        /// The configuration information to be changed.
        /// This parameter can be one value from <see cref="ServiceStartType"/>.
        /// </param>
        /// <param name="lpInfo">
        /// A pointer to the new value to be set for the configuration information. 
        /// The format of this data depends on the value of the dwInfoLevel parameter. 
        /// If this value is NULL, the information remains unchanged.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is nonzero.
        /// If the function fails, the return value is zero
        /// </returns>
        [DllImport(nameof(AdvApi32), SetLastError = true)]
        public static extern bool ChangeServiceConfig2(IntPtr hService, ServiceInfoLevel dwInfoLevel, IntPtr lpInfo);

        /// <summary>
        /// Closes a handle to a service control manager or service object.
        /// </summary>
        /// <param name="hSCObject">
        /// A handle to the service control manager object or the service object to close.
        /// Handles to service control manager objects are returned by the <see cref="OpenSCManager"/> function,
        /// and handles to service objects are returned by either the <see cref="OpenService"/> or <see cref="CreateService"/> function.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is nonzero.
        /// If the function fails, the return value is zero.
        /// </returns>
        [DllImport(nameof(AdvApi32), SetLastError = true)]
        public static extern IntPtr CloseServiceHandle(IntPtr hSCObject);

        /// <summary>
        /// Creates a service object and adds it to the specified service control manager database.
        /// </summary>
        /// <param name="hSCManager">
        /// A handle to the service control manager database. 
        /// This handle is returned by the OpenSCManager function and must have the <see cref="ServiceManagerAccess.SC_MANAGER_CREATE_SERVICE"/> access right.
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
        /// The access to the service (<see cref="ServiceAccess"/>).
        /// Before granting the requested access, the system checks the access token of the calling process.
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
        /// A pointer to a double null-terminated array of null-separated names of services or load ordering groups that the system must start before this service. Specify NULL or an empty string if the service has no dependencies. Dependency on a group means that this service can run if at least one member of the group is running after an attempt to start all members of the group.
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
        [DllImport(nameof(AdvApi32), SetLastError = true)]
        public static extern IntPtr CreateService(IntPtr hSCManager, string lpServiceName, string lpDisplayName, ServiceAccess dwDesiredAccess, ServiceType dwServiceType, ServiceStartType dwStartType, ServiceErrorControl dwErrorControl, string lpBinaryPathName, string lpLoadOrderGroup, int lpdwTagId, string lpDependencies, string lpServiceStartName, string lpPassword);

        /// <summary>
        /// Marks the specified service for deletion from the service control manager database.
        /// </summary>
        /// <param name="hService">
        /// A handle to the service. This handle is returned by the <see cref="OpenService"/> or <see cref="CreateService"/> function, and it must have the <see cref="ServiceAccess.Delete"/> access right
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is nonzero.
        /// If the function fails, the return value is zero
        /// </returns>
        [DllImport(nameof(AdvApi32), SetLastError = true)]
        public static extern IntPtr DeleteService(IntPtr hService);

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
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is a handle to the specified service control manager database.
        /// If the function fails, the return value is NULL.To get extended error information, call GetLastError.
        /// </returns>
        [DllImport(nameof(AdvApi32), SetLastError = true)]
        public static extern IntPtr OpenSCManager(string lpMachineName, string lpDatabaseName, ServiceManagerAccess dwDesiredAccess);

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
        /// The access to the service (<see cref="ServiceAccess"/>).
        /// Before granting the requested access, the system checks the access token of the calling process against the discretionary access-control list of the security descriptor associated with the service object.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is a handle to the service.
        /// If the function fails, the return value is NULL.
        /// </returns>
        [DllImport(nameof(AdvApi32), SetLastError = true)]
        public static extern IntPtr OpenService(IntPtr hSCManager, string lpServiceName, ServiceAccess dwDesiredAccess);

        /// <summary>
        /// Starts a service.
        /// </summary>
        /// <param name="hService">
        /// A handle to the service. This handle is returned by the <see cref="OpenService"/> or <see cref="CreateService"/> function, and it must have the <see cref="ServiceAccess.SERVICE_START"/> access right.
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
        [DllImport(nameof(AdvApi32), SetLastError = true)]
        public static extern IntPtr StartService(IntPtr hService, int dwNumServiceArgs, string lpServiceArgVectors);
    }
}
