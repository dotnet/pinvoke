// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;

    /// <content>
    /// Contains the <see cref="NCryptCreatePersistedKeyFlags"/> nested type.
    /// </content>
    public static partial class NCrypt
    {
        /// <summary>
        /// Flags that may be passed to the <see cref="NCryptCreatePersistedKey(SafeProviderHandle, out SafeKeyHandle, string, string, LegacyKeySpec, NCryptCreatePersistedKeyFlags)"/> method.
        /// </summary>
        [Flags]
        public enum NCryptCreatePersistedKeyFlags
        {
            /// <summary>
            /// No flags.
            /// </summary>
            None = 0x0,

            /// <summary>
            /// The key applies to the local computer. If this flag is not present, the key applies to the current user.
            /// </summary>
            NCRYPT_MACHINE_KEY_FLAG = 0x20,

            /// <summary>
            /// If a key already exists in the container with the specified name, the existing key will be overwritten. If this flag is not specified and a key with the specified name already exists, this function will return <see cref="SECURITY_STATUS.NTE_EXISTS"/>.
            /// </summary>
            NCRYPT_OVERWRITE_KEY_FLAG = 0x80,
        }
    }
}
