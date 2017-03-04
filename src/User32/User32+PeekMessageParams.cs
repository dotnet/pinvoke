// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    /// <content>
    /// Contains the <see cref="PeekMessageParams"/> nested type.
    /// </content>
    public partial class User32
    {
        /// <summary>
        /// Specifies how messages are to be handled.
        /// </summary>
        /// <remarks>By default, all message types are processed. To specify that only certain message should be processed, specify one or more of the PM_QS_* values.</remarks>
        [Flags]
        public enum PeekMessageParams : uint
        {
            /// <summary>
            /// Messages are not removed from the queue after processing by PeekMessage.
            /// </summary>
            PM_NOREMOVE = 0x0000,

            /// <summary>
            /// Messages are removed from the queue after processing by PeekMessage.
            /// </summary>
            PM_REMOVE = 0x0001,

            /// <summary>
            /// Prevents the system from releasing any thread that is waiting for the caller to go idle (see <see cref="WaitForInputIdle"/>).
            /// </summary>
            /// <remarks>Combine this value with either PM_NOREMOVE or PM_REMOVE.</remarks>
            PM_NOYIELD = 0x0002,

            /// <summary>
            /// Process mouse and keyboard messages.
            /// </summary>
            PM_QS_INPUT = QueueStatusFlags.QS_INPUT << 16,

            /// <summary>
            /// Process paint messages.
            /// </summary>
            PM_QS_PAINT = QueueStatusFlags.QS_PAINT << 16,

            /// <summary>
            /// Process all posted messages, including timers and hotkeys.
            /// </summary>
            PM_QS_POSTMESSAGE = (QueueStatusFlags.QS_POSTMESSAGE | QueueStatusFlags.QS_HOTKEY | QueueStatusFlags.QS_TIMER) << 16,

            /// <summary>
            /// Process all sent messages.
            /// </summary>
            PM_QS_SENDMESSAGE = QueueStatusFlags.QS_SENDMESSAGE << 16
        }
    }
}