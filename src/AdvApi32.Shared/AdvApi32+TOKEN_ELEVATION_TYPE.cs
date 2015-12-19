// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    /// <content>
    /// Contains the <see cref="TOKEN_ELEVATION_TYPE"/> nested type.
    /// </content>
    public partial class AdvApi32
    {
        /// <summary>
        /// Indicates the elevation type of token being queried by the <see cref="GetTokenInformation(Kernel32.SafeObjectHandle, TOKEN_INFORMATION_CLASS, void*, int, out int)"/> function.
        /// </summary>
        public enum TOKEN_ELEVATION_TYPE
        {
            /// <summary>
            /// Standard user that don't require UAC as he doesn't have any elevated attributes in it's
            /// security token.
            /// </summary>
            TokenElevationTypeDefault = 1,

            /// <summary>
            /// Process executing with full elevated rights, either UAC is disable or the process is
            /// executing in "Run as administrator" mode.
            /// </summary>
            TokenElevationTypeFull,

            /// <summary>
            /// Process executing under UAC, the current user got some elevated right but they can't
            /// be used in the process as the token is "split".
            /// </summary>
            TokenElevationTypeLimited
        }
    }
}
