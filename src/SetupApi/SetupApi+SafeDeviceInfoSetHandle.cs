// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Runtime.InteropServices;
    using static Kernel32;

    /// <content>
    /// Contains the <see cref="SafeDeviceInfoSetHandle"/> nested type.
    /// </content>
    public partial class SetupApi
    {
        /// <summary>
        /// Represents a preparsed data handle created by
        /// <see cref="SetupDiEnumDeviceInterfaces(SafeDeviceInfoSetHandle,SP_DEVINFO_DATA*,ref Guid,int,ref SP_DEVICE_INTERFACE_DATA)"/>
        /// that can be closed with <see cref="SetupDiDestroyDeviceInfoList"/>.
        /// </summary>
        public class SafeDeviceInfoSetHandle : SafeHandle
        {
            /// <summary>
            /// A handle that may be used in place of <see cref="INVALID_HANDLE_VALUE"/>.
            /// </summary>
            public static readonly SafeDeviceInfoSetHandle Invalid = new SafeDeviceInfoSetHandle();

            /// <summary>
            /// Initializes a new instance of the <see cref="SafeDeviceInfoSetHandle"/> class.
            /// </summary>
            public SafeDeviceInfoSetHandle()
                : base(INVALID_HANDLE_VALUE, true)
            {
            }

            /// <summary>
            /// Initializes a new instance of the <see cref="SafeDeviceInfoSetHandle"/> class.
            /// </summary>
            /// <param name="preexistingHandle">An object that represents the pre-existing handle to use.</param>
            /// <param name="ownsHandle">
            ///     <see langword="true" /> to have the native handle released when this safe handle is disposed or finalized;
            ///     <see langword="false" /> otherwise.
            /// </param>
            public SafeDeviceInfoSetHandle(IntPtr preexistingHandle, bool ownsHandle = true)
                : base(INVALID_HANDLE_VALUE, ownsHandle)
            {
                this.SetHandle(preexistingHandle);
            }

            public override bool IsInvalid => this.handle == INVALID_HANDLE_VALUE;

            protected override bool ReleaseHandle() => SetupDiDestroyDeviceInfoList(this.handle);
        }
    }
}
