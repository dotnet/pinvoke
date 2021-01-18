// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Runtime.InteropServices;
    using Microsoft.Win32.SafeHandles;

    /// <content>
    /// Contains the <see cref="SafeMapViewHandle"/> nested type.
    /// </content>
    public static partial class Kernel32
    {
        /// <summary>
        /// Represents a MapView handle that can be closed with <see cref="UnmapViewOfFile"/>.
        /// </summary>
        public sealed class SafeMapViewHandle : SafeHandleZeroOrMinusOneIsInvalid
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="SafeMapViewHandle"/> class.
            /// </summary>
            /// <param name="existingHandle">An object that represents the pre-existing handle to use.</param>
            /// <param name="ownsHandle">
            ///     <see langword="true" /> to have the native handle released when this safe handle is disposed or finalized;
            ///     <see langword="false" /> otherwise.
            /// </param>
            public SafeMapViewHandle(IntPtr existingHandle, bool ownsHandle)
                : base(ownsHandle)
            {
                this.SetHandle(existingHandle);
            }

            /// <inheritdoc />
            protected override bool ReleaseHandle()
            {
                return UnmapViewOfFile(this.handle);
            }
        }
    }
}
