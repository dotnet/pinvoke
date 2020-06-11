// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PInvoke
{
    using System;

    /// <content>
    /// Contains the <see cref="BCryptFinishHashFlags"/> nested type.
    /// </content>
    public partial class BCrypt
    {
        /// <summary>
        /// Flags that can be passed to the <see cref="BCryptFinishHash(SafeHashHandle, byte[], int, BCryptFinishHashFlags)"/> method.
        /// </summary>
        [Flags]
        public enum BCryptFinishHashFlags
        {
            None = 0x0,
        }
    }
}
