// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PInvoke
{
    using System;

    /// <content>
    /// Contains the <see cref="NOTIFICATION"/> nested type.
    /// </content>
    public partial class Cabinet
    {
        /// <summary>
        /// Cabinet notification details passed to the FDI Notify callback.
        /// </summary>
        public unsafe struct NOTIFICATION
        {
            /// <summary>
            /// The size, in bytes, of a cabinet element.
            /// </summary>
            public int cb;

            /// <summary>
            /// A null-terminated ANSI string.
            /// </summary>
            public sbyte* psz1;

            /// <summary>
            /// A null-terminated ANSI string.
            /// </summary>
            public sbyte* psz2;

            /// <summary>
            /// A null-terminated ANSI string.
            /// </summary>
            public sbyte* psz3;

            /// <summary>
            /// Pointer to an application-defined value.
            /// </summary>
            public IntPtr pv;

            /// <summary>
            /// Application-defined value used to identify the opened file.
            /// </summary>
            public IntPtr hf;

            /// <summary>
            /// The MS-DOS date when the cabinet file was last modified.
            /// </summary>
            public ushort date;

            /// <summary>
            /// The MS-DOS time when the cabinet file was last modified.
            /// </summary>
            public ushort time;

            /// <summary>
            /// The file attributes.
            /// </summary>
            public short attribs;

            /// <summary>
            /// The identifier for a cabinet set.
            /// </summary>
            public short setID;

            /// <summary>
            /// The number of the cabinets within a set.
            /// </summary>
            public short iCabinet;

            /// <summary>
            /// The number of folders within a cabinet.
            /// </summary>
            public short iFolder;

            /// <summary>
            /// An FDI error code.
            /// </summary>
            public FdiError fdie;
        }
    }
}
