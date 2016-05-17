// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Runtime.InteropServices;

    /// <content>
    /// Contains the <see cref="CRYPT_KEY_PROV_INFO"/> nested type.
    /// </content>
    public partial class Crypt32
    {
        /// <summary>
        /// The CRYPT_KEY_PROV_INFO structure contains information about a key container within a cryptographic service provider (CSP).
        /// </summary>
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        [OfferIntPtrPropertyAccessors]
        public unsafe partial struct CRYPT_KEY_PROV_INFO
        {
            /// <summary>
            /// A pointer to a null-terminated Unicode string that contains the name of the key container.
            /// </summary>
            public char* pwszContainerName;

            /// <summary>
            /// A pointer to a null-terminated Unicode string that contains the name of the CSP.
            /// </summary>
            public char* pwszProvName;

            /// <summary>
            /// Specifies the CSP type.
            /// </summary>
            public CRYPT_PROV_TYPE dwProvType;

            /// <summary>
            /// A set of flags that indicate additional information about the provider.
            /// </summary>
            public uint dwFlags;

            /// <summary>
            /// The number of elements in the <see cref="rgProvParam"/> array.
            /// </summary>
            public uint cProvParam;

            /// <summary>
            /// An array of CRYPT_KEY_PROV_PARAM structures that contain the parameters for the key container
            /// </summary>
            public IntPtr rgProvParam;

            /// <summary>
            /// The specification of the private key to retrieve.
            /// </summary>
            public uint dwKeySpec;

            /// <summary>
            /// Gets the name of the key container.
            /// </summary>
            public string ContainerName => new string(this.pwszContainerName);

            /// <summary>
            /// Gets the name of the CSP.
            /// </summary>
            public string ProvName => new string(this.pwszProvName);
        }
    }
}
