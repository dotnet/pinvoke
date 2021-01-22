// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PInvoke
{
    using System;

    /// <content>Contains the <see cref="MsgWaitForMultipleObjectsExFlags" /> nested type.</content>
    public partial class User32
    {
        /// <summary>
        /// Flags for the <see cref="MsgWaitForMultipleObjectsEx(uint, IntPtr*, uint, WakeMask, MsgWaitForMultipleObjectsExFlags)"/> method.
        /// </summary>
        [Flags]
        public enum MsgWaitForMultipleObjectsExFlags : uint
        {
            /// <summary>
            /// The function returns when any one of the objects is signaled. The return value indicates the object whose state caused the function to return.
            /// </summary>
            None,

            /// <summary>
            /// The function returns when all objects in the pHandles array are signaled and an input event has been received, all at the same time.
            /// </summary>
            MWMO_WAITALL = 0x0001,

            /// <summary>
            /// The function also returns if an APC has been queued to the thread with QueueUserAPC while the thread is in the waiting state.
            /// </summary>
            MWMO_ALERTABLE = 0x0002,

            /// <summary>
            /// The function returns if input exists for the queue, even if the input has been seen (but not removed) using a call to another function, such as <see cref="PeekMessage(MSG*, IntPtr, WindowMessage, WindowMessage, PeekMessageRemoveFlags)"/>.
            /// </summary>
            MWMO_INPUTAVAILABLE = 0x0004,
        }
    }
}
