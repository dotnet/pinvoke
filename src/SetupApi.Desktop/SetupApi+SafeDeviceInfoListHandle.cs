// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Runtime.InteropServices;
    using static PInvoke.Kernel32;

    /// <content>
    /// Contains the <see cref="SafeDeviceInfoSetHandle"/> nested class.
    /// </content>
    public partial class SetupApi
    {
        /// <summary>
        /// Represents a preparsed data handle created by
        /// <see cref="SetupDiEnumDeviceInterfaces"/>
        /// that can be closed with <see cref="SetupDiDestroyDeviceInfoList"/>.
        /// </summary>
        public class SafeDeviceInfoSetHandle : SafeHandle
        {
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
            /// <param name="ownsHandle"><see langword="true"/> to reliably release the handle during the finalization
            /// phase; <see langword="false"/> to prevent reliable release.</param>
            public SafeDeviceInfoSetHandle(IntPtr preexistingHandle, bool ownsHandle)
                : base(INVALID_HANDLE_VALUE, ownsHandle)
            {
                this.SetHandle(preexistingHandle);
            }

            public override bool IsInvalid => this.handle == INVALID_HANDLE_VALUE;

            protected override bool ReleaseHandle() => SetupDiDestroyDeviceInfoList(this);
        }
    }
}
