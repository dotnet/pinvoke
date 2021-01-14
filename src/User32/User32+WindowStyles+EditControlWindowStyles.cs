// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PInvoke
{
    using System;

    /// <content>
    /// Contains the <see cref="EditControlWindowStyles"/> nested type.
    /// </content>
    public partial class User32
    {
        /// <summary>
        /// To create an edit control using the CreateWindow or CreateWindowEx function, specify the EDIT class, appropriate window style constants, and a combination of the following edit control styles. After the control has been created, these styles cannot be modified, except as noted.
        /// </summary>
        [Flags]
        public enum EditControlWindowStyles : uint
        {
            /// <summary>
            /// Aligns text with the left margin.
            /// </summary>
            ES_LEFT = 0x0000,

            /// <summary>
            /// Centers text in a single-line or multiline edit control.
            /// </summary>
            ES_CENTER = 0x0001,

            /// <summary>
            /// Right-aligns text in a single-line or multiline edit control.
            /// </summary>
            ES_RIGHT = 0x0002,

            /// <summary>
            /// Designates a multiline edit control. The default is single-line edit control.
            /// When the multiline edit control is in a dialog box, the default response to pressing the ENTER key is to activate the default button. To use the ENTER key as a carriage return, use the ES_WANTRETURN style.
            /// When the multiline edit control is not in a dialog box and the ES_AUTOVSCROLL style is specified, the edit control shows as many lines as possible and scrolls vertically when the user presses the ENTER key. If you do not specify ES_AUTOVSCROLL, the edit control shows as many lines as possible and beeps if the user presses the ENTER key when no more lines can be displayed.
            /// If you specify the ES_AUTOHSCROLL style, the multiline edit control automatically scrolls horizontally when the caret goes past the right edge of the control. To start a new line, the user must press the ENTER key. If you do not specify ES_AUTOHSCROLL, the control automatically wraps words to the beginning of the next line when necessary. A new line is also started if the user presses the ENTER key. The window size determines the position of the Wordwrap. If the window size changes, the Wordwrapping position changes and the text is redisplayed.
            /// Multiline edit controls can have scroll bars. An edit control with scroll bars processes its own scroll bar messages. Note that edit controls without scroll bars scroll as described in the previous paragraphs and process any scroll messages sent by the parent window.
            /// </summary>
            ES_MULTILINE = 0x0004,

            /// <summary>
            /// Converts all characters to uppercase as they are typed into the edit control.
            /// To change this style after the control has been created, use SetWindowLong.
            /// </summary>
            ES_UPPERCASE = 0x0008,

            /// <summary>
            /// Converts all characters to lowercase as they are typed into the edit control.
            /// To change this style after the control has been created, use SetWindowLong.
            /// </summary>
            ES_LOWERCASE = 0x0010,

            /// <summary>
            /// Displays an asterisk (*) for each character typed into the edit control. This style is valid only for single-line edit controls.
            /// To change the characters that is displayed, or set or clear this style, use the EM_SETPASSWORDCHAR message.
            /// </summary>
            ES_PASSWORD = 0x0020,

            /// <summary>
            /// Automatically scrolls text up one page when the user presses the ENTER key on the last line.
            /// </summary>
            ES_AUTOVSCROLL = 0x0040,

            /// <summary>
            /// Automatically scrolls text to the right by 10 characters when the user types a character at the end of the line. When the user presses the ENTER key, the control scrolls all text back to position zero.
            /// </summary>
            ES_AUTOHSCROLL = 0x0080,

            /// <summary>
            /// Negates the default behavior for an edit control. The default behavior hides the selection when the control loses the input focus and inverts the selection when the control receives the input focus. If you specify ES_NOHIDESEL, the selected text is inverted, even if the control does not have the focus.
            /// </summary>
            ES_NOHIDESEL = 0x0100,

            /// <summary>
            /// Converts text entered in the edit control. The text is converted from the Windows character set to the OEM character set and then back to the Windows character set. This ensures proper character conversion when the application calls the CharToOem function to convert a Windows string in the edit control to OEM characters. This style is most useful for edit controls that contain file names that will be used on file systems that do not support Unicode.
            /// To change this style after the control has been created, use SetWindowLong.
            /// </summary>
            ES_OEMCONVERT = 0x0400,

            /// <summary>
            /// Prevents the user from typing or editing text in the edit control.
            /// To change this style after the control has been created, use the EM_SETREADONLY message.
            /// </summary>
            ES_READONLY = 0x0800,

            /// <summary>
            /// Specifies that a carriage return be inserted when the user presses the ENTER key while entering text into a multiline edit control in a dialog box. If you do not specify this style, pressing the ENTER key has the same effect as pressing the dialog box's default push button. This style has no effect on a single-line edit control.
            /// To change this style after the control has been created, use SetWindowLong.
            /// </summary>
            ES_WANTRETURN = 0x1000,

            /// <summary>
            /// Allows only digits to be entered into the edit control. Note that, even with this set, it is still possible to paste non-digits into the edit control.
            /// To change this style after the control has been created, use SetWindowLong.
            /// To translate text that was entered into the edit control to an integer value, use the GetDlgItemInt function. To set the text of the edit control to the string representation of a specified integer, use the SetDlgItemInt function.
            /// </summary>
            ES_NUMBER = 0x2000,
        }
    }
}
