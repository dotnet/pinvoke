// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using static PInvoke.Kernel32;
using static PInvoke.WinUsb;
using Win32ErrorCode = PInvoke.Win32ErrorCode;

public partial class WinUsbFacts
{
    [Fact]
    public async Task WinUsb_ReadPipeAsync_Exception_Test()
    {
        await Assert.ThrowsAsync<PInvoke.Win32Exception>(() => WinUsb_ReadPipeAsync(new SafeUsbHandle(IntPtr.Zero), 0, Array.Empty<byte>(), default).AsTask()).ConfigureAwait(false);
    }

    [Fact(Skip = "Requires USB device")]
    public async Task WinUsb_ReadPipeAsync_Overlapped_Test()
    {
        string devicePath = @"<path to your USB device>";

        using (SafeObjectHandle handle = CreateFile(
           devicePath,
           ACCESS_MASK.GenericRight.GENERIC_READ | ACCESS_MASK.GenericRight.GENERIC_WRITE,
           FileShare.FILE_SHARE_READ | FileShare.FILE_SHARE_WRITE,
           IntPtr.Zero,
           CreationDisposition.OPEN_EXISTING,
           CreateFileFlags.FILE_FLAG_OVERLAPPED,
           SafeObjectHandle.Null))
        {
            ThreadPool.BindHandle(handle);

            if (!WinUsb_Initialize(handle, out SafeUsbHandle usbHandle))
            {
                throw new PInvoke.Win32Exception(Marshal.GetLastWin32Error());
            }

            Assert.True(WinUsb_QueryPipe(usbHandle, alternateInterfaceNumber: 0, pipeIndex: 0, out WINUSB_PIPE_INFORMATION input));

            ValueTask<int> readTask = WinUsb_ReadPipeAsync(usbHandle, input.PipeId, Array.Empty<byte>(), default);
            Assert.Equal(0, await readTask.ConfigureAwait(false));
        }
    }

    [Fact(Skip = "Requires USB device")]
    public async Task WinUsb_ReadPipeAsync_Cancelled_Test()
    {
        string devicePath = @"<path to your USB device>";

        using (SafeObjectHandle handle = CreateFile(
           devicePath,
           ACCESS_MASK.GenericRight.GENERIC_READ | ACCESS_MASK.GenericRight.GENERIC_WRITE,
           FileShare.FILE_SHARE_READ | FileShare.FILE_SHARE_WRITE,
           IntPtr.Zero,
           CreationDisposition.OPEN_EXISTING,
           CreateFileFlags.FILE_FLAG_OVERLAPPED,
           SafeObjectHandle.Null))
        {
            ThreadPool.BindHandle(handle);

            if (!WinUsb_Initialize(handle, out SafeUsbHandle usbHandle))
            {
                throw new PInvoke.Win32Exception(Marshal.GetLastWin32Error());
            }

            Assert.True(WinUsb_QueryPipe(usbHandle, alternateInterfaceNumber: 0, pipeIndex: 0, out WINUSB_PIPE_INFORMATION input));

            byte[] buffer = new byte[100];

            var cts = new CancellationTokenSource();
            ValueTask<int> readTask = WinUsb_ReadPipeAsync(usbHandle, input.PipeId, buffer, cts.Token);
            cts.Cancel();

            PInvoke.Win32Exception ex = await Assert.ThrowsAsync<PInvoke.Win32Exception>(() => readTask.AsTask());
            Assert.Equal(Win32ErrorCode.ERROR_OPERATION_ABORTED, ex.NativeErrorCode);
        }
    }

    [Fact]
    public async Task WinUsb_WritePipeAsync_Exception_Test()
    {
        await Assert.ThrowsAsync<PInvoke.Win32Exception>(() => WinUsb_WritePipeAsync(new SafeUsbHandle(IntPtr.Zero), 0, Array.Empty<byte>(), default).AsTask()).ConfigureAwait(false);
    }

    [Fact(Skip = "Requires USB device")]
    public async Task WinUsb_WritePipeAsync_Overlapped_Test()
    {
        string devicePath = @"<path to your USB device>";

        using (SafeObjectHandle handle = CreateFile(
           devicePath,
           ACCESS_MASK.GenericRight.GENERIC_READ | ACCESS_MASK.GenericRight.GENERIC_WRITE,
           FileShare.FILE_SHARE_READ | FileShare.FILE_SHARE_WRITE,
           IntPtr.Zero,
           CreationDisposition.OPEN_EXISTING,
           CreateFileFlags.FILE_FLAG_OVERLAPPED,
           SafeObjectHandle.Null))
        {
            ThreadPool.BindHandle(handle);

            if (!WinUsb_Initialize(handle, out SafeUsbHandle usbHandle))
            {
                throw new PInvoke.Win32Exception(Marshal.GetLastWin32Error());
            }

            Assert.True(WinUsb_QueryPipe(usbHandle, alternateInterfaceNumber: 0, pipeIndex: 0, out WINUSB_PIPE_INFORMATION input));

            ValueTask<int> readTask = WinUsb_WritePipeAsync(usbHandle, input.PipeId, Array.Empty<byte>(), default);
            Assert.Equal(0, await readTask.ConfigureAwait(false));
        }
    }

    [Fact(Skip = "Requires USB device")]
    public async Task WinUsb_WritePipeAsync_Cancelled_Test()
    {
        string devicePath = @"<path to your USB device>";

        using (SafeObjectHandle handle = CreateFile(
           devicePath,
           ACCESS_MASK.GenericRight.GENERIC_READ | ACCESS_MASK.GenericRight.GENERIC_WRITE,
           FileShare.FILE_SHARE_READ | FileShare.FILE_SHARE_WRITE,
           IntPtr.Zero,
           CreationDisposition.OPEN_EXISTING,
           CreateFileFlags.FILE_FLAG_OVERLAPPED,
           SafeObjectHandle.Null))
        {
            ThreadPool.BindHandle(handle);

            if (!WinUsb_Initialize(handle, out SafeUsbHandle usbHandle))
            {
                throw new PInvoke.Win32Exception(Marshal.GetLastWin32Error());
            }

            Assert.True(WinUsb_QueryPipe(usbHandle, alternateInterfaceNumber: 0, pipeIndex: 0, out WINUSB_PIPE_INFORMATION input));

            byte[] buffer = new byte[100];

            var cts = new CancellationTokenSource();
            ValueTask<int> readTask = WinUsb_WritePipeAsync(usbHandle, input.PipeId, buffer, cts.Token);
            cts.Cancel();

            PInvoke.Win32Exception ex = await Assert.ThrowsAsync<PInvoke.Win32Exception>(() => readTask.AsTask());
            Assert.Equal(Win32ErrorCode.ERROR_OPERATION_ABORTED, ex.NativeErrorCode);
        }
    }
}
