// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;

    /// <content>
    /// Contains the <see cref="MessageBoxOptions"/> nested type.
    /// </content>
    public partial class User32
    {
        /// <summary>
        /// Flags that define appearance and behavior of a standard message box
        /// displayed by a call to the <see cref="MessageBox"/> function.
        /// </summary>
        [Flags]
        public enum MessageBoxOptions : uint
        {
            /// <summary>
            /// The message box contains one push button: OK. This is the default.
            /// </summary>
            MB_OK = 0x000000,

            /// <summary>
            /// The message box contains two push buttons: OK and Cancel.
            /// </summary>
            MB_OKCANCEL = 0x000001,

            /// <summary>
            /// The message box contains three push buttons: Abort, Retry, and Ignore.
            /// </summary>
            MB_ABORTRETRYIGNORE = 0x000002,

            /// <summary>
            /// The message box contains three push buttons: Yes, No, and Cancel.
            /// </summary>
            MB_YESNOCANCEL = 0x000003,

            /// <summary>
            /// The message box contains two push buttons: Yes and No.
            /// </summary>
            MB_YESNO = 0x000004,

            /// <summary>
            /// The message box contains two push buttons: Retry and Cancel.
            /// </summary>
            MB_RETRYCANCEL = 0x000005,

            /// <summary>
            /// The message box contains three push buttons: Cancel, Try Again, Continue. Use this message box type instead of <see cref="MB_ABORTRETRYIGNORE"/>.
            /// </summary>
            MB_CANCELTRYCONTINUE = 0x000006,

            /// <summary>
            /// A stop-sign icon appears in the message box.
            /// </summary>
            MB_ICONSTOP = 0x000010,

            /// <summary>
            /// A stop-sign icon appears in the message box.
            /// </summary>
            MB_ICONERROR = 0x00000010,

            /// <summary>
            /// A stop-sign icon appears in the message box.
            /// </summary>
            MB_ICONHAND = 0x00000010,

            /// <summary>
            /// A question-mark icon appears in the message box. The question-mark message icon is no longer recommended because it does not clearly represent a specific type of message
            /// and because the phrasing of a message as a question could apply to any message type.
            /// In addition, users can confuse the message symbol question mark with Help information.
            /// Therefore, do not use this question mark message symbol in your message boxes.
            /// The system continues to support its inclusion only for backward compatibility.
            /// </summary>
            MB_ICONQUESTION = 0x000020,

            /// <summary>
            /// An exclamation-point icon appears in the message box.
            /// </summary>
            MB_ICONWARNING = 0x000030,

            /// <summary>
            /// An exclamation-point icon appears in the message box.
            /// </summary>
            MB_ICONEXCLAMATION = 0x000030,

            /// <summary>
            /// An icon consisting of a lowercase letter i in a circle appears in the message box.
            /// </summary>
            MB_ICONASTERISK = 0x000040,

            /// <summary>
            /// An icon consisting of a lowercase letter i in a circle appears in the message box.
            /// </summary>
            MB_ICONINFORMATION = 0x00000040,

            /// <summary>
            /// Uses an user defined icon
            /// </summary>
            MB_USERICON = 0x000080,

            /// <summary>
            /// The first button is the default button.
            /// MB_DEFBUTTON1 is the default unless <see cref="MB_DEFBUTTON2"/>, <see cref="MB_DEFBUTTON3"/>, or <see cref="MB_DEFBUTTON4"/> is specified.
            /// </summary>
            MB_DEFBUTTON1 = 0x000000,

            /// <summary>
            /// The second button is the default button.
            /// </summary>
            MB_DEFBUTTON2 = 0x000100,

            /// <summary>
            /// The third button is the default button.
            /// </summary>
            MB_DEFBUTTON3 = 0x000200,

            /// <summary>
            /// The fourth button is the default button.
            /// </summary>
            MB_DEFBUTTON4 = 0x000300,

            /// <summary>
            /// The user must respond to the message box before continuing work in the window identified by the hWnd parameter.
            /// However, the user can move to the windows of other threads and work in those windows.
            /// Depending on the hierarchy of windows in the application, the user may be able to move to other windows within the thread.
            /// All child windows of the parent of the message box are automatically disabled, but pop-up windows are not.
            /// MB_APPLMODAL is the default if neither <see cref="MB_SYSTEMMODAL"/> nor <see cref="MB_TASKMODAL"/> is specified.
            /// </summary>
            MB_APPLMODAL = 0x000000,

            /// <summary>
            /// Same as <see cref="MB_APPLMODAL"/> except that the message box has the WS_EX_TOPMOST style.
            /// Use system-modal message boxes to notify the user of serious, potentially damaging errors that require immediate attention (for example, running out of memory).
            /// This flag has no effect on the user's ability to interact with windows other than those associated with hWnd.
            /// </summary>
            MB_SYSTEMMODAL = 0x001000,

            /// <summary>
            /// Same as <see cref="MB_APPLMODAL"/> except that all the top-level windows belonging to the current thread are disabled if the hWnd parameter is NULL.
            /// Use this flag when the calling application or library does not have a window handle available but still needs to prevent input to other windows
            /// in the calling thread without suspending other threads.
            /// </summary>
            MB_TASKMODAL = 0x002000,

            /// <summary>
            /// Adds a Help button to the message box. When the user clicks the Help button or presses F1, the system sends a <see cref="WindowMessage.WM_HELP"/> message to the owner.
            /// </summary>
            MB_HELP = 0x004000,

            /// <summary>
            /// Undocumented
            /// </summary>
            MB_NOFOCUS = 0x008000,

            /// <summary>
            /// The message box becomes the foreground window. Internally, the system calls the <see cref="SetForegroundWindow"/> function for the message box.
            /// </summary>
            MB_SETFOREGROUND = 0x00010000,

            /// <summary>
            /// Same as desktop of the interactive window station. For more information, see Window Stations.
            /// If the current input desktop is not the default desktop, MessageBox does not return until the user switches to the default desktop.
            /// </summary>
            MB_DEFAULT_DESKTOP_ONLY = 0x00020000,

            /// <summary>
            /// The message box is created with the WS_EX_TOPMOST window style.
            /// </summary>
            MB_TOPMOST = 0x00040000,

            /// <summary>
            /// The text is right-justified.
            /// </summary>
            MB_RIGHT = 0x00080000,

            /// <summary>
            /// Displays message and caption text using right-to-left reading order on Hebrew and Arabic systems.
            /// </summary>
            MB_RTLREADING = 0x00100000,

            /// <summary>
            /// The caller is a service notifying the user of an event. The function displays a message box on the current active desktop, even if there is no user logged on to the computer.
            /// If this flag is set, the hWnd parameter must be NULL. This is so that the message box can appear on a desktop other than the desktop corresponding to the hWnd.
            /// </summary>
            /// <remarks>Terminal Services: If the calling thread has an impersonation token, the function directs the message box to the session specified in the impersonation token.</remarks>
            MB_SERVICE_NOTIFICATION = 0x00200000
        }
    }
}