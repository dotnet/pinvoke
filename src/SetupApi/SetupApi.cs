// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PInvoke
{
    using System;
#if NETFRAMEWORK || NETSTANDARD2_0_ORLATER
    using System.Runtime.ConstrainedExecution;
#endif
    using System.Runtime.InteropServices;
    using System.Security;

    /// <content>
    /// Exported functions from the SetupApi.dll Windows library
    /// that are available to Desktop apps only.
    /// </content>
    [OfferFriendlyOverloads]
    public static partial class SetupApi
    {
        /// <summary>
        /// The line length of the strings that are used by <see cref="SetupApi"/>.
        /// </summary>
        private const int LINE_LEN = 256;

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
        [return: MarshalAs(UnmanagedType.Bool)]
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
        [return: MarshalAs(UnmanagedType.Bool)]
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
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern unsafe bool SetupDiEnumDeviceInfo(
            SafeDeviceInfoSetHandle deviceInfoSet,
            int memberIndex,
            [Friendly(FriendlyFlags.Bidirectional)] SP_DEVINFO_DATA* deviceInfoData);

        /// <summary>
        /// Retrieves a device instance property.
        /// </summary>
        /// <param name="deviceInfoSet">A handle to a <see href="https://docs.microsoft.com/windows-hardware/drivers/install/device-information-sets">device information set</see>
        /// that contains a device instance for which to retrieve a device instance property.</param>
        /// <param name="deviceInfoData">A pointer to the <see cref="SP_DEVINFO_DATA"/> structure that represents the device instance for which to retrieve a device instance property.</param>
        /// <param name="propertyKey">A pointer to a <see cref="DEVPROPKEY"/> structure that represents the device property key of the requested device instance property.</param>
        /// <param name="propertyType">A pointer to a uint-typed variable that receives the property-data-type identifier of the requested device instance property, where the property-data-type
        /// identifier is the bitwise OR between a base-data-type identifier and, if the base-data type is modified, a property-data-type modifier.</param>
        /// <param name="propertyBuffer">
        /// A pointer to a buffer that receives the requested device instance property.
        /// <see cref="SetupDiGetDeviceProperty(SafeDeviceInfoSetHandle, SP_DEVINFO_DATA*, DEVPROPKEY*, uint*, byte*, uint, uint*, SetupDiGetDevicePropertyFlags)"/> retrieves the requested property
        /// only if the buffer is large enough to hold all the property value data. The pointer can be NULL. If the pointer is set to NULL and RequiredSize is supplied,
        /// <see cref="SetupDiGetDeviceProperty(SafeDeviceInfoSetHandle, SP_DEVINFO_DATA*, DEVPROPKEY*, uint*, byte*, uint, uint*, SetupDiGetDevicePropertyFlags)"/> returns the size of the property,
        /// in bytes, in <paramref name="requiredSize"/>.</param>
        /// <param name="propertyBufferSize">The size, in bytes, of the <paramref name="propertyBuffer"/> buffer. If <paramref name="propertyBuffer"/> is set to NULL, <paramref name="propertyBufferSize"/> must be set to zero.</param>
        /// <param name="requiredSize">
        /// A pointer to a DWORD-typed variable that receives the size, in bytes, of either the device instance property if the property is retrieved or the required buffer size if the buffer is not large enough. This pointer can be set to NULL.
        /// </param>
        /// <param name="flags">This parameter must be set to zero.</param>
        /// <returns>
        /// Returns TRUE if it is successful. Otherwise, it returns FALSE, and the logged error can be retrieved by calling <see cref="Marshal.GetLastWin32Error"/>.
        /// </returns>
        [DllImport(nameof(SetupApi), SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern unsafe bool SetupDiGetDeviceProperty(
            SafeDeviceInfoSetHandle deviceInfoSet,
            SP_DEVINFO_DATA* deviceInfoData,
            DEVPROPKEY* propertyKey,
            uint* propertyType,
            [Friendly(FriendlyFlags.Array | FriendlyFlags.Out | FriendlyFlags.Optional, ArrayLengthParameter = 5)] byte* propertyBuffer,
            uint propertyBufferSize,
            uint* requiredSize,
            SetupDiGetDevicePropertyFlags flags);

        /// <summary>
        /// The <see cref="SetupDiCreateDeviceInfoList(Guid*, IntPtr)"/> function creates an empty device information set and optionally associates the
        /// set with a device setup class and a top-level window.
        /// </summary>
        /// <param name="classGuid">
        /// A pointer to the <see cref="Guid"/> of the device setup class to associate with the newly created device information set.
        /// If this parameter is specified, only devices of this class can be included in this device information set. If this parameter is set
        /// to <see cref="IntPtr.Zero"/>, the device information set is not associated with a specific device setup class.
        /// </param>
        /// <param name="hwndParent">
        /// A handle to the top-level window to use for any user interface that is related to non-device-specific actions (such as a select-device dialog
        /// box that uses the global class driver list). This handle is optional and can be <see cref="IntPtr.Zero"/>. If a specific top-level window is not
        /// required, set <paramref name="hwndParent"/> to <see cref="IntPtr.Zero"/>.
        /// </param>
        /// <returns>
        /// The function returns a <see cref="IntPtr"/> to an empty device information set if it is successful. Otherwise, it returns
        /// <see cref="SafeDeviceInfoSetHandle.Invalid"/>. To get extended error information, call <see cref="Marshal.GetLastWin32Error"/>.
        /// </returns>
        /// <seealso href="https://msdn.microsoft.com/en-us/library/windows/hardware/ff550956(v=vs.85).aspx"/>
        [DllImport(nameof(SetupApi), SetLastError = true)]
        public static unsafe extern SafeDeviceInfoSetHandle SetupDiCreateDeviceInfoList(
            [Friendly(FriendlyFlags.In | FriendlyFlags.Optional)] Guid* classGuid,
            IntPtr hwndParent);

        /// <summary>
        /// The <see cref="SetupDiOpenDeviceInfo(SafeDeviceInfoSetHandle, string, IntPtr, SetupDiOpenDeviceInfoFlags, SP_DEVINFO_DATA*)"/> function adds a device information element for a device instance to a device information set,
        /// if one does not already exist in the device information set, and retrieves information that identifies the device information element
        /// for the device instance in the device information set.
        /// </summary>
        /// <param name="deviceInfoSet">
        /// A handle to the device information set to which <see cref="SetupDiOpenDeviceInfo(SafeDeviceInfoSetHandle, string, IntPtr, SetupDiOpenDeviceInfoFlags, SP_DEVINFO_DATA*)"/> adds a device information element, if one does
        /// not already exist, for the device instance that is specified by <paramref name="deviceInstanceId"/>.
        /// </param>
        /// <param name="deviceInstanceId">
        /// A <see cref="string"/> that supplies the device instance identifier of a device (for example, <c>Root\*PNP0500\0000</c>). If
        /// <paramref name="deviceInstanceId"/> is <see langword="null"/> or <see cref="string.Empty"/>, <see cref="SetupDiOpenDeviceInfo(SafeDeviceInfoSetHandle, string, IntPtr, SetupDiOpenDeviceInfoFlags, SP_DEVINFO_DATA*)"/> adds a
        /// device information element to the supplied device information set, if one does not already exist, for the root device in the device tree.
        /// </param>
        /// <param name="parent">
        /// The handle to the top-level window to use for any user interface related to installing the device.
        /// A <see cref="SetupDiOpenDeviceInfo(SafeDeviceInfoSetHandle, string, IntPtr, SetupDiOpenDeviceInfoFlags, SP_DEVINFO_DATA*)"/> that controls how the device information element is opened.
        /// </param>
        /// <param name="openFlags">
        /// A variable of <see cref="SetupDiOpenDeviceInfo(SafeDeviceInfoSetHandle, string, IntPtr, SetupDiOpenDeviceInfoFlags, SP_DEVINFO_DATA*)"/> that controls how the device information element is opened.
        /// </param>
        /// <param name="deviceInfoData">
        /// A pointer to a caller-supplied <see cref="SP_DEVINFO_DATA"/> structure that receives information about the device information
        /// element for the device instance that is specified by <paramref name="deviceInstanceId"/>. The caller must set <see cref="SP_DEVINFO_DATA.Size"/>.
        /// This parameter is optional and can be <see langword="null"/>.
        /// </param>
        /// <returns>
        /// The function returns <see langword="true"/> if it is successful.
        /// Otherwise, it returns <see langword="false"/> and the logged error can be retrieved with a call to <see cref="Marshal.GetLastWin32Error"/>.
        /// </returns>
        /// <see href="https://msdn.microsoft.com/en-us/library/windows/hardware/ff552071(v=vs.85).aspx"/>
        [DllImport(nameof(SetupApi), SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static unsafe extern bool SetupDiOpenDeviceInfo(
            SafeDeviceInfoSetHandle deviceInfoSet,
            string deviceInstanceId,
            IntPtr parent,
            SetupDiOpenDeviceInfoFlags openFlags,
            [Friendly(FriendlyFlags.Bidirectional)] SP_DEVINFO_DATA* deviceInfoData);

        /// <summary>
        /// The <see cref="SetupDiSetSelectedDevice(SafeDeviceInfoSetHandle, SP_DEVINFO_DATA*)"/> function sets a device information element as the selected member of a device information set.
        /// This function is typically used by an installation wizard.
        /// </summary>
        /// <param name="deviceInfoSet">
        /// A handle to the device information set that contains the device information element to set as the selected member of the device information set.
        /// </param>
        /// <param name="deviceInfoData">
        /// A <see cref="SP_DEVINFO_DATA"/> structure that specifies the device information element in <paramref name="deviceInfoSet"/> to set as the
        /// selected member of <paramref name="deviceInfoSet"/>.
        /// </param>
        /// <returns>
        /// The function returns <see langword="true"/> if it is successful.
        /// Otherwise, it returns <see langword="false"/> and the logged error can be retrieved with a call to <see cref="Marshal.GetLastWin32Error"/>.
        /// </returns>
        /// <seealso href="https://msdn.microsoft.com/en-us/library/windows/hardware/ff552176(v=vs.85).aspx"/>
        [DllImport(nameof(SetupApi), SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static unsafe extern bool SetupDiSetSelectedDevice(
            SafeDeviceInfoSetHandle deviceInfoSet,
            [Friendly(FriendlyFlags.In)] SP_DEVINFO_DATA* deviceInfoData);

        /// <summary>
        /// The <see cref="SetupDiGetDeviceInstallParams(SafeDeviceInfoSetHandle, SP_DEVINFO_DATA*, SP_DEVINSTALL_PARAMS*)"/> function retrieves device installation parameters for a device information
        /// set or a particular device information element.
        /// </summary>
        /// <param name="deviceInfoSet">
        /// A handle to the device information set that contains the device installation parameters to retrieve.
        /// </param>
        /// <param name="deviceInfoData">
        /// A pointer to an <see cref="SP_DEVINFO_DATA"/> structure that specifies the device information element in <paramref name="deviceInfoSet"/>.
        /// This parameter is optional and can be <see langword="null"/>. If this parameter is specified, <see cref="SetupDiGetDeviceInstallParams(SafeDeviceInfoSetHandle, SP_DEVINFO_DATA*, SP_DEVINSTALL_PARAMS*)"/>
        /// retrieves the installation parameters for the specified device. If this parameter is <see langword="null"/>, the function retrieves
        /// the global device installation parameters that are associated with <paramref name="deviceInfoSet"/>.
        /// </param>
        /// <param name="deviceInstallParams">
        /// A pointer to an <see cref="SP_DEVINSTALL_PARAMS"/> structure that receives the device install parameters. <see cref="SP_DEVINSTALL_PARAMS.cbSize"/>
        /// must be set to the size, in bytes, of the structure before calling this function.
        /// </param>
        /// <returns>
        /// The function returns <see langword="true"/> if it is successful.
        /// Otherwise, it returns <see langword="false"/> and the logged error can be retrieved with a call to <see cref="Marshal.GetLastWin32Error"/>.
        /// </returns>
        /// <seealso href="https://msdn.microsoft.com/en-us/library/windows/hardware/ff551104(v=vs.85).aspx"/>
        [DllImport(nameof(SetupApi), SetLastError = true, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static unsafe extern bool SetupDiGetDeviceInstallParams(
            SafeDeviceInfoSetHandle deviceInfoSet,
            [Friendly(FriendlyFlags.In | FriendlyFlags.Optional)] SP_DEVINFO_DATA* deviceInfoData,
            [Friendly(FriendlyFlags.Bidirectional)] SP_DEVINSTALL_PARAMS* deviceInstallParams);

        /// <summary>
        /// The <see cref="SetupDiSetDeviceInstallParams(SafeDeviceInfoSetHandle, SP_DEVINFO_DATA*, SP_DEVINSTALL_PARAMS*)"/> function sets device installation parameters for a device information set
        /// or a particular device information element.
        /// </summary>
        /// <param name="deviceInfoSet">
        /// A handle to the device information set for which to set device installation parameters.
        /// </param>
        /// <param name="deviceInfoData">
        /// A pointer to an <see cref="SP_DEVINFO_DATA"/> structure that specifies a device information element in <paramref name="deviceInfoSet"/>.
        /// This parameter is optional and can be set to <see langword="null"/>. If this parameter is specified, <see cref="SetupDiSetDeviceInstallParams(SafeDeviceInfoSetHandle, SP_DEVINFO_DATA*, SP_DEVINSTALL_PARAMS*)"/>
        /// sets the installation parameters for the specified device. If this parameter is <see langword="null"/>, <see cref="SetupDiSetDeviceInstallParams(SafeDeviceInfoSetHandle, SP_DEVINFO_DATA*, SP_DEVINSTALL_PARAMS*)"/>
        /// sets the installation parameters that are associated with the global class driver list for <paramref name="deviceInfoSet"/>.
        /// </param>
        /// <param name="deviceInstallParams">
        /// An <see cref="SP_DEVINFO_DATA"/> structure that contains the new values of the parameters. The <see cref="SP_DEVINSTALL_PARAMS.cbSize"/>
        /// must be set to the size, in bytes, of the structure before this function is called.
        /// </param>
        /// <returns>
        /// The function returns <see langword="true"/> if it is successful.
        /// Otherwise, it returns <see langword="false"/> and the logged error can be retrieved with a call to <see cref="Marshal.GetLastWin32Error"/>.
        /// </returns>
        /// <seealso href="https://msdn.microsoft.com/en-us/library/windows/hardware/ff552141(v=vs.85).aspx"/>
        [DllImport(nameof(SetupApi), SetLastError = true, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static unsafe extern bool SetupDiSetDeviceInstallParams(
            SafeDeviceInfoSetHandle deviceInfoSet,
            [Friendly(FriendlyFlags.In | FriendlyFlags.Optional)] SP_DEVINFO_DATA* deviceInfoData,
            [Friendly(FriendlyFlags.In)] SP_DEVINSTALL_PARAMS* deviceInstallParams);

        /// <summary>
        /// The <see cref="SetupDiBuildDriverInfoList(SafeDeviceInfoSetHandle, SP_DEVINFO_DATA*, DriverType)"/> function builds a list of drivers that is associated with a specific device or with the
        /// global class driver list for a device information set.
        /// </summary>
        /// <param name="deviceInfoSet">
        /// A handle to the device information set to contain the driver list, either globally for all device information elements or specifically
        /// for a single device information element. The device information set must not contain remote device information elements.
        /// </param>
        /// <param name="deviceInfoData">
        /// A pointer to an <see cref="SP_DEVINFO_DATA"/> structure for the device information element in <paramref name="deviceInfoSet"/> that
        /// represents the device for which to build a driver list.This parameter is optional and can be <see langword="null"/>. If this parameter
        /// is specified, the list is associated with the specified device. If this parameter is <see langword="null"/>, the list is associated
        /// with the global class driver list for <paramref name="deviceInfoSet"/>.
        /// <para>
        /// </para>
        /// <para>
        /// If the class of this device is updated because of building a compatible driver list, <see cref="SP_DEVINFO_DATA.ClassGuid"/> is updated upon return.
        /// </para>
        /// </param>
        /// <param name="driverType">
        /// The type of driver list to build.
        /// </param>
        /// <returns>
        /// The function returns <see langword="true"/> if it is successful.
        /// Otherwise, it returns <see langword="false"/> and the logged error can be retrieved with a call to <see cref="Marshal.GetLastWin32Error"/>.
        /// </returns>
        /// <seealso href="https://msdn.microsoft.com/en-us/library/windows/hardware/ff550917(v=vs.85).aspx"/>
        [DllImport(nameof(SetupApi), SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static unsafe extern bool SetupDiBuildDriverInfoList(
            SafeDeviceInfoSetHandle deviceInfoSet,
            [Friendly(FriendlyFlags.In | FriendlyFlags.Optional)] SP_DEVINFO_DATA* deviceInfoData,
            DriverType driverType);

        /// <summary>
        /// The <see cref="SetupDiEnumDriverInfo(SafeDeviceInfoSetHandle, SP_DEVINFO_DATA*, DriverType, uint, SP_DRVINFO_DATA*)"/> function enumerates the members of a driver list.
        /// </summary>
        /// <param name="deviceInfoSet">
        /// A handle to the device information set that contains the driver list to enumerate.
        /// </param>
        /// <param name="deviceInfoData">
        /// An <see cref="SP_DEVINFO_DATA"/> structure that specifies a device information element in <paramref name="deviceInfoSet"/>.
        /// This parameter is optional and can be <see langword="null"/>. If this parameter is specified, <see cref="SetupDiEnumDriverInfo(SafeDeviceInfoSetHandle, SP_DEVINFO_DATA*, DriverType, uint, SP_DRVINFO_DATA*)"/>
        /// enumerates a driver list for the specified device. If this parameter is <see langword="null"/>, <see cref="SetupDiEnumDriverInfo(SafeDeviceInfoSetHandle, SP_DEVINFO_DATA*, DriverType, uint, SP_DRVINFO_DATA*)"/>
        /// enumerates the global class driver list that is associated with <paramref name="deviceInfoSet"/> (this list is of type
        /// <c>SPDIT_CLASSDRIVER</c>).
        /// </param>
        /// <param name="driverType">
        /// The type of driver list to enumerate.
        /// </param>
        /// <param name="memberIndex">
        /// The zero-based index of the driver information member to retrieve.
        /// </param>
        /// <param name="driverInfoData">
        /// A caller-initialized <see cref="SP_DRVINFO_DATA"/> structure that receives information about the enumerated driver.
        /// The caller must set <see cref="SP_DRVINFO_DATA.cbSize"/> before calling <see cref="SetupDiEnumDriverInfo(SafeDeviceInfoSetHandle, SP_DEVINFO_DATA*, DriverType, uint, SP_DRVINFO_DATA*)"/>.
        /// If the <see cref="SP_DRVINFO_DATA.cbSize"/> member is not properly set, <see cref="SetupDiEnumDriverInfo(SafeDeviceInfoSetHandle, SP_DEVINFO_DATA*, DriverType, uint, SP_DRVINFO_DATA*)"/> will return
        /// <see langword="false"/>.
        /// </param>
        /// <remarks>
        /// To enumerate driver information set members, an installer should first call <see cref="SetupDiEnumDriverInfo(SafeDeviceInfoSetHandle, SP_DEVINFO_DATA*, DriverType, uint, SP_DRVINFO_DATA*)"/> with the
        /// <paramref name="memberIndex"/> parameter set to <c>0</c>. It should then increment <paramref name="memberIndex"/> and call
        /// <see cref="SetupDiEnumDriverInfo(SafeDeviceInfoSetHandle, SP_DEVINFO_DATA*, DriverType, uint, SP_DRVINFO_DATA*)"/> until there are no more values. When there are no more values, the function fails and a call to
        /// <see cref="Marshal.GetLastWin32Error"/> returns <see cref="Win32ErrorCode.ERROR_NO_MORE_ITEMS"/>.
        /// </remarks>
        /// <returns>
        /// The function returns <see langword="true"/> if it is successful.
        /// Otherwise, it returns <see langword="false"/> and the logged error can be retrieved with a call to <see cref="Marshal.GetLastWin32Error"/>.
        /// </returns>
        /// <seealso href="https://msdn.microsoft.com/en-us/library/windows/hardware/ff551018(v=vs.85).aspx"/>
        [DllImport(nameof(SetupApi), SetLastError = true, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static unsafe extern bool SetupDiEnumDriverInfo(
            SafeDeviceInfoSetHandle deviceInfoSet,
            [Friendly(FriendlyFlags.In | FriendlyFlags.Optional)] SP_DEVINFO_DATA* deviceInfoData,
            DriverType driverType,
            uint memberIndex,
            [Friendly(FriendlyFlags.Bidirectional)] SP_DRVINFO_DATA* driverInfoData);

        /// <summary>
        /// The <see cref="SetupDiSetSelectedDriver(SafeDeviceInfoSetHandle, SP_DEVINFO_DATA*, SP_DRVINFO_DATA*)"/> function sets, or resets, the selected driver for a device information element or the
        /// selected class driver for a device information set.
        /// </summary>
        /// <param name="deviceInfoSet">
        /// A handle to the device information set that contains the driver list from which to select a driver for a device information element
        /// or for the device information set.
        /// </param>
        /// <param name="deviceInfoData">
        /// A pointer to an <see cref="SP_DEVINFO_DATA"/> structure that specifies the device information element in <paramref name="deviceInfoSet"/>.
        /// This parameter is optional and can be <see langword="null"/>. If this parameter is specified, <see cref="SetupDiSetSelectedDriver(SafeDeviceInfoSetHandle, SP_DEVINFO_DATA*, SP_DRVINFO_DATA*)"/> sets,
        /// or resets, the selected driver for the specified device. If this parameter is <see langword="null"/>, <see cref="SetupDiSetSelectedDriver(SafeDeviceInfoSetHandle, SP_DEVINFO_DATA*, SP_DRVINFO_DATA*)"/>
        /// sets, or resets, the selected class driver for <paramref name="deviceInfoSet"/>.
        /// </param>
        /// <param name="driverInfoData">
        /// <para>
        /// An <see cref="SP_DRVINFO_DATA"/> structure that specifies the driver to be selected. This parameter is optional and can be <see langword="null"/>.
        /// If this parameter and <paramref name="deviceInfoData"/> are supplied, the specified driver must be a member of a driver list that is associated
        /// with <paramref name="deviceInfoData"/>. If this parameter is specified and <paramref name="deviceInfoData"/> is <see langword="null"/>, the
        /// driver must be a member of the global class driver list for <paramref name="deviceInfoSet"/>. If this parameter is <see langword="null"/>, the
        /// selected driver is reset for the device information element, if <paramref name="deviceInfoData"/> is specified, or the device information set,
        /// if <paramref name="deviceInfoData"/> is <see langword="null"/>.
        /// </para>
        /// <para>
        /// If the <see cref="SP_DRVINFO_DATA.Reserved"/> is <see langword="null"/>, the caller is requesting a search for a driver node with the specified
        /// parameters (<see cref="SP_DRVINFO_DATA.DriverType"/>, <see cref="SP_DRVINFO_DATA.Description"/>, and <see cref="SP_DRVINFO_DATA.ProviderName"/>).
        /// If a match is found, that driver node is selected. The <see cref="SP_DRVINFO_DATA.Reserved"/> field is updated on output to reflect
        /// the actual driver node where the match was found. If a match is not found, the function fails and a call to <see cref="Marshal.GetLastWin32Error"/>
        /// returns <c>ERROR_INVALID_PARAMETER</c>.
        /// </para>
        /// </param>
        /// <returns>
        /// The function returns <see langword="true"/> if it is successful.
        /// Otherwise, it returns <see langword="false"/> and the logged error can be retrieved with a call to <see cref="Marshal.GetLastWin32Error"/>.
        /// </returns>
        /// <seealso href="https://msdn.microsoft.com/en-us/library/windows/hardware/ff552183(v=vs.85).aspx"/>
        [DllImport(nameof(SetupApi), SetLastError = true, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static unsafe extern bool SetupDiSetSelectedDriver(
            SafeDeviceInfoSetHandle deviceInfoSet,
            [Friendly(FriendlyFlags.In | FriendlyFlags.Optional)] SP_DEVINFO_DATA* deviceInfoData,
            [Friendly(FriendlyFlags.Bidirectional | FriendlyFlags.Optional)] SP_DRVINFO_DATA* driverInfoData);

        /// <summary>
        /// Retrieves driver information detail for a device information set or a particular device information element in the device information set.
        /// </summary>
        /// <param name="deviceInfoSet">
        /// A handle to a device information set that contains a driver information element for which to retrieve driver information.
        /// </param>
        /// <param name="deviceInfoData">
        /// A pointer to an <see cref="SP_DEVINFO_DATA"/> structure that specifies a device information element that represents the device
        /// for which to retrieve driver information. This parameter is optional and can be <see langword="null"/>.
        /// If this parameter is specified, <see cref="SetupDiGetDriverInfoDetail(SafeDeviceInfoSetHandle, SP_DEVINFO_DATA*, SP_DRVINFO_DATA*, byte*, int, out int)"/> retrieves information about a driver in a driver list
        /// for the specified device.
        /// If this parameter is <see langword="null"/>, SetupDiGetDriverInfoDetail retrieves information about a driver that is a member of
        /// the global class driver list for <paramref name="deviceInfoSet"/>.
        /// </param>
        /// <param name="driverInfoData">
        /// A pointer to an <see cref="SP_DRVINFO_DATA"/> structure that specifies the driver information element that represents the driver
        /// for which to retrieve details. If DeviceInfoData is specified, the driver must be a member of the driver list for the device that
        /// is specified by <paramref name="deviceInfoData"/>. Otherwise, the driver must be a member of the global class driver list for
        /// <paramref name="deviceInfoSet"/>.
        /// </param>
        /// <param name="driverInfoDetailData">
        /// A pointer to an <see cref="SP_DRVINFO_DETAIL_DATA"/> structure that receives detailed information about the specified driver.
        /// If this parameter is not specified, <paramref name="driverInfoDetailDataSize"/> must be zero.
        /// If this parameter is specified, <see cref="SP_DRVINFO_DETAIL_DATA.cbSize"/> must be set to the value of <c>sizeof(SP_DRVINFO_DETAIL_DATA)</c>
        /// before it calls SetupDiGetDriverInfoDetail.
        /// </param>
        /// <param name="driverInfoDetailDataSize">
        /// The size, in bytes, of the <paramref name="driverInfoDetailData"/> buffer.
        /// </param>
        /// <param name="requiredSize">
        /// A pointer to a variable that receives the number of bytes required to store the detailed driver information.
        /// This value includes both the size of the structure and the additional bytes required for the variable-length character buffer at the
        /// end that holds the hardware ID list and the compatible ID list. The lists are in REG_MULTI_SZ format.
        /// </param>
        /// <returns>
        /// The function returns <see langword="true"/> if it is successful.
        /// Otherwise, it returns <see langword="false"/>and the logged error can be retrieved by making a call to <see cref="Marshal.GetLastWin32Error"/>.
        /// </returns>
        /// <seealso href="https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupdigetdriverinfodetaila"/>
        [DllImport(nameof(SetupApi), SetLastError = true, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static unsafe extern bool SetupDiGetDriverInfoDetail(
           SafeDeviceInfoSetHandle deviceInfoSet,
           [Friendly(FriendlyFlags.In | FriendlyFlags.Optional)] SP_DEVINFO_DATA* deviceInfoData,
           [Friendly(FriendlyFlags.In | FriendlyFlags.Optional)] SP_DRVINFO_DATA* driverInfoData,
           [Friendly(FriendlyFlags.Bidirectional)] byte* driverInfoDetailData,
           int driverInfoDetailDataSize,
           out int requiredSize);

        /// <summary>
        /// Deletes a device information set and frees all associated memory.
        /// </summary>
        /// <param name="deviceInfoSet">A handle to the device information set to delete.</param>
        /// <returns>
        /// Returns <see langword="true" /> if the function completed without error. If the function completed with an
        /// error, <see langword="false" /> is returned and the error code for the failure can be retrieved by calling
        /// <see cref="Marshal.GetLastWin32Error" />.
        /// </returns>
#if NETFRAMEWORK || NETSTANDARD2_0_ORLATER
        [SuppressUnmanagedCodeSecurity]
        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
#endif
        [DllImport(nameof(SetupApi), SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool SetupDiDestroyDeviceInfoList(IntPtr deviceInfoSet);
    }
}
