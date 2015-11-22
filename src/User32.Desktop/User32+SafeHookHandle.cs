// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Runtime.InteropServices;

    /// <content>
    /// Contains the <see cref="SafeHookHandle"/> nested type.
    /// </content>
    public static partial class User32
    {
        /// <summary>
        /// Represents a windows Hook that can be removed with <see cref="UnhookWindowsHookEx"/>.
        /// </summary>
        public class SafeHookHandle : SafeHandle
        {
            public static readonly SafeHookHandle Null = new SafeHookHandle();

            /// <summary>
            /// Initializes a new instance of the <see cref="SafeHookHandle"/> class.
            /// </summary>
            public SafeHookHandle()
                : base(IntPtr.Zero, true)
            {
            }

            /// <summary>
            /// Initializes a new instance of the <see cref="SafeHookHandle"/> class.
            /// </summary>
            /// <param name="preexistingHandle">An object that represents the pre-existing handle to use.</param>
            /// <param name="ownsHandle"><see langword="true"/> to reliably release the handle during the finalization
            /// phase; <see langword="false"/> to prevent reliable release.</param>
            public SafeHookHandle(IntPtr preexistingHandle, bool ownsHandle)
                : base(IntPtr.Zero, ownsHandle)
            {
                this.SetHandle(preexistingHandle);
            }

            /// <inheritdoc />
            public override bool IsInvalid => this.handle == IntPtr.Zero;

            /// <inheritdoc />
            protected override bool ReleaseHandle() => UnhookWindowsHookEx(this.handle);
        }
    }
}
