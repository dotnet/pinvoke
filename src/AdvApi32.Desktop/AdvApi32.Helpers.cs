// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Runtime.InteropServices;
    using System.Security.AccessControl;
    using static Kernel32;

    /// <content>
    /// Methods and nested types that are not strictly P/Invokes but provide
    /// a slightly higher level of functionality to ease calling into native code.
    /// </content>
    public static partial class AdvApi32
    {
        /// <summary>
        /// Enumerates services in the specified service control manager database.
        /// The name and status of each service are provided.
        /// </summary>
        /// <returns>
        /// An IEnumerable of <see cref="ENUM_SERVICE_STATUS"/> structures that receive the name and service status information for each service in the database.
        /// </returns>
        /// <exception cref="Win32Exception">If the method fails, returning the calling thread's last-error code value.</exception>
        public static IEnumerable<ENUM_SERVICE_STATUS> EnumServicesStatus()
        {
            using (var scmHandle = OpenSCManager(null, null, ServiceManagerAccess.SC_MANAGER_ENUMERATE_SERVICE))
            {
                if (scmHandle.IsInvalid)
                {
                    throw new Win32Exception();
                }

                int bufferSizeNeeded = 0;
                int numServicesReturned = 0;
                int resumeIndex = 0;
                if (!EnumServicesStatus(
                    scmHandle,
                    ServiceType.SERVICE_WIN32,
                    ServiceStateQuery.SERVICE_STATE_ALL,
                    IntPtr.Zero,
                    0,
                    ref bufferSizeNeeded,
                    ref numServicesReturned,
                    ref resumeIndex))
                {
                    var lastError = GetLastError();
                    if (lastError != Win32ErrorCode.ERROR_MORE_DATA)
                    {
                        throw new Win32Exception(lastError);
                    }

                    IntPtr buffer = Marshal.AllocHGlobal(bufferSizeNeeded);

                    try
                    {
                        if (!EnumServicesStatus(
                                    scmHandle,
                                    ServiceType.SERVICE_WIN32,
                                    ServiceStateQuery.SERVICE_STATE_ALL,
                                    buffer,
                                    bufferSizeNeeded,
                                    ref bufferSizeNeeded,
                                    ref numServicesReturned,
                                    ref resumeIndex))
                        {
                            throw new Win32Exception();
                        }

                        int possition = buffer.ToInt32();
                        for (int i = 0; i < numServicesReturned; i++)
                        {
                            var serviceStatus = (ENUM_SERVICE_STATUS)Marshal.PtrToStructure(new IntPtr(possition), typeof(ENUM_SERVICE_STATUS));
                            possition += Marshal.SizeOf(serviceStatus);
                            yield return serviceStatus;
                        }
                    }
                    finally
                    {
                        Marshal.FreeHGlobal(buffer);
                    }
                }
            }
        }

        /// <summary>
        /// Creates a service object and adds it to service control manager database o the local computer.
        /// </summary>
        /// <param name="lpBinaryPathName">
        /// The fully qualified path to the service binary file. If the path contains a space, it must be quoted so that it is correctly interpreted.
        /// For example, "d:\\my share\\myservice.exe" should be specified as "\"d:\\my share\\myservice.exe\"".
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
        /// <exception cref="ArgumentNullException"><paramref name="lpServiceName" /> or <paramref name="lpBinaryPathName"/> are NULL or empty string.</exception>
        /// <exception cref="FileNotFoundException"><paramref name="lpBinaryPathName"/> cannot be found.</exception>
        public static void CreateService(string lpBinaryPathName, string lpServiceName, string lpDisplayName, string lpDescription, string lpServiceStartName, string lpPassword)
        {
            if (lpBinaryPathName == null)
            {
                throw new ArgumentNullException(nameof(lpBinaryPathName));
            }

            if (lpBinaryPathName.Trim() == string.Empty)
            {
                throw new ArgumentException("Cannot be empty", nameof(lpBinaryPathName));
            }

            if (!File.Exists(lpBinaryPathName))
            {
                throw new FileNotFoundException("Cannot find the file.", lpBinaryPathName);
            }

            if (lpServiceName == null)
            {
                throw new ArgumentNullException(nameof(lpServiceName));
            }

            if (lpServiceName.Trim() == string.Empty)
            {
                throw new ArgumentException(nameof(lpServiceName));
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
        /// <exception cref="ArgumentNullException"><paramref name="lpServiceName" /> is NULL or an empty string.</exception>
        public static void DeleteService(string lpServiceName)
        {
            if (string.IsNullOrWhiteSpace(lpServiceName))
            {
                throw new ArgumentNullException(nameof(lpServiceName));
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
                uint returnLength;
                success = GetTokenInformation(
                    TokenHandle,
                    TOKEN_INFORMATION_CLASS.TokenElevationType,
                    &elevationType,
                    (uint)sizeof(TOKEN_ELEVATION_TYPE),
                    out returnLength);
            }

            if (!success)
            {
                throw new Win32Exception();
            }

            return elevationType;
        }

        /// <summary>
        ///     Retrieves a copy of the security descriptor associated with a service object. You can also use the
        ///     GetNamedSecurityInfo function to retrieve a security descriptor.
        /// </summary>
        /// <param name="hService">
        ///     A handle to the service control manager or the service. Handles to the service control manager
        ///     are returned by the <see cref="OpenSCManager" /> function, and handles to a service are returned by either the
        ///     <see cref="OpenService" /> or <see cref="CreateService(SafeServiceHandle,string,string,ServiceAccess,ServiceType,ServiceStartType,ServiceErrorControl,string,string,int, string,string,string)" /> function. The handle must have the READ_CONTROL access
        ///     right.
        /// </param>
        /// <param name="dwSecurityInformation">
        ///     A set of bit flags that indicate the type of security information to retrieve. This
        ///     parameter can be a combination of the <see cref="SECURITY_INFORMATION" /> flags, with the exception that this
        ///     function does not support the <see cref="SECURITY_INFORMATION.LABEL_SECURITY_INFORMATION" /> value.
        /// </param>
        /// <returns>
        ///     A copy of the security descriptor of the specified service object. The calling process must have the
        ///     appropriate access to view the specified aspects of the security descriptor of the object.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="hService" /> is NULL.</exception>
        /// <exception cref="Win32Exception">If the call to the native method fails fails.</exception>
        public static RawSecurityDescriptor QueryServiceObjectSecurity(SafeServiceHandle hService, SECURITY_INFORMATION dwSecurityInformation)
        {
            if (hService == null)
            {
                throw new ArgumentNullException(nameof(hService));
            }

            var securityDescriptor = new byte[0];
            uint bufSizeNeeded;
            QueryServiceObjectSecurity(hService, dwSecurityInformation, securityDescriptor, 0, out bufSizeNeeded);

            var lastError = GetLastError();
            if (lastError != Win32ErrorCode.ERROR_INSUFFICIENT_BUFFER)
            {
                throw new Win32Exception(lastError);
            }

            securityDescriptor = new byte[bufSizeNeeded];
            var success = QueryServiceObjectSecurity(hService, dwSecurityInformation, securityDescriptor, bufSizeNeeded, out bufSizeNeeded);

            if (!success)
            {
                throw new Win32Exception();
            }

            return new RawSecurityDescriptor(securityDescriptor, 0);
        }

        /// <summary>The SetServiceObjectSecurity function sets the security descriptor of a service object.</summary>
        /// <param name="hService">
        ///     A handle to the service. This handle is returned by the <see cref="OpenService" /> or
        ///     <see cref="CreateService(SafeServiceHandle,string,string,ServiceAccess,ServiceType,ServiceStartType,ServiceErrorControl,string,string,int, string,string,string)" /> function. The access required for this handle depends on the security information
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
        /// <param name="lpSecurityDescriptor">The new security information.</param>
        public static void SetServiceObjectSecurity(
            SafeServiceHandle hService,
            SECURITY_INFORMATION dwSecurityInformation,
            RawSecurityDescriptor lpSecurityDescriptor)
        {
            var binaryForm = new byte[lpSecurityDescriptor.BinaryLength];
            lpSecurityDescriptor.GetBinaryForm(binaryForm, 0);
            if (!SetServiceObjectSecurity(hService, dwSecurityInformation, binaryForm))
            {
                throw new Win32Exception();
            }
        }
    }
}
