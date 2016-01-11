// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    /// <content>
    /// The <see cref="SeverityCode"/> nested type.
    /// </content>
    public partial struct HResult
    {
        /// <summary>
        /// HRESULT severity codes defined by winerror.h
        /// </summary>
        public enum SeverityCode : uint
        {
            Success = 0,
            Fail = 0x80000000,
        }
    }
}
