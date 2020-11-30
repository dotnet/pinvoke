// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PInvoke
{
    /// <content>
    /// Contains the <see cref="CHANGEFILTERSTRUCT"/> nested type.
    /// </content>
    public partial class User32
    {
        /// <summary>Contains extended result information obtained by calling the ChangeWindowMessageFilterEx function.</summary>
        /// <remarks>
        /// <para>Certain messages whose value is smaller than <b>WM_USER</b> are required to pass through the filter, regardless of the filter setting. There will be no effect when you attempt to use this function to allow or block such messages.</para>
        /// <para>An application may use the <a href = "https://docs.microsoft.com/windows/desktop/api/winuser/nf-winuser-changewindowmessagefilter">ChangeWindowMessageFilter</a> function to allow or block a message in a process-wide manner. If the message is allowed by either the process message filter or the window message filter, it will be delivered to the window.</para>
        /// <para>The following table lists the possible values returned in <b>ExtStatus</b>.</para>
        /// <para>This doc was truncated.</para>
        /// <para><see href = "https://docs.microsoft.com/en-us/windows/win32/api//winuser/ns-winuser-changefilterstruct#">Read more on docs.microsoft.com</see>.</para>
        /// </remarks>
        public struct CHANGEFILTERSTRUCT
        {
            /// <summary>
            /// <para>Type: <b>DWORD</b>The size of the structure, in bytes. Must be set to <c>sizeof(CHANGEFILTERSTRUCT)</c>, otherwise the function fails with <b>ERROR_INVALID_PARAMETER</b>.</para>
            /// <para><see href = "https://docs.microsoft.com/en-us/windows/win32/api//winuser/ns-winuser-changefilterstruct#members">Read more on docs.microsoft.com</see>.</para>
            /// </summary>
            public uint cbSize;

            /// <summary>
            /// <para>Type: <b>DWORD</b>If the function succeeds, this field contains one of the following values.</para>
            /// <para>This doc was truncated.</para>
            /// <para><see href = "https://docs.microsoft.com/en-us/windows/win32/api//winuser/ns-winuser-changefilterstruct#members">Read more on docs.microsoft.com</see>.</para>
            /// </summary>
            public uint ExtStatus;
        }
    }
}
