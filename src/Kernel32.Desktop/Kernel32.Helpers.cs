// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;

    /// <content>
    /// Methods and nested types that are not strictly P/Invokes but provide
    /// a slightly higher level of functionality to ease calling into native code.
    /// </content>
    public static partial class Kernel32
    {
        public static PROCESSENTRY32 Process32First(SafeObjectHandle hSnapshot)
        {
            if (hSnapshot == null)
            {
                throw new ArgumentNullException(nameof(hSnapshot));
            }

            var entry = new PROCESSENTRY32();
            if (Process32First(hSnapshot, entry))
            {
                return entry;
            }

            var lastError = (Win32ErrorCode)Marshal.GetLastWin32Error();
            if (lastError != Win32ErrorCode.ERROR_NO_MORE_FILES)
            {
                Marshal.ThrowExceptionForHR(Marshal.GetHRForLastWin32Error());
            }

            return null;
        }

        public static PROCESSENTRY32 Process32Next(SafeObjectHandle hSnapshot)
        {
            if (hSnapshot == null)
            {
                throw new ArgumentNullException(nameof(hSnapshot));
            }

            var entry = new PROCESSENTRY32();
            if (Process32Next(hSnapshot, entry))
            {
                return entry;
            }

            var lastError = (Win32ErrorCode)Marshal.GetLastWin32Error();
            if (lastError != Win32ErrorCode.ERROR_NO_MORE_FILES)
            {
                Marshal.ThrowExceptionForHR(Marshal.GetHRForLastWin32Error());
            }

            return null;
        }

        public static IEnumerable<PROCESSENTRY32> Process32Enumerate(SafeObjectHandle hSnapshot)
        {
            if (hSnapshot == null)
            {
                throw new ArgumentNullException(nameof(hSnapshot));
            }

            var entry = Process32First(hSnapshot);

            while (entry != null)
            {
                yield return entry;
                entry = Process32Next(hSnapshot);
            }
        }
    }
}
