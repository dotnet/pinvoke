// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;

    /// <content>
    /// Contains the <see cref="BCryptCloseAlgorithmProviderFlags"/> nested type.
    /// </content>
    public partial class BCrypt
    {
        [Flags]
        public enum BCryptCloseAlgorithmProviderFlags
        {
            None = 0x0,
        }
    }
}
