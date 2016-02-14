// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

using System.Runtime.InteropServices;

namespace PInvoke
{
    partial class Kernel32
    {
        /// <summary>
        /// Represents a group of icons as stored in a resource
        /// </summary>
        /// <remarks>
        /// The structure is followed by <see cref="idCount"/> <see cref="ICONDIRENTRY"/> entries.
        /// </remarks>
        [StructLayout(LayoutKind.Sequential)]
        public struct GRPICONDIR
        {
            /// <summary>
            /// Reserved (must be 0)
            /// </summary>
            public ushort idReserved;

            /// <summary>
            /// Resource type (1 for icons)
            /// </summary>
            public ushort idType;

            /// <summary>
            /// How many images?
            /// </summary>
            public ushort idCount;
        }
    }
}
