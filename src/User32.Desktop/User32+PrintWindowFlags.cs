// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    /// <content>
    /// Contains the <see cref="PrintWindow"/> nested type.
    /// </content>
    public partial class User32
    {
        [SuppressMessage("ReSharper", "InconsistentNaming", Justification = "Original API names are used for consistency")]
        public enum PrintWindowFlags : uint
        {
            /// <summary>
            ///     Default option. The entire window is copied to hdcBlt.
            /// </summary>
            PW_FULLWINDOW = 0x0000,

            /// <summary>
            ///     Only the client area of the window is copied to hdcBlt.
            /// </summary>
            /// <remarks>By default, the entire window is copied.</remarks>
            PW_CLIENTONLY = 0x0001,
        }
    }
}
