// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;

    /// <content>
    /// Contains the <see cref="BCryptDeriveKeyFlags"/> nested type.
    /// </content>
    public partial class BCrypt
    {
        [Flags]
        public enum BCryptDeriveKeyFlags
        {
            /// <summary>
            /// No flags.
            /// </summary>
            None = 0x0,

            /// <summary>
            /// Causes the secret agreement to serve also
            /// as the HMAC key.  If this flag is used, the KDF_HMAC_KEY parameter should
            /// NOT be specified.
            /// </summary>
            KDF_USE_SECRET_AS_HMAC_KEY_FLAG = 0x1,
        }
    }
}
