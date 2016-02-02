// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <content>
    /// Methods and nested types that are not strictly P/Invokes but provide
    /// a slightly higher level of functionality to ease calling into native code.
    /// </content>
    public static partial class Kernel32
    {
        /// <summary>Retrieves information about the first process encountered in a system snapshot.</summary>
        /// <param name="hSnapshot">
        ///     A handle to the snapshot returned from a previous call to the
        ///     <see cref="CreateToolhelp32Snapshot" /> function.
        /// </param>
        /// <returns>
        ///     The first <see cref="PROCESSENTRY32" /> if there was any or <see langword="null" /> otherwise (No values in
        ///     the snapshot).
        /// </returns>
        /// <exception cref="Win32Exception">Thrown if any error occurs.</exception>
        /// <exception cref="ArgumentNullException">If <paramref name="hSnapshot" /> is <see langword="null" />.</exception>
        public static unsafe PROCESSENTRY32? Process32First(SafeObjectHandle hSnapshot)
        {
            if (hSnapshot == null)
            {
                throw new ArgumentNullException(nameof(hSnapshot));
            }

            var entry = PROCESSENTRY32.Create();
            if (Process32First(hSnapshot, &entry))
            {
                return entry;
            }

            var lastError = GetLastError();
            if (lastError != Win32ErrorCode.ERROR_NO_MORE_FILES)
            {
                throw new Win32Exception(lastError);
            }

            return null;
        }

        /// <summary>Retrieves information about the next process encountered in a system snapshot.</summary>
        /// <param name="hSnapshot">
        ///     A handle to the snapshot returned from a previous call to the
        ///     <see cref="CreateToolhelp32Snapshot" /> function.
        /// </param>
        /// <returns>
        ///     The next <see cref="PROCESSENTRY32" /> if there was any or <see langword="null" /> otherwise (No more values
        ///     in the snapshot).
        /// </returns>
        /// <exception cref="Win32Exception">Thrown if any error occurs.</exception>
        /// <exception cref="ArgumentNullException">If <paramref name="hSnapshot" /> is <see langword="null" />.</exception>
        public static unsafe PROCESSENTRY32? Process32Next(SafeObjectHandle hSnapshot)
        {
            if (hSnapshot == null)
            {
                throw new ArgumentNullException(nameof(hSnapshot));
            }

            var entry = PROCESSENTRY32.Create();
            if (Process32Next(hSnapshot, &entry))
            {
                return entry;
            }

            var lastError = GetLastError();
            if (lastError != Win32ErrorCode.ERROR_NO_MORE_FILES)
            {
                throw new Win32Exception(lastError);
            }

            return null;
        }

        /// <summary>Retrieves information about next process encountered in a system snapshot.</summary>
        /// <param name="hSnapshot">
        ///     A handle to the snapshot returned from a previous call to the
        ///     <see cref="CreateToolhelp32Snapshot" /> function.
        /// </param>
        /// <returns>
        ///     An enumeration of all the <see cref="PROCESSENTRY32" /> present in the snapshot.
        /// </returns>
        /// <exception cref="Win32Exception">Thrown if any error occurs.</exception>
        /// <exception cref="ArgumentNullException">If <paramref name="hSnapshot" /> is <see langword="null" />.</exception>
        public static IEnumerable<PROCESSENTRY32> Process32Enumerate(SafeObjectHandle hSnapshot)
        {
            if (hSnapshot == null)
            {
                throw new ArgumentNullException(nameof(hSnapshot));
            }

            var entry = Process32First(hSnapshot);

            while (entry.HasValue)
            {
                yield return entry.Value;
                entry = Process32Next(hSnapshot);
            }
        }

        public static string QueryFullProcessImageName(
            SafeObjectHandle hProcess,
            QueryFullProcessImageNameFlags dwFlags = QueryFullProcessImageNameFlags.None)
        {
            // If we ever resize over this value something got really wrong
            const int maximumRealisticSize = 1 * 1024 * 2014;

            var buffer = new StringBuilder(255);
            do
            {
                int size = buffer.Capacity;
                bool success = QueryFullProcessImageName(hProcess, dwFlags, buffer, ref size);
                if (success)
                {
                    return buffer.ToString();
                }

                buffer.Capacity = buffer.Capacity * 2;
            }
            while (buffer.Capacity < maximumRealisticSize);

            throw new InvalidOperationException(
                $"QueryFullProcessImageName is expecting a buffer of more than {maximumRealisticSize} bytes");
        }

        public static bool IsWow64Process(SafeObjectHandle hProcess)
        {
            bool result;
            if (!IsWow64Process(hProcess, out result))
            {
                throw new Win32Exception();
            }

            return result;
        }

        /// <summary>
        /// Allocates the specified number of bytes from the heap.
        /// </summary>
        /// <param name="uFlags">
        /// The memory allocation attributes. The default is the <see cref="LocalAllocFlags.LMEM_FIXED"/> value. This parameter can be one or more of the following values, except for the incompatible combinations that are specifically noted.
        /// </param>
        /// <param name="uBytes">The number of bytes to allocate. If this parameter is zero and the <paramref name="uFlags"/> parameter specifies <see cref="LocalAllocFlags.LMEM_MOVEABLE"/>, the function returns a handle to a memory object that is marked as discarded.</param>
        /// <returns>
        /// If the function succeeds, the return value is a handle to the newly allocated memory object.
        /// If the function fails, the return value is NULL. To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        public static unsafe void* LocalAlloc(LocalAllocFlags uFlags, int uBytes)
        {
            // The length of SIZE_T and IntPtr vary with the bitness of the process.
            // For convenience to callers we want to expose the size of a memory allocation
            // as an Int32 no matter the process bitness. So safely 'upscale' the Int32 to
            // the appropriate IntPtr and call the native overload.
            return LocalAlloc(uFlags, new IntPtr(uBytes));
        }

        /// <summary>
        /// Changes the size or the attributes of a specified local memory object. The size can increase or decrease.
        /// </summary>
        /// <param name="hMem">A handle to the local memory object to be reallocated. This handle is returned by either the <see cref="LocalAlloc(LocalAllocFlags, IntPtr)"/> or <see cref="LocalReAlloc(void*, IntPtr, LocalReAllocFlags)"/> function.</param>
        /// <param name="uBytes">The new size of the memory block, in bytes. If uFlags specifies <see cref="LocalReAllocFlags.LMEM_MODIFY"/>, this parameter is ignored.</param>
        /// <param name="uFlags">
        /// The reallocation options. If <see cref="LocalReAllocFlags.LMEM_MODIFY"/> is specified, the function modifies the attributes of the memory object only (the uBytes parameter is ignored.) Otherwise, the function reallocates the memory object.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is a handle to the reallocated memory object.
        /// If the function fails, the return value is NULL. To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// If LocalReAlloc fails, the original memory is not freed, and the original handle and pointer are still valid.
        /// If LocalReAlloc reallocates a fixed object, the value of the handle returned is the address of the first byte of the memory block. To access the memory, a process can simply cast the return value to a pointer.
        /// </remarks>
        public static unsafe void* LocalReAlloc(void* hMem, int uBytes, LocalReAllocFlags uFlags)
        {
            // The length of SIZE_T and IntPtr vary with the bitness of the process.
            // For convenience to callers we want to expose the size of a memory allocation
            // as an Int32 no matter the process bitness. So safely 'upscale' the Int32 to
            // the appropriate IntPtr and call the native overload.
            return LocalReAlloc(hMem, new IntPtr(uBytes), uFlags);
        }

        /// <summary>
        ///     Sets the read mode and the blocking mode of the specified named pipe. If the specified handle is to the client
        ///     end of a named pipe and if the named pipe server process is on a remote computer, the function can also be used to
        ///     control local buffering.
        /// </summary>
        /// <param name="hNamedPipe">
        ///     A handle to the named pipe instance. This parameter can be a handle to the server end of the
        ///     pipe, as returned by the <see cref="CreateNamedPipe(string, PipeAccessMode, PipeMode, int, int, int, int, SECURITY_ATTRIBUTES*)" /> function, or to the client end of the pipe, as returned by
        ///     the <see cref="CreateFile(string, FileAccess, FileShare, SECURITY_ATTRIBUTES*, CreationDisposition, CreateFileFlags, SafeObjectHandle)" /> function. The handle must have GENERIC_WRITE access to the named pipe for a
        ///     write-only or read/write pipe, or it must have GENERIC_READ and FILE_WRITE_ATTRIBUTES access for a read-only pipe.
        ///     <para>
        ///         This parameter can also be a handle to an anonymous pipe, as returned by the <see cref="CreatePipe(out SafeObjectHandle, out SafeObjectHandle, SECURITY_ATTRIBUTES*, int)" />
        ///         function.
        ///     </para>
        /// </param>
        /// <param name="lpMode">The new pipe mode. The mode is a combination of a read-mode flag and a wait-mode flag.</param>
        /// <param name="lpMaxCollectionCount">
        ///     The maximum number of bytes collected on the client computer before transmission to
        ///     the server. This parameter must be NULL if the specified pipe handle is to the server end of a named pipe or if
        ///     client and server processes are on the same machine. This parameter is ignored if the client process specifies the
        ///     FILE_FLAG_WRITE_THROUGH flag in the CreateFile function when the handle was created. This parameter can be NULL if
        ///     the collection count is not being set.
        /// </param>
        /// <param name="lpCollectDataTimeout">
        ///     The maximum time, in milliseconds, that can pass before a remote named pipe
        ///     transfers information over the network. This parameter must be NULL if the specified pipe handle is to the server
        ///     end of a named pipe or if client and server processes are on the same computer. This parameter is ignored if the
        ///     client process specified the FILE_FLAG_WRITE_THROUGH flag in the CreateFile function when the handle was created.
        ///     This parameter can be NULL if the collection count is not being set.
        /// </param>
        /// <returns>
        ///     If the function succeeds, the return value is nonzero.
        ///     <para>
        ///         If the function fails, the return value is zero. To get extended error information, call
        ///         <see cref="GetLastError" />.
        ///     </para>
        /// </returns>
        public static unsafe bool SetNamedPipeHandleState(
            SafeObjectHandle hNamedPipe,
            PipeMode? lpMode,
            int? lpMaxCollectionCount,
            int? lpCollectDataTimeout)
        {
            PipeMode lpModeLocal = lpMode.HasValue ? lpMode.Value : default(PipeMode);
            int lpMaxCollectionCountLocal = lpMaxCollectionCount.HasValue ? lpMaxCollectionCount.Value : 0;
            int lpCollectDataTimeoutLocal = lpCollectDataTimeout.HasValue ? lpCollectDataTimeout.Value : 0;
            return SetNamedPipeHandleState(
                hNamedPipe,
                lpMode.HasValue ? &lpModeLocal : null,
                lpMaxCollectionCount.HasValue ? &lpMaxCollectionCountLocal : null,
                lpCollectDataTimeout.HasValue ? &lpCollectDataTimeoutLocal : null);
        }
    }
}
