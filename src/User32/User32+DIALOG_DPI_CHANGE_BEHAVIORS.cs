// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PInvoke
{
    using System;

    /// <content>
    /// Contains nested type <see cref="DIALOG_CONTROL_DPI_CHANGE_BEHAVIORS"/>.
    /// </content>
    public partial class User32
    {
        /// <summary>
        /// In Per Monitor v2 contexts, dialogs will automatically respond to DPI changes by resizing themselves and re-computing the positions of their child windows (here referred to as re-layouting).
        /// This enum works in conjunction with SetDialogDpiChangeBehavior in order to override the default DPI scaling behavior for dialogs.
        /// This does not affect DPI scaling behavior for the child windows of dialogs(beyond re-layouting), which is controlled by <see cref="DIALOG_CONTROL_DPI_CHANGE_BEHAVIORS"/>.
        /// </summary>
        [Flags]
        public enum DIALOG_DPI_CHANGE_BEHAVIORS : int
        {
            /// <summary>
            /// The default behavior of the dialog manager. In response to a DPI change, the dialog manager will re-layout each control, update the font on each control, resize the dialog, and update the dialog's own font.
            /// </summary>
            DDC_DEFAULT = 0x0000,

            /// <summary>
            /// Prevents the dialog manager from responding to <see cref="WindowMessage.WM_GETDPISCALEDSIZE"/> and <see cref="WindowMessage.WM_DPICHANGED"/>, disabling all default DPI scaling behavior.
            /// </summary>
            DDC_DISABLE_ALL = 0x0001,

            /// <summary>
            /// Prevents the dialog manager from resizing the dialog in response to a DPI change.
            /// </summary>
            DDC_DISABLE_RESIZE = 0x0002,

            /// <summary>
            /// Prevents the dialog manager from re-layouting all of the dialogue's immediate children HWNDs in response to a DPI change.
            /// </summary>
            DDC_DISABLE_CONTROL_RELAYOUT = 0x0003,
        }
    }
}
