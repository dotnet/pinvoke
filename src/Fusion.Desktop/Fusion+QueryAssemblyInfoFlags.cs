// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System;

    /// <content>
    /// Contains the <see cref="QueryAssemblyInfoFlags"/> nested type.
    /// </content>
    public partial class Fusion
    {
        /// <summary>
        /// The flags that may be passed to the <see cref="IAssemblyCache.QueryAssemblyInfo"/> method.
        /// </summary>
        [Flags]
        public enum QueryAssemblyInfoFlags
        {
            /// <summary>
            /// No flags.
            /// </summary>
            None = 0x0,

            /// <summary>
            /// Validates the assembly files in the side-by-side assembly store against the assembly manifest. This includes the verification of the assembly's hash and strong name signature.
            /// </summary>
            QUERYASMINFO_FLAG_VALIDATE = 0x1,

            /// <summary>
            /// Returns the size of all files in the assembly.
            /// </summary>
            QUERYASMINFO_FLAG_GETSIZE = 0x2,
        }
    }
}
