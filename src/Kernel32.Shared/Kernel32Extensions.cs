// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System.Globalization;
    using System.Threading;
    using static PInvoke.Kernel32;

    /// <summary>
    /// Extension methods available for and from the Kernel32 library.
    /// </summary>
    public static partial class Kernel32Extensions
    {
        /// <summary>
        /// The maximum memory we are willing to allocate for the exception message.
        /// </summary>
        private const int MaxAllowedBufferSize = 65 * 1024;

        /// <summary>
        /// Gets the text associated with a <see cref="Win32ErrorCode"/>.
        /// </summary>
        /// <param name="error">The error code.</param>
        /// <returns>The error message. Or <c>null</c> if no message could be found.</returns>
        public static unsafe string GetMessage(this Win32ErrorCode error)
        {
            int dwLanguageId = 0;

#if DESKTOP
            dwLanguageId = CultureInfo.CurrentCulture.LCID;
#endif

            return FormatMessage(
                FormatMessageFlags.FORMAT_MESSAGE_FROM_SYSTEM,
                null,
                (int)error,
                dwLanguageId,
                null,
                MaxAllowedBufferSize);
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
                throw new Win32Exception(errorCode);
            }
        }

        /// <summary>
        /// Throws an exception if a P/Invoke failed.
        /// </summary>
        /// <param name="status">The result of the P/Invoke call.</param>
        public static void ThrowOnError(this NTSTATUS status)
        {
            if (status.Severity == NTSTATUS.SeverityCode.STATUS_SEVERITY_ERROR)
            {
                throw new NTStatusException(status);
            }
        }
    }
}
