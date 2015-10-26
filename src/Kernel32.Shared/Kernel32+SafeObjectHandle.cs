// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Runtime.InteropServices;

    /// <content>
    /// Contains the <see cref="SafeObjectHandle"/> nested class.
    /// </content>
    public static partial class Kernel32
    {
        /// <summary>
        /// Represents a Win32 handle that can be closed with <see cref="CloseHandle"/>.
        /// </summary>
        public class SafeObjectHandle : SafeHandle
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="SafeObjectHandle"/> class.
            /// </summary>
            public SafeObjectHandle()
                : base(INVALID_HANDLE_VALUE, true)
            {
            }

            /// <summary>
            /// Initializes a new instance of the <see cref="SafeObjectHandle"/> class.
            /// </summary>
            /// <param name="preexistingHandle">An object that represents the pre-existing handle to use.</param>
            /// <param name="ownsHandle"><see langword="true"/> to reliably release the handle during the finalization
            /// phase; <see langword="false"/> to prevent reliable release.</param>
            public SafeObjectHandle(IntPtr preexistingHandle, bool ownsHandle)
                : base(INVALID_HANDLE_VALUE, ownsHandle)
            {
                this.SetHandle(preexistingHandle);
            }

            /// <inheritdoc />
            public override bool IsInvalid => this.handle == INVALID_HANDLE_VALUE;

            /// <inheritdoc />
            protected override bool ReleaseHandle() => CloseHandle(this.handle);
        }
    }
}
