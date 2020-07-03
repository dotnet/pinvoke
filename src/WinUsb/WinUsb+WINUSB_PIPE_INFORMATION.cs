// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PInvoke
{
    using System;

    /// <content>
    /// Contains the nested <see cref="WINUSB_PIPE_INFORMATION"/> type.
    /// </content>
    public static partial class WinUsb
    {
        /// <summary>
        /// Contains pipe information that the <see cref="WinUsb.WinUsb_QueryPipe(SafeUsbHandle, byte, byte, WINUSB_PIPE_INFORMATION*)"/> routine retrieves.
        /// </summary>
        /// <seealso href="https://docs.microsoft.com/en-us/windows/win32/api/winusbio/ns-winusbio-winusb_pipe_information"/>
        public struct WINUSB_PIPE_INFORMATION
        {
            /// <summary>
            /// A value that specifies the pipe type.
            /// </summary>
            public USBD_PIPE_TYPE PipeType;

            /// <summary>
            /// The pipe identifier (ID).
            /// </summary>
            public byte PipeId;

            /// <summary>
            /// The maximum size, in bytes, of the packets that are transmitted on the pipe.
            /// </summary>
            public ushort MaximumPacketSize;

            /// <summary>
            /// The pipe interval.
            /// </summary>
            public byte Interval;
        }
    }
}
