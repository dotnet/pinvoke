// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PInvoke
{
    using System.Net;
    using System.Net.NetworkInformation;
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
        public struct MIB_TCPROW_OWNER_PID
        {
            /// <summary>
            /// The state of the TCP connection.
            /// </summary>
            public TcpState dwState;

            /// <summary>
            /// The local IP v4 address for the TCP connection on the local computer.
            /// A value of zero indicates the listener can accept a connection on any interface.
            /// </summary>
            public uint dwLocalAddr;

            /// <summary>
            /// The local port number in network byte order for the TCP connection on the local computer.
            /// </summary>
            public int dwLocalPort;

            /// <summary>
            /// The IP v4 address for the TCP connection on the remote computer.
            /// When the <see cref="dwState"/> member is <see cref="TcpState.Listen"/>, this value has no meaning.
            /// </summary>
            public uint dwRemoteAddr;

            /// <summary>
            /// The remote port number in network byte order for the TCP connection on the remote computer.
            /// When the <see cref="dwState"/> member is <see cref="TcpState.Listen"/>, this member has no meaning.
            /// </summary>
            public int dwRemotePort;

            /// <summary>
            /// The PID of the process that issued a context bind for this TCP connection.
            /// </summary>
            public uint dwOwningPid;

            /// <summary>
            /// Gets the local port number for the TCP connection on the local computer.
            /// </summary>
            public int LocalPort
            {
                get
                {
                    return (ushort)IPAddress.NetworkToHostOrder((short)this.dwLocalPort);
                }
            }

            /// <summary>
            /// Gets the remote port number for the TCP connection on the remote computer.
            /// When the <see cref="dwState"/> member is <see cref="TcpState.Listen"/>, this member has no meaning.
            /// </summary>
            public int RemotePort
            {
                get
                {
                    return (ushort)IPAddress.NetworkToHostOrder((short)this.dwRemotePort);
                }
            }

            /// <summary>
            /// Gets the local <see cref="IPAddress"/> for the TCP connection on the local computer.
            /// A value of <see cref="IPAddress.Any"/> indicates the listener can accept a connection on any interface.
            /// </summary>
            public IPAddress LocalAddr
            {
                get
                {
                    return new IPAddress(this.dwLocalAddr);
                }
            }

            /// <summary>
            /// Gets the <see cref="IPAddress"/> for the TCP connection on the remote computer.
            /// When the <see cref="dwState"/> member is <see cref="TcpState.Listen"/>, this value has no meaning.
            /// </summary>
            public IPAddress RemoteAddr
            {
                get
                {
                    return new IPAddress(this.dwRemoteAddr);
                }
            }
        }
    }
}
