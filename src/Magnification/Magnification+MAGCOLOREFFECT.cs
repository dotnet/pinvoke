// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Runtime.InteropServices;

    /// <content>
    /// Contains the <see cref="MAGCOLOREFFECT"/> nested type.
    /// </content>
    public partial class Magnification
    {
        /// <summary>
        /// Describes a color transformation matrix that a magnifier control uses to apply a color effect to magnified screen content.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public unsafe struct MAGCOLOREFFECT
        {
            /// <summary>
            /// The transformation matrix. Always 5x5.
            /// </summary>
            private fixed float transform[5 * 5];
        }
    }
}
