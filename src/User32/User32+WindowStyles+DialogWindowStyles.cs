// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PInvoke
{
    using System;

    /// <content>
    /// Contains the <see cref="DialogWindowStyles"/> nested type.
    /// </content>
    public partial class User32
    {
        /// <summary>
        /// The following table lists the dialog box styles that you can specify when you create a dialog box. You can use these styles in calls to the CreateWindow and CreateWindowEx functions, in the style member of the DLGTEMPLATE and DLGTEMPLATEEX structures, and in the statement of a dialog box definition in a resource file.
        /// </summary>
        [Flags]
        public enum DialogWindowStyles : uint
        {
            /// <summary>
            /// Indicates that the coordinates of the dialog box are screen coordinates. If this style is not specified, the coordinates are client coordinates.
            /// </summary>
            DS_ABSALIGN = 0x01,

            /// <summary>
            /// This style is obsolete and is included for compatibility with 16-bit versions of Windows. If you specify this style, the system creates the dialog box with the WS_EX_TOPMOST style. This style does not prevent the user from accessing other windows on the desktop.
            /// Do not combine this style with the DS_CONTROL style.
            /// </summary>
            DS_SYSMODAL = 0x02,

            /// <summary>
            /// Applies to 16-bit applications only. This style directs edit controls in the dialog box to allocate memory from the application's data segment. Otherwise, edit controls allocate storage from a global memory object.
            /// </summary>
            DS_LOCALEDIT = 0x20,

            /// <summary>
            /// Indicates that the header of the dialog box template (either standard or extended) contains additional data specifying the font to use for text in the client area and controls of the dialog box. If possible, the system selects a font according to the specified font data. The system passes a handle to the font to the dialog box and to each control by sending them the WM_SETFONT message. For descriptions of the format of this font data, see DLGTEMPLATE and DLGTEMPLATEEX.
            /// If neither DS_SETFONT nor DS_SHELLFONT is specified, the dialog box template does not include the font data.
            /// </summary>
            DS_SETFONT = 0x40,

            /// <summary>
            /// Creates a dialog box with a modal dialog-box frame that can be combined with a title bar and window menu by specifying the WS_CAPTION and WS_SYSMENU styles.
            /// </summary>
            DS_MODALFRAME = 0x80,

            /// <summary>
            /// Suppresses WM_ENTERIDLE messages that the system would otherwise send to the owner of the dialog box while the dialog box is displayed.
            /// </summary>
            DS_NOIDLEMSG = 0x100,

            /// <summary>
            /// Causes the system to use the SetForegroundWindow function to bring the dialog box to the foreground. This style is useful for modal dialog boxes that require immediate attention from the user regardless of whether the owner window is the foreground window.
            /// The system restricts which processes can set the foreground window. For more information, see Foreground and Background Windows.
            /// </summary>
            DS_SETFOREGROUND = 0x200,

            /// <summary>
            /// Obsolete. The system automatically applies the three-dimensional look to dialog boxes created by applications.
            /// </summary>
            DS_3DLOOK = 0x0004,

            /// <summary>
            /// Causes the dialog box to use the SYSTEM_FIXED_FONT instead of the default SYSTEM_FONT. This is a monospace font compatible with the System font in 16-bit versions of Windows earlier than 3.0.
            /// </summary>
            DS_FIXEDSYS = 0x0008,

            /// <summary>
            /// Creates the dialog box even if errors occur for example, if a child window cannot be created or if the system cannot create a special data segment for an edit control.
            /// </summary>
            DS_NOFAILCREATE = 0x0010,

            /// <summary>
            /// Creates a dialog box that works well as a child window of another dialog box, much like a page in a property sheet. This style allows the user to tab among the control windows of a child dialog box, use its accelerator keys, and so on.
            /// </summary>
            DS_CONTROL = 0x0400,

            /// <summary>
            /// Centers the dialog box in the working area of the monitor that contains the owner window. If no owner window is specified, the dialog box is centered in the working area of a monitor determined by the system. The working area is the area not obscured by the taskbar or any appbars.
            /// </summary>
            DS_CENTER = 0x0800,

            /// <summary>
            /// Centers the dialog box on the mouse cursor.
            /// </summary>
            DS_CENTERMOUSE = 0x1000,

            /// <summary>
            /// Includes a question mark in the title bar of the dialog box. When the user clicks the question mark, the cursor changes to a question mark with a pointer. If the user then clicks a control in the dialog box, the control receives a WM_HELP message. The control should pass the message to the dialog box procedure, which should call the function using the HELP_WM_HELP command. The help application displays a pop-up window that typically contains help for the control.
            /// Note that DS_CONTEXTHELP is only a placeholder. When the dialog box is created, the system checks for DS_CONTEXTHELP and, if it is there, adds WS_EX_CONTEXTHELP to the extended style of the dialog box. WS_EX_CONTEXTHELP cannot be used with the WS_MAXIMIZEBOX or WS_MINIMIZEBOX styles.
            /// </summary>
            DS_CONTEXTHELP = 0x2000,

            /// <summary>
            /// Indicates that the dialog box should use the system font. The typeface member of the extended dialog box template must be set to MS Shell Dlg. Otherwise, this style has no effect. It is also recommended that you use the DIALOGEX Resource, rather than the DIALOG Resource. For more information, see Dialog Box Fonts.
            /// The system selects a font using the font data specified in the pointsize, weight, and italic members. The system passes a handle to the font to the dialog box and to each control by sending them the WM_SETFONT message. For descriptions of the format of this font data, see DLGTEMPLATEEX.
            /// If neither DS_SHELLFONT nor DS_SETFONT is specified, the extended dialog box template does not include the font data.
            /// </summary>
            DS_SHELLFONT = DS_SETFONT | DS_FIXEDSYS,

            DS_USEPIXELS = 0x8000,
        }
    }
}
