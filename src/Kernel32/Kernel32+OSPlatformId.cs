// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PInvoke
{
    using System.Runtime.InteropServices;

    /// <summary>
    /// Contains the <see cref="OSPlatformId"/> nested type.
    /// </summary>
    public static partial class Kernel32
    {
        /// <summary>
        /// The <see cref="OSPlatformId"/> structure contains operating system version information.
        /// </summary>
        public enum OSPlatformId
        {
            /// <summary>
            /// The operating system is Microsoft Windows 3.1.
            /// </summary>
            VER_PLATFORM_WIN32s = 0,

            /// <summary>
            /// The operating system is Windows 95, Windows 98, or operating systems descended from them.
            /// </summary>
            VER_PLATFORM_WIN32_WINDOWS = 1,

            /// <summary>
            /// The operating system is Windows 7, Windows Server 2008, Windows Vista, Windows Server 2003, Windows XP, or Windows 2000.
            /// </summary>
            VER_PLATFORM_WIN32_NT = 2,
        }
    }
}
