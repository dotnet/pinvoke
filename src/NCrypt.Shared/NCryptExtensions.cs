// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Globalization;
    using static Kernel32;
    using static NCrypt;

    /// <summary>
    /// Extension methods related to the NCrypt library.
    /// </summary>
    public static class NCryptExtensions
    {
        /// <summary>
        /// The maximum memory we are willing to allocate for the exception message.
        /// </summary>
        private const int MaxAllowedBufferSize = 65 * 1024;

        /// <summary>
        /// Throws an exception if an NCrypt function returned a failure error code.
        /// </summary>
        /// <param name="status">The result from an NCrypt function.</param>
        public static void ThrowOnError(this SECURITY_STATUS status)
        {
            switch (status)
            {
                case SECURITY_STATUS.ERROR_SUCCESS:
                    return;
                default:
                    throw new SecurityStatusException(status);
            }
        }

        /// <summary>
        /// Gets the text associated with a <see cref="SECURITY_STATUS"/>.
        /// </summary>
        /// <param name="error">The error code.</param>
        /// <returns>The error message. Or <c>null</c> if no message could be found.</returns>
        public static unsafe string GetMessage(this SECURITY_STATUS error)
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
    }
}
