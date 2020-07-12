// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PInvoke
{
    using System;

    /// <content>
    /// Contains the <see cref="NamedPipeInfoFlags"/> nested type.
    /// </content>
    public partial class Kernel32
    {
        /// <summary>Flags returned by <see cref="GetNamedPipeInfo" />.</summary>
        [Flags]
        public enum NamedPipeInfoFlags : uint
        {
            /// <summary>The handle refers to the client end of a named pipe instance. This is the default.</summary>
            PIPE_CLIENT_END = 0x00000000,

            /// <summary>
            ///     The handle refers to the server end of a named pipe instance. If this value is not specified, the handle
            ///     refers to the client end of a named pipe instance.
            /// </summary>
            PIPE_SERVER_END = 0x00000001,

            /// <summary>The named pipe is a byte pipe. This is the default.</summary>
            PIPE_TYPE_BYTE = 0x00000000,

            /// <summary>The named pipe is a message pipe. If this value is not specified, the pipe is a byte pipe.</summary>
            PIPE_TYPE_MESSAGE = 0x00000004,
        }
    }
}
