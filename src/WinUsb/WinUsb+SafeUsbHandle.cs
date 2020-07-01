// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PInvoke
{
    using System;
    using Microsoft.Win32.SafeHandles;

    /// <content>
    /// Contains the nested <see cref="SafeUsbHandle"/> type.
    /// </content>
    public static partial class WinUsb
    {
        /// <summary>
        /// A handle which is returned by the WinUsb API.
        /// </summary>
        public class SafeUsbHandle : SafeHandleMinusOneIsInvalid
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="SafeUsbHandle"/> class.
            /// </summary>
            public SafeUsbHandle()
                : base(true)
            {
            }

            /// <summary>
            /// Initializes a new instance of the <see cref="SafeUsbHandle"/> class.
            /// </summary>
            /// <param name="handle">
            /// The predefined handle.
            /// </param>
            public SafeUsbHandle(IntPtr handle)
                : this()
            {
                this.SetHandle(handle);
            }

            /// <inheritdoc/>
            protected override bool ReleaseHandle()
            {
                return WinUsb.WinUsb_Free(this.handle);
            }
        }
    }
}
