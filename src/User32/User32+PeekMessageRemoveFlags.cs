// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PInvoke
{
    using System;

    /// <content>
    /// Contains the <see cref="PeekMessageRemoveFlags"/> nested type.
    /// </content>
    public partial class User32
    {
#pragma warning disable SA1629 // Documentation text should end with a period
        /// <summary>
        /// Flags to be passed to the <code>wRemoveMsg</code> parameter of
        /// <see cref="PeekMessage(MSG*, IntPtr, WindowMessage, WindowMessage, PeekMessageRemoveFlags)" />.
        /// </summary>
#pragma warning restore SA1629 // Documentation text should end with a period
        [Flags]
        public enum PeekMessageRemoveFlags : uint
        {
            /// <summary>
            /// Messages are not removed from the queue after processing by
            /// <see cref="PeekMessage(MSG*, IntPtr, WindowMessage, WindowMessage, PeekMessageRemoveFlags)" />.
            /// </summary>
            PM_NOREMOVE = 0x0000,

            /// <summary>
            /// Messages are removed from the queue after processing by
            /// <see cref="PeekMessage(MSG*, IntPtr, WindowMessage, WindowMessage, PeekMessageRemoveFlags)" />.
            /// </summary>
            PM_REMOVE = 0x0001,

            /// <summary>
            /// Prevents the system from releasing any thread that is waiting for the caller to go idle (see
            /// WaitForInputIdle). Combine this value with either <see cref="PM_NOREMOVE" /> or <see cref="PM_REMOVE" />.
            /// </summary>
            PM_NOYIELD = 0x0002,

            /// <summary>Process mouse and keyboard messages.</summary>
            PM_QS_INPUT = QueueStatusFlags.QS_INPUT << 16,

            /// <summary>Process paint messages.</summary>
            PM_QS_PAINT = QueueStatusFlags.QS_PAINT << 16,

            /// <summary>Process all posted messages, including timers and hotkeys.</summary>
            PM_QS_POSTMESSAGE =
                (QueueStatusFlags.QS_POSTMESSAGE | QueueStatusFlags.QS_HOTKEY | QueueStatusFlags.QS_TIMER) << 16,

            /// <summary>Process all sent messages.</summary>
            PM_QS_SENDMESSAGE = QueueStatusFlags.QS_SENDMESSAGE << 16,
        }
    }
}
