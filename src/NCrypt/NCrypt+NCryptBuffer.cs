// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Runtime.InteropServices;

    /// <content>
    /// Contains the <see cref="NCryptBuffer"/> nested type.
    /// </content>
    public partial class NCrypt
    {
        /// <summary>
        /// The NCryptBuffer structure is used to identify a variable-length memory buffer.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        [OfferIntPtrPropertyAccessors]
        public unsafe partial struct NCryptBuffer
        {
            /// <summary>
            /// The size, in bytes, of the buffer.
            /// </summary>
            public int cbBuffer;

            /// <summary>
            /// A value that identifies the type of data that is contained by the buffer.
            /// </summary>
            public BufferType BufferType;

            /// <summary>
            /// The address of the buffer. The size of this buffer is contained in the <see cref="cbBuffer"/> member.
            /// The format and contents of this buffer are identified by the <see cref="BufferType"/> member.
            /// </summary>
            public void* pvBuffer;
        }
    }
}
