// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Runtime.InteropServices;

    /// <content>
    /// Exported functions from the NTDll.dll Windows library
    /// that are available to Desktop apps only.
    /// </content>
    public static partial class NTDll
    {
        /// <summary>
        /// Converts the specified NTSTATUS code to its equivalent system error code.
        /// </summary>
        /// <param name="Status">The NTSTATUS code to be converted.</param>
        /// <returns>The function returns the corresponding system error code.</returns>
        /// <remarks>
        /// There is no function that provides the inverse functionality of RtlNtStatusToDosError, which would convert a system error code to its corresponding NTSTATUS code.
        /// ERROR_MR_MID_NOT_FOUND is returned when the specified NTSTATUS code does not have a corresponding system error code.
        /// </remarks>
        [DllImport(nameof(NTDll))]
        public static extern Win32ErrorCode RtlNtStatusToDosError(NTSTATUS Status);

        /// <summary>
        /// The NtOpenSection routine opens a handle for an existing section object.
        /// </summary>
        /// <param name="sectionHandle">Pointer to a HANDLE variable that receives a handle to the section object.</param><param name="desiredAccess">Specifies an ACCESS_MASK value that determines the requested access to the object.</param><param name="objectAttributes">Pointer to an OBJECT_ATTRIBUTES structure that specifies the object name and other attributes. Use InitializeObjectAttributes to initialize this structure.</param>
        /// <returns>
        /// Returns <see cref="NTSTATUS.Code.STATUS_SUCCESS"/> on success, or the appropriate <see cref="NTSTATUS"/> error code on failure.
        /// </returns>
        [DllImport(nameof(NTDll), CharSet = CharSet.Unicode)]
        public static extern unsafe NTSTATUS NtOpenSection(
            out SafeNTObjectHandle sectionHandle,
            Kernel32.ACCESS_MASK desiredAccess,
            [Friendly(FriendlyFlags.In)] OBJECT_ATTRIBUTES* objectAttributes);

        /// <summary>
        /// The NtClose routine closes an object handle.
        /// </summary>
        /// <param name="handle">Handle to an object of any type.</param>
        /// <returns>
        /// Returns <see cref="NTSTATUS.Code.STATUS_SUCCESS"/> on success, or the appropriate <see cref="NTSTATUS"/> error code on failure.
        /// </returns>
        [DllImport(nameof(NTDll))]
        private static extern NTSTATUS NtClose(IntPtr handle);
    }
}
