// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Runtime.InteropServices;

    /// <summary>
    /// Extension methods for commonly defined types.
    /// </summary>
    public static class PInvokeExtensions
    {
        /// <summary>
        /// Throws an exception if a P/Invoke failed.
        /// </summary>
        /// <param name="status">The result of the P/Invoke call.</param>
        public static void ThrowOnError(this NTStatus status)
        {
            switch (status)
            {
                case NTStatus.STATUS_SUCCESS:
                    break;
                case NTStatus.STATUS_INVALID_HANDLE:
                    throw new ArgumentException("Invalid handle");
                case NTStatus.STATUS_INVALID_PARAMETER:
                    throw new ArgumentException();
                case NTStatus.STATUS_NOT_FOUND:
                    throw new ArgumentException("Not found");
                case NTStatus.STATUS_NO_MEMORY:
                    throw new OutOfMemoryException();
                case NTStatus.STATUS_NOT_SUPPORTED:
                    throw new NotSupportedException();
                default:
                    if ((int)status < 0)
                    {
                        Marshal.ThrowExceptionForHR(Marshal.GetHRForLastWin32Error());
                    }

                    break;
            }
        }
    }
}
