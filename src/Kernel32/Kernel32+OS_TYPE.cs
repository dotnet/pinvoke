// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PInvoke
{
    /// <summary>
    /// Contains the <see cref="OS_TYPE"/> nested type.
    /// </summary>
    public static partial class Kernel32
    {
        /// <summary>
        /// The product type enumeration.
        /// </summary>
        public enum OS_TYPE : byte
        {
            /// <summary>
            /// The operating system is Windows 8, Windows 7, Windows Vista, Windows XP Professional, Windows XP Home Edition, or Windows 2000 Professional.
            /// </summary>
            VER_NT_WORKSTATION = 0x00000001,

            /// <summary>
            /// The system is a domain controller and the operating system is Windows Server 2012 , Windows Server 2008 R2,
            /// Windows Server 2008, Windows Server 2003, or Windows 2000 Server.
            /// </summary>
            VER_NT_DOMAIN_CONTROLLER = 0x00000002,

            /// <summary>
            /// The operating system is Windows Server 2012, Windows Server 2008 R2, Windows Server 2008, Windows Server 2003, or Windows 2000 Server.
            /// </summary>
            /// <remarks>
            /// Note that a server that is also a domain controller is reported as <see cref="VER_NT_DOMAIN_CONTROLLER"/>, not <see cref="VER_NT_SERVER"/>.
            /// </remarks>
            VER_NT_SERVER = 0x00000003,
        }
    }
}
