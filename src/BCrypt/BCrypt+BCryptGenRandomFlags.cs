// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;

    /// <content>
    /// Contains the <see cref="BCryptGenRandomFlags"/> nested type.
    /// </content>
    public partial class BCrypt
    {
        [Flags]
        public enum BCryptGenRandomFlags
        {
            None = 0x0,

            /// <summary>
            /// This function will use the number in the pbBuffer buffer as additional entropy for the random number. If this flag is not specified, this function will use a random number for the entropy.
            /// Windows 8 and later:  This flag is ignored in Windows 8 and later.
            /// </summary>
            UseEntropyInBuffer = 0x1,

            /// <summary>
            /// Use the system-preferred random number generator algorithm. The hAlgorithm parameter must be NULL.
            /// <see cref="UseSystemPreferredRNG"/> is only supported at PASSIVE_LEVEL IRQL. For more information, see Remarks.
            /// Windows Vista:  This flag is not supported.
            /// </summary>
            UseSystemPreferredRNG = 0x2,
        }
    }
}
