// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;

    /// <content>
    /// Contains the <see cref="NCryptDeriveKeyFlags"/> nested type.
    /// </content>
    public partial class NCrypt
    {
        /// <summary>
        /// The flags that may be passed to the <see cref="NCryptDeriveKey(SafeSecretHandle, string, NCryptBufferDesc*, byte*, int, out int, NCryptDeriveKeyFlags)"/> method.
        /// </summary>
        [Flags]
        public enum NCryptDeriveKeyFlags
        {
            /// <summary>
            /// No flags.
            /// </summary>
            None = 0x0,

            /// <summary>
            /// The secret agreement value will also serve as the HMAC key. If this flag is specified, the KDF_HMAC_KEY parameter should not be included in the set of parameters in the pParameterList parameter. This flag is only used by the <see cref="BCrypt.KeyDerivationFunctions.BCRYPT_KDF_HMAC"/> key derivation function.
            /// </summary>
            KDF_USE_SECRET_AS_HMAC_KEY_FLAG = 0x1,
        }
    }
}
