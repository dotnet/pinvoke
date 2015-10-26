// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.ComponentModel;
    using System.Runtime.InteropServices;
    using System.Text;
    using Microsoft.Win32.SafeHandles;

    /// <content>
    /// Methods and nested types that are not strictly P/Invokes but provide
    /// a slightly higher level of functionality to ease calling into native code.
    /// </content>
    public static partial class Hid
    {
        public static Guid HidD_GetHidGuid()
        {
            Guid guid;
            HidD_GetHidGuid(out guid);
            return guid;
        }

        public static HiddAttributes HidD_GetAttributes(SafeFileHandle hFile)
        {
            var result = HiddAttributes.Create();
            if (!HidD_GetAttributes(hFile, ref result))
            {
                throw new Win32Exception();
            }

            return result;
        }

        public static SafePreparsedDataHandle HidD_GetPreparsedData(SafeFileHandle hDevice)
        {
            SafePreparsedDataHandle preparsedDataHandle;
            if (!HidD_GetPreparsedData(hDevice, out preparsedDataHandle))
            {
                throw new Win32Exception();
            }

            return preparsedDataHandle;
        }

        public static void HidD_SetNumInputBuffersEx(SafeFileHandle hidDeviceObject, uint numberBuffers)
        {
            if (!HidD_SetNumInputBuffers(hidDeviceObject, numberBuffers))
            {
                throw new Win32Exception();
            }
        }

        public static HidpCaps HidP_GetCaps(SafePreparsedDataHandle preparsedData)
        {
            var hidCaps = default(HidpCaps);
            var result = HidP_GetCaps(preparsedData, ref hidCaps);
            switch (result)
            {
                case NTStatus.HidpSuccess:
                    return hidCaps;

                case NTStatus.HidpInvalidPreparsedData:
                    throw new ArgumentException("The specified preparsed data is invalid.", nameof(preparsedData));

                default:
                    throw new InvalidOperationException("Undocumented status returned by HidP_GetCaps: " + result);
            }
        }

        public static bool HidD_GetManufacturerString(SafeFileHandle hidDeviceObject, out string result)
        {
            return GrowBuffer(sb => HidD_GetManufacturerString(hidDeviceObject, sb, sb.Capacity), out result);
        }

        public static bool HidD_GetProductString(SafeFileHandle hidDeviceObject, out string result)
        {
            return GrowBuffer(sb => HidD_GetProductString(hidDeviceObject, sb, sb.Capacity), out result);
        }

        public static bool HidD_GetSerialNumberString(SafeFileHandle hidDeviceObject, out string result)
        {
            return GrowBuffer(sb => HidD_GetSerialNumberString(hidDeviceObject, sb, sb.Capacity), out result);
        }

        public static string HidD_GetManufacturerString(SafeFileHandle hidDeviceObject)
        {
            string result;
            if (!HidD_GetManufacturerString(hidDeviceObject, out result))
            {
                throw new Win32Exception();
            }

            return result;
        }

        public static string HidD_GetProductString(SafeFileHandle hidDeviceObject)
        {
            string result;
            if (!HidD_GetProductString(hidDeviceObject, out result))
            {
                throw new Win32Exception();
            }

            return result;
        }

        public static string HidD_GetSerialNumberString(SafeFileHandle hidDeviceObject)
        {
            string result;
            if (!HidD_GetSerialNumberString(hidDeviceObject, out result))
            {
                throw new Win32Exception();
            }

            return result;
        }

        private static bool GrowBuffer(Func<StringBuilder, bool> nativeMethod, out string result)
        {
            // USB Hid maximum size is 126 wide chars + '\0' = 254 bytes, allocating 256 bytes we should never grow
            // until another HID standard decide otherwise.
            var stringBuilder = new StringBuilder(256);
            while (true)
            {
                if (nativeMethod(stringBuilder))
                {
                    result = stringBuilder.ToString();
                    return true;
                }

                var errorCode = (Win32ErrorCode)Marshal.GetLastWin32Error();
                if (errorCode != Win32ErrorCode.InvalidUserBuffer)
                {
                    result = null;
                    return false;
                }

                stringBuilder.Capacity = stringBuilder.Capacity * 2;
            }
        }
    }
}
