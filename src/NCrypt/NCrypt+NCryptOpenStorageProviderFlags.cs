// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;

    /// <content>
    /// Contains the <see cref="NCryptOpenStorageProviderFlags"/> nested type.
    /// </content>
    public partial class NCrypt
    {
        /// <summary>
        /// Flags that may be passed to the <see cref="NCryptOpenStorageProvider(out SafeProviderHandle, string, NCryptOpenStorageProviderFlags)"/> function.
        /// </summary>
        [Flags]
        public enum NCryptOpenStorageProviderFlags
        {
            /// <summary>
            /// No flags.
            /// </summary>
            None = 0x0,
        }
    }
}
