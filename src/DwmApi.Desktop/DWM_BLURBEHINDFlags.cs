// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;

    /// <content>
    /// Contains the <see cref="DWM_BLURBEHINDFlags"/> nested type.
    /// </content>
    public partial class DwmApi
    {
        /// <summary>
        /// Flags used by the <see cref="DWM_BLURBEHIND"/> structure to indicate which of its members contain valid information.
        /// </summary>
        [Flags]
        public enum DWM_BLURBEHINDFlags : uint
        {
            /// <summary>
            /// A value for the fEnable member has been specified.
            /// </summary>
            DWM_BB_ENABLE = 0x1,

            /// <summary>
            /// A value for the hRgnBlur member has been specified.
            /// </summary>
            DWM_BB_BLURREGION = 0x2,

            /// <summary>
            /// A value for the fTransitionOnMaximized member has been specified.
            /// </summary>
            DWM_BB_TRANSITIONONMAXIMIZED = 0x4,
        }
    }
}
