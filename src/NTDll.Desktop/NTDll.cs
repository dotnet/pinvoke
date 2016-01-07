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
        public static extern Win32ErrorCode RtlNtStatusToDosError(NTStatus Status);
    }
}
