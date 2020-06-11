// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PInvoke
{
    using System;

    /// <content>
    /// Contains the <see cref="MenuInfoStyle"/> nested type.
    /// </content>
    public partial class User32
    {
        /// <summary>
        /// The menu style, as used in <see cref="MENUINFO.dwStyle"/>.
        /// </summary>
        [Flags]
        public enum MenuInfoStyle : uint
        {
            /// <summary>
            /// Menu automatically ends when mouse is outside the menu for approximately 10 seconds.
            /// </summary>
            MNS_AUTODISMISS = 0x10000000,

            /// <summary>
            /// The same space is reserved for the check mark and the bitmap. If the check mark is drawn, the bitmap is not. All checkmarks and bitmaps are aligned. Used for menus where some items use checkmarks and some use bitmaps.
            /// </summary>
            MNS_CHECKORBMP = 0x04000000,

            /// <summary>
            /// Menu items are OLE drop targets or drag sources. Menu owner receives <see cref="WindowMessage.WM_MENUDRAG"/> and <see cref="WindowMessage.WM_MENUGETOBJECT"/> messages.
            /// </summary>
            MNS_DRAGDROP = 0x20000000,

            /// <summary>
            /// Menu is modeless; that is, there is no menu modal message loop while the menu is active.
            /// </summary>
            MNS_MODELESS = 0x40000000,

            /// <summary>
            /// No space is reserved to the left of an item for a check mark. The item can still be selected, but the check mark will not appear next to the item.
            /// </summary>
            MNS_NOCHECK = 0x80000000,

            /// <summary>
            /// Menu owner receives a <see cref="WindowMessage.WM_MENUCOMMAND"/> message instead of a <see cref="WindowMessage.WM_COMMAND"/> message when the user makes a selection.
            /// <see cref="MNS_NOTIFYBYPOS"/> is a menu header style and has no effect when applied to individual sub menus.
            /// </summary>
            MNS_NOTIFYBYPOS = 0x08000000,
        }
    }
}
