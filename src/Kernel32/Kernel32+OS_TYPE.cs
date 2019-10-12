// Copyright (c) All contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PInvoke
{
    /// <summary>
    /// Contains the <see cref="OS_TYPE"/> nested type.
    /// </summary>
    public static partial class Kernel32
    {
        /// <summary>
        /// The product type enumeration
        /// </summary>
        public enum OS_TYPE : byte
        {
            VER_NT_WORKSTATION = 0x00000001,
            VER_NT_DOMAIN_CONTROLLER = 0x00000002,
            VER_NT_SERVER = 0x00000003
        }
    }
}