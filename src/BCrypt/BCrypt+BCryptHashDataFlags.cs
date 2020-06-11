// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PInvoke
{
    using System;

    /// <content>
    /// Contains the <see cref="BCryptHashDataFlags"/> nested type.
    /// </content>
    public partial class BCrypt
    {
        /// <summary>
        /// Flags that can be passed to the <see cref="BCryptHashData(SafeHashHandle, byte[], int, BCryptHashDataFlags)"/> method.
        /// </summary>
        [Flags]
        public enum BCryptHashDataFlags
        {
            None = 0x0,
        }
    }
}
