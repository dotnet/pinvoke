// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    public static class Kernel32Extensions
    {
        /// <summary>
        /// Throws an exception if a P/Invoke failed.
        /// </summary>
        /// <param name="status">The result of the P/Invoke call.</param>
        public static void ThrowOnError(this NTStatus status)
        {
            if ((int)status < 0)
            {
                status.ToWin32ErrorCode().ThrowOnError();
            }
        }

        /// <summary>
        /// Throws an exception when an error occurs.
        /// </summary>
        /// <param name="errorCode">The result of the P/Invoke call.</param>
        /// <exception cref="Win32Exception">If <paramref name="errorCode"/> is not <see cref="Win32ErrorCode.ERROR_SUCCESS"/></exception>
        public static void ThrowOnError(this Win32ErrorCode errorCode)
        {
            if (errorCode != Win32ErrorCode.ERROR_SUCCESS)
            {
                throw new Win32Exception((int)errorCode);
            }
        }
    }
}
