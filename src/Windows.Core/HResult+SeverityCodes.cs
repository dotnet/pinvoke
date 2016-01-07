// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    /// <content>
    /// The <see cref="SeverityCodes"/> nested type.
    /// </content>
    public partial struct HResult
    {
        /// <summary>
        /// HRESULT severity codes defined by winerror.h
        /// </summary>
        internal static class SeverityCodes
        {
            public const int Success = 0;
            public const int Fail = 1;
        }
    }
}
