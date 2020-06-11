// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PInvoke
{
    using System;

    /// <content>
    /// Contains the <see cref="BCryptGenerateKeyPairFlags"/> nested type.
    /// </content>
    public partial class BCrypt
    {
        [Flags]
        public enum BCryptGenerateKeyPairFlags
        {
            None = 0x0,
        }
    }
}
