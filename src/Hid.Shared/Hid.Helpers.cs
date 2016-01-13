// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Text;
    using static Kernel32;

    /// <content>
    /// Methods and nested types that are not strictly P/Invokes but provide
    /// a slightly higher level of functionality to ease calling into native code.
    /// </content>
    [SuppressMessage("ReSharper", "InconsistentNaming", Justification = "Functions are named like their native counterparts")]
    public static partial class Hid
    {
        public static Guid HidD_GetHidGuid()
        {
            Guid guid;
            HidD_GetHidGuid(out guid);
            return guid;
        }

        public static HiddAttributes HidD_GetAttributes(SafeObjectHandle hFile)
        {
            var result = HiddAttributes.Create();
            if (!HidD_GetAttributes(hFile, ref result))
            {
                throw new Win32Exception();
            }

            return result;
        }

        public static SafePreparsedDataHandle HidD_GetPreparsedData(SafeObjectHandle hDevice)
        {
            SafePreparsedDataHandle preparsedDataHandle;
            if (!HidD_GetPreparsedData(hDevice, out preparsedDataHandle))
            {
                throw new Win32Exception();
            }

            return preparsedDataHandle;
        }

        public static HidpCaps HidP_GetCaps(SafePreparsedDataHandle preparsedData)
        {
            var hidCaps = default(HidpCaps);
            var result = HidP_GetCaps(preparsedData, ref hidCaps);
            switch (result.Value)
            {
                case NTSTATUS.Code.HIDP_STATUS_SUCCESS:
                    return hidCaps;

                case NTSTATUS.Code.HIDP_STATUS_INVALID_PREPARSED_DATA:
                    throw new ArgumentException("The specified preparsed data is invalid.", nameof(preparsedData));

                default:
                    result.ThrowOnError();
                    throw new InvalidOperationException("HidP_GetCaps returned an unexpected success value");
            }
        }

        public static bool HidD_GetManufacturerString(SafeObjectHandle hidDeviceObject, out string result)
        {
            return GrowStringBuffer(sb => HidD_GetManufacturerString(hidDeviceObject, sb, sb.Capacity), out result);
        }

        public static bool HidD_GetProductString(SafeObjectHandle hidDeviceObject, out string result)
        {
            return GrowStringBuffer(sb => HidD_GetProductString(hidDeviceObject, sb, sb.Capacity), out result);
        }

        public static bool HidD_GetSerialNumberString(SafeObjectHandle hidDeviceObject, out string result)
        {
            return GrowStringBuffer(sb => HidD_GetSerialNumberString(hidDeviceObject, sb, sb.Capacity), out result);
        }

        public static string HidD_GetManufacturerString(SafeObjectHandle hidDeviceObject)
        {
            string result;
            if (!HidD_GetManufacturerString(hidDeviceObject, out result))
            {
                throw new Win32Exception();
            }

            return result;
        }

        public static string HidD_GetProductString(SafeObjectHandle hidDeviceObject)
        {
            string result;
            if (!HidD_GetProductString(hidDeviceObject, out result))
            {
                throw new Win32Exception();
            }

            return result;
        }

        public static string HidD_GetSerialNumberString(SafeObjectHandle hidDeviceObject)
        {
            string result;
            if (!HidD_GetSerialNumberString(hidDeviceObject, out result))
            {
                throw new Win32Exception();
            }

            return result;
        }

        private static bool GrowStringBuffer(Func<StringBuilder, bool> nativeMethod, out string result)
        {
            // USB Hid maximum size is 126 wide chars + '\0' = 254 bytes, allocating 256 bytes we should never grow
            // until another HID standard decide otherwise.
            var stringBuilder = new StringBuilder(256);

            // If we ever resize over this value something got really wrong
            const int maximumRealisticSize = 1 * 1024 * 2014;

            while (stringBuilder.Capacity < maximumRealisticSize)
            {
                if (nativeMethod(stringBuilder))
                {
                    result = stringBuilder.ToString();
                    return true;
                }

                if (GetLastError() != Win32ErrorCode.ERROR_INVALID_USER_BUFFER)
                {
                    result = null;
                    return false;
                }

                stringBuilder.Capacity = stringBuilder.Capacity * 2;
            }

            result = null;
            return false;
        }
    }
}
