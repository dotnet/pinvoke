// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Runtime.InteropServices;
    using static Kernel32;

    /// <content>
    /// Methods and nested types that are not strictly P/Invokes but provide
    /// a slightly higher level of functionality to ease calling into native code.
    /// </content>
    public static partial class AdvApi32
    {
        /// <summary>
        /// Creates a service object and adds it to service control manager database o the local computer.
        /// </summary>
        /// <param name="lpBinaryPathName">
        /// The fully qualified path to the service binary file. If the path contains a space, it must be quoted so that it is correctly interpreted.
        /// For example, "d:\\my share\\myservice.exe" should be specified as "\"d:\\my share\\myservice.exe\"".
        /// The path can also include arguments for an auto-start service.
        /// For example, "d:\\myshare\\myservice.exe arg1 arg2".
        /// These arguments are passed to the service entry point (typically the main function).
        /// </param>
        /// <param name="lpServiceName">
        /// The name of the service to install. The maximum string length is 256 characters.
        /// The service control manager database preserves the case of the characters, but service name comparisons are always case insensitive.
        /// Forward-slash (/) and backslash (\) are not valid service name characters.
        /// </param>
        /// <param name="lpDisplayName">
        /// The display name to be used by user interface programs to identify the service.
        /// This string has a maximum length of 256 characters. The name is case-preserved in the service control manager.
        /// Display name comparisons are always case-insensitive.
        /// </param>
        /// <param name="lpDescription">
        /// The description of the service. If this member is NULL, the description remains unchanged.
        /// If this value is an empty string (""), the current description is deleted.
        /// The service description must not exceed the size of a registry value of type REG_SZ.
        /// </param>
        /// <param name="lpServiceStartName">
        /// The name of the account under which the service should run.
        /// Use an account name in the form DomainName\UserName. The service process will be logged on as this user.
        /// If the account belongs to the built-in domain, you can specify .\UserName.
        /// </param>
        /// <param name="lpPassword">
        /// The password to the account name specified by the lpServiceStartName parameter.
        /// Specify an empty string if the account has no password or if the service runs in the LocalService, NetworkService, or LocalSystem account.
        /// If the account name specified by the <paramref name="lpServiceStartName"/> parameter is the name of a managed service account or virtual account name, the lpPassword parameter must be NULL.
        /// </param>
        /// <exception cref="Win32Exception">If the method fails, returning the calling thread's last-error code value.</exception>
        /// <exception cref="ArgumentException"><paramref name="lpServiceName" /> or <paramref name="lpBinaryPathName"/> are NULL or empty string.</exception>
        public static void CreateService(string lpBinaryPathName, string lpServiceName, string lpDisplayName, string lpDescription, string lpServiceStartName, string lpPassword)
        {
            if (string.IsNullOrWhiteSpace(lpBinaryPathName))
            {
                throw new ArgumentException("Binary path name must not be null nor empty", nameof(lpBinaryPathName));
            }

            if (string.IsNullOrWhiteSpace(lpServiceName))
            {
                throw new ArgumentException("Service name must not be null nor empty", nameof(lpServiceName));
            }

            using (SafeServiceHandle scmHandle = OpenSCManager(null, null, ServiceManagerAccess.SC_MANAGER_CREATE_SERVICE))
            {
                if (scmHandle.IsInvalid)
                {
                    throw new Win32Exception();
                }

                SafeServiceHandle svcHandle = CreateService(
                    scmHandle,
                    lpServiceName,
                    lpDisplayName,
                    ServiceAccess.SERVICE_ALL_ACCESS,
                    ServiceType.SERVICE_WIN32_OWN_PROCESS,
                    ServiceStartType.SERVICE_DEMAND_START,
                    ServiceErrorControl.SERVICE_ERROR_NORMAL,
                    lpBinaryPathName,
                    null,
                    0,
                    null,
                    lpServiceStartName,
                    lpPassword);

                using (svcHandle)
                {
                    if (svcHandle.IsInvalid)
                    {
                        throw new Win32Exception();
                    }

                    ServiceDescription descriptionStruct = new ServiceDescription
                    {
                        lpDescription = lpDescription
                    };

                    IntPtr lpInfo = Marshal.AllocHGlobal(Marshal.SizeOf(descriptionStruct));

                    try
                    {
                        Marshal.StructureToPtr(descriptionStruct, lpInfo, false);
                        if (!ChangeServiceConfig2(svcHandle, ServiceInfoLevel.SERVICE_CONFIG_DESCRIPTION, lpInfo))
                        {
                            throw new Win32Exception();
                        }
                    }
                    finally
                    {
                        Marshal.DestroyStructure(lpInfo, typeof(ServiceDescription));
                        Marshal.FreeHGlobal(lpInfo);
                    }
                }
            }
        }

        /// <summary>
        /// Marks the specified service for deletion from the service control manager database on the local computer.
        /// </summary>
        /// <param name="lpServiceName">
        /// The name of the service to be opened. This is the name specified by the lpServiceName parameter of the <see cref="CreateService(SafeServiceHandle,string,string,ServiceAccess,ServiceType,ServiceStartType,ServiceErrorControl,string,string,int, string,string,string)"/> function when the service object was created,
        /// not the service display name that is shown by user interface applications to identify the service.
        /// The maximum string length is 256 characters. The service control manager database preserves the case of the characters,
        /// but service name comparisons are always case insensitive. Forward-slash (/) and backslash (\) are invalid service name characters.
        /// </param>
        /// <exception cref="Win32Exception">If the method fails, returning the calling thread's last-error code value.</exception>
        /// <exception cref="ArgumentException"><paramref name="lpServiceName" /> is NULL or an empty string.</exception>
        public static void DeleteService(string lpServiceName)
        {
            if (string.IsNullOrWhiteSpace(lpServiceName))
            {
                throw new ArgumentException("Service name must not be null nor empty", nameof(lpServiceName));
            }

            using (SafeServiceHandle scmHandle = OpenSCManager(null, null, ServiceManagerAccess.GenericWrite))
            {
                if (scmHandle.IsInvalid)
                {
                    throw new Win32Exception();
                }

                using (SafeServiceHandle svcHandle = OpenService(scmHandle, lpServiceName, ServiceAccess.Delete))
                {
                    if (svcHandle.IsInvalid)
                    {
                        throw new Win32Exception();
                    }

                    if (!DeleteService(svcHandle))
                    {
                        throw new Win32Exception();
                    }
                }
            }
        }

        /// <summary>Get the elevation type of a token via <see cref="GetTokenInformation" />.</summary>
        /// <param name="TokenHandle">
        ///     A handle to an access token from which information is retrieved. The handle must have
        ///     TOKEN_QUERY access.
        /// </param>
        /// <returns>The token elevation type</returns>
        /// <exception cref="ArgumentNullException"><paramref name="TokenHandle" /> is NULL.</exception>
        /// <exception cref="Win32Exception">If the call to <see cref="GetTokenInformation" /> fails.</exception>
        public static TOKEN_ELEVATION_TYPE GetTokenElevationType(SafeObjectHandle TokenHandle)
        {
            if (TokenHandle == null)
            {
                throw new ArgumentNullException(nameof(TokenHandle));
            }

            var elevationType = default(TOKEN_ELEVATION_TYPE);

            bool success;
            unsafe
            {
                int returnLength;
                success = GetTokenInformation(
                    TokenHandle,
                    TOKEN_INFORMATION_CLASS.TokenElevationType,
                    &elevationType,
                    sizeof(TOKEN_ELEVATION_TYPE),
                    out returnLength);
            }

            if (!success)
            {
                throw new Win32Exception();
            }

            return elevationType;
        }
    }
}
