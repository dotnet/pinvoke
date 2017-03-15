// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Runtime.InteropServices;

    /// <content>
    /// The <see cref="SafeTerminalServerHandle"/> nested type.
    /// </content>
    public static partial class WtsApi32
    {
        /// <summary>
        /// Represents a Wts server handle that can be closed with <see cref="WTSCloseServer(IntPtr)"/>.
        /// </summary>
        public class SafeTerminalServerHandle : SafeHandle
        {
            /// <summary>
            /// A handle that may be used in place of <see cref="IntPtr.Zero"/>.
            /// </summary>
            public static readonly SafeTerminalServerHandle Null = new SafeTerminalServerHandle(IntPtr.Zero, false);

            /// <summary>
            /// Initializes a new instance of the <see cref="SafeTerminalServerHandle"/> class.
            /// </summary>
            public SafeTerminalServerHandle()
                : base(IntPtr.Zero, true)
            {
            }

            /// <summary>
            /// Initializes a new instance of the <see cref="SafeTerminalServerHandle"/> class.
            /// </summary>
            /// <param name="preexistingHandle">An object that represents the pre-existing handle to use.</param>
            /// <param name="ownsHandle">
            ///     <see langword="true" /> to have the native handle released when this safe handle is disposed or finalized;
            ///     <see langword="false" /> otherwise.
            /// </param>
            public SafeTerminalServerHandle(IntPtr preexistingHandle, bool ownsHandle = true)
                : base(IntPtr.Zero, ownsHandle)
            {
                this.SetHandle(preexistingHandle);
            }

            /// <inheritdoc />
            public override bool IsInvalid => this.handle == IntPtr.Zero;

            /// <inheritdoc />
            protected override bool ReleaseHandle()
            {
                WTSCloseServer(this.handle);
                return true;
            }
        }
    }
}
