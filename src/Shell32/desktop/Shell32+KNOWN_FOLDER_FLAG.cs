// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;

    /// <content>
    /// Contains the <see cref="KNOWN_FOLDER_FLAG"/> nested type.
    /// </content>
    public partial class Shell32
    {
        /// <summary>Specify special retrieval options for known folders.</summary>
        /// <remarks>These values supersede CSIDL values, which have parallel meanings.</remarks>
        [Flags]
        public enum KNOWN_FOLDER_FLAG : uint
        {
            /// <summary>
            /// Define no flags.
            /// </summary>
            None = 0x00000000,

            /// <summary>
            /// Build a simple IDList (PIDL) This value can be used when you want to retrieve the file system path
            /// but do not specify this value if you are retrieving the localized display name of the folder because it might not resolve correctly.
            /// </summary>
            KF_FLAG_SIMPLE_IDLIST = 0x00000100,

            /// <summary>
            /// Gets the folder's default path independent of the current location of its parent. <see cref="KF_FLAG_DEFAULT_PATH"/> must also be set.
            /// </summary>
            KF_FLAG_NOT_PARENT_RELATIVE = 0x00000200,

            /// <summary>
            /// Gets the default path for a known folder. If this flag is not set, the function retrieves the current—and possibly redirected—path of the folder.
            /// The execution of this flag includes a verification of the folder's existence unless <see cref="KF_FLAG_DONT_VERIFY"/> is set.
            /// </summary>
            KF_FLAG_DEFAULT_PATH = 0x00000400,

            /// <summary>
            /// Initializes the folder using its Desktop.ini settings. If the folder cannot be initialized, the function returns a failure code and no path is returned.
            /// This flag should always be combined with <see cref="KF_FLAG_CREATE"/>.
            /// </summary>
            /// <remarks>If the folder is located on a network, the function might take a longer time to execute.</remarks>
            KF_FLAG_INIT = 0x00000800,

            /// <summary>
            /// Gets the true system path for the folder, free of any aliased placeholders such as %USERPROFILE%, returned by SHGetKnownFolderIDList and IKnownFolder::GetIDList.
            /// This flag has no effect on paths returned by <see cref="SHGetKnownFolderPath(Guid, KNOWN_FOLDER_FLAG, IntPtr, out char*)"/> and IKnownFolder::GetPath.
            /// By default, known folder retrieval functions and methods return the aliased path if an alias exists.
            /// </summary>
            KF_FLAG_NO_ALIAS = 0x00001000,

            /// <summary>
            /// Stores the full path in the registry without using environment strings. If this flag is not set, portions of the path may be represented by environment strings
            /// such as %USERPROFILE%. This flag can only be used with SHSetKnownFolderPath and IKnownFolder::SetPath.
            /// </summary>
            KF_FLAG_DONT_UNEXPAND = 0x00002000,

            /// <summary>
            /// Do not verify the folder's existence before attempting to retrieve the path or IDList. If this flag is not set,
            /// an attempt is made to verify that the folder is truly present at the path. If that verification fails due to the folder being absent or inaccessible,
            /// the function returns a failure code and no path is returned.
            /// </summary>
            /// <remarks>If the folder is located on a network, the function might take a longer time to execute. Setting this flag can reduce that lag time.</remarks>
            KF_FLAG_DONT_VERIFY = 0x00004000,

            /// <summary>
            /// Forces the creation of the specified folder if that folder does not already exist. The security provisions predefined for that folder are applied.
            /// If the folder does not exist and cannot be created, the function returns a failure code and no path is returned.
            /// </summary>
            /// <remarks>This value can be used only with the following functions and methods: <see cref="SHGetKnownFolderPath(Guid, KNOWN_FOLDER_FLAG, IntPtr, out char*)"/>, SHGetKnownFolderIDList, IKnownFolder::GetIDList, IKnownFolder::GetPath, IKnownFolder::GetShellItem</remarks>
            KF_FLAG_CREATE = 0x00008000,

            /// <summary>
            /// When running inside an app container, or when providing an app container token, this flag prevents redirection to app container folders.
            /// Instead, it retrieves the path that would be returned where it not running inside an app container.
            /// </summary>
            /// <remarks>Introduced in Windows 7</remarks>
            KF_FLAG_NO_APPCONTAINER_REDIRECTION = 0x00010000,

            /// <summary>
            /// Return only aliased PIDLs. Do not use the file system path.
            /// </summary>
            /// <remarks>Introduced in Windows 7</remarks>
            KF_FLAG_ALIAS_ONLY = 0x80000000
        }
    }
}