// Copyright (c) All contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PInvoke
{
    using System.Runtime.InteropServices;

    /// <content>
    /// Contains the <see cref="FILETIME"/> nested type.
    /// </content>
    public partial class Kernel32
    {
        /// <summary>
        /// A 64-bit representation of a file timestamp.
        /// </summary>
        /// <remarks>
        /// This type is equivalent to <see cref="System.Runtime.InteropServices.ComTypes.FILETIME"/>.
        /// We couldn't use that type directly even though it's in the portable profile because
        /// Xamarin.Android and Xamarin.iOS omit the type and it causes link failures.
        /// See https://github.com/AArnott/pinvoke/issues/232
        /// </remarks>
        [StructLayout(LayoutKind.Sequential)]
        public struct FILETIME
        {
            /// <summary>
            /// Specifies the low 32 bits of the FILETIME.
            /// </summary>
            public int dwLowDateTime;

            /// <summary>
            /// Specifies the high 32 bits of the FILETIME.
            /// </summary>
            public int dwHighDateTime;
        }
    }
}
