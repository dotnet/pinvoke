// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Runtime.InteropServices;

    /// <content>
    /// Contains the <see cref="MAGTRANSFORM"/> nested type.
    /// </content>
    public partial class Magnification
    {
        /// <summary>
        /// Describes a transformation matrix that a magnifier control uses to magnify screen content.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public unsafe struct MAGTRANSFORM
        {
            /// <summary>
            /// The transformation matrix. Always 3x3.
            /// </summary>
            private fixed float v[3 * 3];
        }
    }
}
