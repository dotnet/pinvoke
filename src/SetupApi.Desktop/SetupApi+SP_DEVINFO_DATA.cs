// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.InteropServices;

    /// <content>
    /// Contains the <see cref="SP_DEVINFO_DATA" /> nested type.
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
        public struct SP_DEVINFO_DATA
        {
            /// <summary>
            /// The GUID of the device's setup class.
            /// </summary>
            public Guid ClassGuid;

            /// <summary>
            /// An opaque handle to the device instance (also known as a handle to the devnode).
            /// <para>
            /// Some functions, such as SetupDiXxx functions, take the whole <see cref="SP_DEVINFO_DATA" /> structure as input to
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
            /// The size, in bytes, of the <see cref="SP_DEVINFO_DATA" /> structure. The constructor set this value automatically
            /// to the correct size.
            /// </summary>
            public int Size;

            /// <summary>
            /// Initializes a new instance of the <see cref="SP_DEVINFO_DATA" /> struct
            /// with <see cref="Size" /> set to the correct value.
            /// </summary>
            /// <returns>An instance of <see cref="SP_DEVINFO_DATA"/>.</returns>
            public static SP_DEVINFO_DATA Create()
            {
                return new SP_DEVINFO_DATA
                {
                    Size = Marshal.SizeOf(typeof(SP_DEVINFO_DATA)),
                };
            }
        }
    }
}