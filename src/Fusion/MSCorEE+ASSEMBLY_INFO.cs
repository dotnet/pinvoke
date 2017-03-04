// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System.Runtime.InteropServices;

    /// <content>
    /// Contains the <see cref="ASSEMBLY_INFO"/> nested type.
    /// </content>
    public partial class Fusion
    {
        /// <summary>
        /// Contains information about an assembly that is registered in the global assembly cache.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        [OfferIntPtrPropertyAccessors]
        public unsafe partial struct ASSEMBLY_INFO
        {
            /// <summary>
            /// The size, in bytes, of the structure. This field is reserved for future extensibility.
            /// </summary>
            public uint cbAssemblyInfo;

            /// <summary>
            /// Flags that indicate installation details about the assembly.
            /// </summary>
            public AssemblyInfoFlags dwAssemblyFlags;

            /// <summary>
            /// The total size, in kilobytes, of the files that the assembly contains.
            /// </summary>
            public long uliAssemblySizeInKB;

            /// <summary>
            /// A pointer to a string buffer that holds the current path to the manifest file. The path must end with a null character.
            /// </summary>
            public char* pszCurrentAssemblyPathBuf;

            /// <summary>
            /// The number of wide characters, including the null terminator, that <see cref="pszCurrentAssemblyPathBuf"/> contains.
            /// </summary>
            public int cchBuf;

            /// <summary>
            /// Initializes a new instance of the <see cref="ASSEMBLY_INFO"/> struct
            /// with the <see cref="cbAssemblyInfo"/> field initialized.
            /// </summary>
            /// <returns>The newly initialized struct.</returns>
            public static ASSEMBLY_INFO Create()
            {
                return new ASSEMBLY_INFO
                {
                    cbAssemblyInfo = (uint)Marshal.SizeOf(typeof(ASSEMBLY_INFO)),
                };
            }
        }
    }
}
