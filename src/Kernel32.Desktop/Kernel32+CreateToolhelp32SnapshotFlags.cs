// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;

    /// <content>
    /// Contains the <see cref="CreateToolhelp32SnapshotFlags"/> nested type.
    /// </content>
    public partial class Kernel32
    {
        /// <summary>
        /// The portions of the system to be included in the snapshot for <see cref="CreateToolhelp32Snapshot"/>.
        /// </summary>
        [Flags]
        public enum CreateToolhelp32SnapshotFlags : uint
        {
            /// <summary>
            /// Indicates that the snapshot handle is to be inheritable.
            /// </summary>
            TH32CS_INHERIT = 0x80000000,

            /// <summary>
            /// Includes all heaps of the process specified in th32ProcessID in the snapshot.
            /// To enumerate the heaps, see Heap32ListFirst.
            /// </summary>
            TH32CS_SNAPHEAPLIST = 0x00000001,

            /// <summary>
            /// Includes all modules of the process specified in th32ProcessID in the snapshot.
            /// To enumerate the modules, see <see cref="Module32First(SafeObjectHandle,MODULEENTRY32*)"/>.
            /// If the function fails with <see cref="Win32ErrorCode.ERROR_BAD_LENGTH"/>, retry the function until
            /// it succeeds.
            /// <para>
            /// 64-bit Windows:  Using this flag in a 32-bit process includes the 32-bit modules of the process
            /// specified in th32ProcessID, while using it in a 64-bit process includes the 64-bit modules.
            /// To include the 32-bit modules of the process specified in th32ProcessID from a 64-bit process, use
            /// the <see cref="TH32CS_SNAPMODULE32"/> flag.
            /// </para>
            /// </summary>
            TH32CS_SNAPMODULE = 0x00000008,

            /// <summary>
            /// Includes all 32-bit modules of the process specified in th32ProcessID in the snapshot when called from
            /// a 64-bit process.
            /// This flag can be combined with <see cref="TH32CS_SNAPMODULE"/> or <see cref="TH32CS_SNAPALL"/>.
            /// If the function fails with <see cref="Win32ErrorCode.ERROR_BAD_LENGTH"/>, retry the function until it
            /// succeeds.
            /// </summary>
            TH32CS_SNAPMODULE32 = 0x00000010,

            /// <summary>
            /// Includes all processes in the system in the snapshot. To enumerate the processes, see
            /// <see cref="Process32First(SafeObjectHandle,PROCESSENTRY32*)"/>.
            /// </summary>
            TH32CS_SNAPPROCESS = 0x00000002,

            /// <summary>
            /// Includes all threads in the system in the snapshot. To enumerate the threads, see
            /// Thread32First.
            /// <para>
            /// To identify the threads that belong to a specific process, compare its process identifier to the
            /// th32OwnerProcessID member of the THREADENTRY32 structure when
            /// enumerating the threads.
            /// </para>
            /// </summary>
            TH32CS_SNAPTHREAD = 0x00000004,

            /// <summary>
            /// Includes all processes and threads in the system, plus the heaps and modules of the process specified in
            /// th32ProcessID.
            /// </summary>
            TH32CS_SNAPALL = TH32CS_SNAPHEAPLIST | TH32CS_SNAPMODULE | TH32CS_SNAPPROCESS | TH32CS_SNAPTHREAD
        }
    }
}
