// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System.Runtime.InteropServices;

    /// <content>
    /// Contains the <see cref="NCryptProviderName"/> nested type.
    /// </content>
    public partial class NCrypt
    {
        /// <summary>
        /// Contains the name of a CNG key storage provider. This structure is used with the <see cref="NCryptEnumStorageProviders(out int, out NCryptProviderName*, NCryptEnumStorageProvidersFlags)"/> function to return the names of the registered CNG key storage providers.
        /// </summary>
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        [OfferIntPtrPropertyAccessors]
        public unsafe partial struct NCryptProviderName
        {
            /// <summary>
            /// A pointer to a null-terminated Unicode string that contains the name of the provider.
            /// </summary>
            public char* pszName;

            /// <summary>
            /// A pointer to a null-terminated Unicode string that contains optional text for the provider.
            /// </summary>
            public char* pszComment;

            /// <summary>
            /// Gets the name of the provider.
            /// </summary>
            public string Name => new string(this.pszName);

            /// <summary>
            /// Gets optional text for the provider.
            /// </summary>
            public string Comment => new string(this.pszComment);
        }
    }
}
