// Copyright (c) to owners found in https://github.com/AArnott/pinvoke/blob/master/COPYRIGHT.md. All rights reserved.
// Licensed under the MIT license. See LICENSE.txt file in the project root for full license information.

namespace PInvoke
{
    using System.Diagnostics;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.InteropServices;

    partial class Kernel32
    {
        /// <summary>
        /// Nullable wrapper for a <see cref="PipeMode" /> that can be used in <see cref="DllImportAttribute"/>.
        /// Implicit cast operators exists to convert to and from Nullable&lt;PipeMode&gt;.
        /// </summary>
        [SuppressMessage(
            "StyleCop.CSharp.MaintainabilityRules",
            "SA1401:Fields must be private",
            Justification = "Used in DllImport Marshaling.")]
        [DebuggerDisplay("{Value}")]
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public class NullablePipeMode
        {
            public PipeMode Value;

            public NullablePipeMode()
            {
            }

            public NullablePipeMode(PipeMode value)
            {
                this.Value = value;
            }

            public static implicit operator NullablePipeMode(PipeMode? value)
            {
                return value.HasValue ? new NullablePipeMode(value.Value) : null;
            }

            public static implicit operator PipeMode?(NullablePipeMode value)
            {
                return value?.Value;
            }
        }
    }
}
