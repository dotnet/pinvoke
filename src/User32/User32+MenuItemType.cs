// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PInvoke
{
    using System;

    /// <content>
    /// Contains the <see cref="MenuItemType"/> nested type.
    /// </content>
    public partial class User32
    {
        /// <summary>
        /// The menu item type in <see cref="MENUITEMINFO"/>.
        /// </summary>
        [Flags]
        public enum MenuItemType
        {
            /// <summary>
            ///     Displays the menu item using a bitmap. The low-order word of the <see cref="MENUITEMINFO.dwTypeData" /> member is
            ///     the bitmap handle, and the <see cref="MENUITEMINFO.cch" /> member is ignored.
            ///     <para>
            ///         <see cref="MFT_BITMAP" /> is replaced by <see cref="MenuMembersMask.MIIM_BITMAP" /> and
            ///         <see cref="MENUITEMINFO.hbmpItem" />.
            ///     </para>
            /// </summary>
            MFT_BITMAP = 0x00000004,

            /// <summary>
            ///     Places the menu item on a new line (for a menu bar) or in a new column (for a drop-down menu, submenu, or
            ///     shortcut menu). For a drop-down menu, submenu, or shortcut menu, a vertical line separates the new column from the
            ///     old.
            /// </summary>
            MFT_MENUBARBREAK = 0x00000020,

            /// <summary>
            ///     Places the menu item on a new line (for a menu bar) or in a new column (for a drop-down menu, submenu, or
            ///     shortcut menu). For a drop-down menu, submenu, or shortcut menu, the columns are not separated by a vertical line.
            /// </summary>
            MFT_MENUBREAK = 0x00000040,

            /// <summary>
            ///     Assigns responsibility for drawing the menu item to the window that owns the menu. The window receives a
            ///     WM_MEASUREITEM message before the menu is displayed for the first time, and a WM_DRAWITEM message whenever the
            ///     appearance of the menu item must be updated. If this value is specified, the dwTypeData member contains an
            ///     application-defined value.
            /// </summary>
            MFT_OWNERDRAW = 0x00000100,

            /// <summary>
            ///     Displays selected menu items using a radio-button mark instead of a check mark if the
            ///     <see cref="MENUITEMINFO.hbmpChecked" /> member is <see cref="IntPtr.Zero" />.
            /// </summary>
            MFT_RADIOCHECK = 0x00000200,

            /// <summary>
            ///     Right-justifies the menu item and any subsequent items. This value is valid only if the menu item is in a menu
            ///     bar.
            /// </summary>
            MFT_RIGHTJUSTIFY = 0x00004000,

            /// <summary>
            ///     Specifies that menus cascade right-to-left (the default is left-to-right). This is used to support
            ///     right-to-left languages, such as Arabic and Hebrew.
            /// </summary>
            MFT_RIGHTORDER = 0x00002000,

            /// <summary>
            ///     Specifies that the menu item is a separator. A menu item separator appears as a horizontal dividing line. The
            ///     dwTypeData and cch members are ignored. This value is valid only in a drop-down menu, submenu, or shortcut menu.
            /// </summary>
            MFT_SEPARATOR = 0x00000800,

            /// <summary>
            ///     Displays the menu item using a text string. The <see cref="MENUITEMINFO.dwTypeData" /> member is the pointer
            ///     to a null-terminated string, and the <see cref="MENUITEMINFO.cch" /> member is the length of the string.
            ///     <para><see cref="MFT_STRING" /> is replaced by <see cref="MenuMembersMask.MIIM_STRING" />.</para>
            /// </summary>
            MFT_STRING = 0x00000000,
        }
    }
}
