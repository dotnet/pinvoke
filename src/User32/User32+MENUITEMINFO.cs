// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Runtime.InteropServices;

    /// <content>
    /// Contains the <see cref="MENUITEMINFO"/> nested type.
    /// </content>
    public partial class User32
    {
        /// <summary>
        /// Contains information about a menu item.
        /// </summary>
        [OfferIntPtrPropertyAccessors]
        public unsafe partial struct MENUITEMINFO
        {
            /// <summary>The size of the structure, in bytes.</summary>
            public int cbSize;

            /// <summary>Indicates the members to be retrieved or set.</summary>
            public MenuMembersMask fMask;

            /// <summary>The menu item type.</summary>
            public MenuItemType fType;

            /// <summary>The menu item state.</summary>
            public MenuItemState fState;

            /// <summary>
            ///     An application-defined value that identifies the menu item. Set <see cref="fMask" /> to
            ///     <see cref="MenuMembersMask.MIIM_ID" /> to use <see cref="wID" />.
            /// </summary>
            public int wID;

            /// <summary>
            ///     A handle to the drop-down menu or submenu associated with the menu item. If the menu item is not an item that
            ///     opens a drop-down menu or submenu, this member is <see cref="IntPtr.Zero" />. Set <see cref="fMask" /> to
            ///     <see cref="MenuMembersMask.MIIM_SUBMENU" /> to use hSubMenu.
            /// </summary>
            public IntPtr hSubMenu;

            /// <summary>
            ///     A handle to the bitmap to display next to the item if it is selected. If this member is
            ///     <see cref="IntPtr.Zero" />, a default bitmap is used. If the <see cref="MenuItemType.MFT_RADIOCHECK" /> type value
            ///     is specified, the default bitmap is a bullet. Otherwise, it is a check mark. Set fMask to
            ///     <see cref="MenuMembersMask.MIIM_CHECKMARKS" /> to use <see cref="hbmpChecked" />.
            /// </summary>
            public IntPtr hbmpChecked;

            /// <summary>
            ///     A handle to the bitmap to display next to the item if it is not selected. If this member is
            ///     <see cref="IntPtr.Zero" />, no bitmap is used. Set <see cref="fMask" /> to
            ///     <see cref="MenuMembersMask.MIIM_CHECKMARKS" /> to use <see cref="hbmpUnchecked" />.
            /// </summary>
            public IntPtr hbmpUnchecked;

            /// <summary>
            ///     An application-defined value associated with the menu item. Set <see cref="fMask" /> to
            ///     <see cref="MenuMembersMask.MIIM_DATA" /> to use <see cref="dwItemData" />.
            /// </summary>
            public IntPtr dwItemData;

            /// <summary>
            ///     The contents of the menu item. The meaning of this member depends on the value of fType and is used only if the
            ///     MIIM_TYPE flag is set in the fMask member.
            ///     <para>
            ///         To retrieve a menu item of type <see cref="MenuItemType.MFT_STRING" />, first find the size of the string by
            ///         setting the <see cref="dwTypeData" />
            ///         member of <see cref="MENUITEMINFO" /> to <see cref="IntPtr.Zero" /> and then calling
            ///         <see cref="GetMenuItemInfo(IntPtr, uint, bool, MENUITEMINFO*)" />. The value of <see cref="cch" />+1 is the size needed. Then allocate a buffer of
            ///         this size, place the pointer to the buffer in dwTypeData, increment cch, and call
            ///         <see cref="GetMenuItemInfo(IntPtr, uint, bool, MENUITEMINFO*)" /> once again to fill the buffer with the string. If the retrieved menu item is of
            ///         some other type, then <see cref="GetMenuItemInfo(IntPtr, uint, bool, MENUITEMINFO*)" /> sets the <see cref="dwTypeData" /> member to a value whose
            ///         type is specified by the <see cref="fType" /> member.
            ///     </para>
            ///     <para>
            ///         When using with the <see cref="SetMenuItemInfo(IntPtr, uint, bool, MENUITEMINFO*)" /> function, this member should contain a value whose type is
            ///         specified by the <see cref="fType" /> member.
            ///     </para>
            ///     <para>
            ///         dwTypeData is used only if the <see cref="MenuMembersMask.MIIM_STRING" /> flag is set in the
            ///         <see cref="fMask" /> member.
            ///     </para>
            /// </summary>
            public char* dwTypeData;

            /// <summary>
            ///     The length of the menu item text, in characters, when information is received about a menu item of the
            ///     <see cref="MenuItemType.MFT_STRING" />
            ///     type. However, <see cref="cch" /> is used only if the <see cref="MenuMembersMask.MIIM_TYPE" /> flag is set in the
            ///     <see cref="fMask" /> member and is zero otherwise. Also, <see cref="cch" />
            ///     is ignored when the content of a menu item is set by calling <see cref="SetMenuItemInfo(IntPtr, uint, bool, MENUITEMINFO*)" />.
            ///     <para>
            ///         Note that, before calling <see cref="GetMenuItemInfo(IntPtr, uint, bool, MENUITEMINFO*)" />, the application must set <see cref="cch" /> to the
            ///         length of the buffer pointed to by the <see cref="dwTypeData" /> member. If the retrieved menu item is of type
            ///         <see cref="MenuItemType.MFT_STRING" /> (as indicated by the <see cref="fType" />
            ///         member), then <see cref="GetMenuItemInfo(IntPtr, uint, bool, MENUITEMINFO*)" /> changes <see cref="cch" /> to the length of the menu item text. If
            ///         the retrieved menu item is of some other type, <see cref="GetMenuItemInfo(IntPtr, uint, bool, MENUITEMINFO*)" /> sets the <see cref="cch" /> field
            ///         to zero.
            ///     </para>
            ///     <para>
            ///         The <see cref="cch" /> member is used when the <see cref="MenuMembersMask.MIIM_STRING" /> flag is set in the
            ///         <see cref="fMask" /> member.
            ///     </para>
            /// </summary>
            public int cch;

            /// <summary>
            ///     A handle to the bitmap to be displayed, or it can be one of the following values :
            ///     <para>
            ///         <see cref="HBMMENU_CALLBACK" />.
            ///     </para>
            ///     <para>
            ///         <see cref="HBMMENU_MBAR_CLOSE" />.
            ///     </para>
            ///     <para>
            ///         <see cref="HBMMENU_MBAR_CLOSE_D" />.
            ///     </para>
            ///     <para>
            ///         <see cref="HBMMENU_MBAR_MINIMIZE" />.
            ///     </para>
            ///     <para>
            ///         <see cref="HBMMENU_MBAR_MINIMIZE_D" />.
            ///     </para>
            ///     <para>
            ///         <see cref="HBMMENU_MBAR_RESTORE" />.
            ///     </para>
            ///     <para>
            ///         <see cref="HBMMENU_POPUP_CLOSE" />.
            ///     </para>
            ///     <para>
            ///         <see cref="HBMMENU_POPUP_MAXIMIZE" />.
            ///     </para>
            ///     <para>
            ///         <see cref="HBMMENU_POPUP_MINIMIZE" />.
            ///     </para>
            ///     <para>
            ///         <see cref="HBMMENU_POPUP_RESTORE" />.
            ///     </para>
            ///     <para>
            ///         <see cref="HBMMENU_SYSTEM" />.
            ///     </para>
            /// </summary>
            public IntPtr hbmpItem;

            /// <summary>
            /// Create a new instance of <see cref="MENUITEMINFO"/> with <see cref="cbSize"/> set to the correct value.
            /// </summary>
            /// <returns>A new instance of <see cref="MENUITEMINFO"/> with <see cref="cbSize"/> set to the correct value.</returns>
            public static MENUITEMINFO Create() => new MENUITEMINFO { cbSize = sizeof(MENUITEMINFO) };
        }
    }
}
