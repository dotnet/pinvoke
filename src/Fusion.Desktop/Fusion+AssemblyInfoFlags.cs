// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;

    /// <content>
    /// Contains the <see cref="AssemblyInfoFlags"/> nested type.
    /// </content>
    public partial class Fusion
    {
        /// <summary>
        /// Flags that can be specified in <see cref="ASSEMBLY_INFO.dwAssemblyFlags"/>.
        /// </summary>
        [Flags]
        public enum AssemblyInfoFlags
        {
            /// <summary>
            /// No flags.
            /// </summary>
            None = 0x0,

            /// <summary>
            /// Indicates that the assembly is installed. The current version of the .NET Framework always sets dwAssemblyFlags to this value.
            /// </summary>
            ASSEMBLYINFO_FLAG_INSTALLED = 0x1,

            /// <summary>
            /// Indicates that the assembly is a payload resident. The current version of the .NET Framework never sets dwAssemblyFlags to this value.
            /// </summary>
            ASSEMBLYINFO_FLAG_PAYLOADRESIDENT = 0x2,
        }
    }
}
