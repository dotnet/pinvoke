// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;

    /// <content>
    /// Contains the <see cref="RegOpenKeyOptions"/> nested type.
    /// </content>
    public static partial class AdvApi32
    {
        /// <summary>
        /// Specifies the option to apply when opening the key in <see cref="RegOpenKeyEx"/>.
        /// </summary>
        [Flags]
        public enum RegOpenKeyOptions
        {
            /// <summary>
            /// No option specified
            /// </summary>
            None = 0,

            /// <summary>
            /// The key is a symbolic link. Registry symbolic links should only be used when absolutely necessary.
            /// </summary>
            REG_OPTION_OPEN_LINK = 0x00000008
        }
    }
}
