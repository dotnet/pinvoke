// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Runtime.InteropServices;

    /// <content>
    /// Contains the <see cref="SafeDCHandle"/> nested type.
    /// </content>
    public partial class User32
    {
        /// <summary>
        /// A SafeHandle to track DC handles.
        /// </summary>
        public class SafeDCHandle : SafeHandle
        {
            /// <summary>
            /// A null handle.
            /// </summary>
            public static readonly SafeDCHandle Null = new SafeDCHandle(IntPtr.Zero, IntPtr.Zero);

            /// <summary>
            /// Initializes a new instance of the <see cref="SafeDCHandle"/> class.
            /// </summary>
            /// <param name="hWnd">The HWND this handle is associated with and must be released with.</param>
            /// <param name="hDC">The handle to the DC.</param>
            /// <param name="ownsHandle">
            ///     <see langword="true" /> to have the native handle released when this safe handle is disposed or finalized;
            ///     <see langword="false" /> otherwise.
            /// </param>
            public SafeDCHandle(IntPtr hWnd, IntPtr hDC, bool ownsHandle = true)
                : base(IntPtr.Zero, ownsHandle)
            {
                this.HWnd = hWnd;
                this.SetHandle(hDC);
            }

            /// <summary>
            /// Gets the HWND this handle is associated with.
            /// </summary>
            public IntPtr HWnd { get; }

            /// <inheritdoc />
            public override bool IsInvalid => this.handle == IntPtr.Zero;

            /// <inheritdoc />
            protected override bool ReleaseHandle() => ReleaseDC(this.HWnd, this.handle) == 1;
        }
    }
}
