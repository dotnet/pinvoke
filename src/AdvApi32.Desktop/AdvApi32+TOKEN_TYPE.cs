// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <content>
    /// Exported functions from the AdvApi32.dll Windows library
    /// that are available to Desktop apps only.
    /// </content>
    public static partial class AdvApi32
    {
        /// <summary>
        /// The <see cref="TOKEN_TYPE"/> enumeration contains values that differentiate between a primary token and an
        /// impersonation token.
        /// </summary>
        public enum TOKEN_TYPE
        {
            /// <summary>
            ///     The new token is a primary token that you can use in the CreateProcessAsUser function.
            /// </summary>
            TokenPrimary = 1,

            /// <summary>
            /// The new token is an impersonation token.
            /// </summary>
            TokenImpersonation
        }
    }
}