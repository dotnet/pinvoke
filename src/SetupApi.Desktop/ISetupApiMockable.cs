// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Runtime.InteropServices;
	using static SetupApi;
	[System.Runtime.CompilerServices.CompilerGenerated]
		public interface ISetupApiMockable {        /// <summary>
        /// The SetupDiGetClassDevs function returns a <see cref="SafeDeviceInfoSetHandle" /> handle to a device information set
        /// that contains requested device information elements for a local computer.
        /// </summary>
        /// <param name="classGuid">
        /// A pointer to the GUID for a device setup class or a device interface class. This pointer is
        /// optional and can be <see langword="null" />. For more information about how to set ClassGuid, see the following Remarks
        /// section.
        /// </param>
        /// <param name="enumerator">
        /// A pointer to a NULL-terminated string that specifies:
        /// <list type="bullet">
        ///     <item>
        ///         <description>
        ///         An identifier(ID) of a Plug and Play(PnP) enumerator.This ID can either be the value's globally
        ///         unique identifier (GUID) or symbolic name. For example, "PCI" can be used to specify the PCI PnP value. Other
        ///         examples of symbolic names for PnP values include "USB," "PCMCIA," and "SCSI".
        ///         </description>
        ///     </item>
        ///     <item>
        ///         <description>
        ///         A PnP device instance ID.When specifying a PnP device instance ID, DIGCF_DEVICEINTERFACE must be
        ///         set in the Flags parameter.
        ///         </description>
        ///     </item>
        /// </list>
        /// This pointer is optional and can be <see langword="null" />.If an enumeration value is not used to select devices, set
        /// Enumerator to <see langword="null" />.
        /// </param>
        /// <param name="hwndParent">
        /// A handle to the top-level window to be used for a user interface that is associated with
        /// installing a device instance in the device information set. This handle is optional and can be <see langword="null" />.
        /// </param>
        /// <param name="flags">
        /// A variable of type DWORD that specifies control options that filter the device information elements
        /// that are added to the device information set. This parameter can be a bitwise OR of zero or more of the flags.
        /// </param>
        /// <returns>
        /// If the operation succeeds, SetupDiGetClassDevs returns a handle to a device information set that contains all
        /// installed devices that matched the supplied parameters. If the operation fails, the function returns an invalid handle.
        /// </returns>
        [System.Runtime.CompilerServices.CompilerGenerated]
	SafeDeviceInfoSetHandle InvokeSetupDiGetClassDevs(
            NullableGuid classGuid,
            string enumerator,
            IntPtr hwndParent,
            GetClassDevsFlags flags);
	
        /// <summary>
        /// Enumerates the device interfaces that are contained in a device information set.
        /// </summary>
        /// <param name="deviceInfoSet">
        /// A pointer to a device information set that contains the device interfaces for which to
        /// return information. This handle is typically returned by <see cref="SetupDiGetClassDevs(NullableGuid,string,IntPtr,GetClassDevsFlags)" />.
        /// </param>
        /// <param name="deviceInfoData">
        /// A pointer to an <see cref="DeviceInfoData" /> structure that specifies a device
        /// information element in DeviceInfoSet. This parameter is optional and can be <see langword="null" />. If this parameter
        /// is specified, SetupDiEnumDeviceInterfaces constrains the enumeration to the interfaces that are supported by the
        /// specified device. If this parameter is <see langword="null" />, repeated calls to SetupDiEnumDeviceInterfaces return
        /// information about the interfaces that are associated with all the device information elements in DeviceInfoSet. This
        /// pointer is typically returned by <see cref="SetupDiEnumDeviceInfo" />.
        /// </param>
        /// <param name="interfaceClassGuid">
        /// A pointer to a <see cref="Guid" /> that specifies the device interface class for the
        /// requested interface.
        /// </param>
        /// <param name="memberIndex">
        /// A zero-based index into the list of interfaces in the device information set. The caller
        /// should call this function first with MemberIndex set to zero to obtain the first interface. Then, repeatedly increment
        /// MemberIndex and retrieve an interface until this function fails and <see cref="Kernel32.GetLastError"/> returns
        /// <see cref="Win32ErrorCode.ERROR_NO_MORE_ITEMS" />.
        /// </param>
        /// <param name="deviceInterfaceData">
        /// A pointer to a caller-allocated buffer that contains, on successful return, a
        /// completed <see cref="DeviceInterfaceData" /> structure that identifies an interface that meets the search parameters.
        /// The caller
        /// must set <see cref="DeviceInterfaceData.Size" /> before calling this function either manually or via
        /// <see cref="DeviceInterfaceData.Create" />.
        /// </param>
        /// <returns>
        /// Returns <see langword="true" /> if the function completed without error. If the function completed with an
        /// error, <see langword="false" /> is returned and the error code for the failure can be retrieved by calling
        /// <see cref="Marshal.GetLastWin32Error" />.
        /// </returns>
        [System.Runtime.CompilerServices.CompilerGenerated]
	bool InvokeSetupDiEnumDeviceInterfaces(
            SafeDeviceInfoSetHandle deviceInfoSet,
            DeviceInfoData deviceInfoData,
            ref Guid interfaceClassGuid,
            uint memberIndex,
            ref DeviceInterfaceData deviceInterfaceData);
	
        /// <summary>
        /// Returns details about a device interface.
        /// </summary>
        /// <param name="deviceInfoSet">
        /// A pointer to a device information set that contains the device interfaces for which to
        /// return information. This handle is typically returned by <see cref="SetupDiGetClassDevs(NullableGuid,string,IntPtr,GetClassDevsFlags)" />.
        /// </param>
        /// <param name="deviceInterfaceData">
        /// A pointer to an <see cref="DeviceInterfaceData" /> structure that specifies the
        /// interface in DeviceInfoSet for which to retrieve details. A pointer of this type is typically returned by
        /// <see cref="SetupDiEnumDeviceInterfaces(SafeDeviceInfoSetHandle,DeviceInfoData,ref Guid,uint,ref DeviceInterfaceData)" />.
        /// </param>
        /// <param name="deviceInterfaceDetailData">
        /// A pointer to an SP_DEVICE_INTERFACE_DETAIL_DATA structure to receive
        /// information about the specified interface. This parameter is optional and can be <see langword="null" />. This
        /// parameter must be <see langword="null" /> if <paramref name="deviceInterfaceDetailDataSize"/> is zero. If this parameter is specified, the
        /// caller must set <paramref name="deviceInterfaceDetailData"/>.cbSize to sizeof(SP_DEVICE_INTERFACE_DETAIL_DATA) before calling this
        /// function. The cbSize member always contains the size of the fixed part of the data structure, not a size reflecting the
        /// variable-length string at the end.
        /// </param>
        /// <param name="deviceInterfaceDetailDataSize">
        /// The size of the <paramref name="deviceInterfaceDetailData" /> buffer.
        /// <para>This parameter must be zero if <paramref name="deviceInterfaceDetailData" /> is <see langword="null" />.</para>
        /// </param>
        /// <param name="requiredSize">
        /// A pointer to a variable of type <see cref="uint" /> that receives the required size of the
        /// DeviceInterfaceDetailData buffer. This size includes the size of the fixed part of the structure plus the number of
        /// bytes required for the variable-length device path string. This parameter is optional and can be
        /// <see langword="null" />.
        /// </param>
        /// <param name="deviceInfoData">
        /// A pointer to a buffer that receives information about the device that supports the requested interface. The caller
        /// must set <see cref="DeviceInfoData.Size" /> before calling this function.
        /// <para>This parameter is optional and can be <see langword="null" />.</para>
        /// </param>
        /// <returns>
        /// Returns <see langword="true" /> if the function completed without error. If the function completed with an
        /// error, <see langword="false" /> is returned and the error code for the failure can be retrieved by calling
        /// <see cref="Marshal.GetLastWin32Error" />.
        /// </returns>
        [System.Runtime.CompilerServices.CompilerGenerated]
	bool InvokeSetupDiGetDeviceInterfaceDetail(
            SafeDeviceInfoSetHandle deviceInfoSet,
            ref DeviceInterfaceData deviceInterfaceData,
            IntPtr deviceInterfaceDetailData,
            uint deviceInterfaceDetailDataSize,
            NullableUInt32 requiredSize,
            DeviceInfoData deviceInfoData);
	
        /// <summary>
        /// Returns a <see cref="DeviceInfoData" /> structure that specifies a device information element in a device information
        /// set.
        /// </summary>
        /// <param name="deviceInfoSet">
        /// A handle to the device information set for which to return an <see cref="DeviceInfoData" />
        /// structure that represents a device information element.
        /// </param>
        /// <param name="memberIndex">A zero-based index of the device information element to retrieve.</param>
        /// <param name="deviceInfoData">
        /// A pointer to an <see cref="DeviceInfoData"/> structure to receive information about an enumerated
        /// device information element. The caller must set <see cref="DeviceInfoData.Size" /> before calling this function.
        /// </param>
        /// <returns>
        /// Returns <see langword="true" /> if the function completed without error. If the function completed with an
        /// error, <see langword="false" /> is returned and the error code for the failure can be retrieved by calling
        /// <see cref="Marshal.GetLastWin32Error" />.
        /// </returns>
        [System.Runtime.CompilerServices.CompilerGenerated]
	bool InvokeSetupDiEnumDeviceInfo(
            SafeDeviceInfoSetHandle deviceInfoSet,
            uint memberIndex,
            DeviceInfoData deviceInfoData);
	}
}