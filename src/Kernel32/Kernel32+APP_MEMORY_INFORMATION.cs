// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PInvoke
{
    /// <content>
    /// Contains the <see cref="APP_MEMORY_INFORMATION"/> nested type.
    /// </content>
    public partial class Kernel32
    {
        /// <summary>
        /// Represents app memory usage at a single point in time.
        /// This structure can used by in <see cref="GetProcessInformation(SafeObjectHandle, PROCESS_INFORMATION_CLASS, void*, uint)"/>.
        /// </summary>
        public struct APP_MEMORY_INFORMATION
        {
            /// <summary>
            /// Total commit available to the app.
            /// </summary>
            public ulong AvailableCommit;

            /// <summary>
            /// The app's usage of private commit.
            /// </summary>
            public ulong PrivateCommitUsage;

            /// <summary>
            /// The app's peak usage of private commit.
            /// </summary>
            public ulong PeakPrivateCommitUsage;

            /// <summary>
            /// The app's total usage of private plus shared commit.
            /// </summary>
            public ulong TotalCommitUsage;
        }
    }
}
