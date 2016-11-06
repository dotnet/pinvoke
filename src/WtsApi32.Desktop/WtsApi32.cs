// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    using static Kernel32;

    /// <content>
    /// Exported functions from the WtsApi32.dll Windows library
    /// that are available to Desktop apps only.
    /// </content>
    [OfferFriendlyOverloads]
    public static partial class WtsApi32
    {
        public static readonly SafeTerminalServerHandle WTS_CURRENT_SERVER_HANDLE = SafeTerminalServerHandle.Null;

        /// <summary>
        /// Obtains the primary access token of the logged-on user specified by the session ID. To call this function successfully,
        /// the calling application must be running within the context of the LocalSystem account and have the SE_TCB_NAME privilege.
        /// Caution WTSQueryUserToken is intended for highly trusted services.Service providers must use caution that they do not
        /// leak user tokens when calling this function.Service providers must close token handles after they have finished using them.
        /// </summary>
        /// <param name="SessionId">A Remote Desktop Services session identifier. Any program running in the context of a service
        /// will have a session identifier of zero (0). You can use the WTSEnumerateSessions function to retrieve the identifiers of
        /// all sessions on a specified RD Session Host server.
        /// To be able to query information for another user's session, you need to have the Query Information permission.
        /// For more information, see Remote Desktop Services Permissions. To modify permissions on a session, use the
        /// Remote Desktop Services Configuration administrative tool.</param>
        /// <param name="phToken">If the function succeeds, receives a pointer to the token handle for the logged-on user. Note
        /// that you must call <see cref="SafeHandle.Dispose()"/> function to close this handle.</param>
        /// <returns>f the function succeeds, the return value is a nonzero value, and the phToken parameter points to the primary
        /// token of the user.</returns>
        [DllImport(nameof(WtsApi32), SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool WTSQueryUserToken(int SessionId, out SafeObjectHandle phToken);

        /// <summary>
        /// Frees memory allocated by a Remote Desktop Services function.
        /// </summary>
        /// <param name="pMemory">Pointer to the memory to free.</param>
        [DllImport(nameof(WtsApi32))]
        public static extern unsafe void WTSFreeMemory(void* pMemory);

        /// <summary>
        /// Retrieves a list of sessions on a Remote Desktop Session Host (RD Session Host) server.
        /// </summary>
        /// <param name="hServer">A handle to the RD Session Host server.
        /// You can use the <see cref="WTSOpenServer"/> or <see cref="WTSOpenServerEx"/> functions to retrieve a handle to a specific
        /// server, or <see cref="WTS_CURRENT_SERVER_HANDLE"/> to use the RD Session Host server that hosts your application.</param>
        /// <param name="Reserved">This parameter is reserved. It must be zero.</param>
        /// <param name="Version">The version of the enumeration request. This parameter must be 1.</param>
        /// <param name="ppSessionInfo">A pointer to <see cref="IEnumerable&lt;WTS_SESSION_INFO&gt;"/> structures that represent the retrieved
        /// sessions. Note, that returned object doesn't know overall count of sessions, and always return true for MoveNext, use it in pair
        /// with pSessionInfoCount parameter</param>
        /// <param name="pCount">A pointer to the number of WTS_SESSION_INFO structures returned in the ppSessionInfo parameter.</param>
        /// <returns>Returns zero if this function fails. If this function succeeds, a nonzero value is returned.</returns>
        [DllImport(nameof(WtsApi32), SetLastError = true, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern unsafe bool WTSEnumerateSessions(
            SafeTerminalServerHandle hServer,
            uint Reserved,
            uint Version,
            out WTS_SESSION_INFO* ppSessionInfo,
            out int pCount);

        /// <summary>
        /// Opens a handle to the specified Remote Desktop Session Host (RD Session Host) server.
        /// </summary>
        /// <param name="pServerName">A string specifying the NetBIOS name of the RD Session Host server.</param>
        /// <returns>If the function succeeds, the return value is a handle to the specified server.
        /// If the function fails, it returns a handle that is not valid.You can test the validity of the handle by using it
        /// in another function call.</returns>
        [DllImport(nameof(WtsApi32), SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern SafeTerminalServerHandle WTSOpenServer(string pServerName);

        /// <summary>
        /// Opens a handle to the specified Remote Desktop Session Host (RD Session Host) server or Remote Desktop Virtualization Host (RD Virtualization Host) server.
        /// </summary>
        /// <param name="pServerName">A string that contains the NetBIOS name of the server.</param>
        /// <returns>If the function succeeds, the return value is a handle to the specified server.
        /// If the function fails, it returns an invalid handle.You can test the validity of the handle by using it in another function call.</returns>
        [DllImport(nameof(WtsApi32), SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern SafeTerminalServerHandle WTSOpenServerEx(string pServerName);

        /// <summary>
        /// Closes an open handle to a Remote Desktop Session Host (RD Session Host) server.
        /// </summary>
        /// <param name="hServer">A handle to an RD Session Host server opened by a call to the <see cref="WTSOpenServer"/> or <see cref="WTSOpenServerEx"/> function.</param>
        [DllImport(nameof(WtsApi32), SetLastError =true, CharSet = CharSet.Unicode)]
        private static extern void WTSCloseServer(IntPtr hServer);
    }
}
