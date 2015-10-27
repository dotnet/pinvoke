// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;

    /// <content>
    /// Methods and nested types that are not strictly P/Invokes but provide
    /// a slightly higher level of functionality to ease calling into native code.
    /// </content>
    public static partial class SetupApi
    {
        private static readonly Lazy<int> DeviceInterfaceDetailDataSize = new Lazy<int>(() =>
        {
            // The structure size take into account an Int32 and a character
            switch (IntPtr.Size)
            {
                case 4: // 32-bits
                    // The character can be 1 or 2 octets depending on ANSI / Unicode
                    return 4 + Marshal.SystemDefaultCharSize;
                case 8: // 64-bits
                    // Due to alignment, the size is always the same
                    return 8;
                default:
                    throw new NotSupportedException("Non 32 or 64-bits windows aren't supported");
            }
        });

        public static SafeDeviceInfoSetHandle SetupDiGetClassDevs(
            Guid? classGuid,
            string enumerator,
            IntPtr hwndParent,
            GetClassDevsFlags flags)
        {
            using (var pinnedClassGuid = classGuid.Pin())
            {
                return SetupDiGetClassDevs(pinnedClassGuid.IntPtr, enumerator, hwndParent, flags);
            }
        }

        public static IEnumerable<DeviceInterfaceData> SetupDiEnumDeviceInterfaces(
            SafeDeviceInfoSetHandle lpDeviceInfoSet,
            DeviceInfoData? deviceInfoData,
            Guid interfaceClassGuid)
        {
            using (var pinnedDeviceInfoData = deviceInfoData.Pin())
            {
                uint index = 0;
                while (true)
                {
                    var data = DeviceInterfaceData.Create();

                    var result = SetupDiEnumDeviceInterfaces(
                        lpDeviceInfoSet,
                        pinnedDeviceInfoData.IntPtr,
                        ref interfaceClassGuid,
                        index,
                        ref data);

                    if (!result)
                    {
                        var lastError = (Win32ErrorCode)Marshal.GetLastWin32Error();
                        if (lastError != Win32ErrorCode.ERROR_NO_MORE_ITEMS)
                        {
                            Marshal.ThrowExceptionForHR(Marshal.GetHRForLastWin32Error());
                        }

                        yield break;
                    }

                    yield return data;
                    index++;
                }
            }
        }

        public static string SetupDiGetDeviceInterfaceDetail(
            SafeDeviceInfoSetHandle lpDeviceInfoSet,
            DeviceInterfaceData oInterfaceData,
            IntPtr lpDeviceInfoData)
        {
            using (var requiredSize = new PinnedStruct<uint>(0))
            {
                // First call to get the size to allocate
                SetupDiGetDeviceInterfaceDetail(
                    lpDeviceInfoSet,
                    ref oInterfaceData,
                    IntPtr.Zero,
                    0,
                    requiredSize.IntPtr,
                    IntPtr.Zero);

                var lastError = (Win32ErrorCode)Marshal.GetLastWin32Error();

                if (lastError != Win32ErrorCode.ERROR_INSUFFICIENT_BUFFER)
                {
                    Marshal.ThrowExceptionForHR(Marshal.GetHRForLastWin32Error());
                    return null;
                }

                var buffer = Marshal.AllocHGlobal((int)requiredSize.Value);

                try
                {
                    Marshal.WriteInt32(buffer, DeviceInterfaceDetailDataSize.Value);

                    // Second call to get the value
                    var success = SetupDiGetDeviceInterfaceDetail(
                        lpDeviceInfoSet,
                        ref oInterfaceData,
                        buffer,
                        requiredSize.Value,
                        IntPtr.Zero,
                        IntPtr.Zero);

                    if (!success)
                    {
                        Marshal.ThrowExceptionForHR(Marshal.GetHRForLastWin32Error());
                        return null;
                    }

                    var strPtr = new IntPtr(buffer.ToInt64() + 4);
                    return Marshal.PtrToStringAuto(strPtr);
                }
                finally
                {
                    Marshal.FreeHGlobal(buffer);
                }
            }
        }
    }
}