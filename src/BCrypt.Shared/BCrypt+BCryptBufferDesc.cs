// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Runtime.InteropServices;

    /// <content>
    /// The <see cref="BCryptBufferDesc"/> nested type.
    /// </content>
    public static partial class BCrypt
    {
        /// <summary>
        /// Used to contain a set of generic CNG buffers.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        [OfferIntPtrPropertyAccessors]
        public unsafe partial struct BCryptBufferDesc
        {
            /// <summary>
            /// The version of the <see cref="BCryptBufferDesc"/> structure defined in this library.
            /// </summary>
            public const uint BCRYPTBUFFER_VERSION = 0;

            /// <summary>
            /// The version of the structure.
            /// </summary>
            /// <remarks>
            /// This must have the value of <see cref="BCRYPTBUFFER_VERSION"/>.
            /// </remarks>
            public uint ulVersion;

            /// <summary>
            /// The number of elements in the <see cref="pBuffers"/> array.
            /// </summary>
            public int cBuffers;

            /// <summary>
            /// The address of an array of <see cref="BCryptBuffer"/> structures that contain the buffers.
            /// The <see cref="cBuffers"/> member contains the number of elements in this array.
            /// </summary>
            public BCryptBuffer* pBuffers;
        }
    }
}
