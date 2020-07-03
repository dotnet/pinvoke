// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PInvoke
{
    using System.Runtime.InteropServices;

    /// <content>
    /// Contains the <see cref="ITEMIDLIST"/> nested type.
    /// </content>
    public partial class Shell32
    {
        /// <summary>
        /// Contains a list of item identifiers.
        /// This struct must *always* be handled via pointer
        /// rather than copied around because it is just the header to a native buffer.
        /// </summary>
        /// <remarks>Used by <see cref="SHGetKnownFolderIDList(System.Guid, KNOWN_FOLDER_FLAG, System.IntPtr, out ITEMIDLIST*)"/> and <see cref="SHGetFolderLocation(System.IntPtr, CSIDL, System.IntPtr, int, out ITEMIDLIST*)"/></remarks>
        public struct ITEMIDLIST
        {
            /// <summary>
            /// A list of item identifiers.
            /// </summary>
            public SHITEMID mkid;
        }
    }
}
