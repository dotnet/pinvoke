// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Runtime.InteropServices;

    /// <content>
    /// The <see cref="SafeAlgorithmHandle"/> nested type.
    /// </content>
    public static partial class BCrypt
    {
        /// <summary>
        /// A BCrypt algorithm handle.
        /// </summary>
        public class SafeAlgorithmHandle : SafeHandle
        {
            /// <summary>
            /// A handle that may be used in place of <see cref="IntPtr.Zero"/>.
            /// </summary>
            public static readonly SafeAlgorithmHandle Null = new SafeAlgorithmHandle();

            /// <summary>
            /// Initializes a new instance of the <see cref="SafeAlgorithmHandle"/> class.
            /// </summary>
            public SafeAlgorithmHandle()
                : base(IntPtr.Zero, true)
            {
            }

            /// <summary>
            /// Initializes a new instance of the <see cref="SafeAlgorithmHandle"/> class.
            /// </summary>
            /// <param name="preexistingHandle">An object that represents the pre-existing handle to use.</param>
            /// <param name="ownsHandle">
            ///     <see langword="true" /> to have the native handle released when this safe handle is disposed or finalized;
            ///     <see langword="false" /> otherwise.
            /// </param>
            public SafeAlgorithmHandle(IntPtr preexistingHandle, bool ownsHandle = true)
                : base(IntPtr.Zero, ownsHandle)
            {
                this.SetHandle(preexistingHandle);
            }

            /// <inheritdoc />
            public override bool IsInvalid => this.handle == IntPtr.Zero;

            /// <inheritdoc />
            protected override bool ReleaseHandle()
            {
                return BCryptCloseAlgorithmProvider(this.handle, 0) == NTSTATUS.Code.STATUS_SUCCESS;
            }
        }
    }
}
