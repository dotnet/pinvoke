// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    /// <content>
    /// Contains the <see cref="SHGetFolderPathFlags"/> nested type.
    /// </content>
    public partial class Shell32
    {
        /// <summary>Flags that specify the path to be returned. Used in cases where the folder associated with a <see cref="KNOWNFOLDERID"/> (or CSIDL) can be moved, renamed, redirected, or roamed across languages by a user or administrator.</summary>
        public enum SHGetFolderPathFlags
        {
            /// <summary>Retrieve the folder's current path.</summary>
            /// <remarks>
            /// The known folder system that underlies <see cref="SHGetFolderPath(System.IntPtr, CSIDL, System.IntPtr, SHGetFolderPathFlags, char*)"/> allows users or administrators to redirect a known folder to a location that suits their needs.
            /// This is achieved by calling IKnownFolderManager::Redirect, which sets the "current" value of the folder associated with the SHGFP_TYPE_CURRENT flag
            /// </remarks>
            SHGFP_TYPE_CURRENT = 0,

            /// <summary>Retrieve the folder's default path.</summary>
            /// <remarks>
            /// The default value of the folder, which is the location of the folder if a user or administrator had not redirected it elsewhere,
            /// is retrieved by specifying the SHGFP_TYPE_DEFAULT flag. This value can be used to implement a "restore defaults" feature for a known folder.
            /// </remarks>
            SHGFP_TYPE_DEFAULT = 1
        }
    }
}