// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    /// <content>
    /// The <see cref="Code"/> nested type.
    /// </content>
    public partial struct HResult
    {
        /// <summary>
        /// Common HRESULT constants.
        /// </summary>
        public enum Code : uint
        {
            /// <summary>
            /// Operation successful, and returned a false result.
            /// </summary>
            S_FALSE = 1,

            /// <summary>
            /// Operation successful
            /// </summary>
            S_OK = 0,

            /// <summary>
            /// Unspecified failure
            /// </summary>
            E_FAIL = 0x80004005,

            /// <summary>
            /// Operation aborted
            /// </summary>
            E_ABORT = 0x80004004,

            /// <summary>
            /// General access denied error
            /// </summary>
            E_ACCESSDENIED = 0x80070005,

            /// <summary>
            /// Handle that is not valid
            /// </summary>
            E_HANDLE = 0x80070006,

            /// <summary>
            /// One or more arguments are not valid
            /// </summary>
            E_INVALIDARG = 0x80070057,

            /// <summary>
            /// No such interface supported
            /// </summary>
            E_NOINTERFACE = 0x80004002,

            /// <summary>
            /// Not implemented
            /// </summary>
            E_NOTIMPL = 0x80004001,

            /// <summary>
            /// Failed to allocate necessary memory
            /// </summary>
            E_OUTOFMEMORY = 0x8007000E,

            /// <summary>
            /// Pointer that is not valid
            /// </summary>
            E_POINTER = 0x80004003,

            /// <summary>
            /// Unexpected failure
            /// </summary>
            E_UNEXPECTED = 0x8000FFFF,
        }
    }
}