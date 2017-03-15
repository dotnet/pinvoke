// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Runtime.InteropServices;
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
    }
}
