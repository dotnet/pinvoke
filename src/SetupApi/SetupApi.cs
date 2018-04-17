// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Runtime.InteropServices;

    /// <content>
    /// Exported functions from the SetupApi.dll Windows library
    /// that are available to Desktop apps only.
    /// </content>
    [OfferFriendlyOverloads]
    public static partial class SetupApi
    {
        /// <summary>
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
        [DllImport(nameof(SetupApi), SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern unsafe SafeDeviceInfoSetHandle SetupDiGetClassDevs(
            [Friendly(FriendlyFlags.In | FriendlyFlags.Optional)] Guid* classGuid,
            string enumerator,
            IntPtr hwndParent,
            GetClassDevsFlags flags);

        /// <summary>
        /// Enumerates the device interfaces that are contained in a device information set.
        /// </summary>
        /// <param name="deviceInfoSet">
        /// A pointer to a device information set that contains the device interfaces for which to
        /// return information. This handle is typically returned by <see cref="SetupDiGetClassDevs(Guid*,string,IntPtr,GetClassDevsFlags)" />.
        /// </param>
        /// <param name="deviceInfoData">
        /// A pointer to an <see cref="SP_DEVINFO_DATA" /> structure that specifies a device
        /// information element in DeviceInfoSet. This parameter is optional and can be <see langword="null" />. If this parameter
        /// is specified, SetupDiEnumDeviceInterfaces constrains the enumeration to the interfaces that are supported by the
        /// specified device. If this parameter is <see langword="null" />, repeated calls to SetupDiEnumDeviceInterfaces return
        /// information about the interfaces that are associated with all the device information elements in DeviceInfoSet. This
        /// pointer is typically returned by <see cref="SetupDiEnumDeviceInfo(SafeDeviceInfoSetHandle, int, SP_DEVINFO_DATA*)" />.
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
        /// completed <see cref="SP_DEVICE_INTERFACE_DATA" /> structure that identifies an interface that meets the search parameters.
        /// The caller
        /// must set <see cref="SP_DEVICE_INTERFACE_DATA.Size" /> before calling this function either manually or via
        /// <see cref="SP_DEVICE_INTERFACE_DATA.Create" />.
        /// </param>
        /// <returns>
        /// Returns <see langword="true" /> if the function completed without error. If the function completed with an
        /// error, <see langword="false" /> is returned and the error code for the failure can be retrieved by calling
        /// <see cref="Marshal.GetLastWin32Error" />.
        /// </returns>
        [DllImport(nameof(SetupApi), SetLastError = true)]
        public static extern unsafe bool SetupDiEnumDeviceInterfaces(
            SafeDeviceInfoSetHandle deviceInfoSet,
            [Friendly(FriendlyFlags.In | FriendlyFlags.Optional)] SP_DEVINFO_DATA* deviceInfoData,
            ref Guid interfaceClassGuid,
            int memberIndex,
            ref SP_DEVICE_INTERFACE_DATA deviceInterfaceData);

        /// <summary>
        /// Returns details about a device interface.
        /// </summary>
        /// <param name="deviceInfoSet">
        /// A pointer to a device information set that contains the device interfaces for which to
        /// return information. This handle is typically returned by <see cref="SetupDiGetClassDevs(Guid*,string,IntPtr,GetClassDevsFlags)" />.
        /// </param>
        /// <param name="deviceInterfaceData">
        /// A pointer to an <see cref="SP_DEVICE_INTERFACE_DATA" /> structure that specifies the
        /// interface in DeviceInfoSet for which to retrieve details. A pointer of this type is typically returned by
        /// <see cref="SetupDiEnumDeviceInterfaces(SafeDeviceInfoSetHandle,SP_DEVINFO_DATA*,ref Guid,int,ref SP_DEVICE_INTERFACE_DATA)" />.
        /// </param>
        /// <param name="deviceInterfaceDetailData">
        /// A pointer to an SP_DEVICE_INTERFACE_DETAIL_DATA structure to receive
        /// information about the specified interface. This parameter is optional and can be <see langword="null" />. This
        /// parameter must be <see langword="null" /> if <paramref name="deviceInterfaceDetailDataSize"/> is zero. If this parameter is specified, the
        /// caller must set <paramref name="deviceInterfaceDetailData"/>.cbSize to <see cref="SP_DEVICE_INTERFACE_DETAIL_DATA.ReportableStructSize"/>.
        /// </param>
        /// <param name="deviceInterfaceDetailDataSize">
        /// The size of the <paramref name="deviceInterfaceDetailData" /> buffer.
        /// <para>This parameter must be zero if <paramref name="deviceInterfaceDetailData" /> is <see langword="null" />.</para>
        /// </param>
        /// <param name="requiredSize">
        /// A pointer to a variable of type <see cref="uint" /> that receives the required size of the
        /// <paramref name="deviceInterfaceDetailData"/> buffer. This size includes the size of the fixed part of the structure plus the number of
        /// bytes required for the variable-length device path string. This parameter is optional and can be
        /// <see langword="null" />.
        /// </param>
        /// <param name="deviceInfoData">
        /// A pointer to a buffer that receives information about the device that supports the requested interface. The caller
        /// must set <see cref="SP_DEVINFO_DATA.Size" /> before calling this function.
        /// <para>This parameter is optional and can be <see langword="null" />.</para>
        /// </param>
        /// <returns>
        /// Returns <see langword="true" /> if the function completed without error. If the function completed with an
        /// error, <see langword="false" /> is returned and the error code for the failure can be retrieved by calling
        /// <see cref="Marshal.GetLastWin32Error" />.
        /// </returns>
        [DllImport(nameof(SetupApi), SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern unsafe bool SetupDiGetDeviceInterfaceDetail(
            SafeDeviceInfoSetHandle deviceInfoSet,
            ref SP_DEVICE_INTERFACE_DATA deviceInterfaceData,
            SP_DEVICE_INTERFACE_DETAIL_DATA* deviceInterfaceDetailData,
            int deviceInterfaceDetailDataSize,
            int* requiredSize,
            SP_DEVINFO_DATA* deviceInfoData);

        /// <summary>
        /// Returns a <see cref="SP_DEVINFO_DATA" /> structure that specifies a device information element in a device information
        /// set.
        /// </summary>
        /// <param name="deviceInfoSet">
        /// A handle to the device information set for which to return an <see cref="SP_DEVINFO_DATA" />
        /// structure that represents a device information element.
        /// </param>
        /// <param name="memberIndex">A zero-based index of the device information element to retrieve.</param>
        /// <param name="deviceInfoData">
        /// A pointer to an <see cref="SP_DEVINFO_DATA"/> structure to receive information about an enumerated
        /// device information element. The caller must set <see cref="SP_DEVINFO_DATA.Size" /> before calling this function.
        /// </param>
        /// <returns>
        /// Returns <see langword="true" /> if the function completed without error. If the function completed with an
        /// error, <see langword="false" /> is returned and the error code for the failure can be retrieved by calling
        /// <see cref="Marshal.GetLastWin32Error" />.
        /// </returns>
        [DllImport(nameof(SetupApi), SetLastError = true)]
        public static extern unsafe bool SetupDiEnumDeviceInfo(
            SafeDeviceInfoSetHandle deviceInfoSet,
            int memberIndex,
            SP_DEVINFO_DATA* deviceInfoData);

        /// <summary>
        /// Deletes a device information set and frees all associated memory.
        /// </summary>
        /// <param name="deviceInfoSet">A handle to the device information set to delete.</param>
        /// <returns>
        /// Returns <see langword="true" /> if the function completed without error. If the function completed with an
        /// error, <see langword="false" /> is returned and the error code for the failure can be retrieved by calling
        /// <see cref="Marshal.GetLastWin32Error" />.
        /// </returns>
        [DllImport(nameof(SetupApi), SetLastError = true)]
        private static extern bool SetupDiDestroyDeviceInfoList(IntPtr deviceInfoSet);
    }
}