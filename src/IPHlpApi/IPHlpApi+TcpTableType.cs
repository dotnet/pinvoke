// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PInvoke
{
    /// <content>
    /// Contains the <see cref="TcpTableType"/> nested type.
    /// </content>
    public static partial class IPHlpApi
    {
        /// <summary>
        /// The <see cref="TcpTableType"/> enumeration defines the set of values used to indicate the type
        /// of table returned by calls to <see cref="IPHlpApi.GetExtendedTcpTable"/>.
        /// </summary>
        /// <seealso href="http://msdn2.microsoft.com/en-us/library/aa366386.aspx"/>
        public enum TcpTableType
        {
            /// <summary>
            /// A MIB_TCPTABLE table that contains all listening (receiving only) TCP endpoints on
            /// the local computer is returned to the caller.
            /// </summary>
            BasicListener,

            /// <summary>
            /// A MIB_TCPTABLE table that contains all connected TCP endpoints on the local
            /// computer is returned to the caller.
            /// </summary>
            BasicConnections,

            /// <summary>
            /// A MIB_TCPTABLE table that contains all TCP endpoints on the local computer is
            /// returned to the caller.
            /// </summary>
            BasicAll,

            /// <summary>
            /// A MIB_TCPTABLE_OWNER_PID or MIB_TCP6TABLE_OWNER_PID that contains all listening
            /// (receiving only) TCP endpoints on the local computer is returned to the caller.
            /// </summary>
            OwnerPidListener,

            /// <summary>
            /// A MIB_TCPTABLE_OWNER_PID or MIB_TCP6TABLE_OWNER_PID that structure that contains
            /// all connected TCP endpoints on the local computer is returned to the caller.
            /// </summary>
            OwnerPidConnections,

            /// <summary>
            /// A MIB_TCPTABLE_OWNER_PID or MIB_TCP6TABLE_OWNER_PID structure that contains all TCP
            /// endpoints on the local computer is returned to the caller.
            /// </summary>
            OwnerPidAll,

            /// <summary>
            /// A MIB_TCPTABLE_OWNER_MODULE or MIB_TCP6TABLE_OWNER_MODULE structure that contains
            /// all listening (receiving only) TCP endpoints on the local computer is returned to the caller.
            /// </summary>
            OwnerModuleListener,

            /// <summary>
            /// A MIB_TCPTABLE_OWNER_MODULE or MIB_TCP6TABLE_OWNER_MODULE structure that contains
            /// all connected TCP endpoints on the local computer is returned to the caller.
            /// </summary>
            OwnerModuleConnections,

            /// <summary>
            /// A MIB_TCPTABLE_OWNER_MODULE or MIB_TCP6TABLE_OWNER_MODULE structure that contains
            /// all TCP endpoints on the local computer is returned to the caller.
            /// </summary>
            OwnerModuleAll,
        }
    }
}
