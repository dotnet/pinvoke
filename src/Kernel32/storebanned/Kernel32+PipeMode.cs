// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PInvoke
{
    using System;

    /// <content>
    /// Contains the <see cref="PipeMode"/> nested type.
    /// </content>
    public partial class Kernel32
    {
        /// <summary>A named pipe usage mode, used in <see cref="CreateNamedPipe(string, PipeAccessMode, PipeMode, int, int, int, int, SECURITY_ATTRIBUTES*)" />.</summary>
        [Flags]
        public enum PipeMode : uint
        {
            /// <summary>
            ///     Data is written to the pipe as a stream of bytes. This mode cannot be used with
            ///     <see cref="PIPE_READMODE_MESSAGE" />. The pipe does not distinguish bytes written during different write
            ///     operations.
            /// </summary>
            PIPE_TYPE_BYTE = 0x00000000,

            /// <summary>
            ///     Data is written to the pipe as a stream of messages. The pipe treats the bytes written during each write
            ///     operation as a message unit. The GetLastError function returns <see cref="Win32ErrorCode.ERROR_MORE_DATA" /> when a
            ///     message is not read completely. This mode can be used with either <see cref="PIPE_READMODE_MESSAGE" /> or
            ///     <see cref="PIPE_READMODE_BYTE" />.
            /// </summary>
            PIPE_TYPE_MESSAGE = 0x00000004,

            /// <summary>
            ///     Data is read from the pipe as a stream of bytes. This mode can be used with either
            ///     <see cref="PIPE_TYPE_MESSAGE" /> or
            ///     <see cref="PIPE_TYPE_BYTE" />.
            /// </summary>
            PIPE_READMODE_BYTE = 0x00000000,

            /// <summary>
            ///     Data is read from the pipe as a stream of messages. This mode can be only used if
            ///     <see cref="PIPE_TYPE_MESSAGE" /> is also specified.
            /// </summary>
            PIPE_READMODE_MESSAGE = 0x00000002,

            /// <summary>
            ///     Blocking mode is enabled. When the pipe handle is specified in the
            ///     <see cref="ReadFile(SafeObjectHandle,void*,int,int*,OVERLAPPED*)" />,
            ///     <see cref="WriteFile(SafeObjectHandle,void*,int,int*,OVERLAPPED*)" />, or <see cref="ConnectNamedPipe(SafeObjectHandle, OVERLAPPED*)"/> function, the
            ///     operations are not completed until there is data to read, all data is written, or a client is connected. Use of
            ///     this mode can mean waiting indefinitely in some situations for a client process to perform an action.
            /// </summary>
            PIPE_WAIT = 0x00000000,

            /// <summary>
            ///     Nonblocking mode is enabled. In this mode,
            ///     <see cref="ReadFile(SafeObjectHandle,void*,int,int*,OVERLAPPED*)" />,
            ///     <see cref="WriteFile(SafeObjectHandle,void*,int,int*,OVERLAPPED*)" />, and ConnectNamedPipe always
            ///     return immediately.
            ///     <para>
            ///         Note that nonblocking mode is supported for compatibility with Microsoft LAN Manager version 2.0 and should
            ///         not be used to achieve asynchronous I/O with named pipes.
            ///     </para>
            /// </summary>
            PIPE_NOWAIT = 0x00000001,

            /// <summary>Connections from remote clients can be accepted and checked against the security descriptor for the pipe.
            ///     <para>Windows Server 2003 and Windows XP/2000:  This flag is not supported.</para>
            /// </summary>
            PIPE_ACCEPT_REMOTE_CLIENTS = 0x00000000,

            /// <summary>
            ///     Connections from remote clients are automatically rejected.
            ///     <para>
            ///         Windows Server 2003 and Windows XP/2000:  This flag is not supported. To achieve the same results, deny
            ///         access to the pipe to the NETWORK ACE.
            ///     </para>
            /// </summary>
            PIPE_REJECT_REMOTE_CLIENTS = 0x00000008,
        }
    }
}
