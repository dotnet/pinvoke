// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Runtime.InteropServices;

    /// <content>
    /// Contains the <see cref="PROCESS_BASIC_INFORMATION"/> nested type.
    /// </content>
    public static partial class NTDll
    {
        /// <summary>
        /// Contains basic information about a process.
        /// </summary>
        /// <seealso href="https://msdn.microsoft.com/en-us/library/windows/desktop/ms684280(v=vs.85).aspx"/>
        [StructLayout(LayoutKind.Sequential)]
        public struct PROCESS_BASIC_INFORMATION
        {
            /// <summary>
            /// This value is reserved.
            /// </summary>
            public IntPtr Reserved1;

            /// <summary>
            /// The base address of the PEB structure in the process memory.
            /// </summary>
            public IntPtr PebBaseAddress;

            /// <summary>
            /// This value is reserved.
            /// </summary>
            public IntPtr Reserved2a;

            /// <summary>
            /// This value is reserved.
            /// </summary>
            public IntPtr Reserved2b;

            /// <summary>
            /// The process ID.
            /// </summary>
            public IntPtr UniqueProcessId;

            /// <summary>
            /// This value is reserved.
            /// </summary>
            public IntPtr Reserved3;
        }
    }
}
