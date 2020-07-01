// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PInvoke
{
    using System.Runtime.InteropServices;

    /// <content>
    /// Contains the <see cref="MODULEINFO"/> nested type.
    /// </content>
    public static partial class Psapi
    {
        /// <summary>
        /// The MODULEINFO structure specifies processmodules properties.
        /// </summary>
        [OfferIntPtrPropertyAccessors]
        public unsafe partial struct MODULEINFO
        {
            /// <summary>
            /// The base address of the module
            /// </summary>
            public void* lpBaseOfDll;

            /// <summary>
            /// The size of the module
            /// </summary>
            public int SizeOfImage;

            /// <summary>
            /// The entry point of the module
            /// </summary>
            public void* EntryPoint;
        }
    }
}
