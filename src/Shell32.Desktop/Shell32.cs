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
        /// The returned path does not include a trailing backslash. For example, "C:\Users" is returned rather than "C:\Users\".
        /// </param>
        /// <returns>If this function succeeds, it returns <see cref="HResult.Code.S_OK"/>. Otherwise, it returns an <see cref="HResult"/> error code.</returns>
        /// <remarks>
        /// As of Windows Vista, this function is merely a wrapper for <see cref="SHGetKnownFolderPath(Guid, KNOWN_FOLDER_FLAG, IntPtr, out char*)"/>.
        /// The returned path does not include a trailing backslash.
        /// For example, "C:\Users" is returned rather than "C:\Users\".
        /// </remarks>
        [Obsolete("As of Windows Vista, this function is merely a wrapper for " + nameof(SHGetKnownFolderPath) + ".")]
        [DllImport(nameof(Shell32), CharSet = CharSet.Unicode)]
        public static extern unsafe HResult SHGetFolderPath(
            IntPtr hwndOwner,
            CSIDL nFolder,
            IntPtr hToken,
            SHGetFolderPathFlags dwFlags,
            [Friendly(FriendlyFlags.Array)] char* pszPath);

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
        /// <param name="ppszPath">
        /// When this method returns, contains the address of a pointer to a null-terminated Unicode string that specifies the path of the known folder.
        /// The calling process is responsible for freeing this resource once it is no longer needed by calling <see cref="Marshal.FreeCoTaskMem(IntPtr)"/>.
        /// The returned path does not include a trailing backslash. For example, "C:\Users" is returned rather than "C:\Users\".
        /// </param>
        /// <returns>If this function succeeds, it returns <see cref="HResult.Code.S_OK"/>. Otherwise, it returns an <see cref="HResult"/> error code.</returns>
        /// <remarks>
        /// As of Windows Vista, this function is merely a wrapper for <see cref="SHGetKnownFolderPath(Guid, KNOWN_FOLDER_FLAG, IntPtr, out char*)"/>.
        /// The returned path does not include a trailing backslash.
        /// For example, "C:\Users" is returned rather than "C:\Users\".
        /// </remarks>
        [DllImport(nameof(Shell32), CharSet = CharSet.Unicode)]
        public static extern unsafe HResult SHGetKnownFolderPath(
            [MarshalAs(UnmanagedType.LPStruct)] Guid rfid,
            KNOWN_FOLDER_FLAG dwFlags,
            IntPtr hToken,
            out char* ppszPath); // Do NOT use [Friendly(Array)] here, because an "out byte[]" overload would produce a memory leak, since freeing memory would require a pointer no one has.

        /// <summary>
        /// Retrieves the path of a folder as an ITEMIDLIST structure.
        /// </summary>
        /// <param name="hwndOwner">Reserved.</param>
        /// <param name="nFolder">A <see cref="CSIDL"/> value that identifies the folder to be located. The folders associated with the CSIDLs might not exist on a particular system.</param>
        /// <param name="hToken">
        /// An access token that can be used to represent a particular user. It is usually set to NULL, but it may be needed when there are multiple users for those folders that are treated as belonging to a single user. The most commonly used folder of this type is My Documents. The calling application is responsible for correct impersonation when hToken is non-NULL. It must have appropriate security privileges for the particular user, and the user's registry hive must be currently mounted. See Access Control for further discussion of access control issues.
        /// Assigning the hToken parameter a value of -1 indicates the Default User. This allows clients of SHGetFolderLocation to find folder locations (such as the Desktop folder) for the Default User. The Default User user profile is duplicated when any new user account is created, and includes special folders such as My Documents and Desktop. Any items added to the Default User folder also appear in any new user account.
        /// </param>
        /// <param name="dwReserved">Undocumented.</param>
        /// <param name="pidl">The address of a pointer to an item identifier list structure that specifies the folder's location relative to the root of the namespace (the desktop). The ppidl parameter is set to NULL on failure. The calling application is responsible for freeing this resource by calling <see cref="ILFree(void*)"/>.</param>
        /// <returns>
        /// Returns S_OK if successful, or an error value otherwise, including the following:
        /// <see cref="PInvokeExtensions.ToHResult(Win32ErrorCode)"/>(<see cref="Win32ErrorCode.ERROR_FILE_NOT_FOUND"/>)
        /// <see cref="HResult.Code.E_INVALIDARG"/>
        /// </returns>
        [DllImport(nameof(Shell32))]
        [Obsolete("As of Windows Vista, this function is merely a wrapper for " + nameof(SHGetKnownFolderIDList) + ".")]
        public static extern unsafe HResult SHGetFolderLocation(
            IntPtr hwndOwner,
            CSIDL nFolder,
            IntPtr hToken,
            int dwReserved,
            out ITEMIDLIST* pidl);

        /// <summary>
        /// Retrieves the path of a known folder as an ITEMIDLIST structure.
        /// </summary>
        /// <param name="rfid">A reference to the <see cref="KNOWNFOLDERID"/> that identifies the folder. The folders associated with the known folder IDs might not exist on a particular system.</param>
        /// <param name="dwFlags">Flags that specify special retrieval options. This value can be 0; otherwise, it is one or more of the <see cref="KNOWN_FOLDER_FLAG"/> values.</param>
        /// <param name="hToken">
        /// An access token used to represent a particular user. This parameter is usually set to NULL, in which case the function tries to access the current user's instance of the folder. However, you may need to assign a value to <paramref name="hToken"/> for those folders that can have multiple users but are treated as belonging to a single user. The most commonly used folder of this type is Documents.
        /// The calling application is responsible for correct impersonation when <paramref name="hToken"/> is non-null. It must have appropriate security privileges for the particular user, including TOKEN_QUERY and TOKEN_IMPERSONATE, and the user's registry hive must be currently mounted. See Access Control for further discussion of access control issues.
        /// Assigning the <paramref name="hToken"/> parameter a value of -1 indicates the Default User. This allows clients of SHGetKnownFolderIDList to find folder locations (such as the Desktop folder) for the Default User. The Default User user profile is duplicated when any new user account is created, and includes special folders such as Documents and Desktop. Any items added to the Default User folder also appear in any new user account. Note that access to the Default User folders requires administrator privileges.
        /// </param>
        /// <param name="pidl">When this method returns, contains a pointer to the PIDL of the folder. This parameter is passed uninitialized. The caller is responsible for freeing the returned PIDL when it is no longer needed by calling <see cref="ILFree(void*)"/>.</param>
        /// <returns>
        /// Returns S_OK if successful, or an error value otherwise, including the following:
        /// <see cref="HResult.Code.E_INVALIDARG"/>
        /// Among other things, this value can indicate that the rfid parameter references a KNOWNFOLDERID that is not present on the system. Not all KNOWNFOLDERID values are present on all systems. Use IKnownFolderManager::GetFolderIds to retrieve the set of KNOWNFOLDERID values for the current system.
        /// </returns>
        [DllImport(nameof(Shell32))]
        public static extern unsafe HResult SHGetKnownFolderIDList(
            [MarshalAs(UnmanagedType.LPStruct)] Guid rfid,
            KNOWN_FOLDER_FLAG dwFlags,
            IntPtr hToken,
            out ITEMIDLIST* pidl);

        /// <summary>
        /// Converts an item identifier list to a file system path.
        /// </summary>
        /// <param name="pidl">The address of an item identifier list that specifies a file or directory location relative to the root of the namespace (the desktop).</param>
        /// <param name="pszPath">The address of a buffer to receive the file system path. This buffer must be at least MAX_PATH characters in size.</param>
        /// <returns>Returns TRUE if successful; otherwise, FALSE.</returns>
        [DllImport(nameof(Shell32), CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern unsafe bool SHGetPathFromIDList(
            ITEMIDLIST* pidl,
            [Friendly(FriendlyFlags.Array)] char* pszPath);

        /// <summary>
        /// Frees an <see cref="ITEMIDLIST"/> structure allocated by the Shell.
        /// </summary>
        /// <param name="pidl">A pointer to the <see cref="ITEMIDLIST"/> structure to be freed. This parameter can be NULL.</param>
        /// <remarks>
        /// <see cref="ILFree(void*)"/> is often used with <see cref="ITEMIDLIST"/> structures allocated by one of the other IL functions, but it can be used to free any such structure returned by the Shell—for example, the <see cref="ITEMIDLIST"/> structure returned by SHBrowseForFolder or used in a call to <see cref="SHGetFolderLocation(IntPtr, CSIDL, IntPtr, int, out ITEMIDLIST*)"/>.
        /// </remarks>
        [DllImport(nameof(Shell32))]
        public static extern unsafe void ILFree(void* pidl);
    }
}
