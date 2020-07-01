// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PInvoke
{
    using System.Runtime.InteropServices;

    /// <content>
    /// Contains the <see cref="USEROBJECTFLAGS"/> nested type.
    /// </content>
    public partial class User32
    {
        /// <summary>
        /// Contains information about a window station or desktop handle.
        /// </summary>
        public struct USEROBJECTFLAGS
        {
            /// <summary>
            /// If this member is TRUE, new processes inherit the handle. Otherwise, the handle is not inherited.
            /// </summary>
            [MarshalAs(UnmanagedType.Bool)]
            public bool fInherit;

            /// <summary>
            /// Reserved for future use. This member must be FALSE.
            /// </summary>
            [MarshalAs(UnmanagedType.Bool)]
            public bool fReserved;

            /// <summary>
            /// Flags indicating object specific characteristics
            /// </summary>
            public UserObjectFlagsEnum dwFlags;
        }
    }
}
