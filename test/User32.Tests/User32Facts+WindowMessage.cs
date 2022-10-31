// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using PInvoke;

/// <content>
/// Contains the nested class <see cref="WindowMessage"/>.
/// </content>
public partial class User32Facts
{
    /// <summary>
    /// A simple wrapper representig a Window Message's payload.
    /// </summary>
    private class WindowMessage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WindowMessage"/> class.
        /// </summary>
        /// <param name="msg">Window Message ID.</param>
        /// <param name="wParam">The wParam value.</param>
        /// <param name="lParam">The lparam value.</param>
        internal WindowMessage(User32.WindowMessage msg, IntPtr wParam, IntPtr lParam)
        {
            this.Message = msg;
            this.WParam = wParam;
            this.LParam = lParam;
        }

        /// <summary>
        /// Gets the Window Message ID.
        /// </summary>
        internal User32.WindowMessage Message { get; }

        /// <summary>
        /// Gets the wParam value.
        /// </summary>
        internal IntPtr WParam { get; }

        /// <summary>
        /// Gets the lParam value.
        /// </summary>
        internal IntPtr LParam { get; }
    }
}
