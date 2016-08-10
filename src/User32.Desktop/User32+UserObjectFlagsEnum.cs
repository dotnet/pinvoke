// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    /// <content>
    /// Contains the <see cref="UserObjectFlagsEnum"/> nested type.
    /// </content>
    public partial class User32
    {
        /// <summary>
        /// Flags indicating user object specific characteristics
        /// </summary>
        public enum UserObjectFlagsEnum : uint
        {
            None = 0,

            /// <summary>
            /// For window stations, indicates that the window station has visible display surfaces
            /// </summary>
            WSF_VISIBLE = 0x0001,

            /// <summary>
            /// For desktops, indicates that the desktop allows processes running in other accounts on the desktop to set hooks in this process.
            /// </summary>
            DF_ALLOWOTHERACCOUNTHOOK = 0x0001
        }
    }
}