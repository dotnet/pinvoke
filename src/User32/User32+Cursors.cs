// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PInvoke
{
    /// <content>
    /// Contains the <see cref="Cursors"/> nested type.
    /// </content>
    public static partial class User32
    {
        /// <summary>
        /// Represents system predefined cursors.
        /// </summary>
        public enum Cursors
        {
            /// <summary>Standard arrow and small hourglass</summary>
            IDC_APPSTARTING = 32650,

            /// <summary>Standard arrow</summary>
            IDC_ARROW = 32512,

            /// <summary>Crosshair</summary>
            IDC_CROSS = 32515,

            /// <summary>Hand</summary>
            IDC_HAND = 32649,

            /// <summary>Arrow and question mark</summary>
            IDC_HELP = 32651,

            /// <summary>I-beam</summary>
            IDC_IBEAM = 32513,

            /// <summary>Obsolete for applications marked version 4.0 or later.</summary>
            IDC_ICON = 32641,

            /// <summary>Slashed circle</summary>
            IDC_NO = 32648,

            /// <summary>Obsolete for applications marked version 4.0 or later. Use IDC_SIZEALL.</summary>
            IDC_SIZE = 32640,

            /// <summary>Four-pointed arrow pointing north, south, east, and west</summary>
            IDC_SIZEALL = 32646,

            /// <summary>Double-pointed arrow pointing northeast and southwest</summary>
            IDC_SIZENESW = 32643,

            /// <summary>Double-pointed arrow pointing north and south</summary>
            IDC_SIZENS = 32645,

            /// <summary>Double-pointed arrow pointing northwest and southeast</summary>
            IDC_SIZENWSE = 32642,

            /// <summary>Double-pointed arrow pointing west and east</summary>
            IDC_SIZEWE = 32644,

            /// <summary>Vertical arrow</summary>
            IDC_UPARROW = 32516,

            /// <summary>Hourglass</summary>
            IDC_WAIT = 32514,
        }
    }
}
