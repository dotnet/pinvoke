// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    /// <content>
    /// Contains the <see cref="SC_STATUS_TYPE"/> nested type.
    /// </content>
    public partial class AdvApi32
    {
        /// <summary>
        /// Specifies the information level for the <see cref="QueryServiceStatusEx(SafeServiceHandle, SC_STATUS_TYPE, void*, int, out int)"/> method.
        /// </summary>
        public enum SC_STATUS_TYPE
        {
            /// <summary>
            /// Retrieves the service status information.
            /// </summary>
            SC_STATUS_PROCESS_INFO = 0,
        }
    }
}
