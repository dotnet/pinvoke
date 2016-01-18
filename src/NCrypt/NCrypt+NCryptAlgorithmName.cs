// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System.Runtime.InteropServices;

    /// <content>
    /// Contains the <see cref="NCryptAlgorithmName"/> nested type.
    /// </content>
    public partial class NCrypt
    {
        /// <summary>
        /// The NCryptAlgorithmName structure is used to contain information about a CNG algorithm.
        /// </summary>
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        [OfferIntPtrPropertyAccessors]
        public unsafe partial struct NCryptAlgorithmName
        {
            /// <summary>
            /// A pointer to a null-terminated Unicode string that contains the name of the algorithm. This can be one of the standard <see cref="BCrypt.AlgorithmIdentifiers"/> or the identifier for another registered algorithm.
            /// </summary>
            public char* pszName;

            /// <summary>
            /// A DWORD value that defines which algorithm class this algorithm belongs to.
            /// </summary>
            public InterfaceIdentifiers dwClass;

            /// <summary>
            /// A DWORD value that defines which operational classes this algorithm belongs to. This can be a combination of one or more of the following values:
            /// <see cref="AlgorithmOperations.NCRYPT_ASYMMETRIC_ENCRYPTION_OPERATION"/>
            /// <see cref="AlgorithmOperations.NCRYPT_SECRET_AGREEMENT_OPERATION"/>
            /// <see cref="AlgorithmOperations.NCRYPT_SIGNATURE_OPERATION"/>
            /// </summary>
            public AlgorithmOperations dwAlgOperations;

            /// <summary>
            /// A set of flags that provide more information about the algorithm.
            /// </summary>
            public uint dwFlags;

            /// <summary>
            /// Gets the name of the algorithm. This can be one of the standard <see cref="BCrypt.AlgorithmIdentifiers"/> or the identifier for another registered algorithm.
            /// </summary>
            public string Name => new string(this.pszName);
        }
    }
}
