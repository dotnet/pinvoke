// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using static Kernel32;
    using System;
    using System.Runtime.InteropServices;
    using System.Collections.Generic;

    /// <content>
    /// Exported functions from the WtsApi32.dll Windows library
    /// that are available to Desktop apps only.
    /// </content>
    public static partial class WtsApi32
    {
        public static IntPtr WTS_CURRENT_SERVER_HANDLE = IntPtr.Zero;
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
        /// that you must call the CloseHandle function to close this handle.</param>
        /// <returns>f the function succeeds, the return value is a nonzero value, and the phToken parameter points to the primary 
        /// token of the user.</returns>
        [DllImport(nameof(WtsApi32), SetLastError = true)]
        public static extern bool WTSQueryUserToken(int SessionId, out SafeObjectHandle phToken);

        /// <summary>
        /// Frees memory allocated by a Remote Desktop Services function.
        /// </summary>
        /// <param name="pMemory">Pointer to the memory to free.</param>
        [DllImport(nameof(WtsApi32))]
        public static extern void WTSFreeMemory(IntPtr pMemory);

        /// <summary>
        /// Retrieves a list of sessions on a Remote Desktop Session Host (RD Session Host) server.
        /// </summary>
        /// <param name="hServer">A handle to the RD Session Host server.
        /// You can use the <see cref="WTSOpenServer"/> or <see cref="WTSOpenServerEx"/> functions to retrieve a handle to a specific 
        /// server, or <see cref="WTS_CURRENT_SERVER_HANDLE"/> to use the RD Session Host server that hosts your application.</param>
        /// <param name="reserved">This parameter is reserved. It must be zero.</param>
        /// <param name="version">The version of the enumeration request. This parameter must be 1.</param>
        /// <param name="ppSessionInfo">A pointer to an array of <see cref="WTS_SESSION_INFO"/> structures that represent the retrieved 
        /// sessions. To free the returned buffer, call the <see cref="WTSFreeMemory"/> function.</param>
        /// <param name="pSessionInfoCount">A pointer to the number of WTS_SESSION_INFO structures returned in the ppSessionInfo parameter.</param>
        /// <returns>Returns zero if this function fails. If this function succeeds, a nonzero value is returned.</returns>
        [DllImport(nameof(WtsApi32), SetLastError = true, CharSet = CharSet.Auto)]
        public static extern bool WTSEnumerateSessions(
            IntPtr hServer,
            [MarshalAs(UnmanagedType.U4)] int reserved,
            [MarshalAs(UnmanagedType.U4)] int version,
            ref IntPtr ppSessionInfo,
            [MarshalAs(UnmanagedType.U4)] ref int pSessionInfoCount
            );

        /// <summary>
        /// Retrieves a list of sessions on a Remote Desktop Session Host (RD Session Host) server.
        /// </summary>
        /// <param name="hServer">A handle to the RD Session Host server.
        /// You can use the <see cref="WTSOpenServer"/> or <see cref="WTSOpenServerEx"/> functions to retrieve a handle to a specific 
        /// server, or <see cref="WTS_CURRENT_SERVER_HANDLE"/> to use the RD Session Host server that hosts your application.</param>
        /// <param name="reserved">This parameter is reserved. It must be zero.</param>
        /// <param name="version">The version of the enumeration request. This parameter must be 1.</param>
        /// <param name="ppSessionInfo">A pointer to <see cref="IEnumerable&lt;WTS_SESSION_INFO&gt;"/> structures that represent the retrieved 
        /// sessions. Note, that returned object doesn't know overall count of sessions, and always return true for MoveNext, use it in pair 
        /// with pSessionInfoCount parameter</param>
        /// <param name="pSessionInfoCount">A pointer to the number of WTS_SESSION_INFO structures returned in the ppSessionInfo parameter.</param>
        /// <returns>Returns zero if this function fails. If this function succeeds, a nonzero value is returned.</returns>
        [DllImport(nameof(WtsApi32), SetLastError = true, CharSet = CharSet.Auto)]
        public static extern bool WTSEnumerateSessions(
            IntPtr hServer,
            [MarshalAs(UnmanagedType.U4)] int reserved,
            [MarshalAs(UnmanagedType.U4)] int version,
            ref WtsSafeMemoryGuard<WTS_SESSION_INFO> ppSessionInfo,
            [MarshalAs(UnmanagedType.U4)] ref int pSessionInfoCount
            );
    }
}
