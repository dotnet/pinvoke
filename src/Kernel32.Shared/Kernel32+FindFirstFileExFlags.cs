// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;

    /// <content>
    /// Contains the <see cref="FindFirstFileExFlags"/> nested type.
    /// </content>
    public partial class Kernel32
    {
        /// <summary>
        /// Optional flags to pass to the <see cref="FindFirstFileEx(string, FINDEX_INFO_LEVELS, out WIN32_FIND_DATA, FINDEX_SEARCH_OPS, void*, FindFirstFileExFlags)"/> method.
        /// </summary>
        [Flags]
        public enum FindFirstFileExFlags
        {
            /// <summary>
            /// No flags.
            /// </summary>
            None = 0x0,

            /// <summary>
            /// Searches are case-sensitive.
            /// </summary>
            FIND_FIRST_EX_CASE_SENSITIVE = 0x1,

            /// <summary>
            /// Uses a larger buffer for directory queries, which can increase performance of the find operation.
            /// </summary>
            FIND_FIRST_EX_LARGE_FETCH = 0x2,
        }
    }
}
