// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Runtime.InteropServices;

    /// <content>
    /// Contains the <see cref="SafeServiceHandle"/> nested type.
    /// </content>
    public partial class AdvApi32
    {
        /// <summary>
        /// Represents a preparsed data handle created by
        /// <see cref="OpenSCManager(string,string,Kernel32.ACCESS_MASK)"/> or <see cref="OpenService(SafeServiceHandle,string,Kernel32.ACCESS_MASK)"/>
        /// that can be closed with <see cref="CloseServiceHandle"/>.
        /// </summary>
        public class SafeServiceHandle : SafeHandle
        {
            /// <summary>
            /// A handle that may be used in place of <see cref="IntPtr.Zero"/>.
            /// </summary>
            public static readonly SafeServiceHandle Null = new SafeServiceHandle();

            /// <summary>
            /// Initializes a new instance of the <see cref="SafeServiceHandle"/> class.
            /// </summary>
            public SafeServiceHandle()
                : base(IntPtr.Zero, true)
            {
            }

            /// <summary>
            /// Initializes a new instance of the <see cref="SafeServiceHandle"/> class.
            /// </summary>
            /// <param name="preexistingHandle">An object that represents the pre-existing handle to use.</param>
            /// <param name="ownsHandle">
            ///     <see langword="true" /> to have the native handle released when this safe handle is disposed or finalized;
            ///     <see langword="false" /> otherwise.
            /// </param>
            public SafeServiceHandle(IntPtr preexistingHandle, bool ownsHandle = true)
                : base(IntPtr.Zero, ownsHandle)
            {
                this.SetHandle(preexistingHandle);
            }

            /// <inheritdoc />
            public override bool IsInvalid => this.handle == IntPtr.Zero;

            /// <inheritdoc />
            protected override bool ReleaseHandle() => CloseServiceHandle(this.handle);
        }
    }
}
