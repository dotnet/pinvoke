// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Runtime.InteropServices;

    /// <content>
    /// Contains the <see cref="SafeKeyHandle"/> nested type.
    /// </content>
    public static partial class NCrypt
    {
        /// <summary>
        /// An NCrypt key handle.
        /// </summary>
        public class SafeKeyHandle : SafeHandle
        {
            /// <summary>
            /// A handle that may be used in place of <see cref="IntPtr.Zero"/>.
            /// </summary>
            public static readonly SafeKeyHandle Null = new SafeKeyHandle();

            /// <summary>
            /// Initializes a new instance of the <see cref="SafeKeyHandle"/> class.
            /// </summary>
            public SafeKeyHandle()
                : base(IntPtr.Zero, true)
            {
            }

            /// <summary>
            /// Initializes a new instance of the <see cref="SafeKeyHandle"/> class.
            /// </summary>
            /// <param name="preexistingHandle">An object that represents the pre-existing handle to use.</param>
            /// <param name="ownsHandle">
            ///     <see langword="true" /> to have the native handle released when this safe handle is disposed or finalized;
            ///     <see langword="false" /> otherwise.
            /// </param>
            public SafeKeyHandle(IntPtr preexistingHandle, bool ownsHandle = true)
                : base(IntPtr.Zero, ownsHandle)
            {
                this.SetHandle(preexistingHandle);
            }

            /// <inheritdoc />
            public override bool IsInvalid => this.handle == IntPtr.Zero/*Desktop only: || !NCryptIsKeyHandle(this.handle)*/;

            /// <inheritdoc />
            protected override bool ReleaseHandle()
            {
                return NCryptFreeObject(this.handle) == SECURITY_STATUS.ERROR_SUCCESS;
            }
        }
    }
}
