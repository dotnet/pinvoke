// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Runtime.InteropServices;
    using System.Security.AccessControl;
    using static Kernel32;

    /// <content>
    /// Methods and nested types that are not strictly P/Invokes but provide
    /// a slightly higher level of functionality to ease calling into native code.
    /// </content>
    public static partial class AdvApi32
    {
        public static void InstallService(string servicePath, string serviceName, string serviceDisplayName, string serviceDescription, string userName, string password)
        {
            using (SafeServiceHandle hSCManager = OpenSCManager(null, null, ServiceManagerAccess.SC_MANAGER_CREATE_SERVICE))
            {
                if (hSCManager.IsInvalid)
                {
                    throw new Win32Exception();
                }

                SafeServiceHandle svcHandle = CreateService(
                    hSCManager,
                    serviceName,
                    serviceDisplayName,
                    ServiceAccess.SERVICE_ALL_ACCESS,
                    ServiceType.SERVICE_WIN32_OWN_PROCESS,
                    ServiceStartType.SERVICE_DEMAND_START,
                    ServiceErrorControl.SERVICE_ERROR_NORMAL,
                    servicePath,
                    null,
                    0,
                    null,
                    userName,
                    password);

                using (svcHandle)
                {
                    if (svcHandle.IsInvalid)
                    {
                        throw new Win32Exception();
                    }

                    ServiceDescription descriptionStruct = new ServiceDescription
                    {
                        lpDescription = serviceDescription
                    };

                    IntPtr lpInfo = Marshal.AllocHGlobal(Marshal.SizeOf(descriptionStruct));

                    if (lpInfo == IntPtr.Zero)
                    {
                        throw new Win32Exception();
                    }

                    Marshal.StructureToPtr(descriptionStruct, lpInfo, false);

                    if (!ChangeServiceConfig2(svcHandle, ServiceInfoLevel.SERVICE_CONFIG_DESCRIPTION, lpInfo))
                    {
                        Marshal.FreeHGlobal(lpInfo);
                        throw new Win32Exception();
                    }

                    Marshal.FreeHGlobal(lpInfo);

                    if (svcHandle.IsInvalid)
                    {
                        throw new Win32Exception();
                    }
                }
            }
        }

        public static void UninstallService(string serviceName)
        {
            using (SafeServiceHandle scmHandle = OpenSCManager(null, null, ServiceManagerAccess.GenericWrite))
            {
                if (scmHandle.IsInvalid)
                {
                    throw new Win32Exception();
                }

                using (SafeServiceHandle svcHandle = OpenService(scmHandle, serviceName, ServiceAccess.Delete))
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
        ///     <see cref="OpenService" /> or <see cref="CreateService" /> function. The handle must have the READ_CONTROL access
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
        ///     <see cref="CreateService" /> function. The access required for this handle depends on the security information
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
