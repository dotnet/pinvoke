// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PInvoke
{
    using System.Runtime.InteropServices;

    /// <summary>
    /// Contains the <see cref="OSVERSIONINFO"/> nested type.
    /// </summary>
    public static partial class Kernel32
    {
        /// <summary>
        /// The <see cref="OSVERSIONINFO"/> structure contains operating system version information.
        /// </summary>
        /// <see href="https://docs.microsoft.com/en-us/windows/win32/api/winnt/ns-winnt-osversioninfow"/>
        public unsafe struct OSVERSIONINFO
        {
            /// <summary>
            /// The size of the <see cref="OSVERSIONINFO"/> structure in bytes.
            /// </summary>
            public int dwOSVersionInfoSize;

            /// <summary>
            /// The major OS version.
            /// </summary>
            public int dwMajorVersion;

            /// <summary>
            /// The minor OS version.
            /// </summary>
            public int dwMinorVersion;

            /// <summary>
            /// The build number of the OS.
            /// </summary>
            public int dwBuildNumber;

            /// <summary>
            /// The OS platform.
            /// </summary>
            public OSPlatformId dwPlatformId;

            /// <summary>
            /// A null-terminated string, such as "Service Pack 3", that indicates the latest Service Pack installed on the system.
            /// If no Service Pack has been installed, the string is empty.
            /// </summary>
            public fixed char szCSDVersion[128];

            /// <summary>
            /// Initializes a new instance of the <see cref="OSVERSIONINFO" /> struct
            /// with <see cref="dwOSVersionInfoSize" /> set to the correct value.
            /// </summary>
            /// <returns>
            /// A newly initialized instance of <see cref="OSVERSIONINFO"/>.
            /// </returns>
            public static OSVERSIONINFO Create() => new OSVERSIONINFO { dwOSVersionInfoSize = sizeof(OSVERSIONINFO) };
        }
    }
}
