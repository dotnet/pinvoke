// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PInvoke
{
    using System.Runtime.InteropServices;

    /// <summary>
    /// Contains the <see cref="OSVERSIONINFOEX"/> nested type.
    /// </summary>
    public static partial class Kernel32
    {
        /// <summary>
        /// The RTL_OSVERSIONINFOEXW structure contains operating system version information.
        /// </summary>
        public unsafe partial struct OSVERSIONINFOEX
        {
            /// <summary>
            /// The size, in bytes, of an RTL_OSVERSIONINFOEXW structure.
            /// This member must be set before the structure is used with RtlGetVersion.
            /// </summary>
            public int dwOSVersionInfoSize;

            /// <summary>
            /// The major version number of the operating system. For example, for Windows 2000, the major version number is five.
            /// </summary>
            public int dwMajorVersion;

            /// <summary>
            /// The minor version number of the operating system. For example, for Windows 2000, the minor version number is zero
            /// </summary>
            public int dwMinorVersion;

            /// <summary>
            /// The build number of the operating system.
            /// </summary>
            public int dwBuildNumber;

            /// <summary>
            /// The operating system platform. For Win32 on NT-based operating systems, RtlGetVersion returns the value
            /// VER_PLATFORM_WIN32_NT.
            /// </summary>
            public int dwPlatformId;

            /// <summary>
            /// The service-pack version string. This member contains a null-terminated string, such as "Service Pack 3", which
            /// indicates the latest service pack installed on the system. If no service pack is installed, RtlGetVersion might not
            /// initialize this string. Initialize szCSDVersion to zero (empty string) before the call to RtlGetVersion.
            /// </summary>
            public fixed char szCSDVersion[128];

            /// <summary>
            /// The major version number of the latest service pack installed on the system. For example, for Service Pack 3,
            /// the major version number is three. If no service pack has been installed, the value is zero.
            /// </summary>
            public short wServicePackMajor;

            /// <summary>
            /// The minor version number of the latest service pack installed on the system. For example, for Service Pack 3,
            /// the minor version number is zero.
            /// </summary>
            public short wServicePackMinor;

            /// <summary>
            /// The product suites available on the system. This member is set to zero or to the bitwise OR of one or more of
            /// the <see cref="PRODUCT_SUITE"/> values.
            /// </summary>
            public PRODUCT_SUITE wSuiteMask;

            /// <summary>
            /// The product type. This member contains additional information about the system.
            /// </summary>
            public OS_TYPE wProductType;

            /// <summary>
            /// Reserved for future use.
            /// </summary>
            public byte wReserved;

            /// <summary>
            /// Helper method to create <see cref="OSVERSIONINFOEX"/> with
            /// the right pre-initialization for <see cref="dwOSVersionInfoSize"/>
            /// </summary>
            /// <returns>A newly initialzed instance of <see cref="OSVERSIONINFOEX"/></returns>
            public static OSVERSIONINFOEX Create() => new OSVERSIONINFOEX
            {
#if NETSTANDARD1_3_ORLATER || NETFX_CORE
                dwOSVersionInfoSize = Marshal.SizeOf<OSVERSIONINFOEX>()
#else
                dwOSVersionInfoSize = Marshal.SizeOf(typeof(OSVERSIONINFOEX))
#endif
            };
        }
    }
}
