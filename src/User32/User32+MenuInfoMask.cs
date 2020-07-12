// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PInvoke
{
    using System;

    /// <content>
    /// Contains the <see cref="MenuInfoMask"/> nested type.
    /// </content>
    public partial class User32
    {
        /// <summary>
        /// Controls the appearance and behavior of a menu item.
        /// </summary>
        [Flags]
        public enum MenuInfoMask : uint
        {
            /// <summary>
            /// Settings apply to the menu and all of its submenus. <see cref="SetMenuItemInfo(IntPtr, uint, bool, MENUITEMINFO*)"/> uses this flag and <see cref="GetMenuInfo(IntPtr, MENUINFO*)"/> ignores this flag
            /// </summary>
            MIM_APPLYTOSUBMENUS = 0x80000000,

            /// <summary>
            /// Retrieves or sets the <see cref="MENUINFO.hbrBack"/> member.
            /// </summary>
            MIM_BACKGROUND = 0x00000002,

            /// <summary>
            /// Retrieves or sets the <see cref="MENUINFO.dwContextHelpID"/> member.
            /// </summary>
            MIM_HELPID = 0x00000004,

            /// <summary>
            /// Retrieves or sets the <see cref="MENUINFO.cyMax"/> member.
            /// </summary>
            MIM_MAXHEIGHT = 0x00000001,

            /// <summary>
            /// Retrieves or sets the <see cref="MENUINFO.dwMenuData"/> member.
            /// </summary>
            MIM_MENUDATA = 0x00000008,

            /// <summary>
            /// Retrieves or sets the <see cref="MENUINFO.dwStyle"/> member.
            /// </summary>
            MIM_STYLE = 0x00000010,
        }
    }
}
