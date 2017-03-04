// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Runtime.InteropServices;

    /// <content>
    /// Contains the <see cref="PAINTSTRUCT"/> nested type.
    /// </content>
    public partial class User32
    {
        /// <summary>
        ///  Contains information for an application. This information can be used to paint the client area of a window owned by that application.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public unsafe struct PAINTSTRUCT
        {
            /// <summary>
            /// A handle to the display DC to be used for painting.
            /// </summary>
            public IntPtr hdc;

            /// <summary>
            /// Indicates whether the background must be erased. This value is nonzero if the application should erase the background.
            /// The application is responsible for erasing the background if a window class is created without a background brush.
            /// For more information, see the description of the <see cref="WNDCLASS.hbrBackground"/> member.
            /// </summary>
            [MarshalAs(UnmanagedType.Bool)]
            public bool fErase;

            /// <summary>
            /// A <see cref="RECT"/> structure that specifies the upper left and lower right corners of the rectangle in which the painting is requested,
            /// in device units relative to the upper-left corner of the client area.
            /// </summary>
            public RECT rcPaint;

            /// <summary>
            /// Reserved; used internally by the system.
            /// </summary>
            [MarshalAs(UnmanagedType.Bool)]
            public bool fRestore;

            /// <summary>
            /// Reserved; used internally by the system.
            /// </summary>
            [MarshalAs(UnmanagedType.Bool)]
            public bool fIncUpdate;

            /// <summary>
            /// Reserved; used internally by the system.
            /// </summary>
            public fixed byte rgbReserved[32];
        }
    }
}
