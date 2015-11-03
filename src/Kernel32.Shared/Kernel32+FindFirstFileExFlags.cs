// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;

    /// <content>
    /// Contains the <see cref="FindFirstFileExFlags"/> nested enum.
    /// </content>
    public partial class Kernel32
    {
        /// <summary>
        /// Optional flags to pass to the <see cref="FindFirstFileEx"/> method.
        /// </summary>
        [Flags]
        public enum FindFirstFileExFlags
        {
            /// <summary>
            /// Searches are case-sensitive.
            /// </summary>
            CaseSensitive = 1,

            /// <summary>
            /// Uses a larger buffer for directory queries, which can increase performance of the find operation.
            /// </summary>
            LargeFetch = 2,
        }
    }
}
