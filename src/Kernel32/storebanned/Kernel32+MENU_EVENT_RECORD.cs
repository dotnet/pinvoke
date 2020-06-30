// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Runtime.InteropServices;

    /// <content>
    /// Contains the <see cref="MENU_EVENT_RECORD"/> nested type.
    /// </content>
    public partial class Kernel32
    {
        /// <summary>
        /// Describes a menu event in a console <see cref="INPUT_RECORD"/> structure.
        /// </summary>
        /// <remarks>
        /// These events are used internally and should be ignored.
        /// </remarks>
        public struct MENU_EVENT_RECORD
        {
            /// <summary>
            /// Reserved.
            /// </summary>
            public uint dwCommandId;
        }
    }
}
