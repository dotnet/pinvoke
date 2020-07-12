// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Runtime.InteropServices;

    /// <content>Contains the <see cref="FLASHWINFO" /> nested type.</content>
    public partial class User32
    {
        /// <summary>
        ///     Contains the flash status for a window and the number of times the system should flash the window. Used in
        ///     <see cref="FlashWindowEx" />.
        /// </summary>
        public struct FLASHWINFO
        {
            /// <summary>The size of the structure, in bytes.</summary>
            public int cbSize;

            /// <summary>A handle to the window to be flashed. The window can be either opened or minimized.</summary>
            public IntPtr hwnd;

            /// <summary>The flash status.</summary>
            public FlashWindowFlags dwFlags;

            /// <summary>The number of times to flash the window.</summary>
            public int uCount;

            /// <summary>
            ///     The rate at which the window is to be flashed, in milliseconds. If <see cref="dwTimeout"/> is zero, the
            ///     function uses the default cursor blink rate.
            /// </summary>
            public int dwTimeout;

            /// <summary>
            /// Create a new instance of <see cref="FLASHWINFO"/> with <see cref="cbSize"/> set to the correct value.
            /// </summary>
            /// <returns>A new instance of <see cref="FLASHWINFO"/> with <see cref="cbSize"/> set to the correct value.</returns>
            public static unsafe FLASHWINFO Create() => new FLASHWINFO { cbSize = sizeof(FLASHWINFO) };
        }
    }
}
