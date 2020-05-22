// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PInvoke
{
    using System;

    /// <content>
    /// Contains the <see cref="BCryptGenerateSymmetricKeyFlags"/> nested type.
    /// </content>
    public partial class BCrypt
    {
        /// <summary>
        /// Flags that may be passed to the <see cref="BCryptGenerateSymmetricKey(SafeAlgorithmHandle, byte[], byte[], BCryptGenerateSymmetricKeyFlags)"/> method.
        /// </summary>
        [Flags]
        public enum BCryptGenerateSymmetricKeyFlags
        {
            None = 0x0,
        }
    }
}
