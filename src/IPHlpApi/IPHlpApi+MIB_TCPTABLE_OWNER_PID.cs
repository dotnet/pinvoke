// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PInvoke
{
    using System.Runtime.InteropServices;

    /// <content>
    /// Contains the <see cref="MIB_TCPTABLE_OWNER_PID"/> nested type.
    /// </content>
    public static partial class IPHlpApi
    {
        /// <summary>
        /// The MIB_TCPTABLE_OWNER_PID structure contains a table of process IDs (PIDs) and the
        /// IP v4 TCP links that are context bound to these PIDs.
        /// </summary>
        /// <seealso href="http://msdn2.microsoft.com/en-us/library/aa366921.aspx"/>
        public struct MIB_TCPTABLE_OWNER_PID
        {
            /// <summary>
            /// The number of <see cref="MIB_TCPROW_OWNER_PID"/> elements in the table.
            /// </summary>
            public uint dwNumEntries;
        }
    }
}
