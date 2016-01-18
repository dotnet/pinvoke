// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
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
        public static unsafe IEnumerable<ENUM_SERVICE_STATUS> EnumServicesStatus()
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
                if (EnumServicesStatus(
                    scmHandle,
                    ServiceType.SERVICE_WIN32,
                    ServiceStateQuery.SERVICE_STATE_ALL,
                    IntPtr.Zero,
                    0,
                    ref bufferSizeNeeded,
                    ref numServicesReturned,
                    ref resumeIndex))
                {
                    return Enumerable.Empty<ENUM_SERVICE_STATUS>();
                }

                var lastError = GetLastError();
                if (lastError != Win32ErrorCode.ERROR_MORE_DATA)
                {
                    throw new Win32Exception(lastError);
                }

                fixed (byte* buffer = new byte[bufferSizeNeeded])
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

                    var result = new ENUM_SERVICE_STATUS[numServicesReturned];
                    byte* position = buffer;
                    int structSize = Marshal.SizeOf(typeof(ENUM_SERVICE_STATUS));
                    for (int i = 0; i < numServicesReturned; i++)
                    {
                        result[i] = (ENUM_SERVICE_STATUS)Marshal.PtrToStructure(new IntPtr(position), typeof(ENUM_SERVICE_STATUS));
                        position += structSize;
                    }

                    return result;
                }
            }
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
            int bufSizeNeeded;
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
