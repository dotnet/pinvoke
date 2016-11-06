// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System.Runtime.InteropServices;

    /// <content>
    /// Contains the <see cref="WTS_SESSION_INFO"/> nested type.
    /// </content>
    public static partial class WtsApi32
    {
        /// <summary>
        ///     Contains information about a client session on a Remote Desktop Session Host (RD Session Host) server.
        /// </summary>
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        [OfferIntPtrPropertyAccessors]
        public unsafe partial struct WTS_SESSION_INFO
        {
            /// <summary>
            /// Session identifier of the session.
            /// </summary>
            public int SessionID;

            /// <summary>
            /// Pointer to a null-terminated string that contains the WinStation name of this session. The WinStation name is a name that Windows associates with the session, for example, "services", "console", or "RDP-Tcp#0".
            /// </summary>
            public char* pWinStationName;

            /// <summary>
            /// A value from the <see cref="WTS_CONNECTSTATE_CLASS"/> enumeration type that indicates the session's current connection state.
            /// </summary>
            public WTS_CONNECTSTATE_CLASS State;

            /// <summary>
            /// Gets the WinStation name of this session. The WinStation name is a name that Windows associates with the session, for example, "services", "console", or "RDP-Tcp#0".
            /// </summary>
            public string WinStationName => new string(this.pWinStationName);
        }
    }
}
