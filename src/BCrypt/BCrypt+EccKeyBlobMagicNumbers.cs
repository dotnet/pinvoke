// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    /// <content>
    /// Contains the <see cref="EccKeyBlobMagicNumbers"/> nested type.
    /// </content>
    public partial class BCrypt
    {
        public enum EccKeyBlobMagicNumbers : uint
        {
            BCRYPT_ECDH_PUBLIC_P256_MAGIC = 0x314B4345,  // ECK1
            BCRYPT_ECDH_PRIVATE_P256_MAGIC = 0x324B4345,  // ECK2
            BCRYPT_ECDH_PUBLIC_P384_MAGIC = 0x334B4345,  // ECK3
            BCRYPT_ECDH_PRIVATE_P384_MAGIC = 0x344B4345,  // ECK4
            BCRYPT_ECDH_PUBLIC_P521_MAGIC = 0x354B4345,  // ECK5
            BCRYPT_ECDH_PRIVATE_P521_MAGIC = 0x364B4345,  // ECK6
            BCRYPT_ECDSA_PUBLIC_P256_MAGIC = 0x31534345,  // ECS1
            BCRYPT_ECDSA_PRIVATE_P256_MAGIC = 0x32534345,  // ECS2
            BCRYPT_ECDSA_PUBLIC_P384_MAGIC = 0x33534345,  // ECS3
            BCRYPT_ECDSA_PRIVATE_P384_MAGIC = 0x34534345,  // ECS4
            BCRYPT_ECDSA_PUBLIC_P521_MAGIC = 0x35534345,  // ECS5
            BCRYPT_ECDSA_PRIVATE_P521_MAGIC = 0x36534345,  // ECS6
        }
    }
}
