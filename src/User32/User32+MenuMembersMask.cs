// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PInvoke
{
    using System;

    /// <content>
    /// Contains the <see cref="MenuMembersMask"/> nested type.
    /// </content>
    public partial class User32
    {
        /// <summary>Indicates the members to be retrieved or set in <see cref="MENUITEMINFO" />.</summary>
        [Flags]
        public enum MenuMembersMask
        {
            /// <summary>Retrieves or sets the <see cref="MENUITEMINFO.hbmpItem" /> member.</summary>
            MIIM_BITMAP = 0x00000080,

            /// <summary>Retrieves or sets the <see cref="MENUITEMINFO.hbmpChecked" /> and <see cref="MENUITEMINFO.hbmpUnchecked" />
            ///     members.</summary>
            MIIM_CHECKMARKS = 0x00000008,

            /// <summary>Retrieves or sets the <see cref="MENUITEMINFO.dwItemData" /> member.</summary>
            MIIM_DATA = 0x00000020,

            /// <summary>Retrieves or sets the <see cref="MENUITEMINFO.fType" /> member.</summary>
            MIIM_FTYPE = 0x00000100,

            /// <summary>Retrieves or sets the <see cref="MENUITEMINFO.wID" /> member.</summary>
            MIIM_ID = 0x00000002,

            /// <summary>Retrieves or sets the <see cref="MENUITEMINFO.fState" /> member.</summary>
            MIIM_STATE = 0x00000001,

            /// <summary>Retrieves or sets the <see cref="MENUITEMINFO.dwTypeData" /> member.</summary>
            MIIM_STRING = 0x00000040,

            /// <summary>Retrieves or sets the <see cref="MENUITEMINFO.hSubMenu" /> member.</summary>
            MIIM_SUBMENU = 0x00000004,

            /// <summary>
            ///     Retrieves or sets the <see cref="MENUITEMINFO.fType" /> and <see cref="MENUITEMINFO.dwTypeData" /> members.
            ///     <para>MIIM_TYPE is replaced by <see cref="MIIM_BITMAP" />, <see cref="MIIM_FTYPE" />, and
            ///         <see cref="MIIM_STRING" />.</para>
            /// </summary>
            MIIM_TYPE = 0x00000010,
        }
    }
}
