// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PInvoke
{
    /// <summary>
    /// Contains the <see cref="PROCESS_MEMORY_EXHAUSTION_TYPE"/> nested type.
    /// </summary>
    public partial class Kernel32
    {
        /// <summary>
        /// Represents the different memory exhaustion types.
        /// </summary>
        public enum PROCESS_MEMORY_EXHAUSTION_TYPE
        {
            /// <summary>
            /// Anytime memory management fails an allocation due to an inability to commit memory, it will cause the process to trigger a Windows
            /// Error Reporting report and then terminate immediately with <see cref="NTSTATUS.Code.STATUS_COMMITMENT_LIMIT"/>.
            ///
            /// The failure cannot be caught and handled by the app.
            /// </summary>
            PMETypeFailFastOnCommitFailure,

            /// <summary>
            /// The maximum value for this enumeration. This value may change in a future version.
            /// </summary>
            PMETypeMax,
        }
    }
}
