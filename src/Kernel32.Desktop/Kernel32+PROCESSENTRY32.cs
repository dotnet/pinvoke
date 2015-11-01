// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.InteropServices;
    using System.Text;

    /// <content>
    /// Contains the <see cref="PROCESSENTRY32" /> nested struct.
    /// </content>
    public partial class Kernel32
    {
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        [SuppressMessage(
            "StyleCop.CSharp.MaintainabilityRules",
            "SA1401:Fields must be private",
            Justification = "Used in DllImport Marshaling.")]
        public class PROCESSENTRY32
        {
            /// <summary>
            /// The size of the structure, in bytes. Set automatically by the constructor.
            /// </summary>
            public uint dwSize;

            /// <summary>
            /// This member is no longer used and is always set to zero.
            /// </summary>
            public uint cntUsage;

            /// <summary>
            /// The process identifier.
            /// </summary>
            public uint th32ProcessID;

            /// <summary>
            /// This member is no longer used and is always set to zero.
            /// </summary>
            public IntPtr th32DefaultHeapID;

            /// <summary>
            /// This member is no longer used and is always set to zero.
            /// </summary>
            public uint th32ModuleID;

            /// <summary>
            /// The number of execution threads started by the process.
            /// </summary>
            public uint cntThreads;

            /// <summary>
            /// The identifier of the process that created this process (its parent process).
            /// </summary>
            public uint th32ParentProcessID;

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
            /// <see cref="QueryFullProcessImageName(SafeObjectHandle,QueryFullProcessImageNameFlags,StringBuilder,ref uint)" />
            /// function to retrieve the full path of the executable file for a 64-bit process.
            /// </para>
            /// </summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_PATH)]
            public string szExeFile;

            /// <summary>
            /// Initializes a new instance of the <see cref="PROCESSENTRY32" /> class with <see cref="dwSize" /> set to the
            /// correct value.
            /// </summary>
            public PROCESSENTRY32()
            {
                this.dwSize = (uint)Marshal.SizeOf(this);
            }
        }
    }
}
