// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PInvoke
{
    using System;

    /// <content>
    /// Contains the <see cref="WindowLongIndexFlags"/> nested type.
    /// </content>
    public partial class User32
    {
        [Flags]
        public enum WindowLongIndexFlags : int
        {
            GWL_EXSTYLE = -20,
            GWLP_HINSTANCE = -6,
            GWLP_HWNDPARENT = -8,
            GWL_ID = -12,
            GWLP_ID = GWL_ID,
            GWL_STYLE = -16,
            GWL_USERDATA = -21,
            GWLP_USERDATA = GWL_USERDATA,
            GWL_WNDPROC = -4,
            GWLP_WNDPROC = GWL_WNDPROC,
            DWLP_USER = 0x8,
            DWLP_MSGRESULT = 0x0,
            DWLP_DLGPROC = 0x4,
        }
    }
}
