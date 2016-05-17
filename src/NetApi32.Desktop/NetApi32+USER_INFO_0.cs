// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System.Runtime.InteropServices;

    /// <content>
    /// Contains the <see cref="USER_INFO_0"/> nested type.
    /// </content>
    public partial class NetApi32
    {
        /// <summary>
        /// The USER_INFO_0 structure contains a user account name.
        /// </summary>
        [OfferIntPtrPropertyAccessors]
        [StructLayout(LayoutKind.Sequential)]
        public unsafe partial struct USER_INFO_0
        {
            /// <summary>
            /// Pointer to a Unicode string that specifies the name of the user account. For the NetUserSetInfo function, this member specifies the name of the user.
            /// </summary>
            /// <remarks>
            /// User account names are limited to 20 characters and group names are limited to 256 characters. In addition, account names cannot be terminated by a period and they cannot include commas or any of the following printable characters: ", /, \, [, ], :, |, &lt;, &gt;, +, =, ;, ?, *. Names also cannot include characters in the range 1-31, which are nonprintable.
            /// </remarks>
            public char* usri0_name;
        }
    }
}
