// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System.Runtime.InteropServices;

    /// <content>
    /// Contains the <see cref="WINDOWPLACEMENT"/> nested type.
    /// </content>
    public partial class User32
    {
        /// <summary>
        /// Contains information about the placement of a window on the screen.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct WINDOWPLACEMENT
        {
            /// <summary>
            /// The length of the structure, in bytes. Before calling the GetWindowPlacement or SetWindowPlacement functions,
            /// set this member to sizeof(WINDOWPLACEMENT).
            /// <para>GetWindowPlacement and SetWindowPlacement fail if this member is not set correctly.</para>
            /// </summary>
            public int length;

            /// <summary>The flags that control the position of the minimized window and the method by which the window is restored.</summary>
            public WindowPlacementFlags flags;

            /// <summary>The current show state of the window.</summary>
            public WindowShowStyle showCmd;

            /// <summary>The coordinates of the window's upper-left corner when the window is minimized.</summary>
            public POINT ptMinPosition;

            /// <summary>The coordinates of the window's upper-left corner when the window is maximized.</summary>
            public POINT ptMaxPosition;

            /// <summary>The window's coordinates when the window is in the restored position.</summary>
            public RECT rcNormalPosition;

            /// <summary>
            /// Create a new instance of <see cref="WINDOWPLACEMENT"/> with <see cref="length"/> set to the correct value.
            /// </summary>
            /// <returns>A new instance of <see cref="WINDOWPLACEMENT"/> with <see cref="length"/> set to the correct value.</returns>
            public static WINDOWPLACEMENT Create()
            {
                return new WINDOWPLACEMENT
                {
                    length = Marshal.SizeOf(typeof(WINDOWPLACEMENT))
                };
            }
        }
    }
}