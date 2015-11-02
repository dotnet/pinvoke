// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Runtime.InteropServices;

    /// <summary>
    /// Contains the <see cref="SafeServiceHandler"/> nested class.
    /// </summary>
    public static partial class AdvApi32
    {
        /// <summary>
        /// Represents a preparsed data handle created by
        /// <see cref="OpenSCManager(string,string,ServiceManagerAccess)"/> or <see cref="OpenService(SafeServiceHandler,string,ServiceAccess)"/>
        /// that can be closed with <see cref="CloseServiceHandle"/>.
        /// </summary>
        public class SafeServiceHandler : SafeHandle
        {
            /// <summary>
            /// A handle that may be used in place of <see cref="IntPtr.Zero"/>.
            /// </summary>
            internal static readonly SafeServiceHandler NullHandle = new SafeServiceHandler();

            /// <summary>
            /// Initializes a new instance of the <see cref="SafeServiceHandler"/> class.
            /// </summary>
            public SafeServiceHandler()
                : base(IntPtr.Zero, true)
            {
            }

            /// <summary>
            /// Initializes a new instance of the <see cref="SafeServiceHandler"/> class.
            /// </summary>
            /// <param name="preexistingHandle">An object that represents the pre-existing handle to use.</param>
            /// <param name="ownsHandle"><see langword="true"/> to reliably release the handle during the finalization
            /// phase; <see langword="false"/> to prevent reliable release.</param>
            public SafeServiceHandler(IntPtr preexistingHandle, bool ownsHandle)
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
