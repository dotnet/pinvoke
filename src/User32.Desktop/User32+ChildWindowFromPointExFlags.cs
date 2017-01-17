// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Runtime.InteropServices;

    /// <content>
    /// Contains the <see cref="ChildWindowFromPointExFlags"/> nested type.
    /// </content>
    public partial class User32
    {
        /// <summary>
        /// For use with <see cref="ChildWindowFromPointEx"/>
        /// </summary>
        [Flags]
        public enum ChildWindowFromPointExFlags
        {
            /// <summary>
            /// Does not skip any child windows
            /// </summary>
            CWP_ALL = 0x0000,

            /// <summary>
            /// Skips invisible child windows
            /// </summary>
            CWP_SKIPINVISIBLE = 0x0001,

            /// <summary>
            /// Skips disabled child windows
            /// </summary>
            CWP_SKIPDISABLED = 0x0002,

            /// <summary>
            /// Skips transparent child windows
            /// </summary>
            CWP_SKIPTRANSPARENT = 0x0004
        }
    }
}