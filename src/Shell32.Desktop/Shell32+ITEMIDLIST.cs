// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

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
        /// </summary>
        /// <remarks>Used by <see cref="SHGetKnownFolderIDList"/> and <see cref="SHGetFolderLocation"/></remarks>
        [StructLayout(LayoutKind.Sequential)]
        public struct ITEMIDLIST
        {
            /// <summary>
            /// A list of item identifiers.
            /// </summary>
            [MarshalAs(UnmanagedType.Struct)]
            public SHITEMID mkid;
        }
    }
}