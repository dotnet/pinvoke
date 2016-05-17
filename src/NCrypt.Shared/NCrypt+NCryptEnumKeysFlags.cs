// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;

    /// <content>
    /// Contains the <see cref="NCryptEnumKeysFlags"/> nested type.
    /// </content>
    public partial class NCrypt
    {
        /// <summary>
        /// The flags that may be passed to the <see cref="NCryptEnumKeys(SafeProviderHandle, string, out NCryptKeyName*, ref void*, NCryptEnumKeysFlags)"/> method.
        /// </summary>
        [Flags]
        public enum NCryptEnumKeysFlags : uint
        {
            /// <summary>
            /// No flags.
            /// </summary>
            None = 0x0,

            NCRYPT_MACHINE_KEY_FLAG = 0x00000020,
        }
    }
}
