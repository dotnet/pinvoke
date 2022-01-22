// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Runtime.InteropServices;
    using System.Threading;
    using System.Threading.Tasks;

    /// <content>
    /// Methods and nested types that are not strictly P/Invokes but provide
    /// a slightly higher level of functionality to ease calling into native code.
    /// </content>
    public static partial class WinUsb
    {
        /// <summary>
        /// Asynchronously reads data from the specified pipe.
        /// </summary>
        /// <param name="interfaceHandle">
        /// An opaque handle to the interface that contains the endpoint with which the pipe is associated.
        /// </param>
        /// <param name="pipeID">
        /// <paramref name="pipeID"/> corresponds to the bEndpointAddress field in the endpoint descriptor.
        /// </param>
        /// <param name="buffer">
        /// A caller-allocated buffer that receives the data that is read.
        /// </param>
        /// <param name="cancellationToken">
        /// A <see cref="CancellationToken"/> which can be used to cancel the asynchronous operation.
        /// </param>
        /// <returns>
        /// A <see cref="ValueTask"/> which represents the asynchronous operation, and returns the number of bytes transferred.
        /// </returns>
        public static unsafe ValueTask<int> WinUsb_ReadPipeAsync(SafeUsbHandle interfaceHandle, byte pipeID, Memory<byte> buffer, CancellationToken cancellationToken)
        {
            var overlapped = new WinUsbOverlapped(interfaceHandle, pipeID, buffer.Pin(), cancellationToken);
            NativeOverlapped* nativeOverlapped = overlapped.Pack();

            if (WinUsb_ReadPipe(
                interfaceHandle,
                pipeID,
                (byte*)overlapped.BufferHandle.Pointer,
                buffer.Length,
                out int lengthTransferred,
                nativeOverlapped))
            {
                overlapped.Unpack();
                return new ValueTask<int>(lengthTransferred);
            }
            else
            {
                var error = (Win32ErrorCode)Marshal.GetLastWin32Error();

                if (error == Win32ErrorCode.ERROR_IO_PENDING)
                {
                    return new ValueTask<int>(overlapped.Completion);
                }
                else
                {
                    overlapped.Unpack();

#if NET45
                    return new ValueTask<int>(Task.Run(new Func<int>(() => throw new Win32Exception(error))));
#else
                    return new ValueTask<int>(Task.FromException<int>(new PInvoke.Win32Exception(error)));
#endif
                }
            }
        }

        /// <summary>
        /// Asynchronously writes data to a pipe.
        /// </summary>
        /// <param name="interfaceHandle">
        /// An opaque handle to the interface that contains the endpoint with which the pipe is associated.
        /// </param>
        /// <param name="pipeID">
        /// PipeID corresponds to the bEndpointAddress field in the endpoint descriptor.
        /// </param>
        /// <param name="buffer">
        /// A caller-allocated buffer that contains the data to write.
        /// </param>
        /// <param name="cancellationToken">
        /// A <see cref="CancellationToken"/> which can be used to cancel the asynchronous operation.
        /// </param>
        /// <returns>
        /// A <see cref="ValueTask"/> which represents the asynchronous operation, and returns the number of bytes transferred.
        /// </returns>
        public static unsafe ValueTask<int> WinUsb_WritePipeAsync(SafeUsbHandle interfaceHandle, byte pipeID, ReadOnlyMemory<byte> buffer, CancellationToken cancellationToken)
        {
            var overlapped = new WinUsbOverlapped(interfaceHandle, pipeID, buffer.Pin(), cancellationToken);
            NativeOverlapped* nativeOverlapped = overlapped.Pack();

            if (WinUsb_WritePipe(
                interfaceHandle,
                pipeID,
                (byte*)overlapped.BufferHandle.Pointer,
                buffer.Length,
                out int lengthTransferred,
                nativeOverlapped))
            {
                overlapped.Unpack();
                return new ValueTask<int>(lengthTransferred);
            }
            else
            {
                var error = (Win32ErrorCode)Marshal.GetLastWin32Error();

                if (error == Win32ErrorCode.ERROR_IO_PENDING)
                {
                    return new ValueTask<int>(overlapped.Completion);
                }
                else
                {
                    overlapped.Unpack();

#if NET45
                    return new ValueTask<int>(Task.Run(new Func<int>(() => throw new Win32Exception(error))));
#else
                    return new ValueTask<int>(Task.FromException<int>(new PInvoke.Win32Exception(error)));
#endif
                }
            }
        }
    }
}
