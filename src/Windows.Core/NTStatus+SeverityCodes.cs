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
            STATUS_SEVERITY_SUCCESS = 0x0 << SeverityShift,
            STATUS_SEVERITY_INFORMATIONAL = 0x1 << SeverityShift,
            STATUS_SEVERITY_WARNING = 0x2u << SeverityShift,
            STATUS_SEVERITY_ERROR = 0x3u << SeverityShift,
        }
    }
}
