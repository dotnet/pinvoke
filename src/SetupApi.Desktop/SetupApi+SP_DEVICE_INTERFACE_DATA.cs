// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Runtime.InteropServices;

    /// <content>
    /// Contains the <see cref="SP_DEVICE_INTERFACE_DATA"/> nested type.
    /// </content>
    public partial class SetupApi
    {
        /// <summary>
        /// Defines a device interface in a device information set.
        /// </summary>
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct SP_DEVICE_INTERFACE_DATA
        {
            /// <summary>
            /// The size, in bytes, of the <see cref="SP_DEVICE_INTERFACE_DATA" /> structure. <see cref="Create" /> set this value
            /// automatically
            /// to the correct value.
            /// </summary>
            public int Size;

            /// <summary>
            /// The GUID for the class to which the device interface belongs.
            /// </summary>
            public Guid InterfaceClassGuid;

            /// <summary>
            /// One or more of the <see cref="DeviceInterfaceDataFlags" /> values.
            /// </summary>
            public DeviceInterfaceDataFlags Flags;

            /// <summary>
            /// Reserved. Do not use.
            /// </summary>
            public IntPtr Reserved;

            /// <summary>
            /// Create an instance with <see cref="Size" /> set to the correct value.
            /// </summary>
            /// <returns>An instance of <see cref="SP_DEVICE_INTERFACE_DATA" /> with it's <see cref="Size" /> member set.</returns>
            public static SP_DEVICE_INTERFACE_DATA Create()
            {
                var result = default(SP_DEVICE_INTERFACE_DATA);
                result.Size = Marshal.SizeOf(result);
                return result;
            }
        }
    }
}