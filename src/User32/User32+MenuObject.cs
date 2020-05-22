// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PInvoke
{
    /// <content>
    /// Contains the <see cref="MenuObject"/> nested type.
    /// </content>
    public partial class User32
    {
        /// <summary>
        /// Values to be used when calling the <see cref="GetMenuBarInfo(System.IntPtr, MenuObject, int, MENUBARINFO*)"/> method.
        /// </summary>
        public enum MenuObject : uint
        {
            /// <summary>
            /// The popup menu associated with the window.
            /// </summary>
            OBJID_CLIENT = 0xFFFFFFFC,

            /// <summary>
            /// The menu bar associated with the window (see the <see cref="GetMenu(System.IntPtr)"/> function).
            /// </summary>
            OBJID_MENU = 0xFFFFFFFD,

            /// <summary>
            /// The system menu associated with the window (see the <see cref="GetSystemMenu(System.IntPtr, bool)"/> function).
            /// </summary>
            OBJID_SYSMENU = 0xFFFFFFFF,
        }
    }
}
