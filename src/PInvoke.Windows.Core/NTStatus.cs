// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    /// <summary>
    /// Win32 return error codes.
    /// </summary>
    /// <remarks>
    /// This values come from https://msdn.microsoft.com/en-us/library/cc704588.aspx
    /// </remarks>
    public enum NTStatus : uint
    {
        /// <summary>
        /// The operation completed successfully.
        /// </summary>
        Success = 0,

        /// <summary>
        /// An invalid HANDLE was specified.
        /// </summary>
        InvalidHandle = 0xC0000008,

        /// <summary>
        /// An invalid parameter was passed to a service or function.
        /// </summary>
        InvalidParameter = 0xC000000D,

        /// <summary>
        /// The object was not found.
        /// </summary>
        NotFound = 0xC0000225,

        /// <summary>
        /// {Not Enough Quota} Not enough virtual memory or paging file quota is available to complete the specified operation.
        /// </summary>
        NoMemory = 0xC0000017,

        /// <summary>
        /// An internal error occurred.
        /// </summary>
        InternalError = 0xC00000E5,

        /// <summary>
        /// The request is not supported.
        /// </summary>
        NotSupported = 0xC00000BB,
    }
}
