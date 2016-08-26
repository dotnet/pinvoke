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
        public static PROCESSENTRY32? Process32First(SafeObjectHandle hSnapshot)
        {
            if (hSnapshot == null)
            {
                throw new ArgumentNullException(nameof(hSnapshot));
            }

            var entry = PROCESSENTRY32.Create();
            if (Process32First(hSnapshot, ref entry))
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
        public static PROCESSENTRY32? Process32Next(SafeObjectHandle hSnapshot)
        {
            if (hSnapshot == null)
            {
                throw new ArgumentNullException(nameof(hSnapshot));
            }

            var entry = PROCESSENTRY32.Create();
            if (Process32Next(hSnapshot, ref entry))
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

        /// <summary>Retrieves information about the first module encountered in a system snapshot.</summary>
        /// <param name="hSnapshot">
        ///     A handle to the snapshot returned from a previous call to the
        ///     <see cref="CreateToolhelp32Snapshot" /> function.
        /// </param>
        /// <returns>
        ///     The first <see cref="MODULEENTRY32" /> if there was any or <see langword="null" /> otherwise (No values in
        ///     the snapshot).
        /// </returns>
        /// <exception cref="Win32Exception">Thrown if any error occurs.</exception>
        /// <exception cref="ArgumentNullException">If <paramref name="hSnapshot" /> is <see langword="null" />.</exception>
        public static MODULEENTRY32? Module32First(SafeObjectHandle hSnapshot)
        {
            if (hSnapshot == null)
            {
                throw new ArgumentNullException(nameof(hSnapshot));
            }

            var entry = MODULEENTRY32.Create();
            if (Module32First(hSnapshot, ref entry))
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

        /// <summary>Retrieves information about the next module encountered in a system snapshot.</summary>
        /// <param name="hSnapshot">
        ///     A handle to the snapshot returned from a previous call to the
        ///     <see cref="CreateToolhelp32Snapshot" /> function.
        /// </param>
        /// <returns>
        ///     The next <see cref="MODULEENTRY32" /> if there was any or <see langword="null" /> otherwise (No more values
        ///     in the snapshot).
        /// </returns>
        /// <exception cref="Win32Exception">Thrown if any error occurs.</exception>
        /// <exception cref="ArgumentNullException">If <paramref name="hSnapshot" /> is <see langword="null" />.</exception>
        public static MODULEENTRY32? Module32Next(SafeObjectHandle hSnapshot)
        {
            if (hSnapshot == null)
            {
                throw new ArgumentNullException(nameof(hSnapshot));
            }

            var entry = MODULEENTRY32.Create();
            if (Module32Next(hSnapshot, ref entry))
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

        /// <summary>Retrieves information about next module encountered in a system snapshot.</summary>
        /// <param name="hSnapshot">
        ///     A handle to the snapshot returned from a previous call to the
        ///     <see cref="CreateToolhelp32Snapshot" /> function.
        /// </param>
        /// <returns>
        ///     An enumeration of all the <see cref="MODULEENTRY32" /> present in the snapshot.
        /// </returns>
        /// <exception cref="Win32Exception">Thrown if any error occurs.</exception>
        /// <exception cref="ArgumentNullException">If <paramref name="hSnapshot" /> is <see langword="null" />.</exception>
        public static IEnumerable<MODULEENTRY32> Module32Enumerate(SafeObjectHandle hSnapshot)
        {
            if (hSnapshot == null)
            {
                throw new ArgumentNullException(nameof(hSnapshot));
            }

            var entry = Module32First(hSnapshot);

            while (entry.HasValue)
            {
                yield return entry.Value;
                entry = Module32Next(hSnapshot);
            }
        }

        public static unsafe string QueryFullProcessImageName(
            SafeObjectHandle hProcess,
            QueryFullProcessImageNameFlags dwFlags = QueryFullProcessImageNameFlags.None)
        {
            // If we ever resize over this value something got really wrong
            const int maximumRealisticSize = 1 * 1024 * 2014;

            int size = 255;

            do
            {
                var text = stackalloc char[size];
                var success = QueryFullProcessImageName(hProcess, dwFlags, text, ref size);
                if (success)
                {
                    return new string(text, 0, size);
                }

                size *= 2;
            }
            while (size < maximumRealisticSize);

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
        /// Allocates the specified number of bytes from the heap.
        /// </summary>
        /// <param name="uFlags">
        /// The memory allocation attributes. The default is the <see cref="GlobalAllocFlags.GMEM_FIXED"/> value.
        /// This parameter can be one or more of the following values, except for the incompatible combinations that are specifically noted.
        /// </param>
        /// <param name="uBytes">
        /// The number of bytes to allocate. If this parameter is zero and the uFlags parameter specifies <see cref="GlobalAllocFlags.GMEM_MOVEABLE"/>,
        /// the function returns a handle to a memory object that is marked as discarded.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is a handle to the newly allocated memory object.
        /// If the function fails, the return value is NULL. To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        public static unsafe void* GlobalAlloc(GlobalAllocFlags uFlags, int uBytes)
        {
            // The length of SIZE_T and IntPtr vary with the bitness of the process.
            // For convenience to callers we want to expose the size of a memory allocation
            // as an Int32 no matter the process bitness. So safely 'upscale' the Int32 to
            // the appropriate IntPtr and call the native overload.
            return GlobalAlloc(uFlags, new IntPtr(uBytes));
        }

        /// <summary>
        /// Changes the size or attributes of a specified global memory object. The size can increase or decrease.
        /// </summary>
        /// <param name="hMem">
        /// A handle to the global memory object to be reallocated.
        /// This handle is returned by either the <see cref="GlobalAlloc(GlobalAllocFlags, IntPtr)"/> or <see cref="GlobalReAlloc(void*, IntPtr, GlobalReAllocFlags)"/> function.
        /// </param>
        /// <param name="uBytes">The new size of the memory block, in bytes. If uFlags specifies <see cref="GlobalAllocFlags.GMEM_MODIFY"/>, this parameter is ignored.</param>
        /// <param name="uFlags">
        /// The reallocation options. If <see cref="LocalReAllocFlags.LMEM_MODIFY"/> is specified, the function modifies the attributes of the memory object only
        /// (the uBytes parameter is ignored.) Otherwise, the function reallocates the memory object.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is a handle to the reallocated memory object.
        /// If the function fails, the return value is NULL. To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// If GlobalReAlloc fails, the original memory is not freed, and the original handle and pointer are still valid.
        /// If GlobalReAlloc reallocates a fixed object, the value of the handle returned is the address of the first byte of the memory block.
        /// To access the memory, a process can simply cast the return value to a pointer.
        /// </remarks>
        public static unsafe void* GlobalReAlloc(void* hMem, int uBytes, GlobalReAllocFlags uFlags)
        {
            // The length of SIZE_T and IntPtr vary with the bitness of the process.
            // For convenience to callers we want to expose the size of a memory allocation
            // as an Int32 no matter the process bitness. So safely 'upscale' the Int32 to
            // the appropriate IntPtr and call the native overload.
            return GlobalReAlloc(hMem, new IntPtr(uBytes), uFlags);
        }

        /// <summary>
        /// Allocates a block of memory from a heap. The allocated memory is not movable.
        /// </summary>
        /// <param name="hHeap">A handle to the heap from which the memory will be allocated. This handle is returned by the HeapCreate or GetProcessHeap function.</param>
        /// <param name="uFlags">The heap allocation options. Specifying any of these values will override the corresponding value specified when the heap was created with HeapCreate.</param>
        /// <param name="uBytes">
        /// The number of bytes to be allocated. If the heap specified by the hHeap parameter is a "non-growable" heap,
        /// dwBytes must be less than 0x7FFF8.
        /// You create a non-growable heap by calling the HeapCreate function with a nonzero value.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is a pointer to the allocated memory block.
        /// If the function fails and you have not specified <see cref="HeapAllocFlags.HEAP_GENERATE_EXCEPTIONS"/>, the return value is NULL.
        /// If the function fails and you have specified <see cref="HeapAllocFlags.HEAP_GENERATE_EXCEPTIONS"/>,
        /// the function may generate either of the exceptions listed in the following table:
        /// <list>
        /// <item>STATUS_NO_MEMORY: The allocation attempt failed because of a lack of available memory or heap corruption.</item>
        /// <item>STATUS_ACCESS_VIOLATION: The allocation attempt failed because of heap corruption or improper function parameters.</item>
        /// </list>
        /// The particular exception depends upon the nature of the heap corruption. For more information, see GetExceptionCode.
        /// </returns>
        /// <remarks>If the function fails, it does not call SetLastError. An application cannot call <see cref="GetLastError"/> for extended error information.</remarks>
        public static unsafe void* HeapAlloc(IntPtr hHeap, HeapAllocFlags uFlags, int uBytes)
        {
            // The length of SIZE_T and IntPtr vary with the bitness of the process.
            // For convenience to callers we want to expose the size of a memory allocation
            // as an Int32 no matter the process bitness. So safely 'upscale' the Int32 to
            // the appropriate IntPtr and call the native overload.
            return HeapAlloc(hHeap, uFlags, new IntPtr(uBytes));
        }

        /// <summary>
        /// Reallocates a block of memory from a heap. This function enables you to resize a memory block and change other memory block properties.
        /// The allocated memory is not movable.
        /// </summary>
        /// <param name="hHeap">A handle to the heap from which the memory is to be reallocated. This handle is a returned by either the HeapCreate or GetProcessHeap function.</param>
        /// <param name="uFlags">
        /// The heap reallocation options. Specifying a value overrides the corresponding value specified in the flOptions parameter
        /// when the heap was created by using the HeapCreate function.
        /// </param>
        /// <param name="hMem">
        /// A pointer to the block of memory that the function reallocates.
        /// This pointer is returned by an earlier call to the <see cref="HeapAlloc(IntPtr, HeapAllocFlags, IntPtr)"/> or <see cref="HeapReAlloc(IntPtr, HeapReAllocFlags, void*, IntPtr)"/> function.
        /// </param>
        /// <param name="uBytes">
        /// The new size of the memory block, in bytes. A memory block's size can be increased or decreased by using this function.
        /// If the heap specified by the hHeap parameter is a "non-growable" heap, dwBytes must be less than 0x7FFF8.
        /// You create a non-growable heap by calling the HeapCreate function with a nonzero value.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is a pointer to the reallocated memory block.
        /// If the function fails and you have not specified <see cref="HeapAllocFlags.HEAP_GENERATE_EXCEPTIONS"/>, the return value is NULL.
        /// If the function fails and you have specified <see cref="HeapAllocFlags.HEAP_GENERATE_EXCEPTIONS"/>,
        /// the function may generate either of the exceptions listed in the following table:
        /// <list>
        /// <item>STATUS_NO_MEMORY: The allocation attempt failed because of a lack of available memory or heap corruption.</item>
        /// <item>STATUS_ACCESS_VIOLATION: The allocation attempt failed because of heap corruption or improper function parameters.</item>
        /// </list>
        /// The particular exception depends upon the nature of the heap corruption. For more information, see GetExceptionCode.
        /// </returns>
        /// <remarks>If the function fails, it does not call SetLastError. An application cannot call <see cref="GetLastError"/> for extended error information.</remarks>
        public static unsafe void* HeapReAlloc(IntPtr hHeap, HeapReAllocFlags uFlags, void* hMem, int uBytes)
        {
            // The length of SIZE_T and IntPtr vary with the bitness of the process.
            // For convenience to callers we want to expose the size of a memory allocation
            // as an Int32 no matter the process bitness. So safely 'upscale' the Int32 to
            // the appropriate IntPtr and call the native overload.
            return HeapReAlloc(hHeap, uFlags, hMem, new IntPtr(uBytes));
        }
    }
}
