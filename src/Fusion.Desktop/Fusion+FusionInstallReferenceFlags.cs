// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;

    /// <content>
    /// Contains the <see cref="FusionInstallReferenceFlags"/> nested type.
    /// </content>
    public partial class Fusion
    {
        /// <summary>
        /// Flags that may be specified by <see cref="FUSION_INSTALL_REFERENCE.dwFlags"/>.
        /// </summary>
        [Flags]
        public enum FusionInstallReferenceFlags
        {
            /// <summary>
            /// No flags.
            /// </summary>
            None = 0x0,
        }
    }
}
