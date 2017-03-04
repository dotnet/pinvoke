// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System.Runtime.InteropServices;

    /// <content>
    /// Contains the <see cref="BCRYPT_ALGORITHM_IDENTIFIER"/> nested type.
    /// </content>
    public partial class BCrypt
    {
        /// <summary>
        /// Used with the <see cref="BCryptEnumAlgorithms(AlgorithmOperations, out int, out BCRYPT_ALGORITHM_IDENTIFIER*, BCryptEnumAlgorithmsFlags)"/> function to contain a cryptographic algorithm identifier.
        /// </summary>
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        [OfferIntPtrPropertyAccessors]
        public unsafe partial struct BCRYPT_ALGORITHM_IDENTIFIER
        {
            /// <summary>
            /// A pointer to a null-terminated Unicode string that contains the string identifier of the algorithm. The <see cref="AlgorithmIdentifiers"/> class contains the predefined algorithm identifiers.
            /// </summary>
            public char* pszName;

            /// <summary>
            /// Specifies the class of the algorithm.
            /// </summary>
            public InterfaceIdentifiers dwClass;

            /// <summary>
            /// A set of flags that specify other information about the algorithm.
            /// </summary>
            public Flags dwFlags;

            /// <summary>
            /// Flags for the <see cref="dwFlags"/> field.
            /// </summary>
            public enum Flags : uint
            {
                /// <summary>
                /// No flags.
                /// </summary>
                None = 0,
            }

            /// <summary>
            /// Gets the string identifier of the algorithm. The <see cref="AlgorithmIdentifiers"/> class contains the predefined algorithm identifiers.
            /// </summary>
            public string Name => new string(this.pszName);
        }
    }
}
