// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PInvoke
{
    using System;

    /// <content>
    /// Contains the <see cref="MONITORINFO"/> nested type.
    /// </content>
    public partial class User32
    {
        /// <summary>
        /// The <see cref="MONITORINFO"/> structure contains information about a display monitor.
        /// The <see cref="GetMonitorInfo(IntPtr, MONITORINFO*)"/> function stores information in a <see cref="MONITORINFO"/> structure or a <see cref="MONITORINFOEX"/> structure.
        /// The <see cref="MONITORINFO"/> structure is a subset of the <see cref="MONITORINFOEX"/> structure. The <see cref="MONITORINFOEX"/> structure adds a string member to contain a name for the display monitor.
        /// </summary>
        public struct MONITORINFO
        {
            /// <summary>
            /// The size of the structure, in bytes.
            /// Set this member to <c>sizeof(MONITORINFO)</c> before calling the <see cref="GetMonitorInfo(IntPtr, MONITORINFO*)"/> function.
            /// Doing so lets the function determine the type of structure you are passing to it.
            /// </summary>
            public int cbSize;

            /// <summary>
            /// A <see cref="RECT"/> structure that specifies the display monitor rectangle, expressed in virtual-screen coordinates. Note that if the monitor is not the primary display monitor, some of the rectangle's coordinates may be negative values.
            /// </summary>
            public RECT rcMonitor;

            /// <summary>
            /// A <see cref="RECT"/> structure that specifies the work area rectangle of the display monitor, expressed in virtual-screen coordinates. Note that if the monitor is not the primary display monitor, some of the rectangle's coordinates may be negative values.
            /// </summary>
            public RECT rcWork;

            /// <summary>
            /// A set of flags that represent attributes of the display monitor.
            /// </summary>
            public MONITORINFO_Flags dwFlags;

            /// <summary>
            /// Initializes a new instance of the <see cref="MONITORINFO"/> struct
            /// with the <see cref="cbSize"/> field initialized.
            /// </summary>
            /// <returns>The newly initialized struct.</returns>
            public static unsafe MONITORINFO Create() => new MONITORINFO { cbSize = sizeof(MONITORINFO) };
        }
    }
}
