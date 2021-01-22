// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PInvoke
{
    using System;

    /// <content>
    /// Contains the <see cref="ListBoxWindowStyles"/> nested type.
    /// </content>
    public partial class User32
    {
        /// <summary>
        /// To create a list box by using the CreateWindow or CreateWindowEx function, use the LISTBOX class, appropriate window style constants, and the following style constants to define the list box. After the control has been created, these styles cannot be modified, except as noted.
        /// </summary>
        [Flags]
        public enum ListBoxWindowStyles : uint
        {
            /// <summary>
            /// Causes the list box to send a notification code to the parent window whenever the user clicks a list box item (LBN_SELCHANGE), double-clicks an item (LBN_DBLCLK), or cancels the selection (LBN_SELCANCEL).
            /// </summary>
            LBS_NOTIFY = 0x0001,

            /// <summary>
            /// Sorts strings in the list box alphabetically.
            /// </summary>
            LBS_SORT = 0x0002,

            /// <summary>
            /// Specifies that the list box's appearance is not updated when changes are made.
            /// To change the redraw state of the control, use the WM_SETREDRAW message.
            /// </summary>
            LBS_NOREDRAW = 0x0004,

            /// <summary>
            /// Turns string selection on or off each time the user clicks or double-clicks a string in the list box. The user can select any number of strings.
            /// </summary>
            LBS_MULTIPLESEL = 0x0008,

            /// <summary>
            /// Specifies that the owner of the list box is responsible for drawing its contents and that the items in the list box are the same height. The owner window receives a WM_MEASUREITEM message when the list box is created and a WM_DRAWITEM message when a visual aspect of the list box has changed.
            /// </summary>
            LBS_OWNERDRAWFIXED = 0x0010,

            /// <summary>
            /// Specifies that the owner of the list box is responsible for drawing its contents and that the items in the list box are variable in height. The owner window receives a WM_MEASUREITEM message for each item in the box when the list box is created and a WM_DRAWITEM message when a visual aspect of the list box has changed.
            /// This style causes the LBS_NOINTEGRALHEIGHT style to be enabled.
            /// This style is ignored if the LBS_MULTICOLUMN style is specified.
            /// </summary>
            LBS_OWNERDRAWVARIABLE = 0x0020,

            /// <summary>
            /// Specifies that a list box contains items consisting of strings. The list box maintains the memory and addresses for the strings so that the application can use the LB_GETTEXT message to retrieve the text for a particular item. By default, all list boxes except owner-drawn list boxes have this style. You can create an owner-drawn list box either with or without this style.
            /// For owner-drawn list boxes without this style, the LB_GETTEXT message retrieves the value associated with an item (the item data).
            /// </summary>
            LBS_HASSTRINGS = 0x0040,

            /// <summary>
            /// Enables a list box to recognize and expand tab characters when drawing its strings. You can use the LB_SETTABSTOPS message to specify tab stop positions. The default tab positions are 32 dialog template units apart. Dialog template units are the device-independent units used in dialog box templates. To convert measurements from dialog template units to screen units (pixels), use the MapDialogRect function.
            /// </summary>
            LBS_USETABSTOPS = 0x0080,

            /// <summary>
            /// Specifies that the size of the list box is exactly the size specified by the application when it created the list box. Normally, the system sizes a list box so that the list box does not display partial items.
            /// For list boxes with the LBS_OWNERDRAWVARIABLE style, the LBS_NOINTEGRALHEIGHT style is always enforced.
            /// </summary>
            LBS_NOINTEGRALHEIGHT = 0x0100,

            /// <summary>
            /// Specifies a multi-column list box that is scrolled horizontally. The list box automatically calculates the width of the columns, or an application can set the width by using the LB_SETCOLUMNWIDTH message. If a list box has the LBS_OWNERDRAWFIXED style, an application can set the width when the list box sends the WM_MEASUREITEM message.
            /// A list box with the LBS_MULTICOLUMN style cannot scroll vertically it ignores any WM_VSCROLL messages it receives.
            /// The LBS_MULTICOLUMN and LBS_OWNERDRAWVARIABLE styles cannot be combined. If both are specified, LBS_OWNERDRAWVARIABLE is ignored.
            /// </summary>
            LBS_MULTICOLUMN = 0x0200,

            /// <summary>
            /// Specifies that the owner of the list box receives WM_VKEYTOITEM messages whenever the user presses a key and the list box has the input focus. This enables an application to perform special processing on the keyboard input.
            /// </summary>
            LBS_WANTKEYBOARDINPUT = 0x0400,

            /// <summary>
            /// Allows multiple items to be selected by using the SHIFT key and the mouse or special key combinations.
            /// </summary>
            LBS_EXTENDEDSEL = 0x0800,

            /// <summary>
            /// Shows a disabled horizontal or vertical scroll bar when the list box does not contain enough items to scroll. If you do not specify this style, the scroll bar is hidden when the list box does not contain enough items. This style must be used with the WS_VSCROLL or WS_HSCROLL style.
            /// </summary>
            LBS_DISABLENOSCROLL = 0x1000,

            /// <summary>
            /// Specifies a no-data list box. Specify this style when the count of items in the list box will exceed one thousand. A no-data list box must also have the LBS_OWNERDRAWFIXED style, but must not have the LBS_SORT or LBS_HASSTRINGS style.
            /// A no-data list box resembles an owner-drawn list box except that it contains no string or bitmap data for an item. Commands to add, insert, or delete an item always ignore any specified item data; requests to find a string within the list box always fail. The system sends the WM_DRAWITEM message to the owner window when an item must be drawn. The itemID member of the DRAWITEMSTRUCT structure passed with the WM_DRAWITEM message specifies the line number of the item to be drawn. A no-data list box does not send a WM_DELETEITEM message.
            /// </summary>
            LBS_NODATA = 0x2000,

            /// <summary>
            /// Specifies that the list box contains items that can be viewed but not selected.
            /// </summary>
            LBS_NOSEL = 0x4000,

            /// <summary>
            /// Notifies a list box that it is part of a combo box. This allows coordination between the two controls so that they present a unified UI. The combo box itself must set this style. If the style is set by anything but the combo box, the list box will regard itself incorrectly as a child of a combo box and a failure will result.
            /// </summary>
            LBS_COMBOBOX = 0x8000,

            /// <summary>
            /// Sorts strings in the list box alphabetically. The parent window receives a notification code whenever the user clicks a list box item, double-clicks an item, or or cancels the selection. The list box has a vertical scroll bar, and it has borders on all sides. This style combines the LBS_NOTIFY, LBS_SORT, WS_VSCROLL, and WS_BORDER styles.
            /// </summary>
            LBS_STANDARD = LBS_NOTIFY | LBS_SORT | WindowStyles.WS_VSCROLL | WindowStyles.WS_BORDER,
        }
    }
}
