// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PInvoke
{
    /// <content>
    /// Contains the <see cref="Icons"/> nested type.
    /// </content>
    public static partial class User32
    {
        /// <summary>
        /// Represents system predefined cursors.
        /// </summary>
        public enum Icons
        {
            /// <summary>Default application icon.</summary>
            IDI_APPLICATION = 32512,

            /// <summary>Asterisk icon. Same as IDI_INFORMATION.</summary>
            IDI_ASTERISK = 32516,

            /// <summary>Hand-shaped icon.</summary>
            IDI_ERROR = 32513,

            /// <summary>Exclamation point icon.Same as IDI_WARNING.</summary>
            IDI_EXCLAMATION = 32515,

            /// <summary>Hand-shaped icon.Same as IDI_ERROR.</summary>
            IDI_HAND = 32513,

            /// <summary>Asterisk icon.</summary>
            IDI_INFORMATION = 32516,

            /// <summary>Question mark icon.</summary>
            IDI_QUESTION = 32514,

            /// <summary>Security Shield icon.</summary>
            IDI_SHIELD = 32518,

            /// <summary>Exclamation point icon.</summary>
            IDI_WARNING = 32515,

            /// <summary>Default application icon. Windows 2000:  Windows logo icon.</summary>
            IDI_WINLOGO = 32517,
        }
    }
}
