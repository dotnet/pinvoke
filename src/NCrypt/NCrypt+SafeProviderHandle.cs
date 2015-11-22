// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Runtime.InteropServices;

    /// <content>
    /// Contains the <see cref="SafeProviderHandle"/> nested class.
    /// </content>
    public partial class NCrypt
    {
        /// <summary>
        /// An NCrypt open storage provider handle.
        /// </summary>
        public class SafeProviderHandle : SafeHandle
        {
            /// <summary>
            /// A handle that may be used in place of <see cref="IntPtr.Zero"/>.
            /// </summary>
            internal static readonly SafeProviderHandle NullHandle = new SafeProviderHandle();

            /// <summary>
            /// Initializes a new instance of the <see cref="SafeProviderHandle"/> class.
            /// </summary>
            public SafeProviderHandle()
                : base(IntPtr.Zero, true)
            {
            }

            /// <inheritdoc />
            public override bool IsInvalid => this.handle == IntPtr.Zero;

            /// <inheritdoc />
            protected override bool ReleaseHandle()
            {
                return NCryptFreeObject(this.handle) == SECURITY_STATUS.ERROR_SUCCESS;
            }
        }
    }
}
