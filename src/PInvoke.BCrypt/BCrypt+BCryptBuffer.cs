// Copyright (c) Andrew Arnott. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Runtime.InteropServices;

    /// <content>
    /// The <see cref="BCryptBuffer"/> nested class.
    /// </content>
    public static partial class BCrypt
    {
        /// <summary>
        /// Used to represent a generic CNG buffer.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct BCryptBuffer
        {
            /// <summary>
            /// The size, in bytes, of the buffer.
            /// </summary>
            public int cbBuffer;

            /// <summary>
            /// A value that specifies the type of buffer represented by this structure.
            /// </summary>
            public BufferType BufferType;

            /// <summary>
            /// A 32-bit value defined by the <see cref="BufferType"/> member.
            /// </summary>
            public IntPtr pvBuffer;
        }
    }
}
