// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Runtime.InteropServices;
    using static Kernel32;

    /// <summary>
    /// Exported functions from the Userenv.dll Windows library
    /// that are available to Desktop and Store apps.
    /// </summary>
    [OfferFriendlyOverloads]
    public static partial class Userenv
    {
        /// <summary>
        /// Retrieves the environment variables for the specified user. This block can then be passed to the <see cref="CreateProcessAsUser(IntPtr, string, string, SECURITY_ATTRIBUTES*, SECURITY_ATTRIBUTES*, bool, CreateProcessFlags, void*, string, ref STARTUPINFO, out PROCESS_INFORMATION)"/> function.
        /// </summary>
        /// <param name="lpEnvironment">
        /// When this function returns, receives a pointer to the new environment block. The environment block is an array of null-terminated Unicode strings. The list ends with two nulls (\0\0).
        /// </param>
        /// <param name="hToken">
        /// Token for the user, returned from the LogonUser function. If this is a primary token, the token must have TOKEN_QUERY and TOKEN_DUPLICATE access. If the token is an impersonation token, it must have TOKEN_QUERY access. For more information, see Access Rights for Access-Token Objects.
        /// If this parameter is NULL, the returned environment block contains system variables only.
        /// </param>
        /// <param name="bInherit">
        /// Specifies whether to inherit from the current process' environment. If this value is TRUE, the process inherits the current process' environment. If this value is FALSE, the process does not inherit the current process' environment.
        /// </param>
        /// <returns>
        /// TRUE if successful; otherwise, FALSE. To get extended error information, call GetLastError.
        /// </returns>
        /// <remarks>
        /// To free the buffer when you have finished with the environment block, call the DestroyEnvironmentBlock function.
        /// If the environment block is passed to <see cref="CreateProcessAsUser(IntPtr, string, string, SECURITY_ATTRIBUTES*, SECURITY_ATTRIBUTES*, bool, CreateProcessFlags, void*, string, ref STARTUPINFO, out PROCESS_INFORMATION)"/>, you must also specify the CREATE_UNICODE_ENVIRONMENT flag.
        /// After <see cref="CreateProcessAsUser(IntPtr, string, string, SECURITY_ATTRIBUTES*, SECURITY_ATTRIBUTES*, bool, CreateProcessFlags, void*, string, ref STARTUPINFO, out PROCESS_INFORMATION)"/> has returned, the new process has a copy of the environment block, and <see cref="DestroyEnvironmentBlock(char*)"/> can be safely called.
        /// User-specific environment variables such as %USERPROFILE% are set only when the user's profile is loaded. To load a user's profile, call the LoadUserProfile function.
        /// </remarks>
        [DllImport(nameof(Userenv), SetLastError = true, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern unsafe bool CreateEnvironmentBlock(
            out char* lpEnvironment,
            SafeObjectHandle hToken,
            [MarshalAs(UnmanagedType.Bool)] bool bInherit);

        /// <summary>
        /// Frees environment variables created by the <see cref="CreateEnvironmentBlock(out char*, SafeObjectHandle, bool)"/> function.
        /// </summary>
        /// <param name="lpEnvironment">Pointer to the environment block created by <see cref="CreateEnvironmentBlock(out char*, SafeObjectHandle, bool)"/>. The environment block is an array of null-terminated Unicode strings. The list ends with two nulls (\0\0).</param>
        /// <returns>TRUE if successful; otherwise, FALSE. To get extended error information, call <see cref="GetLastError"/>.</returns>
        [DllImport(nameof(Userenv), SetLastError = true, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern unsafe bool DestroyEnvironmentBlock(
            char* lpEnvironment);
    }
}
