// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System.Runtime.InteropServices;

    /// <content>
    /// Contains the <see cref="CHAR_INFO"/> nested type.
    /// </content>
    public partial class Kernel32
    {
        /// <summary>
        /// Specifies a Unicode or ANSI character and its attributes.
        /// This structure is used by console functions to read from and write to a console screen buffer.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct CHAR_INFO
        {
            /// <summary>
            /// A union of the Unicode and Ascii encodings.
            /// </summary>
            public CHAR_INFO_ENCODING Char;

            /// <summary>
            /// The character attributes. This member can be zero or any combination of the <see cref="CharacterAttributesFlags"/> values
            /// </summary>
            public CharacterAttributesFlags Attributes;
        }
    }
}
