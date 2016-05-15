// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    /// <content>
    /// Contains the <see cref="KeyDerivationFunctions"/> nested type.
    /// </content>
    public partial class BCrypt
    {
        /// <summary>
        /// Key derivation functions.
        /// See https://msdn.microsoft.com/en-us/library/windows/desktop/aa376252(v=vs.85).aspx for more information.
        /// </summary>
        public static class KeyDerivationFunctions
        {
            /// <summary>
            /// Use the hash key derivation function.
            /// </summary>
            public const string BCRYPT_KDF_HASH = "HASH";

            /// <summary>
            /// Use the Hash-Based Message Authentication Code (HMAC) key derivation function.
            /// </summary>
            public const string BCRYPT_KDF_HMAC = "HMAC";

            /// <summary>
            /// Use the transport layer security (TLS) pseudo-random function (PRF) key derivation function.
            /// </summary>
            public const string BCRYPT_KDF_TLS_PRF = "TLS_PRF";

            /// <summary>
            /// Use the SP800-56A key derivation function.
            /// </summary>
            public const string BCRYPT_KDF_SP80056A_CONCAT = "SP800_56A_CONCAT";
        }
    }
}
