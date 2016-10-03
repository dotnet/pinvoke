// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Runtime.InteropServices;

    /// <content>
    /// Contains the <see cref="SystemParametersInfoFlags"/> nested type.
    /// </content>
    public partial class User32
    {
        [Flags]
        public enum SystemParametersInfoFlags
        {
            None = 0x00,

            /// <summary>
            /// Writes the new system-wide parameter setting to the user profile.
            /// </summary>
            SPIF_UPDATEINIFILE = 0x01,

            /// <summary>
            /// Broadcasts the WM_SETTINGCHANGE message after updating the user profile.
            /// </summary>
            SPIF_SENDCHANGE = 0x02,

            /// <summary>
            /// Same as SPIF_SENDCHANGE.
            /// </summary>
            SPIF_SENDWININICHANGE = 0x02
        }
    }
}