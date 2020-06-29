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
            ProcessWow64Information = 26,
        }
    }
}
