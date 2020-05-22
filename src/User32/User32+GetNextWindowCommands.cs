// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PInvoke
{
    /// <content>
    /// Contains the <see cref="GetNextWindowCommands"/> nested type.
    /// </content>
    public partial class User32
    {
        /// <summary>The commands that can be used as arguments to <see cref="GetNextWindow" />.</summary>
        public enum GetNextWindowCommands
        {
            /// <summary>Returns a handle to the window below the given window.</summary>
            GW_HWNDNEXT = GetWindowCommands.GW_HWNDNEXT,

            /// <summary>Returns a handle to the window above the given window.</summary>
            GW_HWNDPREV = GetWindowCommands.GW_HWNDPREV,
        }
    }
}
