// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PInvoke
{
    using System;

    /// <summary>
    /// Contains the <see cref="MONITORINFO_Flags"/> nested type.
    /// </summary>
    public partial class User32
    {
        /// <summary>
        /// Flags that may be defined on the <see cref="MONITORINFO.dwFlags"/> field.
        /// </summary>
        [Flags]
        public enum MONITORINFO_Flags
        {
            /// <summary>
            /// No flags.
            /// </summary>
            None = 0x0,

            /// <summary>
            /// This is the primary display monitor.
            /// </summary>
            MONITORINFOF_PRIMARY = 0x1,
        }
    }
}
