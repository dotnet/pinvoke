// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PInvoke
{
    /// <content>
    /// Contains the <see cref="PROCESSINFOCLASS"/> nested type.
    /// </content>
    public static partial class NTDll
    {
        /// <summary>
        /// The type of process information to be retrieved.
        /// </summary>
        public enum PROCESSINFOCLASS
        {
            /// <summary>
            /// Retrieves a pointer to a PEB structure that can be used to determine whether the specified process
            /// is being debugged, and a unique value used by the system to identify the specified process.
            /// </summary>
            ProcessBasicInformation = 0,

            /// <summary>
            /// Retrieves a DWORD_PTR value that is the port number of the debugger for the process. A nonzero value
            /// indicates that the process is being run under the control of a ring 3 debugger.
            /// </summary>
            ProcessDebugPort = 7,

            /// <summary>
            /// Determines whether the process is running in the WOW64 environment (WOW64 is the x86 emulator that
            /// allows Win32-based applications to run on 64-bit Windows).
            /// </summary>
            ProcessWow64Information = 26,

            /// <summary>
            /// Retrieves a UNICODE_STRING value containing the name of the image file for the process.
            /// </summary>
            ProcessImageFileName = 27,

            /// <summary>
            /// Retrieves a ULONG value indicating whether the process is considered critical.
            /// </summary>
            ProcessBreakOnTermination = 29,

            /// <summary>
            /// Retrieves a SUBSYSTEM_INFORMATION_TYPE value indicating the subsystem type of the process.
            /// The buffer pointed to by the ProcessInformation parameter should be large enough to hold a
            /// single SUBSYSTEM_INFORMATION_TYPE enumeration.
            /// </summary>
            ProcessSubsystemInformation = 75,
        }
    }
}
