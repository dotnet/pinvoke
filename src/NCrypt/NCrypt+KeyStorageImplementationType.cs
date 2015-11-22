// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;

    /// <content>
    /// Contains the <see cref="KeyStorageImplementationType"/> nested type.
    /// </content>
    public static partial class NCrypt
    {
        /// <summary>
        /// Describes the key storage implementation types that may be returned by the
        /// <see cref="KeyStoragePropertyIdentifiers.NCRYPT_IMPL_TYPE_PROPERTY"/> property.
        /// </summary>
        [Flags]
        public enum KeyStorageImplementationType
        {
            /// <summary>
            /// The provider is hardware based.
            /// </summary>
            NCRYPT_IMPL_HARDWARE_FLAG = 0x1,

            /// <summary>
            /// The provider is software based.
            /// </summary>
            NCRYPT_IMPL_SOFTWARE_FLAG = 0x2,

            /// <summary>
            /// The provider is removable.
            /// </summary>
            NCRYPT_IMPL_REMOVABLE_FLAG = 0x8,

            /// <summary>
            /// The provider is a hardware based random number generator.
            /// </summary>
            NCRYPT_IMPL_HARDWARE_RNG_FLAG = 0x10,
        }
    }
}
