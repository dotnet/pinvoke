// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.InteropServices;
    using System.Text;

    /// <content>
    /// Contains the <see cref="PROCESSENTRY32" /> nested type.
    /// </content>
    public partial class Kernel32
    {
        /// <summary>
        /// Describes an entry from a list of the processes residing in the system address space when a snapshot was taken.
        /// </summary>
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        [SuppressMessage(
            "StyleCop.CSharp.MaintainabilityRules",
            "SA1401:Fields must be private",
            Justification = "Used in DllImport Marshaling.")]
        [OfferIntPtrPropertyAccessors]
        public unsafe partial struct PROCESSENTRY32
        {
            /// <summary>
            /// The size of the structure, in bytes. Set automatically by the <see cref="Create"/> method.
            /// </summary>
            public int dwSize;

            /// <summary>
            /// This member is no longer used and is always set to zero.
            /// </summary>
            public int cntUsage;

            /// <summary>
            /// The process identifier.
            /// </summary>
            public int th32ProcessID;

            /// <summary>
            /// This member is no longer used and is always set to zero.
            /// </summary>
            public IntPtr th32DefaultHeapID;

            /// <summary>
            /// This member is no longer used and is always set to zero.
            /// </summary>
            public int th32ModuleID;

            /// <summary>
            /// The number of execution threads started by the process.
            /// </summary>
            public int cntThreads;

            /// <summary>
            /// The identifier of the process that created this process (its parent process).
            /// </summary>
            public int th32ParentProcessID;

            /// <summary>
            /// The base priority of any threads created by this process.
            /// </summary>
            public int pcPriClassBase;

            /// <summary>
            /// This member is no longer used, and is always set to zero.
            /// </summary>
            public uint dwFlags;

            /// <summary>
            /// The name of the executable file for the process.
            /// <para>
            /// To retrieve the full path to the executable file, call the Module32First function and check the szExePath member
            /// of the MODULEENTRY32 structure that is returned. However, if the calling process is a 32-bit process, you must call the
            /// <see cref="QueryFullProcessImageName(SafeObjectHandle, QueryFullProcessImageNameFlags, char*, ref int)" />
            /// function to retrieve the full path of the executable file for a 64-bit process.
            /// </para>
            /// </summary>
            public fixed char szExeFile[MAX_PATH];

            /// <summary>
            /// Gets the name of the executable file for the process, as specified by the <see cref="szExeFile"/> character array.
            /// <para>
            /// To retrieve the full path to the executable file, call the <see cref="Kernel32.Module32First(SafeObjectHandle,MODULEENTRY32*)"/> function and check the <see cref="MODULEENTRY32.szExePath"/> member
            /// of the <see cref="MODULEENTRY32"/> structure that is returned. However, if the calling process is a 32-bit process, you must call the
            /// <see cref="QueryFullProcessImageName(SafeObjectHandle, QueryFullProcessImageNameFlags, char*, ref int)" />
            /// function to retrieve the full path of the executable file for a 64-bit process.
            /// </para>
            /// </summary>
            public string ExeFile
            {
                get
                {
                    fixed (char* exeFile = this.szExeFile)
                    {
                        return new string(exeFile);
                    }
                }
            }

            /// <summary>
            /// Initializes a new instance of the <see cref="PROCESSENTRY32" /> struct
            /// with <see cref="dwSize" /> set to the correct value.
            /// </summary>
            /// <returns>An instance of <see cref="PROCESSENTRY32"/>.</returns>
            public static PROCESSENTRY32 Create()
            {
                return new PROCESSENTRY32
                {
                    dwSize = Marshal.SizeOf(typeof(PROCESSENTRY32)),
                };
            }
        }
    }
}
