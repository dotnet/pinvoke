// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Diagnostics;

    /// <content>
    /// Contains the <see cref="CreatePseudoConsoleFlags"/> nested type.
    /// </content>
    public partial class Kernel32
    {
        /// <summary>
        /// Flags for the <see cref="CreatePseudoConsole(COORD, SafeObjectHandle, SafeObjectHandle, CreatePseudoConsoleFlags, out SafePseudoConsoleHandle)"/> method.
        /// </summary>
        public enum CreatePseudoConsoleFlags
        {
            /// <summary>
            /// Perform a standard pseudoconsole creation.
            /// </summary>
            None = 0,

            /// <summary>
            /// The created pseudoconsole session will attempt to inherit the cursor position of the parent console.
            /// </summary>
            PSEUDOCONSOLE_INHERIT_CURSOR = 1,
        }
    }
}
