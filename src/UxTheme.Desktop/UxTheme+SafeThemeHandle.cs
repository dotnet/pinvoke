// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Runtime.InteropServices;

    /// <content>
    /// Contains the <see cref="SafeThemeHandle"/> nested type.
    /// </content>
    public partial class UxTheme
    {
        /// <summary>
        /// Represents a windows Hook that can be removed with <see cref="CloseThemeData(IntPtr)"/>.
        /// </summary>
        public class SafeThemeHandle : SafeHandle
        {
            public static readonly SafeThemeHandle Null = new SafeThemeHandle();

            /// <summary>
            /// Initializes a new instance of the <see cref="SafeThemeHandle"/> class.
            /// </summary>
            public SafeThemeHandle()
                : base(IntPtr.Zero, true)
            {
            }

            /// <inheritdoc />
            public override bool IsInvalid => this.handle == IntPtr.Zero;

            /// <inheritdoc />
            protected override bool ReleaseHandle() => CloseThemeData(this.handle).Succeeded;
        }
    }
}
