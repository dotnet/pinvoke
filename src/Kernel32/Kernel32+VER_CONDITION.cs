// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PInvoke
{
    /// <summary>
    /// Contains the nested type <see cref="VER_CONDITION"/>.
    /// </summary>
    public static partial class Kernel32
    {
        /// <summary>
        /// The operator to be used for the comparison. The <see cref="VerifyVersionInfo(OSVERSIONINFOEX*, VER_MASK, long)"/> function uses this operator to compare a specified
        /// attribute value to the corresponding value for the currently running system.
        /// </summary>
        /// <remarks>
        /// For all values of dwTypeBitMask other than VER_SUITENAME, this parameter can be one of the following values:
        ///     - <see cref="VER_EQUAL"/>
        ///     - <see cref="VER_GREATER"/>
        ///     - <see cref="VER_GREATER_EQUAL"/>
        ///     - <see cref="VER_LESS"/>
        ///     - <see cref="VER_LESS_EQUAL"/>
        /// If dwTypeBitMask is VER_SUITENAME, this parameter can be one of the following values:
        ///     - <see cref="VER_AND"/>
        ///     - <see cref="VER_OR"/>.
        /// </remarks>
        public enum VER_CONDITION : byte
        {
            /// <summary>
            /// The current value must be equal to the specified value.
            /// </summary>
            VER_EQUAL = 1,

            /// <summary>
            /// The current value must be greater than the specified value.
            /// </summary>
            VER_GREATER = 2,

            /// <summary>
            /// The current value must be greater than or equal to the specified value.
            /// </summary>
            VER_GREATER_EQUAL = 3,

            /// <summary>
            /// The current value must be less than the specified value.
            /// </summary>
            VER_LESS = 4,

            /// <summary>
            /// The current value must be less than or equal to the specified value.
            /// </summary>
            VER_LESS_EQUAL = 5,

            /// <summary>
            /// All product suites specified in the wSuiteMask member must be present in the current system.
            /// </summary>
            VER_AND = 6,

            /// <summary>
            /// At least one of the specified product suites must be present in the current system.
            /// </summary>
            VER_OR = 7,
        }
    }
}
