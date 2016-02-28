// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Text;

    /// <content>
    /// Contains the <see cref="SafeNTObjectHandle"/> nested type.
    /// </content>
    public partial class NTDll
    {
        /// <summary>
        /// A <see cref="SafeHandle"/> that closes with <see cref="NtClose(IntPtr)"/>.
        /// </summary>
        public class SafeNTObjectHandle : SafeHandle
        {
            /// <summary>
            /// A handle that may be used in place of <see cref="IntPtr.Zero"/>.
            /// </summary>
            public static readonly SafeNTObjectHandle Null = new SafeNTObjectHandle();

            /// <summary>
            /// Initializes a new instance of the <see cref="SafeNTObjectHandle"/> class.
            /// </summary>
            public SafeNTObjectHandle()
                : base(IntPtr.Zero, true)
            {
            }

            /// <summary>
            /// Initializes a new instance of the <see cref="SafeNTObjectHandle"/> class.
            /// </summary>
            /// <param name="preexistingHandle">An object that represents the pre-existing handle to use.</param>
            /// <param name="ownsHandle">
            ///     <see langword="true" /> to have the native handle released when this safe handle is disposed or finalized;
            ///     <see langword="false" /> otherwise.
            /// </param>
            public SafeNTObjectHandle(IntPtr preexistingHandle, bool ownsHandle = true)
                : base(IntPtr.Zero, ownsHandle)
            {
                this.SetHandle(preexistingHandle);
            }

            /// <inheritdoc />
            public override bool IsInvalid => this.handle == IntPtr.Zero;

            /// <inheritdoc />
            protected override bool ReleaseHandle()
            {
                return NtClose(this.handle).Severity == NTSTATUS.SeverityCode.STATUS_SEVERITY_SUCCESS;
            }
        }
    }
}
