// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Runtime.InteropServices;

    /// <content>
    /// Contains the <see cref="STARTUPINFOEX"/> nested struct.
    /// </content>
    public partial class Kernel32
    {
        /// <summary>
        /// Specifies the window station, desktop, standard handles, and attributes for a new process. It is used with the <see cref="CreateProcess"/> and <see cref="CreateProcessAsUser"/> functions.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct STARTUPINFOEX
        {
            /// <summary>
            /// A <see cref="STARTUPINFO"/> structure.
            /// </summary>
            public STARTUPINFO StartupInfo;

            /// <summary>
            /// An attribute list. This list is created by the <see cref="InitializeProcThreadAttributeList"/> function.
            /// </summary>
            public IntPtr lpAttributeList;

            /// <summary>
            /// Creates an instance of this structure and initializes its members to
            /// reasonable defaults.
            /// </summary>
            /// <returns>The initialized instance of this struct.</returns>
            public static STARTUPINFOEX Create()
            {
                return new STARTUPINFOEX
                {
                    StartupInfo = STARTUPINFO.Create(),
                };
            }
        }
    }
}
