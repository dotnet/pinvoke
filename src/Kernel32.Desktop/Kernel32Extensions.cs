// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System.Globalization;
    using static PInvoke.Kernel32;

    /// <content>
    /// Desktop-only extension methods for Kernel32.
    /// </content>
    public static partial class Kernel32Extensions
    {
        /// <summary>
        /// Gets the text associated with an <see cref="NTSTATUS"/>.
        /// </summary>
        /// <param name="status">The error code.</param>
        /// <returns>The error message. Or <c>null</c> if no message could be found.</returns>
        public static string GetMessage(this NTSTATUS status)
        {
            using (var ntdll = LoadLibrary("ntdll.dll"))
            {
                int dwLanguageId = 0;
#if DESKTOP
                dwLanguageId = CultureInfo.CurrentCulture.LCID;
#endif

                string formattedMessage = FormatMessage(
                    FormatMessageFlags.FORMAT_MESSAGE_FROM_HMODULE,
                    ntdll.DangerousGetHandle(),
                    (int)status,
                    dwLanguageId,
                    null,
                    MaxAllowedBufferSize);
                if (formattedMessage != null)
                {
                    return formattedMessage;
                }
            }

            return null;
        }
    }
}
