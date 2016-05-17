// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Runtime.InteropServices;

    /// <content>
    /// Contains the <see cref="BCryptEncryptFlags"/> nested type.
    /// </content>
    public partial class BCrypt
    {
        /// <summary>
        /// Flags that can be passed to the <see cref="BCryptEncrypt(SafeKeyHandle, byte[], void*, byte[], BCryptEncryptFlags)"/> method.
        /// </summary>
        [Flags]
        public enum BCryptEncryptFlags
        {
            None = 0x0,

            /// <summary>
            /// Symmetric algorithms: Allows the encryption algorithm to pad the data to the next block size. If this flag is not specified, the size of the plaintext specified in the cbInput parameter must be a multiple of the algorithm's block size.
            /// The block size can be obtained by calling the <see cref="BCryptGetProperty(SafeHandle, string, BCryptGetPropertyFlags)"/> function to get the BCRYPT_BLOCK_LENGTH property for the key. This will provide the size of a block for the algorithm.
            /// This flag must not be used with the authenticated encryption modes (AES-CCM and AES-GCM).
            /// </summary>
            BCRYPT_BLOCK_PADDING = 1,

            /// <summary>
            /// Asymmetric algorithms: Do not use any padding. The pPaddingInfo parameter is not used. The size of the plaintext specified in the cbInput parameter must be a multiple of the algorithm's block size.
            /// </summary>
            BCRYPT_PAD_NONE = 0x1,

            /// <summary>
            /// Asymmetric algorithms: The data will be padded with a random number to round out the block size. The pPaddingInfo parameter is not used.
            /// </summary>
            BCRYPT_PAD_PKCS1 = 0x2,

            /// <summary>
            /// Asymmetric algorithms: Use the Optimal Asymmetric Encryption Padding (OAEP) scheme. The pPaddingInfo parameter is a pointer to a BCRYPT_OAEP_PADDING_INFO structure.
            /// </summary>
            BCRYPT_PAD_OAEP = 0x4,
        }
    }
}
