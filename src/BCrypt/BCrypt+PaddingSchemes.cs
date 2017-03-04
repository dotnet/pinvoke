// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    /// <content>
    /// Contains the <see cref="PaddingSchemes"/> nested type.
    /// </content>
    public partial class BCrypt
    {
        /// <summary>
        /// Possible values for the <see cref="PropertyNames.BCRYPT_PADDING_SCHEMES"/> property.
        /// </summary>
        public enum PaddingSchemes
        {
            /// <summary>
            /// The provider supports padding added by the router.
            /// </summary>
            Router = 0x1,

            /// <summary>
            /// The provider supports the PKCS1 encryption padding scheme.
            /// </summary>
            Pkcs1Encryption = 0x2,

            /// <summary>
            /// The provider supports the PKCS1 signature padding scheme.
            /// </summary>
            Pkcs1Signature = 0x4,

            /// <summary>
            /// The provider supports the OAEP padding scheme.
            /// </summary>
            Oaep = 0x8,

            /// <summary>
            /// The provider supports the PSS padding scheme.
            /// </summary>
            Pss = 0x10,
        }
    }
}
