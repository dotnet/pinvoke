// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PInvoke
{
    /// <content>
    /// Contains the <see cref="NOTIFICATIONTYPE"/> nested type.
    /// </content>
    public partial class Cabinet
    {
        /// <summary>
        /// Type of notification message for the FDI Notify callback.
        /// </summary>
        public enum NOTIFICATIONTYPE : int
        {
            /// <summary>
            /// The notification contains cabinet information.
            /// </summary>
            CABINET_INFO,

            /// <summary>
            /// The notifications contains a partial file.
            /// </summary>
            PARTIAL_FILE,

            /// <summary>
            /// The notification contains the copy fo a file.
            /// </summary>
            COPY_FILE,

            /// <summary>
            /// The notification is a request to close file information.
            /// </summary>
            CLOSE_FILE_INFO,

            /// <summary>
            /// The notification contains the next cabinet.
            /// </summary>
            NEXT_CABINET,

            /// <summary>
            /// The notification is a request to enumerate.
            /// </summary>
            ENUMERATE,
        }
    }
}
