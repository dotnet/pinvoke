// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Runtime.InteropServices;

    /// <content>
    /// Contains the <see cref="NCryptBufferDesc"/> nested type.
    /// </content>
    public partial class NCrypt
    {
        /// <summary>
        /// Used to receive a collection of <see cref="NCryptBuffer"/> structures.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        [OfferIntPtrPropertyAccessors]
        public unsafe partial struct NCryptBufferDesc
        {
            public const uint NCRYPTBUFFER_VERSION = 0;
            public const int NCRYPTBUFFER_EMPTY = 0;

            /// <summary>
            /// The version number of the structure. Currently, this member must be set to <see cref="NCRYPTBUFFER_VERSION"/>.
            /// </summary>
            public uint ulVersion;

            /// <summary>
            /// The number of elements in the <see cref="pBuffers"/> array.
            /// You can test the value received against NCRYPTBUFFER_EMPTY (0) to determine whether the array pointed to by the <see cref="pBuffers"/> parameter contains any members.
            /// </summary>
            public int cBuffers;

            /// <summary>
            /// An array of <see cref="NCryptBuffer"/> structures that contain the buffer information. The <see cref="cBuffers"/> member contains the number of elements in this array.
            /// </summary>
            public NCryptBuffer* pBuffers;

            /// <summary>
            /// Creates an instance of the <see cref="NCryptBufferDesc"/> structure with
            /// the <see cref="ulVersion"/> field initialized to <see cref="NCRYPTBUFFER_VERSION"/>.
            /// </summary>
            /// <returns>The initialized instance of <see cref="NCryptBufferDesc"/>.</returns>
            public static NCryptBufferDesc Create()
            {
                return new NCryptBufferDesc
                {
                    ulVersion = NCRYPTBUFFER_VERSION,
                };
            }
        }
    }
}