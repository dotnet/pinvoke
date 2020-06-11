// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PInvoke
{
    /// <content>
    /// Contains the <see cref="GetMenuStateFlags"/> nested type.
    /// </content>
    public partial class User32
    {
        /// <summary>Flags passed to the <see cref="GetMenuStateFlags"/> method.</summary>
        public enum GetMenuStateFlags
        {
            /// <summary>
            /// Indicates that the uId parameter gives the identifier of the menu item.
            /// The <see cref="MF_BYCOMMAND"/> flag is the default if neither the <see cref="MF_BYCOMMAND"/> nor <see cref="MF_BYPOSITION"/> flag is specified.
            /// </summary>
            MF_BYCOMMAND = MenuItemFlags.MF_BYCOMMAND,

            /// <summary>
            /// Indicates that the uId parameter gives the zero-based relative position of the menu item.
            /// </summary>
            MF_BYPOSITION = MenuItemFlags.MF_BYPOSITION,
        }
    }
}
