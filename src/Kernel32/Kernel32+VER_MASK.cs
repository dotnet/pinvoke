// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PInvoke
{
    using System;

    /// <summary>
    /// Contains the <see cref="VER_MASK"/> nested type.
    /// </summary>
    public static partial class Kernel32
    {
        /// <summary>
        /// A mask that indicates the member of the <see cref="OSVERSIONINFOEX"/> structure whose comparison operator is being set.
        /// This value corresponds to one of the bits specified in the dwTypeMask parameter for the <see cref="VerifyVersionInfo(OSVERSIONINFOEX*, VER_MASK, long)"/> function.
        /// </summary>
        [Flags]
        public enum VER_MASK : int
        {
            /// <summary>
            /// dwBuildNumber
            /// </summary>
            VER_BUILDNUMBER = 0x0000004,

            /// <summary>
            /// dwBuildNumber
            /// </summary>
            VER_MAJORVERSION = 0x0000002,

            /// <summary>
            /// dwMinorVersion
            /// </summary>
            VER_MINORVERSION = 0x0000001,

            /// <summary>
            /// dwPlatformId
            /// </summary>
            VER_PLATFORMID = 0x0000008,

            /// <summary>
            /// wProductType
            /// </summary>
            VER_PRODUCT_TYPE = 0x0000080,

            /// <summary>
            /// wServicePackMajor
            /// </summary>
            VER_SERVICEPACKMAJOR = 0x0000020,

            /// <summary>
            /// wServicePackMinor
            /// </summary>
            VER_SERVICEPACKMINOR = 0x0000010,

            /// <summary>
            /// wSuiteMask
            /// </summary>
            VER_SUITENAME = 0x0000040,
        }
    }
}
