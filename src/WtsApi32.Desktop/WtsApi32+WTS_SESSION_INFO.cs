// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Text;

    /// <content>
    /// Exported functions from the WtsApi32.dll Windows library
    /// that are available to Desktop apps only.
    /// </content>
    public static partial class WtsApi32
    {
        /// <summary>
        ///     Contains information about a client session on a Remote Desktop Session Host (RD Session Host) server.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct WTS_SESSION_INFO
        {
            public int SessionID;

            [MarshalAs(UnmanagedType.LPTStr)]
            public string pWinStationName;

            public WtsConnectStateClass State;
        }
    }
}
