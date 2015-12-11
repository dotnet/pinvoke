// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;

    /// <content>
    /// Contains the <see cref="AuthModeFlags"/> nested type.
    /// </content>
    public partial class BCrypt
    {
        /// <summary>
        /// Flags for the <see cref="BCRYPT_AUTHENTICATED_CIPHER_MODE_INFO.dwFlags"/> field.
        /// </summary>
        [Flags]
        public enum AuthModeFlags
        {
            /// <summary>
            /// No flags.
            /// </summary>
            None = 0x0,

            /// <summary>
            /// Indicates that <see cref="BCryptEncrypt(SafeKeyHandle, byte[], int, void*, byte[], int, byte[], int, out int, BCryptEncryptFlags)"/> and <see cref="BCryptDecrypt(SafeKeyHandle, byte[], int, void*, byte[], int, byte[], int, out int, BCryptEncryptFlags)"/> function calls are being chained and that the MAC value will not be computed. On the last call in the chain, clear this value to compute the MAC value for the entire chain.
            /// </summary>
            BCRYPT_AUTH_MODE_CHAIN_CALLS_FLAG = 0x1,

            /// <summary>
            /// Indicates that this <see cref="BCRYPT_AUTHENTICATED_CIPHER_MODE_INFO"/> structure is being used in a sequence of chained <see cref="BCryptEncrypt(SafeKeyHandle, byte[], int, void*, byte[], int, byte[], int, out int, BCryptEncryptFlags)"/> or <see cref="BCryptDecrypt(SafeKeyHandle, byte[], int, void*, byte[], int, byte[], int, out int, BCryptEncryptFlags)"/> function calls. This flag is set and maintained internally.
            /// Note: During the chaining sequence, this flag value is maintained internally and must not be changed or the value of the computed MAC will be corrupted.
            /// </summary>
            BCRYPT_AUTH_MODE_IN_PROGRESS_FLAG = 0x2,
        }
    }
}
