// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    /// <content>
    /// Contains the <see cref="MenuItemState"/> nested type.
    /// </content>
    public partial class User32
    {
        /// <summary>The menu item state in <see cref="MENUITEMINFO" />.</summary>
        public enum MenuItemState
        {
            /// <summary>
            ///     Checks the menu item. For more information about selected menu items, see the
            ///     <see cref="MENUITEMINFO.hbmpChecked" /> member.
            /// </summary>
            MFS_CHECKED,

            /// <summary>
            ///     Specifies that the menu item is the default. A menu can contain only one default menu item, which is displayed
            ///     in bold.
            /// </summary>
            MFS_DEFAULT,

            /// <summary>
            ///     Disables the menu item and grays it so that it cannot be selected. This is equivalent to
            ///     <see cref="MFS_GRAYED" />.
            /// </summary>
            MFS_DISABLED,

            /// <summary>Enables the menu item so that it can be selected. This is the default state.</summary>
            MFS_ENABLED,

            /// <summary>
            ///     Disables the menu item and grays it so that it cannot be selected. This is equivalent to
            ///     <see cref="MFS_DISABLED" />.
            /// </summary>
            MFS_GRAYED,

            /// <summary>Highlights the menu item.</summary>
            MFS_HILITE,

            /// <summary>Unchecks the menu item. For more information about clear menu items, see the hbmpChecked member.</summary>
            MFS_UNCHECKED,

            /// <summary>Removes the highlight from the menu item. This is the default state.</summary>
            MFS_UNHILITE
        }
    }
}
