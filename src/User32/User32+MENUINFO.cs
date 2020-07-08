// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Runtime.InteropServices;

    /// <content>
    /// Contains the <see cref="MENUINFO"/> nested type.
    /// </content>
    public partial class User32
    {
        /// <summary>
        /// Contains information about a menu.
        /// </summary>
        public struct MENUINFO
        {
            /// <summary>The size of the structure, in bytes.</summary>
            public int cbSize;

            /// <summary>Indicates the members to be retrieved or set (except for <see cref="MenuInfoMask.MIM_APPLYTOSUBMENUS"/>).</summary>
            public MenuInfoMask fMask;

            /// <summary>The menu style.</summary>
            public MenuInfoStyle dwStyle;

            /// <summary>
            /// The maximum height of the menu in pixels. When the menu items exceed the space available, scroll bars are automatically used. The default (0) is the screen height.
            /// </summary>
            public uint cyMax;

            /// <summary>
            /// A handle to the brush to be used for the menu's background.
            /// </summary>
            public IntPtr hbrBack;

            /// <summary>
            /// The context help identifier. This is the same value used in the <see cref="GetMenuContextHelpId"/> and <see cref="SetMenuContextHelpId"/> functions.
            /// </summary>
            public uint dwContextHelpID;

            /// <summary>
            /// An application-defined value.
            /// </summary>
            public UIntPtr dwMenuData;

            /// <summary>
            /// Create a new instance of <see cref="MENUINFO"/> with <see cref="cbSize"/> set to the correct value.
            /// </summary>
            /// <returns>A new instance of <see cref="MENUINFO"/> with <see cref="cbSize"/> set to the correct value.</returns>
            public static unsafe MENUINFO Create() => new MENUINFO { cbSize = sizeof(MENUINFO) };
        }
    }
}
