// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

#if NETSTANDARD2_1
namespace PInvoke
{
    using System;
    using System.Buffers;
    using System.Threading;
    using System.Threading.Tasks;

    /// <content>
    /// Contains the <see cref="CreateFileFlags"/> nested type.
    /// </content>
    public partial class Kernel32
    {
        private class DeviceIOControlOverlapped : Overlapped
        {
            private readonly Memory<byte> input;
            private readonly Memory<byte> output;

            private unsafe NativeOverlapped* native;

            /// <summary>
            /// Initializes a new instance of the <see cref="DeviceIOControlOverlapped"/> class.
            /// </summary>
            /// <param name="input">
            /// The input buffer.
            /// </param>
            /// <param name="output">
            /// The output buffer.
            /// </param>
            public DeviceIOControlOverlapped(Memory<byte> input, Memory<byte> output)
            {
                this.input = input;
                this.output = output;
            }

            /// <summary>
            /// Gets a <see cref="MemoryHandle"/> to the input buffer.
            /// </summary>
            public MemoryHandle InputHandle { get; private set; }

            /// <summary>
            /// Gets a <see cref="MemoryHandle"/> to the output buffer.
            /// </summary>
            public MemoryHandle OutputHandle { get; private set; }

            /// <summary>
            /// Gets the amount of bytes written.
            /// </summary>
            public uint BytesWritten { get; private set; }

            /// <summary>
            /// Gets the error code returned by the device driver.
            /// </summary>
            public uint ErrorCode { get; private set; }

            /// <summary>
            /// Gets the event which is set when the operation completes.
            /// </summary>
            public TaskCompletionSource<int> OnCompleted { get; } = new TaskCompletionSource<int>();

            /// <summary>
            /// Packs the current instance of the <see cref="DeviceIOControlOverlapped"/> into a <see cref="NativeOverlapped"/>
            /// structure and pins the input and output buffers.
            /// </summary>
            /// <returns>
            /// A <see cref="NativeOverlapped"/> structure which can be used to call <see cref="Kernel32.DeviceIoControl(Kernel32.SafeObjectHandle, int, void*, int, void*, int, out int, Kernel32.OVERLAPPED*)"/>.
            /// </returns>
            public unsafe NativeOverlapped* Pack()
            {
                this.InputHandle = this.input.Pin();
                this.OutputHandle = this.output.Pin();

                this.native = this.Pack(
                    this.DeviceIOControlCompletionCallback,
                    null);

                return this.native;
            }

            /// <summary>
            /// Unpacks the <see cref="NativeOverlapped"/> structure associated with this <see cref="DeviceIOControlOverlapped"/>
            /// instance, frees the native memory used and unpins the input and output buffers.
            /// </summary>
            public unsafe void Unpack()
            {
                Overlapped.Unpack(this.native);
                Overlapped.Free(this.native);

                this.InputHandle.Dispose();
                this.OutputHandle.Dispose();
            }

            /// <summary>
            /// A callback which is invoked once the asynchronous I/O operation completes.
            /// </summary>
            /// <param name="errorCode">
            /// The error code returned by the device driver.
            /// </param>
            /// <param name="numberOfBytesTransferred">
            /// The number of bytes transferred.
            /// </param>
            /// <param name="nativeOverlapped">
            /// A <see cref="NativeOverlapped"/> object representing an unmanaged pointer to the
            /// native overlapped value type.
            /// </param>
            private unsafe void DeviceIOControlCompletionCallback(uint errorCode, uint numberOfBytesTransferred, NativeOverlapped* nativeOverlapped)
            {
                this.Unpack();

                this.BytesWritten = numberOfBytesTransferred;
                this.ErrorCode = errorCode;

                if (this.ErrorCode != 0)
                {
                    this.OnCompleted.SetException(
                        new Win32Exception((int)this.ErrorCode));
                }
                else
                {
                    this.OnCompleted.SetResult((int)numberOfBytesTransferred);
                }
            }
        }
    }
}
#endif
