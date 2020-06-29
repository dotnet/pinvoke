// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PInvoke
{
#if !NETSTANDARD1_1
    using System.Net.NetworkInformation;
#endif
    using System.Runtime.InteropServices;

    /// <content>
    /// Contains the <see cref="MIB_TCPROW_OWNER_PID"/> nested type.
    /// </content>
    public static partial class IPHlpApi
    {
        /// <summary>
        /// The MIB_TCPROW_OWNER_PID structure contains information that describes an IP v4 TCP connection
        /// with IP v4 addresses, ports used by the TCP connection, and the specific process ID (PID)
        /// associated with connection.
        /// </summary>
        /// <seealso href="http://msdn2.microsoft.com/en-us/library/aa366913.aspx"/>
        [StructLayout(LayoutKind.Sequential)]
        public struct MIB_TCPROW_OWNER_PID
        {
            /// <summary>
            /// The state of the TCP connection.
            /// </summary>
            [MarshalAs(UnmanagedType.U4)]
#if NETSTANDARD1_1
            public uint State;
#else
            public TcpState State;
#endif

            /// <summary>
            /// The local IP v4 address for the TCP connection on the local computer.
            /// A value of zero indicates the listener can accept a connection on any interface.
            /// </summary>
            [MarshalAs(UnmanagedType.U4)]
            public uint LocalAddr;

            /// <summary>
            /// The local port number in network byte order for the TCP connection on the local computer.
            /// </summary>
            [MarshalAs(UnmanagedType.U2)]
            public ushort LocalPort;

            /// <summary>
            /// The <see cref="LocalPort"/> field is defined as a <see cref="uint"/>, but the last two
            /// bytes are unused.
            /// </summary>
            [MarshalAs(UnmanagedType.U2)]
            public ushort Reserved;

            /// <summary>
            /// The IP v4 address for the TCP connection on the remote computer.
            /// When the <see cref="State"/> member is <see cref="TcpState.Listen"/>, this value has no meaning.
            /// </summary>
            [MarshalAs(UnmanagedType.U4)]
            public uint RemoteAddr;

            /// <summary>
            /// The remote port number in network byte order for the TCP connection on the remote computer.
            /// When the <see cref="State"/> member is <see cref="TcpState.Listen"/>, this member has no meaning.
            /// </summary>
            [MarshalAs(UnmanagedType.U2)]
            public ushort RemotePort;

            /// <summary>
            /// The <see cref="RemotePort"/> field is defined as a <see cref="uint"/>, but the last two
            /// bytes are unused.
            /// </summary>
            [MarshalAs(UnmanagedType.U2)]
            public ushort Reserved2;

            /// <summary>
            /// The PID of the process that issued a context bind for this TCP connection.
            /// </summary>
            [MarshalAs(UnmanagedType.U4)]
            public uint OwningPid;
        }
    }
}
