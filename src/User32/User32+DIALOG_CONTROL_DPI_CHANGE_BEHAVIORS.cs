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
        /// Describes per-monitor DPI scaling behavior overrides for child windows within dialogs. The values in this enumeration are bitfields and can be combined.
        /// </summary>
        /// <remarks>
        /// This enum is used with SetDialogControlDpiChangeBehavior in order to override the default per-monitor DPI scaling behavior for a child window within a dialog.
        ///
        /// These settings only apply to individual controls within dialogs. The dialog-wide per-monitor DPI scaling behavior of a dialog is controlled by <see cref="DIALOG_DPI_CHANGE_BEHAVIORS"/>.
        /// </remarks>
        [Flags]
        public enum DIALOG_CONTROL_DPI_CHANGE_BEHAVIORS : int
        {
            /// <summary>
            /// The default behavior of the dialog manager. The dialog managed will update the font, size, and position of the child window on DPI changes.
            /// </summary>
            DCDC_DEFAULT = 0x0000,

            /// <summary>
            /// Prevents the dialog manager from sending an updated font to the child window via WM_SETFONT in response to a DPI change.
            /// </summary>
            DCDC_DISABLE_FONT_UPDATE = 0x0001,

            /// <summary>
            /// Prevents the dialog manager from resizing and repositioning the child window in response to a DPI change.
            /// </summary>
            DCDC_DISABLE_RELAYOUT = 0x0002,
        }
    }
}
