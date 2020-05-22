// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PInvoke
{
    /// <content>
    /// Contains the <see cref="CryptGetHashParamFlags"/> nested type.
    /// </content>
    public static partial class AdvApi32
    {
        /// <summary>
        /// Flags for passing to the <see cref="CryptGetHashParam(SafeHashHandle, CryptGetHashParamFlags, byte*, int*, uint)"/> method.
        /// </summary>
        public enum CryptGetHashParamFlags
        {
            /// <summary>
            /// An <see cref="ALG_ID"/> that indicates the algorithm specified when the hash object was created. For a list of hash algorithms, see <see cref="CryptCreateHash"/>.
            /// </summary>
            HP_ALGID = 0x0001,

            /// <summary>
            /// The hash value or message hash for the hash object specified by hHash. This value is generated based on the data supplied to the hash object earlier through the <see cref="CryptHashData(SafeHashHandle, byte*, int, CryptHashDataFlags)"/> and CryptHashSessionKey functions.
            /// The <see cref="CryptGetHashParam(SafeHashHandle, CryptGetHashParamFlags, byte*, int*, uint)"/> function completes the hash. After <see cref="CryptGetHashParam(SafeHashHandle, CryptGetHashParamFlags, byte*, int*, uint)"/> has been called, no more data can be added to the hash. Additional calls to <see cref="CryptHashData(SafeHashHandle, byte*, int, CryptHashDataFlags)"/> or CryptHashSessionKey fail. After the application is done with the hash, <see cref="CryptDestroyHash"/> should be called to destroy the hash object.
            /// </summary>
            HP_HASHVAL = 0x0002,

            /// <summary>
            /// DWORD value indicating the number of bytes in the hash value. This value will vary depending on the hash algorithm. Applications must retrieve this value just before the HP_HASHVAL value so the correct amount of memory can be allocated.
            /// </summary>
            HP_HASHSIZE = 0x0004,
        }
    }
}
