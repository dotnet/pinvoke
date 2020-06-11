// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PInvoke
{
    using System;

    /// <content>
    /// Contains the <see cref="LookupIconIdFromDirectoryExFlags"/> nested type.
    /// </content>
    public partial class User32
    {
        /// <summary>
        /// Flags for the <see cref="LookupIconIdFromDirectoryEx(byte*, bool, int, int, LookupIconIdFromDirectoryExFlags)"/> method.
        /// </summary>
        [Flags]
        public enum LookupIconIdFromDirectoryExFlags
        {
            /// <summary>
            /// Uses the default color format.
            /// </summary>
            LR_DEFAULTCOLOR = 0x0,

            /// <summary>
            /// Creates a monochrome icon or cursor.
            /// </summary>
            LR_MONOCHROME = 0x00000001,
        }
    }
}
