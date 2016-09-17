// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Runtime.InteropServices;

    /// <content>
    /// Contains the <see cref="MONITORINFOEX"/> nested type.
    /// </content>
    public partial class User32
    {
        /// <summary>
        /// The MONITORINFOEX structure contains information about a display monitor. The GetMonitorInfo
        /// function stores information into a MONITORINFOEX structure or a MONITORINFO structure. The
        /// MONITORINFOEX structure is a superset of the MONITORINFO structure. The MONITORINFOEX
        /// structure adds a string member to contain a name for the display monitor.
        /// </summary>
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public unsafe struct MONITORINFOEX
        {
            /// <summary>
            /// The size, in bytes, of the structure. Set this member to sizeof(MONITORINFOEX) (72)
            /// before calling the GetMonitorInfo function. Doing so lets the function determine the type
            /// of structure you are passing to it.
            /// </summary>
            public int cbSize;

            /// <summary>
            /// A <see cref="RECT"/> structure that specifies the display monitor rectangle, expressed in
            /// virtual-screen coordinates. Note that if the monitor is not the primary display monitor,
            /// some of the rectangle's coordinates may be negative values.
            /// </summary>
            public RECT Monitor;

            /// <summary>
            /// A <see cref="RECT"/> structure that specifies the work area rectangle of the display monitor that can
            /// be used by applications, expressed in virtual-screen coordinates. Windows uses this
            /// rectangle to maximize an application on the monitor. The rest of the area in rcMonitor
            /// contains system windows such as the task bar and side bars. Note that if the monitor is
            /// not the primary display monitor, some of the rectangle's coordinates may be negative values.
            /// </summary>
            public RECT WorkArea;

            /// <summary>
            /// The attributes of the display monitor.
            /// </summary>
            /// <remarks>This member can be the following value: 1 : MONITORINFOF_PRIMARY</remarks>
            public uint Flags;

            /// <summary>
            /// A string that specifies the device name of the monitor being used. Most applications have
            /// no use for a display monitor name, and so can save some bytes by using a MONITORINFO structure.
            /// </summary>
            public fixed char DeviceName[CCHDEVICENAME];

            public static MONITORINFOEX Create()
            {
                var monitorIfo = default(MONITORINFOEX);
                monitorIfo.cbSize = Marshal.SizeOf(typeof(MONITORINFOEX));

                return monitorIfo;
            }
        }
    }
}