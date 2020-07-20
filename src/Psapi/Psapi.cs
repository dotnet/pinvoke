// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Runtime.InteropServices;
    using System.Text;
    using static Kernel32;

    /// <content>Exported functions from the Psapi.dll Windows library that are available to Desktop apps only.</content>
    /// <devremark>
    ///     In Windows 7 and higher all the Psapi functions are also exported by Kernel32 under the name K32Xxx Where "Xxx" is
    ///     the original name. For each function added here, please add the equivalent one in <see cref="Kernel32" />.
    ///     <para>
    ///         You should also add to the <see cref="Kernel32" /> version a note in the remarks about this. See
    ///         <see cref="K32EmptyWorkingSet" /> for an example.
    ///     </para>
    /// </devremark>
    [OfferFriendlyOverloads]
    public static partial class Psapi
    {
        /// <summary>Removes as many pages as possible from the working set of the specified process.</summary>
        /// <param name="hProcess">
        ///     A handle to the process. The handle must have the PROCESS_QUERY_INFORMATION or
        ///     PROCESS_QUERY_LIMITED_INFORMATION access right and the PROCESS_SET_QUOTA access right.
        /// </param>
        /// <returns>
        ///     If the function succeeds, the return value is nonzero.
        ///     <para>
        ///         If the function fails, the return value is zero. To get extended error information, call
        ///         <see cref="GetLastError" />.
        ///     </para>
        /// </returns>
        [DllImport(nameof(Psapi), SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool EmptyWorkingSet(SafeObjectHandle hProcess);

        /// <summary>
        /// Retrieves a handle for each module in the specified process that meets the specified filter criteria.
        /// </summary>
        /// <param name="hProcess">A handle to the process.</param>
        /// <param name="lphModule">An array that receives the list of module handles.</param>
        /// <param name="cb">The size of the <paramref name="lphModule"/> array, in bytes.</param>
        /// <param name="lpcbNeeded">The number of bytes required to store all module handles in the <paramref name="lphModule"/> array.</param>
        /// <param name="dwFilterFlag">The filter criteria. This parameter can be one of the following values.</param>
        /// <returns>If the function succeeds, the return value is nonzero. If the function fails, the return value is zero. To get extended error information, call GetLastError.</returns>
        [DllImport(nameof(Psapi), SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static unsafe extern bool EnumProcessModulesEx(
            IntPtr hProcess,
            [Friendly(FriendlyFlags.Out | FriendlyFlags.Array)] IntPtr* lphModule,
            int cb,
            out int lpcbNeeded,
            EnumProcessModulesFlags dwFilterFlag);

        /// <summary>
        /// Retrieves information about the specified module in the <see cref="MODULEINFO"/> structure.
        /// </summary>
        /// <param name="hProcess">A handle to the process that contains the module.</param>
        /// <param name="hModule">A handle to the module.</param>
        /// <param name="lpmodinfo">A pointer to the MODULEINFO structure that receives information about the module.</param>
        /// <param name="cb">The size of the <see cref="MODULEINFO"/> structure, in bytes.</param>
        /// <returns>If the function succeeds, the return value is nonzero. If the function fails, the return value is zero. To get extended error information, call GetLastError.</returns>
        [DllImport(nameof(Psapi), SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetModuleInformation(IntPtr hProcess, IntPtr hModule, out MODULEINFO lpmodinfo, int cb);

        /// <summary>
        /// Retrieves the fully qualified path for the file containing the specified module.
        /// </summary>
        /// <param name="hProcess">A handle to the process that contains the module.</param>
        /// <param name="hModule">A handle to the module. If this parameter is NULL, GetModuleFileNameEx returns the path of the executable file of the process specified in hProcess.</param>
        /// <param name="lpFilename">A pointer to a buffer that receives the fully qualified path to the module. If the size of the file name is larger than the value of the nSize parameter, the function succeeds but the file name is truncated and null-terminated.</param>
        /// <param name="nSize">The size of the lpFilename buffer, in characters.</param>
        /// <returns>If the function succeeds, the return value specifies the length of the string copied to the buffer. If the function fails, the return value is zero. To get extended error information, call GetLastError.</returns>
        [DllImport(nameof(Psapi), SetLastError = true, CharSet = CharSet.Unicode)]
        public static unsafe extern int GetModuleFileNameEx(
            IntPtr hProcess,
            IntPtr hModule,
            [Friendly(FriendlyFlags.Array | FriendlyFlags.Out, ArrayLengthParameter = 3)] char* lpFilename,
            int nSize);
    }
}
