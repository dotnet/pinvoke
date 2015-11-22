// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Runtime.InteropServices;
    using System.Text;
    using static Kernel32;
	using static Hid;
	public class HidMockable : IHidMockable {        /// <summary>
        /// The HidD_GetHidGuid routine returns the device interfaceGUID for HIDClass devices.
        /// </summary>
        /// <param name="hidGuid">
        /// Pointer to a caller-allocated GUID buffer that the routine uses to return the device interface GUID
        /// for HIDClass devices.
        /// </param>
        public void InvokeHidD_GetHidGuid(out Guid hidGuid)
			=> HidD_GetHidGuid(out hidGuid);
	
        /// <summary>
        /// Returns the attributes of a specified top-level collection.
        /// </summary>
        /// <param name="hidDeviceObject">Specifies an open handle to a top-level collection.</param>
        /// <param name="attributes">
        /// Pointer to a caller-allocated <see cref="HiddAttributes" /> structure that returns the
        /// attributes of the collection specified by HidDeviceObject.
        /// </param>
        /// <returns>TRUE if succeeds; otherwise, it returns FALSE.</returns>
        public bool InvokeHidD_GetAttributes(
            SafeObjectHandle hidDeviceObject,
            ref HiddAttributes attributes)
			=> HidD_GetAttributes(hidDeviceObject, ref attributes);
	
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
        public bool InvokeHidD_GetManufacturerString(
            SafeObjectHandle hidDeviceObject,
            StringBuilder buffer,
            int bufferLength)
			=> HidD_GetManufacturerString(hidDeviceObject, buffer, bufferLength);
	
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
        public bool InvokeHidD_GetProductString(
            SafeObjectHandle hidDeviceObject,
            StringBuilder buffer,
            int bufferLength)
			=> HidD_GetProductString(hidDeviceObject, buffer, bufferLength);
	
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
        public bool InvokeHidD_GetSerialNumberString(
            SafeObjectHandle hidDeviceObject,
            StringBuilder buffer,
            int bufferLength)
			=> HidD_GetSerialNumberString(hidDeviceObject, buffer, bufferLength);
	
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
        public bool InvokeHidD_SetNumInputBuffers(
            SafeObjectHandle hidDeviceObject,
            uint numberBuffers)
			=> HidD_SetNumInputBuffers(hidDeviceObject, numberBuffers);
	
        /// <summary>
        /// Returns a top-level collection's preparsed data.
        /// </summary>
        /// <param name="hidDeviceObject">Specifies an open handle to a top-level collection.</param>
        /// <param name="preparsedDataHandle">
        /// Pointer to the address of a routine-allocated buffer that contains a collection's
        /// preparsed data in a <see cref="SafePreparsedDataHandle" /> structure.
        /// </param>
        /// <returns>TRUE if it succeeds; otherwise, it returns FALSE.</returns>
        public bool InvokeHidD_GetPreparsedData(
            SafeObjectHandle hidDeviceObject,
            out SafePreparsedDataHandle preparsedDataHandle)
			=> HidD_GetPreparsedData(hidDeviceObject, out preparsedDataHandle);
	
        /// <summary>
        /// Returns a top-level collection's <see cref="HidpCaps" /> structure.
        /// </summary>
        /// <param name="preparsedData">Pointer to a top-level collection's preparsed data.</param>
        /// <param name="capabilities">
        /// Pointer to a caller-allocated buffer that the routine uses to return a collection's
        /// <see cref="HidpCaps" /> structure.
        /// </param>
        /// <returns>
        /// <see cref="NTStatus.HIDP_STATUS_SUCCESS" /> on success or <see cref="NTStatus.HIDP_STATUS_INVALID_PREPARSED_DATA" /> if rhe
        /// specified preparsed data is invalid.
        /// </returns>
        public NTStatus InvokeHidP_GetCaps(SafePreparsedDataHandle preparsedData, ref HidpCaps capabilities)
			=> HidP_GetCaps(preparsedData, ref capabilities);
	}
}