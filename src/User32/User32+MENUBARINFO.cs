// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Runtime.InteropServices;

#pragma warning disable SA1300 // Naming matches .h file
#pragma warning disable SA1303 // Const field names must begin with upper-case letter
#pragma warning disable SA1623 // Docs match Microsoft published text.

    /// <content>
    /// Contains the <see cref="MENUBARINFO"/> nested type.
    /// </content>
    public partial class User32
    {
        /// <summary>
        /// Contains menu bar information.
        /// </summary>
        public struct MENUBARINFO
        {
            /// <summary>
            /// The size of the structure, in bytes. The caller must set this to sizeof(MENUBARINFO).
            /// </summary>
            public int cbSize;

            /// <summary>
            /// The coordinates of the menu bar, popup menu, or menu item.
            /// </summary>
            public RECT rcBar;

            /// <summary>
            /// A handle to the menu bar or popup menu.
            /// </summary>
            public IntPtr hMenu;

            /// <summary>
            /// A handle to the submenu.
            /// </summary>
            public IntPtr hwndMenu;

            private const int fFocusedMask = 1 << 0;

            private const int fBarFocusedMask = 1 << 1;

            /// <summary>
            /// The integer sized location where <see cref="fBarFocused"/> and <see cref="fFocused"/> are stored as bit flags.
            /// </summary>
            private int flags;

            /// <summary>
            /// If the menu bar or popup menu has the focus, this member is TRUE. Otherwise, the member is FALSE.
            /// </summary>
            public bool fBarFocused
            {
                get => (this.flags & fBarFocusedMask) == fBarFocusedMask;
                set
                {
                    if (value)
                    {
                        this.flags |= fBarFocusedMask;
                    }
                    else
                    {
                        this.flags &= ~fBarFocusedMask;
                    }
                }
            }

            /// <summary>
            /// If the menu item has the focus, this member is TRUE. Otherwise, the member is FALSE.
            /// </summary>
            public bool fFocused
            {
                get => (this.flags & fFocusedMask) == fFocusedMask;
                set
                {
                    if (value)
                    {
                        this.flags |= fFocusedMask;
                    }
                    else
                    {
                        this.flags &= ~fFocusedMask;
                    }
                }
            }

            /// <summary>
            /// Initializes a new instance of the <see cref="MENUBARINFO"/> struct
            /// with the <see cref="cbSize"/> preset as required.
            /// </summary>
            /// <returns>The newly initialized instance.</returns>
            public static unsafe MENUBARINFO Create() => new MENUBARINFO { cbSize = sizeof(MENUBARINFO) };
        }
    }
}
