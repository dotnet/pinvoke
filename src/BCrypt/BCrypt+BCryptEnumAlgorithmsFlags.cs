// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;

    /// <content>
    /// Contains the <see cref="BCryptEnumAlgorithmsFlags"/> nested type.
    /// </content>
    public partial class BCrypt
    {
        /// <summary>
        /// Flags that can be passed to the <see cref="BCryptEnumAlgorithms(AlgorithmOperations, out int, out BCRYPT_ALGORITHM_IDENTIFIER*, BCryptEnumAlgorithmsFlags)"/> method.
        /// </summary>
        [Flags]
        public enum BCryptEnumAlgorithmsFlags
        {
            /// <summary>
            /// No flags.
            /// </summary>
            None = 0x0,
        }
    }
}
