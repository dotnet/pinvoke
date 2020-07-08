// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Runtime.InteropServices;

#pragma warning disable SA1401 // Fields must be private

    /// <content>
    /// Contains the <see cref="UNICODE_STRING"/> nested type.
    /// </content>
    public static partial class NTDll
    {
        /// <summary>
        /// The UNICODE_STRING structure is used to define Unicode strings.
        /// </summary>
        [OfferIntPtrPropertyAccessors]
        public unsafe partial struct UNICODE_STRING
        {
            /// <summary>
            /// The length, in bytes, of the string stored in <see cref="Buffer"/>.
            /// </summary>
            public ushort Length;

            /// <summary>
            /// The length, in bytes, of <see cref="Buffer"/>.
            /// </summary>
            public ushort MaximumLength;

            /// <summary>
            /// Pointer to a buffer used to contain a string of wide characters.
            /// </summary>
            public char* Buffer;
        }
    }
}
