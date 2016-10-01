// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using static Kernel32;
    using System;
    using System.Runtime.InteropServices;

    /// <content>
    /// Exported functions from the WtsApi32.dll Windows library
    /// that are available to Desktop apps only.
    /// </content>
    public static partial class WtsApi32
    {
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
    }
}
