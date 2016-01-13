// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Runtime.InteropServices;

    /// <content>
    /// The <see cref="SafeHashHandle"/> nested class.
    /// </content>
    public static partial class BCrypt
    {
        /// <summary>
        /// A BCrypt cryptographic hash handle.
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

            /// <inheritdoc />
            public override bool IsInvalid => this.handle == IntPtr.Zero;

            /// <inheritdoc />
            protected override bool ReleaseHandle()
            {
                return BCryptDestroyHash(this.handle) == NTSTATUS.Code.STATUS_SUCCESS;
            }
        }
    }
}
