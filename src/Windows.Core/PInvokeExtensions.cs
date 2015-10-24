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
                case NTStatus.Success:
                    break;
                case NTStatus.InvalidHandle:
                    throw new ArgumentException("Invalid handle");
                case NTStatus.InvalidParameter:
                    throw new ArgumentException();
                case NTStatus.NotFound:
                    throw new ArgumentException("Not found");
                case NTStatus.NoMemory:
                    throw new OutOfMemoryException();
                case NTStatus.NotSupported:
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
