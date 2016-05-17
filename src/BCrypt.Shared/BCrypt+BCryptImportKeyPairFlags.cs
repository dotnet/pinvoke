// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;

    /// <content>
    /// Contains the <see cref="BCryptImportKeyPairFlags"/> nested type.
    /// </content>
    public partial class BCrypt
    {
        [Flags]
        public enum BCryptImportKeyPairFlags
        {
            None = 0x0,

            /// <summary>
            /// Do not validate the public portion of the key pair.
            /// </summary>
            BCRYPT_NO_KEY_VALIDATION = 0x00000008,
        }
    }
}
