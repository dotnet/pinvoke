// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PInvoke
{
    using System;

    /// <content>
    /// Contains the <see cref="ErrorModes"/> nested type.
    /// </content>
    public partial class Kernel32
    {
        [Flags]
        public enum ErrorModes : uint
        {
            /// <summary>
            /// Use the system default, which is to display all error dialog boxes.
            /// </summary>
            SEM_DEFAULT = 0x00000000,

            /// <summary>
            /// <para>
            ///     The system does not display the critical-error-handler message box.
            ///     Instead, the system sends the error to the calling process.
            /// </para>
            /// <para>
            ///      Best practice is that all applications call the process-wide <see cref="SetErrorMode"/> function
            ///      with a parameter of <see cref="SEM_FAILCRITICALERRORS"/> at startup.
            ///      This is to prevent error mode dialogs from hanging the application.
            /// </para>
            /// </summary>
            SEM_FAILCRITICALERRORS = 0x0001,

            /// <summary>
            /// <para>
            ///     The system automatically fixes memory alignment faults and makes them invisible to the application.
            ///     It does this for the calling process and any descendant processes.
            ///     This feature is only supported by certain processor architectures.
            /// </para>
            /// <para>
            ///     After this value is set for a process, subsequent attempts to clear the value are ignored.
            /// </para>
            /// </summary>
            SEM_NOALIGNMENTFAULTEXCEPT = 0x0004,

            /// <summary>
            /// The system does not display the Windows Error Reporting dialog.
            /// </summary>
            SEM_NOGPFAULTERRORBOX = 0x0002,

            /// <summary>
            /// The OpenFile function does not display a message box when it fails to find a file.
            /// Instead, the error is returned to the caller. This error mode overrides the OF_PROMPT flag.
            /// </summary>
            SEM_NOOPENFILEERRORBOX = 0x8000,
        }
    }
}
