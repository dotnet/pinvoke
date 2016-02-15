// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Runtime.InteropServices;

#pragma warning disable SA1401 // Fields must be private

    /// <content>
    /// Contains the <see cref="UNICODE_STRING"/> nested struct.
    /// </content>
    public static partial class NTDll
    {
        /// <summary>
        /// The UNICODE_STRING structure is used to define Unicode strings.
        /// </summary>
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        public struct UNICODE_STRING
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
            [MarshalAs(UnmanagedType.LPWStr)]
            public string Buffer;

            /// <summary>
            /// Initializes a new instance of the <see cref="UNICODE_STRING"/>structure.
            /// </summary>
            /// <param name="str">A string to represent as UNICODE_STRING</param>
            /// <returns>An <see cref="UNICODE_STRING"/> instance with all the fields set correctly.</returns>
            public static UNICODE_STRING Create(string str)
            {
                return new UNICODE_STRING
                {
                    Length = (ushort)(str.Length * sizeof(char)),
                    MaximumLength = (ushort)(str.Length * sizeof(char)),
                    Buffer = str
                };
            }
        }
    }
}