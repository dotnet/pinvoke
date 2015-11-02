// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Collections.Generic;
    using System.Text;

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

            var lastError = GetLastError();
            if (lastError != Win32ErrorCode.ERROR_NO_MORE_FILES)
            {
                throw new Win32Exception(lastError);
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

            var lastError = GetLastError();
            if (lastError != Win32ErrorCode.ERROR_NO_MORE_FILES)
            {
                throw new Win32Exception(lastError);
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

        public static string QueryFullProcessImageName(
            SafeObjectHandle hProcess,
            QueryFullProcessImageNameFlags dwFlags = QueryFullProcessImageNameFlags.None)
        {
            // If we ever resize over this value something got really wrong
            const int maximumRealisticSize = 1 * 1024 * 2014;

            var buffer = new StringBuilder(255);
            do
            {
                var size = (uint)buffer.Capacity;
                var success = QueryFullProcessImageName(hProcess, dwFlags, buffer, ref size);
                if (success)
                {
                    return buffer.ToString();
                }

                buffer.Capacity = buffer.Capacity * 2;
            }
            while (buffer.Capacity < maximumRealisticSize);

            throw new InvalidOperationException(
                $"QueryFullProcessImageName is expecting a buffer of more than {maximumRealisticSize} bytes");
        }
    }
}
