﻿// Copyright (c) All contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

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
            /// <summary>
            /// A handle that may be used in place of <see cref="IntPtr.Zero"/>.
            /// </summary>
            public static readonly SafeThemeHandle Null = new SafeThemeHandle();

            /// <summary>
            /// Initializes a new instance of the <see cref="SafeThemeHandle"/> class.
            /// </summary>
            public SafeThemeHandle()
                : base(IntPtr.Zero, true)
            {
            }

            /// <summary>
            /// Initializes a new instance of the <see cref="SafeThemeHandle"/> class.
            /// </summary>
            /// <param name="preexistingHandle">An object that represents the pre-existing handle to use.</param>
            /// <param name="ownsHandle">
            ///     <see langword="true" /> to have the native handle released when this safe handle is disposed or finalized;
            ///     <see langword="false" /> otherwise.
            /// </param>
            public SafeThemeHandle(IntPtr preexistingHandle, bool ownsHandle = true)
                : base(IntPtr.Zero, ownsHandle)
            {
                this.SetHandle(preexistingHandle);
            }

            /// <inheritdoc />
            public override bool IsInvalid => this.handle == IntPtr.Zero;

            /// <summary>
            /// Implicitly converts a <see cref="User32.SafeThemeHandle"/> to a <see cref="SafeThemeHandle"/>.
            /// This enables the use of theme handles created as part of user32!OpenThemeDataForDpi to be used
            /// in UxTheme API's seamlessly.
            /// </summary>
            /// <param name="hTheme">Theme handle from User32 library to be converted to a <see cref="SafeThemeHandle"/></param>
            public static implicit operator SafeThemeHandle(User32.SafeThemeHandle hTheme)
            {
                if (hTheme == null)
                {
                    throw new ArgumentNullException(nameof(hTheme));
                }

                hTheme.SetHandleAsInvalid();
                return new SafeThemeHandle(hTheme.DangerousGetHandle(), true);
            }

            /// <inheritdoc />
            protected override bool ReleaseHandle() => CloseThemeData(this.handle).Succeeded;
        }
    }
}
