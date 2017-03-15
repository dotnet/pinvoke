// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Runtime.InteropServices;

    /// <content>
    /// Contains the <see cref="EccKeyBlob"/> nested type.
    /// </content>
    public partial class BCrypt
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct EccKeyBlob
        {
            /// <summary>
            /// Specifies the type of key this BLOB represents.
            /// The possible values for this member depend on the type of BLOB this structure represents.
            /// </summary>
            public EccKeyBlobMagicNumbers Magic;

            /// <summary>
            /// The length, in bytes, of the key.
            /// </summary>
            public int KeyLength;

            /// <summary>
            /// Initializes a new instance of the <see cref="EccKeyBlob"/> struct.
            /// </summary>
            /// <param name="keyBlob">The key blob that starts with an BCRYPT_ECCKEY_BLOB structure.</param>
            public EccKeyBlob(byte[] keyBlob)
            {
                this.Magic = (EccKeyBlobMagicNumbers)BitConverter.ToUInt32(keyBlob, 0);
                this.KeyLength = BitConverter.ToInt32(keyBlob, 4);
            }
        }
    }
}
