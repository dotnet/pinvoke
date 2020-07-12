// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PInvoke
{
    using System.Runtime.InteropServices;

    /// <content>
    /// Contains the <see cref="ICONDIR"/> nested type.
    /// </content>
    public partial class Kernel32
    {
        /// <summary>
        /// Represents a group of icons as stored in a '.ico' file.
        /// </summary>
        /// <remarks>
        /// The structure is followed by <see cref="idCount"/> <see cref="ICONDIRENTRY"/> entries.
        /// </remarks>
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct ICONDIR
        {
            /// <summary>
            /// Reserved (must be 0).
            /// </summary>
            public ushort idReserved;

            /// <summary>
            /// Resource type (1 for icons).
            /// </summary>
            public ushort idType;

            /// <summary>
            /// Indicates the number of images.
            /// </summary>
            public ushort idCount;
        }
    }
}
