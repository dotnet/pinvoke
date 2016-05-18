// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Runtime.InteropServices;

    /// <content>
    /// Exported functions from the Shell32.dll Windows library
    /// that are available to Desktop apps only.
    /// </content>
    public static partial class Shell32
    {
        /// <summary>
        /// Gets the path of a folder identified by a CSIDL value.
        /// </summary>
        /// <param name="hwndOwner">Reserved. Pass IntPtr.Zero</param>
        /// <param name="nFolder">
        /// A <see cref="CSIDL"/> value that identifies the folder whose path is to be retrieved.
        /// Only real folders are valid. If a virtual folder is specified, this function fails.
        /// You can force creation of a folder by combining the folder's <see cref="CSIDL"/> with CSIDL_FLAG_CREATE.
        /// </param>
        /// <param name="hToken">
        /// An access token that can be used to represent a particular user. The calling process is responsible for correct impersonation when hToken is non-NULL.
        /// The calling process must have appropriate security privileges for the particular user, including TOKEN_QUERY and TOKEN_IMPERSONATE, and the user's registry hive must be currently mounted.
        /// Assigning the hToken parameter a value of -1 indicates the Default User.
        /// 
        /// Microsoft Windows 2000 and earlier: Always set this parameter to NULL.
        /// Windows XP and later: This parameter is usually set to NULL, but you might need to assign a non-NULL value to hToken for those folders
        ///     that can have multiple users but are treated as belonging to a single user.The most commonly used folder of this type is Documents.
        /// </param>
        /// <param name="dwFlags">
        /// Flags that specify the path to be returned. This value is used in cases where the folder associated with a <see cref="KNOWNFOLDERID"/> (or <see cref="CSIDL"/>)
        /// can be moved, renamed, redirected, or roamed across languages by a user or administrator.
        /// The default value of the folder, which is the location of the folder if a user or administrator had not redirected it elsewhere,
        /// is retrieved by specifying the <see cref="SHGetFolderPathFlags.SHGFP_TYPE_DEFAULT"/> flag.
        /// This value can be used to implement a "restore defaults" feature for a known folder.
        /// </param>
        /// <param name="pszPath">
        /// A pointer to a null-terminated string of length MAX_PATH which will receive the path.
        /// If an error occurs or <see cref="HResult.Code.S_FALSE"/> is returned, this string will be empty.
        /// </param>
        /// <returns>If this function succeeds, it returns <see cref="HResult.Code.S_OK"/>. Otherwise, it returns an <see cref="HResult"/> error code.</returns>
        /// <remarks>
        /// As of Windows Vista, this function is merely a wrapper for <see cref="SHGetKnownFolderPath"/>.
        /// The returned path does not include a trailing backslash.
        /// For example, "C:\Users" is returned rather than "C:\Users\".
        /// </remarks>
        [Obsolete("As of Windows Vista, this function is merely a wrapper for SHGetKnownFolderPath.")]
        [DllImport(nameof(Shell32), SetLastError = true)]
        public static extern unsafe HResult SHGetFolderPath(
            IntPtr hwndOwner,
            CSIDL nFolder,
            IntPtr hToken,
            SHGetFolderPathFlags dwFlags,
            out IntPtr pszPath);

        /// <summary>
        /// Gets the path of a folder identified by a CSIDL value.
        /// </summary>
        /// <param name="rfid">
        /// A <see cref="Guid"/> value that identifies the folder whose path is to be retrieved.
        /// </param>
        /// <param name="dwFlags">Flags that specify special retrieval options. This value can be 0; otherwise, one or more of the <see cref="KNOWN_FOLDER_FLAG"/> values.</param>
        /// <param name="hToken">
        /// An access token that represents a particular user. If this parameter is NULL, which is the most common usage, the function requests the known folder for the current user.
        /// Assigning the hToken parameter a value of -1 indicates the Default User.
        /// 
        /// Microsoft Windows 2000 and earlier: Always set this parameter to NULL.
        /// Windows XP and later: This parameter is usually set to NULL, but you might need to assign a non-NULL value to hToken for those folders that can have multiple users but are treated as belonging to a single user.The most commonly used folder of this type is Documents.
        /// </param>
        /// <param name="pszPath">
        /// A pointer to a null-terminated string of length MAX_PATH which will receive the path.
        /// If an error occurs or <see cref="HResult.Code.S_FALSE"/> is returned, this string will be empty.
        /// </param>
        /// <returns>If this function succeeds, it returns <see cref="HResult.Code.S_OK"/>. Otherwise, it returns an <see cref="HResult"/> error code.</returns>
        /// <remarks>
        /// As of Windows Vista, this function is merely a wrapper for <see cref="SHGetKnownFolderPath"/>.
        /// The returned path does not include a trailing backslash.
        /// For example, "C:\Users" is returned rather than "C:\Users\".
        /// </remarks>
        [DllImport(nameof(Shell32), SetLastError = true)]
        public static extern unsafe HResult SHGetKnownFolderPath(
            [MarshalAs(UnmanagedType.LPStruct)] Guid rfid,
            KNOWN_FOLDER_FLAG dwFlags,
            IntPtr hToken,
            out IntPtr pszPath);

        [DllImport(nameof(Shell32), SetLastError = true)]
        [Obsolete("As of Windows Vista, this function is merely a wrapper for SHGetKnownFolderIDList")]
        public static extern unsafe HResult SHGetFolderLocation(
            IntPtr hwndOwner,
            CSIDL nFolder,
            IntPtr hToken,
            int dwReserved,
            out IntPtr pidl);

        [DllImport(nameof(Shell32), SetLastError = true)]
        public static extern unsafe HResult SHGetKnownFolderIDList(
            [MarshalAs(UnmanagedType.LPStruct)] Guid rfid,
            KNOWN_FOLDER_FLAG dwFlags,
            IntPtr hToken,
            out IntPtr pidl);

        [DllImport(nameof(Shell32), SetLastError = true, CharSet = CharSet.Auto)]
        public static extern unsafe bool SHGetPathFromIDList(
            IntPtr pidl,
            [Friendly(FriendlyFlags.Array)] char* pszPath);
    }
}
