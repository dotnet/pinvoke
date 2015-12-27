// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    using System.Text;

    /// <content>
    /// Contains the <see cref="SafeCertStoreHandle"/> nested type.
    /// </content>
    public partial class Crypt32
    {
        /// <summary>
        /// A safe handle for certificate stores.
        /// </summary>
        public class SafeCertStoreHandle : SafeHandle
        {
            /// <summary>
            /// A handle that may be used in place of <see cref="IntPtr.Zero"/>.
            /// </summary>
            public static readonly SafeCertStoreHandle Null = new SafeCertStoreHandle();

            /// <summary>
            /// Initializes a new instance of the <see cref="SafeCertStoreHandle"/> class.
            /// </summary>
            public SafeCertStoreHandle()
                : base(IntPtr.Zero, true)
            {
            }

            /// <inheritdoc />
            public override bool IsInvalid => this.handle == IntPtr.Zero;

            /// <inheritdoc />
            protected override bool ReleaseHandle()
            {
                return CertCloseStore(this.handle);
            }
        }
    }
}
