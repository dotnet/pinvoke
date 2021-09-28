// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Buffers;
    using System.Runtime.InteropServices;
    using System.Threading;
    using System.Threading.Tasks;

    /// <content>
    /// Contains the nested <see cref="WinUsbOverlapped"/> type.
    /// </content>
    public static partial class WinUsb
    {
        /// <summary>
        /// A managed implementation of the <see cref="Kernel32.OVERLAPPED"/> structure, used to support overlapped WinUSB I/O.
        /// </summary>
        private class WinUsbOverlapped : Overlapped
        {
            private readonly SafeUsbHandle handle;
            private readonly byte pipeID;
            private readonly CancellationToken cancellationToken;

            /// <summary>
            /// The source for completing the <see cref="Completion"/> property.
            /// </summary>
            private readonly TaskCompletionSource<int> completion = new TaskCompletionSource<int>();

            private unsafe NativeOverlapped* native;
            private CancellationTokenRegistration cancellationTokenRegistration;

            /// <summary>
            /// Initializes a new instance of the <see cref="WinUsbOverlapped"/> class.
            /// </summary>
            /// <param name="handle">
            /// A handle to the WinUSB device on which the I/O is being performed.
            /// </param>
            /// <param name="pipeID">
            /// The ID of the pipe on which the I/O is being performed.
            /// </param>
            /// <param name="bufferHandle">
            /// A handle to the buffer which is used by the I/O operation. This buffer will be pinned for the duration of
            /// the operation.
            /// </param>
            /// <param name="cancellationToken">
            /// A <see cref="CancellationToken"/> which can be used to cancel the overlapped I/O.
            /// </param>
            public WinUsbOverlapped(SafeUsbHandle handle, byte pipeID, MemoryHandle bufferHandle, CancellationToken cancellationToken)
            {
                this.handle = handle ?? throw new ArgumentNullException(nameof(handle));
                this.pipeID = pipeID;
                this.BufferHandle = bufferHandle;
                this.cancellationToken = cancellationToken;
            }

            /// <summary>
            /// Gets a <see cref="MemoryHandle"/> to the transfer buffer.
            /// </summary>
            internal MemoryHandle BufferHandle { get; private set; }

            /// <summary>
            /// Gets the amount of bytes transferred.
            /// </summary>
            internal uint BytesTransferred { get; private set; }

            /// <summary>
            /// Gets the error code returned by the device driver.
            /// </summary>
            internal uint ErrorCode { get; private set; }

            /// <summary>
            /// Gets a task whose result is the number of bytes transferred, or faults with the <see cref="Win32Exception"/> describing the failure.
            /// </summary>
            internal Task<int> Completion => this.completion.Task;

            /// <summary>
            /// Packs the current <see cref="WinUsbOverlapped"/> into a <see cref="NativeOverlapped"/> structure.
            /// </summary>
            /// <returns>
            /// An unmanaged pointer to a <see cref="NativeOverlapped"/> structure.
            /// </returns>
            internal unsafe NativeOverlapped* Pack()
            {
                this.native = this.Pack(
                    this.DeviceIOControlCompletionCallback,
                    null);

                this.cancellationTokenRegistration = this.cancellationToken.Register(this.Cancel);

                return this.native;
            }

            /// <summary>
            /// Unpacks the unmanaged <see cref="NativeOverlapped"/> structure into
            /// a managed <see cref="WinUsbOverlapped"/> object.
            /// </summary>
            internal unsafe void Unpack()
            {
                Overlapped.Unpack(this.native);
                Overlapped.Free(this.native);
                this.native = null;

                this.cancellationTokenRegistration.Dispose();
                this.BufferHandle.Dispose();
            }

            /// <summary>
            /// Cancels the asynchronous I/O operation.
            /// </summary>
            internal unsafe void Cancel()
            {
                if (!WinUsb_AbortPipe(
                    this.handle,
                    this.pipeID))
                {
                    throw new Win32Exception(Marshal.GetLastWin32Error());
                }
            }

            private unsafe void DeviceIOControlCompletionCallback(uint errorCode, uint numberOfBytesTransferred, NativeOverlapped* nativeOverlapped)
            {
                this.Unpack();

                this.BytesTransferred = numberOfBytesTransferred;
                this.ErrorCode = errorCode;

                if (this.ErrorCode != 0)
                {
                    this.completion.SetException(
                        new Win32Exception((int)this.ErrorCode));
                }
                else
                {
                    this.completion.SetResult((int)numberOfBytesTransferred);
                }
            }
        }
    }
}
