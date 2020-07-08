// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

#if NETSTANDARD2_1
namespace PInvoke
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;

    /// <content>
    /// Methods and nested types that are not strictly P/Invokes but provide
    /// a slightly higher level of functionality to ease calling into native code.
    /// </content>
    public static partial class Kernel32
    {
        public static unsafe Task<int> DeviceIoControlAsync(
            SafeObjectHandle hDevice,
            int dwIoControlCode,
            Memory<byte> inBuffer,
            Memory<byte> outBuffer,
            CancellationToken cancellationToken)
        {
            var overlapped = new DeviceIOControlOverlapped(inBuffer, outBuffer);
            var nativeOverlapped = overlapped.Pack();

            bool result = Kernel32.DeviceIoControl(
                hDevice: hDevice,
                dwIoControlCode: dwIoControlCode,
                inBuffer: overlapped.InputHandle.Pointer,
                nInBufferSize: inBuffer.Length,
                outBuffer: overlapped.OutputHandle.Pointer,
                nOutBufferSize: outBuffer.Length,
                out int bytesReturned,
                (OVERLAPPED*)nativeOverlapped);

            if (result)
            {
                // The operation completed synchronously
                overlapped.Unpack();
                return Task.FromResult(bytesReturned);
            }
            else
            {
                var error = (Win32ErrorCode)Marshal.GetLastWin32Error();

                if (error != Win32ErrorCode.ERROR_IO_PENDING)
                {
                    overlapped.Unpack();
                    return Task.FromException<int>(new PInvoke.Win32Exception(error));
                }
                else
                {
                    return overlapped.OnCompleted.Task;
                }
            }
        }
    }
}
#endif
