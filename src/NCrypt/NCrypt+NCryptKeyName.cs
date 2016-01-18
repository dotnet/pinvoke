// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Runtime.InteropServices;

    /// <content>
    /// Contains the <see cref="NCryptKeyName"/> nested type.
    /// </content>
    public partial class NCrypt
    {
        /// <summary>
        /// Contains information about a CNG key.
        /// </summary>
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        [OfferIntPtrPropertyAccessors]
        public unsafe partial struct NCryptKeyName
        {
            /// <summary>
            /// A pointer to a null-terminated Unicode string that contains the name of the key.
            /// </summary>
            public char* pszName;

            /// <summary>
            /// A pointer to a null-terminated Unicode string that contains the identifier of the cryptographic algorithm that the key was created with. This can be one of the standard <see cref="BCrypt.AlgorithmIdentifiers"/> or the identifier for another registered algorithm.
            /// </summary>
            public char* pszAlgid;

            /// <summary>
            /// A legacy identifier that specifies the type of key
            /// </summary>
            public LegacyKeySpec dwLegacyKeySpec;

            /// <summary>
            /// A set of flags that provide more information about the key.
            /// </summary>
            public Flags dwFlags;

            /// <summary>
            /// Possible flags for the <see cref="dwFlags"/> field.
            /// </summary>
            [Flags]
            public enum Flags : uint
            {
                /// <summary>
                /// The key applies to the local computer. If this flag is not present, the key applies to the current user.
                /// </summary>
                NCRYPT_MACHINE_KEY_FLAG = 0x20,
            }

            /// <summary>
            /// Gets the name of the key.
            /// </summary>
            public string Name => new string(this.pszName);

            /// <summary>
            /// Gets the identifier of the cryptographic algorithm that the key was created with. This can be one of the standard <see cref="BCrypt.AlgorithmIdentifiers"/> or the identifier for another registered algorithm.
            /// </summary>
            public string Algid => new string(this.pszAlgid);
        }
    }
}
