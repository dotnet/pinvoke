// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PInvoke
{
    using System;

    /// <content>
    /// Contains the <see cref="GetMenuDefaultItemFlags"/> nested type.
    /// </content>
    public partial class User32
    {
        /// <summary>
        /// Flags to be passed into the <see cref="GetMenuDefaultItem(IntPtr, uint, GetMenuDefaultItemFlags)"/> method.
        /// </summary>
        [Flags]
        public enum GetMenuDefaultItemFlags
        {
            /// <summary>
            /// The function is to return a default item, even if it is disabled. By default, the function skips disabled or grayed items.
            /// </summary>
            GMDI_USEDISABLED = 0x0001,

            /// <summary>
            /// If the default item is one that opens a submenu, the function is to search recursively in the corresponding submenu. If the submenu has no default item, the return value identifies the item that opens the submenu. By default, the function returns the first default item on the specified menu, regardless of whether it is an item that opens a submenu.
            /// </summary>
            GMDI_GOINTOPOPUPS = 0x0002,
        }
    }
}
