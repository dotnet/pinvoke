// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace PInvoke
{
    using System.Diagnostics.CodeAnalysis;

    /// <content>
    /// Contains the <see cref="CpuType"/> nested type.
    /// </content>
    public partial class Cabinet
    {
        /// <summary>
        /// In the 16-bit version of FDI, specifies the CPU type and can be any of the following values.
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.NamingRules", "SA1300:Element must begin with upper-case letter", Justification = "Native naming convention")]
        public enum CpuType : int
        {
            /// <summary>
            /// FDI should determine the CPU type.
            /// </summary>
            Unknown = -1,

            /// <summary>
            /// Only 80286 instructions can be used.
            /// </summary>
            _80286 = 0,

            /// <summary>
            /// 80386 instructions can be used.
            /// </summary>
            _80386 = 1,
        }
    }
}
