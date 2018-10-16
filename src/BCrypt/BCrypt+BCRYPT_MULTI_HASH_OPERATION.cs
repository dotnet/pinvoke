// Copyright (c) All contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PInvoke
{
    using System.Runtime.InteropServices;

    /// <content>
    /// Contains the <see cref="BCRYPT_MULTI_HASH_OPERATION"/> nested type.
    /// </content>
    public partial class BCrypt
    {
        [StructLayout(LayoutKind.Sequential)]
        public unsafe struct BCRYPT_MULTI_HASH_OPERATION
        {
            public int iHash; // index of hash object
            public HashOperationType hashOperation; // operation to be performed
            public byte* pbBuffer;       // data to be hashed, or result buffer
            public int cbBuffer;
        }
    }
}
