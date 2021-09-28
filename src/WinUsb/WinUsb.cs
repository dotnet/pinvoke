// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Runtime.InteropServices;
    using System.Threading;

    /// <summary>
    /// Exported functions from the WinUsb.dll Windows library.
    /// </summary>
    [OfferFriendlyOverloads]
    public static partial class WinUsb
    {
        /// <summary>
        /// Creates a WinUSB handle for the device specified by a file handle.
        /// </summary>
        /// <param name="deviceHandle">
        /// The handle to the device that <see cref="Kernel32.CreateFile(string, Kernel32.ACCESS_MASK, Kernel32.FileShare, Kernel32.SECURITY_ATTRIBUTES*, Kernel32.CreationDisposition, Kernel32.CreateFileFlags, Kernel32.SafeObjectHandle)"/> returned.
        /// </param>
        /// <param name="interfaceHandle">
        /// Receives an opaque handle to the first (default) interface on the device.
        /// This handle is required by other WinUSB routines that perform operations on the default interface.
        /// To release the handle, call the <see cref="WinUsb_Free"/> function.
        /// </param>
        /// <returns>
        /// Returns <see langword="true"/> if the operation succeeds. Otherwise, this routine returns <see langword="false"/>,
        /// and the caller can retrieve the logged error by calling <see cref="Marshal.GetLastWin32Error"/>.
        /// </returns>
        [DllImport(nameof(WinUsb), SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool WinUsb_Initialize(Kernel32.SafeObjectHandle deviceHandle, out SafeUsbHandle interfaceHandle);

        /// <summary>
        /// Rretrieves information about the specified endpoint and the associated pipe for an interface.
        /// </summary>
        /// <param name="interfaceHandle">
        /// An opaque handle to an interface that contains the endpoint with which the pipe is associated.
        /// </param>
        /// <param name="alternateInterfaceNumber">
        /// A value that specifies the alternate interface to return the information for.
        /// </param>
        /// <param name="pipeIndex">
        /// A value that specifies the pipe to return information about. This value is not the same as the bEndpointAddress field in the endpoint descriptor.
        /// A <paramref name="pipeIndex"/> value of 0 signifies the first endpoint that is associated with the interface, a value of 1 signifies the second endpoint,
        /// and so on. <paramref name="pipeIndex"/> must be less than the value in the bNumEndpoints field of the interface descriptor.
        /// </param>
        /// <param name="pipeInformation">
        /// A pointer, on output, to a caller-allocated <see cref="WINUSB_PIPE_INFORMATION"/> structure that contains pipe information.
        /// </param>
        /// <returns>
        /// Returns <see langword="true"/> if the operation succeeds. Otherwise, this routine returns <see langword="false"/>,
        /// and the caller can retrieve the logged error by calling <see cref="Marshal.GetLastWin32Error"/>.
        /// </returns>
        [DllImport(nameof(WinUsb), SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static unsafe extern bool WinUsb_QueryPipe(
            SafeUsbHandle interfaceHandle,
            byte alternateInterfaceNumber,
            byte pipeIndex,
            [Friendly(FriendlyFlags.Out)] WINUSB_PIPE_INFORMATION* pipeInformation);

        /// <summary>
        /// The <see cref="WinUsb_FlushPipe"/> function discards any data that is cached in a pipe. This is a synchronous operation.
        /// </summary>
        /// <param name="interfaceHandle">
        /// An opaque handle to the interface with which the specified pipe's endpoint is associated. To clear data in a pipe that is
        /// associated with the endpoint on the first (default) interface, use the handle returned by <see cref="WinUsb_Initialize"/>.
        /// For all other interfaces, use the handle to the target interface, retrieved by <see cref="WinUsb_GetAssociatedInterface"/>.
        /// </param>
        /// <param name="pipeID">
        /// The identifier (ID) of the control pipe. The PipeID parameter is an 8-bit value that consists of a 7-bit address and a direction bit.
        /// This parameter corresponds to the bEndpointAddress field in the endpoint descriptor.
        /// </param>
        /// <returns>
        /// <see cref="WinUsb_FlushPipe"/> returns <see langword="true"/> if the operation succeeds. Otherwise, this routine returns
        /// <see langword="false"/>, and the caller can retrieve the logged error by calling <see cref="Kernel32.GetLastError"/>.
        /// </returns>
        [DllImport(nameof(WinUsb), SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static unsafe extern bool WinUsb_FlushPipe(
            SafeUsbHandle interfaceHandle,
            byte pipeID);

        /// <summary>
        /// The <see cref="WinUsb_GetAssociatedInterface"/> function retrieves a handle for an associated interface. This is a synchronous operation.
        /// </summary>
        /// <param name="interfaceHandle">
        /// An opaque handle to the first (default) interface on the device, which is returned by <see cref="WinUsb_Initialize"/>.
        /// </param>
        /// <param name="associatedInterfaceIndex">
        /// An index that specifies the associated interface to retrieve. A value of 0 indicates the first associated interface,
        /// a value of 1 indicates the second associated interface, and so on.
        /// </param>
        /// <param name="associatedInterfaceHandle">
        /// A handle for the associated interface. Callers must pass this interface handle to WinUSB Functions exposed by <c>Winusb.dll</c>.
        /// To close this handle, call <see cref="WinUsb_Free"/>.
        /// </param>
        /// <returns>
        /// <see cref="WinUsb_GetAssociatedInterface"/> returns <see langword="true"/> if the operation succeeds. Otherwise, this routine returns
        /// <see langword="true"/>, and the caller can retrieve the logged error by calling <see cref="Kernel32.GetLastError"/>.
        /// </returns>
        [DllImport(nameof(WinUsb), SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static unsafe extern bool WinUsb_GetAssociatedInterface(
            SafeUsbHandle interfaceHandle,
            byte associatedInterfaceIndex,
            out SafeUsbHandle associatedInterfaceHandle);

        /// <summary>
        /// Writes data to a pipe.
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
        /// <param name="bufferLength">
        /// The number of bytes to write. This number must be less than or equal to the size, in bytes, of <paramref name="buffer"/>.
        /// </param>
        /// <param name="lengthTransferred">
        /// A pointer to a ULONG variable that receives the actual number of bytes that were written to the pipe.
        /// </param>
        /// <param name="overlapped">
        /// An optional pointer to an <see cref="NativeOverlapped"/> structure, which is used for asynchronous operations.
        /// If this parameter is specified, <see cref="WinUsb_WritePipe(SafeUsbHandle, byte, byte*, int, out int, NativeOverlapped*)"/> immediately returns, and the event is signaled when the operation is complete.
        /// </param>
        /// <returns>
        /// Returns <see langword="true"/> if the operation succeeds. Otherwise, this routine returns <see langword="false"/>,
        /// and the caller can retrieve the logged error by calling <see cref="Marshal.GetLastWin32Error"/>.
        /// </returns>
        [DllImport(nameof(WinUsb), SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static unsafe extern bool WinUsb_WritePipe(
            SafeUsbHandle interfaceHandle,
            byte pipeID,
            [Friendly(FriendlyFlags.In | FriendlyFlags.Array)] byte* buffer,
            int bufferLength,
            out int lengthTransferred,
            [Friendly(FriendlyFlags.In | FriendlyFlags.Optional)] NativeOverlapped* overlapped);

        /// <summary>
        /// Reads data from the specified pipe.
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
        /// <param name="bufferLength">
        /// The maximum number of bytes to read. This number must be less than or equal to the size, in bytes, of <paramref name="buffer"/>.
        /// </param>
        /// <param name="lengthTransferred">
        /// A pointer to a ULONG variable that receives the actual number of bytes that were copied into <paramref name="buffer"/>.
        /// </param>
        /// <param name="overlapped">
        /// An optional pointer to an <see cref="NativeOverlapped"/> structure that is used for asynchronous operations.
        /// If this parameter is specified, <see cref="WinUsb_ReadPipe(SafeUsbHandle, byte, byte*, int, out int, NativeOverlapped*)"/> returns immediately rather than waiting synchronously for the operation to complete before returning.
        /// An event is signaled when the operation is complete.
        ///  </param>
        /// <returns>
        /// <see cref="WinUsb_ReadPipe(SafeUsbHandle, byte, byte*, int, out int, NativeOverlapped*)"/> returns <see langword="true"/> if the operation succeeds.
        /// Otherwise, this function returns <see langword="false"/>, and the caller can retrieve the logged error by calling <see cref="Marshal.GetLastWin32Error"/>.
        /// </returns>
        [DllImport(nameof(WinUsb), SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern unsafe bool WinUsb_ReadPipe(
            SafeUsbHandle interfaceHandle,
            byte pipeID,
            [Friendly(FriendlyFlags.In | FriendlyFlags.Array)] byte* buffer,
            int bufferLength,
            out int lengthTransferred,
            [Friendly(FriendlyFlags.In | FriendlyFlags.Optional)] NativeOverlapped* overlapped);

        /// <summary>
        /// Resets the data toggle and clears the stall condition on a pipe.
        /// </summary>
        /// <param name="handle">
        /// An opaque handle to the interface that contains the endpoint with which the pipe is associated.
        /// </param>
        /// <param name="pipeID">
        /// The identifier (ID) of the control pipe. The PipeID parameter is an 8-bit value that consists in a 7-bit address and a direction bit.
        /// This parameter corresponds to the bEndpointAddress field in the endpoint descriptor.
        /// </param>
        /// <returns>
        /// <see cref="WinUsb_ResetPipe"/> returns <see langword="true"/> if the operation succeeds.
        /// Otherwise, this function returns <see langword="false"/>, and the caller can retrieve the logged error by calling <see cref="Marshal.GetLastWin32Error"/>.
        /// </returns>
        [DllImport(nameof(WinUsb), SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool WinUsb_ResetPipe(SafeUsbHandle handle, byte pipeID);

        /// <summary>
        /// Aborts all of the pending transfers for a pipe. This is a synchronous operation.
        /// </summary>
        /// <param name="handle">
        /// An opaque handle to the interface that contains the endpoint with which the pipe is associated.
        /// </param>
        /// <param name="pipeID">
        /// The identifier (ID) of the control pipe. The PipeID parameter is an 8-bit value that consists in a 7-bit address and a direction bit.
        /// This parameter corresponds to the bEndpointAddress field in the endpoint descriptor.
        /// </param>
        /// <returns>
        /// <see cref="WinUsb_AbortPipe"/> returns <see langword="true"/> if the operation succeeds.
        /// Otherwise, this function returns <see langword="false"/>, and the caller can retrieve the logged error by calling <see cref="Marshal.GetLastWin32Error"/>.
        /// </returns>
        [DllImport(nameof(WinUsb), SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool WinUsb_AbortPipe(SafeUsbHandle handle, byte pipeID);

        /// <summary>
        /// Releases all of the resources that <see cref="WinUsb_Initialize"/> allocated. This is a synchronous operation.
        /// </summary>
        /// <param name="handle">
        /// An opaque handle to an interface in the selected configuration. That handle must be created by a previous call to <see cref="WinUsb_Initialize"/> or <c>WinUsb_GetAssociatedInterface</c>.
        /// </param>
        /// <returns>
        /// <see cref="WinUsb_Free"/> returns <c>TRUE</c>.
        /// </returns>
        [DllImport(nameof(WinUsb), SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool WinUsb_Free(IntPtr handle);
    }
}
