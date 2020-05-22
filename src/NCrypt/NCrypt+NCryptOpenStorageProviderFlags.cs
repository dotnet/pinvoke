// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

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
