// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Runtime.InteropServices;

    /// <content>
    /// Contains the <see cref="SafeHashHandle"/> nested type.
    /// </content>
    public static partial class AdvApi32
    {
        /// <summary>
        /// A cryptographic hash algorithm handle.
        /// </summary>
        public class SafeHashHandle : SafeHandle
        {
            /// <summary>
            /// A handle that may be used in place of <see cref="IntPtr.Zero"/>.
            /// </summary>
            public static readonly SafeHashHandle Null = new SafeHashHandle();

            /// <summary>
            /// Initializes a new instance of the <see cref="SafeHashHandle"/> class.
            /// </summary>
            public SafeHashHandle()
                : base(IntPtr.Zero, true)
            {
            }

            /// <summary>
            /// Initializes a new instance of the <see cref="SafeHashHandle"/> class.
            /// </summary>
            /// <param name="preexistingHandle">An object that represents the pre-existing handle to use.</param>
            /// <param name="ownsHandle">
            ///     <see langword="true" /> to have the native handle released when this safe handle is disposed or finalized;
            ///     <see langword="false" /> otherwise.
            /// </param>
            public SafeHashHandle(IntPtr preexistingHandle, bool ownsHandle = true)
                : base(IntPtr.Zero, ownsHandle)
            {
                this.SetHandle(preexistingHandle);
            }

            /// <inheritdoc />
            public override bool IsInvalid => this.handle == IntPtr.Zero;

            /// <inheritdoc />
            protected override bool ReleaseHandle()
            {
                return CryptDestroyHash(this.handle);
            }
        }
    }
}
