// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Runtime.InteropServices;

    /// <content>
    /// Exported functions from the NetApi32.dll Windows library
    /// that are available to Desktop apps only.
    /// </content>
    public static partial class NetApi32
    {
        /// <summary>
        /// Value to be used with APIs which have a "preferred maximum length"
        /// parameter.  This value indicates that the API should just allocate
        /// "as much as it takes."
        /// </summary>
        public const uint MAX_PREFERRED_LENGTH = unchecked((uint)-1);

        /// <summary>
        /// The NetUserEnum function retrieves information about all user accounts on a server.
        /// </summary>
        /// <param name="servername">A pointer to a constant string that specifies the DNS or NetBIOS name of the remote server on which the function is to execute. If this parameter is NULL, the local computer is used.</param>
        /// <param name="level">Specifies the information level of the data.</param>
        /// <param name="filter">
        /// A value that specifies the user account types to be included in the enumeration. A value of zero indicates that all normal user, trust data, and machine account data should be included.
        /// This parameter can also be a combination of values.
        /// </param>
        /// <param name="bufptr">
        /// A pointer to the buffer that receives the data. The format of this data depends on the value of the <paramref name="level"/> parameter.
        /// The buffer for this data is allocated by the system and the application must call the <see cref="NetApiBufferFree(void*)"/> function to free the allocated memory when the data returned is no longer needed. Note that you must free the buffer even if the NetUserEnum function fails with <see cref="Win32ErrorCode.ERROR_MORE_DATA"/>.
        /// </param>
        /// <param name="prefmaxlen">
        /// The preferred maximum length, in bytes, of the returned data. If you specify <see cref="MAX_PREFERRED_LENGTH"/>, the NetUserEnum function allocates the amount of memory required for the data. If you specify another value in this parameter, it can restrict the number of bytes that the function returns. If the buffer size is insufficient to hold all entries, the function returns <see cref="Win32ErrorCode.ERROR_MORE_DATA"/>. For more information, see Network Management Function Buffers and Network Management Function Buffer Lengths.
        /// </param>
        /// <param name="entriesread">
        /// A pointer to a value that receives the count of elements actually enumerated.
        /// </param>
        /// <param name="totalentries">
        /// A pointer to a value that receives the total number of entries that could have been enumerated from the current resume position. Note that applications should consider this value only as a hint. If your application is communicating with a Windows 2000 or later domain controller, you should consider using the ADSI LDAP Provider to retrieve this type of data more efficiently. The ADSI LDAP Provider implements a set of ADSI objects that support various ADSI interfaces. For more information, see ADSI Service Providers.
        /// </param>
        /// <param name="resume_handle">
        /// A pointer to a value that contains a resume handle which is used to continue an existing user search. The handle should be zero on the first call and left unchanged for subsequent calls. If this parameter is NULL, then no resume handle is stored.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="Win32ErrorCode.NERR_Success"/>.
        /// If the function fails, the return value can be one of the following error codes:
        /// <see cref="Win32ErrorCode.ERROR_ACCESS_DENIED"/>
        /// <see cref="Win32ErrorCode.ERROR_INVALID_LEVEL"/>
        /// <see cref="Win32ErrorCode.NERR_BufTooSmall"/>
        /// <see cref="Win32ErrorCode.NERR_InvalidComputer"/>
        /// <see cref="Win32ErrorCode.ERROR_MORE_DATA"/>
        /// </returns>
        [DllImport(nameof(NetApi32), CharSet = CharSet.Unicode)]
        public static extern unsafe Win32ErrorCode NetUserEnum(
            string servername,
            NetUserEnumLevel level,
            NetUserEnumFilter filter,
            [Friendly(FriendlyFlags.Array)] byte* bufptr,
            uint prefmaxlen,
            out uint entriesread,
            out uint totalentries,
            ref uint resume_handle);

        /// <summary>
        /// The NetApiBufferFree function frees the memory that the NetApiBufferAllocate function allocates. Applications should also call NetApiBufferFree to free the memory that other network management functions use internally to return information.
        /// </summary>
        /// <param name="Buffer">A pointer to a buffer returned previously by another network management function or memory allocated by calling the <see cref="NetApiBufferAllocate(int, out void*)"/> function.</param>
        /// <returns>
        /// If the function succeeds, the return value is NERR_Success.
        /// If the function fails, the return value is a system error code. For a list of error codes, see System Error Codes.
        /// </returns>
        [DllImport(nameof(NetApi32))]
        public static extern unsafe Win32ErrorCode NetApiBufferFree(void* Buffer);

        /// <summary>
        /// The NetApiBufferAllocate function allocates memory from the heap. Use this function only when compatibility with the <see cref="NetApiBufferFree(void*)"/> function is required. Otherwise, use the memory management functions.
        /// </summary>
        /// <param name="ByteCount">Number of bytes to be allocated.</param>
        /// <param name="Buffer">Receives a pointer to the allocated buffer.</param>
        /// <returns>
        /// If the function succeeds, the return value is NERR_Success.
        /// If the function fails, the return value is a system error code. For a list of error codes, see System Error Codes.
        /// </returns>
        [DllImport(nameof(NetApi32))]
        public static extern unsafe Win32ErrorCode NetApiBufferAllocate(
            int ByteCount,
            out void* Buffer);
    }
}
