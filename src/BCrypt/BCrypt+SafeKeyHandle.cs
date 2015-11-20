// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Runtime.InteropServices;

    /// <content>
    /// The <see cref="SafeKeyHandle"/> nested class.
    /// </content>
    public static partial class BCrypt
    {
        /// <summary>
        /// A BCrypt cryptographic key handle.
        /// </summary>
        public class SafeKeyHandle : SafeHandle
        {
            /// <summary>
            /// A handle that may be used in place of <see cref="IntPtr.Zero"/>.
            /// </summary>
            public static readonly SafeKeyHandle NullHandle = new SafeKeyHandle();

            /// <summary>
            /// Initializes a new instance of the <see cref="SafeKeyHandle"/> class.
            /// </summary>
            public SafeKeyHandle()
                : base(IntPtr.Zero, true)
            {
            }

            /// <inheritdoc />
            public override bool IsInvalid => this.handle == IntPtr.Zero;

            /// <inheritdoc />
            protected override bool ReleaseHandle()
            {
                return BCryptDestroyKey(this.handle) == NTStatus.STATUS_SUCCESS;
            }
        }
    }
}
