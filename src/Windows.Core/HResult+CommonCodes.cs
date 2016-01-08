// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    /// <content>
    /// Common HRESULT constants.
    /// </content>
    public partial struct HResult
    {
        /// <summary>
        /// Operation successful, and returned a false result.
        /// </summary>
        public static readonly HResult S_FALSE = 1;

        /// <summary>
        /// Operation successful
        /// </summary>
        public static readonly HResult S_OK = 0;

        /// <summary>
        /// Unspecified failure
        /// </summary>
        public static readonly HResult E_FAIL = 0x80004005;

        /// <summary>
        /// Operation aborted
        /// </summary>
        public static readonly HResult E_ABORT = 0x80004004;

        /// <summary>
        /// General access denied error
        /// </summary>
        public static readonly HResult E_ACCESSDENIED = 0x80070005;

        /// <summary>
        /// Handle that is not valid
        /// </summary>
        public static readonly HResult E_HANDLE = 0x80070006;

        /// <summary>
        /// One or more arguments are not valid
        /// </summary>
        public static readonly HResult E_INVALIDARG = 0x80070057;

        /// <summary>
        /// No such interface supported
        /// </summary>
        public static readonly HResult E_NOINTERFACE = 0x80004002;

        /// <summary>
        /// Not implemented
        /// </summary>
        public static readonly HResult E_NOTIMPL = 0x80004001;

        /// <summary>
        /// Failed to allocate necessary memory
        /// </summary>
        public static readonly HResult E_OUTOFMEMORY = 0x8007000E;

        /// <summary>
        /// Pointer that is not valid
        /// </summary>
        public static readonly HResult E_POINTER = 0x80004003;

        /// <summary>
        /// Unexpected failure
        /// </summary>
        public static readonly HResult E_UNEXPECTED = 0x8000FFFF;
    }
}
