// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    /// <content>
    /// The <see cref="SeverityCodes"/> nested type.
    /// </content>
    public partial struct NTStatus
    {
        /// <summary>
        /// The <see cref="NTStatus"/> facility codes.
        /// </summary>
        public enum SeverityCodes : uint
        {
            STATUS_SEVERITY_SUCCESS = 0x0,
            STATUS_SEVERITY_INFORMATIONAL = 0x1,
            STATUS_SEVERITY_WARNING = 0x2,
            STATUS_SEVERITY_ERROR = 0x3,
        }
    }
}
