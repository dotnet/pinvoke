// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PInvoke
{
    /// <content>
    /// Contains the nested <see cref="USBD_PIPE_TYPE"/> type.
    /// </content>
    public static partial class WinUsb
    {
        /// <summary>
        /// Indicates the type of an USB pipe.
        /// </summary>
        /// <seealso href="https://docs.microsoft.com/en-us/windows-hardware/drivers/ddi/usb/ne-usb-_usbd_pipe_type"/>
        public enum USBD_PIPE_TYPE : int
        {
            /// <summary>
            /// Indicates that the pipe is a control pipe.
            /// </summary>
            Control = 0,

            /// <summary>
            /// Indicates that the pipe is an isochronous transfer pipe.
            /// </summary>
            Isochronous,

            /// <summary>
            /// Indicates that the pipe is a bulk transfer pipe.
            /// </summary>
            Bulk,

            /// <summary>
            /// Indicates that the pipe is a interrupt pipe.
            /// </summary>
            Interrupt,
        }
    }
}
