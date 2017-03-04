// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Runtime.InteropServices;
    using System.Text;
    using static Kernel32;

    /// <summary>
    /// Exported functions from the Hid.dll Windows library
    /// that are available to Desktop apps only.
    /// </summary>
    public static partial class Hid
    {
        /// <summary>
        /// The HidD_GetHidGuid routine returns the device interfaceGUID for HIDClass devices.
        /// </summary>
        /// <param name="hidGuid">
        /// Pointer to a caller-allocated GUID buffer that the routine uses to return the device interface GUID
        /// for HIDClass devices.
        /// </param>
        [DllImport(nameof(Hid), SetLastError = true)]
        public static extern void HidD_GetHidGuid(out Guid hidGuid);

        /// <summary>
        /// Returns the attributes of a specified top-level collection.
        /// </summary>
        /// <param name="hidDeviceObject">Specifies an open handle to a top-level collection.</param>
        /// <param name="attributes">
        /// Pointer to a caller-allocated <see cref="HiddAttributes" /> structure that returns the
        /// attributes of the collection specified by HidDeviceObject.
        /// </param>
        /// <returns>TRUE if succeeds; otherwise, it returns FALSE.</returns>
        [DllImport(nameof(Hid), SetLastError = true)]
        public static extern bool HidD_GetAttributes(
            SafeObjectHandle hidDeviceObject,
            ref HiddAttributes attributes);

        /// <summary>
        /// Returns a top-level collection's embedded string that identifies the manufacturer.
        /// </summary>
        /// <param name="hidDeviceObject">Specifies an open handle to a top-level collection.</param>
        /// <param name="buffer">
        /// Pointer to a caller-allocated buffer that the routine uses to return the collection's manufacturer
        /// string.
        /// </param>
        /// <param name="bufferLength">
        /// Specifies the length, in bytes, of a caller-allocated buffer provided at Buffer. If the
        /// buffer is not large enough to return the entire NULL-terminated embedded string, the routine returns nothing in the
        /// buffer.
        /// </param>
        /// <returns>TRUE if it returns the entire NULL-terminated embedded string. Otherwise, the routine returns FALSE.</returns>
        /// <remarks>
        /// The maximum possible number of characters in an embedded string is device specific. For USB devices, the
        /// maximum string length is 126 wide characters (not including the terminating NULL character).
        /// </remarks>
        [DllImport(nameof(Hid), CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern bool HidD_GetManufacturerString(
            SafeObjectHandle hidDeviceObject,
            StringBuilder buffer,
            int bufferLength);

        /// <summary>
        /// Returns the embedded string of a top-level collection that identifies the manufacturer's product.
        /// </summary>
        /// <param name="hidDeviceObject">Specifies an open handle to a top-level collection.</param>
        /// <param name="buffer">Pointer to a caller-allocated buffer that the routine uses to return the requested product string.</param>
        /// <param name="bufferLength">
        /// Specifies the length, in bytes, of a caller-allocated buffer provided at Buffer. If the
        /// buffer is not large enough to return the entire NULL-terminated embedded string, the routine returns nothing in the
        /// buffer.
        /// </param>
        /// <returns>
        /// TRUE if it successfully returns the entire NULL-terminated embedded string. Otherwise, the routine returns
        /// FALSE.
        /// </returns>
        /// ///
        /// <remarks>
        /// The maximum possible number of characters in an embedded string is device specific. For USB devices, the
        /// maximum string length is 126 wide characters (not including the terminating NULL character).
        /// </remarks>
        [DllImport(nameof(Hid), CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern bool HidD_GetProductString(
            SafeObjectHandle hidDeviceObject,
            StringBuilder buffer,
            int bufferLength);

        /// <summary>
        /// Returns the embedded string of a top-level collection that identifies the serial number of the collection's physical
        /// device.
        /// </summary>
        /// <param name="hidDeviceObject">Specifies an open handle to a top-level collection.</param>
        /// <param name="buffer">
        /// Pointer to a caller-allocated buffer that the routine uses to return the requested serial number
        /// string.
        /// </param>
        /// <param name="bufferLength">
        /// Specifies the length, in bytes, of a caller-allocated buffer provided at Buffer. If the
        /// buffer is not large enough to return the entire NULL-terminated embedded string, the routine returns nothing in the
        /// buffer.
        /// </param>
        /// <returns>
        /// TRUE if it successfully returns the entire NULL-terminated embedded string. Otherwise, the routine returns
        /// FALSE.
        /// </returns>
        /// /// ///
        /// <remarks>
        /// The maximum possible number of characters in an embedded string is device specific. For USB devices, the
        /// maximum string length is 126 wide characters (not including the terminating NULL character).
        /// </remarks>
        [DllImport(nameof(Hid), CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern bool HidD_GetSerialNumberString(
            SafeObjectHandle hidDeviceObject,
            StringBuilder buffer,
            int bufferLength);

        /// <summary>
        /// Sets the maximum number of input reports that the HID class driver ring buffer can hold for a specified top-level
        /// collection.
        /// </summary>
        /// <param name="hidDeviceObject">Specifies an open handle to a top-level collection.</param>
        /// <param name="numberBuffers">
        /// Specifies the maximum number of buffers that the HID class driver should maintain for the
        /// input reports generated by the HidDeviceObject collection.
        /// </param>
        /// <returns>TRUE if it succeeds; otherwise, it returns FALSE.</returns>
        [DllImport(nameof(Hid), SetLastError = true)]
        public static extern bool HidD_SetNumInputBuffers(
            SafeObjectHandle hidDeviceObject,
            int numberBuffers);

        /// <summary>
        /// Returns a top-level collection's preparsed data.
        /// </summary>
        /// <param name="hidDeviceObject">Specifies an open handle to a top-level collection.</param>
        /// <param name="preparsedDataHandle">
        /// Pointer to the address of a routine-allocated buffer that contains a collection's
        /// preparsed data in a <see cref="SafePreparsedDataHandle" /> structure.
        /// </param>
        /// <returns>TRUE if it succeeds; otherwise, it returns FALSE.</returns>
        [DllImport(nameof(Hid), SetLastError = true)]
        public static extern bool HidD_GetPreparsedData(
            SafeObjectHandle hidDeviceObject,
            out SafePreparsedDataHandle preparsedDataHandle);

        /// <summary>
        /// Returns a top-level collection's <see cref="HidpCaps" /> structure.
        /// </summary>
        /// <param name="preparsedData">Pointer to a top-level collection's preparsed data.</param>
        /// <param name="capabilities">
        /// Pointer to a caller-allocated buffer that the routine uses to return a collection's
        /// <see cref="HidpCaps" /> structure.
        /// </param>
        /// <returns>
        /// <see cref="NTSTATUS.Code.HIDP_STATUS_SUCCESS" /> on success or <see cref="NTSTATUS.Code.HIDP_STATUS_INVALID_PREPARSED_DATA" /> if rhe
        /// specified preparsed data is invalid.
        /// </returns>
        [DllImport(nameof(Hid), SetLastError = true)]
        public static extern NTSTATUS HidP_GetCaps(SafePreparsedDataHandle preparsedData, ref HidpCaps capabilities);

        /// <summary>
        /// Releases the resources that the HID class driver allocated to hold a top-level collection's preparsed data.
        /// </summary>
        /// <param name="preparsedData">
        /// Pointer to the buffer, returned by
        /// <see cref="HidD_GetPreparsedData(Kernel32.SafeObjectHandle, out SafePreparsedDataHandle)" />, that is freed.
        /// </param>
        /// <returns>TRUE if it succeeds. Otherwise, it returns FALSE if the buffer was not a preparsed data buffer.</returns>
        [DllImport(nameof(Hid), SetLastError = true)]
        private static extern bool HidD_FreePreparsedData(IntPtr preparsedData);
    }
}
