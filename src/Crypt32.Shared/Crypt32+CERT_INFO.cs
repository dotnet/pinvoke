// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System.Runtime.InteropServices;

    /// <content>
    /// Contains the <see cref="CERT_INFO"/> nested type.
    /// </content>
    public partial class Crypt32
    {
        /// <summary>
        /// Certificate property identifiers.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        [OfferIntPtrPropertyAccessors]
        public unsafe partial struct CERT_INFO
        {
            public uint dwVersion;

            // TODO:
        }
    }
}
