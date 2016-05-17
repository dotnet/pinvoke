// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Text;

    /// <content>
    /// Contains the <see cref="MODULEENTRY32" /> nested type.
    /// </content>
    public partial class Kernel32
    {
        /// <summary>
        /// Describes an entry from a list of the modules belonging to the specified process.
        /// </summary>
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        [SuppressMessage(
            "StyleCop.CSharp.MaintainabilityRules",
            "SA1401:Fields must be private",
            Justification = "Used in DllImport Marshaling.")]
        [OfferIntPtrPropertyAccessors]
        public unsafe partial struct MODULEENTRY32
        {
            /// <summary>
            /// The size of the structure, in bytes. Set automatically by the <see cref="Create"/> method.
            /// </summary>
            public int dwSize;

            /// <summary>
            /// This member is no longer used, and is always set to one.
            /// </summary>
            public int th32ModuleID;

            /// <summary>
            /// The identifier of the process whose modules are to be examined.
            /// </summary>
            public int th32ProcessID;

            /// <summary>
            /// The load count of the module, which is not generally meaningful, and usually equal to <c>0xFFFF</c>.
            /// </summary>
            public int GlblcntUsage;

            /// <summary>
            /// The load count of the module (same as <see cref="GlblcntUsage"/>), which is not generally meaningful, and usually equal to <c>0xFFFF</c>.
            /// </summary>
            public int ProccntUsage;

            /// <summary>
            /// The base address of the module in the context of the owning process.
            /// </summary>
            public byte* modBaseAddr;

            /// <summary>
            /// The size of the module, in bytes.
            /// </summary>
            public uint modBaseSize;

            /// <summary>
            /// A handle to the module in the context of the owning process.
            /// </summary>
            public void* hModule;

            /// <summary>
            /// The module name.
            /// </summary>
            public fixed char szModule[MAX_MODULE_NAME32 + 1];

            /// <summary>
            /// The module path.
            /// </summary>
            public fixed char szExePath[MAX_PATH];

            /// <summary>
            /// Gets the name of the module, as specified by the <see cref="szModule"/> character array.
            /// </summary>
            public string Module
            {
                get
                {
                    fixed (char* module = this.szModule)
                    {
                        return new string(module);
                    }
                }
            }

            /// <summary>
            /// Gets the executable path for the module, as specified by the <see cref="szExePath"/> character array.
            /// </summary>
            public string ExePath
            {
                get
                {
                    fixed (char* exePath = this.szExePath)
                    {
                        return new string(exePath);
                    }
                }
            }

            /// <summary>
            /// Initializes a new instance of the <see cref="MODULEENTRY32" /> struct
            /// with <see cref="dwSize" /> set to the correct value.
            /// </summary>
            /// <returns>An instance of <see cref="MODULEENTRY32"/>.</returns>
            public static MODULEENTRY32 Create()
            {
                return new MODULEENTRY32
                {
                    dwSize = Marshal.SizeOf(typeof(MODULEENTRY32)),
                    th32ModuleID = 1,
                };
            }
        }
    }
}
