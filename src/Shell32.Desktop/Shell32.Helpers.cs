// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Runtime.InteropServices;

    /// <content>
    /// Methods and nested types that are not strictly P/Invokes but provide
    /// a slightly higher level of functionality to ease calling into native code.
    /// </content>
    public static partial class Shell32
    {
        /// <summary>
        /// Gets the path of a folder identified by a CSIDL value.
        /// </summary>
        /// <param name="folder">
        /// A <see cref="CSIDL"/> value that identifies the folder whose path is to be retrieved.
        /// Only real folders are valid. If a virtual folder is specified, this function fails.
        /// You can force creation of a folder by combining the folder's <see cref="CSIDL"/> with CSIDL_FLAG_CREATE.
        /// </param>
        /// <param name="hToken">
        /// An access token that can be used to represent a particular user. The calling process is responsible for correct impersonation when hToken is non-NULL.
        /// The calling process must have appropriate security privileges for the particular user, including TOKEN_QUERY and TOKEN_IMPERSONATE, and the user's registry hive must be currently mounted.
        /// Assigning the hToken parameter a value of -1 indicates the Default User.
        /// Microsoft Windows 2000 and earlier: Always set this parameter to NULL.
        /// Windows XP and later: This parameter is usually set to NULL, but you might need to assign a non-NULL value to hToken for those folders
        ///     that can have multiple users but are treated as belonging to a single user.The most commonly used folder of this type is Documents.
        /// </param>
        /// <param name="flags">
        /// Flags that specify the path to be returned. This value is used in cases where the folder associated with a <see cref="KNOWNFOLDERID"/> (or <see cref="CSIDL"/>)
        /// can be moved, renamed, redirected, or roamed across languages by a user or administrator.
        /// The default value of the folder, which is the location of the folder if a user or administrator had not redirected it elsewhere,
        /// is retrieved by specifying the <see cref="SHGetFolderPathFlags.SHGFP_TYPE_DEFAULT"/> flag.
        /// This value can be used to implement a "restore defaults" feature for a known folder.
        /// </param>
        /// <returns>
        /// The returned path does not include a trailing backslash. For example, "C:\Users" is returned rather than "C:\Users\".
        /// </returns>
        /// <remarks>
        /// As of Windows Vista, this function is merely a wrapper for <see cref="SHGetKnownFolderPath(Guid, KNOWN_FOLDER_FLAG, IntPtr, out char*)"/>.
        /// The returned path does not include a trailing backslash.
        /// For example, "C:\Users" is returned rather than "C:\Users\".
        /// </remarks>
        [Obsolete("As of Windows Vista, this function is merely a wrapper for " + nameof(SHGetKnownFolderPath) + ".")]
        public static unsafe string SHGetFolderPath(CSIDL folder, IntPtr hToken = default(IntPtr), SHGetFolderPathFlags flags = SHGetFolderPathFlags.SHGFP_TYPE_CURRENT)
        {
            char* pszPath = stackalloc char[Kernel32.MAX_PATH + 1];
#pragma warning disable CS0618 // Type or member is obsolete
            SHGetFolderPath(IntPtr.Zero, folder, hToken, flags, pszPath).ThrowOnFailure();
#pragma warning restore CS0618 // Type or member is obsolete

            return new string(pszPath);
        }

        /// <summary>
        /// Gets the path of a folder identified by a CSIDL value.
        /// </summary>
        /// <param name="rfid">
        /// A <see cref="Guid"/> value that identifies the folder whose path is to be retrieved.
        /// As defined in <see cref="KNOWNFOLDERID"/>.
        /// </param>
        /// <param name="dwFlags">Flags that specify special retrieval options. This value can be 0; otherwise, one or more of the <see cref="KNOWN_FOLDER_FLAG"/> values.</param>
        /// <param name="hToken">
        /// An access token that represents a particular user. If this parameter is NULL, which is the most common usage, the function requests the known folder for the current user.
        /// Assigning the hToken parameter a value of -1 indicates the Default User.
        /// Microsoft Windows 2000 and earlier: Always set this parameter to NULL.
        /// Windows XP and later: This parameter is usually set to NULL, but you might need to assign a non-NULL value to hToken for those folders that can have multiple users but are treated as belonging to a single user.The most commonly used folder of this type is Documents.
        /// </param>
        /// <returns>
        /// The returned path does not include a trailing backslash. For example, "C:\Users" is returned rather than "C:\Users\".
        /// </returns>
        /// <remarks>
        /// As of Windows Vista, this function is merely a wrapper for <see cref="SHGetKnownFolderPath(Guid, KNOWN_FOLDER_FLAG, IntPtr, out char*)"/>.
        /// The returned path does not include a trailing backslash.
        /// For example, "C:\Users" is returned rather than "C:\Users\".
        /// </remarks>
        public static unsafe string SHGetKnownFolderPath(Guid rfid, KNOWN_FOLDER_FLAG dwFlags = KNOWN_FOLDER_FLAG.None, IntPtr hToken = default(IntPtr))
        {
            char* pszPath;
            SHGetKnownFolderPath(rfid, dwFlags, hToken, out pszPath).ThrowOnFailure();

            try
            {
                return new string(pszPath);
            }
            finally
            {
                Marshal.FreeCoTaskMem((IntPtr)pszPath);
            }
        }

        public static unsafe string SHGetPathFromIDList(ITEMIDLIST* pidl)
        {
            char* pszPath = stackalloc char[Kernel32.MAX_PATH + 1];
            if (!SHGetPathFromIDList(pidl, pszPath))
            {
                throw new ArgumentException();
            }

            return new string(pszPath);
        }
    }
}
