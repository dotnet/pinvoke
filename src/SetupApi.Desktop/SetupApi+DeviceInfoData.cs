// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Runtime.InteropServices;

    /// <content>
    /// Contains the <see cref="DeviceInfoData"/> nested struct.
    /// </content>
    public partial class SetupApi
    {
        /// <summary>
        /// Defines a device instance that is a member of a device information set.
        /// </summary>
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct DeviceInfoData
        {
            /// <summary>
            /// The size, in bytes, of the <see cref="DeviceInfoData" /> structure. <see cref="Create" /> set this value automatically
            /// to the correct value.
            /// </summary>
            public uint Size;

            /// <summary>
            /// The GUID of the device's setup class.
            /// </summary>
            public Guid ClassGuid;

            /// <summary>
            /// An opaque handle to the device instance (also known as a handle to the devnode).
            /// <para>
            /// Some functions, such as SetupDiXxx functions, take the whole <see cref="DeviceInfoData" /> structure as input to
            /// identify a device in a device information set.Other functions, such as CM_Xxx functions like CM_Get_DevNode_Status,
            /// take this DevInst handle as input.
            /// </para>
            /// </summary>
            public uint DevInst;

            /// <summary>
            /// Reserved. For internal use only.
            /// </summary>
            public IntPtr Reserved;

            /// <summary>
            /// Create an instance with <see cref="Size" /> set to the correct value.
            /// </summary>
            /// <returns>An instance of <see cref="DeviceInfoData" /> with it's <see cref="Size" /> member set.</returns>
            public static DeviceInfoData Create()
            {
                var result = default(DeviceInfoData);
                result.Size = (uint)Marshal.SizeOf(result);
                return result;
            }
        }
    }
}