// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Runtime.InteropServices;

    /// <content>
    /// Contains the <see cref="SafeFindFilesHandle"/> nested class.
    /// </content>
    public static partial class Kernel32
    {
        /// <summary>
        /// Represents a Win32 handle that can be closed with <see cref="FindClose"/>.
        /// </summary>
        public class SafeFindFilesHandle : SafeHandle
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="SafeFindFilesHandle"/> class.
            /// </summary>
            public SafeFindFilesHandle()
                : base(IntPtr.Zero, true)
            {
            }

            /// <inheritdoc />
            public override bool IsInvalid => this.handle == IntPtr.Zero;

            /// <inheritdoc />
            protected override bool ReleaseHandle() => FindClose(this.handle);
        }
    }
}
