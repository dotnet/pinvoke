// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    using static Kernel32;

    /// <content>
    /// Methods and nested types that are not strictly P/Invokes but provide
    /// a slightly higher level of functionality to ease calling into native code.
    /// </content>
    public static partial class SetupApi
    {
        public static SafeDeviceInfoSetHandle SetupDiGetClassDevs(
            Guid? classGuid,
            string enumerator,
            IntPtr hwndParent,
            GetClassDevsFlags flags)
        {
            var result = SetupDiGetClassDevs((NullableGuid)classGuid, enumerator, hwndParent, flags);
            if (result.IsInvalid)
            {
                throw new Win32Exception();
            }

            return result;
        }

        public static unsafe IEnumerable<SP_DEVICE_INTERFACE_DATA> SetupDiEnumDeviceInterfaces(
            SafeDeviceInfoSetHandle lpDeviceInfoSet,
            SP_DEVINFO_DATA* deviceInfoData,
            Guid interfaceClassGuid)
        {
            return SetupDiEnumDeviceInterfacesHelper(lpDeviceInfoSet, new IntPtr(deviceInfoData), interfaceClassGuid);
        }

        public static unsafe string SetupDiGetDeviceInterfaceDetail(
            SafeDeviceInfoSetHandle deviceInfoSet,
            SP_DEVICE_INTERFACE_DATA interfaceData,
            SP_DEVINFO_DATA* deviceInfoData)
        {
            int requiredSize;

            // First call to get the size to allocate
            SetupDiGetDeviceInterfaceDetail(
                deviceInfoSet,
                ref interfaceData,
                null,
                0,
                &requiredSize,
                deviceInfoData);

            // As we passed an empty buffer we know that the function will fail, not need to check the result.
            var lastError = GetLastError();
            if (lastError != Win32ErrorCode.ERROR_INSUFFICIENT_BUFFER)
            {
                throw new Win32Exception(lastError);
            }

            fixed (byte* pBuffer = new byte[requiredSize])
            {
                var pDetail = (SP_DEVICE_INTERFACE_DETAIL_DATA*)pBuffer;
                pDetail->cbSize = SP_DEVICE_INTERFACE_DETAIL_DATA.ReportableStructSize;

                // Second call to get the value
                var success = SetupDiGetDeviceInterfaceDetail(
                    deviceInfoSet,
                    ref interfaceData,
                    pDetail,
                    requiredSize,
                    null,
                    null);

                if (!success)
                {
                    Marshal.ThrowExceptionForHR(Marshal.GetHRForLastWin32Error());
                    return null;
                }

                return SP_DEVICE_INTERFACE_DETAIL_DATA.GetDevicePath(pDetail);
            }
        }

        private static IEnumerable<SP_DEVICE_INTERFACE_DATA> SetupDiEnumDeviceInterfacesHelper(
            SafeDeviceInfoSetHandle lpDeviceInfoSet,
            IntPtr deviceInfoData,
            Guid interfaceClassGuid)
        {
            int index = 0;
            while (true)
            {
                var data = SP_DEVICE_INTERFACE_DATA.Create();

                var result = SetupDiEnumDeviceInterfaces(
                    lpDeviceInfoSet,
                    deviceInfoData,
                    ref interfaceClassGuid,
                    index,
                    ref data);

                if (!result)
                {
                    var lastError = GetLastError();
                    if (lastError != Win32ErrorCode.ERROR_NO_MORE_ITEMS)
                    {
                        throw new Win32Exception(lastError);
                    }

                    yield break;
                }

                yield return data;
                index++;
            }
        }
    }
}