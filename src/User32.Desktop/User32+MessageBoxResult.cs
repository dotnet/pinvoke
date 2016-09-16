// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;

    /// <content>
    /// Contains the <see cref="MessageBoxResult"/> nested type.
    /// </content>
    public partial class User32
    {
        /// <summary>
        /// Represents possible values returned by the <see cref="MessageBox"/> function.
        /// </summary>
        public enum MessageBoxResult : uint
        {
            /// <summary>
            /// The OK button was selected.
            /// </summary>
            IDOK = 1,

            /// <summary>
            /// The Cancel button was selected.
            /// </summary>
            IDCANCEL = 2,

            /// <summary>
            /// The Abort button was selected.
            /// </summary>
            IDABORT = 3,

            /// <summary>
            /// The Retry button was selected.
            /// </summary>
            IDRETRY = 4,

            /// <summary>
            /// The Ignore button was selected.
            /// </summary>
            IDIGNORE = 5,

            /// <summary>
            /// The Yes button was selected.
            /// </summary>
            IDYES = 6,

            /// <summary>
            /// The No button was selected.
            /// </summary>
            IDNO = 7,

            /// <summary>
            /// The user closed the message box.
            /// </summary>
            IDCLOSE = 8,

            /// <summary>
            /// The Help button was selected.
            /// </summary>
            IDHELP = 9,

            /// <summary>
            /// The Try Again button was selected.
            /// </summary>
            IDTRYAGAIN = 10,

            /// <summary>
            /// The Continue button was selected.
            /// </summary>
            IDCONTINUE = 11,

            /// <summary>
            /// The user did not click any button and the messagebox timed out.
            /// </summary>
            IDTIMEOUT = 32000
        }
    }
}