// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PInvoke
{
    /// <content>
    /// Methods and nested types that are not strictly P/Invokes but provide
    /// a slightly higher level of functionality to ease calling into native code.
    /// </content>
    public static partial class NTDll
    {
        /// <inheritdoc cref="RtlGetVersion(Kernel32.OSVERSIONINFO*)"/>
        [NoFriendlyOverloads]
        public static unsafe NTSTATUS RtlGetVersion(Kernel32.OSVERSIONINFOEX* versionInformation) => RtlGetVersion((Kernel32.OSVERSIONINFO*)versionInformation);

        /// <inheritdoc cref="RtlGetVersion(Kernel32.OSVERSIONINFOEX*)"/>
        public static unsafe NTSTATUS RtlGetVersion(ref Kernel32.OSVERSIONINFOEX versionInformation)
        {
            fixed (Kernel32.OSVERSIONINFOEX* versionInformationLocal = &versionInformation)
            {
                return RtlGetVersion(versionInformationLocal);
            }
        }
    }
}
