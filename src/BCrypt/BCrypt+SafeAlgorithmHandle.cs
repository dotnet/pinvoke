// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Runtime.InteropServices;

    /// <content>
    /// The <see cref="SafeAlgorithmHandle"/> nested class.
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
            internal static readonly SafeAlgorithmHandle NullHandle = new SafeAlgorithmHandle();

            /// <summary>
            /// Initializes a new instance of the <see cref="SafeAlgorithmHandle"/> class.
            /// </summary>
            public SafeAlgorithmHandle()
                : base(IntPtr.Zero, true)
            {
            }

            /// <inheritdoc />
            public override bool IsInvalid => this.handle == IntPtr.Zero;

            /// <inheritdoc />
            protected override bool ReleaseHandle()
            {
                return BCryptCloseAlgorithmProvider(this.handle, 0) == NTStatus.STATUS_SUCCESS;
            }
        }
    }
}
