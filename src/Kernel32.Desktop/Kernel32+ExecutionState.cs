// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;

    /// <content>
    /// Contains the <see cref="EXECUTION_STATE"/> nested type.
    /// </content>
    public partial class Kernel32
    {
        /// <summary>
        /// The thread's execution requirements.
        /// </summary>
        [Flags]
        public enum EXECUTION_STATE : uint
        {
            /// <summary>
            /// No flags.
            /// </summary>
            None = 0x0,

            /// <summary>
            /// Enables away mode. This value must be specified with <see cref="ES_CONTINUOUS"/>.
            /// Away mode should be used only by media-recording and media-distribution applications that must perform critical background processing on desktop computers while the computer appears to be sleeping. See Remarks.
            /// </summary>
            ES_AWAYMODE_REQUIRED = 0x00000040,

            /// <summary>
            /// Informs the system that the state being set should remain in effect until the next call that uses <see cref="ES_CONTINUOUS"/> and one of the other state flags is cleared.
            /// </summary>
            ES_CONTINUOUS = 0x80000000,

            /// <summary>
            /// Forces the display to be on by resetting the display idle timer.
            /// </summary>
            ES_DISPLAY_REQUIRED = 0x00000002,

            /// <summary>
            /// Forces the system to be in the working state by resetting the system idle timer.
            /// </summary>
            ES_SYSTEM_REQUIRED = 0x00000001,

            /// <summary>
            /// This value is not supported. If <see cref="ES_USER_PRESENT"/> is combined with other esFlags values, the call will fail and none of the specified states will be set.
            /// </summary>
            [Obsolete("This value is not supported. If ES_USER_PRESENT is combined with other esFlags values, the call will fail and none of the specified states will be set.")]
            ES_USER_PRESENT = 0x00000004
        }
    }
}
