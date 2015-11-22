// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Runtime.InteropServices;
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
        SafeDeviceInfoSetHandle InvokeSetupDiGetClassDevs(
            NullableGuid classGuid,
            string enumerator,
            IntPtr hwndParent,
            GetClassDevsFlags flags);
	}
}