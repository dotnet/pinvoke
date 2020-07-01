// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PInvoke
{
    /// <content>
    /// Contains the <see cref="TCP_TABLE_CLASS"/> nested type.
    /// </content>
    public static partial class IPHlpApi
    {
        /// <summary>
        /// The <see cref="TCP_TABLE_CLASS"/> enumeration defines the set of values used to indicate the type
        /// of table returned by calls to <see cref="IPHlpApi.GetExtendedTcpTable(void*, ref int, bool, System.Net.Sockets.AddressFamily, TCP_TABLE_CLASS, uint)"/>.
        /// </summary>
        /// <seealso href="http://msdn2.microsoft.com/en-us/library/aa366386.aspx"/>
        public enum TCP_TABLE_CLASS
        {
            /// <summary>
            /// A MIB_TCPTABLE table that contains all listening (receiving only) TCP endpoints on
            /// the local computer is returned to the caller.
            /// </summary>
            TCP_TABLE_BASIC_LISTENER,

            /// <summary>
            /// A MIB_TCPTABLE table that contains all connected TCP endpoints on the local
            /// computer is returned to the caller.
            /// </summary>
            TCP_TABLE_BASIC_CONNECTIONS,

            /// <summary>
            /// A MIB_TCPTABLE table that contains all TCP endpoints on the local computer is
            /// returned to the caller.
            /// </summary>
            TCP_TABLE_BASIC_ALL,

            /// <summary>
            /// A MIB_TCPTABLE_OWNER_PID or MIB_TCP6TABLE_OWNER_PID that contains all listening
            /// (receiving only) TCP endpoints on the local computer is returned to the caller.
            /// </summary>
            TCP_TABLE_OWNER_PID_LISTENER,

            /// <summary>
            /// A MIB_TCPTABLE_OWNER_PID or MIB_TCP6TABLE_OWNER_PID that structure that contains
            /// all connected TCP endpoints on the local computer is returned to the caller.
            /// </summary>
            TCP_TABLE_OWNER_PID_CONNECTIONS,

            /// <summary>
            /// A MIB_TCPTABLE_OWNER_PID or MIB_TCP6TABLE_OWNER_PID structure that contains all TCP
            /// endpoints on the local computer is returned to the caller.
            /// </summary>
            TCP_TABLE_OWNER_PID_ALL,

            /// <summary>
            /// A MIB_TCPTABLE_OWNER_MODULE or MIB_TCP6TABLE_OWNER_MODULE structure that contains
            /// all listening (receiving only) TCP endpoints on the local computer is returned to the caller.
            /// </summary>
            TCP_TABLE_OWNER_MODULE_LISTENER,

            /// <summary>
            /// A MIB_TCPTABLE_OWNER_MODULE or MIB_TCP6TABLE_OWNER_MODULE structure that contains
            /// all connected TCP endpoints on the local computer is returned to the caller.
            /// </summary>
            TCP_TABLE_OWNER_MODULE_CONNECTIONS,

            /// <summary>
            /// A MIB_TCPTABLE_OWNER_MODULE or MIB_TCP6TABLE_OWNER_MODULE structure that contains
            /// all TCP endpoints on the local computer is returned to the caller.
            /// </summary>
            TCP_TABLE_OWNER_MODULE_ALL,
        }
    }
}
