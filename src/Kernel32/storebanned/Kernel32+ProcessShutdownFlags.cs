// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PInvoke
{
    using System;

    /// <content>
    /// Contains the <see cref="ProcessShutdownFlags"/> nested type.
    /// </content>
    public partial class Kernel32
    {
        /// <summary>
        /// Values that are passed to the <see cref="SetProcessShutdownParameters(int, ProcessShutdownFlags)"/> flag.
        /// </summary>
        public enum ProcessShutdownFlags
        {
            None = 0,

            /// <summary>
            /// The system terminates the process without displaying a retry dialog box for the user.
            /// </summary>
            SHUTDOWN_NORETRY = 1,
        }
    }
}
