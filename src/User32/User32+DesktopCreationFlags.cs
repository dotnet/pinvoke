// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    /// <content>
    /// Contains the <see cref="DesktopCreationFlags"/> nested type.
    /// </content>
    public partial class User32
    {
        /// <summary>
        /// Controls the access of other processes to the created desktop
        /// </summary>
        public enum DesktopCreationFlags : uint
        {
            None = 0x0000,

            /// <summary>
            /// Enables processes running in other accounts on the desktop to set hooks in this process
            /// </summary>
            DF_ALLOWOTHERACCOUNTHOOK = 0x0001
        }
    }
}