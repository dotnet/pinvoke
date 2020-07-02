// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Runtime.InteropServices;

    /// <content>
    /// Contains the <see cref="SafePseudoConsoleHandle"/> nested type.
    /// </content>
    public static partial class Kernel32
    {
        /// <summary>
        /// Represents a Win32 handle that can be closed with <see cref="ClosePseudoConsole"/>.
        /// </summary>
        public class SafePseudoConsoleHandle : SafeHandle
        {
            /// <summary>
            /// An invalid handle that may be used in place of <see cref="INVALID_HANDLE_VALUE"/>.
            /// </summary>
            public static readonly SafePseudoConsoleHandle Invalid = new SafePseudoConsoleHandle();

            /// <summary>
            /// Initializes a new instance of the <see cref="SafePseudoConsoleHandle"/> class.
            /// </summary>
            public SafePseudoConsoleHandle()
                : base(INVALID_HANDLE_VALUE, true)
            {
            }

            /// <summary>
            /// Initializes a new instance of the <see cref="SafePseudoConsoleHandle"/> class.
            /// </summary>
            /// <param name="preexistingHandle">An object that represents the pre-existing handle to use.</param>
            /// <param name="ownsHandle">
            ///     <see langword="true" /> to have the native handle released when this safe handle is disposed or finalized;
            ///     <see langword="false" /> otherwise.
            /// </param>
            public SafePseudoConsoleHandle(IntPtr preexistingHandle, bool ownsHandle = true)
                : base(IntPtr.Zero, ownsHandle)
            {
                this.SetHandle(preexistingHandle);
            }

            /// <inheritdoc />
            public override bool IsInvalid => this.handle == INVALID_HANDLE_VALUE;

            /// <inheritdoc />
            protected override bool ReleaseHandle()
            {
                ClosePseudoConsole(this.handle);
                return true;
            }
        }
    }
}
