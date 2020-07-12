// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

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
        private class DeviceIOControlOverlapped<TInput, TOutput> : Overlapped
            where TInput : struct
            where TOutput : struct
        {
            private readonly Memory<TInput> input;
            private readonly Memory<TOutput> output;

            /// <summary>
            /// The source for completing the <see cref="Completion"/> property.
            /// </summary>
            private readonly TaskCompletionSource<uint> completion = new TaskCompletionSource<uint>();

            private unsafe NativeOverlapped* native;

            /// <summary>
            /// Initializes a new instance of the <see cref="DeviceIOControlOverlapped{TInput, TOutput}"/> class.
            /// </summary>
            /// <param name="input">
            /// The input buffer.
            /// </param>
            /// <param name="output">
            /// The output buffer.
            /// </param>
            internal DeviceIOControlOverlapped(Memory<TInput> input, Memory<TOutput> output)
            {
                this.input = input;
                this.output = output;
            }

            /// <summary>
            /// Gets a <see cref="MemoryHandle"/> to the input buffer.
            /// </summary>
            internal MemoryHandle InputHandle { get; private set; }

            /// <summary>
            /// Gets a <see cref="MemoryHandle"/> to the output buffer.
            /// </summary>
            internal MemoryHandle OutputHandle { get; private set; }

            /// <summary>
            /// Gets the amount of bytes written.
            /// </summary>
            internal uint BytesWritten { get; private set; }

            /// <summary>
            /// Gets the error code returned by the device driver.
            /// </summary>
            internal uint ErrorCode { get; private set; }

            /// <summary>
            /// Gets a task whose result is the number of bytes transferred, or faults with the <see cref="Win32Exception"/> describing the failure.
            /// </summary>
            internal Task<uint> Completion => this.completion.Task;

            /// <summary>
            /// Packs the current instance of the <see cref="DeviceIOControlOverlapped{TInput, TOutput}"/> into a <see cref="NativeOverlapped"/>
            /// structure and pins the input and output buffers.
            /// </summary>
            /// <returns>
            /// A <see cref="NativeOverlapped"/> structure which can be used to call <see cref="Kernel32.DeviceIoControl(Kernel32.SafeObjectHandle, int, void*, int, void*, int, out int, Kernel32.OVERLAPPED*)"/>.
            /// </returns>
            internal unsafe NativeOverlapped* Pack()
            {
                this.InputHandle = this.input.Pin();
                this.OutputHandle = this.output.Pin();

                this.native = this.Pack(
                    this.DeviceIOControlCompletionCallback,
                    null);

                return this.native;
            }

            /// <summary>
            /// Unpacks the <see cref="NativeOverlapped"/> structure associated with this <see cref="DeviceIOControlOverlapped{TInput, TOutput}"/>
            /// instance, frees the native memory used and unpins the input and output buffers.
            /// </summary>
            internal unsafe void Unpack()
            {
                Overlapped.Unpack(this.native);
                Overlapped.Free(this.native);
                this.native = null;

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
                    this.completion.SetException(
                        new Win32Exception((int)this.ErrorCode));
                }
                else
                {
                    this.completion.SetResult(numberOfBytesTransferred);
                }
            }
        }
    }
}
