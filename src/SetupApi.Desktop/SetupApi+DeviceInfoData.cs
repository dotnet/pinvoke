// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.InteropServices;

    /// <content>
    /// Contains the <see cref="DeviceInfoData" /> nested struct.
    /// </content>
    public partial class SetupApi
    {
        /// <summary>
        /// Defines a device instance that is a member of a device information set.
        /// </summary>
        [SuppressMessage(
            "StyleCop.CSharp.MaintainabilityRules",
            "SA1401:Fields must be private",
            Justification = "Used in DllImport Marshaling.")]
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public class DeviceInfoData
        {
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
            /// The size, in bytes, of the <see cref="DeviceInfoData" /> structure. The constructor set this value automatically
            /// to the correct size.
            /// </summary>
            public uint Size;

            /// <summary>
            /// Initializes a new instance of the <see cref="DeviceInfoData" /> class with <see cref="Size" /> set to the correct
            /// value.
            /// </summary>
            public DeviceInfoData()
            {
                this.Size = (uint)Marshal.SizeOf(this);
            }
        }
    }
}