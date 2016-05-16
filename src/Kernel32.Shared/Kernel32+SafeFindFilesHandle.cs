// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Runtime.InteropServices;

    /// <content>
    /// Contains the <see cref="SafeFindFilesHandle"/> nested type.
    /// </content>
    public static partial class Kernel32
    {
        /// <summary>
        /// Represents a Win32 handle that can be closed with <see cref="FindClose"/>.
        /// </summary>
        public class SafeFindFilesHandle : SafeHandle
        {
            /// <summary>
            /// An invalid handle that may be used in place of <see cref="INVALID_HANDLE_VALUE"/>.
            /// </summary>
            public static readonly SafeFindFilesHandle Invalid = new SafeFindFilesHandle();

            /// <summary>
            /// Initializes a new instance of the <see cref="SafeFindFilesHandle"/> class.
            /// </summary>
            public SafeFindFilesHandle()
                : base(INVALID_HANDLE_VALUE, true)
            {
            }

            /// <summary>
            /// Initializes a new instance of the <see cref="SafeFindFilesHandle"/> class.
            /// </summary>
            /// <param name="preexistingHandle">An object that represents the pre-existing handle to use.</param>
            /// <param name="ownsHandle">
            ///     <see langword="true" /> to have the native handle released when this safe handle is disposed or finalized;
            ///     <see langword="false" /> otherwise.
            /// </param>
            public SafeFindFilesHandle(IntPtr preexistingHandle, bool ownsHandle = true)
                : base(IntPtr.Zero, ownsHandle)
            {
                this.SetHandle(preexistingHandle);
            }

            /// <inheritdoc />
            public override bool IsInvalid => this.handle == INVALID_HANDLE_VALUE;

            /// <inheritdoc />
            protected override bool ReleaseHandle() => FindClose(this.handle);
        }
    }
}
