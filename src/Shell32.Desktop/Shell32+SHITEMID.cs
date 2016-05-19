// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Runtime.InteropServices;

    /// <content>
    /// Contains the <see cref="SHITEMID"/> nested type.
    /// </content>
    public partial class Shell32
    {
        /// <summary>
        /// Defines an item identifier.
        /// This struct must *always* be handled via pointer
        /// rather than copied around because it is just the header to a native buffer.
        /// </summary>
        /// <remarks>Used by <see cref="ITEMIDLIST"/></remarks>
        [StructLayout(LayoutKind.Sequential)]
        [OfferIntPtrPropertyAccessors]
        public unsafe partial struct SHITEMID
        {
            /// <summary>
            /// The size of identifier, in bytes, including <see cref="cb"/> itself.
            /// </summary>
            public ushort cb;

            /// <summary>
            /// A variable-length item identifier.
            /// </summary>
            public fixed byte abID[1];
        }
    }
}