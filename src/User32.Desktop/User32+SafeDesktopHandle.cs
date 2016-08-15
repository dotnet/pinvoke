// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Runtime.InteropServices;

    /// <content>
    /// Contains the <see cref="SafeDesktopHandle"/> nested type.
    /// </content>
    public static partial class User32
    {
        /// <summary>
        /// Represents a Desktop handle that can be closed with <see cref="CloseDesktop(IntPtr)"/>.
        /// </summary>
        public class SafeDesktopHandle : SafeHandle
        {
            /// <summary>
            /// A handle that may be used in place of <see cref="IntPtr.Zero"/>.
            /// </summary>
            public static readonly SafeDesktopHandle Null = new SafeDesktopHandle(IntPtr.Zero, false);

            /// <summary>
            /// Initializes a new instance of the <see cref="SafeDesktopHandle"/> class.
            /// </summary>
            public SafeDesktopHandle()
                : base(IntPtr.Zero, true)
            {
            }

            /// <summary>
            /// Initializes a new instance of the <see cref="SafeDesktopHandle"/> class.
            /// </summary>
            /// <param name="preexistingHandle">An object that represents the pre-existing handle to use.</param>
            /// <param name="ownsHandle">
            ///     <see langword="true" /> to have the native handle released when this safe handle is disposed or finalized;
            ///     <see langword="false" /> otherwise.
            /// </param>
            public SafeDesktopHandle(IntPtr preexistingHandle, bool ownsHandle = true)
                : base(IntPtr.Zero, ownsHandle)
            {
                this.SetHandle(preexistingHandle);
            }

            public override bool IsInvalid => this.handle == IntPtr.Zero;

            protected override bool ReleaseHandle() => CloseDesktop(this.handle);
        }
    }
}