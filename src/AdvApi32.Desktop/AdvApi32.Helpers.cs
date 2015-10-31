// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.ComponentModel;
    using System.Runtime.InteropServices;

    /// <content>
    /// Methods and nested types that are not strictly P/Invokes but provide
    /// a slightly higher level of functionality to ease calling into native code.
    /// </content>
    public static partial class AdvApi32
    {
        public static void InstallService(string servicePath, string serviceName, string serviceDisplayName, string serviceDescription, string userName, string password)
        {
            IntPtr hSCManager = OpenSCManager(null, null, ServiceManagerAccess.SC_MANAGER_CREATE_SERVICE);

            if (hSCManager == IntPtr.Zero)
            {
                throw new Win32Exception(Marshal.GetHRForLastWin32Error());
            }

            IntPtr svcHandle = CreateService(
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

            if (svcHandle == IntPtr.Zero)
            {
                throw new Win32Exception(Marshal.GetHRForLastWin32Error());
            }

            ServiceDescription descriptionStruct = new ServiceDescription
            {
                lpDescription = serviceDescription
            };

            IntPtr lpInfo = Marshal.AllocHGlobal(Marshal.SizeOf(descriptionStruct));

            if (lpInfo == IntPtr.Zero)
            {
                throw new Win32Exception(Marshal.GetHRForLastWin32Error());
            }

            Marshal.StructureToPtr(descriptionStruct, lpInfo, false);

            if (!ChangeServiceConfig2(svcHandle, ServiceInfoLevel.SERVICE_CONFIG_DESCRIPTION, lpInfo))
            {
                Marshal.FreeHGlobal(lpInfo);
                throw new Win32Exception(Marshal.GetHRForLastWin32Error());
            }

            Marshal.FreeHGlobal(lpInfo);

            if (svcHandle == IntPtr.Zero)
            {
                throw new Win32Exception(Marshal.GetHRForLastWin32Error());
            }

            if (CloseServiceHandle(svcHandle) == IntPtr.Zero)
            {
                throw new Win32Exception(Marshal.GetHRForLastWin32Error());
            }
        }

        public static void UninstallService(string serviceName)
        {
            IntPtr scmHandle = OpenSCManager(null, null, ServiceManagerAccess.GenericWrite);

            if (scmHandle == IntPtr.Zero)
            {
                throw new Win32Exception(Marshal.GetHRForLastWin32Error());
            }

            IntPtr svcHandle = OpenService(scmHandle, serviceName, ServiceAccess.Delete);
            if (svcHandle == IntPtr.Zero)
            {
                throw new Win32Exception(Marshal.GetHRForLastWin32Error());
            }

            if (DeleteService(svcHandle) == IntPtr.Zero)
            {
                throw new Win32Exception(Marshal.GetHRForLastWin32Error());
            }

            if (CloseServiceHandle(scmHandle) == IntPtr.Zero)
            {
                throw new Win32Exception(Marshal.GetHRForLastWin32Error());
            }
        }
    }
}
