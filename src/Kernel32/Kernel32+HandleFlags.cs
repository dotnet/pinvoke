// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PInvoke
{
    using System;

    /// <content>
    /// Contains the nested <see cref="HandleFlags"/> type.
    /// </content>
    public static partial class Kernel32
    {
        [Flags]
        public enum HandleFlags
        {
            /// <summary>
            /// Indicates that none of the flags are set.
            /// </summary>
            /// <remarks>
            /// This value is not defined in Win32 API headers.
            /// </remarks>
            HANDLE_FLAG_NONE = 0,

            /// <summary>
            /// If this flag is set, a child process created with the bInheritHandles parameter of CreateProcess set to TRUE will inherit the object handle.
            /// </summary>
            HANDLE_FLAG_INHERIT = 0x00000001,

            /// <summary>
            /// If this flag is set, calling the <see cref="CloseHandle"/> function will not close the object handle.
            /// </summary>
            HANDLE_FLAG_PROTECT_FROM_CLOSE = 0x00000002,
        }
    }
}
