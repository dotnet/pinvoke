// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;

    /// <content>
    /// The <see cref="NCryptEncryptFlags"/> nested type.
    /// </content>
    public partial class NCrypt
    {
        /// <summary>
        /// Flags that may be passed to the <see cref="NCryptEncrypt(SafeKeyHandle, byte*, int, void*, byte*, int, out int, NCryptEncryptFlags)"/> method.
        /// </summary>
        [Flags]
        public enum NCryptEncryptFlags
        {
            /// <summary>
            /// No flags.
            /// </summary>
            None = 0,

            /// <summary>
            /// Asymmetric keys: Do not use any padding. The pPaddingInfo parameter is not used.
            /// If you specify the NCRYPT_NO_PADDING_FLAG, then the <see cref="NCryptEncrypt(SafeKeyHandle, byte*, int, void*, byte*, int, out int, NCryptEncryptFlags)"/> function only encrypts the first N bits, where N is the length of the key that was passed as the hKey parameter. Any bits after the first N bits are ignored.
            /// </summary>
            NCRYPT_NO_PADDING_FLAG = 0x00000001,

            /// <summary>
            /// Asymmetric keys: The data will be padded with a random number to round out the block size. The pPaddingInfo parameter is not used.
            /// </summary>
            NCRYPT_PAD_PKCS1_FLAG = 0x00000002,

            /// <summary>
            /// Asymmetric keys: Use the Optimal Asymmetric Encryption Padding (OAEP) scheme. The pPaddingInfo parameter is a pointer to a <see cref="BCrypt.BCRYPT_OAEP_PADDING_INFO"/> structure.
            /// </summary>
            NCRYPT_PAD_OAEP_FLAG = 0x00000004,

            /// <summary>
            /// Requests that the key service provider (KSP) not display any user interface. If the provider must display the UI to operate, the call fails and the KSP should set the NTE_SILENT_CONTEXT error code as the last error.
            /// </summary>
            NCRYPT_SILENT_FLAG = 0x00000040,
        }
    }
}
