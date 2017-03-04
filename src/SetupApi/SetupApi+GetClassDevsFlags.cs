// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    /// <content>
    /// Contains the <see cref="GetClassDevsFlags"/> nested type.
    /// </content>
    public partial class SetupApi
    {
        /// <summary>
        /// Control options that filter the device information elements that are added to the device information set by
        /// <see cref="SetupDiGetClassDevs(Guid*,string,IntPtr,GetClassDevsFlags)" />
        /// </summary>
        [Flags]
        [SuppressMessage("ReSharper", "InconsistentNaming", Justification = "Original API names are used for consistency")]
        public enum GetClassDevsFlags
        {
            /// <summary>
            /// Return a list of installed devices for all device setup classes or all device interface classes.
            /// </summary>
            DIGCF_ALLCLASSES = 0x00000004,

            /// <summary>
            /// Return devices that support device interfaces for the specified device interface classes.
            /// This flag must be set in the Flags parameter if the Enumerator parameter specifies a device instance ID.
            /// </summary>
            DIGCF_DEVICEINTERFACE = 0x00000010,

            /// <summary>
            /// Return only the device that is associated with the system default device interface, if one is set,
            /// for the specified device interface classes.
            /// </summary>
            DIGCF_DEFAULT = 0x00000001,

            /// <summary>
            /// Return only devices that are currently present in a system.
            /// </summary>
            DIGCF_PRESENT = 0x00000002,

            /// <summary>
            /// Return only devices that are a part of the current hardware profile.
            /// </summary>
            DIGCF_PROFILE = 0x00000008
        }
    }
}